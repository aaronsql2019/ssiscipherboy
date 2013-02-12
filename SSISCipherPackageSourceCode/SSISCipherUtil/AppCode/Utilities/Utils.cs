using System;
using System.Collections.Generic;
using System.Text;

using System.Text.RegularExpressions;
using System.IO;
using System.Xml;
using System.Windows.Forms;
using System.Drawing;

namespace SSISCipherUtil
{
    public static class Utils
    {
        private static bool xDocAttributeMatch = default(bool);

        public static string BytesToBase64String(byte[] inputBytes)
        {
            return Convert.ToBase64String(inputBytes);
        }

        public static byte[] Base64StringToBytes(string inputBase64String)
        {
            return Convert.FromBase64String(inputBase64String);
        }

        public static string UTF8BytesToString(byte[] inputUTF8Bytes)
        {
            return new UTF8Encoding().GetString(inputUTF8Bytes);
        }

        public static byte[] StringToUTF8Bytes(string inputString)
        {
            return new UTF8Encoding().GetBytes(inputString);
        }

        public static byte[] ConcatStringsToBytes(params string[] input)
        {
            string buffer = string.Concat(input);

            return Utils.StringToUTF8Bytes(buffer);
        }

        public static byte[] ConcatByteArrarys(params byte[] [] input)
        {
            List<byte> list = new List<byte>();
            foreach (byte[] byteArray in input)
            {
                foreach (byte b in byteArray)
                {
                    list.Add(b);
                }
            }

            return list.ToArray();
        }

        public static bool CheckForRegExMatch(string data, string pattern, RegexOptions regExOptions)
        {
            Regex regEx = new Regex(pattern, RegexOptions.IgnoreCase);
            return regEx.IsMatch(data);
        }

        /// <summary>
        /// Writes the given string to a file, if file exists already, it is overwritten
        /// </summary>
        /// <param name="data"></param>
        /// <param name="filePath"></param>
        public static void WriteStringToFile(string data, string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.Write(data);
                    sw.Flush();
                    sw.Close();
                }
            }
        }

        /// <summary>
        /// Reads the contents of the file specified in filePath as string
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string ReadStringFromFile(string filePath)
        {
            string retVal = default(string);
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    retVal = sr.ReadToEnd();
                    sr.Close();
                }
            }
            return retVal;
        }

        public static void ConvertXmlNodeToTreeNode(XmlNode xmlNode, TreeNodeCollection treeNodes, bool isAttribute = false)
        {
            TreeNode newTreeNode;
            newTreeNode = treeNodes.Add(xmlNode.Name);


            switch (xmlNode.NodeType)
            {
                case XmlNodeType.ProcessingInstruction:
                case XmlNodeType.XmlDeclaration:
                    {
                        newTreeNode.Text = "<?" + xmlNode.Name + " " + xmlNode.Value + "?>";
                        break;
                    }
                case XmlNodeType.Element:
                    {
                        if (xmlNode.HasChildNodes)
                            newTreeNode.Text = "<" + xmlNode.Name + ">";
                        else
                            newTreeNode.Text = "<" + xmlNode.Name + "/>";
                        break;
                    }
                case XmlNodeType.Attribute:
                    {
                        TreeNode parentNode = newTreeNode.Parent;
                        string parentText = newTreeNode.Parent.Text;
                        string toAppend = " " + xmlNode.Name + "=";
                        int insertPos = parentText.IndexOfAny(new char[] { '>', '/' });
                        newTreeNode.Parent.Text = parentText.Insert(insertPos, toAppend);

                        //newTreeNode.Text = "ATTRIBUTE: " + xmlNode.Name;
                        newTreeNode.Remove();
                        newTreeNode = parentNode;

                        break;
                    }
                case XmlNodeType.CDATA:
                    {
                        newTreeNode.Text = xmlNode.Value;
                        break;
                    }
                case XmlNodeType.Text:
                    {
                        if (isAttribute)
                        {
                            string parentText = newTreeNode.Parent.Text;
                            string toAppendText = "\"" + xmlNode.Value + "\" ";
                            int insertPos = parentText.LastIndexOf('=') + 1;
                            newTreeNode.Parent.Text = parentText.Insert(insertPos, toAppendText);

                            newTreeNode.Remove();
                        }
                        else
                        {
                            newTreeNode.Text = xmlNode.Value;
                        }
                        break;
                    }
            }

            if (newTreeNode.Level == 4)
            {
                if (newTreeNode.Text.IndexOf("[DPAPI]", StringComparison.InvariantCultureIgnoreCase) == 0 || newTreeNode.Text.IndexOf("[RSA-", StringComparison.InvariantCultureIgnoreCase) == 0)
                {
                    newTreeNode.ForeColor = Color.DarkGreen;
                }
                else
                {
                    newTreeNode.ForeColor = Color.DarkRed;
                }
                
            }

            if (xmlNode.Attributes != null)
            {
                foreach (XmlAttribute attribute in xmlNode.Attributes)
                {
                    ConvertXmlNodeToTreeNode(attribute, newTreeNode.Nodes, true);
                }
            }

            foreach (XmlNode childNode in xmlNode.ChildNodes)
            {
                ConvertXmlNodeToTreeNode(childNode, newTreeNode.Nodes, isAttribute);
            }
        }

        public static void SeekAndStreak(XmlNode xNode, string key, string operation, EncryptionProvider provider, string keyContainerName)
        {
            switch (xNode.NodeType)
            {
                case XmlNodeType.Attribute:
                    {
                        if (string.Compare(xNode.Name, "Path", StringComparison.InvariantCultureIgnoreCase) == 0)
                        {
                            //check if matches the key
                            if (string.Compare(xNode.Value, key, StringComparison.InvariantCultureIgnoreCase) == 0)
                            {
                                xDocAttributeMatch = true;
                            }
                        }
                        break;
                    }
            }

            if (xNode.Attributes != null)
            {
                foreach (XmlAttribute attribute in xNode.Attributes)
                {
                    SeekAndStreak(attribute, key, operation, provider, keyContainerName);
                }
            }


            if (xDocAttributeMatch == true)
            {
                if (xNode.NodeType == XmlNodeType.Attribute)
                    return;
            }


            foreach (XmlNode node in xNode.ChildNodes)
            {
                try
                {
                    if (xDocAttributeMatch == true)
                    {
                        XmlNode targetNode = node.ChildNodes[0];
                        //string targetValue = targetNode.Value;
                        string targetValue = targetNode.Value;

                        switch (operation)
                        {
                            case "cipher":
                                {
                                    switch (provider)
                                    {
                                        case EncryptionProvider.DPAPI:
                                            {
                                                targetNode.Value = SSISInterceptor.Encrypt(targetValue, provider, keyContainerName);
                                                break;
                                            }
                                        case EncryptionProvider.RSA:
                                            {
                                                targetNode.Value = SSISInterceptor.Encrypt(targetValue, provider, keyContainerName);
                                                break;
                                            }
                                    }
                                    break;
                                }
                            case "decipher":
                                {
                                    switch (provider)
                                    {
                                        case EncryptionProvider.DPAPI:
                                            {
                                                targetNode.Value = SSISInterceptor.Decrypt(targetValue);
                                                break;
                                            }
                                        case EncryptionProvider.RSA:
                                            {
                                                targetNode.Value = SSISInterceptor.Decrypt(targetValue);
                                                break;
                                            }
                                    }
                                    break;
                                }
                        }

                        //once done, set the xDocAttributeMatch flag to false and let other nodes be worked out
                        xDocAttributeMatch = false;

                    }

                    SeekAndStreak(node, key, operation, provider, keyContainerName);

                }
                catch (Exception)
                {
                    xDocAttributeMatch = false;
                    throw;
                }

            }
        }

        public static void StartTransforming(XmlNode xNode, string[] intendedKeys, string operation, EncryptionProvider provider, string keyContainerName)
        {
            List<String> dataTypeExclusionList = new List<string>();
            for (int i = 0; i < intendedKeys.Length; i++)
            {
                //sample string from intendedKeys
                //<Configuration ConfiguredType="Property"  Path="\Package.Variables[User::varUInt64].Properties[Value]"  ValueType="UInt64" >
                string searchKey = intendedKeys[i];
                int startPos, endPos, subStringLength;

                startPos = searchKey.IndexOf("Path=\"", StringComparison.InvariantCultureIgnoreCase) + 6;
                endPos = searchKey.IndexOf("\"", startPos, StringComparison.InvariantCultureIgnoreCase);

                subStringLength = endPos - startPos;

                searchKey = searchKey.Substring(startPos, subStringLength);

                SeekAndStreak(xNode, searchKey, operation, provider, keyContainerName);   
            }
        }

        public static bool CheckForAllowedDataType(string inputString)
        {
            int startPos, endPos, subStringLength;   
            Boolean retVal = true;
            List<string> allowedDateTypes = GetAllowedDataTypeList();
            startPos = inputString.IndexOf("ValueType=\"", StringComparison.InvariantCultureIgnoreCase) + 11;
            endPos = inputString.IndexOf("\"", startPos, StringComparison.InvariantCultureIgnoreCase);
            subStringLength = endPos - startPos;
            inputString = inputString.Substring(startPos, subStringLength).ToUpper();

            if (!allowedDateTypes.Contains(inputString))
            {
                retVal = false;
            }
            return retVal;
        }

        private static List<string> GetAllowedDataTypeList()
        {
            //check for String --> allow thems
            List<string> retVal = new List<string>();
            retVal.Add("String".ToUpper());
            /* -- old code --
            //retVal.Add("Char".ToUpper());
            //retVal.Add("Byte".ToUpper());
            //retVal.Add("SByte".ToUpper());
            //retVal.Add("Int16".ToUpper());
            //retVal.Add("Int32".ToUpper());
            //retVal.Add("Int64".ToUpper());
            //retVal.Add("UInt32".ToUpper());
            //retVal.Add("UInt64".ToUpper());
            //retVal.Add("Single".ToUpper());
            //retVal.Add("Double".ToUpper());
            //retVal.Add("DateTime".ToUpper()); 
             * */
            return retVal;
        }

        private static List<string> GetAllowedDtsItems()
        {
            List<string> retVal = new List<string>();
            retVal.Add("Package.Variables[User::");
            retVal.Add("Package.Connections[");
            return retVal;
        }

        public static bool CheckForAllowedDtsItem(string inputString)
        {
            int startPos, endPos, subStringLength;
            Boolean retVal = true;
            List<string> allowedDtsItems = GetAllowedDtsItems();
            startPos = inputString.IndexOf("Path=\"", StringComparison.InvariantCultureIgnoreCase) + 6;
            endPos = inputString.IndexOf("\"", startPos, StringComparison.InvariantCultureIgnoreCase);
            subStringLength = endPos - startPos;
            inputString = inputString.Substring(startPos, subStringLength);


            if (inputString.IndexOf("Package.Variables[User::") != 0)
            {
                if (inputString.IndexOf("Package.Variables[User::") != 1)
                {
                    if (inputString.IndexOf("Package.Connections[") != 0)
                    {
                        if (inputString.IndexOf("Package.Connections[") != 1)
                        {
                            retVal = false;
                        }
                    }
                }
            }
            if (retVal)
            {
                //check for .Properties[Value]
                if (inputString.IndexOf("Package.Variables[User::") == 0 || inputString.IndexOf("Package.Variables[User::") == 1)
                {
                    if(!inputString.EndsWith(".Properties[Value]"))
                    {
                        retVal = false;
                    }
                }
            }
            return retVal;
        }
    }
}

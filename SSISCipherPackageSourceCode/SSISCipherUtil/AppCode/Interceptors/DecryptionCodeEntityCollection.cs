using System;
using System.Collections.Generic;
using System.Text;

namespace SSISCipherUtil
{
    public sealed class DecryptionCodeEntityCollection
    {
        private string propertyName;
        private string dtsObjectType;
        private string cSharpVariableName;
        private string dtsObjectName;
        private List<DecryptionCodeEntityCollection> decryptionEntityCollection;

        private string PropertyName { get { return propertyName; } }
        private string DtsObjectType { get { return dtsObjectType; } }
        private string CSharpVariableName { get { return cSharpVariableName; } }
        private string DtsObjectName { get { return dtsObjectName; } }
        private List<DecryptionCodeEntityCollection> DecryptionEntityCollection { get { return decryptionEntityCollection; } }

        public DecryptionCodeEntityCollection() 
        {
            decryptionEntityCollection = new List<DecryptionCodeEntityCollection>();
        }

        public DecryptionCodeEntityCollection(string pPropertyName, string pDtsObjectType, string pCSharpVariableName, string pDtsObjectName)
        {
            this.propertyName = pPropertyName;
            this.dtsObjectType = pDtsObjectType;
            this.cSharpVariableName = pCSharpVariableName;
            this.dtsObjectName = pDtsObjectName;
            decryptionEntityCollection = new List<DecryptionCodeEntityCollection>();
        }

        private void AddToDecryptionEntityCollection(DecryptionCodeEntityCollection input)
        {
            decryptionEntityCollection.Add(input);
        }

        private static string GetConnectionManagerDecryptorCode(DecryptionCodeEntityCollection input)
        {
            return string.Format("DecryptAndSetConnectionProperty(\"{0}\", \"{1}\");", input.DtsObjectName, input.PropertyName);
        }

        private static string GetVariableDecryptorCode(DecryptionCodeEntityCollection input)
        {
            return string.Format("DecryptAndSetVariable(\"{0}\");", input.DtsObjectName);
        }

        public static List<string> ObtainDecryptorCode(string[] intendedKeys)
        {
            List<DecryptionCodeEntityCollection> input = GetDecryptorCodeRequisites(intendedKeys);

            if (input == null)
                return new List<string>();
                  
            List<string> decryptorCodeLines = new List<string>();

            foreach (DecryptionCodeEntityCollection decryptorCode in input)
            {
                if (decryptorCode.dtsObjectType == "Connections")
                {
                    decryptorCodeLines.Add(GetConnectionManagerDecryptorCode(decryptorCode));
                }
                else if (decryptorCode.dtsObjectType == "Variables")
                {
                    decryptorCodeLines.Add(GetVariableDecryptorCode(decryptorCode));
                }
            }

            return decryptorCodeLines;
        }

        public static string ReplaceScriptMainDotCs(List<string> decryptorCodeLines, ref StringBuilder scriptDotMainContent)
        {
            string code = "";

            foreach (string codeLine in decryptorCodeLines)
            {
                code = code + "\t\t\t" + codeLine + Environment.NewLine;
            }

            return scriptDotMainContent.Replace("/*[[[[INSERTSSISCIPHERUTILDECRYPTORCODEHERE]]]]*/", code).ToString();
        }

        private static List<DecryptionCodeEntityCollection> GetDecryptorCodeRequisites(string[] intendedKeys)
        {
            if (intendedKeys.Length == 0)
                return null;

            foreach (string s in intendedKeys)
            {
                if (!Utils.CheckForAllowedDtsItem(s))
                    throw new DtsItemNotAllowedException();
                if (!Utils.CheckForAllowedDataType(s))
                    throw new DataTypeNotAllowedException();
            }

            int startPos, endPos, subStringLength;
            string input, searchKey, variableName, csVariableName, dtsObjectType, propertyType;
            input = searchKey = variableName = csVariableName = dtsObjectType = propertyType = default(string);
            DecryptionCodeEntityCollection retVal = new DecryptionCodeEntityCollection();

            for (int i = 0; i < intendedKeys.Length; i++)
            {
                searchKey = intendedKeys[i];

                startPos = searchKey.IndexOf("Path=\"", StringComparison.InvariantCultureIgnoreCase) + 6;
                endPos = searchKey.IndexOf("\"", startPos, StringComparison.InvariantCultureIgnoreCase);
                subStringLength = endPos - startPos;
                input = searchKey = searchKey.Substring(startPos, subStringLength);

                /*
                * <Configuration ValueType="String" Path="\Package.Variables[User::packageLevelVariable].Properties[Value]" ConfiguredType="Property">
   <Configuration ValueType="String" Path="\Package.Connections[localhost.formyworkouts.EncrDemoUser].Properties[ConnectionString]" ConfiguredType="Property">
                * 
                */
                //"\Package.Variables[User::var11].Properties[Value]"
                //"\Package.Connections[FTP Connection Manager].Properties[Timeout]"

                //after the word Package and before the first [
                startPos = input.IndexOf("Package.", StringComparison.InvariantCultureIgnoreCase) + 8;
                endPos = input.IndexOf('[');
                subStringLength = endPos - startPos;
                dtsObjectType = input.Substring(startPos, subStringLength);

                //contents of the first square brackets
                startPos = input.IndexOf("[", StringComparison.InvariantCultureIgnoreCase) + 1;
                endPos = input.IndexOf(']');
                subStringLength = endPos - startPos;
                variableName = input.Substring(startPos, subStringLength);
                csVariableName = variableName.Replace(' ', '_').Replace('.', '_');

                if (input.IndexOf("::", StringComparison.InvariantCultureIgnoreCase) >= 0)
                {
                    //after :: before ]
                    startPos = input.IndexOf("::", StringComparison.InvariantCultureIgnoreCase) + 2;
                    endPos = input.IndexOf(']');
                    subStringLength = endPos - startPos;
                    csVariableName = input.Substring(startPos, subStringLength).Replace(' ', '_').Replace('.', '_');
                }

                //after Properties[ before ]
                startPos = input.IndexOf("Properties[", StringComparison.InvariantCultureIgnoreCase) + 11;
                endPos = input.IndexOf(']', startPos);
                subStringLength = endPos - startPos;
                propertyType = input.Substring(startPos, subStringLength);

                retVal.AddToDecryptionEntityCollection(new DecryptionCodeEntityCollection() { cSharpVariableName = csVariableName, dtsObjectName = variableName, dtsObjectType = dtsObjectType, propertyName = propertyType });
            }

            return retVal.DecryptionEntityCollection;
        }

    }  
}

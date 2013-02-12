using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using System.EnterpriseServices.Internal;
using System.Reflection;
using System.IO;
using System.Diagnostics;
using System.Security;

namespace SSISCipherBoy
{
    class AssemblyAdministration
    {
        public static string targetAssemblyName = "SSISCipherUtil.dll";
        public static string targetAssemblyFullName = "SSISCipherUtil, Version=1.2.0.0, Culture=Neutral, PublicKeyToken=4b5e336c740c405d";
        static Assembly currentAssembly = Assembly.GetExecutingAssembly();
    
        public static void RunOnce()
        {
            //try loading the assembly with strong name
            try
            {
                Assembly targetAssembly = Assembly.Load(targetAssemblyFullName);
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show(text: "It seems that this is the first time you are running this program or the SSISCipherUtil.dll could not be loaded with the strong name reference. This program will try to install SSISCipherUtil.dll to the GAC now.", caption: "Prerequisite missing", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Exclamation);

                try
                {
                    WriteAssemblyAndInstall();
                    Application.Restart();
                }
                catch (Exception eX)
                {
                    MessageBox.Show(text: eX.Message, caption: "Something went wrong!", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
                }
            }
        }

        public static void WriteAssemblyToFile(string outputAssemblyName)
        {
            string[] embeddedResourcesArray = currentAssembly.GetManifestResourceNames();

            foreach (string resourceName in embeddedResourcesArray)
            {
                if (resourceName.EndsWith(targetAssemblyName, StringComparison.InvariantCultureIgnoreCase))
                {
                    FileStream outputStream = new FileStream(outputAssemblyName, FileMode.Create, FileAccess.ReadWrite);
                    Stream resourceStream = currentAssembly.GetManifestResourceStream(resourceName);

                    const int size = 4096;
                    byte[] bytes = new byte[4096];
                    int numBytes;

                    while ((numBytes = resourceStream.Read(bytes, 0, size)) > 0)
                    {
                        outputStream.Write(bytes, 0, numBytes);
                    }

                    outputStream.Flush();
                    resourceStream.Flush();
                    outputStream.Close();
                    resourceStream.Close();
                }
            }
        }

        private static void InstallAssemblyToGAC(string outputAssemblyName)
        {
            new Publish().GacInstall(outputAssemblyName);
        }

        private static void UninstallAssemblyFromGAC(string outputAssemblyName)
        {
            new Publish().GacRemove(outputAssemblyName);
        }

        public static void WriteAssemblyAndInstall()
        {
            bool tempPathUsed = default(bool);
            try
            {
                WriteAssemblyToFile(targetAssemblyName);
            }
            catch (SecurityException)
            {
                WriteAssemblyToFile(Path.Combine(System.IO.Path.GetTempPath(), targetAssemblyName));
                tempPathUsed = true;
            }
            catch (UnauthorizedAccessException)
            {
                WriteAssemblyToFile(Path.Combine(System.IO.Path.GetTempPath(), targetAssemblyName));
                tempPathUsed = true;
            }
            catch (IOException)
            {
                WriteAssemblyToFile(Path.Combine(System.IO.Path.GetTempPath(), targetAssemblyName));
                tempPathUsed = true;
            }

            if (tempPathUsed)
            {
                InstallAssemblyToGAC(Path.Combine(System.IO.Path.GetTempPath(), targetAssemblyName));
                MessageBox.Show(text: targetAssemblyName + " installed to GAC.", caption: "Success", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
                File.Delete(Path.Combine(System.IO.Path.GetTempPath(), targetAssemblyName));
            }
            else
            {
                InstallAssemblyToGAC(targetAssemblyName);
                MessageBox.Show(text: targetAssemblyName + " installed to GAC.", caption: "Success", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
                File.Delete(targetAssemblyName);
            }
        }

        public static void WriteAssemblyAndUninstall()
        {
            bool tempPathUsed = default(bool);
            try
            {
                WriteAssemblyToFile(targetAssemblyName);
            }
            catch (SecurityException)
            {
                WriteAssemblyToFile(Path.Combine(System.IO.Path.GetTempPath(), targetAssemblyName));
                tempPathUsed = true;
            }
            catch (UnauthorizedAccessException)
            {
                WriteAssemblyToFile(Path.Combine(System.IO.Path.GetTempPath(), targetAssemblyName));
                tempPathUsed = true;
            }

            if (tempPathUsed)
            {
                UninstallAssemblyFromGAC(Path.Combine(System.IO.Path.GetTempPath(), targetAssemblyName));
                MessageBox.Show(text: targetAssemblyName + " uninstalled from GAC.", caption: "Success", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
                File.Delete(Path.Combine(System.IO.Path.GetTempPath(), targetAssemblyName));
            }
            else
            {
                UninstallAssemblyFromGAC(targetAssemblyName);
                MessageBox.Show(text: targetAssemblyName + " uninstalled from GAC.", caption: "Success", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Information);
                File.Delete(targetAssemblyName);
            }
        }
    }
}

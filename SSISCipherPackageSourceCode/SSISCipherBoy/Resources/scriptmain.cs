/*
   Microsoft SQL Server Integration Services Script Task
   Write scripts using Microsoft Visual C# 2008.
   The ScriptMain is the entry point class of the script.
*/

using System;
using System.Data;
using Microsoft.SqlServer.Dts.Runtime;
using System.Windows.Forms;

namespace stSSISCipherUtil_DecryptConfigValues
{
    [System.AddIn.AddIn("ScriptMain", Version = "1.0", Publisher = "", Description = "")]
    public partial class ScriptMain : Microsoft.SqlServer.Dts.Tasks.ScriptTask.VSTARTScriptObjectModelBase
    {

        #region VSTA generated code
        enum ScriptResults
        {
            Success = Microsoft.SqlServer.Dts.Runtime.DTSExecResult.Success,
            Failure = Microsoft.SqlServer.Dts.Runtime.DTSExecResult.Failure
        };
        #endregion

        /*
		The execution engine calls this method when the task executes.
		To access the object model, use the Dts property. Connections, variables, events,
		and logging features are available as members of the Dts property as shown in the following examples.

		To reference a variable, call Dts.Variables["MyCaseSensitiveVariableName"].Value;
		To post a log entry, call Dts.Log("This is my log text", 999, null);
		To fire an event, call Dts.Events.FireInformation(99, "test", "hit the help message", "", 0, true);

		To use the connections collection use something like the following:
		ConnectionManager cm = Dts.Connections.Add("OLEDB");
		cm.ConnectionString = "Data Source=localhost;Initial Catalog=AdventureWorks;Provider=SQLNCLI10;Integrated Security=SSPI;Auto Translate=False;";

		Before returning from this method, set the value of Dts.TaskResult to indicate success or failure.
		
		To open Help, press F1.
	*/

        public void Main()
        {
            // TODO: Add your code here

            /*[[[[INSERTSSISCIPHERUTILDECRYPTORCODEHERE]]]]*/

            Dts.TaskResult = (int)ScriptResults.Success;
        }

        #region SSISCipherUtil.dll method callers

        private void DecryptAndSetVariable(string varName)
        {
            string variableValue = (string)ReadVariable(varName);
            WriteVariable(varName, (object)DecryptString(variableValue));
        }

        private void DecryptAndSetConnectionProperty(string connectionManagerName, string propertyName)
        {
            ConnectionManager connectionManager = Dts.Connections[connectionManagerName];
            string unEncryptedPropertyValue = (string)connectionManager.Properties[propertyName].GetValue(connectionManager);
            connectionManager.Properties[propertyName].SetValue(connectionManager, (object)DecryptString(unEncryptedPropertyValue));
        }

        private void WriteVariable(string varName, object varValue)
        {
            Variables vars = default(Variables);
            try
            {
                Dts.VariableDispenser.LockForWrite(varName);
                Dts.VariableDispenser.GetVariables(ref vars);
                try
                {
                    vars[varName].Value = varValue;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    vars.Unlock();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private Object ReadVariable(string varName)
        {
            Object retVal = default(Object);
            Variables vars = default(Variables);
            try
            {
                Dts.VariableDispenser.LockForRead(varName);
                Dts.VariableDispenser.GetVariables(ref vars);
                try
                {
                    retVal = vars[varName].Value;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    vars.Unlock();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return retVal;
        }

        private string DecryptString(string input)
        {
            string retVal = default(string);
            try
            {
                retVal = SSISCipherUtil.SSISInterceptor.Decrypt(input);
            }
            catch (SSISCipherUtil.InvalidEncryptionProviderException iEPEx)
            {
                retVal = input;
                Dts.Log("SSISCipherUtil.dll: Returning non decrypted string as it is. Error Details - " + iEPEx.Message, 0, null);
            }
            catch (InvalidCastException)
            {
                Dts.Log("SSISCipherUtil.dll: An Error occurred while converting decrypted string to its original datatype. ", 0, null);
                throw;
            }
            return retVal;
        }

        #endregion

    }
}
using System;
using System.Diagnostics;
using System.Windows;

namespace Executable_Dependency
{
    class ProcessException : Exception
    {
        public ProcessException(String exception)
        {
            MessageBox.Show(exception);
        }
    }

    class ProcessInformation 
    {
        String ProcessName;

        public ProcessInformation()
        {
            ProcessName = null;
        }

        public ProcessInformation(String ProcessName)
        {
            this.ProcessName = ProcessName;
        }

        public ProcessModuleCollection GetProcessInfo()
        {
            ProcessModuleCollection myProcessModuleCollection = null;
            Process myProcess = new Process();
            ProcessStartInfo myProcessStartInfo = new ProcessStartInfo(ProcessName);

            try
            {
                myProcess.StartInfo = myProcessStartInfo;
                myProcess.Start();
                System.Threading.Thread.Sleep(1000);
                myProcessModuleCollection = myProcess.Modules;
            }
            catch (Exception e)
            {
                throw new ProcessException(e.Message);
            }
            finally
            {
                //  myProcess.CloseMainWindow();
                myProcess.Kill();
               // myProcess.Close();
              //  myProcess.Dispose();
            }

            return myProcessModuleCollection;
        }
    }

}

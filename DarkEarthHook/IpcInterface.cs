using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DarkEarthHook
{
    public class IpcInterface : MarshalByRefObject
    {
        public void NotifySucessfulInstallation(Int32 inClientPID)
        {
            Debug.WriteLine(String.Format("DarkEarthHook has been installed in target {0}.\r\n", inClientPID));
        }

        public void OnHooking()
        {

        }

        public void ReportException(Exception inInfo)
        {
            MessageBox.Show("The target process has reported an error:\r\n" + inInfo.ToString());
        }

        public void Ping()
        {
        }
    }
}

using DarkEarthHook;
using EasyHook;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.Remoting;

namespace DarkEarthLauncher.Hook
{
    class HookLauncher
    {
        private static string _targetExe = "";
        private static String ChannelName;

        public static Process Run(string exeName)
        {
            _targetExe = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), exeName);
            Int32 targetPid = 0;
            if (!File.Exists(_targetExe))
            {
                throw new FileNotFoundException(_targetExe);
            }

            RemoteHooking.IpcCreateServer<IpcInterface>(ref ChannelName, WellKnownObjectMode.SingleCall);
            string injectionLibrary = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "DarkEarthHook.dll");
            RemoteHooking.CreateAndInject(_targetExe, "-1 32K", 0, InjectionOptions.DoNotRequireStrongName, injectionLibrary, injectionLibrary, out targetPid, ChannelName);

            var gameProcess = Process.GetProcessById(targetPid);
#if (DEBUG)
            Debug.WriteLine(String.Format("Dark Earth launched and injected successfully. PID : {0}", targetPid));
#endif
            return gameProcess;
        }
    }
}

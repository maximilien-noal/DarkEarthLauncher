using EasyHook;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DarkEarthHook
{
    public class DarkHook : IEntryPoint
    {
        private static IpcInterface _ipcInterface;
        private static string _runningDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        private static string[] _dataDirs = { "EARTH", "DATAS", "ANM", "BIGANIMS", "SAVE", "PERSOS", "WAV", "DIALOG", "OBJETS", "SC" };
        LocalHook _createFileLocalHook;

        public static IntPtr CreateFileHookMethod(
            [MarshalAs(UnmanagedType.LPStr)] string filename,
            [MarshalAs(UnmanagedType.U4)] FileAccess access,
            [MarshalAs(UnmanagedType.U4)] FileShare share,
            IntPtr securityAttributes,
            [MarshalAs(UnmanagedType.U4)] FileMode creationDisposition,
            [MarshalAs(UnmanagedType.U4)] FileAttributes flagsAndAttributes,
            IntPtr templateFile)
        {
            if(String.IsNullOrWhiteSpace(filename))
            {
                return CreateFile(filename, access, share, securityAttributes, creationDisposition, flagsAndAttributes, templateFile);
            }

            string correctedFilename = "";

            if(Path.IsPathRooted(filename))
            {
                string pathWithoutRoot = filename.Remove(0, Path.GetPathRoot(filename).Length);
                pathWithoutRoot = pathWithoutRoot.ToUpper();
                if(_dataDirs.Any(x => pathWithoutRoot.StartsWith(x)))
                {
                    correctedFilename = Path.Combine(_runningDirectory, pathWithoutRoot);
                }
            }

            if (filename.StartsWith(@"CDROM0:\"))
            {
                correctedFilename = Path.Combine(_runningDirectory, filename.Replace(@"CDROM0:\", ""));
            }

            if (filename.StartsWith(@"CDROM1:\"))
            {
                correctedFilename = Path.Combine(_runningDirectory, filename.Replace(@"CDROM1:\", ""));
            }

            if (filename.StartsWith(@"CDROM2:\"))
            {
                correctedFilename = Path.Combine(_runningDirectory, filename.Replace(@"CDROM2:\", ""));
            }

            if (filename.Contains(@"CD1.CHK"))
            {
                correctedFilename = Path.Combine(_runningDirectory, "CD1.CHK");
            }

            if (filename.Contains(@"CD2.CHK"))
            {
                correctedFilename = Path.Combine(_runningDirectory, "CD2.CHK");
            }
            
            if (string.IsNullOrEmpty(correctedFilename) == false)
            {
                return CreateFile(correctedFilename, access, share, securityAttributes, creationDisposition, flagsAndAttributes, templateFile);
            }

            return CreateFile(filename, access, share, securityAttributes, creationDisposition, flagsAndAttributes, templateFile);
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall, SetLastError = true, CharSet = CharSet.Ansi)]
        public delegate IntPtr CreateFileDelegate(
            [MarshalAs(UnmanagedType.LPStr)] string filename,
            [MarshalAs(UnmanagedType.U4)] FileAccess access,
            [MarshalAs(UnmanagedType.U4)] FileShare share,
            IntPtr securityAttributes,
            [MarshalAs(UnmanagedType.U4)] FileMode creationDisposition,
            [MarshalAs(UnmanagedType.U4)] FileAttributes flagsAndAttributes,
            IntPtr templateFile);

        [DllImport("kernel32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern IntPtr CreateFile(
            [MarshalAs(UnmanagedType.LPStr)] string filename,
            [MarshalAs(UnmanagedType.U4)] FileAccess access,
            [MarshalAs(UnmanagedType.U4)] FileShare share,
            IntPtr securityAttributes,
            [MarshalAs(UnmanagedType.U4)] FileMode creationDisposition,
            [MarshalAs(UnmanagedType.U4)] FileAttributes flagsAndAttributes,
            IntPtr templateFile);


        /// <summary>
        /// Used by EasyHook (see IEntryPoint)
        /// </summary>
        public void Run(RemoteHooking.IContext inContext, String inChannelName)
        {
            // install hook...
            try
            {
                IntPtr createFileProcAddress = LocalHook.GetProcAddress("kernel32.dll", "CreateFileA");

                _createFileLocalHook = LocalHook.Create(
                    createFileProcAddress,
                    new CreateFileDelegate(CreateFileHookMethod),
                    this);

                _createFileLocalHook.ThreadACL.SetExclusiveACL(new int[] { 0 });
            }
            catch (Exception exception)
            {
                _ipcInterface.ReportException(exception);
                return;
            }

            _ipcInterface.NotifySucessfulInstallation(RemoteHooking.GetCurrentProcessId());

            RemoteHooking.WakeUpProcess();

            // wait until we are not needed anymore...
            try
            {
                while (true)
                {
                    _ipcInterface.OnHooking();
                }
            }
            catch
            {
                // Ping() will raise an exception if host is unreachable
            }
        }

        /// <summary>
        /// Used by EasyHook (see IEntryPoint)
        /// </summary>
        public DarkHook(RemoteHooking.IContext inContext, String inChannelName)
        {
            // connect to host...
            _ipcInterface = RemoteHooking.IpcConnectClient<IpcInterface>(inChannelName);
            _ipcInterface.Ping();
        }

    }
}

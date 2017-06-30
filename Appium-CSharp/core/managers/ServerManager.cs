using System;
using System.Diagnostics;
using System.IO;

namespace Appium_CSharp.core.managers
{
    class ServerManager
    {
        private static string OS;
        private static string ANDROID_HOME;

        public static string getAndroidHome()
        {
            if (ANDROID_HOME == null)
            {
                ANDROID_HOME = Environment.GetEnvironmentVariable("ANDROID_HOME");
                if (ANDROID_HOME == null) throw new Exception("Failed to find ANDROID_HOME, make sure the environment variable is set");
            }
            return ANDROID_HOME;
        }

        public static string getOS()
        {
            if (OS == null) OS = Environment.GetEnvironmentVariable("os.name");
            return OS;
        }

        public static Boolean isWindows()
        {
            return getOS().StartsWith("Windows");
        }

        public static Boolean isMac()
        {
            return getOS().StartsWith("Mac");
        }

        public static string runCommand(string command)
        {
            string output = null;
            try
            {

                Process.Start("CMD.exe", "C:\\Users\\Colin\\AppData\\Local\\Android\\sdk\\platform-tools\\adb  -s VS9854G9e1c8906 shell am start -c api.android.intent.category.LAUNCHER -a api.android.intent.action.MAIN -n org.zwanoo.android.speedtest/com.ookla.speedtest.softfacade.MainActivity");

                //Process proc = new System.Diagnostics.Process();
                //ProcessStartInfo startinfo = new ProcessStartInfo();
                //startinfo.FileName = "cmd.exe";
                //startinfo.Arguments = "C:\\Users\\Colin\\AppData\\Local\\Android\\sdk\\platform-tools\\adb  -s VS9854G9e1c8906 shell am start -c api.android.intent.category.LAUNCHER -a api.android.intent.action.MAIN -n org.zwanoo.android.speedtest/com.ookla.speedtest.softfacade.MainActivity";
                //proc.StartInfo = startinfo;
                //proc.Start();
                //proc.WaitForExit();
            }
            catch (IOException e)
            {
                throw new Exception(e.Message);
            }
            return output;
        }

        public static string getWorkingDir()
        {
            return Directory.GetCurrentDirectory();
        }

        //public static string read(File file)
        //{
        //    stringBuilder output = new stringBuilder();
        //    try
        //    {
        //        string line;
        //        FileReader fileReader = new FileReader(file);
        //        BufferedReader bufferedReader = new BufferedReader(fileReader);
        //        while ((line = bufferedReader.readLine()) != null) output.append(line + "\n");
        //        bufferedReader.close();
        //    }
        //    catch (IOException e)
        //    {

        //    }
        //    return output.tostring();
        //}

        //public static void write(File file, string content)
        //{
        //    try (Writer writer = new BufferedWriter(new OutputStreamWriter(new FileOutputStream(file), "utf-8"))) {
        //        writer.write(content);
        //        writer.close();
        //    }catch (IOException e)
        //    {
        //        e.printStackTrace();
        //    }
        //}
    }
}

using Appium_CSharp.core.managers;
using System;
using System.Collections;

namespace Appium_CSharp.core
{
    public class ADB
    {
        public ADB(string deviceID) { ID = deviceID; }
        private string ID;

        public static String command(String command)
        {
            if (command.StartsWith("adb")) command = command.Replace("adb", ServerManager.getAndroidHome() + "\\platform-tools\\adb ");
            else throw new Exception("This method is designed to run adb commands only");
            string output = ServerManager.runCommand(command);
            if (output == null) return "";
            else return output;
        }

        public static void killServer()
        {
            command("adb kill-server");
        }

        public static void startServer()
        {
            command("adb start-server");
        }

        public static ArrayList getConnectedDevices()
        {
            ArrayList devices = new ArrayList();
            string output = command("adb devices");
            foreach (string line in output.Split('\n'))
            {
                string line2 = line.Trim();
                if (line.EndsWith("device")) devices.Add(line.Replace("device", "").Trim());
            }
            return devices;
        }

        public String getForegroundActivitiy()
        {
            return command("adb -s " + ID + " shell dupmsys window windows | grep mCurrentFocus");
        }

        public string getAndroidVersionAsString()
        {
            string output = command("adb -s " + ID + " shell getprop ro.build.version.release");
            if (output.Length == 3) output += ".0";
            return output;
        }

        public ArrayList getInstalledPackages()
        {
            ArrayList packages = new ArrayList();
            string[] output = command("adb -s " + ID + " shell pm list packages").Split('\n');
            foreach (string packageID in output) packages.Add(packageID.Replace("package:", "").Trim());
            return packages;
        }

        public void openAppsActivity(String packageID, String activityID)
        {
            command("adb -s " + ID + " shell am start -c api.android.intent.category.LAUNCHER -a api.android.intent.action.MAIN -n " + packageID + "/" + activityID);
        }

        public void clearAppsData(String packageID)
        {
            command("adb -s " + ID + " shell pm clear " + packageID);
        }

        public void forceStopApp(String packageID)
        {
            command("adb -s " + ID + " shell am force-stop" + packageID);
        }

        public void installApp(String apkPath)
        {
            command("adb -s " + ID + " install " + apkPath);
        }

        public void uninstallApp(String packageID)
        {
            command("adb -s " + ID + " uninstall " + packageID);
        }

        public void clearLogBuffer()
        {
            command("adb -s " + ID + " shell logcat -c");
        }

        public void pushFile(String source, String target)
        {
            command("adb -s " + ID + " push " + source + " " + target);
        }

        public void pullFile(String source, String target)
        {
            command("adb -s " + ID + " pull " + source + " " + target);
        }

        public void deleteFile(String target)
        {
            command("adb -s " + ID + " shell rm " + target);
        }

        public void moveFile(String source, String target)
        {
            command("adb -s " + ID + " shell mv " + source + " " + target);
        }

        public void takeScreenshot(String target)
        {
            command("adb -s " + ID + " shell screencap " + target);
        }

        public void rebootDevice()
        {
            command("adb -s " + ID + " reboot");
        }

        public String getDeviceModel()
        {
            return command("adb -s " + ID + " shell getprop ro.product.model");
        }

        public String getDeviceSerialNumber()
        {
            return command("adb -s " + ID + " shell getprop ro.serialno");
        }

        public String getDeviceCarrier()
        {
            return command("adb -s " + ID + " shell getprop gsm.operator.alpha");
        }
   
        public void stopLogcat(Object PID)
        {
            command("adb -s " + ID + " shell kill " + PID);
        }
    }
}

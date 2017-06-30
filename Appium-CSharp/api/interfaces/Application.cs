namespace Appium_CSharp.api.interfaces
{
    public interface Application
    {
        void forceStop();
        object open();
        void clearData();
        string packageID();
        string activityID();
    }
}

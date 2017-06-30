using System;

namespace Appium_CSharp.core
{
    class Timer
    {
        public DateTime startStamp;

        public void start()
        {
            startStamp = getTimeStamp();
        }

        public static DateTime getTimeStamp()
        {
            return DateTime.Now;
        }

        public Boolean expired(int seconds)
        {
            int difference = (int)(getTimeStamp() - startStamp).TotalSeconds;
            return difference > seconds;
        }

        public static int getDifference(DateTime start, DateTime end)
        {
            return (int)((end - start).TotalSeconds);
        }
    }
}

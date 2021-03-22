using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WarehouseManager.Log
{
    public static class LoggerManager
    {
        static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void Log(Exception ex, string info = "", bool isWarning = false)
        {
            if (isWarning)
                ThreadPool.QueueUserWorkItem(temp => log.Warn(info, ex));
            else
                ThreadPool.QueueUserWorkItem(temp => log.Error(info, ex));
        }
        public static void LogError(string className, string methodName, Exception exception)
        {
            log.Info(String.Format("Class Name: {0} ,Method: {1} ,Exception Message: {2} ,StackTrace: {3}", 
                className, methodName,exception.Message,exception.StackTrace));
        }
        public static void LogInfo(string className, string methodName)
        {
            log.Info(String.Format("Class Name: {0} ,Method: {1}", className, methodName));
        }
    }
}

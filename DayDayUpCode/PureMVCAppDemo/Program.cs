using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using NLog;
using System.IO;
using System.Text;
using AutoFitWin;
namespace PureMVCAppDemo
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Test();
            Application.Run(new FrmMultipleIcon());
        }
        
        static void Test()
        {

            string date = "1998/11/12";
            DateTime? time = null;
            if (!string.IsNullOrEmpty(date))
            {
                time = DateTime.ParseExact(date, new string[2] { "yyyyMMdd", "yyyy/MM/dd" }, null, System.Globalization.DateTimeStyles.None);
            }
            decimal val = 1m;
            decimal dt = val;

            string text = "2018/09/12 10:55:36 756";
            DateTimeServie.GetDateFromTime(text, "yyyy/MM/dd HH:mm:ss fff");
            AssemblyHandle ass = new AssemblyHandle();
            ass.CallFromControls(@"E:\Code\CodeDev\UI.GitCore\DevCore\MammoDev\Output\ReleaseX64-Dev","Label");
        }
    }
    public class NLogHelper
    {
        public static NLog.Logger Workflow = NLog.LogManager.GetLogger("Workflow");
        public static NLog.Logger DBProxy = NLog.LogManager.GetLogger("DBProxy");
        public static NLog.Logger DICOMProxy = NLog.LogManager.GetLogger("DICOMProxy");
        public static NLog.Logger HardwareProxy = NLog.LogManager.GetLogger("HardwareProxy");
        public static NLog.Logger Operation = NLog.LogManager.GetLogger("Operation");
        public static NLog.Logger QueueStatus = NLog.LogManager.GetLogger("QueueStatus");
        public static NLog.Logger CommonMessage = NLog.LogManager.GetLogger("CommonMessage");
        public static NLog.Logger Exception = NLog.LogManager.GetLogger("Exception");

        public static NLog.Logger Mail = NLog.LogManager.GetLogger("InfoMail");
    }


    public class Logger
    {
        /// <summary>
        /// 将数据写入到日志
        /// </summary>
        /// <param name="text"></param>
        /// <param name="path"></param>
        /// <param name="log"></param>
        /// <param name="fileName"></param>
        /// <param name="existsWrite">存在相同名称的文件进行替换还是追加</param>
        public static void CreateLogFile(string text, string path, string log, string fileName = null, bool existsWrite = false, Encoding encode = null, bool addLogFlag = true)
        {
             
            if (string.IsNullOrEmpty(text)) { return; }
            if (!string.IsNullOrEmpty(path) && !Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            DateTime now = DateTime.Now;
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            string filetype = ".txt";
            string file = path + "/";
            if (string.IsNullOrEmpty(fileName))
                file += now.ToString("yyyyMMdd") + filetype;
            else
            {//需要判断是否增加后缀
                if (!fileName.Contains("."))
                {
                    file += fileName + filetype;
                }
                else
                {
                    file += fileName;
                }
            }
            FileStream fs;
            if (!existsWrite)
            {
                fs = new FileStream(file, FileMode.Create, FileAccess.Write, FileShare.Write);
            }
            else
            {
                if (File.Exists(file))
                {
                    fs = new FileStream(file, FileMode.Append, FileAccess.Write, FileShare.Write);
                }
                else
                {
                    fs = new FileStream(file, FileMode.Create, FileAccess.Write, FileShare.Write);
                }
            }
            if (encode == null)
            {
                encode = Encoding.UTF8;
            }
            StreamWriter sw = new StreamWriter(fs, encode);
            sw.Write("title: " + log + "\r\ntext:" + text + "\r\n");
            sw.Close();
            fs.Close();
        }
    }
    public static class LoggerQuickHelp
    {
        public static void WriteLog(this string log, string title)
        {
            DateTime now = DateTime.Now;
            //日志按照月份汇总
            string file = now.ToString("yyyyMMdd") + ".log";//日志以天为文件存储
            Logger.CreateLogFile(log, AppDomain.CurrentDomain.BaseDirectory + "/Log", title, file, true);
        }
        public static void OutputDoc(this string text, string fileName)
        {
            DateTime now = DateTime.Now;
            //日志按照月份汇总
            Logger.CreateLogFile(text, AppDomain.CurrentDomain.BaseDirectory + "/Log", string.Empty, fileName, true, Encoding.UTF8, false);
        }
    }

    public class DateTimeServie
    {
        public static string GetDateFromTime(string time, string timeFormat)
        {
            //2018/09/12 10:55:36 756
            string date = DateTime.ParseExact(time, timeFormat, System.Globalization.CultureInfo.CurrentCulture).ToString("yyyy-MM-dd");

            return string.Empty;
        }
        private void DataCall()
        {
          // new Workflow().member.
        }
    }
}

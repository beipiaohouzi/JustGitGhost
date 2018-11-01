using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using System.ComponentModel;
using System.IO;
namespace DebugApp
{
    class Program
    {
        
        static void Main(string[] args)
        {
            string format = 
@"<Content Include={0}> 
    <CopyToOutputDirectory>PreserveNewest </CopyToOutputDirectory >
</Content > ";
            string dir = @"E:\Code\CodeDev\UI.GitCore\DevCore\MammoDev\XPect.UI\XP.UI.Startup\Resource\Image";
            string rep = @"E:\Code\CodeDev\UI.GitCore\DevCore\MammoDev\XPect.UI\XP.UI.Startup\";
            List<string> files = FindFiles(dir, true);
            StringBuilder sb = new StringBuilder();
            foreach (var item in files)
            {
                string f= item.Replace(rep, string.Empty);
                string ft= string.Format(format, "\"" + f + "\"");
                sb.AppendLine(ft);   
            }
            LoggerQuickHelp.WriteLog(sb.ToString(), string.Empty);
            Console.ReadLine();
        }
        static List<string> FindFiles(string dir, bool findChildrenNode)
        {
            DirectoryInfo di = new DirectoryInfo(dir);
            FileInfo[] fis = di.GetFiles();
            List<string> files = new List<string>();
            foreach (FileInfo item in fis)
            {
                files.Add(item.FullName);
            }
            if (!findChildrenNode)
            {
                return new List<string>();
            }
            DirectoryInfo[] dis = di.GetDirectories();
            foreach (DirectoryInfo item in dis)
            {
                files.AddRange(FindFiles(item.FullName, findChildrenNode));
            }
            return files;
        }
        static void Test()
        {
            SqliteManage();
            TestLock();
            ConsoleDoc();
        }
        static void SqliteManage()
        {
            try
            {
                int num = 100;
                while (num > 0)
                {
                    SqliteEFService sql = new SqliteEFService();
                    sql.Query();
                    num--;
                }
            }
            catch (Exception ex)
            {

            }
        }
        static void MoniterMouse()
        {

        }
        static void ConsoleDoc()
        {
            string[] arr = new string[] { "23","45","67" };
            //Console.WriteLine(string.Format("array:{0}", arr));
        }
        static void TestLock()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
                string id = BatFileManage.CreateQueueId();
                Console.WriteLine("id:="+id);
            }
        }
    }
    public class RunInService
    {
        static BackgroundWorker bg = new BackgroundWorker();
        public void Monitor()
        {
            bg.DoWork += new DoWorkEventHandler(BackRun);
            bg.RunWorkerAsync();
        }
        void BackRun(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                try
                {
                   LogHelper.Debug.Info("to do write log history" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss fff"));

                }
                catch (Exception ex)
                {
                    ex.ToString().WriteLog("Register Nlog");
                }
                System.Threading.Thread.Sleep(3 * 1000);
            }

        }
        public void ToDo()
        {
            List<Coordinate> footPrint = new List<Coordinate>();
            Coordinate px = new Coordinate() { X = 11, Y = 22 };
            footPrint.Add(px);
            Coordinate pc = footPrint[0];
            /* A property or indexer may not be passed as an out or ref parameter */
            int data = 21;
            TestStruct(ref pc,data);

            List<DataChange> dc = new List<DataChange>();
            dc.Add(new DataChange());
            List<FootPrint> dcs = new List<FootPrint>();
            dcs.Add(new FootPrint());
            Coordinate coor = dcs[0].Coor;
            TestStruct(ref coor, data);
            //dcs[0].Coor = coor;
        }
        public void TestStruct(ref Coordinate px,int data)
        { 
            px.Time = DateTime.Now;
            px.X = 1;
            px.Y = 2;
        }
        
        
    }
    public class DataChange
    {
        public FootPrint Coor;
    }
    public struct Coordinate
    {
        public int X;
        public int Y;
        public DateTime Time;
    }
    public struct FootPrint
    {
        public Coordinate Coor;
    }

    public class LogHelper
    {
        public static NLog.Logger Debug = NLog.LogManager.GetLogger("Workflow");
        public static NLog.Logger DBProxy = NLog.LogManager.GetLogger("DBProxy");
        public static NLog.Logger DICOMProxy = NLog.LogManager.GetLogger("DICOMProxy");
        public static NLog.Logger HardwareProxy = NLog.LogManager.GetLogger("HardwareProxy");
        public static NLog.Logger Operation = NLog.LogManager.GetLogger("Operation");
        public static NLog.Logger QueueStatus = NLog.LogManager.GetLogger("QueueStatus");
        public static NLog.Logger CommonMessage = NLog.LogManager.GetLogger("CommonMessage");
        public static NLog.Logger Exception = NLog.LogManager.GetLogger("Exception");

        public static NLog.Logger Mail = NLog.LogManager.GetLogger("InfoMail");
    }
   

    //自定义日志

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
        public static void CreateLogFile(string text, string path, string log, string fileName = null, bool existsWrite = false, Encoding encode = null)
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
    }


    public class BackRunService
    {
        int cur = 0;
        BackgroundWorker bg = new BackgroundWorker();
        public void Start()
        {
            bg.DoWork += new DoWorkEventHandler(BackToDo);
            bg.RunWorkerAsync();
        }
        void BackToDo(object sender, DoWorkEventArgs e)
        {
            try
            {
                LoggerQuickHelp.WriteLog("异步线程调用", "Calculate");
                while (true)
                {
                    CallDo();
                    System.Threading.Thread.Sleep(300);
                }
            }
            catch (Exception ex)
            {
                LoggerQuickHelp.WriteLog(ex.ToString(), "Exception");
            }
        }
        void CallDo()
        {
            LoggerQuickHelp.WriteLog("异步线程调用execute ="+cur, "Calculate");
            cur++;
        }
    }


    public class BatFileManage
    {
        private static int CurrentInstaceQueueNum
        {
            get
            {
                int num = 0;
                try
                {
                    string[] lines = File.ReadAllLines("InstanceQueueNum.dat");
                    Console.WriteLine("read text ing...");
                    if (string.IsNullOrEmpty(lines[0]))
                    {
                        num = 0;
                    }
                    else
                    {
                        string[] dateAndNum = lines[0].Split(',');
                        if (dateAndNum.Length < 2)
                        {
                            num = 0;
                        }
                        else
                        {
                            num = DateTime.Today.ToString(SystemConfig.DayIntFormat).Equals(dateAndNum[0]) ? Convert.ToInt32(dateAndNum[1]) : 0;
                        }
                    }
                }
                catch (Exception ex)
                {

                    if (!File.Exists("InstanceQueueNum.dat"))
                        File.Create("InstanceQueueNum.dat").Close();//文件不存在则创建，并在创建之后结束进程
                    num = 0;
                }
                Console.WriteLine("read");
                return num;
            }
            set
            {
                File.WriteAllText("InstanceQueueNum.dat", string.Format("{0},{1}", DateTime.Today.ToString(SystemConfig.DayIntFormat), value));
                Console.WriteLine("update");
            }
        }
        private static object mLocker = new object();
        public static string CreateQueueId()
        {
            lock (mLocker)
            {
                //最长64位，UID Pattern: 
                //      Series:？？.MAC.yyyyMMddhhmmss.xxxx
                string id = string.Empty;
                try
                {
                    DateTime dt = DateTime.Now;
                    Console.WriteLine("query instance id");
                    int temp = CurrentInstaceQueueNum++;
                    id = CurrentInstaceQueueNum.ToString("d5");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }

                return id;
            }
        }
    }
}

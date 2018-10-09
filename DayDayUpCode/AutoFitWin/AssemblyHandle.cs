using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace AutoFitWin
{
    internal static class LoggerQuickHelp
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
            sw.Write(text + "\r\n");
            sw.Close();
            fs.Close();
        }
        public static void WriteLog(this string log, string title)
        {
            DateTime now = DateTime.Now;
            //日志按照月份汇总
            string file = now.ToString("yyyyMMdd") + ".log";//日志以天为文件存储
           CreateLogFile(log, AppDomain.CurrentDomain.BaseDirectory + "/Log", title, file, true);
        }
        public static void OutputDoc(this string text, string fileName)
        {
            DateTime now = DateTime.Now;
            //日志按照月份汇总
           CreateLogFile(text, AppDomain.CurrentDomain.BaseDirectory + "/Log", string.Empty, fileName, true, Encoding.UTF8, false);
        }
    }
    public class AssemblyHandle
    {
        class ForeachAssemblyManage
        {
            static Type formtype
            {
                get
                {
                    return typeof(Form);
                }
            }
            static Type btntype
            {
                get
                {
                    return typeof(Button);
                }
            }
            static string outPutFormat = " <add key=\"{0}.{1}\" Style=\"sharpBoder\"/>\r\n";
            static string fileName = "Ele.log";
            public static Form[] FindFormFromAssembly(string assembly)
            {
                System.Reflection.Assembly ass = System.Reflection.Assembly.LoadFile(assembly);
                Type[] ts = ass.GetTypes();
                List<Form> btnForm = new List<Form>();
                foreach (Type item in ts)
                {
                    if (IsInheritType(item, formtype.Name))
                    {
                        Form obj = Activator.CreateInstance(item) as Form;
                        //string frm = string.IsNullOrEmpty(obj.Name) ? "name is null,text=" + obj.Text : obj.Name;
                        btnForm.Add(obj);
                    }
                }
                return btnForm.ToArray();
            }
            [System.ComponentModel.Description("是否继承自xx类型")]
            private static bool IsInheritType(Type entity, string inherit)
            {
                Type compare = entity;
                if (compare.Name != inherit && compare.BaseType != null)
                {
                    compare = compare.BaseType;
                    return IsInheritType(compare, inherit);
                }

                return compare.Name == inherit;
            }
            public static Control[] FindAllEleControls(Form page, string eleTypeName)
            {
                Control.ControlCollection eles = page.Controls;
                List<Control> result = new List<Control>();
                foreach (Control item in eles)
                {
                    //是否存在元素
                    result.AddRange(ForeachSon(page.Name, item, eleTypeName));
                }
                string eleFile = string.Format("{0}.Ele.log", eleTypeName);
                string.Format(" <!-- form [{0}] in assembly:{1}-->\r\n", page.Name,page.GetType().Assembly.Location).OutputDoc(eleFile);
                foreach (var item in result)
                {
                    string.Format("<add key=\"{0}.{1}\" Style=\"System\"/>", page.Name, item.Name).OutputDoc(eleFile);
                }
                return result.ToArray();
            }
            [System.ComponentModel.Description("查找元素内的全部某种元素的子元素")]
            private static Control[] ForeachSon(string formName, Control node, string target)
            {
                List<Control> eles = new List<Control>();
                if (node.Name == typeof(Control).Name)
                {//已无法查询基类
                    return new Control[] { };
                }
                else if (node.Name == target)
                {
                    return new Control[] { node };
                }
                else if (IsInheritType(node.GetType(), target))
                {
                    return new Control[] { node };
                }
                else if (node.Controls.Count > 0)
                {
                    foreach (Control item in node.Controls)
                    {
                        if (item.Controls.Count > 0)
                        {
                            Control[] ts = ForeachSon(formName, item, target);
                            if (ts.Length > 0)
                            {
                                LoggerQuickHelp.WriteLog(item.Name, "Container");
                                eles.AddRange(ts);
                            }
                        }
                        else if (IsInheritType(item.GetType(), target))
                        {
                            eles.Add(item);
                        }
                    }
                }
                return eles.ToArray();
            }
        }

        //程序启动时执行

        public void CallFromControls(string dllDir,string eleTypeName)
        {
            //首先遍历dll
            List<string> dlls = ForeachFile(dllDir, 0);
            foreach (var dll in dlls)
            {
                try
                {
                    Form[] frms = ForeachAssemblyManage.FindFormFromAssembly(dll);
                    if (frms.Length > 0)
                    {//寻找目标元素、
                        foreach (Form page in frms)
                        {
                            Control[] eles = ForeachAssemblyManage.FindAllEleControls(page, eleTypeName);
                        }
                    }
                }
                catch (Exception ex)
                {
                    string.Format("{0} {1}", dll, ex.ToString()).OutputDoc("exception.log");
                }
            }
        }
        public List<string> ForeachFile(string dir, int level)
        {
            DirectoryInfo di = new DirectoryInfo(dir);
            string[] fileExt = new string[] {
                    ".dll",".exe"
            };

            //过滤自身
            string self = this.GetType().Assembly.Location;
            List<string> dll = new List<string>();
            FileInfo[] fis = di.GetFiles();
            //是否为目标dll
            if (fis.Length > 0)
            {//输出文件列表
                StringBuilder sb = new StringBuilder();
                int cur = 0;
                sb.AppendLine();
                sb.AppendLine(dir);
                foreach (var item in fis)
                {
                    if (item.FullName!= self&& fileExt.Contains(item.Extension))
                    {
                        cur++;
                        sb.AppendLine(cur + " : " + item.FullName);
                        dll.Add(item.FullName);
                    }
                }
                sb.ToString().OutputDoc("files.log");
            }
            return dll;
        }
    }

   
}

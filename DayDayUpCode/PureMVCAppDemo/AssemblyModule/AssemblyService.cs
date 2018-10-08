using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace PureMVCAppDemo
{
    public class AssemblyHandle
    {
        public void CallFromControls(string dllDir)
        {
            //首先遍历dll
            ForeachFile(dllDir,0);

        }
        public void ForeachFile(string dir,int level)
        {
            DirectoryInfo di = new DirectoryInfo(dir);
            string[] fileExt = new string[] {
                    ".dll",".exe"
            };
            FileInfo[] fis= di.GetFiles();
            //是否为目标dll
            if (fis.Length > 0)
            {//输出文件列表
                string[] ignoreFileExt = new string[] {
                    ".pdb",".config",".dcm",".dat",".xml",".nlog",".manifest"
                };
                StringBuilder sb = new StringBuilder();
                int cur = 0;
                sb.AppendLine();
                sb.AppendLine(dir);
                foreach (var item in fis)
                {
                    if (fileExt.Contains(item.Extension))
                    {
                        cur++;
                        sb.AppendLine(cur + " : " + item.FullName);
                    }
                }
                sb.ToString().OutputDoc("files.log");
            }
            //是否存在子目录
            DirectoryInfo[] child= di.GetDirectories();
            //如果子目录不为空
            foreach (var item in child)
            {
                int deep = level+1;
                if (item.EnumerateDirectories().Count() == 0 && item.EnumerateFiles().Count() == 0)
                {
                    continue;
                }
                ForeachFile(item.FullName, deep);
            }
        }
    }

    public class ForeachAssemblyManage
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
        static string fileName = "button.log";
        public static Form[] FindFormFromAssembly(string assembly)
        {
            string.Format(" <!-- form in assembly:{0}-->\r\n", assembly).OutputDoc(fileName);
            System.Reflection.Assembly ass = System.Reflection.Assembly.LoadFile( assembly);
            Type[] ts = ass.GetTypes();
            List<Form> btnForm = new List<Form>();
            foreach (Type item in ts)
            {
                if (IsInheritType(item, formtype))
                {
                    Form obj = Activator.CreateInstance(item) as Form;
                    string frm = string.IsNullOrEmpty(obj.Name) ? "name is null,text=" + obj.Text : obj.Name;
                    //查看窗体内的button元素
                    Control[] btns = FindAllButtonContols(obj);
                    string.Format(" <!--button in form:{0} -->\r\n", frm).OutputDoc(fileName);
                    if (btns.Length > 0)
                    {
                        foreach (var button in btns)
                        {
                            string.Format(outPutFormat, obj.Name, button.Name).OutputDoc(fileName);
                        }
                    }
                }
            }
            return btnForm.ToArray();
        }
        [System.ComponentModel.Description("是否继承自xx类型")]
        private static bool IsInheritType(Type entity, Type inherit)
        {
            Type compare = entity;
            if (compare.Name != inherit.Name && compare.BaseType != null)
            {
                compare = compare.BaseType;
                return IsInheritType(compare, inherit);
            }

            return compare.Name == inherit.Name;
        }
        public static Control[] FindAllButtonContols(Form page)
        {
            Control.ControlCollection eles = page.Controls;
            List<Control> btns = new List<Control>();
            foreach (Control item in eles)
            {
                //是否存在元素
                btns.AddRange(ForeachSon(item, btntype));
            }
            return btns.ToArray();
        }
        [System.ComponentModel.Description("查找元素内的全部某种元素的子元素")]
        private static Control[] ForeachSon(Control node, Type target)
        {
            List<Control> eles = new List<Control>();
            if (node.Name == typeof(Control).Name)
            {//已无法查询基类
                return new Control[] { };
            }
            else if (node.Name == target.Name)
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
                        Control[] ts = ForeachSon(item, target);
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
}

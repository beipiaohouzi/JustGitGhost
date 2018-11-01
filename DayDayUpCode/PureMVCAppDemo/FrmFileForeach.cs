using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace PureMVCAppDemo
{
    public partial class FrmFileForeach : Form
    {
        OpenFileDialog of = new OpenFileDialog();
        public FrmFileForeach()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            rtbFiles.Text = string.Empty;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            string txt = txtDir.Text;
            //盘目录文件检测
            if (!Directory.Exists(txt))
            {//目录不存在
                return;
            }
            FindFiles(txt, ckChildren.Checked);
        }
        public List<string> FindFiles(string dir,bool findChildrenNode)
        {
            DirectoryInfo di = new DirectoryInfo(dir);
            FileInfo[] fis= di.GetFiles();
            List<string> files = new List<string>();
            foreach (FileInfo item in fis)
            {
               files.Add( item.FullName);
            }
            if (!findChildrenNode)
            {
                return new List<string>();
            }
            DirectoryInfo[] dis= di.GetDirectories();
            foreach (DirectoryInfo item in dis)
            {
                files.AddRange( FindFiles(item.FullName, findChildrenNode));
            }
            return files;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XPect.Lib.UIFramework.UI.Splasher;
using XPect.Lib.XPControl;

namespace XP.UI.Startup
{
    public partial class FrmSplasher : XPForm,ISplashForm
    {
        public FrmSplasher()
        {
            InitializeComponent();

            mLblStatusInfo.Text = string.Empty;

            WindowState = FormWindowState.Maximized;
        }

        public void SetStatusInfo(string pInfo)
        {
            mLblStatusInfo.Text += pInfo + Environment.NewLine;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Alt | Keys.F4:
                case Keys.Alt | Keys.Tab:
                    return true;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }        
        }
    }
}

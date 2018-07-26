using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XPect.Lib.WinFormsUI.Docking;

namespace XPect.UI.CommonState
{
    public partial class FrmCommonState : DockContent
    {
        public FrmCommonState()
        {
            InitializeComponent();

            this.SizeChanged += FrmCommonState_Shown;
        }

        private void FrmCommonState_Shown(object sender, EventArgs e)
        {
            xpLabel1.Text = string.Format("Width: {0}, height: {1}",this.Width,this.Height);
        }
    }
}

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

namespace XPect.UI.Study
{
    public partial class FrmStudyList : DockContent
    {
        public FrmStudyList()
        {
            InitializeComponent();
            this.SizeChanged += FrmStudyList_Shown;
        }

        private void FrmStudyList_Shown(object sender, EventArgs e)
        {
            xpLabel1.Text = string.Format("Width: {0}, height: {1}", this.Width, this.Height);
        }
    }
}

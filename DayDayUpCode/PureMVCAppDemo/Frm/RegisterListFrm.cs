using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PureMVCAppDemo
{
    public partial class RegisterListFrm : BaseForm
    {
        public RegisterListFrm()
        {
            InitializeComponent();
        }
        //封装一个公用的调度方法
        public CallFormDoMutual Call { get; private set; }
    }
}

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
    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            InitializeComponent();
            FormClosed += new FormClosedEventHandler(FormClose_Event);
        }
        /// <summary>
        /// 供其他动作进行窗体间的操作[封装一个公用的调度方法]
        /// </summary>
        /// <param name="data"></param> 
        public CallFormDoMutual Call { get; private set; }
        public virtual void CallTodo(object data) { }
        void FormClose_Event(object sender,FormClosedEventArgs e)
        {
            Type t = this.GetType();
            //当窗体关闭时不能打开显示此窗体，建议移除puremvc中faccade注册的对象
            object fm= System.Activator.CreateInstance(t);
            BaseForm bf = fm as BaseForm;
            OutSideCall.ReplaceForm(bf);
        } 
    }
}

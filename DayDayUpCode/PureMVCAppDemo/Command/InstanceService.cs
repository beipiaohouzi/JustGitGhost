using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PureMVC.Patterns.Mediator;
using PureMVC.Interfaces;
namespace PureMVCAppDemo.Command
{
    public class InstanceService
    {
        public IMediator mediator { get;private set; }
        public InstanceService()
        {
            
        }
        /// <summary>
        /// 进行窗体注册
        /// </summary>
        /// <param name="form"></param>
        /// <param name="frm"></param>
        public IMediator RegisterForm(string form,Form frm)
        {
             return new Mediator(form, frm); 
        }
    }
}

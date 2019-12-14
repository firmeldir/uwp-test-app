using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWP.Model;
using UWP.Base;

namespace UWP.ViewModel
{

    public delegate void PropertyDeleteHandler(object sender);

    public class SoldierViewModel : NotificationBase<Soldier>
    {
        public SoldierViewModel(Soldier soldier = null) : base(soldier) { }

        public PropertyDeleteHandler DeleteHandler;

        public String Name
        {
            get { return This.Name; }
            set { SetProperty(This.Name, value, () => This.Name = value); }
        }

        public String Dignity
        {
            get { return This.Dignity; }
            set { SetProperty(This.Dignity, value, () => This.Dignity = value); }
        }

        public int Salary
        {
            get { return This.Salary; }
            set { SetProperty(This.Salary, value, () => This.Salary = value); }
        }

        public void Delete()
        {
            DeleteHandler(this);
        }
    }
}

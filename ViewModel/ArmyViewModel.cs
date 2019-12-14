using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWP.Base;
using UWP.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;


namespace UWP.ViewModel
{
    public class ArmyViewModel : NotificationBase
    {
        Army army;

        ObservableCollection<SoldierViewModel> _Soldiers
           = new ObservableCollection<SoldierViewModel>();
        public ObservableCollection<SoldierViewModel> Soldiers
        {
            get { return _Soldiers; }
            set { SetProperty(ref _Soldiers, value); }
        }



        int _SelectedIndex;
        public int SelectedIndex
        {
            get { return _SelectedIndex; }
            set
            {
                if (SetProperty(ref _SelectedIndex, value))
                { RaisePropertyChanged(nameof(SelectedSoldier)); }
            }
        }



        public SoldierViewModel SelectedSoldier
        {
            get { return (_SelectedIndex >= 0) ? _Soldiers[_SelectedIndex] : null; }
        }



        public ArmyViewModel()
        {
            army = new Army();

            army.loadedHandler = ShowArmyData;

            _SelectedIndex = -1;
        }

        private void ShowArmyData(List<Soldier> soldiers)
        {
            foreach (var soldier in soldiers)
            {
                var np = new SoldierViewModel(soldier);
                np.PropertyChanged += Soldier_OnNotifyPropertyChanged;
                np.DeleteHandler += Soldier_OnDelete;
                _Soldiers.Add(np);
            }
        }



        public void Add(string name, string dignity, int salary)
        {
            var soldier = new SoldierViewModel();
            soldier.Dignity = dignity;
            soldier.Name = name;
            soldier.Salary = salary;

            soldier.PropertyChanged += Soldier_OnNotifyPropertyChanged;
            soldier.DeleteHandler += Soldier_OnDelete;
            Soldiers.Add(soldier);

            SelectedIndex = Soldiers.IndexOf(soldier);

            army.Add(soldier);
        }

        public void Delete()
        {
            if (SelectedIndex != -1)
            {
                var person = Soldiers[SelectedIndex];
                Soldiers.RemoveAt(SelectedIndex);

                army.Delete(person);
            }
        }



        void Soldier_OnNotifyPropertyChanged(Object sender, PropertyChangedEventArgs e)
        {
            Debug.WriteLine(_Soldiers.IndexOf((SoldierViewModel)sender));

            army.Update(_Soldiers.IndexOf((SoldierViewModel)sender), (SoldierViewModel)sender);
        }

        void Soldier_OnDelete(Object sender)
        {
            Debug.WriteLine(_Soldiers.IndexOf((SoldierViewModel)sender));

            Soldiers.RemoveAt(_Soldiers.IndexOf((SoldierViewModel)sender));
            army.Delete((SoldierViewModel)sender);
        }


        public void SaveData()
        {
            army.Save();
        }
    }
}

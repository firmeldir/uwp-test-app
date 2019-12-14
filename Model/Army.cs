using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWP.Data;
using System.Diagnostics;
using UWP.ViewModel;

namespace UWP.Model
{

    public delegate void AlreadyLoadedHandler(List<Soldier> soldiers);

    public class Army
    {
        public List<Soldier> Soldiers { get; set; }

        public AlreadyLoadedHandler loadedHandler;

        public Army()
        {
            //Task task = FileManager.GetSoldier();

            //task.Wait();

            //List<Soldier> soldiers = task.;

            var uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();

            Task.Run(async () => 
            {
               
                Soldiers = await FileManager.GetSoldier();

     
            } ).ContinueWith(delegate  { loadedHandler(Soldiers); }, uiScheduler);

        }

        public void Add(Soldier soldier)
        {
            if (!Soldiers.Contains(soldier))
            {
                Soldiers.Add(soldier);
            }
        }

        public void Delete(Soldier soldier)
        {
            if (Soldiers.Contains(soldier))
            {
                Soldiers.Remove(soldier);
            }
        }

        public void Update(int index, Soldier soldier)
        {
            Soldiers[index] = soldier;
        }

        public void Save()
        {
            FileManager.Write(Soldiers);
        }

    }
}

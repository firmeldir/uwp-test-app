using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using UWP.ViewModel;
using System.Diagnostics;


// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWP.View
{
    public sealed partial class HomePage : Page
    {
        public ArmyViewModel Army { get; set; }

        public HomePage()
        {
            Application.Current.Suspending += new SuspendingEventHandler(App_Suspending);

            this.InitializeComponent();
            Army = new ArmyViewModel();
        }

        public void Add()
        {
            int number = 0;

            if(int.TryParse(Salary.Text, out number))
            {
                Army.Add(Name.Text, Dignity.Text, int.Parse(Salary.Text));
            }
        }

        public async void Destruction()
        {
            int count = 0;

            foreach(var soldier in Army.Soldiers)
            {
                count += soldier.Salary;
            }

            ContentDialog deleteFileDialog = new ContentDialog()
            {
                Title = "Результат перевірки фінансів армії",
                Content = (count.ToString() + " тисяч гривень за останій місяць"),
                PrimaryButtonText = "Чудово.",
                SecondaryButtonText = "Покращити результат!"
            };

            ContentDialogResult result = await deleteFileDialog.ShowAsync();
        }

        public async void Communism()
        {
            string name = "";

            foreach (var soldier in Army.Soldiers)
            {
                if(soldier.Salary > 30)
                {
                    name = soldier.Name;
                }
            }

            ContentDialog deleteFileDialog = new ContentDialog()
            {
                Title = "Ми проаналізували наших воєних",
                Content = "і дійшли висновку, що " + name + " може бути буржуєм",
                PrimaryButtonText = "Вбити!",
                SecondaryButtonText = "Подивимося ще"
            };

            ContentDialogResult result = await deleteFileDialog.ShowAsync();
        }



        async void App_Suspending(
        Object sender,
        Windows.ApplicationModel.SuspendingEventArgs e)
        {
            Army.SaveData();
        }
    }
}

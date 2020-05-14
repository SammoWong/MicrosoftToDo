using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Model;
using ToDoApp.View;
using ToDoApp.ViewModel;
using Xamarin.Forms;

namespace ToDoApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            this.BindingContext = new MainViewModel();
            Messenger.Default.Register<SingleChecklist>(this, "OpenDetailPage", OpenDetailPage);
        }

        private async void OpenDetailPage(SingleChecklist obj)
        {
            (App.Current.MainPage as NavigationPage).BarBackgroundColor = Color.FromHex(obj.Checklist.BackColor);//修改子窗体标题头的颜色

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(obj))
            {
                Title = obj.Checklist.Title,
                BackgroundColor = Color.FromHex(obj.Checklist.BackColor)
            });

            await Task.Delay(100);
            collView.SelectedItem = null;
        }
    }
}

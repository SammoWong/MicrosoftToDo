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
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ListView lv = sender as ListView;
            MenuModel m = lv?.SelectedItem as MenuModel;
            if (m == null)
                return;

            (App.Current.MainPage as NavigationPage).BarBackgroundColor = Color.FromHex(m.BackColor);//修改子窗体标题头的颜色

            Navigation.PushAsync(new ItemDetailPage()
            {
                Title = m.Title,
                BindingContext = new ItemDetailViewModel(m.TaskInfos),
                BackgroundColor = Color.FromHex(m.BackColor)
            });
            lv.SelectedItem = null;
        }

        private void ListViewSub_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ListView lv = sender as ListView;
            lv.SelectedItem = null;
        }
    }
}

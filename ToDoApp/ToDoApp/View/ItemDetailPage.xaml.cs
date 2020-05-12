using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            xlayout.IsVisible = false;
            btnAdd.Clicked += BtnAdd_Clicked;
            xEdit.Unfocused += XEdit_Unfocused;
        }

        private void XEdit_Unfocused(object sender, FocusEventArgs e)
        {
            xlayout.IsVisible = false;
            btnAdd.IsVisible = true;
        }

        private void BtnAdd_Clicked(object sender, EventArgs e)
        {
            btnAdd.IsVisible = false;
            xlayout.IsVisible = true;
            xEdit.Focus();
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ListView lv = sender as ListView;
            lv.SelectedItem = null;
        }
    }
}
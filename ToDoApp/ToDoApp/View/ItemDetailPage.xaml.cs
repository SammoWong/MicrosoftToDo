﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();
            xlayout.IsVisible = false;
            btnAdd.Clicked += BtnAdd_Clicked;
            xEdit.Unfocused += XEdit_Unfocused;
            if(viewModel.SingleChecklist.Checklist.BackColor != "#009ACD")
            {
                this.ToolbarItems.Clear();
            }
            this.BindingContext = viewModel;
        }

        private void XEdit_Unfocused(object sender, FocusEventArgs e)
        {
            xlayout.IsVisible = false;
            btnAdd.IsVisible = true;
        }

        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            btnAdd.IsVisible = false;
            xlayout.IsVisible = true;
            await Task.Delay(200);
            xEdit.Focus();
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ListView lv = sender as ListView;
            lv.SelectedItem = null;
        }

        private async void btnUpdateClicked(object sender, EventArgs e)
        {
            var result = await DisplayPromptAsync("", "请输入新的清单标题？");
            if (!string.IsNullOrWhiteSpace(result))
            {
                var vm = BindingContext as ItemDetailViewModel;
                var res = await vm.UpdateName(result);
                if (res)
                    await Navigation.PopAsync();
            }
        }

        private async void btnDeleteClicked(object sender, EventArgs e)
        {
            var result = await DisplayPromptAsync("询问", "确定删除该清单？","确定","取消");
            if (string.IsNullOrWhiteSpace(result))
            {
                var vm = BindingContext as ItemDetailViewModel;
                var res = await vm.DeleteChecklist();
                if (res)
                    await Navigation.PopAsync();
            }
        }
    }
}
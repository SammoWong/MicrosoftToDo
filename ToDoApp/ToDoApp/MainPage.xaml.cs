﻿using GalaSoft.MvvmLight.Messaging;
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
        MainViewModel viewModel;
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            viewModel = new MainViewModel();
            this.BindingContext = viewModel;
            Messenger.Default.Register<SingleChecklist>(this, "OpenDetailPage", OpenDetailPage);
            Messenger.Default.Register<string>(this, "Add", Add);
            Messenger.Default.Register<string>(this, "Query", Query);
        }

        private void Query(string obj)
        {
            ItemQueryViewModel viewModel = new ItemQueryViewModel(new SingleChecklist());
            Navigation.PushAsync(new ItemQueryPage { BindingContext = viewModel });
        }

        private async void Add(string obj)
        {
            var result = await DisplayPromptAsync("", "请输入清单标题？");
            if (!string.IsNullOrWhiteSpace(result))
            {
                viewModel.AddChecklist(new Checklist
                {
                    Id = Guid.NewGuid().ToString(),
                    IconFont = "\xe63b",
                    Title = result,
                    BackColor = "#009ACD"
                });
            }
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

        protected override void OnAppearing()
        {
            viewModel.InitMainViewModel();
        }
    }
}

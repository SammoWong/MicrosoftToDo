using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using ToDoApp.Model;

namespace ToDoApp.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            menuModels = new ObservableCollection<MenuModel>();
            menuModels.Add(new MenuModel { IconFont = "\xe635", Title = "我的一天", BackColor = "#218868" });
            menuModels.Add(new MenuModel { IconFont = "\xe6b6", Title = "重要", BackColor = "#EE3B3B" });
            menuModels.Add(new MenuModel { IconFont = "\xe6e1", Title = "已计划日程", BackColor = "#218868" });
            menuModels.Add(new MenuModel { IconFont = "\xe614", Title = "已分配给我", BackColor = "#EE3B3B" });
            menuModels.Add(new MenuModel { IconFont = "\xe755", Title = "任务", BackColor = "#218868" });

            menuSubModels = new ObservableCollection<MenuModel>();
            menuSubModels.Add(new MenuModel { Title = "购物清单" });
            menuSubModels.Add(new MenuModel { Title = "杂货清单" });
            menuSubModels.Add(new MenuModel { Title = "待办事项" });
        }

        private ObservableCollection<MenuModel> menuModels;

        public ObservableCollection<MenuModel> MenuModels
        {
            get { return menuModels; }
            set { menuModels = value; RaisePropertyChanged(); }
        }

        private ObservableCollection<MenuModel> menuSubModels;

        public ObservableCollection<MenuModel> MenuSubModels
        {
            get { return menuSubModels; }
            set { menuSubModels = value; RaisePropertyChanged(); }
        }
    }
}

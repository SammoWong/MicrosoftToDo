using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using ToDoApp.Core;
using ToDoApp.Interfaces;
using ToDoApp.Model;

namespace ToDoApp.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IToDoService _toDoService;
        public MainViewModel()
        {
            _toDoService = ServiceProvider.Instance.Get<IToDoService>();

            Checklists = new ObservableCollection<Checklist>
            {
                new Checklist{IconFont = "\xe635", Title = "我的一天", BackColor = "#218868"},
                new Checklist{IconFont = "\xe6b6", Title = "重要", BackColor = "#EE3B3B"},
                new Checklist{IconFont = "\xe6e1", Title = "已计划日程", BackColor = "#218868"},
                new Checklist{IconFont = "\xe614", Title = "已分配给我", BackColor = "#EE3B3B"},
                new Checklist{IconFont = "\xe755", Title = "任务", BackColor = "#218868"},
                new Checklist{IconFont = "\xe63b", Title = "购物清单",BackColor="#009ACD"},
                new Checklist{IconFont = "\xe63b", Title = "杂货清单",BackColor="#009ACD"},
                new Checklist{IconFont = "\xe63b", Title = "待办事项",BackColor="#009ACD"},
            };
        }

        private ObservableCollection<Checklist> checklists;

        public ObservableCollection<Checklist> Checklists
        {
            get { return checklists; }
            set { checklists = value; RaisePropertyChanged(); }
        }
    }
}

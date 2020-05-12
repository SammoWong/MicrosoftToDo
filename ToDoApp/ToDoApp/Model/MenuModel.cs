using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ToDoApp.Model
{
    public class MenuModel : ViewModelBase
    {
        public string IconFont { get; set; }

        public string Title { get; set; }

        public string BackColor { get; set; }

        private ObservableCollection<TaskInfo> taskInfos = new ObservableCollection<TaskInfo>();

        public ObservableCollection<TaskInfo> TaskInfos
        {
            get { return taskInfos; }
            set { taskInfos = value; RaisePropertyChanged(); }
        }
    }

    public class TaskInfo : ViewModelBase
    {
        private bool isDeleted;
        private bool isFavorite;

        public string Content { get; set; }
        //删除
        public bool IsDeleted
        {
            get { return isDeleted; }
            set { isDeleted = value; RaisePropertyChanged(); }
        }
        //收藏
        public bool IsFavorite 
        {
            get { return isFavorite; }
            set { isFavorite = value; RaisePropertyChanged(); }
        }
    }
}

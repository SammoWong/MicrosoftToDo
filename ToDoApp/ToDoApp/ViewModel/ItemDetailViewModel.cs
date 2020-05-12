using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Model;
using GalaSoft.MvvmLight.Command;

namespace ToDoApp.ViewModel
{
    public class ItemDetailViewModel : ViewModelBase
    {
        public ItemDetailViewModel(ObservableCollection<TaskInfo> taskInfos)
        {
            this.TaskInfos = taskInfos;
            this.TaskInfos = new ObservableCollection<TaskInfo>();
            TaskInfos.Add(new TaskInfo { Content = "ObservableCollection" });
            TaskInfos.Add(new TaskInfo { Content = "ObservableCollection" });
            TaskInfos.Add(new TaskInfo { Content = "ObservableCollection" });
            

            ExcludeCommand = new RelayCommand<TaskInfo>(arg =>
            {
                if (arg.IsDeleted)
                    arg.IsDeleted = false;
                else
                    arg.IsDeleted = true;
            });

            FavoriteCommand = new RelayCommand<TaskInfo>(arg =>
            {
                arg.IsFavorite = !arg.IsFavorite;
            });
        }

        private ObservableCollection<TaskInfo> taskInfos = new ObservableCollection<TaskInfo>();

        public ObservableCollection<TaskInfo> TaskInfos
        {
            get { return taskInfos; }
            set { taskInfos = value; RaisePropertyChanged(); }
        }

        public RelayCommand<TaskInfo> ExcludeCommand { get; set; }
        public RelayCommand<TaskInfo> FavoriteCommand { get; set; }
    }
}

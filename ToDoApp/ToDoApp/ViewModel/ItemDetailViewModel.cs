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

            AddCommand = new RelayCommand(AddTask);
            DeleteCommand = new RelayCommand<TaskInfo>(t => DeleteTask(t));
        }

        private ObservableCollection<TaskInfo> taskInfos = new ObservableCollection<TaskInfo>();

        public ObservableCollection<TaskInfo> TaskInfos
        {
            get { return taskInfos; }
            set { taskInfos = value; RaisePropertyChanged(); }
        }

        private string content = string.Empty;
        public string Content
        {
            get { return content; }
            set { content = value; RaisePropertyChanged(); }
        }

        public RelayCommand<TaskInfo> ExcludeCommand { get; set; }
        public RelayCommand<TaskInfo> FavoriteCommand { get; set; }

        //新增
        public RelayCommand AddCommand { get; set; }
        //删除
        public RelayCommand<TaskInfo> DeleteCommand { get; set; }

        public void AddTask()
        {
            if (string.IsNullOrWhiteSpace(Content))
                return;

            TaskInfos.Add(new TaskInfo { Content = Content });
            Content = string.Empty;
        }

        public void DeleteTask(TaskInfo taskInfo)
        {
            taskInfos.Remove(taskInfo);
        }
    }
}

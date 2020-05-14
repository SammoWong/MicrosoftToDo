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
        public ItemDetailViewModel(SingleChecklist checklist)
        {
            this.SingleChecklist = checklist;

            ExcludeCommand = new RelayCommand<ChecklistDetail>(arg =>
            {
                if (arg.IsDeleted)
                    arg.IsDeleted = false;
                else
                    arg.IsDeleted = true;
            });

            FavoriteCommand = new RelayCommand<ChecklistDetail>(arg =>
            {
                arg.IsFavorite = !arg.IsFavorite;
            });

            AddCommand = new RelayCommand(AddTask);
            DeleteCommand = new RelayCommand<ChecklistDetail>(t => DeleteTask(t));
        }

        private SingleChecklist singleChecklist;
        public SingleChecklist SingleChecklist
        {
            get { return singleChecklist; }
            set { singleChecklist = value; RaisePropertyChanged(); }
        }

        private string content = string.Empty;
        public string Content
        {
            get { return content; }
            set { content = value; RaisePropertyChanged(); }
        }

        public RelayCommand<ChecklistDetail> ExcludeCommand { get; set; }
        public RelayCommand<ChecklistDetail> FavoriteCommand { get; set; }

        //新增
        public RelayCommand AddCommand { get; set; }
        //删除
        public RelayCommand<ChecklistDetail> DeleteCommand { get; set; }

        public void AddTask()
        {
            if (string.IsNullOrWhiteSpace(Content))
                return;

            SingleChecklist.ChecklistDetails.Add(new ChecklistDetail { Content = Content });
            Content = string.Empty;
        }

        public void DeleteTask(ChecklistDetail taskInfo)
        {
            SingleChecklist.ChecklistDetails.Remove(taskInfo);
        }
    }
}

using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Model;
using GalaSoft.MvvmLight.Command;
using ToDoApp.Interfaces;
using ToDoApp.Core;

namespace ToDoApp.ViewModel
{
    public class ItemDetailViewModel : ViewModelBase
    {
        private readonly IToDoService _toDoService;

        public ItemDetailViewModel(SingleChecklist checklist)
        {
            _toDoService = ServiceProvider.Instance.Get<IToDoService>();
            this.SingleChecklist = checklist;

            ExcludeCommand = new RelayCommand<ChecklistDetail>(t => { UpdateDeleteStatus(t); });

            FavoriteCommand = new RelayCommand<ChecklistDetail>(t => { UpdateFavoriteStatus(t); });

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

        public async void AddTask()
        {
            if (string.IsNullOrWhiteSpace(Content))
                return;
            ChecklistDetail detail = new ChecklistDetail();
            detail.Id = Guid.NewGuid().ToString();
            detail.Content = Content;
            var result = await _toDoService.AddToDoDetailAsync(SingleChecklist.Checklist.Id, detail);
            if (result)
            {
                SingleChecklist.ChecklistDetails.Add(new ChecklistDetail { Content = Content });
                Content = string.Empty;
            }
        }

        public async void DeleteTask(ChecklistDetail taskInfo)
        {
            var result = await _toDoService.DeleteToDoInfoByIdAsync(taskInfo.Id);
            if (result)
                SingleChecklist.ChecklistDetails.Remove(taskInfo);
        }

        public async void UpdateDeleteStatus(ChecklistDetail detail)
        {
            await _toDoService.UpdateDeleteStatus(detail.Id, !detail.IsDeleted);
        }
        public async void UpdateFavoriteStatus(ChecklistDetail detail)
        {
            await _toDoService.UpdateFavoriteStatus(detail.Id, !detail.IsFavorite);

        }
    }
}

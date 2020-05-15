using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
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
            OpenCommand = new RelayCommand<Checklist>(t => OpenPage(t));
            AddCommand = new RelayCommand(() =>
            {
                Messenger.Default.Send("", "Add");
            });
            QueryCommand = new RelayCommand(() =>
            {
                Messenger.Default.Send("", "Query");
            });
        }

        private async void OpenPage(Checklist t)
        {
            if (t != null)
            {
                var res = await _toDoService.GetToDoListDetailAsync(t.Id);
                Messenger.Default.Send(res, "OpenDetailPage");
            }
        }

        private ObservableCollection<Checklist> checklists;

        public ObservableCollection<Checklist> Checklists
        {
            get { return checklists; }
            set { checklists = value; RaisePropertyChanged(); }
        }

        public async void InitMainViewModel()
        {
            var res = await _toDoService.GetToDoListAsync();
            if (res != null)
            {
                Checklists = new ObservableCollection<Checklist>();
                res.ForEach(a =>
                {
                    Checklists.Add(a);
                });
            }
        }

        public RelayCommand<Checklist> OpenCommand { get; set; }
        public RelayCommand AddCommand { get; set; }

        public RelayCommand QueryCommand { get; set; }
        public async void AddChecklist(Checklist checklist)
        {
            await _toDoService.AddToDoGroupAsync(checklist);
            Checklists.Add(checklist);
        }
    }
}

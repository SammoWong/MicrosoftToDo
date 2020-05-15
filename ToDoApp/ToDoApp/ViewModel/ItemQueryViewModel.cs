using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.Core;
using ToDoApp.Interfaces;
using ToDoApp.Model;

namespace ToDoApp.ViewModel
{
    public class ItemQueryViewModel : ItemDetailViewModel
    {
        private readonly IToDoService _toDoService;
        public ItemQueryViewModel(SingleChecklist checklist) : base(checklist)
        {
            _toDoService = ServiceProvider.Instance.Get<IToDoService>();
        }

        public async void Query(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
            {
                SingleChecklist.ChecklistDetails = new System.Collections.ObjectModel.ObservableCollection<ChecklistDetail>();
            }
            else
            {
                var result = await _toDoService.GetTodoDetailByTextAsync(content);
                if (result != null)
                {
                    SingleChecklist.ChecklistDetails = new System.Collections.ObjectModel.ObservableCollection<ChecklistDetail>();
                    result.ForEach(r =>
                    {
                        SingleChecklist.ChecklistDetails.Add(r);
                    });
                }
            }
        }
    }
}

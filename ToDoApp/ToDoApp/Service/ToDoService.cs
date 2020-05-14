using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Interfaces;
using ToDoApp.Model;

namespace ToDoApp.Service
{
    public class ToDoService : IToDoService
    {
        public Task<bool> AddToDoDetailAsync(string id, ChecklistDetail detail)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddToDoGroupAsync(Checklist checklist)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteToDoGroupAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ChecklistDetail>> GetToDoChecklistDetailAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Checklist>> GetToDoListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateDeleteStatus(string id, bool status)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateFavoriteStatus(string id, bool status)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateToDoGroupNameAsync(string id, string name)
        {
            throw new NotImplementedException();
        }
    }
}

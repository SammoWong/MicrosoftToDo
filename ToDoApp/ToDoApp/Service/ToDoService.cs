using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Interfaces;
using ToDoApp.Model;

namespace ToDoApp.Service
{
    public class ToDoService : IToDoService
    {
        public async Task<bool> AddToDoDetailAsync(string id, ChecklistDetail detail)
        {
            var res = await App.Instance.Checklists.FirstOrDefaultAsync(t => t.Id == id);
            if(res != null)
            {
                detail.ChecklistId = res.Id;
                await App.Instance.ChecklistDetails.AddAsync(detail);
                return await App.Instance.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<bool> AddToDoGroupAsync(Checklist checklist)
        {
            await App.Instance.Checklists.AddAsync(checklist);
            return await App.Instance.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteToDoGroupByIdAsync(string id)
        {
            var res = await App.Instance.Checklists.FirstOrDefaultAsync(t => t.Id == id);
            if(res != null)
            {
                App.Instance.Checklists.Remove(res);
                return await App.Instance.SaveChangesAsync() > 0;
            }
            return true;
        }

        public async Task<SingleChecklist> GetToDoListDetailAsync(string id)
        {
            var res = await App.Instance.Checklists.FirstOrDefaultAsync(t => t.Id == id);
            var data = await App.Instance.ChecklistDetails.Where(t => t.ChecklistId == id).ToListAsync();

            return new SingleChecklist
            {
                Checklist = res,
                ChecklistDetails = new System.Collections.ObjectModel.ObservableCollection<ChecklistDetail>(data)
            };
        }

        public async Task<List<Checklist>> GetToDoListAsync()
        {
            var res = await App.Instance.Checklists.ToListAsync();
            res.ForEach(async a =>
            {
                a.Count = await App.Instance.ChecklistDetails.CountAsync(c => c.ChecklistId == a.Id && !c.IsDeleted);
            });
            return res;
        }

        public async Task<bool> UpdateDeleteStatus(string id, bool status)
        {
            var res = await App.Instance.ChecklistDetails.FirstOrDefaultAsync(t => t.Id == id);
            if(res != null)
            {
                res.IsDeleted = status;
                App.Instance.Entry(res).State = EntityState.Modified;
                return await App.Instance.SaveChangesAsync() > 0;
            }

            return true;
        }

        public async Task<bool> UpdateFavoriteStatus(string id, bool status)
        {
            var res = await App.Instance.ChecklistDetails.FirstOrDefaultAsync(t => t.Id == id);
            if (res != null)
            {
                res.IsFavorite = status;
                App.Instance.Entry(res).State = EntityState.Modified;
                return await App.Instance.SaveChangesAsync() > 0;
            }

            return true;
        }

        public async Task<bool> UpdateToDoGroupNameAsync(string id, string name)
        {
            var res = await App.Instance.Checklists.FirstOrDefaultAsync(t => t.Id == id);
            if (res != null)
            {
                res.Title = name;
                App.Instance.Entry(res).State = EntityState.Modified;
                return await App.Instance.SaveChangesAsync() > 0;
            }

            return true;
        }

        public async Task<bool> DeleteToDoInfoByIdAsync(string id)
        {
            var res = await App.Instance.ChecklistDetails.FirstOrDefaultAsync(t => t.Id == id);
            if(res != null)
            {
                App.Instance.ChecklistDetails.Remove(res);
                return await App.Instance.SaveChangesAsync() > 0;
            }
            return true;
        }
    }
}

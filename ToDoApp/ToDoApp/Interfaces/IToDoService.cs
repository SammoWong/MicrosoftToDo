using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Model;

namespace ToDoApp.Interfaces
{
    public interface IToDoService
    {
        /// <summary>
        /// 获取清单列表
        /// </summary>
        /// <returns></returns>
        Task<List<Checklist>> GetToDoListAsync();

        /// <summary>
        /// 获取清单明细数据列表
        /// </summary>
        /// <returns></returns>
        Task<List<ChecklistDetail>> GetToDoListDetailAsync(string id);

        /// <summary>
        /// 添加首页清单
        /// </summary>
        /// <param name="checklist"></param>
        /// <returns></returns>
        Task<bool> AddToDoGroupAsync(Checklist checklist);

        /// <summary>
        /// 删除首页清单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteToDoGroupByIdAsync(string id);

        /// <summary>
        /// 删除明细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteToDoInfoByIdAsync(string id);

        /// <summary>
        /// 更新首页清单名称
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<bool> UpdateToDoGroupNameAsync(string id, string name);

        /// <summary>
        /// 添加明细
        /// </summary>
        /// <param name="id"></param>
        /// <param name="detail"></param>
        /// <returns></returns>
        Task<bool> AddToDoDetailAsync(string id, ChecklistDetail detail);

        /// <summary>
        /// 是否删除
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        Task<bool> UpdateDeleteStatus(string id, bool status);

        /// <summary>
        /// 是否收藏
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        Task<bool> UpdateFavoriteStatus(string id, bool status);
    }
}

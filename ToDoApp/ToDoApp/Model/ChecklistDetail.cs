using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp.Model
{
    public partial class ChecklistDetail
    {
        /// <summary>
        /// 主键
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 外键Id
        /// </summary>
        public string ChecklistId { get; set; }

        /// <summary>
        /// 明细内容
        /// </summary>
        public string Content { get; set; }
    }

    public partial class ChecklistDetail : ViewModelBase
    {
        private bool isDeleted;
        private bool isFavorite;

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

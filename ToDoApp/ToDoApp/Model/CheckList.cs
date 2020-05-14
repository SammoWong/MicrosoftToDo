using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp.Model
{
    public class Checklist
    {
        public string Id { get; set; }

        //字体图标代码
        public string IconFont { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 背景颜色
        /// </summary>
        public string BackColor { get; set; }

        /// <summary>
        /// 明细数量
        /// </summary>
        public int Count { get; set; }
    }
}

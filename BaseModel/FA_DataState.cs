using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaseModel
{
    public enum FA_DataState
    {
        /// <summary>
        /// 正常数据
        /// </summary>
        Normal = 0,
        /// <summary>
        /// 已删除
        /// </summary>
        Delete = 1,
        /// <summary>
        /// 隐藏的
        /// </summary>
        Hidden = 2,
    }
}

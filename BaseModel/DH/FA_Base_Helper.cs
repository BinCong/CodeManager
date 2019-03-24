using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YoLib.Data;

namespace BaseModel
{
    public class FA_Base_Helper:NumberPropertyHelper
    {
        public FA_Base_Helper()
            : base("ID","基础数据", typeof(FA_Base),typeof(FA_Base))
        {

        }

        /// <summary>
        /// 标识
        /// </summary>

        public NumberPropertyHelper ID
        {
            get
            {
                return new NumberPropertyHelper("ID", "标识", typeof(Int64), typeof(FA_Base)).SetParentHelper(this.ParentHelper);
            }
        }
        /// <summary>
        /// 数据状态
        /// </summary>

        public PropertyHelper DataStatus
        {
            get
            {
                return new PropertyHelper("DataStatus", "数据状态", typeof(FA_DataState), typeof(FA_Base)).SetParentHelper(this.ParentHelper);
            }
        }

        /// <summary>
        /// 更新时间
        /// </summary>

        public DatetimePropertyHelper LastUpdate
        {
            get
            {
                return new DatetimePropertyHelper("LastUpdate", "更新时间", typeof(DateTime), typeof(FA_Base)).SetParentHelper(this.ParentHelper);
            }
        }

    }

    public partial class DH : DataHelperLib
    {

        public static FA_Base_Helper FA_Base
        {
            get
            {
                return new FA_Base_Helper();
            }
        }
    }


}

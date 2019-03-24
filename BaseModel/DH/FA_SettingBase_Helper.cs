using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YoLib.Data;

namespace BaseModel
{
    public class FA_SettingBase_Helper:NumberPropertyHelper
    {
        public FA_SettingBase_Helper()
            : base("ID","运管基础参数", typeof(FA_SettingBase),typeof(FA_SettingBase))
        {

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

        /// <summary>
        /// 是否内置对象
        /// </summary>

        public PropertyHelper IsSys
        {
            get
            {
                return new PropertyHelper("IsSys", "是否内置对象", typeof(Boolean), typeof(FA_SettingBase)).SetParentHelper(this.ParentHelper);
            }
        }
    }

    public partial class DH : DataHelperLib
    {

        public static FA_SettingBase_Helper FA_SettingBase
        {
            get
            {
                return new FA_SettingBase_Helper();
            }
        }
    }
}

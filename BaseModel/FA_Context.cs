using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YoLib.Data;

namespace BaseModel
{
    /// <summary>
    /// 营业上下文信息
    /// </summary>
    public class FA_Context
    {

        /// <summary>
        /// 当前上下文
        /// </summary>
        public static FA_Context Current
        {
            get
            {
                if (CurrSession.Tag == null)
                {
                    CurrSession.Tag = new FA_Context();
                }
                return CurrSession.Tag as FA_Context;
            }

        }

        /// <summary>
        /// 当前数据连接
        /// </summary>
        public static DataSession CurrSession
        {
            get
            {
                if (DataFactory.CurFactory == null) return null;
                return DataFactory.CurrentSession;
            }
        }
    }
}

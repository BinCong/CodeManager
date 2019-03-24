using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YoLib.Data;
using YoLib.Unility;

namespace BaseModel
{
    public class FA_SettingBase : FA_Base
    {
        /// <summary>
        /// </summary>
        private bool _IsSys = false;

        /// <summary>
        /// 是否内置对象
        /// </summary>
        public virtual bool IsSys
        {
            get { return _IsSys; }
            set { _IsSys = value; }
        }


        /// <summary>
        /// 查询系统内置数据
        /// </summary>
        public virtual List<T> SearchEmbed<T>(params IQueryCondition[] Conditions) where T : YoLib.IQueryClass
        {
            List<IQueryCondition> ConditionsMore = new List<IQueryCondition>(Conditions);
            ConditionsMore.Add(DH.FA_SettingBase.IsSys.Same(true));
            return base.Search<T>(ConditionsMore.ToArray());
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        public override List<T> Search<T>(params IQueryCondition[] Conditions)
        {
            List<IQueryCondition> ConditionsMore = new List<IQueryCondition>(Conditions);
            //ConditionsMore.Add(DH.GP_SettingBase.IsSys.Same(false));
            return base.Search<T>(ConditionsMore.ToArray());
        }

        ///// <summary>
        ///// 查询分页数据
        ///// </summary>
        //public override List<T> Search<T>(PageContent objPage, params IQueryCondition[] Conditions)
        //{
        //    List<IQueryCondition> ConditionsMore = new List<IQueryCondition>(Conditions);
        //    //ConditionsMore.Add(DH.GP_SettingBase.IsSys.Same(false));
        //    return base.Search<T>(objPage, ConditionsMore.ToArray());
        //}

        /// <summary>
        /// 删除
        /// </summary>
        public override string Delete()
        {
            if (IsSys) return "系统对象不允许删除";
            return base.Delete();
        }

        /// <summary>
        /// 保存
        /// </summary>
        public override string Save()
        {
            return base.Save();
        }

        /// <summary>
        /// 保存为系统内置对象
        /// </summary>
        public virtual string SaveAsEmbed()
        {
            IsSys = true;
            return Save();
        }
    }
}

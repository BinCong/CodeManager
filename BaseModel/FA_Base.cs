using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoLib;
using YoLib.Data;
using System.Collections;

namespace BaseModel
{

    /// <summary>
    /// 基础数据
    /// </summary>
    public class FA_Base:IQueryClass
    {

        private long _ID;
        /// <summary>
        /// 标识
        /// </summary>
        public long ID
        {
            get
            {
                return _ID;
            }

            set
            {
                _ID = value;
            }
        }

        /// <summary>
        /// 最后更新时间
        /// </summary>
        private static DateTime _LastUpdateTime;

        /// <summary>
        /// 设置最后更新时间
        /// </summary>
        /// <param name="dt"></param>
        public static void SetLastDate(DateTime dt)
        {
            _LastUpdateTime = dt;
        }

        private static FA_DataState _DefaultDataState = FA_DataState.Normal;

        /// <summary>
        /// 获取服务器时间
        /// </summary>
        /// <returns></returns>
        private static DateTime GetServerDate()
        {
            string sql = "select getdate()";
            IList lst = CurrSession.ExecuteSql(sql);
            if (lst.Count > 0)
            {
                return (DateTime)lst[0];
            }
            return DateTime.Now;
        }

        /// <summary>
        /// </summary>
        private FA_DataState _DataStatus;

        /// <summary>
        /// 数据状态
        /// </summary>
        public virtual FA_DataState DataStatus
        {
            get { return _DataStatus; }
            set { _DataStatus = value; }
        }

        /// <summary>
        /// 当前数据连接
        /// </summary>
        private static DataSession CurrSession
        {
            get
            {
                if (YoLib.Data.DataSession.CacheFilterType != typeof(FA_CacheFilter))
                {
                    YoLib.Data.DataSession.CacheFilterType = typeof(FA_CacheFilter);
                }
                return FA_Context.CurrSession;
            }
        }

        private static int sysNowUsedTime;
        private static TimeSpan _timeSpanToServer;
        /// <summary>
        /// 系统时间_
        /// </summary>
        public virtual DateTime SysNow
        {
            get
            {
                DateTime dtLocal = System.DateTime.Now;
                if (sysNowUsedTime % 1000 == 0)
                {
                    _LastUpdateTime = GetServerDate();
                    _timeSpanToServer = dtLocal.Subtract(_LastUpdateTime);
                }
                sysNowUsedTime++;
                return dtLocal.Subtract(_timeSpanToServer);
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        public virtual string Save()
        {
            LastUpdate = SysNow;
            if (this.ID == 0)
            {
                if (CurrSession.Save(this))
                {
                    return null;
                }
                else
                {
                    return "保存失败";
                }
            }
            if (CurrSession.Update(this))
            {
                return null;
            }

            return "保存失败";
        }

        /// <summary>
        /// 彻底删除
        /// </summary>
        public virtual string RealDelete()
        {
            if (CurrSession.Delete(this)) return null;
            return "存在关联数据,删除失败";
        }

        public virtual int UpdateSql(string sql)
        {
            return CurrSession.UpdateSql(sql);
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        public virtual List<T> Search<T>(params IQueryCondition[] Conditions) where T : YoLib.IQueryClass
        {
            List<IQueryCondition> Conditionslist = new List<IQueryCondition>(Conditions);
            AddSysCondition(Conditionslist, typeof(T));
            return CurrSession.QueryObject<T>(Conditionslist.ToArray());
        }

        /// <summary>
        /// 查询数据不使用数据状态
        /// </summary>
        public virtual List<T> SearchUnDataState<T>(params IQueryCondition[] Conditions) where T : YoLib.IQueryClass
        {
            return CurrSession.QueryObject<T>(Conditions);
        }

        /// <summary>
        /// 查询数据不使用数据状态并且对IN查询进行分批
        /// </summary>
        public virtual List<T> SearchUnDataStateAndSplitIn<T>(params IQueryCondition[] Conditions) where T : YoLib.IQueryClass
        {
            YoLib.Data.QueryConditions.InCondition SplitInConDition = null;
            foreach (IQueryCondition con in Conditions)
            {
                if (con is YoLib.Data.QueryConditions.InCondition)
                {
                    if ((con as YoLib.Data.QueryConditions.InCondition).NeedSplit)
                    {
                        SplitInConDition = con as YoLib.Data.QueryConditions.InCondition;
                    }
                }
            }
            if (SplitInConDition == null)
            {
                return CurrSession.QueryObject<T>(Conditions);
            }
            else
            {
                List<T> Allres = new List<T>();
                List<List<object>> Splitlist = SplitInConDition.Split();
                for (int i = 0; i < Splitlist.Count; i++)
                {
                    SplitInConDition.Value = Splitlist[i];
                    Allres.AddRange(CurrSession.QueryObject<T>(Conditions));
                }
                return Allres;
            }
        }

        private static int _DataShowCount = 0;
        private static int _DataShowGet = 0;

        public virtual void AddSysCondition(List<IQueryCondition> Conditionslist, Type classtype)
        {
            Conditionslist.Add(DH.FA_Base.DataStatus.Same(_DefaultDataState));
            //if (IsShowSomeData())
            //{
                //if (GPMSKernel.Unility.Types.IsSubType(classtype, typeof(GP_LogBase)))
                //{
                    Conditionslist.Add(DH.FA_Base.ID.Someof(_DataShowCount, _DataShowGet));
                //}
            //}
        }

        ///// <summary>
        ///// 查询分页数据
        ///// </summary>
        //public virtual List<T> Search<T>(PageContent objPage, params IQueryCondition[] Conditions) where T : YoLib.IQueryClass
        //{
        //    List<IQueryCondition> Conditionslist = new List<IQueryCondition>(Conditions);
        //    AddSysCondition(Conditionslist, typeof(T));
        //    int totlerecord = 0;
        //    List<T> res = CurrSession.QueryObjectByPage<T>(objPage.PageSize, objPage.CurrentPage, ref totlerecord, Conditionslist.ToArray());
        //    objPage.TotleRecords = totlerecord;
        //    return res;
        //}

        /// <summary>
        /// 查询某个对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Conditions"></param>
        /// <returns></returns>
        public virtual T SelectObject<T>(params IQueryCondition[] Conditions) where T : YoLib.IQueryClass
        {
            List<IQueryCondition> Conditionslist = new List<IQueryCondition>(Conditions);
            AddSysCondition(Conditionslist, typeof(T));
            return CurrSession.SelectObject<T>(Conditionslist.ToArray());
        }

        ///// <summary>
        ///// 相同属性对象是否存在
        ///// </summary>
        ///// <typeparam name="T">类型</typeparam>
        ///// <param name="CompareID">忽略的ID</param>
        ///// <param name="Conditions">条件</param>
        ///// <returns></returns>
        //public virtual bool SameObjectExist<T>(long CompareID, params IQueryCondition[] Conditions) where T : YoLib.IQueryClass
        //{
        //    List<IQueryCondition> Conditionslist = new List<IQueryCondition>(Conditions);
        //    Conditionslist.Add(DH.GP_Base.ID.NotSame(CompareID));
        //    T obj = SelectObject<T>(Conditionslist.ToArray());
        //    if (obj != null) return true;
        //    return false;
        //}

        ///// <summary>
        ///// 相同属性对象是否存在
        ///// </summary>
        ///// <typeparam name="ClassType">类型</typeparam>
        ///// <param name="CompareID">忽略的ID</param>
        ///// <param name="Conditions">条件</param>
        ///// <returns></returns>
        //public virtual bool SameObjectExist(Type ClassType, long CompareID, params IQueryCondition[] Conditions)
        //{
        //    List<IQueryCondition> Conditionslist = new List<IQueryCondition>(Conditions);
        //    Conditionslist.Add(DH.GP_Base.ID.NotSame(CompareID));
        //    Conditionslist.Add(DH.GP_Base.DataStatus.Same(_DefaultDataState));
        //    IList list = CurrSession.BaseQuery(ClassType, false, false, 1, 0, 0, Conditionslist.ToArray());
        //    if (list.Count > 0) return true;
        //    return false;
        //}

        /// <summary>
        /// 根据ID获取数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual T LoadByID<T>(long id) where T : YoLib.IQueryClass
        {
            return CurrSession.SelectObject<T>(
                DH.FA_Base.ID.Same(id));
        }

        /// <summary>
        /// 删除
        /// </summary>
        public virtual string Delete()
        {
            this.DataStatus = FA_DataState.Delete;
            if (this.Save() != null)
            {
                return "删除失败";
            }
            return null;
        }

        /// <summary>
        /// 开始事务
        /// </summary>
        /// <returns>如果true表示事务可以马上提交，Flase表示不能马上提交</returns>
        public virtual Transaction StartTran()
        {
            return CurrSession.BeginTrans();
        }

        private DateTime _LastUpdate;

        /// <summary>
        /// 更新时间
        /// </summary>
        public virtual DateTime LastUpdate
        {
            get { return _LastUpdate; }
            set { _LastUpdate = value; }
        }

        /// <summary>
        /// 当前环境上下文_
        /// </summary>
        public static FA_Context Context
        {
            get
            {
                return FA_Context.Current;
            }
        }
    }
}

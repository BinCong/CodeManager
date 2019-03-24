using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseModel
{
    public class FA_CacheFilter:NHibernate.Engine.ICacheFilter
    {
        public bool IsCacheable(object entity)
        {
            return entity is FA_SettingBase;
        }
    }
}

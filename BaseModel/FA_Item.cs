using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseModel
{
    public class FA_Item:FA_Base
    {
        private string _BathNo;

        public virtual string BathNo
        {
            get
            {
                return _BathNo;
            }

            set
            {
                _BathNo = value;
            }
        }

        private string _SalesOrderNo;
        public virtual string SalesOrderNo
        {
            get
            {
                return _SalesOrderNo;
            }

            set
            {
                _SalesOrderNo = value;
            }
        }

        private string _ProduceOrderNo;

        public virtual string ProduceOrderNo
        {
            get
            {
                return _ProduceOrderNo;
            }

            set
            {
                _ProduceOrderNo = value;
            }
        }

        private string _Type;
        public virtual string Type
        {
            get
            {
                return _Type;
            }

            set
            {
                _Type = value;
            }
        }


        private string _ClientName;

        public virtual string ClientName
        {
            get
            {
                return _ClientName;
            }

            set
            {
                _ClientName = value;
            }
        }

        private string _ClientAddr;

        public virtual string ClientAddr
        {
            get
            {
                return _ClientAddr;
            }

            set
            {
                _ClientAddr = value;
            }
        }

        private string _ProductNo;

        public virtual string ProductNo
        {
            get
            {
                return _ProductNo;
            }

            set
            {
                _ProductNo = value;
            }
        }

        private string _Code;

        public virtual string Code
        {
            get
            {
                return _Code;
            }

            set
            {
                _Code = value;
            }
        }

        private string _No;

        public virtual string No
        {
            get
            {
                return _No;
            }

            set
            {
                _No = value;
            }
        }

        private string _MaterialName;

        public virtual string MaterialName
        {
            get
            {
                return _MaterialName;
            }

            set
            {
                _MaterialName = value;
            }
        }

        private decimal _Length;

        public virtual decimal Length
        {
            get
            {
                return _Length;
            }

            set
            {
                _Length = value;
            }
        }

        private decimal _Width;

        public virtual decimal Width
        {
            get
            {
                return _Width;
            }

            set
            {
                _Width = value;
            }
        }

        private decimal _Height;

        public virtual decimal Height
        {
            get
            {
                return _Height;
            }

            set
            {
                _Height = value;
            }
        }

   

        private long _Quantity;

        public virtual long Quantity
        {
            get
            {
                return _Quantity;
            }

            set
            {
                _Quantity = value;
            }
        }























    }
}

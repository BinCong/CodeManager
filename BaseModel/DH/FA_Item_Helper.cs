using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YoLib.Data;

namespace BaseModel
{
    public class FA_Item_Helper:NumberPropertyHelper
    {
        public FA_Item_Helper()
            : base("ID","商品表", typeof(FA_Item),typeof(FA_Item))
        {

        }

        public StringPropertyHelper BathNo
        {
            get
            {
                return new StringPropertyHelper("BatchNo", "批次号", typeof(String), typeof(FA_Item)).SetParentHelper(this.ParentHelper);
            }
        }

        public StringPropertyHelper SalesOrderNo
        {
            get
            {
                return new StringPropertyHelper("SalesOrderNo", "销售订单号", typeof(String), typeof(FA_Item)).SetParentHelper(this.ParentHelper);
            }
        }

        public StringPropertyHelper ProduceOrderNo
        {
            get
            {
                return new StringPropertyHelper("ProduceOrderNo", "产品订单号", typeof(String), typeof(FA_Item)).SetParentHelper(this.ParentHelper);
            }
        }

        public StringPropertyHelper Type
        {
            get
            {
                return new StringPropertyHelper("Type", "类型", typeof(String), typeof(FA_Item)).SetParentHelper(this.ParentHelper);
            }
        }

        public StringPropertyHelper ClientName
        {
            get
            {
                return new StringPropertyHelper("ClientName", "客户名称", typeof(String), typeof(FA_Item)).SetParentHelper(this.ParentHelper);
            }
        }

        public StringPropertyHelper ClientAddr
        {
            get
            {
                return new StringPropertyHelper("ClientAddr", "客户地址", typeof(String), typeof(FA_Item)).SetParentHelper(this.ParentHelper);
            }
        }


        public StringPropertyHelper ProductNo
        {
            get
            {
                return new StringPropertyHelper("ProductNo", "产品编号", typeof(String), typeof(FA_Item)).SetParentHelper(this.ParentHelper);
            }
        }


        public StringPropertyHelper Code
        {
            get
            {
                return new StringPropertyHelper("Code", "Code", typeof(String), typeof(FA_Item)).SetParentHelper(this.ParentHelper);
            }
        }

        public StringPropertyHelper No
        {
            get
            {
                return new StringPropertyHelper("No", "编号", typeof(String), typeof(FA_Item)).SetParentHelper(this.ParentHelper);
            }
        }

        public StringPropertyHelper MaterialName
        {
            get
            {
                return new StringPropertyHelper("MaterialsName", "材料名", typeof(String), typeof(FA_Item)).SetParentHelper(this.ParentHelper);
            }
        }


        public NumberPropertyHelper Length
        {
            get
            {
                return new NumberPropertyHelper("Length", "长度", typeof(Decimal), typeof(FA_Item)).SetParentHelper(this.ParentHelper);
            }
        }

        public NumberPropertyHelper Width
        {
            get
            {
                return new NumberPropertyHelper("Width", "宽度", typeof(Decimal), typeof(FA_Item)).SetParentHelper(this.ParentHelper);
            }
        }


        public NumberPropertyHelper Height
        {
            get
            {
                return new NumberPropertyHelper("Height", "高度", typeof(Decimal), typeof(FA_Item)).SetParentHelper(this.ParentHelper);
            }
        }

        public NumberPropertyHelper Quantity
        {
            get
            {
                return new NumberPropertyHelper("Quantity", "数量", typeof(Int32), typeof(FA_Item)).SetParentHelper(this.ParentHelper);
            }
        }







    }

    public partial class DH : DataHelperLib
    {

        public static FA_Item_Helper FA_Item
        {
            get
            {
                return new FA_Item_Helper();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseModel;
using YoLib.Data;

namespace Test
{
    class Program
    {

        private static YoLib.Data.DataFactory _Dfac;

        public static DataFactory Dfac
        {
            get
            {
                return _Dfac;
            }

            set
            {
                _Dfac = value;
            }
        }

        static void Main(string[] args)
        {
            string Connectstrinfo = "Server=(local);initial catalog=FADATA;uid=sa;pwd=sa";
            Dfac = new YoLib.Data.Sql2000Factory(Connectstrinfo, null);
            //Dfac.AddDataModel("BaseModel");
            try
            {
                PrepLoadBaseModel();
            }
            catch (Exception ex)
            {
                Console.WriteLine("加载基础模块失败");
            }
            FA_Item item = new FA_Item();
            item.BatchNo = "1";
            var err=item.Save();
            if (!string.IsNullOrWhiteSpace(err))
            {
                Console.WriteLine(err);
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("FA_Item保存成功");
                Console.ReadLine();
            }
        }
        static System.Reflection.Assembly BaseModelass;
        static int BaseModelLoadState = 0;

        static Dictionary<string, string> Loadedxml = new Dictionary<string, string>();
        public static void PrepLoadBaseModel()
        {
            if (BaseModelLoadState != 0) return;
            BaseModelass = System.Reflection.Assembly.Load("BaseModel");
            string[] prophbm = new string[] {
                "BaseModel.HBM.FA_Item.hbm.xml",
            };
            foreach (string xml in prophbm)
            {
                YoLib.Data.DataFactory.CurFactory.AddResource(xml, BaseModelass);
                Loadedxml.Add(xml, null);
            }
            BaseModelLoadState = 1;
        }



    }
}

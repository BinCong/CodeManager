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
            FA_Item item = new FA_Item();
            item.BathNo = "1";
            var err=item.Save();
            if (!string.IsNullOrWhiteSpace(err))
            {
                Console.WriteLine(err);
                Console.ReadLine();
            }
        }



    }
}

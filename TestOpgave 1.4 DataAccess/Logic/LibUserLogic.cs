using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using TestOpgave_1._4_DataAccess.Models;
using TestOpgave_1._4_DataAccess.Access;

namespace TestOpgave_1._4_DataAccess.Logic
{
    public static class LibUserLogic
    {

        public static void CreateLibUser(string name)
        {
            string sql = "insert into [TestOpgave14].[dbo].[LibUser] (name) values (@name)";


            LibUserModel userModel = new LibUserModel{
                name = name
            };

            DataAccess.SaveData(sql, userModel);
        }

        public static List<LibUserModel> LoadLibUsers()
        {
            string sql = "select name, libraryUserNo from [TestOpgave14].[dbo].[LibUser]";

            return DataAccess.LoadData<LibUserModel>(sql);
        }


    }
}

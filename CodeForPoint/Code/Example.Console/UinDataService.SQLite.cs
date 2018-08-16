using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
namespace Example.Console
{
    
    public class SyncDataHelper 
    {
        public static void SyncCategory() 
        {
            try
            {
                List<CategoryData> list = new List<CategoryData>();
                for (int i = 0; i < 30; i++)
                {
                    CategoryData c = new CategoryData()
                    {
                        Code = "C" + i,
                        Name = "N" + i,
                        CreateTime = DateTime.Now,
                        Id = i,
                        IsDelete = false,
                        ItemType = "City",
                        NodeLevel = 0,
                        ParentCode = "-1",
                        ParentId = -1,
                        Sort = 1
                    };
                    list.Add(c);
                }
                SQLiteReporistory<CategoryData> md = new SQLiteReporistory<CategoryData>("data source=LocalDB.db;");
                md.BatchAdd(list);
            }
            catch (Exception ex)
            { 
            
            }
        }
    }
  
}

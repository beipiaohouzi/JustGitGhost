using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Linq.Mapping;
using System.ComponentModel.DataAnnotations;
namespace DebugApp
{
    public class SystemConfig
    {
        public static string GetDBString
        {
            get
            {
                return string.Empty;
            }
        }
        public static string dir
        {
            get { return AppDomain.CurrentDomain.BaseDirectory; }
        }
    }

    public class SqliteEFService
    {
        public void Query()
        {
            try
            {
                //online 
                var sqliteContext = new DBReporistoryProxy<Patient>();

                /*
                     SQL logic error
 no such table: Patients
                      */
                //  var apiInfo_sqlite = sqliteContext.Entity.AsQueryable().ToList();
                //List<Patient> patients= sqliteContext.DoQuery<Patient>().ToList();
                Patient p = new Patient()
                {
                    TId = Guid.NewGuid().ToString(),
                    PatientID = Guid.NewGuid().ToString(),
                    PatientName = "张三"+DateTime.Now.ToString("HHss"),
                    PatientSex = "0"
                };
                sqliteContext.AddList(new Patient[] { p });
               // patients = sqliteContext.DoQuery<Patient>().ToList();
            }
            catch (Exception ex)
            {

            }
        }
    } 
    public class DBContextFactory <T>: DbContext where T:class
    {
        public DBContextFactory() : base("SQLite")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        { 
            base.OnModelCreating(modelBuilder);
        }
        public IDbSet<T> Entity { get; set; }
    }
    [Table( Name ="Patient")]
    public class Patient
    {
        [Key]
        public string TId { get; set; }
        public string PatientID { get; set; }
        public string PatientName { get; set; }
        public string PatientBirthDate { get; set; }
        public string PatientBirthTime { get; set; }
        public string PatientSex { get; set; }
        public string EthnicGroup { get; set; }
        public string IssuerOfPatientID { get; set; }
        public string QualityControlSubject { get; set; }
        public string ReferencedSOPClassUID { get; set; }
        public string ReferencedSOPInstanceUID { get; set; }
        public string OtherPatientID { get; set; }
        public string OtherPatientNames { get; set; }
        public string OtherIssuerOfPatientID { get; set; }
        public string PatientComments { get; set; } 
    }
    /// <summary>
    /// 封装单个数据表的简单操作/外键约束表的增加
    /// </summary>
    public class DBReporistoryProxy<T> where T : class
    {
        static DBContextFactory<T> dbcontext = null;
        public DBReporistoryProxy()
        {
            if (dbcontext == null)
            {
                dbcontext = new DBContextFactory<T>();
            }
        }
        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="datas"></param>
        /// <returns></returns>
        public int AddList(T[] datas)
        {
            DbSet<T> ds = dbcontext.Set<T>();
            foreach (var data in datas)
            {
                ds.Add(data);
            }
            return Submit();
        }
        /// <summary>
        /// 主键删除
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int Delete(object obj)
        {
            DbSet<T> ds = dbcontext.Set<T>();
            T one = ds.Find(obj);
            dbcontext.Entry(one).State = EntityState.Deleted;
            return Submit();
        }
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <typeparam name="R"></typeparam>
        /// <param name="ids"></param>
        public void BatchDelete<R>(object[] ids) where R : class
        {
            DbSet<R> ds = dbcontext.Set<R>();
            foreach (var item in ids)
            {
                R one = ds.Find(item);
                dbcontext.Entry(one).State = EntityState.Deleted;
            }
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <typeparam name="R"></typeparam>
        /// <param name="entity"></param>
        /// <param name="origin"></param>
        public void Update<R>(R entity, R origin) where R : class
        {
            dbcontext.Entry(origin).CurrentValues.SetValues(entity);//进行数据更新替换
        }
        /// <summary>
        /// 开放提交接口，用于进行批量修改时使用
        /// </summary>
        /// <returns></returns>
        public int Submit()
        {
            return dbcontext.SaveChanges();
        }
        /// <summary>
        /// 主键查找
        /// </summary>
        /// <typeparam name="R"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public R Get<R>(object obj) where R : class
        {
            DbSet<R> ds = dbcontext.Set<R>();
            return ds.Find(obj);
        }
        /// <summary>
        /// 提供使用lambda表达式操作的查询
        /// </summary>
        /// <typeparam name="R"></typeparam>
        /// <returns></returns>
        public IEnumerable<R> DoQuery<R>() where R : class
        {
            DbSet<R> ds = dbcontext.Set<R>();
            return ds.AsQueryable().AsNoTracking().AsEnumerable();
        }

    }
}

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
                using (var sqliteContext = new SQLiteDBCoontext<Patient>())
                {
                    var apiInfo_sqlite = sqliteContext.APIInfo.FirstOrDefault();
                    
                    //sqliteContext.SaveChanges();
                }

                //mine
                DBContextFactory<Patient> pf = new DBContextFactory<Patient>();
                List<Patient> ps = pf.Entity.AsQueryable().ToList();
            }
            catch (Exception ex)
            {

            }
        }
    }
   // [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class SQLiteDBCoontext<T> : DbContext where T:class
    {
        public SQLiteDBCoontext() : base("SQLite")
        {
            Database.SetInitializer(new InitializerDBContext<DBContextFactory<T>>());
        }

        public DbSet<T> APIInfo { get; set; }
    }
    public class InitializerDBContext<T> : DropCreateDatabaseAlways<T> where T:DbContext
    {
        protected override void Seed(T context)
        {
            #region 接口信息表
            
            #endregion

            base.Seed(context);
        }
    }
    public class DBContextFactory <T>: DbContext where T:class
    {
        public DBContextFactory() : base("SQLite")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {   
           //modelBuilder.Configurations.AddFromAssembly(System.Reflection.Assembly.LoadFrom("XPect.Lib.DataModel.dll"));
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

}

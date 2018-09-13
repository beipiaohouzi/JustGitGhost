using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Linq.Mapping;
using System.ComponentModel.DataAnnotations;
using XPect.Lib.DataModel.DataBaseEntity;
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
                using (var sqliteContext = new DBContextFactory<XPectPatient>())
                {
                    var apiInfo_sqlite = sqliteContext.Entity.AsQueryable().ToList();
                    
                    //sqliteContext.SaveChanges();
                }

                //mine
                DBContextFactory<XPectPatient> pf = new DBContextFactory<XPectPatient>();
                List<XPectPatient> ps = pf.Entity.AsQueryable().ToList();
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
            //Database.Initialize(false);
            //Database.CreateIfNotExists();
            modelBuilder.Configurations.AddFromAssembly(System.Reflection.Assembly.LoadFrom("XPect.Lib.DataModel.dll"));
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

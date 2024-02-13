using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace AdoVsEF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //DbConnection dbConnection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SampleDb;Integrated Security=True;Connect Timeout=60;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            //IService ado = new ServiceAdo(dbConnection);

            //foreach(Sample sample in ado.Get())
            //{
            //    Console.WriteLine(sample.ToString());
            //}
            //Console.WriteLine("Press F5 to continue");            

            //Sample? first = null;

            using (MyDbContext dbContext = new MyDbContext())
            {
                IService ef = new ServiceEF(dbContext);

                foreach (Sample sample in ef.Get())
                {
                    Console.WriteLine(sample.ToString());
                }

                //first = dbContext.Find<Sample>(1);
            }

            //if (first is not null)
            //{
            //    Console.WriteLine(first.ToString());

            //    using (MyDbContext dbContext = new MyDbContext())
            //    {
            //        //IService ef = new ServiceEF(dbContext);

            //        //foreach (Sample sample in ef.Get())
            //        //{
            //        //    Console.WriteLine(sample.ToString());
            //        //}
            //        first.Uid = Guid.NewGuid();
            //        dbContext.Attach(first);
            //        dbContext.Entry(first).State = EntityState.Modified;
            //        dbContext.SaveChanges();
            //    }
            //}

            

            //if (first is not null)
            //    first.Uid = new Guid();

            //dbContext.Remove(dbContext.Find<Sample>(2));

            //dbContext.Add(new Sample() { Uid = Guid.NewGuid() });

            //Console.WriteLine(dbContext.SaveChanges());

            Console.WriteLine("Press F5 to continue");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Client.ServiceReference1;
using University.Db;

namespace University.Client
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var db = new ServiceContext())
            {
                foreach (var x in db.Lecturers)
                {
                    Console.WriteLine(x.LecturerName);
                }
            }
           }
    }
}

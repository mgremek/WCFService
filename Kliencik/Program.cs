using ProduktyService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Kliencik
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost h = new ServiceHost(typeof(ProduktyService2.ProduktyService));
            h.Opened += H_Opened;
            h.Open();
            Console.Read(); 
        }

        private static void H_Opened(object sender, EventArgs e)
        {
            Console.WriteLine("Działa");
        }
    }
}

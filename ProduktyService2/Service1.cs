using ProduktyService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ProduktyService2
{
    // UWAGA: możesz użyć polecenia „Zmień nazwę” w menu „Refaktoryzuj”, aby zmienić nazwę klasy „Service1” w kodzie i pliku konfiguracji.
    public class ProduktyService : IProdukty
    {
        WarKonfiguratorEntities wke;
        public ProduktyService()
        {
            wke = new WarKonfiguratorEntities();
        }

        public List<Manufacturers> GetManufacturers()
        {
            return wke.Manufacturers.ToList();
        }

        public List<Products_TEST> GetProdukty()
        {
            //return wke.Products_TEST.ToList();
            return wke.Products_TEST.Select(p=>new {ManID=p.ManID,Model=p.Model,Price=p.Price,SubId=p.SubID, Specification="[niedostępne w tym widoku]"}).Take(200).ToList()
                .ConvertAll<Products_TEST>(c=>new Products_TEST {  ManID = c.ManID, Model = c.Model, Price = c.Price, SubID=c.SubId, Specification=c.Specification });
        }

        public List<SubCategory> GetSubcategory()
        {
            return wke.SubCategory.ToList();
        }

        public List<Products_TEST> GetGpu()
        {
            return wke.Products_TEST.Select(p=>new {ManID=p.ManID, Model = p.Model, Price = p.Price, SubID = p.SubID, Specification = "[niedostępne w tym widoku]"}).Where(p=>p.SubID==2).Take(200).ToList()
                .ConvertAll<Products_TEST>(c => new Products_TEST { ManID = c.ManID, Model = c.Model, Price = c.Price, SubID = c.SubID, Specification = c.Specification });
        }
    }
}

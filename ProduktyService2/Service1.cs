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

        public List<SubCategory> GetSubcategory()
        {
            return wke.SubCategory.ToList();
        }

        public List<Products> GetProdukty(int subId)
        {
            //return wke.Products_TEST.ToList();
            return wke.Products_TEST.Select(p => new { ProdId = p.ProdID, ManID = p.ManID, Model = p.Model, Price = p.Price, SubID = p.SubID, Specification = "[niedostępne w tym widoku]" })
                                    .Where(p => p.SubID == subId)
                                    .Take(200)
                                    .ToList()
                                    .ConvertAll<Products_TEST>(c => new Products_TEST { ProdID = c.ProdId, ManID = c.ManID, Model = c.Model, Price = c.Price, SubID = c.SubID, Specification = c.Specification })
                                    .Join(wke.Manufacturers, l => l.ManID, r => r.Manufacturer_Id, (l, r) => new { lft = l, rght = r })
                                    .Where(x => x.lft.ManID == x.rght.Manufacturer_Id)
                                    .Select(c => new { c.rght.Manufacturer_Name, c.lft.ProdID, c.lft.Price, c.lft.Model, c.lft.Specification })
                                    .ToList()
                                    .ConvertAll<Products>(h => new Products { ProdID = h.ProdID, Manufacturer = h.Manufacturer_Name, Model = h.Model, Price = h.Price, Specification = h.Specification });
        }
        
    }
}

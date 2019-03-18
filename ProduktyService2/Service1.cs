using ProduktyService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
                                    .Take(30)
                                    .ToList()
                                    .ConvertAll<Products_TEST>(c => new Products_TEST { ProdID = c.ProdId, ManID = c.ManID, Model = c.Model, Price = c.Price, SubID = c.SubID, Specification = c.Specification })
                                    .Join(wke.Manufacturers, l => l.ManID, r => r.Manufacturer_Id, (l, r) => new { lft = l, rght = r })
                                    .Where(x => x.lft.ManID == x.rght.Manufacturer_Id)
                                    .Select(c => new { c.rght.Manufacturer_Name, c.lft.ProdID, c.lft.Price, c.lft.Model, c.lft.Specification })
                                    .ToList()
                                    .ConvertAll<Products>(h => new Products { ProdID = h.ProdID, Manufacturer = h.Manufacturer_Name, Model = h.Model, Price = h.Price, Specification = h.Specification });
        }
        public bool IsLogged(string pass, string login)
        {
            bool sprawdzDane = true;
            if ((pass != "" || pass != null) && (login != "" || login != null))
            {
                var i = (from c in wke.clients
                            where c.Login == login
                            where c.Pass == pass
                            select c.client_ID).Count();
                if (i==0) sprawdzDane = false;
            }
           return sprawdzDane;
        }

        public string GetXml(int id) //tujestcoszle
        {
           // XDocument xd = new XDocument();

            var v= wke.Products_TEST.Select(n => new { str = n.Specification, ProdID = n.ProdID }).Where(n => n.ProdID == id).First();
            return v.str;
                   
        }

        public List<Products> GetBasketItems(int ClientId)
        {
            var v = wke.BasketItems.Select(n => n)
                                    .Join(wke.Basket, l => l.BasketIdFOREIGN, r => r.BasketId, (l, r) => new { lft = l, rght = r })
                                    .Where(x => x.lft.BasketIdFOREIGN == x.rght.BasketId)
                                    .Where( z=> z.rght.ClientId==ClientId)
                                    .Where(z=>z.rght.BasketStatusId==1)
                                    .Select(c => new { c.lft.BasketItemId })
                                    .Join(wke.Products_TEST, l=>l.BasketItemId, r=>r.ProdID, (l,r)=> new {lft=l,rght=r})
                                    .Join(wke.Manufacturers,l => l.rght.ManID, r => r.Manufacturer_Id, (l, r) => new { lft = l, rght = r })
                                    .ToList()
                                    .ConvertAll<Products>(h=>new Products { ProdID = h.lft.rght.ProdID, Manufacturer = h.rght.Manufacturer_Name, Model = h.lft.rght.Model, Price = h.lft.rght.Price, Specification = null });
            return v;
        }

        public bool PostToBasket(int ProdId)
        {
            throw new NotImplementedException();
        }
    }
}

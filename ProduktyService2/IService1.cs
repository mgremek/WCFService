﻿using ProduktyService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ProduktyService2
{
    public enum Operation
    {
        Add, Delete
    }
    // UWAGA: możesz użyć polecenia „Zmień nazwę” w menu „Refaktoryzuj”, aby zmienić nazwę interfejsu „IService1” w kodzie i pliku konfiguracji.
    [ServiceContract]
    public interface IProdukty
    {
        [OperationContract]
        List<Products> GetProdukty(int subId);

        [OperationContract]
        List<Manufacturers> GetManufacturers();

        [OperationContract]
        List<SubCategory> GetSubcategory();

        [OperationContract]
        bool IsLogged(string pass, string login);

        [OperationContract]
        string GetXml(int id);

        [OperationContract]
        List<Products> GetBasketItems(int ClientId);

        [OperationContract]
        bool ModifyBasket(int ProdId, Operation operation);
     
    }
}

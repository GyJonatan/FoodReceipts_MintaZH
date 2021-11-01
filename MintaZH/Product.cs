using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MintaZH
{
    /*
     a) Készítsen el egy Product osztályt az alábbi írható olvasható nyilvános tulajdonságokkal: (0 pont)
            Name (string) - Megnevezés
            Amount (int) - Mennyiség
    */

    /*
     d) Helyezze el a Refrigerator és Product osztályok tulajdonságain a DisplayName attribútumot beszédes
        nevekkel. (0,5 pont) *csillaggal jelölöm*
     */
    public class Product
    {
        [DisplayName("Név")]//*
        public string Name { get; set; }
        [DisplayName("Mennyiség")]//*
        public int Amount { get; set; }
    }
}

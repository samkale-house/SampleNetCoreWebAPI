using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLibrary
{
    public class ProductType
    {
        public int ID { get; set; }
        public string Type_Name { get; set; }

        //[ForeignKey("Product_Type")]//name of forignkey from Product class
        public List<Product> products { get; set; }
    }
}

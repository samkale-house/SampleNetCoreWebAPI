using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLibrary
{
   
    public class Product
    {
        public int ID { get; set; }

        [DisplayName("Title")]
        public string Product_Name { get; set; }
        public string Company { get; set; }

        [DisplayName("Price")]
        public decimal Product_Price { get; set; }

        public string Product_Image { get; set; }

        [Required]
        public int Product_Type { get; set; }

        [ForeignKey("Product_Type")]                //forignkey navigation property for integer property Product_Type
        public ProductType ProductType { get; set; }//forign key constraint navigation property
    }

}

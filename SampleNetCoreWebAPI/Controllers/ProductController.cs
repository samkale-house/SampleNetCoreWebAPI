using DataLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleNetCoreWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController:ControllerBase
    {
        private readonly AppDbContext _db;
        public ProductController(AppDbContext db)
        {
            _db =db;
        }
        
        [HttpGet]
        public ActionResult<Product> ProductWithId(int id)
        {

            var product = _db.Products.Where(z=>z.ID==id).Include("ProductType").FirstOrDefault();
            if (product == null)
            {
                return NotFound("Product not found");
            }

            return Ok(product);

        }
        [HttpGet("ProductByCategory")]
        public ActionResult<List<Product>> ProductByCategory(string category)
        {
            if (category != null)
            {
                //getcategoryid
               // int categoryid = _db.ProductTypes.Where(type => type.Type_Name.Equals(category)).FirstOrDefault().ID;

                var categoryentity = _db.Products.Where(p => p.ProductType.Type_Name.Equals(category)).ToList();// _db.Products.Where(p => p.Product_Type == categoryid).ToList();

                if (categoryentity.Count==0)
                {
                    return NotFound("No products of this category are added yet");
                }

                return Ok(categoryentity);
            }
            return BadRequest("Please provide category name");
        }
    }
}

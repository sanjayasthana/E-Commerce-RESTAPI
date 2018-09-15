using ECom.BAL;
using ECom.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace E_Commerce.Controllers
{
    [RoutePrefix("api/product")]
    public class ProductController : ApiController
    {
        ProductService ps = null;
        public ProductController()
        {
            ps = new ProductService();
        }


        [Route("GetProduct")]
        [HttpGet]
        public IHttpActionResult Get(int Id)
        {
            return Ok(ps.GetProduct(Id));
        }

        [Route("GetProductList")]
        [HttpPost]
        public IHttpActionResult Get(int[] category, string name ="")
        {
            IList<Product> pList = ps.GetProductList(category, name);
            var d = pList.Select(x => new Product
            {   ProductId =x.ProductId,
                CategoryId = x.CategoryId,
                Description = x.Description,
                Name = x.Name,
                ProductAttributes = x.ProductAttributes.Select(y => new ProductAttribute()
                {
                    AttributeValue = y.AttributeValue,
                    AttributeId = y.AttributeId,
                    ProductAttributeLookup = new ProductAttributeLookup() { AttributeName = y.ProductAttributeLookup.AttributeName, AttributeId = y.AttributeId }
                }).ToArray()
            }).ToArray();
            return Ok(d);
        }

        [Route("GetCategoryList")]
        [HttpGet]
        public IHttpActionResult GetCategory()
        {
            return Ok(ps.GetCategoryList());
        }

        [Route("GetroductAttributeLookupList")]
        [HttpGet]
        public IHttpActionResult GetroductAttributeLookupList(int CategoryId)
        {
            return Ok(ps.GetroductAttributeLookupList(CategoryId));
        }

        [Route("GetroductAttributeList")]
        [HttpGet]
        public IHttpActionResult GetroductAttributeList(int ProductId)
        {
            return Ok(ps.GetroductAttributeList(ProductId));
        }

        [Route("Save")]
        [HttpPost]
        public IHttpActionResult Save(Product P)
        {
            return Ok(ps.Save(P));
        }
    }
}

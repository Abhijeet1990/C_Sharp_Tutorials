using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CRUD.Controllers
{
    public class ProductController : ApiController
    {
        [HttpPost()]
        public IHttpActionResult Post(Product product)
        {
            IHttpActionResult ret = null;
            if (Add(product))
            {
                ret = Created<Product>(Request.RequestUri +
                     product.ProductId.ToString(), product);
            }
            else
            {
                ret = NotFound();
            }
            return ret;
        }

        [HttpGet()]
        public IHttpActionResult Get()
        {
            IHttpActionResult ret = null ;
            List<Product> list = new List<Product>();
            Product prod = new Product();

            list = CreateMockData();
            //prod = list.Find(p => p.ProductId == id);
            if (list.Count == 0)
            {
                ret = NotFound();
            }
            else {
                ret = Ok(list);
            }

            return ret;
        }

        // for single product
        [HttpGet()]
        public IHttpActionResult Get(int id)
        {
            IHttpActionResult ret;
            List<Product> list = new List<Product>();
            Product prod = new Product();

            list = CreateMockData();
            prod = list.Find(p => p.ProductId == id);
            if (prod == null)
            {
                ret = NotFound();
            }
            else {
                ret = Ok(prod);
            }

            return ret;
        }

        [HttpPut()]
        public IHttpActionResult Put(int id,
                             Product product)
        {
            IHttpActionResult ret = null;
            if (Update(product))
            {
                ret = Ok(product);
            }
            else
            {
                ret = NotFound();
            }
            return ret;
        }

        [HttpDelete()]
        public IHttpActionResult Delete(int id)
        {
            IHttpActionResult ret = null;
            if (DeleteProduct(id))
            {
                ret = Ok(true);
            }
            else
            {
                ret = NotFound();
            }
            return ret;
        }

        private bool DeleteProduct(int id)
        {
            return true;
        }
        private bool Update(Product product)
        {
            return true;
        }

        private bool Add(Product product)
        {
            int newId = 0;
            List<Product> list = new List<Product>();
            list = CreateMockData();

            newId = list.Max(p => p.ProductId);
            newId++;
            product.ProductId = newId;
            list.Add(product);
            // TODO: Change to ‘ false ’ to test NotFound()
            return true;
        }
        private List<Product> CreateMockData()
        {
            List<Product> ret = new List<Product>();
            ret.Add(new Product()
            {
                ProductId = 1,
                ProductName = "Extending Bootstrap with CSS,JavaScript and jQuery",
              IntroductionDate = Convert.ToDateTime("6/11/2015"),
                Url = "http://bit.ly/1SNzc0i"
            });

            ret.Add(new Product()
            {
                ProductId = 2,
                ProductName = "Build your own Bootstrap Business Application Template in MVC",
              IntroductionDate = Convert.ToDateTime("1/29/2015"),
                Url = "http://bit.ly/1I8ZqZg"
            });

            ret.Add(new Product()
            {
                ProductId = 3,
                ProductName = "Building Mobile Web Sites Using Web Forms,Bootstrap,and HTML5",
              IntroductionDate = Convert.ToDateTime("8/28/2014"),
                Url = "http://bit.ly/1J2dcrj"
            });

            return ret;
        }
    }
}

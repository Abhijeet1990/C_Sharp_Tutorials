using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI2Tutorial.Models;


namespace WebAPI2Tutorial.Controllers
{
    public class ProductsController : ApiController
    {
        Product[] products = new Product[]
        {
            new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 },
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
            new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M }
        };

        public IEnumerable<Product> GetAllProducts()
        {
            return products;
        }

        //IHttpActionResult contains a single method, ExecuteAsync, which asynchronously creates an HttpResponseMessage instance.
        /*
         * public interface IHttpActionResult
        {
            Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken);
         }
         */
        public HttpResponseMessage GetProduct(int id)
        {
            var product = products.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                //return NotFound();
                var message = String.Format("customer with id: {0} was not found", id);
                var httpError = new HttpError(message);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, httpError);
            }
            return Request.CreateResponse(HttpStatusCode.OK, product);
        }
    }
}

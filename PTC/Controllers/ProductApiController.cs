using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PTC
{
    [RoutePrefix("api/productApi")]
    public class ProductApiController : ApiController
    {
        public IHttpActionResult Get()
        {
            IHttpActionResult ret;
            PTCViewModel vm = new PTCViewModel();

            //throw new ApplicationException("Error"); to check error

            vm.Get();
            if(vm.Products.Count() > 0)
            {
                ret = Ok(vm.Products);
            }
            else if(vm.LastException != null)
            {
                ret = BadRequest(vm.Message);
            }
            else
            {
                ret = NotFound();
            }
            return ret;
        }

        [Route("Search")]
        [HttpPost()]

        public IHttpActionResult Search([FromBody]ProductSearch search)
        {
            IHttpActionResult ret;
            PTCViewModel vm = new PTCViewModel();

            vm.SearchEntity = search;
            vm.Search();
            if (vm.LastException != null)
            {
                ret = BadRequest(vm.Message);
            }
            else
            {
                ret = Ok(vm.Products);
            }

            return ret;
        }
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //public string Get(int id)
        //{
        //    return "value";
        //}

        //public void Post([FromBody]string value)
        //{
        //}

        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //public void Delete(int id)
        //{
        //}
    }
}
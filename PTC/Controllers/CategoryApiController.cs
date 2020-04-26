using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PTC.Controllers
{
    [RoutePrefix("api/CategoryApi")]
    public class CategoryApiController : ApiController
    {
        [HttpPost()]
        [Route("SearchCategories")]

        public IHttpActionResult GetSearchCategories()
        {
            IHttpActionResult ret;
            PTCViewModel vm = new PTCViewModel();

            vm.LoadSearchCategories();
            if(vm.SearchCategories.Count() > 0)
            {
                ret = Ok(vm.SearchCategories);
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

        public IHttpActionResult Get()
        {
            IHttpActionResult ret;
            PTCViewModel vm = new PTCViewModel();

            vm.LoadCategories();
            if (vm.Categories.Count() > 0)
            {
                ret = Ok(vm.Categories);
            }
            else if (vm.LastException != null)
            {
                ret = BadRequest(vm.Message);
            }
            else
            {
                ret = NotFound();
            }

            return ret;
        }

        //GET api/<controller>
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //GET api/<controller>/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<controller>
        //public void Post([FromBody]string value)
        //{
        //}

        // PUT api/<controller>/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        // DELETE api/<controller>/5
        //public void Delete(int id)
        //{
        //}
    }
}
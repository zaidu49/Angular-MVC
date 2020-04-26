using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PTC.Models;
using System.Web.Http.ModelBinding;

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

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            IHttpActionResult ret;
            PTCViewModel vm = new PTCViewModel();
            
            vm.Get(id);
            if (vm.Entity != null)
            {
                ret = Ok(vm.Entity);
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

        private ModelStateDictionary ConvertToModelState(System.Web.Mvc.ModelStateDictionary state)
        {
            ModelStateDictionary ret = new ModelStateDictionary();
            foreach(var list in state.ToList())
            {
                for(int i=0; i<list.Value.Errors.Count;i++)
                {
                    ret.AddModelError(list.Key, list.Value.Errors[i].ErrorMessage);
                }
            }
            return ret;
        }

        [HttpPost]
        public IHttpActionResult Post(Product product)
        {
            IHttpActionResult ret = null;
            PTCViewModel vm = new PTCViewModel();

            if(product != null)
            {
                vm.Entity = product;
                vm.PageMode = PDSAPageModeEnum.Add;
                vm.Save();
                if(vm.IsValid)
                {
                    ret = Created<Product>(
                        Request.RequestUri +
                        vm.Entity.ProductId.ToString(),
                        vm.Entity);
                }
                else
                {
                    if(vm.Messages.Count > 0)
                    {
                        ret = BadRequest(ConvertToModelState(vm.Messages));
                    }
                    else
                    {
                        ret = BadRequest(vm.Message);
                    }
                }
            }
            else
            {
                ret = NotFound();
            }
            return ret;
        }

        [HttpPut]
        public IHttpActionResult Put(int id,Product product)
        {
            IHttpActionResult ret = null;
            PTCViewModel vm = new PTCViewModel();

            if(product != null)
            {
                vm.Entity = product;
                vm.PageMode = PDSAPageModeEnum.Edit;
                vm.Save();
                if(vm.IsValid)
                {
                    ret = Ok(vm.Entity);
                }
                else
                {
                    if(vm.Messages.Count > 0)
                    {
                        ret = BadRequest(ConvertToModelState(vm.Messages));
                    }
                    else if(vm.LastException != null)
                    {
                        ret = BadRequest(vm.Message);
                    }
                }
            }
            else
            {
                ret = NotFound();
            }
            return ret;
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            IHttpActionResult ret;
            PTCViewModel vm = new PTCViewModel();

            vm.Delete(id);
            if(vm.LastException != null)
            {
                ret = BadRequest(vm.Message);
            }
            else
            {
                ret = Ok(vm.Entity);
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
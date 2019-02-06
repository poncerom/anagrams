using System;
using System.Web.Http;
using Anagram.Business;

namespace Anagram.Controllers
{
    
    public class AnagramController : ApiController
    {
        private readonly IAnagramCalculatorBusiness _business;

        public AnagramController(IAnagramCalculatorBusiness business)
        {
            _business = business;
        }
        
        [HttpGet]
        public IHttpActionResult Get(string value)
        {
            if(String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
            {
                return BadRequest("Value is mandatory");
            }
            
            var result = _business.GetFormattedAnagrams(value);
            return Ok(result);
        }

        
    }
}
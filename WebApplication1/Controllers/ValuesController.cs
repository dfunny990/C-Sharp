using Microsoft.AspNetCore.Mvc;
using System.Net;
using static System.Net.WebRequestMethods;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/values")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<IEnumerable<String>> Get(String id)
        {
            var result = await GetExternalResponse(id);

            return new string[] { result, "value2" };
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        String key = "?key=f823c9a1-95f4-4619-8e3d-b85e3272347e";
        String _address = "https://www.dictionaryapi.com/api/v3/references/collegiate/json/";
        private async Task<string> GetExternalResponse(string id)
        {
            var client = new HttpClient();
            String fullPath = _address + id + key;
            Console.WriteLine(fullPath);
            HttpResponseMessage response = await client.GetAsync(fullPath);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            return result;
        }
    }
}

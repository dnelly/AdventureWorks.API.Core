using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AdventureWorks.Data.Person;
using AdventureWorks.Data;
using AdventureWorks.Repository;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AdventureWorks.API.Controllers
{
    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        private AdventureWorks2014Context _context;
        private IPersonRepository _personRepository;
        public PersonController(IPersonRepository repository)
        {
            _personRepository = repository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        // GET: api/values
        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return _personRepository.GetPerson().ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET api/values/5
        [HttpGet("{id}")]
        public Person Get(int id)
        {
            return _personRepository.GetPerson(id);
        }

        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{

        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        // POST api/values
        [HttpPost]
        public Person Post([FromBody]Person person)
        {
            if (person != null)
            {
                var results = _personRepository.Add(person);
            }

            return person;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="person"></param>
        /// <returns></returns>
        // PUT api/values/5
        [HttpPut("{id}")]
        public Person Put(int id, [FromBody]Person person)
        {
            if (person != null)
            {
                _personRepository.UpdatePerson(person);
            }


            return person;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

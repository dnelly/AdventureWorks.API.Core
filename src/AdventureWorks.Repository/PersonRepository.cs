using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdventureWorks.Data;
using AdventureWorks.Data.HumanResources;
using AdventureWorks.Data.Person;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorks.Repository
{
    public interface IPersonRepository
    {
        IQueryable<Person> GetPerson();
        Person GetPerson(int id);
        Person UpdatePerson(Person person);
        Person Add(Person person);
    }

    public class PersonRepository : IPersonRepository
    {
        private AdventureWorks2014Context _adventureWorks2014Context;
        public PersonRepository(AdventureWorks2014Context adventureWorks2014Context)
        {
            _adventureWorks2014Context = adventureWorks2014Context;
        }

        public Person Add(Person person)
        {
            var businessEntity = new BusinessEntity() {Person = person,Rowguid = person.Rowguid};
            person.BusinessEntity = businessEntity;
            var result = _adventureWorks2014Context.Person.Add(person).Entity;
            _adventureWorks2014Context.SaveChanges();
            return result;
        }

        public IQueryable<Person> GetPerson()
        {
            return _adventureWorks2014Context.Person
                .Include(p=>p.Employee)
                .Include(p=>p.EmailAddress);
        }

        public Person GetPerson(int id)
        {

            return _adventureWorks2014Context.Person.FirstOrDefault(p=>p.BusinessEntityId == id);
        }

        public Person UpdatePerson(Person person)
        {
            var results = _adventureWorks2014Context.Person.Update(person).Entity;
            _adventureWorks2014Context.SaveChanges();
            return results;
        }
    }
}

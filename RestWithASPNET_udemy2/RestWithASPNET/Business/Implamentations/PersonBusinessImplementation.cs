using RestWithASPNET.Models;
using RestWithASPNET.Business.Implementations;
using RestWithASPNET.Repository;
using System.Collections.Generic;


namespace RestWithASPNET.Business.Implamentations
{
    public class PersonServiceImplementation : IPersonBusiness
    {
        private IPersonRepository _repository; 
        
        public void PersonBusinessImplementation(IPersonRepository repository)
        {
            _repository = repository;
        }

        public Person Create(Person person)
        {
            return _repository.Create(person);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<Person> FindAll()
        {
           return _repository.FindAll();
        }

        public Person FindByID(long id)
        {
            return _repository.FindByID(id);

        }
        public Person Update(Person person)
        {
            return _repository.Update(person);
        }
    }
}

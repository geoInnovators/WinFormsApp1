using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1;

public class PersonManager
{
    public List<Person> persons;

    private readonly IStorageRepository storageRepository;

    public PersonManager(IStorageRepository storageRepository)
    {
        this.storageRepository = storageRepository;
    }
    public void Load()
    {
        persons = storageRepository.Load();
    }
    public void Add(Person person)
    {
        person.Id = persons.Max(x => x.Id) + 1;
        persons.Add(person);
        storageRepository.Add(persons);
    }
}

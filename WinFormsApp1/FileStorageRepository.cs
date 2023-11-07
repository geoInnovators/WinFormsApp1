using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1;

public class FileStorageRepository : IStorageRepository
{
    public void Add(List<Person> persons)
    {
        File.WriteAllText(@".\Persons.json", JsonConvert.SerializeObject(persons));
    }

    public List<Person> Load()
    {
        var text = File.ReadAllText(@".\Persons.json");
        return  JsonConvert.DeserializeObject<List<Person>>(text);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1;

public interface IStorageRepository
{
    List<Person> Load();
    void Add(List<Person> person);
}

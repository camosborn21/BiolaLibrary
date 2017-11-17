using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiolaLibrary.Model;
namespace BiolaLibrary.Application
{
    public interface IUiDataProvider
    {
	    IList<Person> GetPeople();
	    Person GetPerson(int personId);
	    Person UpdatePerson(Person person);
	    Person NewPerson(Person person);
	    void DeletePerson(Person person);
    }
}

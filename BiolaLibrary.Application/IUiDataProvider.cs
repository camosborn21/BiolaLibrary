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
	    void UpdatePerson(ref Person person);
	    Person NewPerson(Person person);
	    void DeletePerson(ref Person person);
    }
}

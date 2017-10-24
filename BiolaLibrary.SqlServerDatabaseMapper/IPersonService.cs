using System.Collections.Generic;
namespace BiolaLibrary.SqlServerDatabaseMapper
{
	public interface IPersonService
	{
		IList<Person> GetPeople();
		Person GetPerson(int personId);
		void Update(Person person);
		void NewPerson(Person person);
		void DeletePerson(Person person);
	}
}
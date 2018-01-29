using System.Collections.Generic;
namespace BiolaLibrary.SqlServerDatabaseMapper
{
	public interface IPersonService
	{
		IList<Person> GetPeople();
		Person GetPerson(int personId);
		Person Update(Person person);
		Person NewPerson(Person person);
		void DeletePerson(Person person);
		void DeletePersonById(int entityId);
	}
}
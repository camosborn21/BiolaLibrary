using System.Collections.Generic;
namespace BiolaLibrary.SqlServerDatabaseMapper
{
	public interface IPersonService
	{
		IList<Person> GetPeople();
		Person GetPerson(int personId);
		void Update(ref Person person);
		Person NewPerson(Person person);
		void DeletePerson(Person person);
	}
}
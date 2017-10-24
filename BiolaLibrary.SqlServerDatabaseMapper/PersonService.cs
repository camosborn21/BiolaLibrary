using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using BiolaLibrary.Data;
using System;

namespace BiolaLibrary.SqlServerDatabaseMapper
{
	public class PersonService : IPersonService
	{
		private readonly LibraryPublicServicesEntities _libraryPublicServicesEntities = new LibraryPublicServicesEntities();

		public void DeletePerson(Person person)
		{
			throw new NotImplementedException();
		}

		public IList<Person> GetPeople()
		{
			return _libraryPublicServicesEntities.People.Select(p => new Person
			{
				EntityId = p.EntityId,
				FirstName = p.FirstName,
				LastName = p.LastName
			}).ToList();
		}

		public Person GetPerson(int personId)
		{
			throw new System.NotImplementedException();
		}

		public void NewPerson(Person person)
		{
			Data.Person newPersonEntity = new Data.Person
			{
				FirstName = person.FirstName,
				MiddleName = person.MiddleName,
				LastName = person.LastName,
				PersonType = person.PersonType.Id,
				Title = person.Title,
				Suffix = person.Suffix,
				ModifiedDate = DateTime.Now
			};
			_libraryPublicServicesEntities.People.Add(newPersonEntity);
			_libraryPublicServicesEntities.SaveChanges();
		}

		public void Update(Person person)
		{
			throw new System.NotImplementedException();
		}
	}
}
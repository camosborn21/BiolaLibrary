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
				LastName = p.LastName,
				LastUpdate = p.ModifiedDate
			}).ToList();
		}

		public Person GetPerson(int personId)
		{
			throw new NotImplementedException();
		}

		public Person NewPerson(Person person)
		{

			Data.Person newPersonEntity = new Data.Person
			{
				FirstName = person.FirstName,
				MiddleName = person.MiddleName,
				LastName = person.LastName,
				PersonType = person.PersonType.Id,
				Title = person.Title,
				Suffix = person.Suffix,
				ModifiedDate = DateTime.Now,
				rowguid = Guid.NewGuid(),
				//[10/26/2017 18:07] camerono: Generate EntityId for new person
				EntityId = _libraryPublicServicesEntities.Entities
					.Add(new Entity {ModifiedDate = DateTime.Now, rowguid = Guid.NewGuid()}).EntityId
			};

			//[10/26/2017 18:07] camerono: Add new person to the database and save changes
			_libraryPublicServicesEntities.People.Add(newPersonEntity);
			_libraryPublicServicesEntities.SaveChanges();

			//[10/26/2017 18:07] camerono: Pass Updated person back through mapper class to model
			person.EntityId = newPersonEntity.EntityId;
			person.LastUpdate = newPersonEntity.ModifiedDate;
			return person;
		}



		public void Update(ref Person person)
		{
			throw new System.NotImplementedException();
		}
	}
}
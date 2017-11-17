using System.Collections.Generic;
using System.Linq;
using BiolaLibrary.SqlServerDatabaseMapper;
using Person = BiolaLibrary.Model.Person;

namespace BiolaLibrary.Application
{
	public class UiDataProvider : IUiDataProvider
	{
		private IList<Model.Person> _people;

		private readonly IPersonService _personServiceClient;

		public UiDataProvider(IPersonService personService)
		{
			_personServiceClient = personService;
		}

		public IList<Person> GetPeople()
		{
			return _people ?? (_personServiceClient.GetPeople()
				.Select(p => 
				PersonTranslator.Instance.CreateModel(p))
				.ToList());
		}

		public Person GetPerson(int personId)
		{
			return PersonTranslator.Instance.CreateModel(_personServiceClient.GetPerson(personId));
		}

		public Person UpdatePerson(Person person)
		{
			return PersonTranslator.Instance.UpdateModel(person,
				_personServiceClient.Update(PersonTranslator.Instance.CreateDto(person)));
		}

		public Person NewPerson(Person person)
		{
			return PersonTranslator.Instance.CreateModel(_personServiceClient.NewPerson(PersonTranslator.Instance.CreateDto(person)));
		}

		public void DeletePerson(Person person)
		{
			throw new System.NotImplementedException();
		}
	}
}
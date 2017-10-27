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
			throw new System.NotImplementedException();
		}

		public void UpdatePerson(ref Person person)
		{
			throw new System.NotImplementedException();
		}

		public Person NewPerson(Person person)
		{
			return PersonTranslator.Instance.CreateModel(_personServiceClient.NewPerson(PersonTranslator.Instance.CreateDto(person)));
		}

		public void DeletePerson(ref Person person)
		{
			throw new System.NotImplementedException();
		}
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiolaLibrary.Application;
using BiolaLibrary.SqlServerDatabaseMapper;
using Person = BiolaLibrary.Model.Person;
using PersonType = BiolaLibrary.Model.PersonType;

namespace BiolaLibrary.Console
{
	class Program
	{
		public static void TestGetPeople()
		{
			IUiDataProvider dataProvider = new UiDataProvider(new PersonService());
			foreach (Person person in dataProvider.GetPeople())
			{
				System.Console.WriteLine(person.FirstName + " " + person.LastName + " Last Updated: " + person.LastUpdate + " EntityId: " + person.EntityId );
			}
		}
		public static void TestAddPerson()
		{
			Person addPerson = new Person
			{
				FirstName = "Brett",
				LastName = "Osborn",
				MiddleName = "Philip",
				PersonType = new PersonType()
				{
					Id = 1,
					Name = "Individual"
				}
			};

			//IPersonService dataService = new PersonService();
			//addPerson = dataService.NewPerson(addPerson);
			IUiDataProvider dataProvider = new UiDataProvider(new PersonService());
			addPerson = dataProvider.NewPerson(addPerson);

			System.Console.WriteLine(addPerson.EntityId);
		}
		static void Main(string[] args)
		{
			//TestAddPerson();
			TestGetPeople();
			System.Console.ReadLine();
		}


	}
}

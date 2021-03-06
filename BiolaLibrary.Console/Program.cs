﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiolaLibrary.Application;
using BiolaLibrary.Model;
using BiolaLibrary.SqlServerDatabaseMapper;
using IDCharacteristic = BiolaLibrary.Model.IDCharacteristic;
using Person = BiolaLibrary.Model.Person;
using PersonType = BiolaLibrary.Model.PersonType;

namespace BiolaLibrary.Console
{
	class Program
	{
		public static void TestUpdatePerson()
		{
			IUiDataProvider dataProvider = new UiDataProvider(new PersonService());
			Person person = dataProvider.GetPerson(1);

			person.FormsOfId.Add(new Model.PersonalID()
			{
				Type = new Model.IDType() { Id = 9 },
				Value = "1454718",
				Characteristics = new ObservableCollection<IDCharacteristic>()
				{
					new IDCharacteristic()
					{
						Type = new Model.IDCharacteristicType()
						{
							Id = 3
						},
						Value = "USMC"
					}
				}
			});
			dataProvider.UpdatePerson(person);

			System.Console.WriteLine(person.FirstName + " " + person.LastName + " Last Updated: " + person.LastUpdate + " EntityId: " + person.EntityId);
			System.Console.WriteLine("|Forms Of Id:");
			foreach (Model.PersonalID personalId in person.FormsOfId)
			{
				System.Console.WriteLine("|| Personal Id: " + personalId.Id + "     Id Type: " + personalId.Type.Id + " - " + personalId.Type.Name + "    Id Value: " + personalId.Value + "    Last Update: " + personalId.LastUpdate);
				foreach (Model.IDCharacteristic personalIdCharacteristic in personalId.Characteristics)
				{
					System.Console.WriteLine("||| ID Characteristic: " + personalIdCharacteristic.Id + "    Characteristic Type: " + personalIdCharacteristic.Type.Id + "-" + personalIdCharacteristic.Type.Name + "    Characteristic Value: " + personalIdCharacteristic.Value + "    Last Update: " + personalIdCharacteristic.LastUpdate);
				}
			}

		}

		public static void GetPerson()
		{
			//11

			IUiDataProvider dataProvider = new UiDataProvider(new PersonService());
			Person person = dataProvider.GetPerson(1);
			System.Console.WriteLine(person.FirstName + " " + person.LastName + " Last Updated: " + person.LastUpdate + " EntityId: " + person.EntityId);
			System.Console.WriteLine("|Forms Of Id:");
			foreach (Model.PersonalID personalId in person.FormsOfId)
			{
				System.Console.WriteLine("|| Personal Id: " + personalId.Id + "     Id Type: " + personalId.Type.Id + " - " + personalId.Type.Name + "    Id Value: " + personalId.Value + "    Last Update: " + personalId.LastUpdate);
				foreach (Model.IDCharacteristic personalIdCharacteristic in personalId.Characteristics)
				{
					System.Console.WriteLine("||| ID Characteristic: " + personalIdCharacteristic.Id + "    Characteristic Type: " + personalIdCharacteristic.Type.Id + "-" + personalIdCharacteristic.Type.Name + "    Characteristic Value: " + personalIdCharacteristic.Value + "    Last Update: " + personalIdCharacteristic.LastUpdate);
				}
			}

			System.Console.WriteLine(); System.Console.WriteLine();
			System.Console.WriteLine("|Email Addresses:");
			foreach (Model.EmailAddress emailAddress in person.EmailAddresses)
			{
				System.Console.WriteLine("|| Email Address Id: " + emailAddress.Id + "    Email Type: " + emailAddress.EmailType.Id + "-" + emailAddress.EmailType.Name + "    Email Address: " + emailAddress.Address + "    Primary: " + emailAddress.Primary + "    Last Update: " + emailAddress.LastUpdate);
			}

		}

		public static void TestGetPeople()
		{
			IUiDataProvider dataProvider = new UiDataProvider(new PersonService());
			foreach (Person person in dataProvider.GetPeople())
			{
				System.Console.WriteLine(person.FirstName + " " + person.LastName + " Last Updated: " + person.LastUpdate + " EntityId: " + person.EntityId);
			}
		}
		public static void TestAddPerson()
		{
			Person addPerson = new Person
			{
				FirstName = "Larissa",
				LastName = "Osborn",
				MiddleName = "Ann",
				PersonType = new PersonType()
				{
					Id = 2,
					Name = "Individual"
				}
			};

			//IPersonService dataService = new PersonService();
			//addPerson = dataService.NewPerson(addPerson);
			IUiDataProvider dataProvider = new UiDataProvider(new PersonService());
			addPerson = dataProvider.NewPerson(addPerson);
			addPerson.EmailAddresses.Add(new Model.EmailAddress() {
				Address = "larissa.a.osborn@gmail.com",
				EmailType = new Model.EmailType(){Id = 1,Name = "Personal"},
				Primary = true
			});

			addPerson.PhoneNumbers.Add(new Model.PhoneNumber()
			{
				Number = "425.283.7469",
				Primary = true,
				PhoneType = new Model.PhoneType()
				{
					Id = 1,
					Name = "Cell"
				}
			});

			addPerson.FormsOfId.Add(new Model.PersonalID()
			{
				Type = new Model.IDType() { Id = 9 },
				Value = "1454718",
				Characteristics = new ObservableCollection<IDCharacteristic>()
				{
					new IDCharacteristic()
					{
						Type = new Model.IDCharacteristicType()
						{
							Id = 5
						},
						Value = "Staff ID"
					}
				}
			});
			//[1/28/2018 20:51] camerono: Left off here
			//addPerson.Addresses.Add(new Model.EntityAddress()
			//{
			//	Name = "Mailing Address",
			//	AddressType = new Model.AddressType() { Id=3,Name="Home"},
			//	Address = new Model.Address() {Line1 = "1900 Brookdale Ave", City = "La Habra", StateProvince = new Model.StateProvince() { } }
			//});
			System.Console.WriteLine(addPerson.EntityId);
		}

		public static void TestDeletePerson()
		{
			IUiDataProvider dataProvider = new UiDataProvider(new PersonService());
			dataProvider.DeletePersonById(2);
		}

		static void Main(string[] args)
		{
			//TestAddPerson();
			//TestGetPeople();
			//TestUpdatePerson();
			//GetPerson();
			//TestDeletePerson();
			System.Console.ReadLine();
		}


	}
}

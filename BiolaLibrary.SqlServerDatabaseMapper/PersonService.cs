using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using BiolaLibrary.Data;
using System;
using System.Data;
using System.Reflection;
using System.Runtime.InteropServices;

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
			Data.Person foundPersonEntity = _libraryPublicServicesEntities.People.Single(p => p.EntityId == personId);
			return new Person()
			{
				EntityId = foundPersonEntity.EntityId,
				FirstName = foundPersonEntity.FirstName,
				MiddleName = foundPersonEntity.MiddleName,
				LastName = foundPersonEntity.LastName,
				Title = foundPersonEntity.Title,
				Suffix = foundPersonEntity.Suffix,
				LastUpdate = foundPersonEntity.ModifiedDate,
				PersonType = GetPersontype(foundPersonEntity.PersonType1),
				FormsOfID = GetFormsOfId(foundPersonEntity.EntityId),
				PhoneNumbers = GetPhoneNumbers(foundPersonEntity.EntityId),
				EmailAddresses = GetEmailAddresses(foundPersonEntity.EntityId),
				EntityAddresses = GetEntityAddresses(foundPersonEntity.EntityId),
				Properties = GetPersonalProperties(foundPersonEntity.EntityId)
			};
		}

		private PersonType GetPersontype(Data.PersonType personType)
		{
			return new PersonType()
			{
				Id = personType.PersonTypeId,
				Name = personType.Name
			};
		}

		private IEnumerable<PersonalID> GetFormsOfId(int entityId)
		{
			List<Data.EntityIdentification> formsOfId = _libraryPublicServicesEntities.EntityIdentifications
				.Where(fOI => fOI.EntityId == entityId).ToList();

			return formsOfId.Select(id => new PersonalID()
			{
				Id = id.EntityIdentificationId,
				Value = id.IDValue,
				LastUpdate = id.ModifiedDate,
				IDType = GetIDTypeFromDatabase(id.IDType),
				Characteristics = GetIdCharacteristicsFromDatabase(id.IDCharacteristics)
			}).ToList();
		}

		private IDType GetIDTypeFromDatabase(int entityIDType)
		{
			Data.EntityIDType idType = _libraryPublicServicesEntities.EntityIDTypes.Single(t => t.TypeId == entityIDType);
			return new IDType()
			{
				Id = idType.TypeId,
				Name = idType.Name,
				PrefixChar = idType.Prefix
			};
		}

		private IEnumerable<IDCharacteristic> GetIdCharacteristicsFromDatabase(ICollection<Data.IDCharacteristic> iDCharacteristics)
		{
			if (iDCharacteristics == null)
				return new List<IDCharacteristic>();

			return iDCharacteristics.Select(c => new IDCharacteristic()
			{
				Id = c.CharacteristicId,
				Type = GetIdCharacteristicTypeFromDatabase(c.IDCharacteristicType),
				Value = c.Value,
				LastUpdate = c.ModifiedDate
			}).ToList();
		}

		private IDCharacteristicType GetIdCharacteristicTypeFromDatabase(Data.IDCharacteristicType iDCharacteristicType)
		{
			return new IDCharacteristicType()
			{
				Id = iDCharacteristicType.TypeId,
				Name = iDCharacteristicType.Name
			};
		}

		private IEnumerable<PhoneNumber> GetPhoneNumbers(int entityId)
		{
			List<Data.PhoneNumber> phoneNumbers = _libraryPublicServicesEntities.PhoneNumbers.Where(p => p.EntityId == entityId)
				.ToList();
			return phoneNumbers.Select(n => new PhoneNumber()
			{
				Id = n.PhoneId,
				PhoneType = GetPhoneTypeFromDatabase(n.PhoneType),
				Number = n.PhoneNumber1,
				Primary = n.Primary != null && (bool)n.Primary,
				LastUpdate = n.ModifiedDate
			});
		}

		private PhoneType GetPhoneTypeFromDatabase(Data.PhoneType phoneType)
		{
			return new PhoneType()
			{
				Id = phoneType.PhoneTypeId,
				Name = phoneType.Name
			};
		}

		private IEnumerable<EmailAddress> GetEmailAddresses(int entityId)
		{
			List<Data.EmailAddress> emailAddresses = _libraryPublicServicesEntities.EmailAddresses
				.Where(e => e.EntityId == entityId).ToList();
			return emailAddresses.Select(a =>

				 new EmailAddress()
				 {
					 Id = a.EmailId,
					 EmailType = GetEmailTypeFromDatabase(a.EmailType),
					 Address = a.EmailAddress1,
					 Primary = a.Primary != null && (bool)a.Primary,
					 LastUpdate = a.ModifiedDate
				 }
			);
		}

		private EmailType GetEmailTypeFromDatabase(Data.EmailType emailType)
		{
			return new EmailType()
			{
				Id = emailType.EmailTypeId,
				Name = emailType.Name
			};
		}

		private IEnumerable<EntityAddress> GetEntityAddresses(int entityId)
		{
			List<Data.EntityAddress> addresses = _libraryPublicServicesEntities.EntityAddresses
				.Where(ea => ea.EntityId == entityId).ToList();
			return addresses.Select(a => new EntityAddress()
			{
				AddressId = a.AddressId,
				Name = a.Name,
				LastUpdate = a.ModifiedDate,
				Address = GetAddressFromDatabase(a.Address),
				AddressType = GetAddressTypeFromDatabase(a.AddressType)
			});
		}

		private Address GetAddressFromDatabase(Data.Address address)
		{
			return new Address()
			{
				Id = address.AddressId,
				Line1 = address.AddressLine1,
				Line2 = address.AddressLine2,
				City = address.City,
				StateProvince = GetStateProvinceFromDatabase(address.StateProvince),
				PostalCode = address.PostalCode,
				SpatialLocation = address.SpatialLocation,
				LastUpdate = address.ModifiedDate
			};
		}

		private StateProvince GetStateProvinceFromDatabase(Data.StateProvince stateProvince)
		{
			return new StateProvince()
			{
				Id = stateProvince.StateProvinceId,
				Name = stateProvince.Name,
				StateProvinceCode = stateProvince.StateProvinceCode,
				CountryRegion = GetCountryRegionInfoFromDatabase(stateProvince.CountryRegion)
			};
		}

		private CountryRegion GetCountryRegionInfoFromDatabase(Data.CountryRegion countryRegion)
		{
			return new CountryRegion()
			{
				Name = countryRegion.Name,
				CountryRegionCode = countryRegion.CountryRegionCode
			};
		}

		private AddressType GetAddressTypeFromDatabase(Data.AddressType addressType)
		{
			return new AddressType()
			{
				Id = addressType.AddressTypeId,
				Name = addressType.Name
			};
		}

		private IEnumerable<PersonalProperty> GetPersonalProperties(int entityId)
		{
			List<Data.Property> properties =
				_libraryPublicServicesEntities.Properties.Where(i => i.EntityId == entityId).ToList();
			return properties.Select(p => new PersonalProperty()
			{
				Id = p.PropertyId,
				Value = p.Value,
				LastUpdate = p.ModifiedDate,
				Type = GetPropertyTypeFromDatabase(p.PropertyType)
			});

		}

		private PropertyType GetPropertyTypeFromDatabase(Data.PropertyType propertyType)
		{
			return new PropertyType()
			{
				Id = propertyType.TypeId,
				Name = propertyType.Name
			};
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
					.Add(new Entity { ModifiedDate = DateTime.Now, rowguid = Guid.NewGuid() }).EntityId
			};

			//[10/26/2017 18:07] camerono: Add new person to the database and save changes
			_libraryPublicServicesEntities.People.Add(newPersonEntity);
			_libraryPublicServicesEntities.SaveChanges();

			//[10/26/2017 18:07] camerono: Pass Updated person back through mapper class to model
			person.EntityId = newPersonEntity.EntityId;
			person.LastUpdate = newPersonEntity.ModifiedDate;
			return person;
		}



		public Person Update(Person person)
		{
			bool databaseUpdated = false;
			Data.Person updatePersonEntity = _libraryPublicServicesEntities.People.Single(p => p.EntityId == person.EntityId);
			if (updatePersonEntity == null)
				return NewPerson(person);


			//Update Literal Values
			if (updatePersonEntity.FirstName != person.FirstName)
			{
				updatePersonEntity.FirstName = person.FirstName;
				databaseUpdated = true;
			}
			if (updatePersonEntity.MiddleName != person.MiddleName)
			{
				updatePersonEntity.MiddleName = person.MiddleName;
				databaseUpdated = true;
			}
			if (updatePersonEntity.LastName != person.LastName)
			{
				updatePersonEntity.LastName = person.LastName;
				databaseUpdated = true;
			}
			if (updatePersonEntity.Title != person.Title)
			{
				updatePersonEntity.Title = person.Title;
				databaseUpdated = true;
			}
			if (updatePersonEntity.Suffix != person.Suffix)
			{
				updatePersonEntity.Suffix = person.Suffix;
				databaseUpdated = true;
			}
			if (updatePersonEntity.PersonType != person.PersonType.Id)
			{
				updatePersonEntity.PersonType = person.PersonType.Id;
				databaseUpdated = true;
			}

			//Update Collection Contents
			//		FormsOfId
			if (person.FormsOfID != null)
			{
				if (UpdateFormsOfId(person))
					databaseUpdated = true;
			}

			//		PhoneNumbers
			if (person.PhoneNumbers != null)
			{
				if (UpdatePhoneNumbers(person))
					databaseUpdated = true;
			}

			//		EmailAddress
			if (person.EmailAddresses != null)
			{
				if (UpdateEmailAddresses(person))
					databaseUpdated = true;
			}

			//		Addresses
			if (person.EntityAddresses != null)
			{
				if (UpdateEntityAddresses(person))
					databaseUpdated = true;
			}

			//		Properties
			if (person.Properties != null)
			{
				if (UpdateProperties(person))
					databaseUpdated = true;
			}



			if (databaseUpdated)
			{
				updatePersonEntity.ModifiedDate = DateTime.Now;

				_libraryPublicServicesEntities.SaveChanges();

				//Update the return objects "Last Update" property -- IS THIS NECERSSARY? I dont think so. It will pull on the GetPerson return
				//person.LastUpdate = updatePersonEntity.ModifiedDate;
			}



			return GetPerson(person.EntityId);
		}


		private bool UpdateFormsOfId(Person person)
		{
			bool databaseUpdated = false;
			foreach (PersonalID personalId in person.FormsOfID)
			{
				bool newId = false;
				Data.EntityIdentification updateId;

				//[1/25/2018 15:08] camerono: If this is a brand new ID
				if (personalId.Id < 1)
				{
					updateId = new EntityIdentification()
					{
						//EntityIDType = new EntityIDType(),
						rowguid = Guid.NewGuid()
					};
					databaseUpdated = true;
					newId = true;
				}
				else
				{
					updateId =
						_libraryPublicServicesEntities.EntityIdentifications.Single(
							i => i.EntityIdentificationId == personalId.Id);
				}


				if (updateId.EntityId != person.EntityId)
				{
					updateId.EntityId = person.EntityId;
					updateId.ModifiedDate = DateTime.Now;
					personalId.LastUpdate = updateId.ModifiedDate;
					databaseUpdated = true;
				}

				if (updateId.IDType != personalId.IDType.Id)
				{
					//updateId.EntityIDType.TypeId = personalId.IDType.Id;
					updateId.IDType = personalId.IDType.Id;
					updateId.ModifiedDate = DateTime.Now;
					personalId.LastUpdate = updateId.ModifiedDate;
					databaseUpdated = true;
				}

				if (updateId.IDValue != personalId.Value)
				{
					updateId.IDValue = personalId.Value;
					updateId.ModifiedDate = DateTime.Now;
					personalId.LastUpdate = updateId.ModifiedDate;
					databaseUpdated = true;
				}
				if (personalId.Characteristics != null)
					if (UpdateIdCharacteristics(personalId))
						databaseUpdated = true;

				if (newId)
				{
					_libraryPublicServicesEntities.EntityIdentifications.Add(updateId);
				}
			}
			return databaseUpdated;
		}

		private bool UpdateIdCharacteristics(PersonalID personalId)
		{
			bool databaseUpdated = false;
			foreach (IDCharacteristic idCharacteristic in personalId.Characteristics)
			{
				bool newCharacteristic = false;
				Data.IDCharacteristic updateCharacteristic;
				if (idCharacteristic.Id < 1)
				{
					updateCharacteristic = new Data.IDCharacteristic()
					{
						rowguid = Guid.NewGuid()
					};
					databaseUpdated = true;
					newCharacteristic = true;
				}
				else
				{
					updateCharacteristic =
						_libraryPublicServicesEntities.IDCharacteristics.Single(c => c.CharacteristicId == idCharacteristic.Id);
				}


				if (updateCharacteristic.EntityIdentificationId != personalId.Id)
				{
					updateCharacteristic.EntityIdentificationId = personalId.Id;
					updateCharacteristic.ModifiedDate = DateTime.Now;
					idCharacteristic.LastUpdate = updateCharacteristic.ModifiedDate;
					databaseUpdated = true;
				}

				if (updateCharacteristic.CharacteristicTypeId != idCharacteristic.Type.Id)
				{
					updateCharacteristic.CharacteristicTypeId = idCharacteristic.Type.Id;
					updateCharacteristic.ModifiedDate = DateTime.Now;
					idCharacteristic.LastUpdate = updateCharacteristic.ModifiedDate;
					databaseUpdated = true;
				}

				if (updateCharacteristic.Value != idCharacteristic.Value)
				{
					updateCharacteristic.Value = idCharacteristic.Value;
					updateCharacteristic.ModifiedDate = DateTime.Now;
					personalId.LastUpdate = updateCharacteristic.ModifiedDate;
					databaseUpdated = true;
				}

				if (newCharacteristic)
					_libraryPublicServicesEntities.IDCharacteristics.Add(updateCharacteristic);

			}

			return databaseUpdated;
		}

		private bool UpdatePhoneNumbers(Person person)
		{
			bool databaseUpdated = false;

			foreach (PhoneNumber personPhoneNumber in person.PhoneNumbers)
			{
				bool newNumber = false;
				Data.PhoneNumber updateNumber;
				if (personPhoneNumber.Id < 1)
				{
					updateNumber = new Data.PhoneNumber()
					{
						rowguid = Guid.NewGuid()
					};
					databaseUpdated = true;
					newNumber = true;
				}
				else
				{
					updateNumber = _libraryPublicServicesEntities.PhoneNumbers.Single(p => p.PhoneId == personPhoneNumber.Id);
				}

				if (updateNumber.EntityId != person.EntityId)
				{
					updateNumber.EntityId = person.EntityId;
					updateNumber.ModifiedDate = DateTime.Now;
					personPhoneNumber.LastUpdate = updateNumber.ModifiedDate;
					databaseUpdated = true;
				}

				if (updateNumber.PhoneTypeId != personPhoneNumber.PhoneType.Id)
				{
					updateNumber.PhoneTypeId = personPhoneNumber.PhoneType.Id;
					updateNumber.ModifiedDate = DateTime.Now;
					personPhoneNumber.LastUpdate = updateNumber.ModifiedDate;
					databaseUpdated = true;
				}

				if (updateNumber.PhoneNumber1 != personPhoneNumber.Number)
				{
					updateNumber.PhoneNumber1 = personPhoneNumber.Number;
					updateNumber.ModifiedDate = DateTime.Now;
					personPhoneNumber.LastUpdate = updateNumber.ModifiedDate;
					databaseUpdated = true;
				}

				if (updateNumber.Primary != personPhoneNumber.Primary)
				{
					updateNumber.Primary = personPhoneNumber.Primary;
					updateNumber.ModifiedDate = DateTime.Now;
					personPhoneNumber.LastUpdate = updateNumber.ModifiedDate;
					databaseUpdated = true;
				}

				if (newNumber)
					_libraryPublicServicesEntities.PhoneNumbers.Add(updateNumber);
			}
			

			return databaseUpdated;
		}

		private bool UpdateEmailAddresses(Person person)
		{
			bool databaseUpdated = false;

			foreach (EmailAddress personEmailAddress in person.EmailAddresses)
			{
				bool newEmail = false;
				Data.EmailAddress updateEmail;
				if (personEmailAddress.Id < 1)
				{
					updateEmail = new Data.EmailAddress()
					{
						rowguid = Guid.NewGuid()
					};
					databaseUpdated = true;
					newEmail = true;
				}
				else
				{
					updateEmail = _libraryPublicServicesEntities.EmailAddresses.Single(e => e.EmailId == personEmailAddress.Id);
				}

				if (updateEmail.EntityId != person.EntityId)
				{
					updateEmail.EntityId = person.EntityId;
					updateEmail.ModifiedDate = DateTime.Now;
					personEmailAddress.LastUpdate = updateEmail.ModifiedDate;
					databaseUpdated = true;
				}

				if (updateEmail.EmailTypeId != personEmailAddress.EmailType.Id)
				{
					updateEmail.EmailTypeId = personEmailAddress.EmailType.Id;
					updateEmail.ModifiedDate = DateTime.Now;
					personEmailAddress.LastUpdate = updateEmail.ModifiedDate;
					databaseUpdated = true;
				}

				if (updateEmail.EmailAddress1 != personEmailAddress.Address)
				{
					updateEmail.EmailAddress1 = personEmailAddress.Address;
					updateEmail.ModifiedDate = DateTime.Now;
					personEmailAddress.LastUpdate = updateEmail.ModifiedDate;
					databaseUpdated = true;
				}

				if (updateEmail.Primary != personEmailAddress.Primary)
				{
					updateEmail.Primary = personEmailAddress.Primary;
					updateEmail.ModifiedDate = DateTime.Now;
					personEmailAddress.LastUpdate = updateEmail.ModifiedDate;
					databaseUpdated = true;
				}

				if (newEmail)
					_libraryPublicServicesEntities.EmailAddresses.Add(updateEmail);

			}

			return databaseUpdated;
		}

		private bool UpdateEntityAddresses(Person person)
		{
			bool databaseUpdated = false;


			foreach (EntityAddress personEntityAddress in person.EntityAddresses)
			{
				bool newAddress = false;
				Data.EntityAddress updateAddress;
				if (personEntityAddress.AddressId < 1)
				{
					updateAddress = new Data.EntityAddress() {rowguid = Guid.NewGuid(),EntityId = person.EntityId,AddressTypeId = personEntityAddress.AddressType.Id};
					databaseUpdated = true;
					newAddress = true;

				}
				else
				{
					updateAddress =
						_libraryPublicServicesEntities.EntityAddresses.Single(a => a.AddressId == personEntityAddress.AddressId && a.EntityId == person.EntityId && a.AddressTypeId == personEntityAddress.AddressType.Id);
				}

				//if (updateAddress.EntityId != person.EntityId)
				//{
				//	updateAddress.EntityId = person.EntityId;
				//	updateAddress.ModifiedDate = DateTime.Now;
				//	personEntityAddress.LastUpdate = updateAddress.ModifiedDate;
				//	databaseUpdated = true;
				//}

				if (updateAddress.Name != personEntityAddress.Name)
				{
					updateAddress.Name = personEntityAddress.Name;
					updateAddress.ModifiedDate = DateTime.Now;
					personEntityAddress.LastUpdate = updateAddress.ModifiedDate;
					databaseUpdated = true;
				}

				if (updateAddress.Address.AddressLine1 != personEntityAddress.Address.Line1)
				{
					updateAddress.Address.AddressLine1 = personEntityAddress.Address.Line1;
					updateAddress.Address.ModifiedDate = DateTime.Now;
					personEntityAddress.Address.LastUpdate = updateAddress.Address.ModifiedDate;
					databaseUpdated = true;
				}

				if (updateAddress.Address.AddressLine2 != personEntityAddress.Address.Line2)
				{
					updateAddress.Address.AddressLine2 = personEntityAddress.Address.Line2;
					updateAddress.Address.ModifiedDate = DateTime.Now;
					personEntityAddress.Address.LastUpdate = updateAddress.Address.ModifiedDate;
					databaseUpdated = true;
				}

				if (updateAddress.Address.City != personEntityAddress.Address.City)
				{
					updateAddress.Address.City = personEntityAddress.Address.City;
					updateAddress.Address.ModifiedDate = DateTime.Now;
					personEntityAddress.Address.LastUpdate = updateAddress.Address.ModifiedDate;
					databaseUpdated = true;
				}

				if (updateAddress.Address.StateProvinceId != personEntityAddress.Address.StateProvince.Id)
				{
					updateAddress.Address.StateProvinceId = personEntityAddress.Address.StateProvince.Id;
					updateAddress.Address.ModifiedDate = DateTime.Now;
					personEntityAddress.Address.LastUpdate = updateAddress.Address.ModifiedDate;
					databaseUpdated = true;
				}

				if (updateAddress.Address.PostalCode != personEntityAddress.Address.PostalCode)
				{
					updateAddress.Address.PostalCode = personEntityAddress.Address.PostalCode;
					updateAddress.Address.ModifiedDate = DateTime.Now;
					personEntityAddress.Address.LastUpdate = updateAddress.Address.ModifiedDate;
					databaseUpdated = true;
				}

				if (updateAddress.Address.SpatialLocation != personEntityAddress.Address.SpatialLocation)
				{
					updateAddress.Address.SpatialLocation = personEntityAddress.Address.SpatialLocation;
					updateAddress.Address.ModifiedDate = DateTime.Now;
					personEntityAddress.Address.LastUpdate = updateAddress.Address.ModifiedDate;
					databaseUpdated = true;
				}

				
				if (newAddress)
					_libraryPublicServicesEntities.EntityAddresses.Add(updateAddress);

			}

			return databaseUpdated;
		}

		

		private bool UpdateProperties(Person person)
		{
			bool databaseUpdated = false;
			foreach (PersonalProperty personalProperty in person.Properties)
			{
				bool newProperty = false;
				Data.Property updateProperty;

				//[1/25/2018 15:32] camerono: Check if this is a new property
				if (personalProperty.Id < 1)
				{
					updateProperty = new Data.Property()
					{
						rowguid = Guid.NewGuid()
					};
					databaseUpdated = true;
					newProperty = true;
				}
				else
				{
					updateProperty = _libraryPublicServicesEntities.Properties.Single(p => p.PropertyId == personalProperty.Id);
				}

				if (updateProperty.EntityId != person.EntityId)
				{
					updateProperty.EntityId = person.EntityId;
					updateProperty.ModifiedDate = DateTime.Now;
					personalProperty.LastUpdate = updateProperty.ModifiedDate;
					databaseUpdated = true;
				}

				if (updateProperty.TypeId != personalProperty.Type.Id)
				{
					updateProperty.TypeId = personalProperty.Type.Id;
					updateProperty.ModifiedDate = DateTime.Now;
					personalProperty.LastUpdate = updateProperty.ModifiedDate;
					databaseUpdated = true;
				}

				if (updateProperty.Value != personalProperty.Value)
				{
					updateProperty.Value = personalProperty.Value;
					updateProperty.ModifiedDate = DateTime.Now;
					personalProperty.LastUpdate = updateProperty.ModifiedDate;
					databaseUpdated = true;
				}

				if (newProperty)
					_libraryPublicServicesEntities.Properties.Add(updateProperty);

			}

			return databaseUpdated;
		}


	}
}
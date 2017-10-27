using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using BiolaLibrary.Model;
using Person = BiolaLibrary.SqlServerDatabaseMapper.Person;
using Service = BiolaLibrary.SqlServerDatabaseMapper.PersonService;
using BiolaLibrary.SqlServerDatabaseMapper;
using System;
using EmailAddress = BiolaLibrary.Model.EmailAddress;
using EntityAddress = BiolaLibrary.Model.EntityAddress;
using IDCharacteristic = BiolaLibrary.Model.IDCharacteristic;
using PersonalID = BiolaLibrary.Model.PersonalID;
using PersonalProperty = BiolaLibrary.Model.PersonalProperty;
using PhoneNumber = BiolaLibrary.Model.PhoneNumber;

namespace BiolaLibrary.Application
{
	public class PersonTranslator : IEntityTranslator<Model.Person, Person>
	{
		internal static IEntityTranslator<Model.Person, Person> _instance;

		public static IEntityTranslator<Model.Person, Person> Instance => _instance ?? (_instance = new PersonTranslator());

		public Model.Person CreateModel(Person dto)
		{
			return UpdateModel(new Model.Person(), dto);
		}

		public Model.Person UpdateModel(Model.Person model, Person dto)
		{
			//literal value loading
			if (model.EntityId != dto.EntityId)
				model.EntityId = dto.EntityId;
			if (model.FirstName != dto.FirstName)
				model.FirstName = dto.FirstName;
			if (model.MiddleName != dto.MiddleName)
				model.MiddleName = dto.MiddleName;
			if (model.LastName != dto.LastName)
				model.LastName = dto.LastName;
			if (model.Title != dto.Title)
				model.Title = dto.Title;
			if (model.Suffix != dto.Suffix)
				model.Suffix = dto.Suffix;
			if (model.LastUpdate != dto.LastUpdate)
				model.LastUpdate = dto.LastUpdate;

			//Subclass loading
			if (dto.PersonType != null)
			{
				model.PersonType = GetPersonTypeFromDto(dto);
			}
			if (dto.FormsOfID != null)
			{
				model.FormsOfId = GetFormsOfIdFromDto(dto);
			}
			if (dto.PhoneNumbers != null)
			{
				model.PhoneNumbers = GetPhoneNumbersFromDto(dto);
			}
			if (dto.EmailAddresses != null)
			{
				model.EmailAddresses = GetEmailAddressesFromDto(dto);
			}
			if (dto.EntityAddresses != null)
			{
				model.Addresses = GetEntityAddressesFromDto(dto);
			}
			if (dto.Properties != null)
			{
				model.Properties = GetPropretiesFromDto(dto);
			}

			return model;
		}

		private Model.PersonType GetPersonTypeFromDto(Person dto)
		{
			return new Model.PersonType()
			{
				Id = dto.PersonType.Id,
				Name = dto.PersonType.Name
			};
		}

		private ObservableCollection<Model.PersonalProperty> GetPropretiesFromDto(Person dto)
		{
			IEnumerable<Model.PersonalProperty> properties = dto.Properties.Select(p => new Model.PersonalProperty
			{
				Id = p.Id,
				LastUpdate = p.LastUpdate,
				Value = p.Value,
				Type = GetPropertyTypeFromDto(p)
			});
			return new ObservableCollection<PersonalProperty>(properties);
		}

		private Model.PropertyType GetPropertyTypeFromDto(SqlServerDatabaseMapper.PersonalProperty p)
		{
			return new Model.PropertyType()
			{
				Id = p.Type.Id,
				Name = p.Type.Name
			};
		}

		private ObservableCollection<Model.EntityAddress> GetEntityAddressesFromDto(Person dto)
		{
			IEnumerable<Model.EntityAddress> entityAddresses = dto.EntityAddresses.Select(ea => new Model.EntityAddress()
			{
				AddressId = ea.AddressId,
				Name = ea.Name,
				LastUpdate = ea.LastUpdate,
				Address = GetAddressFromDto(ea.Address),
				AddressType = GetAddressTypeFromDto(ea.AddressType)
			});
			return new ObservableCollection<EntityAddress>(entityAddresses);
		}

		private Model.AddressType GetAddressTypeFromDto(SqlServerDatabaseMapper.AddressType t)
		{
			return new Model.AddressType()
			{
				Id = t.Id,
				Name = t.Name
			};
		}

		private Model.Address GetAddressFromDto(SqlServerDatabaseMapper.Address a)
		{
			return new Model.Address()
			{
				Id = a.Id,
				Line1 = a.Line1,
				Line2 = a.Line2,
				City = a.City,
				StateProvince = GetStateProvinceFromDto(a.StateProvince),
				PostalCode = a.PostalCode,
				SpatialLocation = a.SpatialLocation,
				LastUpdate = a.LastUpdate
			};
		}

		private Model.StateProvince GetStateProvinceFromDto(SqlServerDatabaseMapper.StateProvince stateProvince)
		{
			return new Model.StateProvince()
			{
				Id = stateProvince.Id,
				Name = stateProvince.Name,
				StateProvinceCode = stateProvince.StateProvinceCode,
				CountryRegion = GetCountryRegionDataFromDto(stateProvince.CountryRegion)
			};
		}

		private Model.CountryRegion GetCountryRegionDataFromDto(SqlServerDatabaseMapper.CountryRegion countryRegion)
		{
			return new Model.CountryRegion()
			{
				CountryRegionCode = countryRegion.CountryRegionCode,
				Name = countryRegion.Name
			};
		}

		private ObservableCollection<Model.EmailAddress> GetEmailAddressesFromDto(Person dto)
		{
			IEnumerable<Model.EmailAddress> emailAddresses = dto.EmailAddresses.Select(e => new Model.EmailAddress()
			{
				Id = e.Id,
				Address = e.Address,
				LastUpdate = e.LastUpdate,
				Primary = e.Primary,
				EmailType = GetEmailTypeFromDto(e)

			});
			return new ObservableCollection<EmailAddress>(emailAddresses);
		}

		private Model.EmailType GetEmailTypeFromDto(SqlServerDatabaseMapper.EmailAddress e)
		{
			return new Model.EmailType()
			{
				Id = e.EmailType.Id,
				Name = e.EmailType.Name
			};
		}

		private ObservableCollection<Model.PhoneNumber> GetPhoneNumbersFromDto(Person dto)
		{
			IEnumerable<Model.PhoneNumber> phoneNumbers = dto.PhoneNumbers.Select(p => new Model.PhoneNumber()
			{
				Id = p.Id,
				Number = p.Number,
				LastUpdate = p.LastUpdate,
				Primary = p.Primary,
				PhoneType = GetPhoneTypeFromDto(p)
			});
			return new ObservableCollection<PhoneNumber>(phoneNumbers);
		}

		private Model.PhoneType GetPhoneTypeFromDto(SqlServerDatabaseMapper.PhoneNumber p)
		{
			return new Model.PhoneType
			{
				Id = p.PhoneType.Id,
				Name = p.PhoneType.Name
			};
		}

		private ObservableCollection<Model.PersonalID> GetFormsOfIdFromDto(Person dto)
		{
			IEnumerable<Model.PersonalID> formsOfId = dto.FormsOfID.Select(i => new Model.PersonalID()
			{
				Id = i.Id,
				Value = i.Value,
				LastUpdate = i.LastUpdate,
				Type = GetIdTypeFromDto(i),
				Characteristics = GetIdCharacteristicsFromDto(i)
			});
			return new ObservableCollection<PersonalID>(formsOfId);
		}

		private ObservableCollection<Model.IDCharacteristic> GetIdCharacteristicsFromDto(SqlServerDatabaseMapper.PersonalID i)
		{
			IEnumerable<Model.IDCharacteristic> idCharacteristics = i.Characteristics.Select(c => new Model.IDCharacteristic()
			{
				Id = c.Id,
				Value = c.Value,
				LastUpdate = c.LastUpdate,
				Type = GetIdCharacteristicTypeFromDto(c)
			});
			return new ObservableCollection<IDCharacteristic>(idCharacteristics);
		}

		private Model.IDCharacteristicType GetIdCharacteristicTypeFromDto(SqlServerDatabaseMapper.IDCharacteristic c)
		{
			return new Model.IDCharacteristicType()
			{
				Id = c.Type.Id,
				Name = c.Type.Name
			};
		}

		private Model.IDType GetIdTypeFromDto(SqlServerDatabaseMapper.PersonalID i)
		{
			return new Model.IDType
			{
				Id = i.IDType.Id,
				Name = i.IDType.Name,
				PrefixChar = i.IDType.PrefixChar
			};
		}

		public Person CreateDto(Model.Person model)
		{
			return UpdateDto(new Person(), model);
		}

		public Person UpdateDto(Person dto, Model.Person model)
		{
			if (model.EntityId != dto.EntityId)
				dto.EntityId = model.EntityId;
			if (model.FirstName != dto.FirstName)
				dto.FirstName = model.FirstName;
			if (model.MiddleName != dto.MiddleName)
				dto.MiddleName = model.MiddleName;
			if (model.LastName != dto.LastName)
				dto.LastName = model.LastName;
			if (model.Title != dto.Title)
				dto.Title = model.Title;
			if (model.Suffix != dto.Suffix)
				dto.Suffix = model.Suffix;
			if (model.LastUpdate != dto.LastUpdate)
				dto.LastUpdate = model.LastUpdate;
			if (model.PersonType != null)
			{
				dto.PersonType = GetPersonTypeFromModel(model.PersonType);
			}
			if (model.FormsOfId != null)
			{
				dto.FormsOfID = GetFormsOfIdFromModel(model.FormsOfId);
			}
			if (model.PhoneNumbers != null)
			{
				dto.PhoneNumbers = GetPhoneNumbersFromModel(model.PhoneNumbers);
			}
			if (model.EmailAddresses != null)
			{
				dto.EmailAddresses = GetEmailAddressesFromModel(model.EmailAddresses);
			}
			if (model.Addresses != null)
			{
				dto.EntityAddresses = GetEntityAddressesFromModel(model.Addresses);
			}
			if (model.Properties != null)
			{
				dto.Properties = GetPropertiesFromModel(model.Properties);
			}

			return dto;
		}

		private SqlServerDatabaseMapper.PersonType GetPersonTypeFromModel(Model.PersonType modelPersonType)
		{
			return new SqlServerDatabaseMapper.PersonType()
			{
				Id = modelPersonType.Id,
				Name = modelPersonType.Name
			};
		}

		private IEnumerable<SqlServerDatabaseMapper.PersonalID> GetFormsOfIdFromModel(ObservableCollection<PersonalID> modelIds)
		{
			IEnumerable<SqlServerDatabaseMapper.PersonalID> formsOfId =
				modelIds.Select(i => new SqlServerDatabaseMapper.PersonalID()
				{
					Id = i.Id,
					Value = i.Value,
					LastUpdate = i.LastUpdate,
					IDType = GetIdTypeFromModel(i.Type),
					Characteristics = GetIdCharacteristicsFromModel(i.Characteristics)
				});
			return formsOfId;
		}

		private SqlServerDatabaseMapper.IDType GetIdTypeFromModel(Model.IDType type)
		{
			return new SqlServerDatabaseMapper.IDType()
			{
				Id = type.Id,
				Name = type.Name,
				PrefixChar = type.PrefixChar // Consider Factoring value based traits out here as they aren't necessary and may overwrite database values if changed in seq.?
			};
		}

		private IEnumerable<SqlServerDatabaseMapper.IDCharacteristic> GetIdCharacteristicsFromModel(ObservableCollection<IDCharacteristic> modelCharacteristics)
		{
			IEnumerable<SqlServerDatabaseMapper.IDCharacteristic> idCharacteristics =
				modelCharacteristics.Select(c => new SqlServerDatabaseMapper.IDCharacteristic()
				{
					Id = c.Id,
					Value = c.Value,
					LastUpdate = c.LastUpdate,
					Type = GetIdCharacteristicTypeFromModel(c.Type)
				});
			return idCharacteristics;
		}

		private SqlServerDatabaseMapper.IDCharacteristicType GetIdCharacteristicTypeFromModel(Model.IDCharacteristicType type)
		{
			return new SqlServerDatabaseMapper.IDCharacteristicType()
			{
				Id=type.Id,
				Name = type.Name
			};
		}

		private IEnumerable<SqlServerDatabaseMapper.PhoneNumber> GetPhoneNumbersFromModel(ObservableCollection<PhoneNumber> modelPhoneNumbers)
		{
			IEnumerable<SqlServerDatabaseMapper.PhoneNumber> phoneNumbers =
				modelPhoneNumbers.Select(p => new SqlServerDatabaseMapper.PhoneNumber()
				{
					Id = p.Id,
					Number = p.Number,
					LastUpdate = p.LastUpdate,
					Primary = p.Primary,
					PhoneType = GetPhoneTypeFromModel(p.PhoneType)
				});
			return phoneNumbers;
		}

		private SqlServerDatabaseMapper.PhoneType GetPhoneTypeFromModel(Model.PhoneType phoneType)
		{
			return new SqlServerDatabaseMapper.PhoneType()
			{
				Id = phoneType.Id,
				Name = phoneType.Name
			};
		}

		private IEnumerable<SqlServerDatabaseMapper.EmailAddress> GetEmailAddressesFromModel(ObservableCollection<EmailAddress> modelEmailAddresses)
		{
			IEnumerable<SqlServerDatabaseMapper.EmailAddress> emailAddresses =
				modelEmailAddresses.Select(e => new SqlServerDatabaseMapper.EmailAddress()
				{
					Id = e.Id,
					Address = e.Address,
					LastUpdate = e.LastUpdate,
					Primary = e.Primary,
					EmailType = GetEmailTypeFromModel(e.EmailType)
				});
			return emailAddresses;
		}

		private SqlServerDatabaseMapper.EmailType GetEmailTypeFromModel(Model.EmailType emailType)
		{
			return new SqlServerDatabaseMapper.EmailType()
			{
				Id = emailType.Id,
				Name = emailType.Name
			};
		}

		private IEnumerable<SqlServerDatabaseMapper.EntityAddress> GetEntityAddressesFromModel(ObservableCollection<EntityAddress> modelEntityAddresses)
		{
			IEnumerable<SqlServerDatabaseMapper.EntityAddress> entityAddresses =
				modelEntityAddresses.Select(ea => new SqlServerDatabaseMapper.EntityAddress()
				{
					AddressId = ea.AddressId,
					Name = ea.Name,
					LastUpdate = ea.LastUpdate,
					AddressType = GetAddressTypeFromModel(ea.AddressType),
					Address = GetAddressesFromModel(ea.Address)
				});
			return entityAddresses;
		}

		private SqlServerDatabaseMapper.AddressType GetAddressTypeFromModel(Model.AddressType addressType)
		{
			return new SqlServerDatabaseMapper.AddressType()
			{
				Id = addressType.Id,
				Name = addressType.Name
			};
		}

		private SqlServerDatabaseMapper.Address GetAddressesFromModel(Model.Address address)
		{
			return new SqlServerDatabaseMapper.Address()
			{
				Id = address.Id,
				Line1 = address.Line1,
				Line2 = address.Line2,
				City = address.City,
				StateProvince = GetStateProvinceFromModel(address.StateProvince),
				PostalCode = address.PostalCode,
				SpatialLocation = address.SpatialLocation,
				LastUpdate = address.LastUpdate
			};
		}

		private SqlServerDatabaseMapper.StateProvince GetStateProvinceFromModel(Model.StateProvince stateProvince)
		{
			return new SqlServerDatabaseMapper.StateProvince()
			{
				Id = stateProvince.Id,
				Name = stateProvince.Name,
				StateProvinceCode = stateProvince.StateProvinceCode,
				CountryRegion = GetCountryRegionDataFromModel(stateProvince.CountryRegion)
			};
		}

		private SqlServerDatabaseMapper.CountryRegion GetCountryRegionDataFromModel(Model.CountryRegion countryRegion)
		{
			return new SqlServerDatabaseMapper.CountryRegion()
			{
				CountryRegionCode = countryRegion.CountryRegionCode,
				Name = countryRegion.Name
			};
		}

		private IEnumerable<SqlServerDatabaseMapper.PersonalProperty> GetPropertiesFromModel(ObservableCollection<PersonalProperty> modelProperties)
		{
			IEnumerable<SqlServerDatabaseMapper.PersonalProperty> properties =
				modelProperties.Select(p => new SqlServerDatabaseMapper.PersonalProperty()
				{
					Id = p.Id,
					Value = p.Value,
					LastUpdate = p.LastUpdate,
					Type = GetPropertyTypeFromModel(p.Type)
				});
			return properties;
		}

		private SqlServerDatabaseMapper.PropertyType GetPropertyTypeFromModel(Model.PropertyType type)
		{
			return new SqlServerDatabaseMapper.PropertyType()
			{
				Id = type.Id,
				Name = type.Name
			};
		}
	}
}
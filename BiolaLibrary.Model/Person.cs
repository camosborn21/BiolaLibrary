using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiolaLibrary.Model
{
	public class Person : ModelBase
	{
		public const string EntityIdPropertyName = "EntityId";
		private int _entityId;
		public int EntityId
		{
			get { return _entityId; }
			set
			{
				if (_entityId == value)
					return;
				_entityId = value;
				RaisePropertyChanged(EntityIdPropertyName);
			}
		}
		public const string PersonTypePropertyName = "PersonType";
		private PersonType _personType;
		public PersonType PersonType
		{
			get { return _personType; }
			set
			{
				if (_personType == value)
					return;
				_personType = value;
				RaisePropertyChanged(PersonTypePropertyName);
			}
		}

		public const string FirstNamePropertyName = "FirstName";
		private string _firstName;
		public string FirstName
		{
			get { return _firstName; }
			set
			{
				if (string.Compare(_firstName, value) == 0)
					return;
				_firstName = value;
				RaisePropertyChanged(FirstNamePropertyName);
			}
		}
		public const string MiddleNamePropertyName = "MiddleName";
		private string _middleName;
		public string MiddleName
		{
			get { return _middleName; }
			set
			{
				if (string.Compare(_middleName, value) == 0)
					return;
				_middleName = value;
				RaisePropertyChanged(MiddleNamePropertyName);
			}
		}
		public const string LastNamePropertyName = "LastName";
		private string _lastName;
		public string LastName
		{
			get { return _lastName; }
			set
			{
				if (string.Compare(_lastName, value) == 0)
					return;
				_lastName = value;
				RaisePropertyChanged(LastNamePropertyName);
			}
		}
		public const string TitlePropertyName = "Title";
		private string _title;
		public string Title
		{
			get { return _title; }
			set
			{
				if (string.Compare(_title, value) == 0)
					return;
				_title = value;
				RaisePropertyChanged(TitlePropertyName);
			}
		}
		public const string SuffixPropertyName = "Suffix";
		private string _suffix;
		public string Suffix
		{
			get { return _suffix; }
			set
			{
				if (string.Compare(_suffix, value) == 0)
					return;
				_suffix = value;
				RaisePropertyChanged(SuffixPropertyName);
			}
		}

		//[10/26/2017 18:11] camerono: This may need to be changed so it doesn't RaisePropertyChanged since it's updated by saving it to the database.
		public const string LastUpdatePropertyName = "LastUpdate";
		private DateTime _lastUpdate;
		public DateTime LastUpdate
		{
			get { return _lastUpdate; }
			set
			{
				if (_lastUpdate == value)
					return;
				_lastUpdate = value;
				RaisePropertyChanged(LastUpdatePropertyName);
			}
		}
		public const string FormsOfIdPropertyName = "FormsOfId";
		private ObservableCollection<PersonalID> _formsOfId;
		public ObservableCollection<PersonalID> FormsOfId
		{
			get { return _formsOfId; }
			set
			{
				if (_formsOfId == value)
					return;
				_formsOfId = value;
				RaisePropertyChanged(FormsOfIdPropertyName);
			}
		}
		public const string PhoneNumbersPropertyName = "PhoneNumbers";
		private ObservableCollection<PhoneNumber> _phoneNumbers;
		public ObservableCollection<PhoneNumber> PhoneNumbers
		{
			get { return _phoneNumbers; }
			set
			{
				if (_phoneNumbers == value)
					return;
				_phoneNumbers = value;
				RaisePropertyChanged(PhoneNumbersPropertyName);
			}
		}
		public const string EmailAddressesPropertyName = "EmailAddresses";
		private ObservableCollection<EmailAddress> _emailAddresses;
		public ObservableCollection<EmailAddress> EmailAddresses
		{
			get { return _emailAddresses; }
			set
			{
				if (_emailAddresses == value)
					return;
				_emailAddresses = value;
				RaisePropertyChanged(EmailAddressesPropertyName);
			}
		}
		public const string AddressesPropertyName = "Addresses";
		private ObservableCollection<EntityAddress> _addresses;
		public ObservableCollection<EntityAddress> Addresses
		{
			get { return _addresses; }
			set
			{
				if (_addresses == value)
					return;
				_addresses = value;
				RaisePropertyChanged(AddressesPropertyName);
			}
		}
		public const string PropertiesPropertyName = "Properties";
		private ObservableCollection<PersonalProperty> _properties;
		public ObservableCollection<PersonalProperty> Properties
		{
			get { return _properties; }
			set
			{
				if (_properties == value)
					return;
				_properties = value;
				RaisePropertyChanged(PropertiesPropertyName);
			}
		}
	}
}

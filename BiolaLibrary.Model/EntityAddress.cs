using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiolaLibrary.Model
{
	public class EntityAddress : ModelBase
	{
		public const string AddressIdPropertyName = "AddressId";
		private int _addressId;
		public int AddressId
		{
			get { return _addressId; }
			set
			{
				if (_addressId == value)
					return;
				_addressId = value;
				RaisePropertyChanged(AddressIdPropertyName);
			}
		}
		public const string AddressTypePropertyName = "AddressType";
		private AddressType _addressType;
		public AddressType AddressType
		{
			get { return _addressType; }
			set
			{
				if (_addressType == value)
					return;
				_addressType = value;
				RaisePropertyChanged(AddressTypePropertyName);
			}
		}

		public const string NamePropertyName = "Name";
		private string _name;
		public string Name
		{
			get { return _name; }
			set
			{
				if (string.Compare(_name, value) == 0)
					return;
				_name = value;
				RaisePropertyChanged(NamePropertyName);
			}
		}
		public const string AddressPropertyName = "Address";
		private Address _address;
		public Address Address
		{
			get { return _address; }
			set
			{
				if (_address == value)
					return;
				_address = value;
				RaisePropertyChanged(AddressPropertyName);
			}
		}
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
	}
}

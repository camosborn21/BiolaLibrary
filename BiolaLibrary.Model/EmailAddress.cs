using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiolaLibrary.Model
{
	public class EmailAddress : ModelBase
	{
		public const string IdPropertyName = "Id";
		private int _id;
		public int Id
		{
			get { return _id; }
			set
			{
				if (_id == value)
					return;
				_id = value;
				RaisePropertyChanged(IdPropertyName);
			}
		}
		public const string EmailTypePropertyName = "EmailType";
		private EmailType _emailType;
		public EmailType EmailType
		{
			get { return _emailType; }
			set
			{
				if (_emailType == value)
					return;
				_emailType = value;
				RaisePropertyChanged(EmailTypePropertyName);
			}
		}

		public const string AddressPropertyName = "Address";
		private string _address;
		public string Address
		{
			get { return _address; }
			set
			{
				if (string.Compare(_address, value) == 0)
					return;
				_address = value;
				RaisePropertyChanged(AddressPropertyName);
			}
		}

		public const string PrimaryPropertyName = "Primary";
		private bool _primary;
		public bool Primary
		{
			get { return _primary; }
			set
			{
				if (_primary == value)
					return;
				_primary = value;
				RaisePropertyChanged(PrimaryPropertyName);
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

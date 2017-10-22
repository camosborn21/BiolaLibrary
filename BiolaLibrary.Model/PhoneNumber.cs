using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiolaLibrary.Model
{
	public class PhoneNumber : ModelBase
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
		public const string PhoneTypePropertyName = "PhoneType";
		private PhoneType _phoneType;
		public PhoneType PhoneType
		{
			get { return _phoneType; }
			set
			{
				if (_phoneType == value)
					return;
				_phoneType = value;
				RaisePropertyChanged(PhoneTypePropertyName);
			}
		}
		public const string NumberPropertyName = "Number";
		private string _number;
		public string Number
		{
			get { return _number; }
			set
			{
				if (string.Compare(_number, value) == 0)
					return;
				_number = value;
				RaisePropertyChanged(NumberPropertyName);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiolaLibrary.Model
{
	public class PersonalProperty : ModelBase
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
		public const string TypePropertyName = "Type";
		private PropertyType _type;
		public PropertyType Type
		{
			get { return _type; }
			set
			{
				if (_type == value)
					return;
				_type = value;
				RaisePropertyChanged(TypePropertyName);
			}
		}
		public const string ValuePropertyName = "Value";
		private string _value;
		public string Value
		{
			get { return _value; }
			set
			{
				if (string.Compare(_value, value) == 0)
					return;
				_value = value;
				RaisePropertyChanged(ValuePropertyName);
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

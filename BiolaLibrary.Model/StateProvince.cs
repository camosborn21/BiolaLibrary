using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiolaLibrary.Model
{
	public class StateProvince : ModelBase
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

		public const string StateProvinceCodePropertyName = "StateProvinceCode";
		private string _stateProvinceCode;
		public string StateProvinceCode
		{
			get { return _stateProvinceCode; }
			set
			{
				if (string.Compare(_stateProvinceCode, value) == 0)
					return;
				_stateProvinceCode = value;
				RaisePropertyChanged(StateProvinceCodePropertyName);
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

		public const string CountryRegionPropertyName = "CountryRegion";
		private CountryRegion _countryRegion;
		public CountryRegion CountryRegion
		{
			get { return _countryRegion; }
			set
			{
				if (_countryRegion == value)
					return;
				_countryRegion = value;
				RaisePropertyChanged(CountryRegionPropertyName);
			}
		}

	}
}

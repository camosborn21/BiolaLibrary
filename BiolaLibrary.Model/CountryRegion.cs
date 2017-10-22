using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiolaLibrary.Model
{
	public class CountryRegion : ModelBase
	{
		public const string CountryRegionCodePropertyName = "CountryRegionCode";
		private string _countryRegionCode;
		public string CountryRegionCode
		{
			get { return _countryRegionCode; }
			set
			{
				if (string.Compare(_countryRegionCode, value) == 0)
					return;
				_countryRegionCode = value;
				RaisePropertyChanged(CountryRegionCodePropertyName);
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

	}
}

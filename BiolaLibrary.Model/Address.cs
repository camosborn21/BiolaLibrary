using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiolaLibrary.Model
{
	public class Address : ModelBase
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

		public const string Line1PropertyName = "Line1";
		private string _line1;
		public string Line1
		{
			get { return _line1; }
			set
			{
				if (string.Compare(_line1, value) == 0)
					return;
				_line1 = value;
				RaisePropertyChanged(Line1PropertyName);
			}
		}

		public const string Line2PropertyName = "Line2";
		private string _line2;
		public string Line2
		{
			get { return _line2; }
			set
			{
				if (string.Compare(_line2, value) == 0)
					return;
				_line2 = value;
				RaisePropertyChanged(Line2PropertyName);
			}
		}

		public const string CityPropertyName = "City";
		private string _city;
		public string City
		{
			get { return _city; }
			set
			{
				if (string.Compare(_city, value) == 0)
					return;
				_city = value;
				RaisePropertyChanged(CityPropertyName);
			}
		}

		public const string StateProvincePropertyName = "StateProvince";
		private StateProvince _stateProvince;
		public StateProvince StateProvince
		{
			get { return _stateProvince; }
			set
			{
				if (_stateProvince == value)
					return;
				_stateProvince = value;
				RaisePropertyChanged(StateProvincePropertyName);
			}
		}

		public const string PostalCodePropertyName = "PostalCode";
		private string _postalCode;
		public string PostalCode
		{
			get { return _postalCode; }
			set
			{
				if (string.Compare(_postalCode, value) == 0)
					return;
				_postalCode = value;
				RaisePropertyChanged(PostalCodePropertyName);
			}
		}

		public const string SpatialLocationPropertyName = "SpatialLocation";
		private DbGeography _spatialLocation;
		public DbGeography SpatialLocation
		{
			get { return _spatialLocation; }
			set
			{
				if (_spatialLocation == value)
					return;
				_spatialLocation = value;
				RaisePropertyChanged(SpatialLocationPropertyName);
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

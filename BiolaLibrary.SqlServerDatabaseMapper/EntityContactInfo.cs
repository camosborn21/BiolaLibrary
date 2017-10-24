using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiolaLibrary.SqlServerDatabaseMapper
{
	public class CountryRegion
	{
		public string CountryRegionCode { get; set; }
		public string Name { get; set; }
	}

	public class StateProvince
	{
		public int Id { get; set; }
		public string StateProvinceCode { get; set; }
		public string Name { get; set; }
		public CountryRegion CountryRegion { get; set; }
	}

	public class Address
	{
		public int Id { get; set; }
		public string Line1 { get; set; }
		public string Line2 { get; set; }
		public string City { get; set; }
		public StateProvince StateProvince { get; set; }
		public string PostalCode { get; set; }
		public DbGeography SpatialLocation { get; set; }
		public DateTime LastUpdate { get; set; }
	}

	public class AddressType
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}

	public class EntityAddress
	{
		public int AddressId { get; set; }
		public AddressType AddressType { get; set; }
		public string Name { get; set; }
		public Address Address { get; set; }
		public DateTime LastUpdate { get; set; }
	}
	public class EmailType
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}

	public class EmailAddress
	{
		public int Id { get; set; }
		public EmailType EmailType { get; set; }
		public string Address { get; set; }
		public bool Primary { get; set; }
		public DateTime LastUpdate { get; set; }
	}

	public class PhoneType
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}

	public class PhoneNumber
	{
		public int Id { get; set; }
		public PhoneType PhoneType { get; set; }
		public string Number { get; set; }
		public bool Primary { get; set; }
		public DateTime LastUpdate { get; set; }
	}
}

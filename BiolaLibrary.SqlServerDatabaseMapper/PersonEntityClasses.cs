using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiolaLibrary.SqlServerDatabaseMapper
{
	public class PersonType
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}

	public class PropertyType
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}

	public class PersonalProperty
	{
		public int Id { get; set; }
		public PropertyType Type { get; set; }
		public string Value { get; set; }
		public DateTime LastUpdate { get; set; }
	}

	public class Person
	{
		public int EntityId { get; set; }
		public PersonType PersonType { get; set; }
		public string FirstName { get; set; }
		public string MiddleName { get; set; }
		public string LastName { get; set; }
		public string Title { get; set; }
		public string Suffix { get; set; }
		public DateTime LastUpdate { get; set; }
		// ReSharper disable once InconsistentNaming
		public IEnumerable<PersonalID> FormsOfID { get; set; }
		public IEnumerable<PhoneNumber> PhoneNumbers { get; set; }
		public IEnumerable<EmailAddress> EmailAddresses { get; set; }
		public IEnumerable<PersonalProperty> Properties { get; set; }
	}
}

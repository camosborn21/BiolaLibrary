using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiolaLibrary.SqlServerDatabaseMapper
{
	// ReSharper disable once InconsistentNaming
	public class IDCharacteristicType
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}

	// ReSharper disable once InconsistentNaming
	public class IDCharacteristic
	{
		public int Id { get; set; }
		public IDCharacteristicType Type { get; set; }
		public string Value { get; set; }
		public DateTime LastUpdate { get; set; }
	}

	// ReSharper disable once InconsistentNaming
	public class IDType
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string PrefixChar { get; set; }
	}

	// ReSharper disable once InconsistentNaming
	public class PersonalID
	{
		public int Id { get; set; }
		// ReSharper disable once InconsistentNaming
		public IDType IDType { get; set; }
		public string Value { get; set; }
		public DateTime LastUpdate { get; set; }
		public IEnumerable<IDCharacteristic> Characteristics { get; set; }
	}
}

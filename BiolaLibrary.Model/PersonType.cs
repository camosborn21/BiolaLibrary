using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiolaLibrary.Model
{
	public class PersonType : ModelBase
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

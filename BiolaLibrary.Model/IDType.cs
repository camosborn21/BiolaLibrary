using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiolaLibrary.Model
{
	public class IDType : ModelBase
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
		public const string PrefixCharPropertyName = "PrefixChar";
		private string _prefixChar;
		public string PrefixChar
		{
			get { return _prefixChar; }
			set
			{
				if (string.Compare(_prefixChar, value) == 0)
					return;
				_prefixChar = value;
				RaisePropertyChanged(PrefixCharPropertyName);
			}
		}
	}
}

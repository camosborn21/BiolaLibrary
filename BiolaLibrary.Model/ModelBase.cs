﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiolaLibrary.Model
{
    public class ModelBase : INotifyPropertyChanged
    {
	    public event PropertyChangedEventHandler PropertyChanged = delegate { };

	    public void RaisePropertyChanged(string propertyName)
	    {
		    VerifyPropertyName(propertyName);
			PropertyChanged(this,new PropertyChangedEventArgs(propertyName));
	    }

		[DebuggerStepThrough]
		[Conditional("DEBUG")]
		private void VerifyPropertyName(string propertyName)
		{
			if(TypeDescriptor.GetProperties(this)[propertyName]==null)
				throw new InvalidOperationException("Property " + propertyName + " wasn't found in " + GetType().Name + ".");
		}
	}
}

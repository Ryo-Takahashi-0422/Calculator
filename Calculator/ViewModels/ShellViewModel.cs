using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.ViewModels
{
    public class ShellViewModel : Caliburn.Micro.Screen
    {
		private int _value = 0;

		public int Value
		{
			get 
			{
				return _value; 
			}
			set 
			{ 
				_value = Value;
			}
		}

	}
}

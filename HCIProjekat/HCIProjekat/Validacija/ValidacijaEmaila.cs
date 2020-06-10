using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HCIProjekat.Validacija
{
	class ValidacijaEmaila : ValidationRule
	{
		public override ValidationResult Validate(object value, CultureInfo cultureInfo)
		{
			try
			{
				var s = value as string;
				Regex regex = new Regex(@"^[A - Z0 - 9._ % +-] +@[A - Z0 - 9.-] +\.[A-Z]{2,}$.");
				if (regex.IsMatch(s))
				{
					return new ValidationResult(true, null);
				}
				return new ValidationResult(false, "Neophodno je da lozinka ima najmanje 8 karaktera, bar jedno slovo i bar jedan broj.");
			}
			catch
			{
				return new ValidationResult(false, "Doslo je do nepoznate greske");
			}
		}
	}
}

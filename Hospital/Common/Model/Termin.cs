using Common.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
	[Serializable]
	public class Termin : ValidationBase
	{
		DateTime vreme;
		string pacijent;
		string doktor;

		public DateTime Vreme
		{
			get
			{
				return vreme;
			}
			set
			{
				vreme = value;
				OnPropertyChanged("Vreme");
			}
		}

		public string Pacijent
		{
			get
			{
				return pacijent;
			}
			set
			{
				pacijent = value;
				OnPropertyChanged("Pacijent");
			}
		}

		public string Doktor
		{
			get
			{
				return doktor;
			}
			set
			{
				doktor = value;
				OnPropertyChanged("Doktor");
			}
		}

		protected override void ValidateSelf()
		{
			if (vreme <= DateTime.Now)
			{
				ValidationErrors["Vreme"] = "Ne mozete zakazati sastanak u proslosti.";
			}
		}
	}
}

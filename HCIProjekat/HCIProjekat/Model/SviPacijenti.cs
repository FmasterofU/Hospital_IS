using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Controller;
using Model.Roles;

namespace HCIProjekat.Model
{
    public class SviPacijenti
    {
        private static SviPacijenti instance = null;

        public static SviPacijenti getInstance()
        {
            if (instance == null)
            {
                instance = new SviPacijenti();
            }
            return instance;
        }

        private ObservableCollection<Patient> pacijenti;

        private SviPacijenti()
        {
            this.pacijenti = new ObservableCollection<Patient>();
            InicijalizujPacijente();
        }


        private void InicijalizujPacijente()
        {
            UserController allPatient = new UserController();


            foreach (Patient p in allPatient.GetPatientBySearch("", "", ""))
                pacijenti.Add(p);
        }

        public ObservableCollection<Patient> getPacijente()
        {
            return pacijenti;
        }
    }
}

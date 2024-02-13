using OptimisationEvents.ObserverPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimisationEvents.Models
{
    public class Stagiaire : ObservableObject
    {
        private string _nom, _prenom;

        public int Id { get; init; }

        public string Nom
        {
            get
            {
                return _nom;
            }

            set
            {
                Set(ref _nom, value, "Nom");
            }
        }

        public string Prenom
        {
            get
            {
                return _prenom;
            }

            set
            {
                Set(ref _prenom, value, "Prenom");
            }
        }

        public Stagiaire(int id, string nom, string prenom)
        {
            Id = id;
            _nom = nom;
            _prenom = prenom;
        }
    }
}

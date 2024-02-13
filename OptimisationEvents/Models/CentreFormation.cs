using OptimisationEvents.ObserverPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimisationEvents.Models
{
    public class CentreFormation
    {
        private readonly IList<Stagiaire> _personnes;

        public CentreFormation()
        {
            _personnes = new List<Stagiaire>();
        }


        private void OnPropertyChanged(ObservableObject observable, string propertyName)
        {
            if(observable is Stagiaire personne) 
            {
                Console.WriteLine($"La propriété '{propertyName}' du stagiaire dont l'id est '{personne.Id}' a changé");
            }
        }

        public void Add(Stagiaire personne)
        {
            personne.Notifier += OnPropertyChanged;
            _personnes.Add(personne);
        }

        public void Remove(Stagiaire personne)
        {
            personne.Notifier -= OnPropertyChanged;
            _personnes.Remove(personne);
        }
    }
}

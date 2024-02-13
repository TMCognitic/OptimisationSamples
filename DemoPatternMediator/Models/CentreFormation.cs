using DemoPatternMediator.MediatorPattern;
using DemoPatternMediator.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoPatternMediator.Models
{
    public class CentreFormation
    {
        private readonly IList<Stagiaire> _personnes;

        public CentreFormation()
        {
            _personnes = new List<Stagiaire>();
            Mediator<PropertyChangedMessage>.Instance.Publisher += OnPropertyChangedMessage;
        }


        private void OnPropertyChangedMessage(PropertyChangedMessage message)
        {
            if(_personnes.Contains(message.Stagiaire))
            {
                Console.WriteLine($"La propriété '{message.Propriete}' du stagiaire dont l'id est '{message.Stagiaire.Id}' a changé");
            }
        }

        public void Add(Stagiaire personne)
        {
            _personnes.Add(personne);
        }

        public void Remove(Stagiaire personne)
        {
            _personnes.Remove(personne);
        }
    }
}

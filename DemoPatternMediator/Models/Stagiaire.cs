using DemoPatternMediator.MediatorPattern;
using DemoPatternMediator.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoPatternMediator.Models
{
    public class Stagiaire
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
                _nom = value;
                Notify(nameof(Nom));
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
                _nom = value;
                Notify(nameof(Prenom));
            }
        }

        public Stagiaire(int id, string nom, string prenom)
        {
            Id = id;
            _nom = nom;
            _prenom = prenom;
        }

        private void Notify(string propertyName)
        {
            Mediator<PropertyChangedMessage>.Instance.Send(new PropertyChangedMessage(this, propertyName));
        }
    }
}

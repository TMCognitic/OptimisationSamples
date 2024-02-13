using DemoPatternMediator.MediatorPattern;
using DemoPatternMediator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoPatternMediator.Messages
{
    public struct PropertyChangedMessage : IMessage
    {
        public Stagiaire Stagiaire { get; init; }
        public string Propriete { get; init; }

        public PropertyChangedMessage(Stagiaire stagiaire, string propriete)
        {
            Stagiaire = stagiaire;
            Propriete = propriete;
        }
    }
}

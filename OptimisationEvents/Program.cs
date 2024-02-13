using OptimisationEvents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimisationEvents
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stagiaire johnDoe = new Stagiaire(1, "Doe", "John");
            Stagiaire hannibalSmith = new Stagiaire(2, "Smith", "Hannibal");
            CentreFormation observer = new CentreFormation();
            observer.Add(johnDoe);
            observer.Add(hannibalSmith);     
            

            observer.Remove(johnDoe);

            johnDoe.Prenom = "Jane";
            hannibalSmith.Nom = "Doe";
        }
    }
}

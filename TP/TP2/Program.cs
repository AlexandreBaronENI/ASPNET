using ProjetLinq.BO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TP2
{
    class Program
    {
        private static List<Auteur> ListeAuteurs = new List<Auteur>();
        private static List<Livre> ListeLivres = new List<Livre>();

        static void Main(string[] args)
        {
            InitialiserDatas();

            // Prenom commencant par un G
            Console.WriteLine("Prenom commencant par un G");
            var prenomsAvecNomCommenceParG = ListeAuteurs.Where(a => a.Nom.StartsWith("G")).Select(a => a.Prenom);

            foreach (var prenom in prenomsAvecNomCommenceParG)
            {
                Console.WriteLine(prenom);
            }


            Console.WriteLine(Environment.NewLine);
            //Auteur avec le plus de livres
            Console.WriteLine("Auteur avec le plus de livres");
            var auteurPlusDeLivres = ListeLivres.GroupBy(l => l.Auteur).OrderByDescending(a => a.Count()).FirstOrDefault().Select(l => l.Auteur).FirstOrDefault();
            Console.WriteLine($"{auteurPlusDeLivres.Nom} {auteurPlusDeLivres.Prenom}");


            Console.WriteLine(Environment.NewLine);
            //Nombre moyen de pages par livre par auteur
            Console.WriteLine("Nombre moyen de pages par livre par auteur");
            var livresParAuteur = ListeLivres.GroupBy(l => l.Auteur);

            foreach (var auteur in livresParAuteur)
            {
                Console.WriteLine($"{auteur.Key.Nom} {auteur.Key.Prenom} {auteur.Average(a => a.NbPages)}");
            }

            Console.WriteLine(Environment.NewLine);
            //Titre livre plus de pages
            Console.WriteLine("Titre livre plus de pages");
            var livrePlusDePages = ListeLivres.OrderByDescending(l => l.NbPages).FirstOrDefault();
            Console.WriteLine(livrePlusDePages.Titre);

            Console.WriteLine(Environment.NewLine);
            //Moyenne des facture
            Console.WriteLine("Moyenne des facture");
            var moyenneFacture = ListeAuteurs.Average(a => a.Factures.Sum(f => f.Montant));
            Console.WriteLine(moyenneFacture);

            Console.WriteLine(Environment.NewLine);
            //Livre par Auteur
            Console.WriteLine("Livre par Auteur");
            livresParAuteur = ListeLivres.GroupBy(l => l.Auteur);
            foreach (var livres in livresParAuteur)
            {
                Console.WriteLine($"{livres.Key.Nom} {livres.Key.Prenom}");
                foreach (var livre in livres)
                {
                    Console.WriteLine($"\t{livre.Titre}");
                }
            }

            Console.WriteLine(Environment.NewLine);
            //Livres par ordre alphabethique
            Console.WriteLine("Livres par ordre alphabethique");
            var livresOrdreAlphabethique = ListeLivres.OrderBy(l => l.Titre);

            foreach (var livre in livresOrdreAlphabethique)
            {
                Console.WriteLine(livre.Titre);
            }

            Console.WriteLine(Environment.NewLine);
            //Livre dont le nombre de page est supérieur à la moyenne de pages
            Console.WriteLine("Livre dont le nombre de page est supérieur à la moyenne de pages");
            var livrePagesSuperieurALaMoyenne = ListeLivres.Where(l => l.NbPages >= ListeLivres.Average(l2 => l2.NbPages));

            foreach (var livre in livrePagesSuperieurALaMoyenne)
            {
                Console.WriteLine(livre.Titre);
            }

            Console.WriteLine(Environment.NewLine);
            //Auteur avec le moins de livre
            Console.WriteLine("Auteur avec le moins de livre");
            var auteurAvecLeMoinsDeLivre = ListeAuteurs.OrderBy(a => ListeLivres.Count(l => l.Auteur == a)).FirstOrDefault();
            Console.WriteLine($"{auteurAvecLeMoinsDeLivre.Nom} {auteurAvecLeMoinsDeLivre.Prenom}");



            Console.ReadKey();

        }

        private static void InitialiserDatas()
        {
            ListeAuteurs.Add(new Auteur("GROUSSARD", "Thierry"));
            ListeAuteurs.Add(new Auteur("GABILLAUD", "Jérôme"));
            ListeAuteurs.Add(new Auteur("HUGON", "Jérôme"));
            ListeAuteurs.Add(new Auteur("ALESSANDRI", "Olivier"));
            ListeAuteurs.Add(new Auteur("de QUAJOUX", "Benoit"));
            ListeLivres.Add(new Livre(1, "C# 4", "Les fondamentaux du langage", ListeAuteurs.ElementAt(0), 533));
            ListeLivres.Add(new Livre(2, "VB.NET", "Les fondamentaux du langage", ListeAuteurs.ElementAt(0), 539));
            ListeLivres.Add(new Livre(3, "SQL Server 2008", "SQL, Transact SQL", ListeAuteurs.ElementAt(1), 311));
            ListeLivres.Add(new Livre(4, "ASP.NET 4.0 et C#", "Sous visual studio 2010", ListeAuteurs.ElementAt(3), 544));
            ListeLivres.Add(new Livre(5, "C# 4", "Développez des applications windows avec visual studio 2010", ListeAuteurs.ElementAt(2), 452));
            ListeLivres.Add(new Livre(6, "Java 7", "les fondamentaux du langage", ListeAuteurs.ElementAt(0), 416));
            ListeLivres.Add(new Livre(7, "SQL et Algèbre relationnelle", "Notions de base", ListeAuteurs.ElementAt(1), 216));
            ListeAuteurs.ElementAt(0).addFacture(new Facture(3500, ListeAuteurs.ElementAt(0)));
            ListeAuteurs.ElementAt(0).addFacture(new Facture(3200, ListeAuteurs.ElementAt(0)));
            ListeAuteurs.ElementAt(1).addFacture(new Facture(4000, ListeAuteurs.ElementAt(1)));
            ListeAuteurs.ElementAt(2).addFacture(new Facture(4200, ListeAuteurs.ElementAt(2)));
            ListeAuteurs.ElementAt(3).addFacture(new Facture(3700, ListeAuteurs.ElementAt(3)));
        }
    }
}

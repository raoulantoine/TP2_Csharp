using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2.Entities;
using TP2.Utils;

namespace TP2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            foreach (var item in FakeDb.Instance.Users)
            {
                Console.WriteLine(item);
            }

            #region Q1
            Console.WriteLine("Question 1");
            // Afficher le nombre de personne s'appelant Dupond ou Dupont.
           foreach (var item in FakeDb.Instance.Users.Where(x => x.Lastname == "Dupont" || x.Lastname == "Dupond"))
            {
                Console.WriteLine(item);
            }


            #endregion
            #region Q2
            Console.WriteLine("Question 2");
            // Afficher les personnes enregistré avec le role Automobiliste.
           var query = from User in FakeDb.Instance.Users
                        join Role in FakeDb.Instance.Roles
                        on User.Id equals Role.Id
                        where Role.Name == "Automobiliste"
                        select User.Firstname;
            foreach (var item in query)
            {
                Console.WriteLine(item);
            }

            #endregion
            #region Q3
            Console.WriteLine("Question 3");
            // Afficher les plaques d'immatriculation de toutes les voitures (une seule fois par voiture) liées à au moins un utilisateur.
            var query3 = from Car in FakeDb.Instance.Cars
                         join User in FakeDb.Instance.Users
                         on Car.Id equals User.Id
                         where User.Id != null
                         select FakeDb.Instance.Cars.Distinct();
            foreach (var item in query3 )
            {
                Console.WriteLine(item);
            }

            #endregion
            #region Q4
            Console.WriteLine("Question 4");
            // Afficher la ou les voiture(s) avec le plus de kilomètre
             var query4 = from Car in FakeDb.Instance.Cars
                         where Car.Mileage == FakeDb.Instance.Cars.Max(x => x.Mileage)
                         select Car.Registration;
            foreach (var item in query4)
            {
                Console.WriteLine(item);
            }

            #endregion
            #region Q5
            Console.WriteLine("Question 5");
            // Afficher le classement des types de voiture par nombre de voiture unique présentes du plus grand au plus petit.

            #endregion
            #region Q6
            Console.WriteLine("Question 6");
            // Afficher les "Garagiste" liés à 4 voitures ou plus.

            #endregion
            #region Q7
            Console.WriteLine("Question 7");
            // Afficher les "Controlleur" et la liste des voitures aux quelles ils sont liés.

            #endregion
            Console.ReadKey();
        }
    }
}

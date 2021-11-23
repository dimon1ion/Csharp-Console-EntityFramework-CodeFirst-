using _07_11_2021_Entity_Framework_Core_CodeFirst.Classes;
using _07_11_2021_Entity_Framework_Core_CodeFirst.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Homework_07112021
{
    class Program
    {
        static void Main(string[] args)
        {
            OlympContext db = new OlympContext();

            #region Add
            //AddCounties(db);
            //AddMedals(db);
            //AddSports(db);
            //AddParticipants(db);
            //AddParticipantsSportsMedals(db);
            //db.SaveChanges();
            #endregion

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Enter Action:");
                Console.WriteLine("1. Select Participants" +
                    "\n2. Select Sports" +
                    "\n3. Select Countries" +
                    "\n4. Select Participant by Id" +
                    "\n5. Select Sport by Id" +
                    "\n6. Select Country by Id" +
                    "\n7. Find Participant" +
                    "\n8. Top Countries by Medals" +
                    "\n9. Top Sports by Medals" +
                    "\n10. Top Participants" +
                    "\n11. Top Sports by Countries");

                int write = Int32.Parse(Console.ReadLine());

                switch (write)
                {
                    case 1:
                        List<Participants> participants = db.Participants.ToList();
                        Console.WriteLine("Id FirstName LastName");
                        foreach (Participants participant in participants)
                        {
                            Console.Write(participant.Id + " " + participant.FirstName + " " + participant.LastName + '\n');
                        }
                        Console.ReadKey();
                        continue;
                    case 2:

                        continue;
                    default:
                        break;
                }
                break;
            }

        }

        private static void AddCounties(OlympContext db)
        {
            db.Countries.Add(new Country { Name = "Azerbaijan" });
            db.Countries.Add(new Country { Name = "Russia" });
            db.Countries.Add(new Country { Name = "Ukrain" });
            db.Countries.Add(new Country { Name = "Belgia" });
            db.Countries.Add(new Country { Name = "Argentina" });
            db.Countries.Add(new Country { Name = "Portugalia" });
            db.Countries.Add(new Country { Name = "Gecia" });
            db.Countries.Add(new Country { Name = "Albania" });
            db.Countries.Add(new Country { Name = "Avstralia" });
            db.Countries.Add(new Country { Name = "Belorusia" });
        }

        private static void AddMedals(OlympContext db)
        {
            db.Medals.Add(new Medals { Type = Medal.Gold });
            db.Medals.Add(new Medals { Type = Medal.Silver });
            db.Medals.Add(new Medals { Type = Medal.Bronze });
            db.Medals.Add(new Medals { Type = Medal.No });
        }

        private static void AddParticipants(OlympContext db)
        {
            db.Participants.Add(new Participants { FirstName = "Dmitriy", LastName = "Kokorin", CountryId = db.Countries.Where(c => c.Name == "Russia").First().Id });
            db.Participants.Add(new Participants { FirstName = "Mamed", LastName = "Mamedov", CountryId = db.Countries.Where(c => c.Name == "Azerbaijan").First().Id });
            db.Participants.Add(new Participants { FirstName = "Veronika", LastName = "Kolesnikova", CountryId = db.Countries.Where(c => c.Name == "Ukrain").First().Id });
        }

        private static void AddParticipantsSportsMedals(OlympContext db)
        {
            db.ParticipantsSportsMedals.Add(new ParticipantsSportsMedals
            {
                MedalsId = db.Medals.Where(m => m.Type == Medal.Gold).First().Id,
                PartId = db.Participants.Where(p => p.FirstName == "Dmitriy" && p.LastName == "Kokorin").First().Id,
                SportId = db.Sports.Where(s => s.Name == "Basketball").First().Id
            });
        }

        private static void AddSports(OlympContext db)
        {
            db.Sports.Add(new Sports { Name = "Basketball" });
        }
    }
}

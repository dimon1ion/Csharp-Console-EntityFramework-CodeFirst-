using _07_11_2021_Entity_Framework_Core_CodeFirst.Classes;
using _07_11_2021_Entity_Framework_Core_CodeFirst.Contexts;
using Microsoft.EntityFrameworkCore;
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

            #region Add DATA

            //AddCounties(db);
            //AddMedals(db);
            //AddSports(db);
            //AddParticipants(db);
            //AddParticipantsSportsMedals(db);

            #endregion

            bool find = false;

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
                            find = true;
                            Console.WriteLine(participant.Id + " " + participant.FirstName + " " + participant.LastName);
                        }

                        checkBoolShowEmpty(ref find);

                        Console.ReadKey();
                        continue;
                    case 2:
                        List<Sports> sports = db.Sports.ToList();
                        Console.WriteLine("Id Name");
                        foreach (Sports sport in sports)
                        {
                            find = true;
                            Console.WriteLine(sport.Id + " " + sport.Name);
                        }

                        checkBoolShowEmpty(ref find);

                        Console.ReadKey();
                        continue;
                    case 3:
                        List<Country> countries = db.Countries.ToList();
                        Console.WriteLine("Id Name");
                        foreach (Country country in countries)
                        {
                            find = true;
                            Console.WriteLine(country.Id + " " + country.Name);
                        }

                        checkBoolShowEmpty(ref find);

                        Console.ReadKey();
                        continue;
                    case 4:
                        {
                            int id = TakeId();
                            var list = (from i in db.ParticipantsSportsMedals
                                        where i.Participant.Id == id
                                        select new
                                        {
                                            FirstName = i.Participant.FirstName,
                                            LastName = i.Participant.LastName,
                                            Country = i.Participant.Country.Name,
                                            Sport = i.Sport.Name,
                                            Medal = i.Medal.Type
                                        }).ToList();

                            Console.WriteLine("FirstName LastName Country Sport Medal");

                            foreach (var item in list)
                            {
                                find = true;
                                Console.WriteLine(item.FirstName + " " + item.LastName + " " + item.Country + " " + item.Sport + " " + item.Medal);
                            }

                            checkBoolShowEmpty(ref find);

                            Console.ReadKey();
                        }
                        continue;
                    case 5:
                        {
                            int id = TakeId();

                            var list = (from sport in db.ParticipantsSportsMedals
                                        where sport.SportId == id
                                        select sport).ToList();

                            Console.WriteLine("Name Medals Countries Partitiants");

                            if (list.Count > 0)
                            {
                                Console.WriteLine(list.First().Sport.Name + " " + list.GroupBy(m => m.MedalsId).Count() + " " + list.GroupBy(c => c.Participant.CountryId).Count() +
                                    " " + list.GroupBy(p => p.ParticipantId).Count());
                                find = true;
                            }
                            checkBoolShowEmpty(ref find);

                            //var list = (from sport in db.ParticipantsSportsMedals
                            //           where sport.SportId == id
                            //           group sport by sport.SportId into sportgroup
                            //           select sportgroup).ToList();

                            //foreach (var item in list)
                            //{
                            //    Console.WriteLine(item.First().Sport.Name + " " + item.GroupBy(m => m.MedalsId).Count() + " " + item.GroupBy(c => c.Participant.CountryId).Count() +
                            //        " " + item.GroupBy(p => p.ParticipantId).Count());
                            //}

                            //var list1 = (from sport in db.ParticipantsSportsMedals
                            //            where sport.SportId == id
                            //            group sport by sport.Sport.Name into sportgroup
                            //            select new
                            //            {
                            //                Name = (sportgroup.FirstOrDefault() == null ? "null" : sportgroup.FirstOrDefault().Sport.Name),
                            //                Medals = sportgroup.GroupBy(m => m.MedalsId).Count(),
                            //                Countries = sportgroup.GroupBy(c => c.Participant.CountryId).Count(),
                            //                Partitiants = sportgroup.GroupBy(p => p.ParticipantId).Count()
                            //            }).ToList();

                            //foreach (var item in list1)
                            //{
                            //    Console.WriteLine(item.Name + " " + item.Medals + " " + item.Countries + " " + item.Partitiants);
                            //}
                            //Console.WriteLine();
                            //Console.WriteLine();

                        }
                        Console.ReadKey();
                        continue;
                    case 6:
                        {
                            int id = TakeId();

                            var list = (from country in db.ParticipantsSportsMedals
                                        where country.Participant.CountryId == id
                                        select country).ToList();

                            Console.WriteLine("Name Sports Medals Participants");

                            if (list.Count > 0)
                            {
                                find = true;
                                Console.WriteLine(list.First().Participant.Country.Name + " " + list.OrderBy(s => s.SportId).Count() + " " + list.OrderBy(m => m.MedalsId).Count() +
                                    " " + list.OrderBy(p => p.ParticipantId).Count());
                            }

                            checkBoolShowEmpty(ref find);

                        }
                        Console.ReadKey();
                        continue;
                    case 7:
                        {
                            IEnumerable<Participants> list;

                            while (true)
                            {
                                Console.Clear();
                                Console.WriteLine("Enter action:" +
                                    "\n1. Find partition by Fistname" +
                                    "\n2. Find partition by Lastname" +
                                    "\n3. Back");

                                write = Int32.Parse(Console.ReadLine());

                                list = null;

                                switch (write)
                                {
                                    case 1:
                                        Console.Write("Enter Firstname => ");
                                        string name = Console.ReadLine();

                                        list = db.Participants.Where(p => p.FirstName.Contains(name)).ToList();

                                        break;
                                    case 2:
                                        Console.Write("Enter Lastname => ");
                                        string lastname = Console.ReadLine();

                                        list = db.Participants.Where(p => p.LastName.Contains(lastname)).ToList();

                                        break;
                                    default:
                                        break;
                                }
                                if (list != null)
                                {
                                    Console.WriteLine("Id FirstName LastName");

                                    foreach (Participants participant in list)
                                    {
                                        find = true;
                                        Console.WriteLine(participant.Id + " " + participant.FirstName + " " + participant.LastName);
                                    }
                                    checkBoolShowEmpty(ref find);
                                    Console.ReadKey();
                                    continue;
                                }
                                break;
                            }


                        }
                        continue;
                    case 8:
                        {
                            while (true)
                            {
                                Console.Clear();
                                Console.WriteLine("Enter Top Countries" +
                                    "\n1. Gold Medals" +
                                    "\n2. Silver Medals" +
                                    "\n3. Bronze Medals" +
                                    "\n4. Break");

                                write = Int32.Parse(Console.ReadLine());

                                switch (write)
                                {
                                    case 1:
                                        {
                                            var list = db.ParticipantsSportsMedals
                                                .Where(m => m.Medal.Type == Medal.Gold)
                                                .GroupBy(c => c.Participant.Country.Name)
                                                .Select(s => new { Name = s.Key, Medals = s.Count() })
                                                .OrderBy(s => s.Medals)
                                                .Distinct()
                                                .ToList();

                                            Console.WriteLine("Name Medals Type");

                                            foreach (var item in list)
                                            {
                                                find = true;
                                                Console.WriteLine(item.Name + " " + item.Medals + " " + "Gold");
                                            }
                                            checkBoolShowEmpty(ref find);
                                        }
                                        Console.ReadKey();
                                        continue;
                                    case 2:
                                        {
                                            var list = db.ParticipantsSportsMedals
                                                .Where(m => m.Medal.Type == Medal.Silver)
                                                .GroupBy(c => c.Participant.Country.Name)
                                                .Select(s => new { Name = s.Key, Medals = s.Count() })
                                                .OrderBy(s => s.Medals)
                                                .Distinct()
                                                .ToList();

                                            Console.WriteLine("Name Medals Type");

                                            foreach (var item in list)
                                            {
                                                find = true;
                                                Console.WriteLine(item.Name + " " + item.Medals + " " + "Silver");
                                            }
                                            checkBoolShowEmpty(ref find);
                                        }
                                        Console.ReadKey();
                                        continue;
                                    case 3:
                                        {
                                            var list = db.ParticipantsSportsMedals
                                                .Where(m => m.Medal.Type == Medal.Bronze)
                                                .GroupBy(c => c.Participant.Country.Name)
                                                .Select(s => new { Name = s.Key, Medals = s.Count() })
                                                .OrderBy(s => s.Medals)
                                                .Distinct()
                                                .ToList();

                                            Console.WriteLine("Name Medals Type");

                                            foreach (var item in list)
                                            {
                                                find = true;
                                                Console.WriteLine(item.Name + " " + item.Medals + " " + "Bronze");
                                            }
                                            checkBoolShowEmpty(ref find);
                                        }
                                        Console.ReadKey();
                                        continue;
                                    default:
                                        break;
                                }

                                break;
                            }
                        }
                        continue;
                    case 9:
                        {
                            while (true)
                            {
                                Console.Clear();
                                Console.WriteLine("Enter Top Sports" +
                                    "\n1. Gold Medals" +
                                    "\n2. Silver Medals" +
                                    "\n3. Bronze Medals" +
                                    "\n4. Break");

                                write = Int32.Parse(Console.ReadLine());

                                switch (write)
                                {
                                    case 1:
                                        {
                                            var list = db.ParticipantsSportsMedals
                                                .Where(m => m.Medal.Type == Medal.Gold)
                                                .GroupBy(c => c.Sport.Name)
                                                .Select(s => new { Name = s.Key, Medals = s.Count() })
                                                .OrderBy(s => s.Medals)
                                                .Distinct()
                                                .ToList();

                                            Console.WriteLine("Name Medals Type");

                                            foreach (var item in list)
                                            {
                                                find = true;
                                                Console.WriteLine(item.Name + " " + item.Medals + " " + "Gold");
                                            }
                                            checkBoolShowEmpty(ref find);
                                        }
                                        Console.ReadKey();
                                        continue;
                                    case 2:
                                        {
                                            var list = db.ParticipantsSportsMedals
                                                .Where(m => m.Medal.Type == Medal.Silver)
                                                .GroupBy(c => c.Sport.Name)
                                                .Select(s => new { Name = s.Key, Medals = s.Count() })
                                                .OrderBy(s => s.Medals)
                                                .Distinct()
                                                .ToList();

                                            Console.WriteLine("Name Medals Type");

                                            foreach (var item in list)
                                            {
                                                find = true;
                                                Console.WriteLine(item.Name + " " + item.Medals + " " + "Silver");
                                            }
                                            checkBoolShowEmpty(ref find);
                                        }
                                        Console.ReadKey();
                                        continue;
                                    case 3:
                                        {
                                            var list = db.ParticipantsSportsMedals
                                                    .Where(m => m.Medal.Type == Medal.Bronze)
                                                    .GroupBy(c => c.Sport.Name)
                                                    .Select(s => new { Name = s.Key, Medals = s.Count() })
                                                    .OrderBy(s => s.Medals)
                                                    .Distinct()
                                                    .ToList();

                                            Console.WriteLine("Name Medals Type");

                                            foreach (var item in list)
                                            {
                                                find = true;
                                                Console.WriteLine(item.Name + " " + item.Medals + " " + "Bronze");
                                            }
                                            checkBoolShowEmpty(ref find);
                                        }
                                        Console.ReadKey();
                                        continue;
                                    default:
                                        break;
                                }

                                break;
                            }
                        }
                        continue;
                    case 10:
                        {
                            var countryList = db.Countries.Select(c => new { c.Id, c.Name }).ToList();
                            Console.WriteLine("Enter country Id:");

                            foreach (var item in countryList)
                            {
                                Console.WriteLine(item.Id + ". " + item.Name);
                            }
                            int countryId = Int32.Parse(Console.ReadLine());
                            if (countryList.Where(c => c.Id == countryId).FirstOrDefault() != null)
                            {
                                
                                var list = db.ParticipantsSportsMedals
                                                    .Where(c => c.Participant.Country.Id == countryId)
                                                    .GroupBy(c => new { c.Participant.FirstName, c.Participant.LastName })
                                                    .Select(s => new 
                                                    { 
                                                        FirstName = s.Key.FirstName, 
                                                        LastName = s.Key.LastName,
                                                        Medals = s.Count()
                                                    })
                                                    .OrderBy(m => m.Medals)
                                                    .Distinct()
                                                    .ToList();

                                Console.WriteLine("Firstname Lastname Medals");

                                foreach (var item in list)
                                {
                                    find = true;
                                    Console.WriteLine(item.FirstName + " " + item.LastName + " " + item.Medals);
                                }
                                checkBoolShowEmpty(ref find);

                                Console.ReadKey();
                            }
                        }
                        continue;
                    case 11:
                        {
                            var countryList = db.Countries.Select(c => new { c.Id, c.Name }).ToList();
                            Console.WriteLine("Enter country Id:");

                            foreach (var item in countryList)
                            {
                                Console.WriteLine(item.Id + ". " + item.Name);
                            }
                            int countryId = Int32.Parse(Console.ReadLine());
                            if (countryList.Where(c => c.Id == countryId).FirstOrDefault() != null)
                            {

                                var list = db.ParticipantsSportsMedals
                                    .Where(c => c.Participant.Country.Id == countryId)
                                    .GroupBy(s => s.Sport.Name)
                                    .Select(s => new
                                    {
                                        Name = s.Key,
                                        Popularity = s.Count()
                                    })
                                    .OrderBy(p => p.Popularity)
                                    .Distinct()
                                    .ToList();

                                Console.WriteLine("Name Popularity");

                                foreach (var item in list)
                                {
                                    find = true;
                                    Console.WriteLine(item.Name + " " + item.Popularity);
                                }
                                checkBoolShowEmpty(ref find);

                                Console.ReadKey();
                            }
                        }
                        continue;
                    default:
                        break;
                }
                break;
            }

        }

        private static int TakeId()
        {
            Console.Write("Enter Id => ");
            return Int32.Parse(Console.ReadLine());
        }

        private static void checkBoolShowEmpty(ref bool find)
        {
            if (!find)
            {
                Console.WriteLine("Table is Empty");
            }
            find = false;
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

            db.SaveChanges();
        }

        private static void AddMedals(OlympContext db)
        {
            db.Medals.Add(new Medals { Type = Medal.Gold });
            db.Medals.Add(new Medals { Type = Medal.Silver });
            db.Medals.Add(new Medals { Type = Medal.Bronze });
            db.Medals.Add(new Medals { Type = Medal.No });

            db.SaveChanges();
        }

        private static void AddParticipants(OlympContext db)
        {
            db.Participants.Add(new Participants { FirstName = "Dmitriy", LastName = "Kokorin", CountryId = db.Countries.Where(c => c.Name == "Russia").First().Id });
            db.Participants.Add(new Participants { FirstName = "Mamed", LastName = "Mamedov", CountryId = db.Countries.Where(c => c.Name == "Azerbaijan").First().Id });
            db.Participants.Add(new Participants { FirstName = "Veronika", LastName = "Kolesnikova", CountryId = db.Countries.Where(c => c.Name == "Russia").First().Id });

            db.SaveChanges();
        }

        private static void AddParticipantsSportsMedals(OlympContext db)
        {
            db.ParticipantsSportsMedals.Add(new ParticipantsSportsMedals
            {
                MedalsId = db.Medals.Where(m => m.Type == Medal.Gold).First().Id,
                ParticipantId = db.Participants.Where(p => p.FirstName == "Dmitriy" && p.LastName == "Kokorin").First().Id,
                SportId = db.Sports.Where(s => s.Name == "Basketball").First().Id
            });
            db.ParticipantsSportsMedals.Add(new ParticipantsSportsMedals
            {
                MedalsId = db.Medals.Where(m => m.Type == Medal.Silver).First().Id,
                ParticipantId = db.Participants.Where(p => p.FirstName == "Veronika" && p.LastName == "Kolesnikova").First().Id,
                SportId = db.Sports.Where(s => s.Name == "Basketball").First().Id
            });

            db.SaveChanges();
        }

        private static void AddSports(OlympContext db)
        {
            db.Sports.Add(new Sports { Name = "Basketball" });

            db.SaveChanges();
        }
    }
}

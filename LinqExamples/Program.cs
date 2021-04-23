using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExamples {

    class State {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    class City {
        public string Name { get; set; }
        public int StateId { get; set; }
    }
    class Program {
        static void Main(string[] args) {

            var states = new List<State> {
                new State { Id = 1, Name = "Ohio" },
                new State { Id = 2, Name = "Kentucky" },
                new State { Id = 3, Name = "Indiana" }
            };
            var cities = new List<City> {
                new City { Name = "Cincinnati", StateId = 1 },
                new City { Name = "Columbus", StateId = 1 },
                new City { Name = "Cleveland", StateId = 1 },
                new City { Name = "Newport", StateId = 2 },
                new City { Name = "Covington", StateId = 2 },
                new City { Name = "Indianapolis", StateId = 3 }
            };

            var citiesStates = from s in states
                               join c in cities
                               on s.Id equals c.StateId
                               select new {
                                   City = c.Name, State = s.Name
                               };
            foreach(var cs in citiesStates.ToList()) {
                Console.WriteLine($"City/State is {cs.City} {cs.State}");
            }

            var nbrs = new List<int> {
                268,876,510,365,219,299,489,390,965,993,
                419,726,282,926,681,206,263,481,501,456,
                744,976,792,201,674,595,805,360,973,203,
                913,747,356,437,897,170,151,906,684,763,
                369,332,215,660,666,366,272,127,543,803,
                175,823,119,427,963,478,553,903,384,220,
                471,164,401,236,539,845,805,489,209,273,
                944,261,529,570,206,401,157,870,266,861,
                411,487,600,702,177,829,810,371,932,262,
                286,467,834,303,842,544,659,738,431,458
            };


            // sum nbrs divisible by 3 or 7
            var sumDivBy3or7 = nbrs.Where(n => n % 3 == 0 || n % 7 == 0)
                                    .Sum();
            sumDivBy3or7 = (from n in nbrs
                            where n % 3 == 0 || n % 7 == 0
                            select n).Sum();

            // avg of nbrs gte 500
            var avgGte500 = nbrs.Where(n => n >= 500).Average();
            avgGte500 = (from n in nbrs
                         where n >= 500
                         select n).Average();
            var nbrsGte500 = from n in nbrs
                             where n >= 500
                             select n;
            avgGte500 = nbrsGte500.Average();

            var ints = new int[] { 1, 3, 5, 7, 9, 11, 13, 17 };

            // are all ints odd?
            var allAreOdd = ints.All(i => i % 2 == 1);

            // the avg of nbrs lte 11
            var avgLte11 = ints.Where(i => i <= 11).Average();
            avgLte11 = (from anInt in ints
                        where anInt <= 11
                        select anInt).Average();

            // the sum of nbrs gt 7
            var sumGt7 = ints.Where(i => i > 7).Sum();
            sumGt7 = (from i in ints
                      where i > 7
                      select i).Sum();


            var max = ints.Max();
            var min = ints.Min();
            var sum = ints.Sum();
            var avg = ints.Average();
            var cnt = ints.Count();
        }
    }
}

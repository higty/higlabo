using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Mapper.PerformanceTest
{
    public class Person
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Emails { get; set; }

        public Person Parent { get; set; }

        public static Person Create()
        {
            var p = new Person();
            p.Id = Guid.NewGuid();
            p.FirstName = "Joe";
            p.LastName = "Mickelson";
            p.Emails = "joe@email.com";
            return p;
        }
    }

    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public GpsPosition Gps { get; set; }
    }

    public class AddressDTO
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public GpsPosition Gps { get; set; }
    }
    public struct GpsPosition
    {
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }

        public GpsPosition(double latitude, double longitude)
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
        }
    }

    public class Customer
    {
        public static readonly Random Random = new Random();
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Credit { get; set; }
        public Customer RootCustomer { get; set; }
        public Address Address { get; set; }
        public Address HomeAddress { get; set; }
        public Address[] Addresses { get; set; }
        public ICollection<Address> WorkAddresses { get; set; }

        public static Customer Create()
        {
            Customer customer = new Customer()
            {
                Id = 1,
                Name = "Timucin Kivanc " + GetRandomNumber(),
                Credit = 234.7m,
                Address = new Address()
                {
                    City = "Istanbul " + GetRandomNumber(),
                    Country = "Turkey " + GetRandomNumber(),
                    Id = 1,
                    Street = "Istiklal cad. " + GetRandomNumber(),
                    Gps = new GpsPosition(139, 36),
                }
            };
            customer.RootCustomer = new Customer()
            {
                Id = 1,
                Name = "Robelt Evani " + GetRandomNumber(),
                Credit = 234.7m,
                Address = new Address()
                {
                    City = "Milano " + GetRandomNumber(),
                    Country = "Italy " + GetRandomNumber(),
                    Id = 1,
                    Street = "Rosso street. " + GetRandomNumber(),
                    Gps = new GpsPosition(23, 40.66),
                }
            };

            customer.HomeAddress = new Address()
            {
                City = "Istanbul " + GetRandomNumber(),
                Country = "Turkey " + GetRandomNumber(),
                Id = 2,
                Street = "Istiklal cad. " + GetRandomNumber(),
                Gps = new GpsPosition(-69, -60),
            };
            customer.WorkAddresses = new Address[]
            {
                new Address()
                {
                    City = "Istanbul " + GetRandomNumber(),
                    Country = "Turkey " + GetRandomNumber(),
                    Id = 5,
                    Street = "Istiklal cad. " + GetRandomNumber(),
                    Gps = new GpsPosition(13.35, 49.3),
                },
                new Address()
                {
                    City = "Izmir " + GetRandomNumber(),
                    Country = "Turkey " + GetRandomNumber(),
                    Id = 6,
                    Street = "Konak " + GetRandomNumber(),
                    Gps = new GpsPosition(3.91, 72.55),
            }
            };
            customer.Addresses = new Address[]
            {
                new Address()
                {
                    City = "Istanbul " + GetRandomNumber(),
                    Country = "Turkey " + GetRandomNumber(),
                    Id = 3,
                    Street = "Istiklal cad. " + GetRandomNumber(),
                    Gps = new GpsPosition(145, 36),
                },
                new Address()
                {
                    City = "Izmir " + GetRandomNumber(),
                    Country = "Turkey " + GetRandomNumber(),
                    Id = 4,
                    Street = "Konak " + GetRandomNumber(),
                    Gps = new GpsPosition(93, 60),
                }
            };

            return customer;
        }
        private static Int32 GetRandomNumber()
        {
            return Random.Next(100);
        }
    }

    public class CustomerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Customer RootCustomer { get; set; }
        public Address Address { get; set; }
        public AddressDTO HomeAddress { get; set; }
        public AddressDTO[] Addresses { get; set; }
        public List<AddressDTO> WorkAddresses { get; set; }
        public string AddressCity { get; set; }
    }
}

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
    }

    public class AddressDTO
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }

    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Credit { get; set; }
        public Address Address { get; set; }
        public Address HomeAddress { get; set; }
        public Address[] Addresses { get; set; }
        public ICollection<Address> WorkAddresses { get; set; }

        public static Customer Create()
        {
            Customer customer = new Customer()
            {
                Id = 1,
                Name = "Timucin Kivanc",
                Credit = 234.7m,
                Address = new Address()
                {
                    City = "Istanbul",
                    Country = "Turkey",
                    Id = 1,
                    Street = "Istiklal cad."
                }
            };
            customer.HomeAddress = new Address()
            {
                City = "Istanbul",
                Country = "Turkey",
                Id = 2,
                Street = "Istiklal cad."
            };
            customer.WorkAddresses = new Address[]
            {
            new Address() {
                City = "Istanbul",
                Country = "Turkey",
                Id = 5,
                Street = "Istiklal cad."
            },
            new Address() {
                City = "Izmir",
                Country = "Turkey",
                Id = 6,
                Street = "Konak"
            }
            };
            customer.Addresses = new Address[]
            {
            new Address()
            {
                City = "Istanbul",
                Country = "Turkey",
                Id = 3,
                Street = "Istiklal cad."
            },
            new Address()
            {
                City = "Izmir",
                Country = "Turkey",
                Id = 4,
                Street = "Konak"
            }
            };

            return customer;
        }
    }

    public class CustomerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
        public AddressDTO HomeAddress { get; set; }
        public AddressDTO[] Addresses { get; set; }
        public List<AddressDTO> WorkAddresses { get; set; }
        public string AddressCity { get; set; }
    }
}

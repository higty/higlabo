using FastMapper;
using HigLabo.Core;
using Mapster;
using Nelibur.ObjectMapper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgileObjects;
using BenchmarkDotNet.Attributes;

namespace HigLabo.Mapper.PerformanceTest
{
    public class MapperPerformanceTest
    {
        public static readonly Int32 ExecuteCount = 1000;

        [Setup]
        public static void Setup()
        {
            AutoMapper.Mapper.Initialize(config =>
            {
                config.CreateMap<Customer, CustomerDTO>();
                config.CreateMap<Address, AddressDTO>();
            });
            TinyMapper.Bind<Customer, CustomerDTO>();
            TinyMapper.Bind<Address, AddressDTO>();

            ObjectMapConfig.Current.NullPropertyMapMode = NullPropertyMapMode.NewObject;
            ObjectMapConfig.Current.CollectionElementMapMode = CollectionElementMapMode.NewObject;
            var customerDto = ObjectMapConfig.Current.Map(Customer.Create(), new CustomerDTO());
        }
        public static void HandwriteMapperTest()
        {
            var customer = Customer.Create();
            var count = ExecuteCount;
            var config = ObjectMapConfig.Current;
            config.CollectionElementMapMode = CollectionElementMapMode.DeepCopy;
            for (int i = 0; i < count; i++)
            {
                var customerDto = new CustomerDTO();
                customerDto.Id = customer.Id;
                customerDto.Name = customer.Name;
                customerDto.Address = new Address();
                customerDto.Address.Id = customer.Address.Id;
                customerDto.Address.Street = customer.Address.Street;
                customerDto.Address.City = customer.Address.City;
                customerDto.Address.Country = customer.Address.Country;
                customerDto.Addresses = new AddressDTO[customer.Addresses.Length];
                for (int aIndex = 0; aIndex < customer.Addresses.Length; aIndex++)
                {
                    customerDto.Addresses[aIndex] = new AddressDTO();
                    customerDto.Addresses[aIndex].Id = customer.Addresses[aIndex].Id;
                    customerDto.Addresses[aIndex].City = customer.Addresses[aIndex].City;
                    customerDto.Addresses[aIndex].Country = customer.Addresses[aIndex].Country;
                }
                customerDto.HomeAddress = new AddressDTO();
                customerDto.HomeAddress.Id = customerDto.HomeAddress.Id;
                customerDto.HomeAddress.City = customerDto.HomeAddress.City;
                customerDto.HomeAddress.Country = customerDto.HomeAddress.Country;
                customerDto.WorkAddresses = new List<AddressDTO>();
                foreach (var item in customer.WorkAddresses)
                {
                    customerDto.WorkAddresses.Add(new AddressDTO()
                    {
                        Id = item.Id,
                        City = item.City,
                        Country = item.Country,
                    });
                }
            }
        }
        [Benchmark]
        public static void HigLaboMapperTest()
        {
            var customer = Customer.Create();
            var count = ExecuteCount;
            var config = ObjectMapConfig.Current;
            for (int i = 0; i < count; i++)
            {
                var customerDto = config.Map(customer, new CustomerDTO());
            }
        }
        [Benchmark]
        public static void TinyMapperTest()
        {
            var customer = Customer.Create();
            var count = ExecuteCount;

            for (int i = 0; i < count; i++)
            {
                var customerDto = TinyMapper.Map<CustomerDTO>(customer);
            }
        }
        [Benchmark]
        public static void AutoMapperTest()
        {
            var customer = Customer.Create();
            var count = ExecuteCount;

            for (int i = 0; i < count; i++)
            {
                var customerDto = AutoMapper.Mapper.Map<CustomerDTO>(customer);
            }
        }
        public static void MapsterTest()
        {
            var customer = Customer.Create();
            var count = ExecuteCount;
            for (int i = 0; i < count; i++)
            {
                var customerDto = Mapster.TypeAdapter.Adapt<CustomerDTO>(customer);
            }
        }
        public static void AgileMapperTest()
        {
            var customer = Customer.Create();
            var count = ExecuteCount;
            for (int i = 0; i < count; i++)
            {
                var customerDto = AgileObjects.AgileMapper.Mapper.Map<Customer>(customer).ToANew<CustomerDTO>();
            }
        }
        public static void ExpressMapperTest()
        {
            var customer = Customer.Create();
            var count = ExecuteCount;

            for (int i = 0; i < count; i++)
            {
                var customerDto = ExpressMapper.Mapper.Map<Customer, CustomerDTO>(customer);
            }
        }
        public static void FastMapperTest()
        {
            var customer = Customer.Create();
            var count = ExecuteCount;
            for (int i = 0; i < count; i++)
            {
                var customerDto = FastMapper.TypeAdapter.Adapt<Customer, CustomerDTO>(customer);
            }
        }
    }
}

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
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Jobs;

namespace HigLabo.Mapper.PerformanceTest
{
    public class BenchmarkConfig : ManualConfig
    {
        public BenchmarkConfig()
        {
            AddExporter(MarkdownExporter.GitHub); 
            AddDiagnoser(MemoryDiagnoser.Default);

            //AddJob(Job.ShortRun);
        }
    }
    [Config(typeof(BenchmarkConfig))]
    public class MapperPerformanceTest
    {
        private AutoMapper.MapperConfiguration _AutoMapperConfiguration = null;

        public static readonly Int32 ExecuteCount = 1000;

        public AutoMapper.IMapper AutoMapper = null;
        public Customer Customer = null;
        public Address Address = null;
        public TC0_Members TC0_Members = null; 

        [GlobalSetup]
        public void Setup()
        {
            _AutoMapperConfiguration = new AutoMapper.MapperConfiguration(config => {
                config.CreateMap<Customer, Customer>();
                config.CreateMap<Customer, CustomerDTO>();
                config.CreateMap<Address, AddressDTO>();
            });
            this.AutoMapper = _AutoMapperConfiguration.CreateMapper();

            TinyMapper.Bind<Address, Address>();
            TinyMapper.Bind<Address, AddressDTO>();
            TinyMapper.Bind<Customer, Customer>();
            TinyMapper.Bind<Customer, CustomerDTO>();

            HigLabo.Core.ObjectMapper.Default.CompilerConfig.ClassPropertyCreateMode = ClassPropertyCreateMode.NewObject;
            HigLabo.Core.ObjectMapper.Default.CompilerConfig.CollectionElementCreateMode = CollectionElementCreateMode.NewObject;

            this.Customer = Customer.Create();
            this.Address = Address.Create();
            this.TC0_Members = TC0_Members.Create();
        }

        [Benchmark(Baseline = true)]
        public void HandwriteMapper_Address()
        {
            var address = Address.Create();
            for (int i = 0; i < ExecuteCount; i++)
            {
                this.MapAddress(address, new Address());
            }
        }
        private void MapAddress(Address address, Address addressTo)
        {
            addressTo.Id = address.Id;
            addressTo.City = address.City;
            addressTo.Country = address.Country;
            addressTo.AddressType = address.AddressType;
        }
        [Benchmark]
        public void HigLaboObjectMapper_Address()
        {
            var mapper = ObjectMapper.Default;
            var md = mapper.GetMapMethod<Address, Address>();
            for (int i = 0; i < ExecuteCount; i++)
            {
                var r = md(mapper, this.Address, new Address());
            }
        }
        [Benchmark]
        public void Mapperly_Address()
        {
            var mapper = new MapperlyMapper();
            for (int i = 0; i < ExecuteCount; i++)
            {
                var r = mapper.AddressToAddress(this.Address);
            }
        }
        [Benchmark]
        public void Mapster_Address()
        {
            for (int i = 0; i < ExecuteCount; i++)
            {
                var r = this.Address.Adapt(new Address());
            }
        }
        [Benchmark]
        public void AutoMapper_Address()
        {
            for (int i = 0; i < ExecuteCount; i++)
            {
                var r = this.AutoMapper.Map<Address>(this.Address);
            }
        }
        [Benchmark]
        public void ExpressMapper_Address()
        {
            for (int i = 0; i < ExecuteCount; i++)
            {
                var addressDto = ExpressMapper.Mapper.Map<Address, Address>(this.Address);
            }
        }
        [Benchmark]
        public void AgileMapper_Address()
        {
            for (int i = 0; i < ExecuteCount; i++)
            {
                var addressDto = AgileObjects.AgileMapper.Mapper.Map(this.Address).ToANew<Address>();
            }
        }
        [Benchmark]
        public void FastMapper_Address()
        {
            for (int i = 0; i < ExecuteCount; i++)
            {
                var addressDto = FastMapper.TypeAdapter.Adapt<Address, Address>(this.Address);
            }
        }
		[Benchmark]
		public void TinyMapper_Address()
        {
            for (int i = 0; i < ExecuteCount; i++)
            {
                var addressDto = TinyMapper.Map<Address>(this.Address);
            }
        }

        [Benchmark]
        public void HandwriteMapper_AddressDTO()
        {
            var address = Address.Create();
            for (int i = 0; i < ExecuteCount; i++)
            {
                this.MapAddressDTO(address, new AddressDTO());
            }
        }
        private void MapAddressDTO(Address address, AddressDTO addressDto)
        {
            addressDto.Id = address.Id;
            addressDto.City = address.City;
            addressDto.Country = address.Country;
            addressDto.AddressType = address.AddressType;
        }
        [Benchmark]
        public void HigLaboObjectMapper_AddressDTO()
        {
            var mapper = ObjectMapper.Default;
            var md = mapper.GetMapMethod<Address, AddressDTO>();
            for (int i = 0; i < ExecuteCount; i++)
            {
                var r = md(mapper, this.Address, new AddressDTO());
            }
        }
        [Benchmark]
        public void Mapperly_AddressDTO()
        {
            var mapper = new MapperlyMapper();
            for (int i = 0; i < ExecuteCount; i++)
            {
                var r = mapper.AddressToAddressDto(this.Address);
            }
        }
        [Benchmark]
        public void Mapster_AddressDTO()
        {
            for (int i = 0; i < ExecuteCount; i++)
            {
                var r = this.Address.Adapt(new AddressDTO());
            }
        }
        [Benchmark]
        public void AutoMapper_AddressDTO()
        {
            for (int i = 0; i < ExecuteCount; i++)
            {
                var r = this.AutoMapper.Map<AddressDTO>(this.Address);
            }
        }
        [Benchmark]
        public void ExpressMapper_AddressDTO()
        {
            for (int i = 0; i < ExecuteCount; i++)
            {
                var addressDto = ExpressMapper.Mapper.Map<Address, AddressDTO>(this.Address);
            }
        }
        [Benchmark]
        public void AgileMapper_AddressDTO()
        {
            for (int i = 0; i < ExecuteCount; i++)
            {
                var addressDto = AgileObjects.AgileMapper.Mapper.Map(this.Address).ToANew<AddressDTO>();
            }
        }
        [Benchmark]
        public void FastMapper_AddressDTO()
        {
            for (int i = 0; i < ExecuteCount; i++)
            {
                var addressDto = FastMapper.TypeAdapter.Adapt<Address, AddressDTO>(this.Address);
            }
        }
		[Benchmark]
		public void TinyMapper_AddressDTO()
        {
            for (int i = 0; i < ExecuteCount; i++)
            {
                var addressDto = TinyMapper.Map<AddressDTO>(this.Address);
            }
        }

        [Benchmark]
        public void HigLaboObjectMapper_Customer()
        {
            var mapper = ObjectMapper.Default;
            var md = mapper.GetMapMethod<Customer, Customer>();
            for (int i = 0; i < ExecuteCount; i++)
            {
                var r = md(mapper, this.Customer, new Customer());
            }
        }
        [Benchmark]
        public void Mapperly_Customer()
        {
            var mapper = new MapperlyMapper();
            for (int i = 0; i < ExecuteCount; i++)
            {
                var r = mapper.CustomerToCustomer(this.Customer);
            }
        }
        [Benchmark]
        public void Mapster_Customer()
        {
            for (int i = 0; i < ExecuteCount; i++)
            {
                var r = this.Customer.Adapt(new Customer());
            }
        }
        [Benchmark]
        public void AutoMapper_Customer()
        {
            for (int i = 0; i < ExecuteCount; i++)
            {
                var r = this.AutoMapper.Map<Customer>(this.Customer);
            }
        }
        [Benchmark]
        public void ExpressMapper_Customer()
        {
            var customer = Customer.Create();
            var count = ExecuteCount;

            for (int i = 0; i < count; i++)
            {
                var customerDto = ExpressMapper.Mapper.Map<Customer, Customer>(customer);
            }
        }
        [Benchmark]
        public void AgileMapper_Customer()
        {
            var customer = Customer.Create();
            var count = ExecuteCount;
            for (int i = 0; i < count; i++)
            {
                var customerDto = AgileObjects.AgileMapper.Mapper.Map<Customer>(customer).ToANew<Customer>();
            }
        }
        [Benchmark]
        public void FastMapper_Customer()
        {
            var customer = Customer.Create();
            var count = ExecuteCount;
            for (int i = 0; i < count; i++)
            {
                var customerDto = FastMapper.TypeAdapter.Adapt<Customer, Customer>(customer);
            }
        }
		[Benchmark]
		public void TinyMapper_Customer()
        {
            var customer = Customer.Create();
            var count = ExecuteCount;

            for (int i = 0; i < count; i++)
            {
                var customerDto = TinyMapper.Map<Customer>(customer);
            }
        }

        [Benchmark]
        public void HandwriteMapper_Customer_CustomerDTO()
        {
            var customer = Customer.Create();
            for (int i = 0; i < ExecuteCount; i++)
            {
                this.MapCustomer(customer, new CustomerDTO());
            }
        }
        private void MapCustomer(Customer customer, CustomerDTO customerDto)
        {
            customerDto.Id = customer.Id;
            customerDto.Name = customer.Name;
            customerDto.Address = new Address();
            customerDto.Address.Id = customer.Address.Id;
            customerDto.Address.Street = customer.Address.Street;
            customerDto.Address.City = customer.Address.City;
            customerDto.Address.Country = customer.Address.Country;
            customerDto.AddressList = new AddressDTO[customer.AddressList.Length];
            for (int aIndex = 0; aIndex < customer.AddressList.Length; aIndex++)
            {
                customerDto.AddressList[aIndex] = new AddressDTO();
                customerDto.AddressList[aIndex].Id = customer.AddressList[aIndex].Id;
                customerDto.AddressList[aIndex].City = customer.AddressList[aIndex].City;
                customerDto.AddressList[aIndex].Country = customer.AddressList[aIndex].Country;
            }
            customerDto.HomeAddress = new AddressDTO();
            customerDto.HomeAddress.Id = customerDto.HomeAddress.Id;
            customerDto.HomeAddress.City = customerDto.HomeAddress.City;
            customerDto.HomeAddress.Country = customerDto.HomeAddress.Country;
            customer.WorkAddressList = new List<Address>();
            foreach (var item in customer.WorkAddressList)
            {
                customerDto.WorkAddressList.Add(new AddressDTO()
                {
                    Id = item.Id,
                    City = item.City,
                    Country = item.Country,
                });
            }
            foreach (var item in customer.WorkAddressList)
            {
                customerDto.WorkAddressList.Add(new AddressDTO()
                {
                    Id = item.Id,
                    City = item.City,
                    Country = item.Country,
                });
            }
        }
        [Benchmark]
        public void HigLaboObjectMapper_Customer_CustomerDTO()
        {
            var mapper = ObjectMapper.Default;
            var md = mapper.GetMapMethod<Customer, CustomerDTO>();
            for (int i = 0; i < ExecuteCount; i++)
            {
                var r = md(mapper, this.Customer, new CustomerDTO());
            }
        }
        [Benchmark]
        public void Mapperly_Customer_CustomerDTO()
        {
            var mapper = new MapperlyMapper();
            for (int i = 0; i < ExecuteCount; i++)
            {
                var r = mapper.CustomerToCustomerDto(this.Customer);
            }
        }
        [Benchmark]
        public void Mapster_Customer_CustomerDTO()
        {
            for (int i = 0; i < ExecuteCount; i++)
            {
                var r = this.Customer.Adapt(new CustomerDTO());
            }
        }
        [Benchmark]
        public void AutoMapper_Customer_CustomerDTO()
        {
            for (int i = 0; i < ExecuteCount; i++)
            {
                var r = this.AutoMapper.Map<CustomerDTO>(this.Customer);
            }
        }

        [Benchmark]
        public void HigLaboObjectMapper_TC0_Members_To_Tc0_I0_MembersO()
        {
            for (int i = 0; i < ExecuteCount; i++)
            {
                var r = HigLabo.Core.ObjectMapper.Default.Map(this.TC0_Members, new TC0_I0_Members());
            }
        }
        [Benchmark]
        public void Mapster_TC0_Members_To_Tc0_I0_Members()
        {
            for (int i = 0; i < ExecuteCount; i++)
            {
                var r = this.TC0_Members.Adapt(new TC0_I0_Members());
            }
        }
    }
}

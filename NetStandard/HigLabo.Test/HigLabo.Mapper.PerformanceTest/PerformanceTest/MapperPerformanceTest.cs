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
            AddExporter(MarkdownExporter.GitHub); // ベンチマーク結果を書く時に出力させとくとベンリ
            AddDiagnoser(MemoryDiagnoser.Default);

            // ShortRunを使うとサクッと終わらせられる、デフォルトだと本気で長いので短めにしとく。
            // ShortRunは LaunchCount=1  TargetCount=3 WarmupCount = 3 のショートカット
            AddJob(Job.ShortRun);
        }
    }
    [Config(typeof(BenchmarkConfig))]
    public class MapperPerformanceTest
    {
        private AutoMapper.MapperConfiguration _AutoMapperConfiguration = null;

        public static readonly Int32 ExecuteCount = 20000;

        public AutoMapper.IMapper AutoMapper = null;
        public Customer Customer = null;
        public Address Address = null;

        [GlobalSetup]
        public void Setup()
        {
            _AutoMapperConfiguration = new AutoMapper.MapperConfiguration(config => {
                config.CreateMap<Customer, Customer>();
                config.CreateMap<Customer, CustomerDTO>();
                config.CreateMap<Address, AddressDTO>();
            });
            this.AutoMapper = _AutoMapperConfiguration.CreateMapper();

            TinyMapper.Bind<Customer, Customer>();
            TinyMapper.Bind<Customer, CustomerDTO>();
            TinyMapper.Bind<Address, AddressDTO>();

            HigLabo.Core.ObjectMapper.Default.CompilerConfig.ClassPropertyCreateMode = ClassPropertyCreateMode.NewObject;
            HigLabo.Core.ObjectMapper.Default.CompilerConfig.CollectionElementCreateMode = CollectionElementCreateMode.Assign;

            ObjectMapConfig.Current.ClassPropertyMapMode = ClassPropertyMapMode.NewObject;
            ObjectMapConfig.Current.CollectionElementMapMode = CollectionElementMapMode.NewObject;
            var customerDto = ObjectMapConfig.Current.Map(Customer.Create(), new CustomerDTO());

            this.Customer = Customer.Create();
            this.Address = Address.Create();
        }

        [Benchmark(Baseline = true)]
        public void HandwriteMapper_Address()
        {
            var address = Address.Create();
            for (int i = 0; i < ExecuteCount; i++)
            {
                this.MapAddress(address, new AddressDTO());
            }
        }
        private void MapAddress(Address address, AddressDTO addressDto)
        {
            addressDto.Id = address.Id;
            addressDto.City = address.City;
            addressDto.Country = address.Country;
        }
        [Benchmark]
        public void HigLaboObjectMapper_Address()
        {
            for (int i = 0; i < ExecuteCount; i++)
            {
                var r = HigLabo.Core.ObjectMapper.Default.Map(this.Address, new AddressDTO());
            }
        }
        public void HigLaboMapper_Address()
        {
            for (int i = 0; i < ExecuteCount; i++)
            {
                var r = ObjectMapConfig.Current.Map(this.Address, new AddressDTO());
            }
        }
        [Benchmark]
        public void Mapster_Address()
        {
            for (int i = 0; i < ExecuteCount; i++)
            {
                var r = this.Address.Adapt(new AddressDTO());
            }
        }
        [Benchmark]
        public void AutoMapper_Address()
        {
            for (int i = 0; i < ExecuteCount; i++)
            {
                var r = this.AutoMapper.Map<AddressDTO>(this.Address);
            }
        }

        public void HandwriteMapper_Customer()
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
        public void HigLaboObjectMapper_Customer()
        {
            for (int i = 0; i < ExecuteCount; i++)
            {
                var r = HigLabo.Core.ObjectMapper.Default.Map(this.Customer, new Customer());
            }
        }
        public void HigLaboMapper_Customer()
        {
            for (int i = 0; i < ExecuteCount; i++)
            {
                var r = ObjectMapConfig.Current.Map(this.Customer, new Customer());
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
        public void ExpressMapperTest()
        {
            var customer = Customer.Create();
            var count = ExecuteCount;

            for (int i = 0; i < count; i++)
            {
                var customerDto = ExpressMapper.Mapper.Map<Customer, Customer>(customer);
            }
        }
        public void AgileMapperTest()
        {
            var customer = Customer.Create();
            var count = ExecuteCount;
            for (int i = 0; i < count; i++)
            {
                var customerDto = AgileObjects.AgileMapper.Mapper.Map<Customer>(customer).ToANew<Customer>();
            }
        }
        public void FastMapperTest()
        {
            var customer = Customer.Create();
            var count = ExecuteCount;
            for (int i = 0; i < count; i++)
            {
                var customerDto = FastMapper.TypeAdapter.Adapt<Customer, Customer>(customer);
            }
        }
        public void TinyMapperTest()
        {
            var customer = Customer.Create();
            var count = ExecuteCount;

            for (int i = 0; i < count; i++)
            {
                var customerDto = TinyMapper.Map<Customer>(customer);
            }
        }

        [Benchmark]
        public void HigLaboObjectMapper_Customer_CustomerDTO()
        {
            for (int i = 0; i < ExecuteCount; i++)
            {
                var r = HigLabo.Core.ObjectMapper.Default.Map(this.Customer, new CustomerDTO());
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
        public void Mapster_Customer_CustomerDTO()
        {
            for (int i = 0; i < ExecuteCount; i++)
            {
                var r = this.Customer.Adapt(new CustomerDTO());
            }
        }
    }
}

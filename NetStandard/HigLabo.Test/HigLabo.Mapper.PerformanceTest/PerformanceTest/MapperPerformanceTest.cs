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

        public static readonly Int32 ExecuteCount = 10000;

        [GlobalSetup]
        public void Setup()
        {
            _AutoMapperConfiguration = new AutoMapper.MapperConfiguration(config => {
                config.CreateMap<Customer, CustomerDTO>();
                config.CreateMap<Address, AddressDTO>();
            });
            TinyMapper.Bind<Customer, CustomerDTO>();
            TinyMapper.Bind<Address, AddressDTO>();

            ObjectMapConfig.Current.ClassPropertyMapMode = ClassPropertyMapMode.NewObject;
            ObjectMapConfig.Current.CollectionElementMapMode = CollectionElementMapMode.NewObject;
            var customerDto = ObjectMapConfig.Current.Map(Customer.Create(), new CustomerDTO());
        }

        [Benchmark(Baseline = true)]
        public void HandwriteMapperTest()
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
                foreach (var item in customer.WorkAddresses)
                {
                    customerDto.WorkAddresses.Add(new AddressDTO()
                    {
                        Id = item.Id,
                        City = item.City,
                        Country = item.Country,
                    });
                }
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
        public void HigLaboMapperNewTest()
        {
            HigLabo.Core.Mapper.Default.Config.CollectionElementMapMode = CollectionElementMapMode.NewObject;

            var customer = Address.Create();
            var count = ExecuteCount;
            for (int i = 0; i < count; i++)
            {
                var customerDto = HigLabo.Core.Mapper.Default.Map(customer, new AddressDTO());
            }
        }
        public void HigLaboMapperTest()
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
        public void MapsterTest()
        {
            var customer = Address.Create();
            var count = ExecuteCount;
            for (int i = 0; i < count; i++)
            {
                var customerDto = customer.Adapt(new AddressDTO());
            }
        }
        public void AutoMapperTest()
        {
            var mapper = _AutoMapperConfiguration.CreateMapper();
            var customer = Customer.Create();
            var count = ExecuteCount;

            for (int i = 0; i < count; i++)
            {
                var customerDto = mapper.Map<CustomerDTO>(customer);
            }
        }
        public void ExpressMapperTest()
        {
            var customer = Customer.Create();
            var count = ExecuteCount;

            for (int i = 0; i < count; i++)
            {
                var customerDto = ExpressMapper.Mapper.Map<Customer, CustomerDTO>(customer);
            }
        }
        public void TinyMapperTest()
        {
            var customer = Customer.Create();
            var count = ExecuteCount;

            for (int i = 0; i < count; i++)
            {
                var customerDto = TinyMapper.Map<CustomerDTO>(customer);
            }
        }
        public void AgileMapperTest()
        {
            var customer = Customer.Create();
            var count = ExecuteCount;
            for (int i = 0; i < count; i++)
            {
                var customerDto = AgileObjects.AgileMapper.Mapper.Map<Customer>(customer).ToANew<CustomerDTO>();
            }
        }
        public void FastMapperTest()
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

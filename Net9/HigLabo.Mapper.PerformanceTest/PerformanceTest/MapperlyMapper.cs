using HigLabo.Mapper.TestNotSupported;
using Riok.Mapperly.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Mapper.PerformanceTest;

[Mapper]
public partial class MapperlyMapper
{
    public partial Address AddressToAddress(Address address);
    public partial AddressDTO AddressToAddressDto(Address address);
    public partial Customer CustomerToCustomer(Customer customer);
    public partial CustomerDTO CustomerToCustomerDto(Customer customer);
}

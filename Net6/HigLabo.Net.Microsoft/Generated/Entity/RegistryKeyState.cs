using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/registrykeystate?view=graph-rest-1.0
    /// </summary>
    public partial class RegistryKeyState
    {
        public enum RegistryKeyStateRegistryHive
        {
            Unknown,
            CurrentConfig,
            CurrentUser,
            LocalMachineSam,
            LocalMachineSecurity,
            LocalMachineSoftware,
            LocalMachineSystem,
            UsersDefault,
        }
        public enum RegistryKeyStateRegistryOperation
        {
            Unknown,
            Create,
            Modify,
            Delete,
        }
        public enum RegistryKeyStateRegistryValueType
        {
            Unknown,
            Binary,
            Dword,
            DwordLittleEndian,
            DwordBigEndian,
            ExpandSz,
            Link,
            MultiSz,
            None,
            Qword,
            QwordlittleEndian,
            Sz,
        }

        public RegistryKeyStateRegistryHive Hive { get; set; }
        public string? Key { get; set; }
        public string? OldKey { get; set; }
        public string? OldValueData { get; set; }
        public string? OldValueName { get; set; }
        public RegistryKeyStateRegistryOperation Operation { get; set; }
        public Int32? ProcessId { get; set; }
        public string? ValueData { get; set; }
        public string? ValueName { get; set; }
        public RegistryKeyStateRegistryValueType ValueType { get; set; }
    }
}

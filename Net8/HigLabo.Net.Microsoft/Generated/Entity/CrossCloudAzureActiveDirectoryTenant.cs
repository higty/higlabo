﻿using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/crosscloudazureactivedirectorytenant?view=graph-rest-1.0
    /// </summary>
    public partial class CrossCloudAzureActiveDirectoryTenant
    {
        public string? CloudInstance { get; set; }
        public string? DisplayName { get; set; }
        public string? TenantId { get; set; }
    }
}
﻿using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/internetexplorermode?view=graph-rest-1.0
    /// </summary>
    public partial class InternetExplorerMode
    {
        public BrowserSiteList[]? SiteLists { get; set; }
    }
}
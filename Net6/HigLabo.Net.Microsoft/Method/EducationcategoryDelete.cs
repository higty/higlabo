﻿using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EducationcategoryDeleteParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Education_Classes_Acdefc6b2dc64e71B1e96d9810ab1793_AssignmentCategories_Id: return $"/education/classes/acdefc6b-2dc6-4e71-b1e9-6d9810ab1793/assignmentCategories/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Education_Classes_Acdefc6b2dc64e71B1e96d9810ab1793_AssignmentCategories_Id,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
    }
    public partial class EducationcategoryDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationcategory-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationcategoryDeleteResponse> EducationcategoryDeleteAsync()
        {
            var p = new EducationcategoryDeleteParameter();
            return await this.SendAsync<EducationcategoryDeleteParameter, EducationcategoryDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationcategory-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationcategoryDeleteResponse> EducationcategoryDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new EducationcategoryDeleteParameter();
            return await this.SendAsync<EducationcategoryDeleteParameter, EducationcategoryDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationcategory-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationcategoryDeleteResponse> EducationcategoryDeleteAsync(EducationcategoryDeleteParameter parameter)
        {
            return await this.SendAsync<EducationcategoryDeleteParameter, EducationcategoryDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationcategory-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationcategoryDeleteResponse> EducationcategoryDeleteAsync(EducationcategoryDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationcategoryDeleteParameter, EducationcategoryDeleteResponse>(parameter, cancellationToken);
        }
    }
}
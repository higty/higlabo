﻿using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EducationUserDeleteParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Education_Users_Id: return $"/education/users/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Education_Users_Id,
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
    public partial class EducationUserDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationuser-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationUserDeleteResponse> EducationUserDeleteAsync()
        {
            var p = new EducationUserDeleteParameter();
            return await this.SendAsync<EducationUserDeleteParameter, EducationUserDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationuser-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationUserDeleteResponse> EducationUserDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new EducationUserDeleteParameter();
            return await this.SendAsync<EducationUserDeleteParameter, EducationUserDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationuser-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationUserDeleteResponse> EducationUserDeleteAsync(EducationUserDeleteParameter parameter)
        {
            return await this.SendAsync<EducationUserDeleteParameter, EducationUserDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationuser-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationUserDeleteResponse> EducationUserDeleteAsync(EducationUserDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationUserDeleteParameter, EducationUserDeleteResponse>(parameter, cancellationToken);
        }
    }
}
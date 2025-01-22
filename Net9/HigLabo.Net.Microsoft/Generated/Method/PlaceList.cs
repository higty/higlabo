using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/place-list?view=graph-rest-1.0
/// </summary>
public partial class PlaceListParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? RoomListEmailaddress { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Places_Microsoftgraphroom: return $"/places/microsoft.graph.room";
                case ApiPath.Places_Microsoftgraphroomlist: return $"/places/microsoft.graph.roomlist";
                case ApiPath.Places_RoomListEmailaddress_Microsoftgraphroomlist_Rooms: return $"/places/{RoomListEmailaddress}/microsoft.graph.roomlist/rooms";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Places_Microsoftgraphroom,
        Places_Microsoftgraphroomlist,
        Places_RoomListEmailaddress_Microsoftgraphroomlist_Rooms,
    }

    public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
    string IRestApiParameter.ApiPath
    {
        get
        {
            return this.ApiPathSetting.GetApiPath();
        }
    }
    string IRestApiParameter.HttpMethod { get; } = "GET";
    public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
    IQueryParameter IQueryParameterProperty.Query
    {
        get
        {
            return this.Query;
        }
    }
}
public partial class PlaceListResponse : RestApiResponse<Place>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/place-list?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/place-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PlaceListResponse> PlaceListAsync()
    {
        var p = new PlaceListParameter();
        return await this.SendAsync<PlaceListParameter, PlaceListResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/place-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PlaceListResponse> PlaceListAsync(CancellationToken cancellationToken)
    {
        var p = new PlaceListParameter();
        return await this.SendAsync<PlaceListParameter, PlaceListResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/place-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PlaceListResponse> PlaceListAsync(PlaceListParameter parameter)
    {
        return await this.SendAsync<PlaceListParameter, PlaceListResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/place-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PlaceListResponse> PlaceListAsync(PlaceListParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<PlaceListParameter, PlaceListResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/place-list?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<Place> PlaceListEnumerateAsync(PlaceListParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<PlaceListParameter, PlaceListResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<Place>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}

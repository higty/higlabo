using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/nameditem-range?view=graph-rest-1.0
/// </summary>
public partial class NamedItemRangeParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? ItemPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Me_Drive_Items_Id_Workbook_Names_Name_Range: return $"/me/drive/items/{Id}/workbook/names/{Name}/range";
                case ApiPath.Me_Drive_Root_ItemPath_Workbook_Names_Name_Range: return $"/me/drive/root:/{ItemPath}:/workbook/names/{Name}/range";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Me_Drive_Items_Id_Workbook_Names_Name_Range,
        Me_Drive_Root_ItemPath_Workbook_Names_Name_Range,
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
public partial class NamedItemRangeResponse : RestApiResponse
{
    public enum RangeJson
    {
        Unknown,
        Empty,
        String,
        Integer,
        Double,
        Boolean,
        Error,
    }

    public string? Address { get; set; }
    public string? AddressLocal { get; set; }
    public int? CellCount { get; set; }
    public int? ColumnCount { get; set; }
    public bool? ColumnHidden { get; set; }
    public int? ColumnIndex { get; set; }
    public Json? Formulas { get; set; }
    public Json? FormulasLocal { get; set; }
    public Json? FormulasR1C1 { get; set; }
    public bool? Hidden { get; set; }
    public Json? NumberFormat { get; set; }
    public int? RowCount { get; set; }
    public bool? RowHidden { get; set; }
    public int? RowIndex { get; set; }
    public Json? Text { get; set; }
    public RangeJson ValueTypes { get; set; }
    public Json? Values { get; set; }
    public RangeFormat? Format { get; set; }
    public RangeSort? Sort { get; set; }
    public Worksheet? Worksheet { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/nameditem-range?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/nameditem-range?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<NamedItemRangeResponse> NamedItemRangeAsync()
    {
        var p = new NamedItemRangeParameter();
        return await this.SendAsync<NamedItemRangeParameter, NamedItemRangeResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/nameditem-range?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<NamedItemRangeResponse> NamedItemRangeAsync(CancellationToken cancellationToken)
    {
        var p = new NamedItemRangeParameter();
        return await this.SendAsync<NamedItemRangeParameter, NamedItemRangeResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/nameditem-range?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<NamedItemRangeResponse> NamedItemRangeAsync(NamedItemRangeParameter parameter)
    {
        return await this.SendAsync<NamedItemRangeParameter, NamedItemRangeResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/nameditem-range?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<NamedItemRangeResponse> NamedItemRangeAsync(NamedItemRangeParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<NamedItemRangeParameter, NamedItemRangeResponse>(parameter, cancellationToken);
    }
}

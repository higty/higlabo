using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/identityuserflowattributeassignment?view=graph-rest-1.0
/// </summary>
public partial class IdentityUserFlowAttributeAssignment
{
    public enum IdentityUserFlowAttributeAssignmentIdentityUserFlowAttributeInputType
    {
        TextBox,
        DateTimeDropdown,
        RadioSingleSelect,
        DropdownSingleSelect,
        EmailBox,
        CheckboxMultiSelect,
    }

    public string? DisplayName { get; set; }
    public string? Id { get; set; }
    public bool? IsOptional { get; set; }
    public bool? RequiresVerification { get; set; }
    public UserAttributeValuesItem[]? UserAttributeValues { get; set; }
    public IdentityUserFlowAttributeAssignmentIdentityUserFlowAttributeInputType UserInputType { get; set; }
    public IdentityUserFlowAttribute? UserAttribute { get; set; }
}

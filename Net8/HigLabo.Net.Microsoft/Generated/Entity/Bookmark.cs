﻿using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/search-bookmark?view=graph-rest-1.0
/// </summary>
public partial class Bookmark
{
    public enum BookmarkDevicePlatformType
    {
        Android,
        AndroidForWork,
        Ios,
        MacOS,
        WindowsPhone81,
        WindowsPhone81AndLater,
        Windows10AndLater,
        AndroidWorkProfile,
        Unknown,
        AndroidASOP,
        AndroidMobileApplicationManagement,
        IOSMobileApplicationManagement,
        UnknownFutureValue,
    }
    public enum BookmarkSearchAnswerState
    {
        Published,
        Draft,
        Excluded,
        UnknownFutureValue,
    }

    public DateTimeOffset? AvailabilityEndDateTime { get; set; }
    public DateTimeOffset? AvailabilityStartDateTime { get; set; }
    public String[]? Categories { get; set; }
    public string? Description { get; set; }
    public string? DisplayName { get; set; }
    public String[]? GroupIds { get; set; }
    public bool? IsSuggested { get; set; }
    public string? Id { get; set; }
    public AnswerKeyword? Keywords { get; set; }
    public String[]? LanguageTags { get; set; }
    public IdentitySet? LastModifiedBy { get; set; }
    public DateTimeOffset? LastModifiedDateTime { get; set; }
    public BookmarkDevicePlatformType Platforms { get; set; }
    public String[]? PowerAppIds { get; set; }
    public BookmarkSearchAnswerState State { get; set; }
    public AnswerVariant[]? TargetedVariations { get; set; }
    public string? WebUrl { get; set; }
}

using System.Runtime.Serialization;

namespace HigLabo.X;

public enum UserField
{
    [EnumMember(Value = "created_at")]
    CreatedAt,
    Description,
    Entities,
    Id,
    Location,
    [EnumMember(Value = "most_recent_tweet_id")]
    MostRecentTweetId,
    Name,
    [EnumMember(Value = "pinned_tweet_id")]
    PinnedTweetId,
    [EnumMember(Value = "profile_image_url")]
    ProfileImageUrl,
    Protected,
    [EnumMember(Value = "public_metrics")]
    PublicMetrics,
    Url,
    Username,
    Verified,
    [EnumMember(Value = "verified_type")]
    VerifiedType,
}

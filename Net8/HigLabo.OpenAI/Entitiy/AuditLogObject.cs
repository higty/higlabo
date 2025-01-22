using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.OpenAI;

public class AuditLogObject
{
    public string Id { get; set; } = "";
    public string Type { get; set; } = "";
    public long Effective_At { get; set; }
    public Project? Project { get; set; }
    public Actor? Actor { get; set; }
    public ApiKeyEvent? Api_Key_Created { get; set; }
    public ApiKeyEvent? Api_Key_Updated { get; set; }
    public ApiKeyEvent? Api_Key_Deleted { get; set; }
    public InviteEvent? Invite_Sent { get; set; }
    public InviteEvent? Invite_Accepted { get; set; }
    public InviteEvent? Invite_Deleted { get; set; }
    public LoginEvent? Login_Failed { get; set; }
    public LogoutEvent? Logout_Failed { get; set; }
    public OrganizationUpdated? Organization_Updated { get; set; }
    public ProjectEvent? Project_Created { get; set; }
    public ProjectEvent? Project_Updated { get; set; }
    public ProjectEvent? Project_Archived { get; set; }
    public RateLimitEvent? Rate_Limit_Updated { get; set; }
    public RateLimitEvent? Rate_Limit_Deleted { get; set; }
    public ServiceAccountEvent? Service_Account_Created { get; set; }
    public ServiceAccountEvent? Service_Account_Updated { get; set; }
    public ServiceAccountEvent? Service_Account_Deleted { get; set; }
    public UserEvent? User_Added { get; set; }
    public UserEvent? User_Updated { get; set; }
    public UserEvent? User_Deleted { get; set; }
}

public class Project
{
    public string Id { get; set; } = "";
    public string Name { get; set; } = "";
}

public class Actor
{
    public string Type { get; set; } = ""; // Either "session" or "api_key"
    public Session? Session { get; set; }
    public ApiKey? Api_Key { get; set; }
    public ServiceAccount? Service_Account { get; set; }
}

public class Session
{
    public User? User { get; set; }
    public string Ip_Address { get; set; } = "";
    public string User_Agent { get; set; } = "";
}

public class ApiKey
{
    public string Id { get; set; } = "";
    public string Type { get; set; } = ""; // Either "user" or "service_account"
    public User? User { get; set; }
}

public class User
{
    public string Id { get; set; } = "";
    public string Email { get; set; } = "";
}

public class ServiceAccount
{
    public string Id { get; set; } = "";
}

public class ApiKeyEvent
{
    public string Id { get; set; } = "";
    public ApiKeyData? Data { get; set; }
    public ApiKeyChangesRequested? Changes_Requested { get; set; }
}

public class ApiKeyData
{
    public List<string> Scopes { get; set; } = new List<string>();
}

public class ApiKeyChangesRequested
{
    public List<string> Scopes { get; set; } = new List<string>();
}

public class InviteEvent
{
    public string Id { get; set; } = "";
    public InviteData? Data { get; set; }
}

public class InviteData
{
    public string Email { get; set; } = "";
    public string Role { get; set; } = ""; // Either "owner" or "member"
}

public class LoginEvent
{
    public string Error_Code { get; set; } = "";
    public string Error_Message { get; set; } = "";
}

public class LogoutEvent
{
    public string Error_Code { get; set; } = "";
    public string Error_Message { get; set; } = "";
}

public class OrganizationUpdated
{
    public string Id { get; set; } = "";
    public OrganizationChangesRequested? Changes_Requested { get; set; }
}

public class OrganizationChangesRequested
{
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public string Name { get; set; } = "";
    public OrganizationSettings? Settings { get; set; }
}

public class OrganizationSettings
{
    public string Threads_UI_Visibility { get; set; } = ""; // ANY_ROLE, OWNERS, or NONE
    public string Usage_Dashboard_Visibility { get; set; } = ""; // ANY_ROLE or OWNERS
}

public class ProjectEvent
{
    public string Id { get; set; } = "";
    public ProjectData? Data { get; set; }
    public ProjectChangesRequested? Changes_Requested { get; set; }
}

public class ProjectData
{
    public string Name { get; set; } = "";
    public string Title { get; set; } = "";
}

public class ProjectChangesRequested
{
    public string Title { get; set; } = "";
}

public class RateLimitEvent
{
    public string Id { get; set; } = "";
    public RateLimitChangesRequested? Changes_Requested { get; set; }
}

public class RateLimitChangesRequested
{
    public int Max_Requests_Per_1_Minute { get; set; }
    public int Max_Tokens_Per_1_Minute { get; set; }
    public int Max_Images_Per_1_Minute { get; set; }
    public int Max_Audio_Megabytes_Per_1_Minute { get; set; }
    public int Max_Requests_Per_1_Day { get; set; }
    public int Batch_1_Day_Max_Input_Tokens { get; set; }
}

public class ServiceAccountEvent
{
    public string Id { get; set; } = "";
    public ServiceAccountData? Data { get; set; }
    public ServiceAccountChangesRequested? Changes_Requested { get; set; }
}

public class ServiceAccountData
{
    public string Role { get; set; } = ""; // Either "owner" or "member"
}

public class ServiceAccountChangesRequested
{
    public string Role { get; set; } = ""; // Either "owner" or "member"
}

public class UserEvent
{
    public string Id { get; set; } = "";
    public UserData? Data { get; set; }
    public UserChangesRequested? Changes_Requested { get; set; }
}

public class UserData
{
    public string Role { get; set; } = ""; // Either "owner" or "member"
}

public class UserChangesRequested
{
    public string Role { get; set; } = ""; // Either "owner" or "member"
}
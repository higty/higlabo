using HigLabo.Core;

namespace HigLabo.Net.Slack
{
    public enum Scope
    {
        Admin,
        AdminAnalyticsRead,
        AdminAppsRead,
        AdminAppsWrite,
        AdminBarriersRead,
        AdminBarriersWrite,
        AdminConversationsRead,
        AdminConversationsWrite,
        AdminInvitesRead,
        AdminInvitesWrite,
        AdminRolesRead,
        AdminRolesWrite,
        AdminTeamsRead,
        AdminTeamsWrite,
        AdminUsergroupsRead,
        AdminUsergroupsWrite,
        AdminUsersRead,
        AdminUsersWrite,
        AdminWorkflowsRead,
        AdminWorkflowsWrite,
        App_configurationsRead,
        App_configurationsWrite,
        App_mentionsRead,
        AuditlogsRead,
        AuthorizationsRead,
        BookmarksRead,
        BookmarksWrite,
        Bot,
        CallsRead,
        CallsWrite,
        ChannelsHistory,
        ChannelsJoin,
        ChannelsManage,
        ChannelsRead,
        ChannelsWrite,
        ChannelsWriteInvites,
        ChannelsWriteTopic,
        ChatWrite,
        ChatWriteCustomize,
        ChatWritePublic,
        ChatWriteBot,
        ChatWriteUser,
        Commands,
        ConnectionsWrite,
        ConversationsConnectManage,
        ConversationsConnectRead,
        ConversationsConnectWrite,
        ConversationsWriteInvites,
        ConversationsWriteTopic,
        DndRead,
        DndWrite,
        DndWriteUser,
        Email,
        EmojiRead,
        FilesRead,
        FilesWrite,
        FilesWriteUser,
        GroupsHistory,
        GroupsRead,
        GroupsWrite,
        GroupsWriteInvites,
        GroupsWriteTopic,
        Identify,
        IdentityAvatar,
        IdentityAvatarReadUser,
        IdentityBasic,
        IdentityEmail,
        IdentityEmailReadUser,
        IdentityTeam,
        IdentityTeamReadUser,
        IdentityReadUser,
        ImHistory,
        ImRead,
        ImWrite,
        IncomingWebhook,
        LinksEmbedWrite,
        LinksRead,
        LinksWrite,
        MetadataMessageRead,
        MpimHistory,
        MpimRead,
        MpimWrite,
        MpimWriteInvites,
        MpimWriteTopic,
        None,
        Openid,
        PinsRead,
        PinsWrite,
        Profile,
        ReactionsRead,
        ReactionsWrite,
        RemindersRead,
        RemindersReadUser,
        RemindersWrite,
        RemindersWriteUser,
        Remote_filesRead,
        Remote_filesShare,
        Remote_filesWrite,
        SearchRead,
        StarsRead,
        StarsWrite,
        TeamBillingRead,
        TeamPreferencesRead,
        TeamRead,
        TokensBasic,
        TriggersRead,
        TriggersWrite,
        UsergroupsRead,
        UsergroupsWrite,
        UsersProfileRead,
        UsersProfileWrite,
        UsersProfileWriteUser,
        UsersRead,
        UsersReadEmail,
        UsersWrite,
        WorkflowStepsExecute,
    }
    public static class ScopeExtensions
    {
        public static string GetScopeName(this Scope value)
        {
            switch(value)
            {
                case Scope.Admin: return "admin";
                case Scope.AdminAnalyticsRead: return "admin.analytics:read";
                case Scope.AdminAppsRead: return "admin.apps:read";
                case Scope.AdminAppsWrite: return "admin.apps:write";
                case Scope.AdminBarriersRead: return "admin.barriers:read";
                case Scope.AdminBarriersWrite: return "admin.barriers:write";
                case Scope.AdminConversationsRead: return "admin.conversations:read";
                case Scope.AdminConversationsWrite: return "admin.conversations:write";
                case Scope.AdminInvitesRead: return "admin.invites:read";
                case Scope.AdminInvitesWrite: return "admin.invites:write";
                case Scope.AdminRolesRead: return "admin.roles:read";
                case Scope.AdminRolesWrite: return "admin.roles:write";
                case Scope.AdminTeamsRead: return "admin.teams:read";
                case Scope.AdminTeamsWrite: return "admin.teams:write";
                case Scope.AdminUsergroupsRead: return "admin.usergroups:read";
                case Scope.AdminUsergroupsWrite: return "admin.usergroups:write";
                case Scope.AdminUsersRead: return "admin.users:read";
                case Scope.AdminUsersWrite: return "admin.users:write";
                case Scope.AdminWorkflowsRead: return "admin.workflows:read";
                case Scope.AdminWorkflowsWrite: return "admin.workflows:write";
                case Scope.App_configurationsRead: return "app_configurations:read";
                case Scope.App_configurationsWrite: return "app_configurations:write";
                case Scope.App_mentionsRead: return "app_mentions:read";
                case Scope.AuditlogsRead: return "auditlogs:read";
                case Scope.AuthorizationsRead: return "authorizations:read";
                case Scope.BookmarksRead: return "bookmarks:read";
                case Scope.BookmarksWrite: return "bookmarks:write";
                case Scope.Bot: return "bot";
                case Scope.CallsRead: return "calls:read";
                case Scope.CallsWrite: return "calls:write";
                case Scope.ChannelsHistory: return "channels:history";
                case Scope.ChannelsJoin: return "channels:join";
                case Scope.ChannelsManage: return "channels:manage";
                case Scope.ChannelsRead: return "channels:read";
                case Scope.ChannelsWrite: return "channels:write";
                case Scope.ChannelsWriteInvites: return "channels:write.invites";
                case Scope.ChannelsWriteTopic: return "channels:write.topic";
                case Scope.ChatWrite: return "chat:write";
                case Scope.ChatWriteCustomize: return "chat:write.customize";
                case Scope.ChatWritePublic: return "chat:write.public";
                case Scope.ChatWriteBot: return "chat:write:bot";
                case Scope.ChatWriteUser: return "chat:write:user";
                case Scope.Commands: return "commands";
                case Scope.ConnectionsWrite: return "connections:write";
                case Scope.ConversationsConnectManage: return "conversations.connect:manage";
                case Scope.ConversationsConnectRead: return "conversations.connect:read";
                case Scope.ConversationsConnectWrite: return "conversations.connect:write";
                case Scope.ConversationsWriteInvites: return "conversations:write.invites";
                case Scope.ConversationsWriteTopic: return "conversations:write.topic";
                case Scope.DndRead: return "dnd:read";
                case Scope.DndWrite: return "dnd:write";
                case Scope.DndWriteUser: return "dnd:write:user";
                case Scope.Email: return "email";
                case Scope.EmojiRead: return "emoji:read";
                case Scope.FilesRead: return "files:read";
                case Scope.FilesWrite: return "files:write";
                case Scope.FilesWriteUser: return "files:write:user";
                case Scope.GroupsHistory: return "groups:history";
                case Scope.GroupsRead: return "groups:read";
                case Scope.GroupsWrite: return "groups:write";
                case Scope.GroupsWriteInvites: return "groups:write.invites";
                case Scope.GroupsWriteTopic: return "groups:write.topic";
                case Scope.Identify: return "identify";
                case Scope.IdentityAvatar: return "identity.avatar";
                case Scope.IdentityAvatarReadUser: return "identity.avatar:read:user";
                case Scope.IdentityBasic: return "identity.basic";
                case Scope.IdentityEmail: return "identity.email";
                case Scope.IdentityEmailReadUser: return "identity.email:read:user";
                case Scope.IdentityTeam: return "identity.team";
                case Scope.IdentityTeamReadUser: return "identity.team:read:user";
                case Scope.IdentityReadUser: return "identity:read:user";
                case Scope.ImHistory: return "im:history";
                case Scope.ImRead: return "im:read";
                case Scope.ImWrite: return "im:write";
                case Scope.IncomingWebhook: return "incoming-webhook";
                case Scope.LinksEmbedWrite: return "links.embed:write";
                case Scope.LinksRead: return "links:read";
                case Scope.LinksWrite: return "links:write";
                case Scope.MetadataMessageRead: return "metadata.message:read";
                case Scope.MpimHistory: return "mpim:history";
                case Scope.MpimRead: return "mpim:read";
                case Scope.MpimWrite: return "mpim:write";
                case Scope.MpimWriteInvites: return "mpim:write.invites";
                case Scope.MpimWriteTopic: return "mpim:write.topic";
                case Scope.None: return "none";
                case Scope.Openid: return "openid";
                case Scope.PinsRead: return "pins:read";
                case Scope.PinsWrite: return "pins:write";
                case Scope.Profile: return "profile";
                case Scope.ReactionsRead: return "reactions:read";
                case Scope.ReactionsWrite: return "reactions:write";
                case Scope.RemindersRead: return "reminders:read";
                case Scope.RemindersReadUser: return "reminders:read:user";
                case Scope.RemindersWrite: return "reminders:write";
                case Scope.RemindersWriteUser: return "reminders:write:user";
                case Scope.Remote_filesRead: return "remote_files:read";
                case Scope.Remote_filesShare: return "remote_files:share";
                case Scope.Remote_filesWrite: return "remote_files:write";
                case Scope.SearchRead: return "search:read";
                case Scope.StarsRead: return "stars:read";
                case Scope.StarsWrite: return "stars:write";
                case Scope.TeamBillingRead: return "team.billing:read";
                case Scope.TeamPreferencesRead: return "team.preferences:read";
                case Scope.TeamRead: return "team:read";
                case Scope.TokensBasic: return "tokens.basic";
                case Scope.TriggersRead: return "triggers:read";
                case Scope.TriggersWrite: return "triggers:write";
                case Scope.UsergroupsRead: return "usergroups:read";
                case Scope.UsergroupsWrite: return "usergroups:write";
                case Scope.UsersProfileRead: return "users.profile:read";
                case Scope.UsersProfileWrite: return "users.profile:write";
                case Scope.UsersProfileWriteUser: return "users.profile:write:user";
                case Scope.UsersRead: return "users:read";
                case Scope.UsersReadEmail: return "users:read.email";
                case Scope.UsersWrite: return "users:write";
                case Scope.WorkflowStepsExecute: return "workflow.steps:execute";
                default: throw new SwitchStatementNotImplementException<Scope>(value);
            }
        }
    }
}

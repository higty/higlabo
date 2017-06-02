using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hignull.Data;
using Hignull.Facebook.Webhook;
using Hignull.Core;
using App.Core;
using HigLabo.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Hignull.Facebook.Send;

namespace Hignull.Facebook
{
    public class BotCommand_TaskAdd : BotCommand
    {
        public enum State
        {
            AskTitle,
            AskProject,
            AskUser,
            AskAdditional,
            AskDueDate,
            AskDescription,
        }
        public class CommandData
        {
            [JsonConverter(typeof(StringEnumConverter))]
            public State State { get; set; }
            public String Title { get; set; } = "";
            public Guid? ProjectCD { get; set; }
            public Guid? UserCD { get; set; }
            public DateTime? DueDate { get; set; }
            public String Description { get; set; } = "";
        }
        public static Int32 ExpireMinutes = 60;

        public CommandData Data { get; private set; }

        public BotCommand_TaskAdd(String recipientID, Guid botCD, BotCommandRecord record)
            : base(recipientID, botCD, record)
        {
            this.Data = JsonConvert.DeserializeObject<CommandData>(record.CommandData);
        }
        public override HandleMessageResult HandleMessage(UserActionMessage message)
        {
            var cm = message.Command;

            switch (this.Data.State)
            {
                case State.AskTitle:
                    #region
                    if (message.ActionType == UserActionType.Message)
                    {
                        this.Data.Title = message.Text;
                        this.UpdateCommandData(State.AskProject);
                        this.ResponseAskProject();
                        return new HandleMessageResult(true);
                    }
                    break;
                    #endregion
                case State.AskProject:
                    #region
                    if (message.ActionType != UserActionType.Postback || cm == null)
                    { return new HandleMessageResult(false); }
                    if (cm.MethodName == "SelectProject")
                    {
                        this.Data.ProjectCD = Guid.Parse(cm.Value);
                        this.UpdateCommandData(State.AskUser);
                        this.ResponseAskUser();
                        return new HandleMessageResult(true);
                    }
                    break;
                    #endregion
                case State.AskUser:
                    #region
                    if (message.ActionType != UserActionType.Postback || cm == null)
                    { return new HandleMessageResult(false); }
                    if (cm.MethodName == "SelectUser")
                    {
                        this.Data.UserCD = cm.Value.ToGuid();
                        this.UpdateCommandData(State.AskAdditional);
                        this.ResponseAskAdditional();
                        return new HandleMessageResult(true);
                    }
                    break;
                    #endregion
                case State.AskAdditional:
                    #region
                    if (message.ActionType != UserActionType.Postback || cm == null)
                    { return new HandleMessageResult(false); }
                    if (cm.MethodName == nameof(BotTextKey.AskTaskAdditionalInfo))
                    {
                        if (cm.Value.ToBoolean() == true)
                        {
                            this.UpdateCommandData(State.AskDueDate);
                            this.ResponseAskDueDate();
                        }
                        else
                        {
                            this.AddTask();
                        }
                        return new HandleMessageResult(true);
                    }
                    break;
                    #endregion
                case State.AskDueDate:
                    #region
                    if (message.ActionType == UserActionType.Message)
                    {
                        var dtime = DateTimeInfo.GetDateTime(message.Text);
                        if (dtime.HasValue)
                        {
                            this.Data.DueDate = dtime.Value.Date;
                        }
                        this.UpdateCommandData(State.AskDescription);
                        this.ResponseAskDescription();
                        return new HandleMessageResult(true);
                    }
                    break;
                    #endregion
                case State.AskDescription:
                    #region
                    if (message.ActionType == UserActionType.Message)
                    {
                        this.Data.Description = message.Text;
                        this.AddTask();
                        return new HandleMessageResult(true);
                    }
                    break;
                    #endregion
                default: throw new InvalidOperationException();
            }
            return new HandleMessageResult(false);
        }
        public override string GetText()
        {
            return this.Text(BotTextKey.AddingTask) + Environment.NewLine + this.Data.Title;
        }
        public override void Reset()
        {
            _Record.CommandData = JsonConvert.SerializeObject(new CommandData());
            this.UpdateCommandData();
            this.ResponseAskTitle();
        }
        public override void Cancel()
        {
            this.DeleteCommandData();
        }

        public override void ResponseMessage()
        {
            switch (this.Data.State)
            {
                case State.AskTitle:this.ResponseAskTitle();break;
                case State.AskProject:this.ResponseAskProject();break;
                case State.AskUser:this.ResponseAskUser();break;
                case State.AskAdditional:this.ResponseAskAdditional();break;
                case State.AskDueDate:this.ResponseAskDueDate();break;
                case State.AskDescription:this.ResponseAskDescription();break;
                default:throw new InvalidOperationException();
            }
        }
        private void ResponseAskTitle()
        {
            var cl = new FacebookBotClient();
            cl.SendMessage(this.RecipientID, this.TextManager.Text(BotTextKey.AskTitle));
        }
        private void ResponseAskProject()
        {
            var dc = new ProjectDataContext(this.UserCD);

            var l = new List<IButton>();
            foreach (var rProject in dc.CreateProjectList_Get())
            {
                var bt = new PostbackButton();
                bt.Title = rProject.DisplayName;
                var cm = new PayloadCommand();
                cm.CommandName = BotCommandName.TaskAdd;
                cm.MethodName = "SelectProject";
                cm.Value = rProject.ProjectCD.ToString();
                bt.SetPayload(cm);
                l.Add(bt);
            }
            var cl = new FacebookBotClient();
            foreach (var item in ButtonTemplateMessage.Create(this.RecipientID
                , this.TextManager.Text(BotTextKey.PleaseSelectProject), l))
            {
                cl.SendMessage(item);
            }
        }
        private void ResponseAskUser()
        {
            var dc = new ProjectDataContext(this.UserCD);

            var l = new List<IButton>();
            {
                var rUser = WebApp.Current.DatabaseCache.User.SelectByPrimaryKey(this.UserCD);
                var bt = new PostbackButton();
                bt.Title = this.Text(TextKey.ByMyself);
                var cm = new PayloadCommand();
                cm.CommandName = BotCommandName.TaskAdd;
                cm.MethodName = "SelectUser";
                cm.Value = this.UserCD.ToString();
                bt.SetPayload(cm);
                l.Add(bt);
            }
            {
                var bt = new PostbackButton();
                bt.Title = this.Text(TextKey.NotAssigned);
                var cm = new PayloadCommand();
                cm.CommandName = BotCommandName.TaskAdd;
                cm.MethodName = "SelectUser";
                cm.Value = "";
                bt.SetPayload(cm);
                l.Add(bt);
            }
            foreach (var item in dc.Project_User_List_Data_Get(this.Data.ProjectCD.Value))
            {
                if (item.UserCD == this.UserCD) { continue; }

                var rUser = item.User;
                var bt = new PostbackButton();
                bt.Title = rUser.DisplayName;
                var cm = new PayloadCommand();
                cm.CommandName = BotCommandName.TaskAdd;
                cm.MethodName = "SelectUser";
                cm.Value = rUser.UserCD.ToString();
                bt.SetPayload(cm);
                l.Add(bt);
            }
            var cl = new FacebookBotClient();
            foreach (var item in ButtonTemplateMessage.Create(this.RecipientID
                , this.TextManager.Text(BotTextKey.PleaseSelectTaskUser), l))
            {
                cl.SendMessage(item);
            }
        }
        private void ResponseAskAdditional()
        {
            this.ResponseAskYesNo(this.Text(BotTextKey.AskTaskAdditionalInfo)
                , BotCommandName.TaskAdd, nameof(BotTextKey.AskTaskAdditionalInfo));
        }
        private void ResponseAskDueDate()
        {
            var cl = new FacebookBotClient();
            cl.SendMessage(this.RecipientID, this.TextManager.Text(BotTextKey.AskDueDate));
        }
        private void ResponseAskDescription()
        {
            var cl = new FacebookBotClient();
            if (this.Data.DueDate.HasValue)
            {
                var text = String.Format("{0} {1}", this.TextManager.Text(TextKey.DueDate), this.Data.DueDate.Value.ToString("yyyy/MM/dd"));
                cl.SendMessage(this.RecipientID, text);
            }
            cl.SendMessage(this.RecipientID, this.TextManager.Text(BotTextKey.AskDescription));
        }

        private void UpdateCommandData(State nextState)
        {
            this.Data.State = nextState;
            _Record.RetryTime = null;
            _Record.ExpireTime = DateTimeInfo.GetNow().AddMinutes(ExpireMinutes);
            _Record.CommandData = JsonConvert.SerializeObject(this.Data);
            this.UpdateCommandData();
        }

        private void AddTask()
        {
            var dc = new TaskDataContext(this.UserCD);
            dc.Task_Insert(this.Data);

            var cl = new FacebookBotClient();
            cl.SendMessage(this.RecipientID, this.Text(BotTextKey.TaskAdded));

            this.DeleteCommandData();
        }
    }
}

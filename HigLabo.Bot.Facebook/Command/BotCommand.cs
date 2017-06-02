using HigLabo.Core;
using Hignull.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using Hignull.Facebook.Webhook;
using Newtonsoft.Json;
using Hignull.Core;
using Hignull.Facebook.Send;
using App.Core;
using HigLabo.Net;
using System.Net;

namespace Hignull.Facebook
{
    public abstract class BotCommand
    {
        private static readonly Random _Random = new Random();
        protected BotCommandRecord _Record = null;

        public String RecipientID { get; set; }
        public Guid UserCD { get; set; }
        public Guid BotCD { get; set; }
        public BotCommandName CommandName
        {
            get { return _Record.CommandName; }
        }
        public DateTimeOffset UpdateTime
        {
            get { return _Record.UpdateTime; }
        }
        public TextManager TextManager { get; set; }

        protected BotCommand(String recipientID, Guid botCD, BotCommandRecord record)
        {
            _Record = record;
            this.RecipientID = recipientID;
            this.UserCD = record.UserCD;
            this.BotCD = botCD;

            var rUser = WebApp.Current.DatabaseCache.User.SelectByPrimaryKey(this.UserCD);
            this.TextManager = WebApp.Current.TextManager.Copy(rUser.Language, "");
        }

        public abstract HandleMessageResult HandleMessage(UserActionMessage message);

        protected UserRecord GetUser()
        {
            return WebApp.Current.DatabaseCache.User.SelectByPrimaryKey(this.UserCD);
        }
        protected Int32 GetUserTimeZone()
        {
            return WebApp.Current.DatabaseCache.User.SelectByPrimaryKey(this.UserCD).TimeZone;
        }
        public Boolean IsExpired()
        {
            return _Record.ExpireTime.HasValue && _Record.ExpireTime < DateTimeInfo.GetNow();
        }
        public void UpdateCommandData()
        {
            var dc = new BotDataContext(this.UserCD);
            dc.BotCommand_Update(_Record);
        }
        public void DeleteCommandData()
        {
            var dc = new BotDataContext(this.UserCD);
            dc.BotCommand_Delete(_Record.CommandCD);
        }

        public abstract void ResponseMessage();
        public abstract String GetText();
        public abstract void Reset();
        public abstract void Cancel();

        protected void ResponseAskYesNo(String title, BotCommandName commandName, String methodName)
        {
            var tp = new ButtonTemplateMessage();
            tp.RecipientID = this.RecipientID;
            tp.Text = title;
            {
                var bt = new PostbackButton();
                bt.Title = this.Text(TextKey.Confirm_Yes);
                bt.SetPayload(commandName, methodName, "True");
                tp.Buttons.Add(bt);
            }
            {
                var bt = new PostbackButton();
                bt.Title = this.Text(TextKey.Confirm_No);
                bt.SetPayload(commandName, methodName, "False");
                tp.Buttons.Add(bt);
            }
            var cl = new FacebookBotClient();
            cl.SendMessage(tp);
        }
        protected void SendImage(BotActionType actionType)
        {
            var cl = new FacebookBotClient();
            cl.SuppressThrowException = true;

            var l = WebApp.Current.DatabaseCache.BotActionImage
                .Where(el => el.BotCD == this.BotCD && el.ActionType == actionType).ToList();
            if (l.Count == 0) { return; }
            var index = _Random.Next(l.Count);
            var rImage = l[index];

            HttpResponse res = null;
            var rAttachment = WebApp.Current.DatabaseCache.FacebookAttachment.FirstOrDefault(el => el.Url == rImage.ImageUrl);
            if (rAttachment == null)
            {
                res = cl.SendImage(this.RecipientID, rImage.ImageUrl);
                if (res.StatusCode == HttpStatusCode.OK)
                {
                    try
                    {
                        var o = JsonConvert.DeserializeObject<SendMediaResponse>(res.BodyText);
                        rAttachment = new FacebookAttachmentRecord();
                        rAttachment.AttachmentID = o.Attachment_ID;
                        rAttachment.Url = rImage.ImageUrl;
                        rAttachment.CreateTime = DateTimeInfo.GetNow();
                        var dc = new SystemDataContext();
                        dc.FacebookAttachment_Insert(rAttachment);
                    }
                    catch (Exception ex)
                    {
                        HignullLog.Current.Add(ex);
                    }
                }
            }
            else
            {
                res = cl.SendAttachment(this.RecipientID, rAttachment.AttachmentID);
            }
        }
        public String Text(String textKey)
        {
            return this.TextManager.Text(textKey);
        }
        public String Text(BotActionType actionType)
        {
            return this.TextManager.Text(actionType.ToStringFromEnum());
        }

        public static BotCommand Create(String recipientID, Guid botCD, BotCommandRecord record)
        {
            switch (record.CommandName)
            {
                case BotCommandName.StartCommand: return new BotCommand_StartCommand(recipientID, botCD, record);
                case BotCommandName.ScheduleAdd: return new BotCommand_ScheduleAdd(recipientID, botCD, record);
                case BotCommandName.TaskAdd: return new BotCommand_TaskAdd(recipientID, botCD, record);
                case BotCommandName.TaskComplete: return new BotCommand_TaskComplete(recipientID, botCD, record);
                default: throw new InvalidOperationException();
            }
        }
        public void StartCommand(BotCommandName commandName)
        {
            switch (commandName)
            {
                case BotCommandName.StartCommand: throw new InvalidOperationException();
                case BotCommandName.ScheduleAdd: StartScheduleAddCommand(); break;
                case BotCommandName.TaskAdd: StartTaskAddCommand(); break;
                case BotCommandName.TaskComplete: StartTaskCompleteCommand(); break;
                default: throw new InvalidOperationException();
            }
        }
        private void StartScheduleAddCommand()
        {
            var dc = new BotDataContext(this.UserCD);
            var data = new BotCommand_ScheduleAdd.CommandData();
            var rBotCommand = dc.BotCommand_Add(DatabaseSetting.NewGuid(), this.UserCD, BotCommandName.ScheduleAdd, null
                , DateTimeInfo.GetNow().AddMinutes(BotCommand_ScheduleAdd.ExpireMinutes), JsonConvert.SerializeObject(data));
            var cm = new BotCommand_ScheduleAdd(this.RecipientID, this.BotCD, rBotCommand);
            cm.ResponseMessage();
        }
        private void StartTaskAddCommand()
        {
            var dc = new BotDataContext(this.UserCD);
            var data = new BotCommand_TaskAdd.CommandData();
            var rBotCommand = dc.BotCommand_Add(DatabaseSetting.NewGuid(), this.UserCD, BotCommandName.TaskAdd, null
                , DateTimeInfo.GetNow().AddMinutes(BotCommand_TaskAdd.ExpireMinutes), JsonConvert.SerializeObject(data));
            var cm = new BotCommand_TaskAdd(this.RecipientID, this.BotCD, rBotCommand);
            cm.ResponseMessage();
        }
        private void StartTaskCompleteCommand()
        {
            var dc = new BotDataContext(this.UserCD);
            var data = new BotCommand_TaskComplete.CommandData();
            data.State = BotCommand_TaskComplete.State.AskComplete;
            var rBotCommand = dc.BotCommand_Add(DatabaseSetting.NewGuid(), this.UserCD, BotCommandName.TaskComplete, null
                , DateTimeInfo.GetNow().AddMinutes(BotCommand_TaskComplete.ExpireMinutes), JsonConvert.SerializeObject(data));
            var cm = new BotCommand_TaskComplete(this.RecipientID, this.BotCD, rBotCommand);
            cm.LoadData();
            cm.ResponseMessage();
        }
    }
}

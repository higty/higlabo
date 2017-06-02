using System;
using System.Collections.Generic;
using System.Linq;
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
    public class BotCommand_ScheduleAdd : BotCommand
    {
        public enum State
        {
            AskTitle,
            AskStation,
            AskIsAllDay,
            AskStartDate,
            AskIsStartDateAndEndDateSame,
            AskEndDate,
            AskStartTime,
            AskEndTime,
            AskDateIsCorrect,
            AskAdditional,
            AskViewPermission,
            AskDescription,
        }
        public class CommandData
        {
            [JsonConverter(typeof(StringEnumConverter))]
            public State State { get; set; }
            public String Title { get; set; } = "";
            public String Station { get; set; } = "";
            public Boolean IsAllDay { get; set; } = false;
            public DateTime? StartDate { get; set; }
            public DateTime? EndDate { get; set; }
            public DateTimeOffset? StartTime { get; set; }
            public DateTimeOffset? EndTime { get; set; }
            [JsonConverter(typeof(StringEnumConverter))]
            public ScheduleViewPermission ViewPermissoin { get; set; } = ScheduleViewPermission.Paticipant;
            public String Description { get; set; } = "";

            public List<Guid> UserCDList { get; set; } = new List<Guid>();
        }
        public static Int32 ExpireMinutes = 60;

        public CommandData Data { get; private set; }

        public BotCommand_ScheduleAdd(String recipientID, Guid botCD, BotCommandRecord record)
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
                        this.UpdateCommandData(State.AskIsAllDay);
                        this.ResponseAskIsAllDay();
                        return new HandleMessageResult(true);
                    }
                    break;
                    #endregion
                case State.AskIsAllDay:
                    #region
                    if (message.ActionType != UserActionType.Postback || cm == null)
                    { return new HandleMessageResult(false); }
                    if (cm.MethodName == nameof(State.AskIsAllDay))
                    {
                        this.Data.IsAllDay = cm.Value == "True";
                        if (this.Data.IsAllDay)
                        {
                            this.UpdateCommandData(State.AskStartDate);
                            this.ResponseAskStartDate();
                        }
                        else
                        {
                            this.UpdateCommandData(State.AskStartTime);
                            this.ResponseAskStartTime();
                        }
                        return new HandleMessageResult(true);
                    }
                    break;
                    #endregion
                case State.AskStartDate:
                    #region
                    if (message.ActionType == UserActionType.Message)
                    {
                        var dtime = message.GetDateTime();
                        if (dtime.HasValue)
                        {
                            this.Data.StartDate = dtime;
                            this.UpdateCommandData(State.AskIsStartDateAndEndDateSame);
                            this.ResponseAskIsStartDateAndEndDateSame();
                        }
                        else
                        {
                            this.ResponseShowSampleDateTimeFormat();
                        }
                        return new HandleMessageResult(true);
                    }
                    break;
                    #endregion
                case State.AskIsStartDateAndEndDateSame:
                    #region 
                    if (message.ActionType != UserActionType.Postback || cm == null)
                    { return new HandleMessageResult(false); }
                    if (cm.MethodName == nameof(State.AskIsStartDateAndEndDateSame))
                    {
                        if (cm.Value == "True")
                        {
                            this.Data.EndDate = this.Data.StartDate;
                            this.UpdateCommandData(State.AskAdditional);
                            this.ResponseAskAdditional();
                        }
                        else
                        {
                            this.UpdateCommandData(State.AskEndDate);
                            this.ResponseAskEndDate();
                        }
                        return new HandleMessageResult(true);
                    }
                    break;
                    #endregion
                case State.AskEndDate:
                    #region 
                    if (message.ActionType == UserActionType.Message)
                    {
                        var dtime = message.GetDateTime();
                        if (dtime.HasValue)
                        {
                            if (this.Data.StartDate <= dtime.Value)
                            {
                                this.Data.EndDate = dtime;
                                this.UpdateCommandData(State.AskAdditional);
                                this.ResponseAskAdditional();
                            }
                            else
                            {
                                this.ResponseEndDateMustBeLargerThanStartDate();
                            }
                        }
                        else
                        {
                            this.ResponseShowSampleDateTimeFormat();
                        }
                        return new HandleMessageResult(true);
                    }
                    break;
                    #endregion
                case State.AskStartTime:
                    #region
                    if (message.ActionType == UserActionType.Postback && cm.MethodName == nameof(BotTextKey.DateTimeSample))
                    {
                        this.ResponseShowSampleDateTimeFormat();
                        return new HandleMessageResult(true);
                    }
                    if (message.ActionType == UserActionType.Message)
                    {
                        var dtime = message.GetDateTime();
                        if (dtime.HasValue)
                        {
                            this.Data.StartTime = new DateTimeOffset(dtime.Value, TimeSpan.FromHours(this.GetUserTimeZone()));
                            this.UpdateCommandData(State.AskEndTime);
                            this.ResponseAskEndTime();
                        }
                        else
                        {
                            this.ResponseShowSampleDateTimeFormat();
                        }
                        return new HandleMessageResult(true);
                    }
                    break;
                    #endregion
                case State.AskEndTime:
                    #region
                    if (message.ActionType == UserActionType.Message)
                    {
                        var minutes = message.Text.ToInt32();
                        if (minutes.HasValue)
                        {
                            var dtime = this.Data.StartTime.Value.AddMinutes(minutes.Value);
                            this.Data.EndTime = dtime;
                            this.UpdateCommandData(State.AskDateIsCorrect);
                            this.ResponseAskDateIsCorrect();
                        }
                        else
                        {
                            var dtime = message.GetDateTime();
                            if (dtime.HasValue)
                            {
                                if (this.Data.StartTime <= dtime.Value)
                                {
                                    this.Data.EndTime = new DateTimeOffset(dtime.Value, TimeSpan.FromHours(this.GetUserTimeZone()));
                                    this.UpdateCommandData(State.AskDateIsCorrect);
                                    this.ResponseAskDateIsCorrect();
                                }
                                else
                                {
                                    this.ResponseEndTimeMustBeLargerThanStartTime();
                                }
                            }
                            else
                            {
                                this.ResponseShowSampleDateTimeFormat();
                            }
                        }
                        return new HandleMessageResult(true);
                    }
                    break;
                    #endregion
                case State.AskDateIsCorrect:
                    #region
                    if (message.ActionType != UserActionType.Postback || cm == null)
                    { return new HandleMessageResult(false); }
                    if (cm.MethodName == nameof(State.AskDateIsCorrect))
                    {
                        if (cm.Value.ToBoolean() == true)
                        {
                            this.UpdateCommandData(State.AskAdditional);
                            this.ResponseAskAdditional();
                        }
                        else
                        {
                            this.UpdateCommandData(State.AskIsAllDay);
                            this.ResponseAskIsAllDay();
                        }
                        return new HandleMessageResult(true);
                    }
                    break;
                    #endregion
                case State.AskAdditional:
                    #region
                    if (message.ActionType != UserActionType.Postback || cm == null)
                    { return new HandleMessageResult(false); }
                    if (cm.MethodName == nameof(BotTextKey.AskScheduleAdditionalInfo))
                    {
                        if (cm.Value.ToBoolean() == true)
                        {
                            this.UpdateCommandData(State.AskStation);
                            this.ResponseAskStation();
                        }
                        else
                        {
                            this.AddSchedule();
                        }
                        return new HandleMessageResult(true);
                    }
                    break;
                    #endregion
                case State.AskStation:
                    #region
                    if (message.ActionType == UserActionType.Message)
                    {
                        this.Data.Station = message.Text;
                        this.UpdateCommandData(State.AskViewPermission);
                        this.ResponseAskViewPermission();
                        return new HandleMessageResult(true);
                    }
                    break;
                    #endregion
                case State.AskViewPermission:
                    #region
                    if (message.ActionType != UserActionType.Postback || cm == null)
                    { return new HandleMessageResult(false); }
                    if (cm.MethodName == nameof(State.AskViewPermission))
                    {
                        this.Data.ViewPermissoin = Enum<ScheduleViewPermission>.Parse(cm.Value);
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
                        this.AddSchedule();
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
            return this.Text(BotTextKey.AddingSchedule) + Environment.NewLine + this.Data.Title;
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
                case State.AskStation: this.ResponseAskStation(); break;
                case State.AskIsAllDay: this.ResponseAskIsAllDay(); break;
                case State.AskStartDate: this.ResponseAskStartDate(); break;
                case State.AskEndDate: this.ResponseAskEndDate(); break;
                case State.AskStartTime: this.ResponseAskStartTime(); break;
                case State.AskEndTime: this.ResponseAskEndTime(); break;
                case State.AskAdditional: this.ResponseAskAdditional(); break;
                case State.AskViewPermission: this.ResponseAskViewPermission(); break;
                case State.AskDescription:this.ResponseAskDescription();break;
                default:throw new InvalidOperationException();
            }
        }
        private void ResponseAskTitle()
        {
            var cl = new FacebookBotClient();
            cl.SendMessage(this.RecipientID, this.TextManager.Text(BotTextKey.AskTitle));
        }
        private void ResponseAskStation()
        {
            var cl = new FacebookBotClient();
            cl.SendMessage(this.RecipientID, this.TextManager.Text(BotTextKey.AskStation));
        }
        private void ResponseAskIsAllDay()
        {
            var tm = this.TextManager;
            var tp = new ButtonTemplateMessage();
            tp.RecipientID = this.RecipientID;
            tp.Text = this.Text(BotTextKey.AskIsAllDay);
            {
                var bt = new PostbackButton();
                bt.Title = tm.Text(TextKey.Confirm_Yes);
                bt.SetPayload(new PayloadCommand(BotCommandName.ScheduleAdd, nameof(State.AskIsAllDay)
                    , "True"));
                tp.Buttons.Add(bt);
            }
            {
                var bt = new PostbackButton();
                bt.Title = tm.Text(TextKey.Confirm_No);
                bt.SetPayload(new PayloadCommand(BotCommandName.ScheduleAdd, nameof(State.AskIsAllDay)
                    , "False"));
                tp.Buttons.Add(bt);
            }
            var cl = new FacebookBotClient();
            cl.SendMessage(tp);
        }
        private void ResponseAskStartDate()
        {
            var cl = new FacebookBotClient();
            cl.SendMessage(this.RecipientID, this.TextManager.Text(BotTextKey.AskStartDate));
        }
        private void ResponseAskIsStartDateAndEndDateSame()
        {
            var tm = this.TextManager;
            var tp = new ButtonTemplateMessage();
            tp.RecipientID = this.RecipientID;
            tp.Text = this.Text(BotTextKey.IsStartDateAndEndDateSame);
            {
                var bt = new PostbackButton();
                bt.Title = tm.Text(TextKey.Confirm_Yes);
                bt.SetPayload(new PayloadCommand(BotCommandName.ScheduleAdd, nameof(State.AskIsStartDateAndEndDateSame)
                    , "True"));
                tp.Buttons.Add(bt);
            }
            {
                var bt = new PostbackButton();
                bt.Title = tm.Text(TextKey.Confirm_No);
                bt.SetPayload(new PayloadCommand(BotCommandName.ScheduleAdd, nameof(State.AskIsStartDateAndEndDateSame)
                    , "False"));
                tp.Buttons.Add(bt);
            }
            var cl = new FacebookBotClient();
            cl.SendMessage(tp);
        }
        private void ResponseAskEndDate()
        {
            var cl = new FacebookBotClient();
            cl.SendMessage(this.RecipientID, this.TextManager.Text(BotTextKey.AskEndDate));
        }
        private void ResponseAskStartTime()
        {
            var tm = this.TextManager;
            var cl = new FacebookBotClient();
            cl.SendMessage(this.RecipientID, this.TextManager.Text(BotTextKey.AskStartTime));

            var tp = new ButtonTemplateMessage();
            tp.RecipientID = this.RecipientID;
            tp.Text = "　";
            var bt = new PostbackButton();
            bt.Title = tm.Text(BotTextKey.DisplayDateTimeSample);
            var cm = new PayloadCommand();
            cm.CommandName = BotCommandName.ScheduleAdd;
            cm.MethodName = nameof(BotTextKey.DateTimeSample);
            cm.Value = "";
            bt.SetPayload(cm);
            tp.Buttons.Add(bt);
            cl.SendMessage(tp);
        }
        private void ResponseAskEndTime()
        {
            var cl = new FacebookBotClient();
            var text = String.Format("{0} {1}"
                , this.TextManager.Text(TextKey.StartTime), this.Data.StartTime.Value.ToString("yyyy/MM/dd HH:mm"));
            cl.SendMessage(this.RecipientID, text);
            cl.SendMessage(this.RecipientID, this.TextManager.Text(BotTextKey.AskEndTime));
        }

        private void ResponseEndDateMustBeLargerThanStartDate()
        {
            var cl = new FacebookBotClient();
            cl.SendMessage(this.RecipientID, this.TextManager.Text(TextKey.EndDateMustBeLargerThanStartDate));
        }
        private void ResponseEndTimeMustBeLargerThanStartTime()
        {
            var cl = new FacebookBotClient();
            cl.SendMessage(this.RecipientID, this.TextManager.Text(TextKey.EndTimeMustBeLargerThanStartTime));
        }
        private void ResponseShowSampleDateTimeFormat()
        {
            var cl = new FacebookBotClient();
            cl.SendMessage(this.RecipientID, this.TextManager.Text(BotTextKey.DateTimeSample));
        }

        private void ResponseAskDateIsCorrect()
        {
            var text = "";
            if (this.Data.IsAllDay)
            {
                text = String.Format("{0} - {1}"
                    , this.Data.StartDate.Value.ToString("yyyy/MM/dd"), this.Data.EndDate.Value.ToString("MM/dd"));
            }
            else
            {
                text = String.Format("{0} - {1}"
                    , this.Data.StartTime.Value.ToString("yyyy/MM/dd HH:mm"), this.Data.EndTime.Value.ToString("MM/dd HH:mm"));
            }
            this.ResponseAskYesNo(this.Text(BotTextKey.AskScheduleDateIsCorrect) + Environment.NewLine + text
                , BotCommandName.ScheduleAdd, nameof(State.AskDateIsCorrect));
        }
        private void ResponseAskAdditional()
        {
            this.ResponseAskYesNo(this.Text(BotTextKey.AskScheduleAdditionalInfo)
                , BotCommandName.ScheduleAdd, nameof(BotTextKey.AskScheduleAdditionalInfo));
        }

        private void ResponseAskViewPermission()
        {
            var tm = this.TextManager;
            var l = new List<IButton>();
            foreach (var item in Enum<ScheduleViewPermission>.GetValues())
            {
                var bt = new PostbackButton();
                bt.Title = tm.Text(item);
                var cm = new PayloadCommand();
                cm.CommandName = BotCommandName.ScheduleAdd;
                cm.MethodName = nameof(State.AskViewPermission);
                cm.Value = item.ToStringFromEnum();
                bt.SetPayload(cm);
                l.Add(bt);
            }
            var cl = new FacebookBotClient();
            foreach (var item in ButtonTemplateMessage.Create(this.RecipientID
                , this.TextManager.Text(BotTextKey.PleaseSelectViewPermission), l))
            {
                cl.SendMessage(item);
            }
        }
        private void ResponseAskDescription()
        {
            var cl = new FacebookBotClient();
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

        private void AddSchedule()
        {
            var dc = new ScheduleDataContext(this.UserCD);
            dc.Schedule_Insert(this.Data);

            var cl = new FacebookBotClient();
            cl.SendMessage(this.RecipientID, this.Text(BotTextKey.ScheduleAdded));

            this.DeleteCommandData();
        }
    }
}

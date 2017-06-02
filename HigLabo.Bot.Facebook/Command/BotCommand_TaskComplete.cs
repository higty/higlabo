using App.Core;
using HigLabo.Core;
using Hignull.Core;
using Hignull.Data;
using Hignull.Facebook.Send;
using Hignull.Facebook.Webhook;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hignull.Facebook
{
    public class BotCommand_TaskComplete : BotCommand
    {
        public enum State
        {
            AskStart,
            AskComplete,
            AskSuspend,
        }
        public class CommandData
        {
            [JsonConverter(typeof(StringEnumConverter))]
            public State State { get; set; }
            public Boolean HasData { get; set; }
            public TaskRecord Task { get; set; }
            public List<TaskRecord> TaskList { get; set; }
        }
        public class TaskRecord
        {
            public Guid TaskCD { get; set; }
            public String Title { get; set; }
            public Guid ProjectCD { get; set; }
        }
        public static Int32 ExpireMinutes = 60;

        public CommandData Data { get; private set; }

        public BotCommand_TaskComplete(String recipientID, Guid botCD, BotCommandRecord record)
            : base(recipientID, botCD, record)
        {
            this.Data = JsonConvert.DeserializeObject<CommandData>(record.CommandData);
            if (this.Data.TaskList == null)
            {
                this.Data.TaskList = new List<TaskRecord>();
            }
        }
        public override HandleMessageResult HandleMessage(UserActionMessage message)
        {
            var cm = message.Command;

            switch (this.Data.State)
            {
                case State.AskStart:
                    if (message.ActionType != UserActionType.Postback || cm == null)
                    { return new HandleMessageResult(false); }
                    if (cm.MethodName == nameof(State.AskStart))
                    {
                        if (cm.Value.ToBoolean() == true)
                        {
                            this.LoadData();
                            if (this.Data.Task == null)
                            {
                                this.Complete();
                            }
                            else
                            {
                                this.ResponseAskComplete();
                            }
                        }
                        else
                        {
                            this.Complete();
                        }
                        return new HandleMessageResult(true);
                    }
                    break;
                case State.AskComplete:
                    if (message.ActionType != UserActionType.Postback || cm == null)
                    { return new HandleMessageResult(false); }

                    if (cm.MethodName == "TaskSuspend")
                    {
                        this.UpdateCommandData(State.AskSuspend);
                        this.ResponseAskSuspend();
                        return new HandleMessageResult(true);
                    }

                    if (cm.MethodName == "TaskComplete")
                    {
                        var rState = WebApp.Current.DatabaseCache.TaskState.GetDefaultState(this.Data.Task.ProjectCD, "Done");
                        var dc = new TaskDataContext(this.UserCD);
                        dc.Task_CompleteState_Edit(this.Data.Task.TaskCD, rState.StateCD);
                    }
                    else if (cm.MethodName == "TaskInCompleted")
                    {
                        //Do nothing...
                    }
                    if (this.Data.TaskList.Count > 0)
                    {
                        this.TaskEdit();
                    }
                    else
                    {
                        this.Complete();
                    }
                    return new HandleMessageResult(true);
                case State.AskSuspend:
                    if (message.ActionType == UserActionType.Postback)
                    {
                        if (cm.MethodName == "SuspendDay")
                        {
                            var dc = new TaskDataContext(this.UserCD);
                            var days = cm.Value.ToInt32();
                            DateTime? dueDate = null;
                            if (days.HasValue)
                            {
                                dueDate = DateTimeInfo.GetToday().Date.AddDays(days.Value);
                            }
                            dc.Task_DueDate_Edit(this.Data.Task.TaskCD, dueDate);
                            this.TaskEdit();
                        }
                    }
                    else if (message.ActionType == UserActionType.Message)
                    {
                        var days = message.Text.ToInt32();
                        if (days > 0)
                        {
                            var dueDate = DateTimeInfo.GetToday().Date.AddDays(days.Value);
                            var dc = new TaskDataContext(this.UserCD);
                            dc.Task_DueDate_Edit(this.Data.Task.TaskCD, dueDate);
                        }
                        this.TaskEdit();
                    }
                    return new HandleMessageResult(true);
                default: throw new InvalidOperationException();
            }
            return new HandleMessageResult(false);
        }
        public override string GetText()
        {
            return this.Text(BotTextKey.TaskConfirmation) + Environment.NewLine + this.Data.Task?.Title;
        }
        public override void Reset()
        {
            _Record.CommandData = JsonConvert.SerializeObject(new CommandData());
            this.UpdateCommandData();
            this.ResponseMessage();
        }
        public override void Cancel()
        {
            this.DeleteCommandData();
        }
        public void LoadData()
        {
            var dc = new TaskDataContext(this.UserCD);
            var l = dc.Task_CompleteTimeIsNull_Get(this.UserCD, null, DateTimeInfo.GetToday().Date);
            if (l.Count > 0)
            {
                this.Data.HasData = true;
                for (int i = 0; i < l.Count; i++)
                {
                    var r = l[i].Map(new TaskRecord());
                    if (i == 0)
                    {
                        this.Data.Task = r;
                    }
                    else
                    {
                        this.Data.TaskList.Add(r);
                    }
                }
            }
            else
            {
                this.Data.HasData = false;
            }
            this.UpdateCommandData(State.AskComplete);
        }

        public override void ResponseMessage()
        {
            switch (this.Data.State)
            {
                case State.AskStart: this.ResponseAskStart(); break;
                case State.AskComplete: this.ResponseAskComplete(); break;
                case State.AskSuspend: this.ResponseAskSuspend(); break;
                default: throw new InvalidOperationException();
            }
        }
        private void ResponseAskStart()
        {
            this.ResponseAskYesNo(this.Text(BotTextKey.AskTaskCompleteProcessStart)
                , BotCommandName.TaskComplete, nameof(State.AskStart));
        }
        private void ResponseAskComplete()
        {
            if (this.Data.Task == null)
            {
                this.Complete();
                return;
            }
            var rTask = this.Data.Task;

            var tp = new ButtonTemplateMessage();
            tp.RecipientID = this.RecipientID;
            tp.Text = this.Text(BotTextKey.AskTaskComplete) + Environment.NewLine + rTask.Title;
            {
                var bt = new PostbackButton();
                bt.Title = this.Text(TextKey.Confirm_Yes);
                bt.SetPayload(BotCommandName.TaskComplete, "TaskCompleted", rTask.TaskCD.ToString());
                tp.Buttons.Add(bt);
            }
            {
                var bt = new PostbackButton();
                bt.Title = this.Text(TextKey.Confirm_No);
                bt.SetPayload(BotCommandName.TaskComplete, "TaskInCompleted", rTask.TaskCD.ToString());
                tp.Buttons.Add(bt);
            }
            {
                var bt = new PostbackButton();
                bt.Title = this.Text(TextKey.Suspend);
                bt.SetPayload(BotCommandName.TaskComplete, "TaskSuspend", "");
                tp.Buttons.Add(bt);
            }
            var cl = new FacebookBotClient();
            cl.SendMessage(tp);
        }
        private void ResponseAskSuspend()
        {
            if (this.Data.Task == null)
            {
                this.Complete();
                return;
            }

            var rTask = this.Data.Task;

            var tp = new ButtonTemplateMessage();
            tp.RecipientID = this.RecipientID;
            tp.Text = this.Text(BotTextKey.AskTaskSuspend);
            {
                var bt = new PostbackButton();
                bt.Title = String.Format(this.Text(BotTextKey.DayAfter_DayFormat), 1);
                bt.SetPayload(BotCommandName.TaskComplete, "SuspendDay", "1");
                tp.Buttons.Add(bt);
            }
            {
                var bt = new PostbackButton();
                bt.Title = String.Format(this.Text(BotTextKey.DayAfter_DayFormat), 3);
                bt.SetPayload(BotCommandName.TaskComplete, "SuspendDay", "3");
                tp.Buttons.Add(bt);
            }
            {
                var bt = new PostbackButton();
                bt.Title = this.Text(BotTextKey.DayAfter_1Week);
                bt.SetPayload(BotCommandName.TaskComplete, "SuspendDay", "7");
                tp.Buttons.Add(bt);
            }
            var cl = new FacebookBotClient();
            cl.SendMessage(tp);
        }

        private void UpdateCommandData(State nextState)
        {
            this.Data.State = nextState;
            _Record.RetryTime = null;
            _Record.ExpireTime = DateTimeInfo.GetNow().AddMinutes(ExpireMinutes);
            _Record.CommandData = JsonConvert.SerializeObject(this.Data);
            this.UpdateCommandData();
        }
        private void TaskEdit()
        {
            if (this.Data.TaskList.Count  == 0)
            {
                this.Complete();
                return;
            }
            this.Data.Task = this.Data.TaskList[0];
            this.Data.TaskList.RemoveAt(0);
            this.UpdateCommandData(State.AskComplete);
            this.ResponseAskComplete();
        }
        private void Complete()
        {
            var cl = new FacebookBotClient();
            if (this.Data.HasData)
            {
                cl.SendMessage(this.RecipientID, this.Text(BotTextKey.AllTaskDone));
            }
            else
            {
                cl.SendMessage(this.RecipientID, this.Text(BotTextKey.ThereIsNoInCompleteTask));
            }
            this.DeleteCommandData();
        }
    }
}

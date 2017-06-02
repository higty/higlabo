using Hignull.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hignull.Facebook.Webhook;
using Hignull.Core;
using Hignull.Facebook.Send;
using App.Core;
using HigLabo.Core;
using Newtonsoft.Json;

namespace Hignull.Facebook
{
    public class BotCommand_StartCommand : BotCommand
    {
        public BotCommand_StartCommand(String recipientID, Guid botCD, BotCommandRecord record)
            : base(recipientID, botCD, record)
        {
        }
        public override HandleMessageResult HandleMessage(UserActionMessage message)
        {
            if (message.ActionType == UserActionType.Postback && 
                message.Command.CommandName == BotCommandName.StartCommand)
            {
                if (message.Command.MethodName == "StartCommand")
                {
                    var commandName = message.Command.Value.ToEnum<BotCommandName>().Value;
                    this.StartCommand(commandName);
                }
                else if (message.Command.MethodName == "RestartCommand")
                {
                    var dc = new BotDataContext(this.UserCD);
                    var commandCD = Guid.Parse(message.Command.Value);
                    dc.BotCommand_Restart(commandCD);
                    var r = dc.BotCommand_Get(commandCD);
                    if (r == null)
                    {
                        var cl = new FacebookBotClient();
                        cl.SendMessage(this.RecipientID, this.Text(BotTextKey.ThisCommandMayBeDeleted));
                    }
                    else
                    {
                        var cm = BotCommand.Create(this.RecipientID, this.BotCD, r);
                        cm.ResponseMessage();
                    }
                }

                return new HandleMessageResult(true);
            }
            return new HandleMessageResult(false);
        }
        public override void ResponseMessage()
        {
            var cl = new FacebookBotClient();
            cl.SendMessage(this.RecipientID, this.TextManager.Text(BotTextKey.CanIHelpYou));
        }
        public override string GetText()
        {
            return this.Text(BotTextKey.CanIHelpYou);
        }
        public override void Reset()
        {
        }
        public override void Cancel()
        {
        }

        public void ResponseCommandListMessage()
        {
            var dc = new BotDataContext(this.UserCD);

            var l = new List<IButton>();
            {
                var bt = new PostbackButton();
                bt.Title = this.Text(BotTextKey.AddNewSchedule);
                var cm = new PayloadCommand();
                cm.CommandName = BotCommandName.StartCommand;
                cm.MethodName = "StartCommand";
                cm.Value = nameof(BotCommandName.ScheduleAdd);
                bt.SetPayload(cm);
                l.Add(bt);
            }
            {
                var bt = new PostbackButton();
                bt.Title = this.Text(BotTextKey.AddNewTask);
                var cm = new PayloadCommand();
                cm.CommandName = BotCommandName.StartCommand;
                cm.MethodName = "StartCommand";
                cm.Value = nameof(BotCommandName.TaskAdd);
                bt.SetPayload(cm);
                l.Add(bt);
            }
            {
                var bt = new PostbackButton();
                bt.Title = this.Text(BotTextKey.TaskConfirmation);
                var cm = new PayloadCommand();
                cm.CommandName = BotCommandName.StartCommand;
                cm.MethodName = "StartCommand";
                cm.Value = nameof(BotCommandName.TaskComplete);
                bt.SetPayload(cm);
                l.Add(bt);
            }
            foreach (var item in dc.BotCommand_List_Get())
            {
                if (item.CommandName == BotCommandName.StartCommand) { continue; }
                var cm = BotCommand.Create(this.RecipientID, this.BotCD, item);
                var bt = new PostbackButton();
                bt.Title = cm.GetText();
                bt.SetPayload(BotCommandName.StartCommand, "RestartCommand", item.CommandCD.ToString());
                l.Add(bt);
            }
            this.SendImage(BotActionType.Greeting);
            var cl = new FacebookBotClient();
            foreach (var item in ButtonTemplateMessage.Create(this.RecipientID
                , this.TextManager.Text(BotTextKey.CanIHelpYou), l))
            {
                cl.SendMessage(item);
            }
            dc.BotCommand_Update(_Record);
        }
    }
}

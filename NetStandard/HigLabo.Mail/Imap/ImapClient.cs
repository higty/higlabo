using System;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.IO;
using System.Collections.Generic;
using G = System.Collections.Generic;
using HigLabo.Net.Mail;
using HigLabo.Net.Internal;
using HigLabo.Net.Pop3;
using HigLabo.Mime;
using System.Globalization;
using HigLabo.Converter;
using HigLabo.Core;

namespace HigLabo.Net.Imap
{
    /// Represent and probide functionality about IMAP command.
    /// <summary>
    /// Represent and probide functionality about IMAP command.
    /// </summary>
    public class ImapClient : SocketClient, IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        public class RegexList
        {
            /// <summary>
            /// 
            /// </summary>
            public static readonly Regex SelectFolderResultFlagsLine = new Regex(@"^\* FLAGS \((?<Flags>[^)]*)\)\r\n", RegexOptions.Singleline | RegexOptions.IgnoreCase);
            /// <summary>
            /// 
            /// </summary>
            public static readonly Regex SelectFolderResult = new Regex(@"^\* (?<exst>\d+) EXISTS\r\n\* (?<rcnt>\d+) RECENT\r\n", RegexOptions.Multiline | RegexOptions.IgnoreCase);
            /// <summary>
            /// 
            /// </summary>
            public static readonly Regex GetListFolderResult = new Regex("^\\* LIST \\(((?<opt>\\\\\\w+)\\s?)*\\) \".\" ((\"(?<name>.*)\")|(?<name>[^\r\n]*))", RegexOptions.Multiline | RegexOptions.IgnoreCase);
            /// <summary>
            /// 
            /// </summary>
            public static readonly Regex GetXListFolderResult = new Regex("^\\* XLIST \\(((?<opt>\\\\\\w+)\\s?)*\\) \".\" ((\"(?<name>.*)\")|(?<name>[^\r\n]*))", RegexOptions.Multiline | RegexOptions.IgnoreCase);
            /// <summary>
            /// 
            /// </summary>
            public static readonly Regex GetLsubFolderResult = new Regex("^\\* LSUB \\(((?<opt>\\\\\\w+)\\s?)*\\) \".\" ((\"(?<name>.*)\")|(?<name>[^\r\n]*))", RegexOptions.Multiline | RegexOptions.IgnoreCase);
            /// <summary>
            /// 
            /// </summary>
            public static readonly Regex GetRlsubFolderResult = new Regex("^\\* RLSUB \\(((?<opt>\\\\\\w+)\\s?)*\\) \".\" ((\"(?<name>.*)\")|(?<name>[^\r\n]*))", RegexOptions.Multiline | RegexOptions.IgnoreCase);
        }
        private static readonly Byte[] NewlineBytes = new Byte[] { 13, 10 };
        
        public new static readonly ImapClientDefaultSettings Default = new ImapClientDefaultSettings();
        private ModifiedUtf7Converter _ModifiedUtf7Converter = new ModifiedUtf7Converter(200);
        private Int32 _TagNo = Default.TagNo;
        private ImapConnectionState _State = ImapConnectionState.Disconnected;

        private String Tag
        {
            get { return "tag" + this.TagNo; }
        }

        public MimeParser MimeParser { get; set; }
        /// <summary>
        /// Get connection state.
        /// </summary>
        public ImapConnectionState State
        {
            get
            {
                if (this.Connected == false)
                {
                    this._State = ImapConnectionState.Disconnected;
                }
                return this._State;
            }
        }
        /// <summary>
        /// Get selected folder
        /// </summary>
        public ImapFolder CurrentFolder { get; private set; }
        /// <summary>
        /// Get connection is ready.
        /// </summary>
        public Boolean Available
        {
            get { return this._State != ImapConnectionState.Disconnected; }
        }
        public Int32 TagNo
        {
            get { return _TagNo; }
            set { _TagNo = value; }
        }
        /// <summary>
        /// Throw exception when invalid mime format message received.
        /// </summary>
        public Boolean ThrowExceptionOnInvalidMailMessage { get; set; } = false;

        public ImapClient(EmailServiceProvider provider)
            : this(provider, Default.UserName, Default.Password)
        {
        }
        public ImapClient(EmailServiceProvider provider, String userName, String password)
            : this("")
        {
            this.SetProperty(provider);
            this.UserName = userName;
            this.Password = password;
        }
        public ImapClient(String userName, String password)
            : this("")
        {
            this.UserName = userName;
            this.Password = password;
            if (userName.EndsWith("@gmail.com")) { this.SetProperty(EmailServiceProvider.Gmail); }
            if (userName.EndsWith("@outlook.com") ||
                userName.EndsWith("@live.com") ||
                userName.EndsWith("@hotmail.com")) { this.SetProperty(EmailServiceProvider.Outlook); }
            if (userName.EndsWith("@yahoo.com")) { this.SetProperty(EmailServiceProvider.YahooMail); }
            if (userName.EndsWith("@aol.com")) { this.SetProperty(EmailServiceProvider.AolMail); }
            if (userName.EndsWith("@zoho.com")) { this.SetProperty(EmailServiceProvider.ZohoMail); }
        }
        public ImapClient(String serverName)
            : this(serverName, Default.Port, Default.UserName, Default.Password)
        {
        }
        public ImapClient(String serverName, Int32 port, String userName, String password)
            : base(serverName, port, userName, password, Default)
        {
            this.MimeParser = new MimeParser();
        }

        public void SetProperty(EmailServiceProvider provider)
        {
            String serverName = "";

            switch (provider)
            {
                case EmailServiceProvider.Gmail: serverName = "imap.gmail.com"; break;
                case EmailServiceProvider.Outlook: serverName = "imap-mail.outlook.com"; break;
                case EmailServiceProvider.YahooMail: serverName = "imap.mail.yahoo.com"; break;
                case EmailServiceProvider.AolMail: serverName = "imap.aol.com"; break;
                case EmailServiceProvider.ZohoMail: serverName = "imap.zoho.com"; break;
                default: throw new InvalidOperationException();
            }
            this.ServerName = serverName;
            this.Port = 993;
            this.Ssl = true;
        }
        /// <summary>
        /// Open connection to a server.
        /// </summary>
        public ImapConnectionState Open()
        {
            if (this.Connect() == true)
            {
                this._State = ImapConnectionState.Connected;
            }
            else
            {
                this._State = ImapConnectionState.Disconnected;
            }
            return this._State;
        }
        /// サーバーへの接続が開かれていない場合、サーバーへの接続を開きます。
        /// <summary>
        /// Ensure connection is opened.
        /// サーバーへの接続が開かれていない場合、サーバーへの接続を開きます。
        /// </summary>
        public ImapConnectionState EnsureOpen()
        {
            if (this.Connected == true)
            { return this._State; }

            return this.Open();
        }
        private void ValidateState(ImapConnectionState state)
        {
            this.ValidateState(state, false);
        }
        private void ValidateState(ImapConnectionState state, Boolean folderSelected)
        {
            if (this._State != state)
            {
                switch (state)
                {
                    case ImapConnectionState.Disconnected: throw new MailClientException("You can execute this command only when State is Disconnected");
                    case ImapConnectionState.Connected: throw new MailClientException("You can execute this command only when State is Connected");
                    case ImapConnectionState.Authenticated: throw new MailClientException("You can execute this command only when State is Authenticated");
                    default: throw new MailClientException("Missing switch case of " + state.ToStringFromEnum());
                }
            }
            if (folderSelected == true && this.CurrentFolder == null)
            {
                throw new MailClientException("You must select folder before executing this command."
                  + "You can select folder by calling SelectFolder,ExecuteSelect,ExecuteExamine method of this object.");
            }
        }
        private new String GetResponseText()
        {
            MemoryStream ms = new MemoryStream();
            this.GetResponse(ms);
            return this.ResponseEncoding.GetString(ms.ToArray());
        }
        private void GetResponse(Stream stream)
        {
            Byte[] bb = this.GetResponseBytes(new ImapDataReceiveContext(this.Tag, this.ResponseEncoding));
            stream.Write(bb, 0, bb.Length);
            this.Commnicating = false;
        }
        /// <summary>
        /// Log in to imap server.Please use TryAuthenticate method if you don't want to throw exception.
        /// </summary>
        public void Authenticate()
        {
            if (this.TryAuthenticate() == false)
            {
                throw new ImapAuthenticateException();
            }
        }
        /// <summary>
        /// Log in to IMAP server and return login success or failure as bool.
        /// </summary>
        /// <returns></returns>
        public Boolean TryAuthenticate()
        {
            if (this._State == ImapConnectionState.Authenticated) { return true; }
            if (this.EnsureOpen() == ImapConnectionState.Disconnected) { return false; }
            var rs = this.ExecuteLogin();
            return this.State == ImapConnectionState.Authenticated;
        }
        private ImapCommandResult Execute(String command)
        {
            var text = this.Execute(Encoding.UTF8.GetBytes(command + SocketClient.NewLine), null);
            return new ImapCommandResult(this.Tag, text);
        }
        private String Execute(String command, String encodedCommand)
        {
            return this.Execute(Encoding.UTF8.GetBytes(command), Encoding.UTF8.GetBytes(encodedCommand));
        }
        private String Execute(Byte[] command, Byte[] encodedCommand)
        {
            if (encodedCommand == null)
            {
                this.Send(command);
                this.Commnicating = true;
                return this.GetResponseText();
            }
            else
            {
                var bb = MergeBytes(command, Encoding.UTF8.GetBytes("{" + encodedCommand.Length + "}"), NewlineBytes);
                //Send search command and get response from server. 
                var text = this.Execute(bb);
                //Server may return response text="+ go ahead" or text="+ Ready for argument"

                //Send encoded search text that you want to search
                bb = MergeBytes(encodedCommand, NewlineBytes);
                return this.Execute(bb);
            }
        }
        private String Execute(Byte[] command)
        {
            this.Send(command);
            this.Commnicating = true;
            Byte[] res = this.GetResponseBytes();
            this.Commnicating = false;
            return this.ResponseEncoding.GetString(res);
        }
        private static Byte[] MergeBytes(params Byte[][] byteArrayList)
        {
            var bytes = new Byte[byteArrayList.Sum(el => el.Length)];
            Int32 startIndex = 0;
            for (int i = 0; i < byteArrayList.Length; i++)
            {
                var bb = byteArrayList[i];
                Buffer.BlockCopy(bb, 0, bytes, startIndex, bb.Length);
                startIndex += bb.Length;
            }
            return bytes;
        }
        
        /// <summary>
        /// Send capability command to IMAP server.
        /// </summary>
        /// <returns></returns>
        public CapabilityResult ExecuteCapability()
        {
            var rs = this.Execute(this.Tag + " CAPABILITY");
            return new CapabilityResult(this.Tag, rs.Text);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ImapCommandResult ExecuteLogin()
        {
            if (this.EnsureOpen() == ImapConnectionState.Disconnected) { throw new MailClientException("Connection is not available."); }

            String commandText = String.Format(this.Tag + " LOGIN {0} \"{1}\"", this.UserName, this.Password);
            ImapCommandResult rs = this.Execute(commandText);
            if (rs.Status == ImapCommandResultStatus.Ok)
            {
                this._State = ImapConnectionState.Authenticated;
            }
            else
            {
                this._State = ImapConnectionState.Connected;
            }
            return rs;
        }
        /// <summary>
        /// Send Logout command to IMAP server.
        /// </summary>
        /// <returns></returns>
        public ImapCommandResult ExecuteLogout()
        {
            this.ValidateState(ImapConnectionState.Authenticated);
            ImapCommandResult rs = this.Execute(this.Tag + " Logout");
            if (rs.Status == ImapCommandResultStatus.Ok)
            {
                this._State = ImapConnectionState.Connected;
            }
            return rs;
        }
        /// <summary>
        /// Send select command to IMAP server.
        /// </summary>
        /// <returns></returns>
        public SelectResult ExecuteSelect(String folderName)
        {
            this.ValidateState(ImapConnectionState.Authenticated);
            String commandText = String.Format(this.Tag + " Select \"{0}\"", _ModifiedUtf7Converter.Encode(folderName));
            ImapCommandResult rs = this.Execute(commandText);
            var srs = this.GetSelectResult(folderName, rs.Text);
            this.CurrentFolder = new ImapFolder(srs);
            return srs;
        }
        /// <summary>
        /// Send examine command to IMAP server.
        /// </summary>
        /// <returns></returns>
        public SelectResult ExecuteExamine(String folderName)
        {
            this.ValidateState(ImapConnectionState.Authenticated);
            String commandText = String.Format(this.Tag + " Examine \"{0}\"", _ModifiedUtf7Converter.Encode(folderName));
            var rs = this.Execute(commandText);
            var srs = this.GetSelectResult(folderName, rs.Text);
            this.CurrentFolder = new ImapFolder(srs);
            return srs;
        }
        private SelectResult GetSelectResult(String folderName, String text)
        {
            var rs = new ImapCommandResult(this.Tag, text);
            if (rs.Status == ImapCommandResultStatus.Ok)
            {
                Int32 exists = 0;
                Int32 recent = 0;
                List<String> l = new List<string>();
                Match m = null;
                m = RegexList.SelectFolderResult.Match(rs.Text);
                if (m.Success)
                {
                    Int32.TryParse(m.Groups["exst"].Value, out exists);
                    Int32.TryParse(m.Groups["rcnt"].Value, out recent);
                }
                m = RegexList.SelectFolderResultFlagsLine.Match(rs.Text);
                if (m.Success == true)
                {
                    String flags = m.Groups["Flags"].Value;
                    foreach (var el in flags.Split(' '))
                    {
                        if (el.StartsWith("\\") == true)
                        {
                            l.Add(el.Substring(1, el.Length - 1));
                        }
                    }
                }
                return new SelectResult(folderName, exists, recent, l.ToArray());
            }
            throw new MailClientException(text);
        }
        /// <summary>
        /// Send create folder command to IMAP server.
        /// </summary>
        /// <returns></returns>
        public ImapCommandResult ExecuteCreate(String folderName)
        {
            this.ValidateState(ImapConnectionState.Authenticated);
            String commandText = String.Format(this.Tag + " Create \"{0}\"", _ModifiedUtf7Converter.Encode(folderName));
            return this.Execute(commandText);
        }
        /// <summary>
        /// Send delete folder command to IMAP server.
        /// </summary>
        /// <returns></returns>
        public ImapCommandResult ExecuteDelete(String folderName)
        {
            this.ValidateState(ImapConnectionState.Authenticated);
            String commandText = String.Format(this.Tag + " Delete \"{0}\"", _ModifiedUtf7Converter.Encode(folderName));
            return this.Execute(commandText);
        }
        /// <summary>
        /// Send close command to IMAP server.
        /// </summary>
        /// <returns></returns>
        public ImapCommandResult ExecuteClose()
        {
            this.ValidateState(ImapConnectionState.Authenticated);
            var rs = this.Execute(this.Tag + " Close");
            this.CurrentFolder = null;
            return rs;
        }
        /// <summary>
        /// Send list command to IMAP server.
        /// </summary>
        /// <param name="folderName"></param>
        /// <param name="recursive"></param>
        /// <returns></returns>
        public ListResult ExecuteList(String folderName, Boolean recursive)
        {
            this.ValidateState(ImapConnectionState.Authenticated);

            List<ListLineResult> l = new List<ListLineResult>();
            String name = "";
            Boolean noSelect = false;
            Boolean hasChildren = false;
            String rc = "%";
            if (recursive == true)
            {
                rc = "*";
            }
            var rs = this.Execute(String.Format(this.Tag + " LIST \"{0}\" \"{1}\"", folderName, rc));
            foreach (Match m in RegexList.GetListFolderResult.Matches(rs.Text))
            {
                name = _ModifiedUtf7Converter.Decode(m.Groups["name"].Value);
                foreach (Capture c in m.Groups["opt"].Captures)
                {
                    if (c.Value.ToString() == "\\Noselect")
                    {
                        noSelect = true;
                    }
                    else if (c.Value.ToString() == "\\HasNoChildren")
                    {
                        hasChildren = false;
                    }
                    else if (c.Value.ToString() == "\\HasChildren")
                    {
                        hasChildren = true;
                    }
                }
                l.Add(new ListLineResult(name, noSelect, hasChildren));
            }
            return new ListResult(l);
        }
        /// <summary>
        /// Send xlist command to IMAP server.
        /// </summary>
        /// <param name="folderName"></param>
        /// <param name="recursive"></param>
        /// <returns></returns>
        public XListResult ExecuteXList(String folderName, Boolean recursive)
        {
            this.ValidateState(ImapConnectionState.Authenticated);

            List<XListLineResult> l = new List<XListLineResult>();
            String name = "";
            Boolean noSelect = false;
            Boolean hasChildren = false;
            String rc = "%";
            String xname = "";
            if (recursive == true)
            {
                rc = "*";
            }
            var rs = this.Execute(String.Format(this.Tag + " XLIST \"{0}\" \"{1}\"", folderName, rc));
            foreach (Match m in RegexList.GetXListFolderResult.Matches(rs.Text))
            {
                xname = "";
                name = _ModifiedUtf7Converter.Decode(m.Groups["name"].Value);
                foreach (Capture c in m.Groups["opt"].Captures)
                {
                    if (c.Value.ToString() == "\\Noselect")
                    {
                        noSelect = true;
                    }
                    else if (c.Value.ToString() == "\\HasNoChildren")
                    {
                        hasChildren = false;
                    }
                    else if (c.Value.ToString() == "\\HasChildren")
                    {
                        hasChildren = true;
                    }
                    else if (c.Value.ToString().Length > 0)
                    {
                        xname = c.Value.ToString();
                    }
                }
                l.Add(new XListLineResult(name, noSelect, hasChildren, xname));
            }
            return new XListResult(l);
        }
        /// <summary>
        /// Send subscribe command to IMAP server.
        /// </summary>
        /// <returns></returns>
        public ImapCommandResult ExecuteSubscribe(String folderName)
        {
            this.ValidateState(ImapConnectionState.Authenticated);
            String commandText = String.Format(this.Tag + " Subscribe \"{0}\"", _ModifiedUtf7Converter.Encode(folderName));
            return this.Execute(commandText);
        }
        /// <summary>
        /// Send unsubscribe command to IMAP server.
        /// </summary>
        /// <returns></returns>
        public ImapCommandResult ExecuteUnsubscribe(String folderName)
        {
            this.ValidateState(ImapConnectionState.Authenticated);
            String commandText = String.Format(this.Tag + " Unsubscribe \"{0}\"", _ModifiedUtf7Converter.Encode(folderName));
            return this.Execute(commandText);
        }
        /// <summary>
        /// Send list command to IMAP server.
        /// </summary>
        /// <param name="folderName"></param>
        /// <param name="recursive"></param>
        /// <returns></returns>
        public ListResult ExecuteLsub(String folderName, Boolean recursive)
        {
            this.ValidateState(ImapConnectionState.Authenticated);

            List<ListLineResult> l = new List<ListLineResult>();
            String name = "";
            Boolean noSelect = false;
            Boolean hasChildren = false;
            String rc = "%";
            if (recursive == true)
            {
                rc = "*";
            }
            var rs = this.Execute(String.Format(this.Tag + " Lsub \"{0}\" \"{1}\"", folderName, rc));
            foreach (Match m in RegexList.GetLsubFolderResult.Matches(rs.Text))
            {
                name = _ModifiedUtf7Converter.Decode(m.Groups["name"].Value);
                foreach (Capture c in m.Groups["opt"].Captures)
                {
                    if (c.Value.ToString() == "\\Noselect")
                    {
                        noSelect = true;
                    }
                    else if (c.Value.ToString() == "\\HasNoChildren")
                    {
                        hasChildren = false;
                    }
                    else if (c.Value.ToString() == "\\HasChildren")
                    {
                        hasChildren = true;
                    }
                }
                l.Add(new ListLineResult(name, noSelect, hasChildren));
            }
            return new ListResult(l);
        }
        /// <summary>
        /// Send Fetch command to IMAP server.
        /// </summary>
        /// <param name="mailIndex"></param>
        /// <returns></returns>
        public ImapCommandResult ExecuteFetch(Int64 mailIndex)
        {
            this.ValidateState(ImapConnectionState.Authenticated, true);
            return this.Execute(String.Format(this.Tag + " FETCH {0} (BODY[])", mailIndex));
        }
        /// <summary>
        /// Send search command to IMAP server.
        /// </summary>
        /// <returns></returns>
        public SearchResult ExecuteSearch(String searchText)
        {
            String commandText = String.Format(this.Tag + " SEARCH {0}", searchText);
            return this.Search(commandText);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mailIndex"></param>
        /// <param name="command"></param>
        /// <param name="flags"></param>
        /// <returns></returns>
        public ImapCommandResult ExecuteStore(Int64 mailIndex, StoreItem command, params ImapSystemFlag[] flags)
        {
            List<String> l = new List<string>();
            foreach (var flag in flags)
            {
                if (flag == ImapSystemFlag.Recent) throw new ArgumentException("You can't set Recent flag.Only server can set this flag.");
                l.Add("\\" + flag.ToStringFromEnum());
            }
            return this.ExecuteStore(mailIndex, command, l.ToArray());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mailIndex"></param>
        /// <param name="command"></param>
        /// <param name="flags"></param>
        /// <returns></returns>
        public ImapCommandResult ExecuteStore(Int64 mailIndex, StoreItem command, params String[] flags)
        {
            if (flags.Length == 0) return null;

            this.ValidateState(ImapConnectionState.Authenticated, true);

            StringBuilder sb = new StringBuilder(256);
            sb.Append(this.Tag);
            sb.Append(" STORE ");
            sb.Append(mailIndex);
            sb.Append(" ");
            if (command == StoreItem.FlagsReplace)
            {
                sb.Append("FLAGS ");
            }
            else if (command == StoreItem.FlagsReplaceSilent)
            {
                sb.Append("FLAGS.SILENT ");
            }
            else if (command == StoreItem.FlagsAdd)
            {
                sb.Append("+FLAGS ");
            }
            else if (command == StoreItem.FlagsAddSilent)
            {
                sb.Append("+FLAGS.SILENT ");
            }
            else if (command == StoreItem.FlagsRemove)
            {
                sb.Append("-FLAGS ");
            }
            else if (command == StoreItem.FlagsRemoveSilent)
            {
                sb.Append("-FLAGS.SILENT ");
            }
            else
            {
                throw new ArgumentException("command");
            }
            sb.Append("(");
            for (int i = 0; i < flags.Length; i++)
            {
                sb.Append(flags[i]);
                if (i < flags.Length - 1)
                {
                    sb.Append(" ");
                }
            }
            sb.Append(")");

            return this.Execute(sb.ToString());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="folderName"></param>
        /// <param name="mailData"></param>
        /// <returns></returns>
        public ImapCommandResult ExecuteAppend(String folderName, String mailData)
        {
            return this.ExecuteAppend(folderName, mailData, DateTimeOffset.Now, new String[0]);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="folderName"></param>
        /// <param name="mailData"></param>
        /// <param name="flag"></param>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public ImapCommandResult ExecuteAppend(String folderName, String mailData, DateTimeOffset datetime, params String[] flags)
        {
            this.ValidateState(ImapConnectionState.Authenticated, true);

            var dateText = datetime.ToString("dd-MMM-yyyy HH:mm:ss ", new CultureInfo("en-US"));
            var ts = datetime.Offset;
            if (ts.TotalHours < 0)
            {
                dateText += String.Format("-{0:00}{1:00}", ts.Hours, ts.Minutes);
            }
            else
            {
                dateText += String.Format("+{0:00}{1:00}", ts.Hours, ts.Minutes);
            }
            String commandText = String.Format(this.Tag + " APPEND \"{0}\" ({1}) \"{2}\" "
                , _ModifiedUtf7Converter.Encode(folderName), String.Join(" ", flags), dateText);
            var text = this.Execute(commandText, mailData);
            return new ImapCommandResult(this.Tag, text);
        }
        /// <summary>
        /// Send rename folder command to IMAP server.
        /// </summary>
        /// <returns></returns>
        public ImapCommandResult ExecuteRename(String oldFolderName, String folderName)
        {
            this.ValidateState(ImapConnectionState.Authenticated);
            String commandText = String.Format(this.Tag + " Rename \"{0}\" \"{1}\""
                , _ModifiedUtf7Converter.Encode(oldFolderName), _ModifiedUtf7Converter.Encode(folderName));
            var rs = this.Execute(commandText);
            if (rs.Status == ImapCommandResultStatus.Ok ||
                rs.Status == ImapCommandResultStatus.None)
            {
                return rs;
            }
            return rs;
        }
        /// <summary>
        /// Send rlsub command to IMAP server.
        /// </summary>
        /// <param name="folderName"></param>
        /// <param name="recursive"></param>
        /// <returns></returns>
        public ListResult ExecuteRlsub(String folderName, Boolean recursive)
        {
            this.ValidateState(ImapConnectionState.Authenticated);

            List<ListLineResult> l = new List<ListLineResult>();
            String name = "";
            Boolean noSelect = false;
            Boolean hasChildren = false;
            String rc = "%";
            if (recursive == true)
            {
                rc = "*";
            }
            var rs = this.Execute(String.Format(this.Tag + " RLSUB \"{0}\" \"{1}\"", folderName, rc));
            foreach (Match m in RegexList.GetRlsubFolderResult.Matches(rs.Text))
            {
                name = _ModifiedUtf7Converter.Decode(m.Groups["name"].Value);
                foreach (Capture c in m.Groups["opt"].Captures)
                {
                    if (c.Value.ToString() == "\\Noselect")
                    {
                        noSelect = true;
                    }
                    else if (c.Value.ToString() == "\\HasNoChildren")
                    {
                        hasChildren = false;
                    }
                    else if (c.Value.ToString() == "\\HasChildren")
                    {
                        hasChildren = true;
                    }
                }
                l.Add(new ListLineResult(name, noSelect, hasChildren));
            }
            return new ListResult(l);

        }
        /// <summary>
        /// Send status command to IMAP server.
        /// </summary>
        /// <param name="folderName"></param>
        /// <param name="message"></param>
        /// <param name="recent"></param>
        /// <param name="uidnext"></param>
        /// <param name="uidvalidity"></param>
        /// <param name="unseen"></param>
        /// <returns></returns>
        public ImapCommandResult ExecuteStatus(String folderName, Boolean message, Boolean recent, Boolean uidnext, Boolean uidvalidity, Boolean unseen)
        {
            this.ValidateState(ImapConnectionState.Authenticated);
            StringBuilder sb = new StringBuilder(256);
            sb.Append(this.Tag);
            sb.Append(" Status ");
            sb.AppendFormat("\"{0}\"", _ModifiedUtf7Converter.Encode(folderName));
            if (message || recent || uidnext || uidvalidity || unseen)
            {
                sb.Append(" ");
                sb.Append("(");
                if (message)
                {
                    sb.Append("messages");
                }

                if (recent)
                {
                    sb.Append(" recent");
                }

                if (uidnext)
                {
                    sb.Append(" uidnext");
                }

                if (uidvalidity)
                {
                    sb.Append(" uidvalidity");
                }

                if (unseen)
                {
                    sb.Append(" unseen");
                }

                sb.Append(")");
            }

            var rs = this.Execute(sb.ToString());
            if (rs.Status == ImapCommandResultStatus.Ok ||
                rs.Status == ImapCommandResultStatus.None)
            {
                return rs;
            }
            return rs;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ImapCommandResult ExecuteCheck()
        {
            this.ValidateState(ImapConnectionState.Authenticated, true);
            return this.Execute(this.Tag + " Check");
        }
        /// <summary>
        /// Send copy command to IMAP server.
        /// </summary>
        /// <param name="mailindexstart"></param>
        /// <param name="mailindexend"></param>
        /// <param name="folderName"></param>
        /// <returns></returns>
        public ImapCommandResult ExecuteCopy(Int32 mailindexstart, Int32 mailindexend, String folderName)
        {
            this.ValidateState(ImapConnectionState.Authenticated);
            StringBuilder sb = new StringBuilder(256);
            sb.Append(this.Tag);
            sb.Append(" Copy ");
            if (!Int32.Equals(mailindexstart, 0))
            {
                sb.Append(mailindexstart);
            }
            if (!Int32.Equals(mailindexend, 0) && !Int32.Equals(mailindexstart, 0))
            {
                sb.Append(":");
                sb.Append(mailindexend);
            }
            else if (!Int32.Equals(mailindexend, 0))
            {
                sb.Append(mailindexend);
            }
            sb.Append(" ");
            sb.AppendFormat("\"{0}\"", _ModifiedUtf7Converter.Encode(folderName));

            var rs = this.Execute(sb.ToString());
            if (rs.Status == ImapCommandResultStatus.Ok ||
                rs.Status == ImapCommandResultStatus.None)
            {
                return rs;
            }
            return rs;

        }
        /// <summary>
        /// Send UID command to IMAP server.
        /// <param name="command"></param>
        /// </summary>
        /// <returns></returns>
        public ImapCommandResult ExecuteUid(String command)
        {
            this.ValidateState(ImapConnectionState.Authenticated);
            return this.Execute(this.Tag + " UID " + command);
        }
        /// <summary>
        /// Send NAMESPACE command to IMAP server.
        /// </summary>
        /// <returns></returns>
        public ImapCommandResult ExecuteNamespace()
        {
            this.ValidateState(ImapConnectionState.Authenticated);
            return this.Execute(this.Tag + " NAMESPACE");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ImapIdleCommand CreateImapIdleCommand()
        {
            return new ImapIdleCommand(this.Tag, this.ResponseEncoding);
        }
        /// <summary>
        /// Send IDLE command to IMAP server.
        /// You can receive message from server by register event handler to MessageReceived event of ImapIdleCommand object
        /// </summary>
        /// <returns></returns>
        public void ExecuteIdle(ImapIdleCommand command)
        {
            this.ValidateState(ImapConnectionState.Authenticated);
            this.Send(this.Tag + " IDLE");
            var bb = command.Buffer;
            command.IAsyncResult = this.Stream.BeginRead(bb, 0, bb.Length, this.ExecuteIdleCallback, command);
            this._State = ImapConnectionState.Idle;
        }
        private void ExecuteIdleCallback(IAsyncResult result)
        {
            ImapIdleCommand cx = null;

            try
            {
                cx = (ImapIdleCommand)result.AsyncState;
                if (this.Socket == null)
                {
                    throw new SocketClientException("Connection is closed");
                }
                Int32 size = Stream.EndRead(result);
                if (cx.ReadBuffer(size) == true)
                {
                    var bb = cx.Buffer;
                    this.Stream.BeginRead(bb, 0, bb.Length, this.GetResponseCallback, cx);
                }
                else
                {
                    cx.Dispose();
                }
            }
            catch (Exception ex)
            {
                cx.Exception = ex;
                this.OnError(ex);
            }
            finally
            {
                if (cx.Exception != null)
                {
                    cx.Dispose();
                }
            }
        }
        /// <summary>
        /// Send done command to IMAP server.
        /// </summary>
        /// <returns></returns>
        public ImapCommandResult ExecuteDone(ImapIdleCommand command)
        {
            this.ValidateState(ImapConnectionState.Idle);
            if (command.IAsyncResult != null)
            {
                var x = this.Stream.EndRead(command.IAsyncResult);
            }
            var rs = this.Execute("DONE");
            this._State = ImapConnectionState.Authenticated;
            return rs;
        }
        /// <summary>
        /// Send GetQuota command to IMAP server.
        /// <param name="resourceName"></param>
        /// </summary>
        /// <returns></returns>
        public ImapCommandResult ExecuteGetQuota(String resourceName)
        {
            return this.Execute(this.Tag + " GetQuota " + resourceName);
        }
        /// <summary>
        /// Send SETQUOTA command to IMAP server.
        /// <param name="resourceName"></param>
        /// </summary>
        /// <returns></returns>
        public ImapCommandResult ExecuteSetQuota(String resourceName)
        {
            return this.Execute(this.Tag + " SETQUOTA " + resourceName);
        }
        /// <summary>
        /// Send GETQUOTAROOT command to IMAP server.
        /// <param name="folderName"></param>
        /// </summary>
        /// <returns></returns>
        public ImapCommandResult ExecuteGetQuotaRoot(String folderName)
        {
            String commandText = String.Format(this.Tag + " GETQUOTAROOT \"{0}\"", _ModifiedUtf7Converter.Encode(folderName));
            return this.Execute(commandText);
        }
        /// <summary>
        /// Send noop command to IMAP server.
        /// </summary>
        /// <returns></returns>
        public ImapCommandResult ExecuteNoop()
        {
            this.ValidateState(ImapConnectionState.Authenticated);
            return this.Execute(this.Tag + " NOOP");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ImapCommandResult ExecuteExpunge()
        {
            this.ValidateState(ImapConnectionState.Authenticated);
            return this.Execute(this.Tag + " EXPUNGE");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="folderName"></param>
        public ImapFolder SelectFolder(String folderName)
        {
            var rs = this.ExecuteSelect(folderName);
            return new ImapFolder(rs);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="folderName"></param>
        public void UnselectFolder(String folderName)
        {
            this.ExecuteClose();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<ImapFolder> GetAllFolders()
        {
            return this.GetFolders("", true);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="folderName"></param>
        /// <param name="recursive"></param>
        /// <returns></returns>
        public List<ImapFolder> GetFolders(String folderName, Boolean recursive)
        {
            ValidateState(ImapConnectionState.Authenticated);
            List<ImapFolder> l = new List<ImapFolder>();
            var rs = this.ExecuteList(folderName, recursive);
            foreach (var el in rs.Lines)
            {
                l.Add(new ImapFolder(el));
            }
            return l;
        }

        public SearchResult Search(SearchByKeywordCommandKey key)
        {
            var cm = new SearchByKeywordCommand();
            cm.Key = key;
            return this.Search(cm);
        }
        public SearchResult Search(SearchByValueCommandKey key, String value)
        {
            var cm = new SearchByValueCommand();
            cm.Key = key;
            cm.Value = value;
            return this.Search(cm);
        }
        public SearchResult Search(SearchByDateTimeCommandKey key, DateTime value)
        {
            var cm = new SearchByDateTimeCommand();
            cm.Key = key;
            cm.Value = value;
            return this.Search(cm);
        }
        public SearchResult Search(String headerFieldName, String value)
        {
            var cm = new SearchHeaderCommand();
            cm.FieldName = headerFieldName;
            cm.Value = value;
            return this.Search(cm);
        }
        public SearchResult Search(SearchCommand command)
        {
            if (command.IsEncodeValue == true)
            {
                this.ValidateState(ImapConnectionState.Authenticated, true);
                var searchText = this.Execute(Encoding.UTF8.GetBytes(this.Tag + " " + command.GetCommandText()), command.GetEncodedValue());
                if (searchText.StartsWith("* Search", StringComparison.OrdinalIgnoreCase) == false)
                {
                    throw new MailClientException(searchText);
                }
                var bb = this.GetResponseBytes();
                var rs = new ImapCommandResult(this.Tag, this.ResponseEncoding.GetString(bb));
                if (rs.Status == ImapCommandResultStatus.Ok)
                {
                    return new SearchResult(searchText);
                }
                throw new MailClientException(rs.Text);
            }
            else
            {
                var text = this.Tag + " " + command.GetCommandText();
                return this.Search(text);
            }
        }
        private SearchResult Search(String commandText)
        {
            this.ValidateState(ImapConnectionState.Authenticated, true);
            var rs = this.Execute(commandText);
            if (rs.Status == ImapCommandResultStatus.Ok)
            {
                return new SearchResult(rs.Text);
            }
            throw new MailClientException(rs.Text);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mailIndex"></param>
        /// <returns></returns>
        public MailMessage GetMessage(Int64 mailIndex)
        {
            return this.GetMessage(mailIndex, false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mailIndex"></param>
        /// <param name="setAsSeen"></param>
        /// <returns></returns>
        public MailMessage GetMessage(Int64 mailIndex, Boolean setAsSeen)
        {
            this.ValidateState(ImapConnectionState.Authenticated, true);
            String commandText = String.Format(this.Tag + " FETCH {0} (BODY[])", mailIndex);
            if (setAsSeen == false)
            {
                commandText = String.Format(this.Tag + " FETCH {0} (BODY.PEEK[])", mailIndex);
            }
            var result = this.Execute(commandText);
            if (result.Status == ImapCommandResultStatus.Bad) { throw new MailClientException(result.Text); }
            var text = this.GetMessageText(result.Text);
            this.MimeParser.Encoding = this.ResponseEncoding;
            return this.MimeParser.ToMailMessage(text);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mailIndexList"></param>
        /// <returns></returns>
        public List<MailMessage> GetMessages(params Int32[] mailIndexList)
        {
            return this.GetMessages(mailIndexList.Select(el => (Int64)el));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mailIndexList"></param>
        /// <returns></returns>
        public List<MailMessage> GetMessages(IEnumerable<Int32> mailIndexList)
        {
            return this.GetMessages(mailIndexList.Select(el => (Int64)el));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mailIndex"></param>
        /// <param name="setAsSeen"></param>
        /// <returns></returns>
        public List<MailMessage> GetMessages(IEnumerable<Int64> mailIndexList)
        {
            this.ValidateState(ImapConnectionState.Authenticated, true);
            String commandText = String.Format(this.Tag + " FETCH {0} (BODY.PEEK[])", this.CreateIndexList(mailIndexList));
            var result = this.Execute(commandText);
            if (result.Status == ImapCommandResultStatus.Bad) { throw new MailClientException(result.Text); }
            var l = this.CreateMailMessages(result.Text);
            return l;
        }
        private List<MailMessage> CreateMailMessages(String text)
        {
            List<MailMessage> l = new List<MailMessage>();
            StringReader sr = new StringReader(text);
            Boolean readingHeader = false;
            String endOfLine = String.Format("{0} OK FETCH Completed", this.Tag);
            StringBuilder sb = new StringBuilder(256);

            while (true)
            {
                var line = sr.ReadLine();
                if (readingHeader == false &&
                    line.StartsWith("* ") == true)
                {
                    sb.Length = 0;
                    readingHeader = true;
                    continue;
                }
                if (readingHeader == true)
                {
                    if (line == ")")
                    {
                        sb.Append(".");
                        try
                        {
                            var mg = this.MimeParser.ToMailMessage(sb.ToString());
                            l.Add(mg);
                            readingHeader = false;
                            continue;
                        }
                        catch (InvalidMimeMessageException ex)
                        {
                            if (this.ThrowExceptionOnInvalidMailMessage)
                            {
                                throw;
                            }
                            var mg = new InvalidMailMessage(ex.MimeMessage, text, ex.ParseText);
                            l.Add(mg);
                        }
                    }
                    else
                    {
                        sb.AppendLine(line);
                    }
                }
                if (String.Equals(line, endOfLine, StringComparison.OrdinalIgnoreCase) == true) { break; }
                if (sr.Peek() == -1) { break; }
            }

            return l;
        }
        private String GetMessageText(String text)
        {
            StringBuilder sb = new StringBuilder(text.Length);
            StringReader sr = new StringReader(text);
            String endOfLine = String.Format("{0} OK", this.Tag);
            Boolean isFirstLine = true;
            while (true)
            {
                var line = sr.ReadLine();
                if (isFirstLine == true && line.StartsWith("*") == true) { continue; }
                if (line.StartsWith(")") == true) { continue; }
                if (line.StartsWith(endOfLine, StringComparison.OrdinalIgnoreCase) == true) { break; }
                sb.AppendLine(line);

                if (sr.Peek() == -1) { break; }
            }
            return sb.ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public IEnumerable<FetchCommandResult<Int32>> GetMessageSizes(Int32 startIndex, Int32 endIndex)
        {
            this.ValidateState(ImapConnectionState.Authenticated, true);
            var command = String.Format("{0} FETCH {1}:{2} RFC822.SIZE"
                , this.Tag, startIndex, endIndex);
            var result = this.Execute(command);
            //CharCount = "RFC822.SIZE ".Length+1 --> 13
            return this.GetHeaderValues(result.Text, 13).Select(el => new FetchCommandResult<Int32>(el.MailIndex, Int32.Parse(el.Value)));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public String GetUid(Int32 index)
        {
            var f = this.GetUidList(index, index).FirstOrDefault();
            if (f == null) { return null; }
            return f.Value;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public IEnumerable<FetchCommandResult<String>> GetUidList(Int32 startIndex, Int32 endIndex)
        {
            this.ValidateState(ImapConnectionState.Authenticated, true);
            var command = String.Format("{0} FETCH {1}:{2} UID"
                , this.Tag, startIndex, endIndex);
            var result = this.Execute(command);
            //CharCount = "UID ".Length+1 --> 5
            return this.GetHeaderValues(result.Text, 5);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public ImapMessageFlag GetMessageFlag(Int32 index)
        {
            var f = this.GetMessageFlags(index, index).FirstOrDefault();
            if (f == null) { return null; }
            return f.Value;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public IEnumerable<FetchCommandResult<ImapMessageFlag>> GetMessageFlags(Int32 startIndex, Int32 endIndex)
        {
            ImapMessageFlag f = null;

            this.ValidateState(ImapConnectionState.Authenticated, true);
            var command = String.Format("{0} FETCH {1}:{2} FLAGS"
                , this.Tag, startIndex, endIndex);
            var result = this.Execute(command);
            //CharCount = "FLAGS ".Length+1 --> 7
            foreach (var item in this.GetHeaderValues(result.Text, 8))
            {
                f = new ImapMessageFlag();
                var ss = item.Value.Split(' ');
                for (int i = 0; i < ss.Length; i++)
                {
                    f.Add(ss[i].TrimStart('\\'));
                }
                yield return new FetchCommandResult<ImapMessageFlag>(item.MailIndex, f);
            }
            yield break;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public DateTimeOffset? GetInternalDate(Int32 index)
        {
            var f = this.GetInternalDates(index, index).FirstOrDefault();
            if (f == null) { return null; }
            return f.Value;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public IEnumerable<FetchCommandResult<DateTimeOffset>> GetInternalDates(Int32 startIndex, Int32 endIndex)
        {
            this.ValidateState(ImapConnectionState.Authenticated, true);
            var command = String.Format("{0} FETCH {1}:{2} INTERNALDATE"
                , this.Tag, startIndex, endIndex);
            var result = this.Execute(command);
            //CharCount = "INTERNALDATE ".Length+1 --> 14
            return this.GetHeaderValues(result.Text, 14).Select(el => new FetchCommandResult<DateTimeOffset>(el.MailIndex, DateTimeOffset.Parse(el.Value.Trim('"'))));
        }
        private IEnumerable<FetchCommandResult<String>> GetHeaderValues(String text, Int32 charCount)
        {
            StringReader sr = new StringReader(text);
            String endOfLine = String.Format("{0} OK FETCH Completed", this.Tag);

            while (true)
            {
                var line = sr.ReadLine();
                if (String.Equals(line, endOfLine, StringComparison.OrdinalIgnoreCase) == true) { break; }

                var mIndex = Int32.Parse(line.Substring(2, line.IndexOf(' ', 2) - 2));
                var sIndex = line.IndexOf("(");
                var eIndex = line.IndexOf(")");
                var value = line.Substring(sIndex + charCount, eIndex - (sIndex + charCount));
                yield return new FetchCommandResult<String>(mIndex, value);

                if (sr.Peek() == -1) { break; }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mailIndex"></param>
        /// <returns></returns>
        public MailHeaderCollection GetHeaderCollection(Int32 mailIndex)
        {
            var l = GetHeaderCollections(mailIndex, mailIndex);
            if (l.Count > 0) { return l[0]; }
            throw new ArgumentException("Message does not exist of this mailIndex");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mailIndex"></param>
        /// <param name="headerKeys"></param>
        /// <returns></returns>
        public MailHeaderCollection GetHeaderCollection(Int32 mailIndex, params String[] headerKeys)
        {
            var l = GetHeaderCollections(mailIndex, mailIndex, headerKeys);
            if (l.Count > 0) { return l[0]; }
            throw new ArgumentException("Message does not exist of this mailIndex");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<MailHeaderCollection> GetHeaderCollections()
        {
            this.ValidateState(ImapConnectionState.Authenticated, true);
            return GetHeaderCollections(1, this.CurrentFolder.MailCount);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public List<MailHeaderCollection> GetHeaderCollections(Int32 startIndex, Int32 endIndex)
        {
            this.ValidateState(ImapConnectionState.Authenticated, true);

            var command = String.Format("{0} FETCH {1}:{2} RFC822.HEADER"
                , this.Tag, startIndex, endIndex);
            var result = this.Execute(command);

            return this.CreateMailHeaderCollections(result.Text);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mailIndexList"></param>
        /// <returns></returns>
        public List<MailHeaderCollection> GetHeaderCollections(params Int32[] mailIndexList)
        {
            return this.GetHeaderCollections(mailIndexList.Select(el => (Int64)el));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mailIndexList"></param>
        /// <returns></returns>
        public List<MailHeaderCollection> GetHeaderCollections(IEnumerable<Int32> mailIndexList)
        {
            return this.GetHeaderCollections(mailIndexList.Select(el => (Int64)el));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="indices"></param>
        /// <returns></returns>
        public List<MailHeaderCollection> GetHeaderCollections(IEnumerable<Int64> mailIndexList)
        {
            this.ValidateState(ImapConnectionState.Authenticated, true);
            var command = String.Format("{0} FETCH {1} RFC822.HEADER"
                , this.Tag, this.CreateIndexList(mailIndexList));
            var result = this.Execute(command);

            return this.CreateMailHeaderCollections(result.Text);
        }
        private String CreateIndexList(IEnumerable<Int64> mailIndexList)
        {
            var sb = new StringBuilder();
            foreach (var index in mailIndexList)
            {
                sb.Append(index);
                sb.Append(",");
            }
            if (sb.Length == 0) { return ""; }

            return sb.Remove(sb.Length - 1, 1).ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="headerKeys"></param>
        /// <returns></returns>
        public List<MailHeaderCollection> GetHeaderCollections(params String[] headerKeys)
        {
            this.ValidateState(ImapConnectionState.Authenticated, true);
            return GetHeaderCollections(1, this.CurrentFolder.MailCount, headerKeys);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <param name="headerKeys"></param>
        /// <returns></returns>
        public List<MailHeaderCollection> GetHeaderCollections(Int32 startIndex, Int32 endIndex, params String[] headerKeys)
        {
            this.ValidateState(ImapConnectionState.Authenticated, true);

            var command = String.Format("{0} FETCH {1}:{2} (BODY[HEADER.FIELDS ({3})])"
                , this.Tag, startIndex, endIndex, String.Join(" ", headerKeys));
            var result = this.Execute(command);

            return this.CreateMailHeaderCollections(result.Text);
        }
        private List<MailHeaderCollection> CreateMailHeaderCollections(String text)
        {
            List<MailHeaderCollection> l = new List<MailHeaderCollection>();
            StringReader sr = new StringReader(text);
            Boolean readingHeader = false;
            Boolean endHeader = false;
            String endOfLine = String.Format("{0} OK FETCH Completed", this.Tag);
            Boolean loadContents = this.MimeParser.Filter.LoadContents;

            this.MimeParser.Filter.LoadContents = false;
            StringBuilder sb = new StringBuilder(256);
            while (true)
            {
                var line = sr.ReadLine();
                if (readingHeader == false &&
                    line.StartsWith("* ") == true)
                {
                    sb.Length = 0;
                    readingHeader = true;
                    endHeader = false;
                    continue;
                }
                if (readingHeader == true)
                {
                    //Блок может быть завершен или 
                    //)
                    //или
                    //  FLAGS (\Seen))
                    //пичаль с if (line.EndsWith(")") == true) в том что бывают даты ... (GMT+00:00)
                    if ((line.EndsWith(")") == true) && endHeader)
                    {
                        var mg = this.MimeParser.ToMailMessage(sb.ToString());
                        l.Add(mg.Headers);
                        readingHeader = false;
                        continue;
                    }
                    else
                    {
                        sb.AppendLine(line);
                    }
                    if (String.IsNullOrEmpty(line))
                        endHeader = true;
                }
                if (String.Equals(line, endOfLine, StringComparison.OrdinalIgnoreCase) == true) { break; }
                if (sr.Peek() == -1) { break; }
            }
            this.MimeParser.Filter.LoadContents = loadContents;

            return l;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="folderName"></param>
        /// <param name="message"></param>
        public Boolean SaveMail(String folderName, Boolean draft, Smtp.SmtpMessage message)
        {
            var flag = "";
            if (draft == true)
            {
                flag = "\\Draft";
            }
            var rs = this.ExecuteAppend(folderName, message.GetRawText(), DateTimeOffset.Now, flag);
            return rs.Status == ImapCommandResultStatus.Ok;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mailIndexList"></param>
        /// <returns></returns>
        public Boolean ReadMail(params Int64[] mailIndexList)
        {
            if (mailIndexList.Length == 0) return true;
            this.ValidateState(ImapConnectionState.Authenticated, true);
            return this.SetMailStore(StoreItem.FlagsAdd, ImapSystemFlag.Seen, mailIndexList);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mailIndexList"></param>
        /// <returns></returns>
        public Boolean UnReadMail(params Int64[] mailIndexList)
        {
            if (mailIndexList.Length == 0) return true;
            this.ValidateState(ImapConnectionState.Authenticated, true);
            return this.SetMailStore(StoreItem.FlagsRemove, ImapSystemFlag.Seen, mailIndexList);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mailIndexList"></param>
        /// <returns></returns>
        public Boolean DeleteMail(params Int64[] mailIndexList)
        {
            if (mailIndexList.Length == 0) return true;
            this.ValidateState(ImapConnectionState.Authenticated, true);
            var bl = this.SetMailStore(StoreItem.FlagsAdd, ImapSystemFlag.Deleted, mailIndexList);
            if (bl == false) { return false; }
            this.ExecuteExpunge();
            return true;
        }
        private Boolean SetMailStore(StoreItem storeItem, ImapSystemFlag value, params Int64[] mailIndexList)
        {
            return this.SetMailStore(storeItem, "\\" + value.ToStringFromEnum(), mailIndexList);
        }
        private Boolean SetMailStore(StoreItem storeItem, String value, params Int64[] mailIndexList)
        {
            this.ValidateState(ImapConnectionState.Authenticated, true);
            for (int i = 0; i < mailIndexList.Length; i++)
            {
                var rs = this.ExecuteStore(mailIndexList[i], storeItem, value);
                if (rs.Status != ImapCommandResultStatus.Ok) { return false; }
            }
            return true;
        }

        /// <summary>
        /// disconnect connection to IMAP server.
        /// </summary>
        public override void Close()
        {
            base.Close();
            this._State = ImapConnectionState.Disconnected;
        }
        /// <summary>
        /// 
        /// </summary>
        ~ImapClient()
        {
            this.Dispose(false);
        }

    }
}
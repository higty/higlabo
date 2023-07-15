using System;
using HigLabo.Core;

namespace Hignull.Core
{
    public class HignullText : LanguageText
    {
        protected override string[] LanguageList
        {
            get
            {
                return new string[] { "en-US","ja-JP" };
            }
        }
        public string Add
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Add";
                    case "ja-JP": return "追加";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string AddCategory
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Add category";
                    case "ja-JP": return "カテゴリの追加";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string AddComment
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Add comment";
                    case "ja-JP": return "コメントの追加";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string AddImage
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Add image";
                    case "ja-JP": return "画像の追加";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string AddProject
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Add project";
                    case "ja-JP": return "プロジェクトの追加";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string AddTask
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Add task";
                    case "ja-JP": return "タスクの追加";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string AddUser
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Add user";
                    case "ja-JP": return "ユーザーの追加";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Affiliation
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Affilication";
                    case "ja-JP": return "所属";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string AffiliationName
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Affilication name";
                    case "ja-JP": return "所属名";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string AgeSuffix
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "year of age";
                    case "ja-JP": return "歳";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string All
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "All";
                    case "ja-JP": return "全て";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string ApiNotFound
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "API not found";
                    case "ja-JP": return "APIが見つかりませんでした。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string AuthenticateExpired
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Authenticate token expired.Please retry to login.";
                    case "ja-JP": return "認証情報の有効期限が切れました。再度ログインをしてください。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string AuthenticateRequired
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Authenticate required.";
                    case "ja-JP": return "認証が必要です。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string AuthenticationFailure
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Authenticate failure.";
                    case "ja-JP": return "認証に失敗しました。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Billing
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Billing";
                    case "ja-JP": return "請求";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Birthday
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Birthday";
                    case "ja-JP": return "誕生日";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Birthplace
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Birth place";
                    case "ja-JP": return "出身地";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string BloodType
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Blood type";
                    case "ja-JP": return "血液型";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string BodyHeight
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Body height";
                    case "ja-JP": return "身長";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Calendar
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Calendar";
                    case "ja-JP": return "カレンダー";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Cancel
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Cancel";
                    case "ja-JP": return "キャンセル";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Category
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Category";
                    case "ja-JP": return "カテゴリ";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Change
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Change";
                    case "ja-JP": return "変更";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string ChangeProfileImage
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Change profile image";
                    case "ja-JP": return "プロフィール画像の変更";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Chat
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Chat";
                    case "ja-JP": return "チャット";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Clear
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Clear";
                    case "ja-JP": return "クリア";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Close
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Close";
                    case "ja-JP": return "閉じる";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Command
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Command";
                    case "ja-JP": return "コマンド";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Comment
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Comment";
                    case "ja-JP": return "コメント";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string CommentList
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Comment list";
                    case "ja-JP": return "コメント一覧";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string CompanyName
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Company name";
                    case "ja-JP": return "会社名";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Complete
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Complete";
                    case "ja-JP": return "完了";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Confirm_DeleteThisData
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Delete this data?";
                    case "ja-JP": return "このデータを削除します。よろしいですか？";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Confirm_No
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "No";
                    case "ja-JP": return "いいえ";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Confirm_Yes
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Yes";
                    case "ja-JP": return "はい";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string ConfirmDelete
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Delete?";
                    case "ja-JP": return "削除します。よろしいですか？";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Confirmed
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Confirmed";
                    case "ja-JP": return "確認済";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string ConfirmationRequired
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Confirmation required";
                    case "ja-JP": return "確認が必要です。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string ContextMenu
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Context menu";
                    case "ja-JP": return "コンテキストメニュー";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Create
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Create";
                    case "ja-JP": return "作成";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string CreateNew
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Create new";
                    case "ja-JP": return "新規作成";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string CreateNewAccount
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Create account";
                    case "ja-JP": return "アカウントを作成";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string CreateTime
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "CreateTime";
                    case "ja-JP": return "作成時刻";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string DashBoard
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Dash board";
                    case "ja-JP": return "ダッシュボード";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string DataAddedSuccessfully
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Data added successfully.";
                    case "ja-JP": return "データが正常に追加されました。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string DataDeletedSuccessfully
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Data deleted successfully.";
                    case "ja-JP": return "データが正常に削除されました。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string DataUpdatedSuccessfully
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Data updated successfully.";
                    case "ja-JP": return "データが正常に更新されました。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string DataProcessedSuccessfully
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Data processed successfully.";
                    case "ja-JP": return "データが正常に処理されました。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Date
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Date";
                    case "ja-JP": return "日付";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Decide
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Decide";
                    case "ja-JP": return "決定";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Delete
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Delete";
                    case "ja-JP": return "削除";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Description
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Description";
                    case "ja-JP": return "詳細";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string DirectoryNotFound
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Directory not found.";
                    case "ja-JP": return "ディレクトリが見つかりません。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Display
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Display";
                    case "ja-JP": return "表示";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string DisplayAll
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Display all";
                    case "ja-JP": return "全て表示";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string DisplayName
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Display name";
                    case "ja-JP": return "表示名";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Download
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Download";
                    case "ja-JP": return "ダウンロード";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string DownloadByBrowser
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Download by browser";
                    case "ja-JP": return "ブラウザでダウンロード";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Draft
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Draft";
                    case "ja-JP": return "下書き";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string DueDate
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Due date";
                    case "ja-JP": return "締切日";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Duplicate
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Duplicate";
                    case "ja-JP": return "複製";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Duration
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Duration";
                    case "ja-JP": return "期間";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Edit
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Edit";
                    case "ja-JP": return "編集";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Encoding
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Encoding";
                    case "ja-JP": return "エンコーディング";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string EndDate
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "End date";
                    case "ja-JP": return "終了日";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string EndTime
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "End time";
                    case "ja-JP": return "終了時刻";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Export
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Export";
                    case "ja-JP": return "出力";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Execute
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Execute";
                    case "ja-JP": return "実行";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string File
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "File";
                    case "ja-JP": return "ファイル";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string FileNotFound
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "File not found.";
                    case "ja-JP": return "ファイルが見つかりません。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string FileSizeMustBeSmallerThan_
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "File size must be smaller than {0} byte.";
                    case "ja-JP": return "ファイルが大きすぎます。{0}バイト以下である必要があります。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Filter
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Filter";
                    case "ja-JP": return "フィルタ";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string FilterCondition
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Filter condition";
                    case "ja-JP": return "フィルタ条件";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string FolderNotFound
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Folder not found.";
                    case "ja-JP": return "フォルダが見つかりません。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string TextColor
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Text color";
                    case "ja-JP": return "文字色";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string ForgetPassword
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Forget password？";
                    case "ja-JP": return "パスワードを忘れた？";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Gender
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Gender";
                    case "ja-JP": return "性別";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Generate
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Generate";
                    case "ja-JP": return "生成";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string HashTag
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Hash tag";
                    case "ja-JP": return "ハッシュタグ";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Home
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Home";
                    case "ja-JP": return "ホーム";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Hour
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Hour";
                    case "ja-JP": return "時間";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string IAgreeTermsOfUse
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "I agree terms of use.";
                    case "ja-JP": return "利用規約に同意する";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string IAgreeTermsOfUseAndPrivacyPolicy
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "I agree terms of use and privacy policy.";
                    case "ja-JP": return "利用規約とプライバシーポリシーに同意する";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string ImageUrl
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Image url";
                    case "ja-JP": return "画像URL";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Import
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Import";
                    case "ja-JP": return "インポート";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string InComplete
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Incomplete";
                    case "ja-JP": return "未完了";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string InputForm
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Input form";
                    case "ja-JP": return "入力フォーム";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string InputSample
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Input sample";
                    case "ja-JP": return "入力例";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string InputValue
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Input value";
                    case "ja-JP": return "入力値";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Inquiry
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Inquiry";
                    case "ja-JP": return "問い合わせ";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Kana
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Kana";
                    case "ja-JP": return "カナ";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Language
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Language";
                    case "ja-JP": return "言語";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string LastAccessTime
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Last access time";
                    case "ja-JP": return "最終アクセス時刻";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string LastDayOfMonth
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Last day of month";
                    case "ja-JP": return "月末";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Later
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Later";
                    case "ja-JP": return "後で";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string License
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "License";
                    case "ja-JP": return "ライセンス";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Link
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Link";
                    case "ja-JP": return "リンク";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string List
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "List";
                    case "ja-JP": return "一覧";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Load
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Load";
                    case "ja-JP": return "ロード";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Login
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Login";
                    case "ja-JP": return "ログイン";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Logout
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Logout";
                    case "ja-JP": return "ログアウト";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string MailAddress
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "MailAddress";
                    case "ja-JP": return "メールアドレス";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string MailIsSent
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Mail is sent";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string MainImage
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Main image";
                    case "ja-JP": return "メイン画像";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Man
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Man";
                    case "ja-JP": return "男性";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string ManageUser
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "ManageUser";
                    case "ja-JP": return "ユーザーの管理";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Maximize
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Maximize";
                    case "ja-JP": return "最大化";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Minimize
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Minimize";
                    case "ja-JP": return "最小化";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Member
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Member";
                    case "ja-JP": return "メンバー";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Menu
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Menu";
                    case "ja-JP": return "メニュー";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Message
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Message";
                    case "ja-JP": return "メッセージ";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Minute
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Minute";
                    case "ja-JP": return "分";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Name
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Name";
                    case "ja-JP": return "名前";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string NewPassword
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "New password";
                    case "ja-JP": return "新しいパスワード";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string NextMonth
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Next month";
                    case "ja-JP": return "翌月";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Notification
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Notification";
                    case "ja-JP": return "通知";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string NotConfirmed
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Not confirmed";
                    case "ja-JP": return "未確認";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string NowRedirecting
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Now redirecting...";
                    case "ja-JP": return "リダイレクト中です。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Other
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Other";
                    case "ja-JP": return "その他";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Page
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Page";
                    case "ja-JP": return "ページ";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string PageNotFound
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Page not found.";
                    case "ja-JP": return "ページが見つかりません。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Password
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Password";
                    case "ja-JP": return "パスワード";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string PasswordSettings
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Password settings";
                    case "ja-JP": return "パスワードの設定";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string PleaseSelect
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Please select.";
                    case "ja-JP": return "選択してください。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string PreviousMonth
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Previous month";
                    case "ja-JP": return "先月";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Processing_
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Processing...";
                    case "ja-JP": return "実行中...";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Price
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Price";
                    case "ja-JP": return "価格";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Profile
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Profile";
                    case "ja-JP": return "プロフィール";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Project
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Project";
                    case "ja-JP": return "プロジェクト";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Receive
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Receive";
                    case "ja-JP": return "受信";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Remarks
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Remarks";
                    case "ja-JP": return "備考";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string ResetPassword
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Reset password";
                    case "ja-JP": return "パスワードのリセット";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Resolved
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Resolved";
                    case "ja-JP": return "解決済";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Result
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Result";
                    case "ja-JP": return "結果";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Results
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Results";
                    case "ja-JP": return "件";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Save
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Save";
                    case "ja-JP": return "保存";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Search
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Search";
                    case "ja-JP": return "検索";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Select
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Select";
                    case "ja-JP": return "選択";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string SelectRecordByClick
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Select record by click";
                    case "ja-JP": return "クリックしてレコードを選択";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string SelectUserByClick
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Select User by click";
                    case "ja-JP": return "クリックしてユーザーを選択";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Send
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Send";
                    case "ja-JP": return "送信";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string SendMail
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Send mail";
                    case "ja-JP": return "メールを送信";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string SendMailFailed
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Send mail failed.";
                    case "ja-JP": return "メールの送信に失敗しました。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string SendResetPasswordMail
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Send reset password mail.";
                    case "ja-JP": return "パスワードのリセットメールを送る";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Service
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Service";
                    case "ja-JP": return "サービス";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string SettingChanged
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Settings changed.";
                    case "ja-JP": return "設定が変更されました。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Settings
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Settings";
                    case "ja-JP": return "設定";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Signup
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Signup";
                    case "ja-JP": return "サインアップ";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string SortBy
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Sort by";
                    case "ja-JP": return "並べ替え";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Start
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Start";
                    case "ja-JP": return "開始";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Stop
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Stop";
                    case "ja-JP": return "停止";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string StartDate
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Start date";
                    case "ja-JP": return "開始日";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string StartTime
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Start time";
                    case "ja-JP": return "開始時刻";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string State
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "State";
                    case "ja-JP": return "状態";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Subscription
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Subscription";
                    case "ja-JP": return "サブスクリプション";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Summary
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Summary";
                    case "ja-JP": return "サマリー";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string System
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "System";
                    case "ja-JP": return "システム";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Tablet
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Tablet";
                    case "ja-JP": return "タブレット";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Tag
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Tag";
                    case "ja-JP": return "タグ";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Task
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Task";
                    case "ja-JP": return "タスク";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Text
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Text";
                    case "ja-JP": return "テキスト";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string TextCopied
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Text copied";
                    case "ja-JP": return "テキストをコピーしました。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string ThisDataMayBeDeleted
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "This data may be deleted.";
                    case "ja-JP": return "このデータは削除されたようです。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string ThisFieldIsRequired
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "This field is required.";
                    case "ja-JP": return "この項目は入力必須です。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string ThisFileFormatIsNotSupported
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "This file formatis not supported.";
                    case "ja-JP": return "このファイルフォーマットはサポートされていません。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string ThisMailAddressAlreadyUsed
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "This mail address already used";
                    case "ja-JP": return "このメールアドレスは既に使用されています。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string ThisMailAddressNotExists
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "This mail address not exists.";
                    case "ja-JP": return "このメールアドレスは存在しません。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string TimeZone
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Timezone";
                    case "ja-JP": return "タイムゾーン";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Title
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Title";
                    case "ja-JP": return "タイトル";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Today
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Today";
                    case "ja-JP": return "今日";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string TokenExpired
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Token expired.";
                    case "ja-JP": return "トークンの有効期限が切れています。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string UnDecided
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "UnDecided";
                    case "ja-JP": return "未定";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string University
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "University";
                    case "ja-JP": return "大学";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Uninstall
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Uninstall";
                    case "ja-JP": return "アンインストール";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Unknown
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Unknown";
                    case "ja-JP": return "不明";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string UnRead
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "UnRead";
                    case "ja-JP": return "未読";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Update
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Update";
                    case "ja-JP": return "更新";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string UpdateTime
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Update time";
                    case "ja-JP": return "更新時刻";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Upload
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Upload";
                    case "ja-JP": return "アップロード";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string UploadImage
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Upload image";
                    case "ja-JP": return "画像のアップロード";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Url
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "URL";
                    case "ja-JP": return "URL";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Unsubscribe
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Unsubscribe";
                    case "ja-JP": return "解約する";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Unsubscription
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Unsubscription";
                    case "ja-JP": return "解約";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string User
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "User";
                    case "ja-JP": return "ユーザー";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string UserId
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "UserId";
                    case "ja-JP": return "ユーザーID";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string UserList
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "User list";
                    case "ja-JP": return "ユーザー一覧";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string UserName
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "User name";
                    case "ja-JP": return "ユーザー名";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string UserSettings
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "User settings";
                    case "ja-JP": return "ユーザー設定";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string View
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "View";
                    case "ja-JP": return "表示";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string ViewPermission
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "View permission";
                    case "ja-JP": return "閲覧権限";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Visibility
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Visibility";
                    case "ja-JP": return "公開範囲";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Woman
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Woman";
                    case "ja-JP": return "女性";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string YouMustAgreeToTermsOfUse
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "You must agree to the Terms of Use.";
                    case "ja-JP": return "利用規約への同意が必要です。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string ActualTime
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "ja-JP": return "実際の時間";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string MailSent
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "ja-JP": return "メールが送信されました。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string PositionName
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "ja-JP": return "役職名";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string SendResetPasswordMailFailed
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "ja-JP": return "パスワードリセットメールの送信に失敗しました";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string SetByEndTime
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "ja-JP": return "時刻で指定";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string SignupMailSendFailure
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "ja-JP": return "サインアップ完了のメール送信に失敗しました。メールアドレスを確認してみてください。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string ThisUserIdAlreadyUsed
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "ja-JP": return "このユーザーIDは既に使用されています。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string TopPixel
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "ja-JP": return "トップからの位置";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string ChatAgentType_Prompton
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Prompton";
                    case "ja-JP": return "ぷろんぷとん";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string ChatAgentType_ChatGPT
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "ChatGPT";
                    case "ja-JP": return "ChatGPT";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string ChatAgentType_Search
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Search agent";
                    case "ja-JP": return "検索エージェント";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string CreateArticle
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Create article";
                    case "ja-JP": return "記事の作成";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string EmployeeId
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Employee Id";
                    case "ja-JP": return "従業員ID";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string EmptyDataMessage
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "No data available.";
                    case "ja-JP": return "データがありません。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string EmptyDataMessage_Article
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "No articles.";
                    case "ja-JP": return "記事がありません。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string EmptyDataMessage_Comment
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "No comments.";
                    case "ja-JP": return "コメントがありません。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string EmptyDataMessage_User
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "There is no users.";
                    case "ja-JP": return "ユーザーがいません。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string FunctionCallStartMessage_NotFound
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "May I help you?";
                    case "ja-JP": return "何をしますか？";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string FunctionCallStartMessage_TaskAdd
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Add a task";
                    case "ja-JP": return "タスクの追加をします。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string FunctionCallStartMessage_ScheduleAdd
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Add a appointment";
                    case "ja-JP": return "予定の追加をします。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string FunctionCallStartMessage_Translate
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Translate. Enter text.";
                    case "ja-JP": return "翻訳します。テキストを入力してください。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string FunctionCallStartMessage_Proofreading
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Proofreading. Enter text.";
                    case "ja-JP": return "校正します。テキストを入力してください。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string FunctionCallStartMessage_Summarize
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Summarize. Enter text.";
                    case "ja-JP": return "要約します。テキストを入力してください。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string FunctionCallStartMessage_Rewrite
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Rewrite. Enter text.";
                    case "ja-JP": return "書き換えます。テキストを入力してください。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string FunctionCallStartMessage_Review
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Review. Enter text.";
                    case "ja-JP": return "文章のレビューをします。テキストを入力してください。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string GanttChart
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "GanttChart";
                    case "ja-JP": return "ガントチャート";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string GenerateArticle
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Generate article";
                    case "ja-JP": return "記事の生成";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string GenerateStructure
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Generate structure";
                    case "ja-JP": return "構成の生成";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string HelpDesk
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "HelpDesk";
                    case "ja-JP": return "ヘルプデスク";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Install
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Install";
                    case "ja-JP": return "インストール";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Kanban
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Kanban";
                    case "ja-JP": return "かんばん";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Marketing
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Marketing";
                    case "ja-JP": return "マーケティング";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string OpenAIOops
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Oops...";
                    case "ja-JP": return "...（気絶）";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string OpenAIQuotaExceeded
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "OpenAI API exceeded. Please check current status of your account below url.";
                    case "ja-JP": return "OpenAIのAPIの利用回数の上限を超えています。OpenAIのページで利用状況を確認してみてください。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string PleaseInput
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Please input.";
                    case "ja-JP": return "入力してください。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string PleaseInputNegativeNumber
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Please input negative number.";
                    case "ja-JP": return "ゼロよりも小さい数を入力してください。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string PleaseInputPositiveNumber
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Please input positive number.";
                    case "ja-JP": return "ゼロよりも大きい数を入力してください。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string PleaseChangeFileNameToUpload
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "File name is duplicated. Please change file name to upload.";
                    case "ja-JP": return "ファイル名が重複しているようです。アップロードするファイル名を変更してみてください。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string PleaseConfirm
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Please confirm.";
                    case "ja-JP": return "確認してください。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string PleaseSelectFile
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Please select file.";
                    case "ja-JP": return "ファイルを選択してください。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string PleaseSelectUser
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Please select user.";
                    case "ja-JP": return "ユーザーを選択してください。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string PleaseSelectImage
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Please select image.";
                    case "ja-JP": return "画像を選択してください。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Proofreading
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Proofreading";
                    case "ja-JP": return "校正";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string RecentCommentList
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Recent comment list";
                    case "ja-JP": return "最新コメント一覧";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string RequestEntityTooLarge
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Request entity too large.";
                    case "ja-JP": return "送信したリクエストのサイズが大きすぎます。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string SeeAll
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "See all";
                    case "ja-JP": return "全部見る";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string SeeAllComment
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "See all comments";
                    case "ja-JP": return "全てのコメントを見る";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string SeeDescription
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "See description";
                    case "ja-JP": return "詳細を見る";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string SeeMore
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "See more";
                    case "ja-JP": return "もっと見る";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string SorryInconvenience
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Sorry inconvenience.Something wrong.Error report is sent to  administrator and developer and they will investigate and solve problem as soon as possible.";
                    case "ja-JP": return "エラーが発生しました。ご迷惑をおかけします。エラーは自動的に管理者に送信されできる限り早くプログラムの修正がされます。今しばらくお待ちください。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string PersonInCharge
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Person in charge";
                    case "ja-JP": return "担当者";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Portal
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Portal";
                    case "ja-JP": return "ポータル";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string PleaseSelect_
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Please select {0}";
                    case "ja-JP": return "{0}を選択してください。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Rewrite
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Rewrite";
                    case "ja-JP": return "書き換え";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string ShortName
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Short name";
                    case "ja-JP": return "名前（短い表示）";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Summarize
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Summarize";
                    case "ja-JP": return "要約";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Theme
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Theme";
                    case "ja-JP": return "テーマ";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string ThisPageIsUnderConstructing
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "This page is under constructing.";
                    case "ja-JP": return "このページは現在作成中です。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Translate
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Translate";
                    case "ja-JP": return "翻訳";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string UnAssigned
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Unassigned";
                    case "ja-JP": return "担当無し";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string UnConfirm
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Unconfirm";
                    case "ja-JP": return "未確認";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string UnConfirmed
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Unconfirmed";
                    case "ja-JP": return "未確認";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string UserReading
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "User reading";
                    case "ja-JP": return "ユーザー閲覧";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string WidthPixel
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Width pixel";
                    case "ja-JP": return "横幅";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string YouDontHaveLicense
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "You don't have license.";
                    case "ja-JP": return "ライセンスがありません。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string YouDontHaveAuthority
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "You don't have authority.";
                    case "ja-JP": return "権限がありません。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string YouDontHaveAuthorityToAdd
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "You don't have authority to add.";
                    case "ja-JP": return "追加権限がありません。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string YouDontHaveAuthorityToDelete
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "You don't have authority to delete.";
                    case "ja-JP": return "削除権限がありません。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string YouDontHaveAuthorityToEdit
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "You don't have authority to edit.";
                    case "ja-JP": return "編集権限がありません。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string YouDontHaveAuthorityToManage
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "You don't have authority to manage.";
                    case "ja-JP": return "このデータの管理権限がありません。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }

        protected override string GetText(string key)
        {
            switch (key)
            {
                case "Add": return this.Add;
                case "AddCategory": return this.AddCategory;
                case "AddComment": return this.AddComment;
                case "AddImage": return this.AddImage;
                case "AddProject": return this.AddProject;
                case "AddTask": return this.AddTask;
                case "AddUser": return this.AddUser;
                case "Affiliation": return this.Affiliation;
                case "AffiliationName": return this.AffiliationName;
                case "AgeSuffix": return this.AgeSuffix;
                case "All": return this.All;
                case "ApiNotFound": return this.ApiNotFound;
                case "AuthenticateExpired": return this.AuthenticateExpired;
                case "AuthenticateRequired": return this.AuthenticateRequired;
                case "AuthenticationFailure": return this.AuthenticationFailure;
                case "Billing": return this.Billing;
                case "Birthday": return this.Birthday;
                case "Birthplace": return this.Birthplace;
                case "BloodType": return this.BloodType;
                case "BodyHeight": return this.BodyHeight;
                case "Calendar": return this.Calendar;
                case "Cancel": return this.Cancel;
                case "Category": return this.Category;
                case "Change": return this.Change;
                case "ChangeProfileImage": return this.ChangeProfileImage;
                case "Chat": return this.Chat;
                case "Clear": return this.Clear;
                case "Close": return this.Close;
                case "Command": return this.Command;
                case "Comment": return this.Comment;
                case "CommentList": return this.CommentList;
                case "CompanyName": return this.CompanyName;
                case "Complete": return this.Complete;
                case "Confirm_DeleteThisData": return this.Confirm_DeleteThisData;
                case "Confirm_No": return this.Confirm_No;
                case "Confirm_Yes": return this.Confirm_Yes;
                case "ConfirmDelete": return this.ConfirmDelete;
                case "Confirmed": return this.Confirmed;
                case "ConfirmationRequired": return this.ConfirmationRequired;
                case "ContextMenu": return this.ContextMenu;
                case "Create": return this.Create;
                case "CreateNew": return this.CreateNew;
                case "CreateNewAccount": return this.CreateNewAccount;
                case "CreateTime": return this.CreateTime;
                case "DashBoard": return this.DashBoard;
                case "DataAddedSuccessfully": return this.DataAddedSuccessfully;
                case "DataDeletedSuccessfully": return this.DataDeletedSuccessfully;
                case "DataUpdatedSuccessfully": return this.DataUpdatedSuccessfully;
                case "DataProcessedSuccessfully": return this.DataProcessedSuccessfully;
                case "Date": return this.Date;
                case "Decide": return this.Decide;
                case "Delete": return this.Delete;
                case "Description": return this.Description;
                case "DirectoryNotFound": return this.DirectoryNotFound;
                case "Display": return this.Display;
                case "DisplayAll": return this.DisplayAll;
                case "DisplayName": return this.DisplayName;
                case "Download": return this.Download;
                case "DownloadByBrowser": return this.DownloadByBrowser;
                case "Draft": return this.Draft;
                case "DueDate": return this.DueDate;
                case "Duplicate": return this.Duplicate;
                case "Duration": return this.Duration;
                case "Edit": return this.Edit;
                case "Encoding": return this.Encoding;
                case "EndDate": return this.EndDate;
                case "EndTime": return this.EndTime;
                case "Export": return this.Export;
                case "Execute": return this.Execute;
                case "File": return this.File;
                case "FileNotFound": return this.FileNotFound;
                case "FileSizeMustBeSmallerThan_": return this.FileSizeMustBeSmallerThan_;
                case "Filter": return this.Filter;
                case "FilterCondition": return this.FilterCondition;
                case "FolderNotFound": return this.FolderNotFound;
                case "TextColor": return this.TextColor;
                case "ForgetPassword": return this.ForgetPassword;
                case "Gender": return this.Gender;
                case "Generate": return this.Generate;
                case "HashTag": return this.HashTag;
                case "Home": return this.Home;
                case "Hour": return this.Hour;
                case "IAgreeTermsOfUse": return this.IAgreeTermsOfUse;
                case "IAgreeTermsOfUseAndPrivacyPolicy": return this.IAgreeTermsOfUseAndPrivacyPolicy;
                case "ImageUrl": return this.ImageUrl;
                case "Import": return this.Import;
                case "InComplete": return this.InComplete;
                case "InputForm": return this.InputForm;
                case "InputSample": return this.InputSample;
                case "InputValue": return this.InputValue;
                case "Inquiry": return this.Inquiry;
                case "Kana": return this.Kana;
                case "Language": return this.Language;
                case "LastAccessTime": return this.LastAccessTime;
                case "LastDayOfMonth": return this.LastDayOfMonth;
                case "Later": return this.Later;
                case "License": return this.License;
                case "Link": return this.Link;
                case "List": return this.List;
                case "Load": return this.Load;
                case "Login": return this.Login;
                case "Logout": return this.Logout;
                case "MailAddress": return this.MailAddress;
                case "MailIsSent": return this.MailIsSent;
                case "MainImage": return this.MainImage;
                case "Man": return this.Man;
                case "ManageUser": return this.ManageUser;
                case "Maximize": return this.Maximize;
                case "Minimize": return this.Minimize;
                case "Member": return this.Member;
                case "Menu": return this.Menu;
                case "Message": return this.Message;
                case "Minute": return this.Minute;
                case "Name": return this.Name;
                case "NewPassword": return this.NewPassword;
                case "NextMonth": return this.NextMonth;
                case "Notification": return this.Notification;
                case "NotConfirmed": return this.NotConfirmed;
                case "NowRedirecting": return this.NowRedirecting;
                case "Other": return this.Other;
                case "Page": return this.Page;
                case "PageNotFound": return this.PageNotFound;
                case "Password": return this.Password;
                case "PasswordSettings": return this.PasswordSettings;
                case "PleaseSelect": return this.PleaseSelect;
                case "PreviousMonth": return this.PreviousMonth;
                case "Processing_": return this.Processing_;
                case "Price": return this.Price;
                case "Profile": return this.Profile;
                case "Project": return this.Project;
                case "Receive": return this.Receive;
                case "Remarks": return this.Remarks;
                case "ResetPassword": return this.ResetPassword;
                case "Resolved": return this.Resolved;
                case "Result": return this.Result;
                case "Results": return this.Results;
                case "Save": return this.Save;
                case "Search": return this.Search;
                case "Select": return this.Select;
                case "SelectRecordByClick": return this.SelectRecordByClick;
                case "SelectUserByClick": return this.SelectUserByClick;
                case "Send": return this.Send;
                case "SendMail": return this.SendMail;
                case "SendMailFailed": return this.SendMailFailed;
                case "SendResetPasswordMail": return this.SendResetPasswordMail;
                case "Service": return this.Service;
                case "SettingChanged": return this.SettingChanged;
                case "Settings": return this.Settings;
                case "Signup": return this.Signup;
                case "SortBy": return this.SortBy;
                case "Start": return this.Start;
                case "Stop": return this.Stop;
                case "StartDate": return this.StartDate;
                case "StartTime": return this.StartTime;
                case "State": return this.State;
                case "Subscription": return this.Subscription;
                case "Summary": return this.Summary;
                case "System": return this.System;
                case "Tablet": return this.Tablet;
                case "Tag": return this.Tag;
                case "Task": return this.Task;
                case "Text": return this.Text;
                case "TextCopied": return this.TextCopied;
                case "ThisDataMayBeDeleted": return this.ThisDataMayBeDeleted;
                case "ThisFieldIsRequired": return this.ThisFieldIsRequired;
                case "ThisFileFormatIsNotSupported": return this.ThisFileFormatIsNotSupported;
                case "ThisMailAddressAlreadyUsed": return this.ThisMailAddressAlreadyUsed;
                case "ThisMailAddressNotExists": return this.ThisMailAddressNotExists;
                case "TimeZone": return this.TimeZone;
                case "Title": return this.Title;
                case "Today": return this.Today;
                case "TokenExpired": return this.TokenExpired;
                case "UnDecided": return this.UnDecided;
                case "University": return this.University;
                case "Uninstall": return this.Uninstall;
                case "Unknown": return this.Unknown;
                case "UnRead": return this.UnRead;
                case "Update": return this.Update;
                case "UpdateTime": return this.UpdateTime;
                case "Upload": return this.Upload;
                case "UploadImage": return this.UploadImage;
                case "Url": return this.Url;
                case "Unsubscribe": return this.Unsubscribe;
                case "Unsubscription": return this.Unsubscription;
                case "User": return this.User;
                case "UserId": return this.UserId;
                case "UserList": return this.UserList;
                case "UserName": return this.UserName;
                case "UserSettings": return this.UserSettings;
                case "View": return this.View;
                case "ViewPermission": return this.ViewPermission;
                case "Visibility": return this.Visibility;
                case "Woman": return this.Woman;
                case "YouMustAgreeToTermsOfUse": return this.YouMustAgreeToTermsOfUse;
                case "ActualTime": return this.ActualTime;
                case "MailSent": return this.MailSent;
                case "PositionName": return this.PositionName;
                case "SendResetPasswordMailFailed": return this.SendResetPasswordMailFailed;
                case "SetByEndTime": return this.SetByEndTime;
                case "SignupMailSendFailure": return this.SignupMailSendFailure;
                case "ThisUserIdAlreadyUsed": return this.ThisUserIdAlreadyUsed;
                case "TopPixel": return this.TopPixel;
                case "ChatAgentType_Prompton": return this.ChatAgentType_Prompton;
                case "ChatAgentType_ChatGPT": return this.ChatAgentType_ChatGPT;
                case "ChatAgentType_Search": return this.ChatAgentType_Search;
                case "CreateArticle": return this.CreateArticle;
                case "EmployeeId": return this.EmployeeId;
                case "EmptyDataMessage": return this.EmptyDataMessage;
                case "EmptyDataMessage_Article": return this.EmptyDataMessage_Article;
                case "EmptyDataMessage_Comment": return this.EmptyDataMessage_Comment;
                case "EmptyDataMessage_User": return this.EmptyDataMessage_User;
                case "FunctionCallStartMessage_NotFound": return this.FunctionCallStartMessage_NotFound;
                case "FunctionCallStartMessage_TaskAdd": return this.FunctionCallStartMessage_TaskAdd;
                case "FunctionCallStartMessage_ScheduleAdd": return this.FunctionCallStartMessage_ScheduleAdd;
                case "FunctionCallStartMessage_Translate": return this.FunctionCallStartMessage_Translate;
                case "FunctionCallStartMessage_Proofreading": return this.FunctionCallStartMessage_Proofreading;
                case "FunctionCallStartMessage_Summarize": return this.FunctionCallStartMessage_Summarize;
                case "FunctionCallStartMessage_Rewrite": return this.FunctionCallStartMessage_Rewrite;
                case "FunctionCallStartMessage_Review": return this.FunctionCallStartMessage_Review;
                case "GanttChart": return this.GanttChart;
                case "GenerateArticle": return this.GenerateArticle;
                case "GenerateStructure": return this.GenerateStructure;
                case "HelpDesk": return this.HelpDesk;
                case "Install": return this.Install;
                case "Kanban": return this.Kanban;
                case "Marketing": return this.Marketing;
                case "OpenAIOops": return this.OpenAIOops;
                case "OpenAIQuotaExceeded": return this.OpenAIQuotaExceeded;
                case "PleaseInput": return this.PleaseInput;
                case "PleaseInputNegativeNumber": return this.PleaseInputNegativeNumber;
                case "PleaseInputPositiveNumber": return this.PleaseInputPositiveNumber;
                case "PleaseChangeFileNameToUpload": return this.PleaseChangeFileNameToUpload;
                case "PleaseConfirm": return this.PleaseConfirm;
                case "PleaseSelectFile": return this.PleaseSelectFile;
                case "PleaseSelectUser": return this.PleaseSelectUser;
                case "PleaseSelectImage": return this.PleaseSelectImage;
                case "Proofreading": return this.Proofreading;
                case "RecentCommentList": return this.RecentCommentList;
                case "RequestEntityTooLarge": return this.RequestEntityTooLarge;
                case "SeeAll": return this.SeeAll;
                case "SeeAllComment": return this.SeeAllComment;
                case "SeeDescription": return this.SeeDescription;
                case "SeeMore": return this.SeeMore;
                case "SorryInconvenience": return this.SorryInconvenience;
                case "PersonInCharge": return this.PersonInCharge;
                case "Portal": return this.Portal;
                case "PleaseSelect_": return this.PleaseSelect_;
                case "Rewrite": return this.Rewrite;
                case "ShortName": return this.ShortName;
                case "Summarize": return this.Summarize;
                case "Theme": return this.Theme;
                case "ThisPageIsUnderConstructing": return this.ThisPageIsUnderConstructing;
                case "Translate": return this.Translate;
                case "UnAssigned": return this.UnAssigned;
                case "UnConfirm": return this.UnConfirm;
                case "UnConfirmed": return this.UnConfirmed;
                case "UserReading": return this.UserReading;
                case "WidthPixel": return this.WidthPixel;
                case "YouDontHaveLicense": return this.YouDontHaveLicense;
                case "YouDontHaveAuthority": return this.YouDontHaveAuthority;
                case "YouDontHaveAuthorityToAdd": return this.YouDontHaveAuthorityToAdd;
                case "YouDontHaveAuthorityToDelete": return this.YouDontHaveAuthorityToDelete;
                case "YouDontHaveAuthorityToEdit": return this.YouDontHaveAuthorityToEdit;
                case "YouDontHaveAuthorityToManage": return this.YouDontHaveAuthorityToManage;
                default: return "";
            }
        }
    }
}

using System;
using HigLabo.Core;

namespace DbSharpApplication
{
    public class DbSharpText : LanguageText
    {
        protected override string[] LanguageList
        {
            get
            {
                return new string[] { "en-US","ja-JP" };
            }
        }
        public string ActualTime
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Actual Time";
                    case "ja-JP": return "実際の時間";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
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
                    case "en-US": return "Add Category";
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
                    case "en-US": return "Add Comment";
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
                    case "en-US": return "Add Image";
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
                    case "en-US": return "Add Project";
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
                    case "en-US": return "Add Task";
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
                    case "en-US": return "Add User";
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
                    case "en-US": return "Affiliation";
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
                    case "en-US": return "Affiliation";
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
                    case "en-US": return "years of age";
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
        public string AllForum
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "All Forum";
                    case "ja-JP": return "全てのフォーラム";
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
                    case "en-US": return "API Not Found";
                    case "ja-JP": return "APIが見つかりませんでした。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string ArticleDisplayOrdinal
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Article Display Ordinal";
                    case "ja-JP": return "記事の表示順";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Assigned
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Assigned";
                    case "ja-JP": return "担当あり";
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
        public string BackColor
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Back Color";
                    case "ja-JP": return "背景色";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string BackToList
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Back to List";
                    case "ja-JP": return "一覧へ戻る";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string BackToView
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Back to View";
                    case "ja-JP": return "詳細表示へ戻る";
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
                    case "en-US": return "Birthplace";
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
                    case "en-US": return "Blood Type";
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
                    case "en-US": return "Body Height";
                    case "ja-JP": return "身長";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string ByMyself
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "By myself";
                    case "ja-JP": return "自分";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string CacheDataLoadingErrorMessage
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Cache data loading is not finished. Please wait few seconds and go to start page.";
                    case "ja-JP": return "キャッシュデータのロード中です。数秒後にスタートページにアクセスしてみてください。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string CacheTable
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "CacheTable";
                    case "ja-JP": return "キャッシュテーブル";
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
                    case "en-US": return "CommentList";
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
                    case "en-US": return "Company Name";
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
        public string CompleteTime
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "CompleteTime";
                    case "ja-JP": return "完了時刻";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string CompletionCondition
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "CompletionCondition";
                    case "ja-JP": return "完了条件";
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
        public string Contact
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Contact";
                    case "ja-JP": return "連絡先";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string ContactList
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Contact List";
                    case "ja-JP": return "連絡先一覧";
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
                    case "en-US": return "ContextMenu";
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
                    case "en-US": return "Create New";
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
                    case "en-US": return "Create New Account";
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
        public string CreateUser
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Created User";
                    case "ja-JP": return "作成者";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string CurrentSeatPresence
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Cuurent presence";
                    case "ja-JP": return "現在のプレゼンス";
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
                    case "en-US": return "DashBoard";
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
                    case "en-US": return "Data added successfully";
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
                    case "en-US": return "Data deleted successfully";
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
                    case "en-US": return "Data updated successfully";
                    case "ja-JP": return "データが正常に更新されました。";
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
        public string DateInfoType_Y
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Year Only";
                    case "ja-JP": return "年のみ";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string DateInfoType_M
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Year and Month";
                    case "ja-JP": return "年月";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string DateInfoType_D
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Date";
                    case "ja-JP": return "年月日";
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
        public string Department
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Department";
                    case "ja-JP": return "部署";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string DepartmentName
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Department Name";
                    case "ja-JP": return "部署名";
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
                    case "en-US": return "Display All";
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
                    case "en-US": return "DisplayName";
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
                    case "en-US": return "DueDate";
                    case "ja-JP": return "締切日";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string DueDateOver
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "DueDateOver";
                    case "ja-JP": return "締切オーバー";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string DueTime
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "DueTime";
                    case "ja-JP": return "締切";
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
                    case "en-US": return "EndDate";
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
                    case "en-US": return "EndTime";
                    case "ja-JP": return "終了時刻";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string EveningNotifyTime
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Evening notify time";
                    case "ja-JP": return "夜の通知時刻";
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
        public string Faculty
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Faculty";
                    case "ja-JP": return "学部";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Favorite
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Favorite";
                    case "ja-JP": return "お気に入り";
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
        public string FileSizeMustBeSmallerThanFormat
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
                    case "en-US": return "Filter Condition";
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
        public string ForeColor
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Fore Color";
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
                    case "en-US": return "Forget Password?";
                    case "ja-JP": return "パスワードを忘れた？";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Friend
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Friend";
                    case "ja-JP": return "お友達";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string GoogleChartNoDataMessage
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Data does not exists for chart.";
                    case "ja-JP": return "グラフの元データがありません。";
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
        public string GoToTopPage
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Go to top page.";
                    case "ja-JP": return "トップページへ";
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
                    case "en-US": return "HashTag";
                    case "ja-JP": return "ハッシュタグ";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string HeightPixel
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Height pixel";
                    case "ja-JP": return "高さ";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string HignullServiceName_OutlookCalendar
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Calendar";
                    case "ja-JP": return "Outlookカレンダー";
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
                    case "en-US": return "Image URL";
                    case "ja-JP": return "画像URL";
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
                    case "en-US": return "InComplete";
                    case "ja-JP": return "未完了";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string InCompleteTask
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "InComplete Task";
                    case "ja-JP": return "未完了タスク";
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
                    case "en-US": return "Input Form";
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
                    case "en-US": return "InputSample";
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
        public string InvalidAccessToken
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Invalid access token.";
                    case "ja-JP": return "アクセストークンが不正です。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string InvalidDateMessage
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Invalid date";
                    case "ja-JP": return "日付が間違っています。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string InvalidInputValue
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Invalid input value.";
                    case "ja-JP": return "入力した値に誤りがあります。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string InvalidPassword
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Invalid password.";
                    case "ja-JP": return "パスワードが間違っています。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string InvalidToken
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Invalid token";
                    case "ja-JP": return "トークンが不正です。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string InvitationIsExpired
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "This invitation code expired.";
                    case "ja-JP": return "この招待コードは期限が切れています。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string InvitationMailSent
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Invitation mail sent";
                    case "ja-JP": return "招待メールが送信されました。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string InviteYourFriend
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Invite your friend";
                    case "ja-JP": return "友人を招待";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string JavaScript_App_DoNothing
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "javascript:App.DoNothing();";
                    case "ja-JP": return "javascript:App.DoNothing();";
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
                    case "en-US": return "LastAccessTime";
                    case "ja-JP": return "最終アクセス時刻";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string LastComment
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "LastComment";
                    case "ja-JP": return "最終コメント";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string LastCommentTime
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "LastCommentTime";
                    case "ja-JP": return "最終コメント時刻";
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
                    case "en-US": return "Last day of Month";
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
        public string LeftPixel
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "LeftPixel";
                    case "ja-JP": return "左からの位置";
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
        public string ListView
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "ListView";
                    case "ja-JP": return "リストビュー";
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
        public string LoadMore
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Load More";
                    case "ja-JP": return "さらに読み込む";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Location
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Location";
                    case "ja-JP": return "場所";
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
        public string OnlineMeeting
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Online Meeting";
                    case "ja-JP": return "オンライン会議";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string OnlineMeetingUrl
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Meeting URL";
                    case "ja-JP": return "会議のURL";
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
        public string MailAddressMustHaveAtmark
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "MailAddress must have atmark";
                    case "ja-JP": return "メールアドレスは@が必要です。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string MailList
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Mail List";
                    case "ja-JP": return "メール一覧";
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
                    case "en-US": return "Mail sent";
                    case "ja-JP": return "メールが送信されました。";
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
                    case "en-US": return "Main Image";
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
        public string ManageMenu
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Manage Menu";
                    case "ja-JP": return "管理メニュー";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string ManagePermission
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Manage Permission";
                    case "ja-JP": return "管理権限";
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
                    case "en-US": return "Manage User";
                    case "ja-JP": return "ユーザーの管理";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string ManualSetting
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Manual Setting";
                    case "ja-JP": return "手動設定";
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
        public string Mentioned
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Mentioned";
                    case "ja-JP": return "メンションされました。";
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
        public string MoveToLoginPage
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Move to Login page";
                    case "ja-JP": return "ログインページへ移動";
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
                    case "en-US": return "New Password";
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
                    case "en-US": return "Next Month";
                    case "ja-JP": return "翌月";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string NoNotification
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "No notification";
                    case "ja-JP": return "通知しない";
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
        public string NoPermissionToAccessThisPage
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "You have no permission to access this page.";
                    case "ja-JP": return "このページにアクセスする権限がありません。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string NoScheduled
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "No scheduled";
                    case "ja-JP": return "日程が未確定";
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
        public string OnlyInvitationUserCanSignup
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Only invitation user can signup";
                    case "ja-JP": return "現在は招待されたユーザーだけサインアップ可能です。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Ordinal
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Ordinal";
                    case "ja-JP": return "表示順";
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
        public string OutlookCalendarViewPermission_Office
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Office";
                    case "ja-JP": return "オフィスに公開";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string OutlookCalendarViewPermission_Private
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Private";
                    case "ja-JP": return "非公開";
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
                    case "en-US": return "Page not found";
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
                    case "en-US": return "Password Settings";
                    case "ja-JP": return "パスワードの設定";
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
                    case "en-US": return "Please input negative number";
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
                    case "en-US": return "Please input positive number";
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
        public string PositionName
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Position Name";
                    case "ja-JP": return "役職名";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Post
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Post";
                    case "ja-JP": return "投稿";
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
                    case "en-US": return "Previous Month";
                    case "ja-JP": return "先月";
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
        public string RecentCommentList
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Recent Comment List";
                    case "ja-JP": return "最新コメント一覧";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string RecentSchedule
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Recent Schedule";
                    case "ja-JP": return "最近の予定";
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
        public string ResetPassword
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Reset Password";
                    case "ja-JP": return "パスワードのリセット";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string ResetPasswordMail_Body
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Please click link url to reset password";
                    case "ja-JP": return "リンクをクリックしてください。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string ResetPasswordMail_Title
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Hignull Password reset mail";
                    case "ja-JP": return "パスワードリセットメールです。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string ResetPasswordMailSent
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Reset password mail sent";
                    case "ja-JP": return "パスワードのリセットメールが送信されました。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string ResetPasswordMailSentFailed
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Reset password mail sent is failed";
                    case "ja-JP": return "パスワードのリセットメールの送信に失敗しました。";
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
        public string SaveAsDraft
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Save as Draft";
                    case "ja-JP": return "下書き保存";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string ScheduleNotAcceptedRecordCount
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Schedule adjusting";
                    case "ja-JP": return "予定調整中";
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
        public string SearchCandidate
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Search Candidate";
                    case "ja-JP": return "候補を検索";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string SearchUser
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Search User";
                    case "ja-JP": return "ユーザー検索";
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
                    case "en-US": return "See All";
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
                    case "en-US": return "See All Comment";
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
                    case "en-US": return "See Description";
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
                    case "en-US": return "See More";
                    case "ja-JP": return "もっと見る";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string SeeOtherImage
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "See Other Images";
                    case "ja-JP": return "他の画像";
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
                    case "en-US": return "Send Mail";
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
        public string SendInvitationMail
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Send invitation mail";
                    case "ja-JP": return "招待メールを送る";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string SendInvitationMailFailed
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Send invitation mail failed.Sorry inconvenience.";
                    case "ja-JP": return "招待メールの送信に失敗しました。";
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
                    case "en-US": return "Send reset password mail";
                    case "ja-JP": return "パスワードのリセットメールを送る";
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
                    case "en-US": return "";
                    case "ja-JP": return "パスワードリセットメールの送信に失敗しました";
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
        public string SetByEndTime
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Set by EndTime";
                    case "ja-JP": return "時刻で指定";
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
                    case "en-US": return "Setting changed";
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
        public string Shipping
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Shipping";
                    case "ja-JP": return "出荷";
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
        public string SignupMailSendFailure
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Signup mail sent is failed.Please confirm mail address is correct.";
                    case "ja-JP": return "サインアップ完了のメール送信に失敗しました。メールアドレスを確認してみてください。";
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
        public string SortBy
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "SortBy";
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
                    case "en-US": return "StartDate";
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
                    case "en-US": return "StartTime";
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
        public string SystemManagement
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "System Management";
                    case "ja-JP": return "システムの管理";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string PleaseSelectFormat
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
        public string TaskList
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Task List";
                    case "ja-JP": return "タスク一覧";
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
                    case "en-US": return "Text Copied";
                    case "ja-JP": return "テキストをコピーしました。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string ThereIsNoComment
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "There is no comment";
                    case "ja-JP": return "コメントはありません。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string ThereIsNoData
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "There is no data";
                    case "ja-JP": return "データがありません。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string ThereIsNoNotification
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "There is no notification";
                    case "ja-JP": return "通知はありません。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string ThereIsNoTask
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "There is no task";
                    case "ja-JP": return "タスクがありません。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string ThereIsNoUser
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "There is no user";
                    case "ja-JP": return "ユーザーはいません。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string ThisAccountAlreadyAuthenticated
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "This account already authenticated";
                    case "ja-JP": return "このアカウントは既に認証済みです。";
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
                    case "en-US": return "This data may be deleted";
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
                    case "en-US": return "This file formatis not supported";
                    case "ja-JP": return "このファイルフォーマットはサポートされていません。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string ThisUserIDAlreadyUsed
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "This UserID already used.";
                    case "ja-JP": return "このユーザーIDは既に使用されています。";
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
                    case "en-US": return "This mail address not exists";
                    case "ja-JP": return "このメールアドレスは存在しません。";
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
                    case "en-US": return "This page is under constructing";
                    case "ja-JP": return "このページは現在作成中です。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string ThisUserAlreadyExists
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "This user already exists";
                    case "ja-JP": return "このユーザーは既に存在しています。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string ThisUserIsSelected
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "This user is selected";
                    case "ja-JP": return "このユーザーは選択されています。";
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
                    case "en-US": return "TimeZone";
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
                    case "en-US": return "Token expired";
                    case "ja-JP": return "トークンの有効期限が切れています。";
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
                    case "en-US": return "Top Pixel";
                    case "ja-JP": return "トップからの位置";
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
                    case "en-US": return "UnAssigned";
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
                    case "en-US": return "UnConfirm";
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
                    case "en-US": return "UnConfirmed";
                    case "ja-JP": return "未確認";
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
                    case "en-US": return "";
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
                    case "en-US": return "UpdateTime";
                    case "ja-JP": return "更新時刻";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string UpdateUser
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "UpdateUser";
                    case "ja-JP": return "更新ユーザー";
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
        public string UserID
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "UserID";
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
                    case "en-US": return "User List";
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
                    case "en-US": return "User Name";
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
        public string ValidationResult_DisplayName_Required
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "DisplayName required";
                    case "ja-JP": return "表示名は必須です。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string ValidationResult_MailAddress_Atmark_Required
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "MailAddress must have atmark";
                    case "ja-JP": return "メールアドレスには@マークが必要です。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string ValidationResult_MailAddress_Required
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "MailAddress required";
                    case "ja-JP": return "メールアドレスは必須です。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string ValidationResult_MaxLengthFormat
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Max char count is {0}";
                    case "ja-JP": return "文字数は{0}文字までです。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string ValidationResult_Title_Required
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Title required";
                    case "ja-JP": return "タイトルは必須です。";
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
        public string YouDontHavePermission
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
        public string YouDontHavePermissionToAdd
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
        public string YouDontHavePermissionToDelete
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
        public string YouDontHavePermissionToEdit
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
        public string YouDontHavePermissionToManage
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "You don't have permission to manage";
                    case "ja-JP": return "このデータの管理権限がありません。";
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
                    case "en-US": return "You must agree to the Terms of Use";
                    case "ja-JP": return "利用規約への同意が必要です。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string OpenOutputFolder
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Open output folder";
                    case "ja-JP": return "出力先フォルダを開く";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string LoadStoredProcedure
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Load stored procedure";
                    case "ja-JP": return "ストアドのロード";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string LoadUserDefinedType
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Load user defined type";
                    case "ja-JP": return "ユーザー定義型のロード";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string ConnectionList
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Connection list";
                    case "ja-JP": return "接続先の一覧";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string ConnectionString
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Connection string";
                    case "ja-JP": return "接続文字列";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string Namespace
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Namespace";
                    case "ja-JP": return "名前空間";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string DatabaseKey
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Database key";
                    case "ja-JP": return "データベースキー";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string OutputFolder
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Output folder";
                    case "ja-JP": return "出力先フォルダ";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string LoadResultSet
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Load result set";
                    case "ja-JP": return "結果セットのロード";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string LoadResultSetFailed
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Result set loading failed. The result set may not exist or the argument may be invalid. You may get result set by setting the appropriate value in the Value column of the argument.";
                    case "ja-JP": return "結果セットのロードに失敗しました。結果セットが存在しないか、引数が不正な可能性があります。引数のValue列に適切な値をセットすると結果セットが取得できる可能性があります。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }
        public string ConnectionFailed
        {
            get
            {
                var language = this.GetLanguage();
                switch (language)
                {
                    case "en-US": return "Connection failed.";
                    case "ja-JP": return "接続に失敗しました。";
                    default:throw SwitchStatementNotImplementException.Create(language);
                }
            }
        }

        public override string GetText(string key)
        {
            switch (key)
            {
                case "ActualTime": return this.ActualTime;
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
                case "AllForum": return this.AllForum;
                case "ApiNotFound": return this.ApiNotFound;
                case "ArticleDisplayOrdinal": return this.ArticleDisplayOrdinal;
                case "Assigned": return this.Assigned;
                case "AuthenticateExpired": return this.AuthenticateExpired;
                case "AuthenticateRequired": return this.AuthenticateRequired;
                case "AuthenticationFailure": return this.AuthenticationFailure;
                case "BackColor": return this.BackColor;
                case "BackToList": return this.BackToList;
                case "BackToView": return this.BackToView;
                case "Birthday": return this.Birthday;
                case "Birthplace": return this.Birthplace;
                case "BloodType": return this.BloodType;
                case "BodyHeight": return this.BodyHeight;
                case "ByMyself": return this.ByMyself;
                case "CacheDataLoadingErrorMessage": return this.CacheDataLoadingErrorMessage;
                case "CacheTable": return this.CacheTable;
                case "Calendar": return this.Calendar;
                case "Cancel": return this.Cancel;
                case "Category": return this.Category;
                case "Change": return this.Change;
                case "ChangeProfileImage": return this.ChangeProfileImage;
                case "Chat": return this.Chat;
                case "Close": return this.Close;
                case "Command": return this.Command;
                case "Comment": return this.Comment;
                case "CommentList": return this.CommentList;
                case "CompanyName": return this.CompanyName;
                case "Complete": return this.Complete;
                case "CompleteTime": return this.CompleteTime;
                case "CompletionCondition": return this.CompletionCondition;
                case "Confirm_DeleteThisData": return this.Confirm_DeleteThisData;
                case "Confirm_No": return this.Confirm_No;
                case "Confirm_Yes": return this.Confirm_Yes;
                case "ConfirmDelete": return this.ConfirmDelete;
                case "Confirmed": return this.Confirmed;
                case "ConfirmationRequired": return this.ConfirmationRequired;
                case "Contact": return this.Contact;
                case "ContactList": return this.ContactList;
                case "ContextMenu": return this.ContextMenu;
                case "Create": return this.Create;
                case "CreateNew": return this.CreateNew;
                case "CreateNewAccount": return this.CreateNewAccount;
                case "CreateTime": return this.CreateTime;
                case "CreateUser": return this.CreateUser;
                case "CurrentSeatPresence": return this.CurrentSeatPresence;
                case "DashBoard": return this.DashBoard;
                case "DataAddedSuccessfully": return this.DataAddedSuccessfully;
                case "DataDeletedSuccessfully": return this.DataDeletedSuccessfully;
                case "DataUpdatedSuccessfully": return this.DataUpdatedSuccessfully;
                case "Date": return this.Date;
                case "DateInfoType_Y": return this.DateInfoType_Y;
                case "DateInfoType_M": return this.DateInfoType_M;
                case "DateInfoType_D": return this.DateInfoType_D;
                case "Decide": return this.Decide;
                case "Delete": return this.Delete;
                case "Department": return this.Department;
                case "DepartmentName": return this.DepartmentName;
                case "Description": return this.Description;
                case "DirectoryNotFound": return this.DirectoryNotFound;
                case "Display": return this.Display;
                case "DisplayAll": return this.DisplayAll;
                case "DisplayName": return this.DisplayName;
                case "Download": return this.Download;
                case "DownloadByBrowser": return this.DownloadByBrowser;
                case "Draft": return this.Draft;
                case "DueDate": return this.DueDate;
                case "DueDateOver": return this.DueDateOver;
                case "DueTime": return this.DueTime;
                case "Duration": return this.Duration;
                case "Edit": return this.Edit;
                case "Encoding": return this.Encoding;
                case "EndDate": return this.EndDate;
                case "EndTime": return this.EndTime;
                case "EveningNotifyTime": return this.EveningNotifyTime;
                case "Execute": return this.Execute;
                case "Faculty": return this.Faculty;
                case "Favorite": return this.Favorite;
                case "FileNotFound": return this.FileNotFound;
                case "FileSizeMustBeSmallerThanFormat": return this.FileSizeMustBeSmallerThanFormat;
                case "Filter": return this.Filter;
                case "FilterCondition": return this.FilterCondition;
                case "FolderNotFound": return this.FolderNotFound;
                case "ForeColor": return this.ForeColor;
                case "ForgetPassword": return this.ForgetPassword;
                case "Friend": return this.Friend;
                case "GoogleChartNoDataMessage": return this.GoogleChartNoDataMessage;
                case "Gender": return this.Gender;
                case "Generate": return this.Generate;
                case "GoToTopPage": return this.GoToTopPage;
                case "HashTag": return this.HashTag;
                case "HeightPixel": return this.HeightPixel;
                case "HignullServiceName_OutlookCalendar": return this.HignullServiceName_OutlookCalendar;
                case "Home": return this.Home;
                case "Hour": return this.Hour;
                case "IAgreeTermsOfUse": return this.IAgreeTermsOfUse;
                case "IAgreeTermsOfUseAndPrivacyPolicy": return this.IAgreeTermsOfUseAndPrivacyPolicy;
                case "ImageUrl": return this.ImageUrl;
                case "InComplete": return this.InComplete;
                case "InCompleteTask": return this.InCompleteTask;
                case "InputForm": return this.InputForm;
                case "InputSample": return this.InputSample;
                case "InputValue": return this.InputValue;
                case "Inquiry": return this.Inquiry;
                case "InvalidAccessToken": return this.InvalidAccessToken;
                case "InvalidDateMessage": return this.InvalidDateMessage;
                case "InvalidInputValue": return this.InvalidInputValue;
                case "InvalidPassword": return this.InvalidPassword;
                case "InvalidToken": return this.InvalidToken;
                case "InvitationIsExpired": return this.InvitationIsExpired;
                case "InvitationMailSent": return this.InvitationMailSent;
                case "InviteYourFriend": return this.InviteYourFriend;
                case "JavaScript_App_DoNothing": return this.JavaScript_App_DoNothing;
                case "Kana": return this.Kana;
                case "Language": return this.Language;
                case "LastAccessTime": return this.LastAccessTime;
                case "LastComment": return this.LastComment;
                case "LastCommentTime": return this.LastCommentTime;
                case "LastDayOfMonth": return this.LastDayOfMonth;
                case "Later": return this.Later;
                case "LeftPixel": return this.LeftPixel;
                case "License": return this.License;
                case "Link": return this.Link;
                case "List": return this.List;
                case "ListView": return this.ListView;
                case "Load": return this.Load;
                case "LoadMore": return this.LoadMore;
                case "Location": return this.Location;
                case "Login": return this.Login;
                case "Logout": return this.Logout;
                case "OnlineMeeting": return this.OnlineMeeting;
                case "OnlineMeetingUrl": return this.OnlineMeetingUrl;
                case "MailAddress": return this.MailAddress;
                case "MailAddressMustHaveAtmark": return this.MailAddressMustHaveAtmark;
                case "MailList": return this.MailList;
                case "MailSent": return this.MailSent;
                case "MainImage": return this.MainImage;
                case "Man": return this.Man;
                case "ManageMenu": return this.ManageMenu;
                case "ManagePermission": return this.ManagePermission;
                case "ManageUser": return this.ManageUser;
                case "ManualSetting": return this.ManualSetting;
                case "Maximize": return this.Maximize;
                case "Minimize": return this.Minimize;
                case "Member": return this.Member;
                case "Mentioned": return this.Mentioned;
                case "Menu": return this.Menu;
                case "Message": return this.Message;
                case "Minute": return this.Minute;
                case "MoveToLoginPage": return this.MoveToLoginPage;
                case "Name": return this.Name;
                case "NewPassword": return this.NewPassword;
                case "NextMonth": return this.NextMonth;
                case "NoNotification": return this.NoNotification;
                case "Notification": return this.Notification;
                case "NoPermissionToAccessThisPage": return this.NoPermissionToAccessThisPage;
                case "NoScheduled": return this.NoScheduled;
                case "NotConfirmed": return this.NotConfirmed;
                case "NowRedirecting": return this.NowRedirecting;
                case "OnlyInvitationUserCanSignup": return this.OnlyInvitationUserCanSignup;
                case "Ordinal": return this.Ordinal;
                case "Other": return this.Other;
                case "OutlookCalendarViewPermission_Office": return this.OutlookCalendarViewPermission_Office;
                case "OutlookCalendarViewPermission_Private": return this.OutlookCalendarViewPermission_Private;
                case "Page": return this.Page;
                case "PageNotFound": return this.PageNotFound;
                case "Password": return this.Password;
                case "PasswordSettings": return this.PasswordSettings;
                case "PersonInCharge": return this.PersonInCharge;
                case "PleaseInput": return this.PleaseInput;
                case "PleaseInputNegativeNumber": return this.PleaseInputNegativeNumber;
                case "PleaseInputPositiveNumber": return this.PleaseInputPositiveNumber;
                case "PleaseChangeFileNameToUpload": return this.PleaseChangeFileNameToUpload;
                case "PleaseConfirm": return this.PleaseConfirm;
                case "PleaseSelect": return this.PleaseSelect;
                case "PleaseSelectFile": return this.PleaseSelectFile;
                case "PleaseSelectUser": return this.PleaseSelectUser;
                case "PleaseSelectImage": return this.PleaseSelectImage;
                case "PositionName": return this.PositionName;
                case "Post": return this.Post;
                case "PreviousMonth": return this.PreviousMonth;
                case "Price": return this.Price;
                case "Profile": return this.Profile;
                case "Project": return this.Project;
                case "Receive": return this.Receive;
                case "RecentCommentList": return this.RecentCommentList;
                case "RecentSchedule": return this.RecentSchedule;
                case "Remarks": return this.Remarks;
                case "RequestEntityTooLarge": return this.RequestEntityTooLarge;
                case "ResetPassword": return this.ResetPassword;
                case "ResetPasswordMail_Body": return this.ResetPasswordMail_Body;
                case "ResetPasswordMail_Title": return this.ResetPasswordMail_Title;
                case "ResetPasswordMailSent": return this.ResetPasswordMailSent;
                case "ResetPasswordMailSentFailed": return this.ResetPasswordMailSentFailed;
                case "Resolved": return this.Resolved;
                case "Result": return this.Result;
                case "Results": return this.Results;
                case "Save": return this.Save;
                case "SaveAsDraft": return this.SaveAsDraft;
                case "ScheduleNotAcceptedRecordCount": return this.ScheduleNotAcceptedRecordCount;
                case "Search": return this.Search;
                case "SearchCandidate": return this.SearchCandidate;
                case "SearchUser": return this.SearchUser;
                case "SeeAll": return this.SeeAll;
                case "SeeAllComment": return this.SeeAllComment;
                case "SeeDescription": return this.SeeDescription;
                case "SeeMore": return this.SeeMore;
                case "SeeOtherImage": return this.SeeOtherImage;
                case "Select": return this.Select;
                case "SelectRecordByClick": return this.SelectRecordByClick;
                case "SelectUserByClick": return this.SelectUserByClick;
                case "Send": return this.Send;
                case "SendMail": return this.SendMail;
                case "SendMailFailed": return this.SendMailFailed;
                case "SendInvitationMail": return this.SendInvitationMail;
                case "SendInvitationMailFailed": return this.SendInvitationMailFailed;
                case "SendResetPasswordMail": return this.SendResetPasswordMail;
                case "SendResetPasswordMailFailed": return this.SendResetPasswordMailFailed;
                case "Service": return this.Service;
                case "SetByEndTime": return this.SetByEndTime;
                case "SettingChanged": return this.SettingChanged;
                case "Settings": return this.Settings;
                case "Shipping": return this.Shipping;
                case "Signup": return this.Signup;
                case "SignupMailSendFailure": return this.SignupMailSendFailure;
                case "SorryInconvenience": return this.SorryInconvenience;
                case "SortBy": return this.SortBy;
                case "Start": return this.Start;
                case "Stop": return this.Stop;
                case "StartDate": return this.StartDate;
                case "StartTime": return this.StartTime;
                case "State": return this.State;
                case "Subscription": return this.Subscription;
                case "Summary": return this.Summary;
                case "System": return this.System;
                case "SystemManagement": return this.SystemManagement;
                case "PleaseSelectFormat": return this.PleaseSelectFormat;
                case "Tablet": return this.Tablet;
                case "Tag": return this.Tag;
                case "Task": return this.Task;
                case "TaskList": return this.TaskList;
                case "Text": return this.Text;
                case "TextCopied": return this.TextCopied;
                case "ThereIsNoComment": return this.ThereIsNoComment;
                case "ThereIsNoData": return this.ThereIsNoData;
                case "ThereIsNoNotification": return this.ThereIsNoNotification;
                case "ThereIsNoTask": return this.ThereIsNoTask;
                case "ThereIsNoUser": return this.ThereIsNoUser;
                case "ThisAccountAlreadyAuthenticated": return this.ThisAccountAlreadyAuthenticated;
                case "ThisDataMayBeDeleted": return this.ThisDataMayBeDeleted;
                case "ThisFieldIsRequired": return this.ThisFieldIsRequired;
                case "ThisFileFormatIsNotSupported": return this.ThisFileFormatIsNotSupported;
                case "ThisUserIDAlreadyUsed": return this.ThisUserIDAlreadyUsed;
                case "ThisMailAddressAlreadyUsed": return this.ThisMailAddressAlreadyUsed;
                case "ThisMailAddressNotExists": return this.ThisMailAddressNotExists;
                case "ThisPageIsUnderConstructing": return this.ThisPageIsUnderConstructing;
                case "ThisUserAlreadyExists": return this.ThisUserAlreadyExists;
                case "ThisUserIsSelected": return this.ThisUserIsSelected;
                case "TimeZone": return this.TimeZone;
                case "Title": return this.Title;
                case "Today": return this.Today;
                case "TokenExpired": return this.TokenExpired;
                case "TopPixel": return this.TopPixel;
                case "UnAssigned": return this.UnAssigned;
                case "UnConfirm": return this.UnConfirm;
                case "UnConfirmed": return this.UnConfirmed;
                case "UnDecided": return this.UnDecided;
                case "University": return this.University;
                case "Unknown": return this.Unknown;
                case "UnRead": return this.UnRead;
                case "Update": return this.Update;
                case "UpdateTime": return this.UpdateTime;
                case "UpdateUser": return this.UpdateUser;
                case "Upload": return this.Upload;
                case "UploadImage": return this.UploadImage;
                case "Url": return this.Url;
                case "Unsubscribe": return this.Unsubscribe;
                case "Unsubscription": return this.Unsubscription;
                case "User": return this.User;
                case "UserID": return this.UserID;
                case "UserList": return this.UserList;
                case "UserName": return this.UserName;
                case "UserSettings": return this.UserSettings;
                case "ValidationResult_DisplayName_Required": return this.ValidationResult_DisplayName_Required;
                case "ValidationResult_MailAddress_Atmark_Required": return this.ValidationResult_MailAddress_Atmark_Required;
                case "ValidationResult_MailAddress_Required": return this.ValidationResult_MailAddress_Required;
                case "ValidationResult_MaxLengthFormat": return this.ValidationResult_MaxLengthFormat;
                case "ValidationResult_Title_Required": return this.ValidationResult_Title_Required;
                case "View": return this.View;
                case "ViewPermission": return this.ViewPermission;
                case "Visibility": return this.Visibility;
                case "WidthPixel": return this.WidthPixel;
                case "Woman": return this.Woman;
                case "YouDontHaveLicense": return this.YouDontHaveLicense;
                case "YouDontHavePermission": return this.YouDontHavePermission;
                case "YouDontHavePermissionToAdd": return this.YouDontHavePermissionToAdd;
                case "YouDontHavePermissionToDelete": return this.YouDontHavePermissionToDelete;
                case "YouDontHavePermissionToEdit": return this.YouDontHavePermissionToEdit;
                case "YouDontHavePermissionToManage": return this.YouDontHavePermissionToManage;
                case "YouMustAgreeToTermsOfUse": return this.YouMustAgreeToTermsOfUse;
                case "OpenOutputFolder": return this.OpenOutputFolder;
                case "LoadStoredProcedure": return this.LoadStoredProcedure;
                case "LoadUserDefinedType": return this.LoadUserDefinedType;
                case "ConnectionList": return this.ConnectionList;
                case "ConnectionString": return this.ConnectionString;
                case "Namespace": return this.Namespace;
                case "DatabaseKey": return this.DatabaseKey;
                case "OutputFolder": return this.OutputFolder;
                case "LoadResultSet": return this.LoadResultSet;
                case "LoadResultSetFailed": return this.LoadResultSetFailed;
                case "ConnectionFailed": return this.ConnectionFailed;
                default: return "";
            }
        }
    }
}

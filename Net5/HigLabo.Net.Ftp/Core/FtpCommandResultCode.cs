using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace HigLabo.Net.Ftp
{
    /// Specify smtp command result code.
    /// <summary>
    /// Specify smtp command result code.
    /// </summary>
    public enum FtpCommandResultCode : int
    {
        /// <summary>
        /// 
        /// </summary>
        None = 0,
        /// <summary>
        /// 110:RESTコマンドのためのマーカー返答である 
        /// </summary>
        RestartMarkerReply = 110,
        /// <summary>
        /// 120:サービスは停止しているが、nnn分後に準備できる
        /// </summary>
        ServiceReadyInMinutes = 120,
        /// <summary>
        /// 125:データコネクションはすでに確立されている。このコネクションで転送を開始する
        /// </summary>
        DataConnectionAlreadyOpenTransferStarting = 125,
        /// <summary>
        /// 150:ファイルステータスは正常である。データコネクションを確立する 
        /// </summary>
        FileStatusOkayAboutToOpenDataConnection = 150,
        /// <summary>
        /// 200:コマンドは正常に受け入れられた 
        /// </summary>
        CommandOkey = 200,
        /// <summary>
        /// 202:コマンドは実装されていない。
        /// </summary>
        CommandNotImplementedSuperfluousAtThisSite = 202,
        /// <summary>
        /// 211:STATコマンドに対するレスポンス 
        /// </summary>
        SystemStatus = 211,
        /// <summary>
        /// 212:STATコマンドによるディレクトリ情報を示す 
        /// </summary>
        DirectoryStatus = 212,
        /// <summary>
        /// 213:STATコマンドによるファイル情報を示す 
        /// </summary>
        FileStatus = 213,
        /// <summary>
        /// 214:HELPコマンドに対するレスポンス 
        /// </summary>
        HelpMessage = 214,
        /// <summary>
        /// 215:SYSTコマンドに対するレスポンス 
        /// </summary>
        NameSystemType = 215,
        /// <summary>
        /// 220:新規ユーザー向けに準備が整った。ログイン時に表示される場合を想定している
        /// </summary>
        ServiceReady = 220,
        /// <summary>
        /// 221:コントロールコネクションを切断する。QUITコマンド時のレスポンス 
        /// </summary>
        ServiceClosingControlConnection = 221,
        /// <summary>
        /// 225:データコネクションを確立した。データの転送は行われていない
        /// </summary>
        DataConnectionOpen = 225,
        /// <summary>
        /// 226:要求されたリクエストは成功した。データコネクションをクローズする
        /// </summary>
        ClosingDataConnection = 226,
        /// <summary>
        /// 227:PASVコマンドへのレスポンス。
        /// </summary>
        EnteringPassiveMode = 227,
        /// <summary>
        /// 230:ユーザーログインの成功
        /// </summary>
        UserLoggedIn = 230,
        /// <summary>
        /// 250:要求されたコマンドによる操作は正常終了した
        /// </summary>
        RequestedFileActionOkay = 250,
        /// <summary>
        /// 257:ファイルやディレクトリを作成したというのがRFCでの意味だが、MKDコマンドの結果以外にも、実際にはPWDコマンドの結果にも用いられる
        /// </summary>
        Created = 257,
        /// <summary>
        /// 331:パスワードの入力を求める 
        /// </summary>
        UserNameOkey = 331,
        /// <summary>
        /// 332:ACCTコマンドで課金情報を指定する必要がある
        /// </summary>
        NeedAccountForLogin = 332,
        /// <summary>
        /// 350:他の何らかの情報を求めている
        /// </summary>
        RequestedFileActionPendingFurtherInformation = 350,
        /// <summary>
        /// 421:サービスを提供できない。コントロールコネクションを終了する。サーバのシャットダウン時など 
        /// </summary>
        ServiceNotAvailable = 421,
        /// <summary>
        /// 425:データコネクションをオープンできない 
        /// </summary>
        CannotOpenDataConnection = 425,
        /// <summary>
        /// 426:何らかの原因により、コネクションをクローズし、データ転送も中止した 
        /// </summary>
        ConnectionClosedTransferAborted = 426,
        /// <summary>
        /// 450:要求されたリクエストはアクセス権限やファイルシステムの理由で実行できない
        /// </summary>
        RequestedFileActionNotTaken = 450,
        /// <summary>
        /// 451:ローカルエラーのため処理を中止した
        /// </summary>
        RequestedActionAbortedLocalErrorInProcessing = 451,
        /// <summary>
        /// 452:ディスク容量の問題で実行できない
        /// </summary>
        RequestedActionNotTakenForDiskSize = 452,
        /// <summary>
        /// 500:コマンドの文法エラー
        /// </summary>
        SyntaxErrorCommandUnrecognized = 500,
        /// <summary>
        /// 501:引数やパラメータの文法エラー 
        /// </summary>
        SyntaxErrorInParametersOrArguments = 501,
        /// <summary>
        /// 502:コマンドは未実装である
        /// </summary>
        CommandNotImplemented = 502,
        /// <summary>
        /// 503:コマンドを用いる順番が間違っている
        /// </summary>
        BadSequenceOfCommands = 503,
        /// <summary>
        /// 504:引数やパラメータが未実装
        /// </summary>
        CommandNotImplementedForthatParameter = 504,
        /// <summary>
        /// 530:ユーザーはログインできなかった
        /// </summary>
        NotLoggedIn = 530,
        /// <summary>
        /// 532:ファイル送信には、ACCTコマンドで課金情報を確認しなくてはならない
        /// </summary>
        NeedAccountForStoringFiles = 532,
        /// <summary>
        /// 550:要求されたリクエストはアクセス権限やファイルシステムの理由で実行できない
        /// </summary>
        RequestedActionNotTakenForPermissionOrFileSystem = 550,
        /// <summary>
        /// 551:ページ構造のタイプの問題で実行できない
        /// </summary>
        RequestedActionAbortedPageTypeUnknown = 551,
        /// <summary>
        /// 552:ディスク容量の問題で実行できない 
        /// </summary>
        RequestedFileActionAborted = 552,
        /// <summary>
        /// 553:ファイル名が間違っているため実行できない
        /// </summary>
        RequestedActionNotTakenForInvalidFileName = 553,
    }
}

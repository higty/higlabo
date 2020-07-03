using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace HigLabo.Net.Smtp
{
    /// Specify smtp command result code.
    /// <summary>
    /// Specify smtp command result code.
    /// </summary>
    public enum SmtpCommandResultCode : int
    {
		/// <summary>
		/// 
		/// </summary>
        None = 0,
        /// 211:システムの状態。システムヘルプ準備完了。
        /// <summary>
        /// 211:システムの状態。システムヘルプ準備完了。
        /// </summary>
        SystemStatus_OrSystemHelpReply = 211,
        /// 214:ヘルプメッセージ。 
        /// <summary>
        /// 214:ヘルプメッセージ。 
        /// </summary>
        HelpMessage = 214,
        /// 220:準備完了。 
        /// <summary>
        /// 220:準備完了。 
        /// </summary>
        ServiceReady = 220,
        /// 221:接続を閉じる。
        /// <summary>
        /// 221:接続を閉じる。
        /// </summary>
        ServiceClosingTransmissionChannel = 221,
        /// 235:認証は成功。
        /// <summary>
        /// 235:認証は成功。
        /// </summary>
        AuthenticationSuccessful = 235,
        /// 250:要求された処理は実行可能。完了。
        /// <summary>
        /// 250:要求された処理は実行可能。完了。
        /// </summary>
        RequestedMailActionOkay_Completed = 250,
        /// 251:受信者が存在しないので[forward-path]に転送する。 
        /// <summary>
        /// 251:受信者が存在しないので[forward-path]に転送する。 
        /// </summary>
        UserNotLocal_WillForwardTo = 251,
        /// 252:ユーザーの確認に失敗。しかしメッセージ受信され配送される。
        /// <summary>
        /// 252:ユーザーの確認に失敗。しかしメッセージ受信され配送される。
        /// </summary>
        CannotVerifyUser_ButWillAcceptMessageAndAttemptDelivery = 252,
        /// 334:認証処理を待機中
        /// <summary>
        /// 334:認証処理を待機中
        /// </summary>
        WaitingForAuthentication= 334,
        /// 354:メールの入力開始。入力終了は「.」のみの行を送信。 
        /// <summary>
        /// 354:メールの入力開始。入力終了は「.」のみの行を送信。 
        /// </summary>
        StartMailInput = 354,
        /// 421:サービスは利用不能。接続を閉じる。 
        /// <summary>
        /// 421:サービスは利用不能。接続を閉じる。 
        /// </summary>
        ServiceNotAvailable_ClosingTransmissionChannel = 421,
        /// 432:パスワードの変更が必要。
        /// <summary>
        /// 432:パスワードの変更が必要。
        /// </summary>
        APasswordTransitionIsNeeded = 432,
        /// 450:メールボックスが利用できないため、要求された処理は実行不能。
        /// <summary>
        /// 450:メールボックスが利用できないため、要求された処理は実行不能。
        /// </summary>
        RequestedMailActionNotTaken_MailboxUnavailable = 450,
        /// 451:処理中にエラーが発生。要求された処理は失敗。
        /// <summary>
        /// 451:処理中にエラーが発生。要求された処理は失敗。
        /// </summary>
        RequestedActionAborted_ErrorInProcessing = 451,
        /// 454:一時的な認証失敗。
        /// <summary>
        /// 454:一時的な認証失敗。
        /// </summary>
        TemporaryAuthenticationFailure = 454,
        /// 500:文法に間違いがあるため、コマンドが理解できない。
        /// <summary>
        /// 500:文法に間違いがあるため、コマンドが理解できない。
        /// </summary>
        SyntaxError_CommandUnrecognized = 500,
        /// 501:引数の文法に間違いがある。
        /// <summary>
        /// 501:引数の文法に間違いがある。
        /// </summary>
        SyntaxErrorInParametersOrArguments = 501,
        /// 502:指示されたコマンドはこのシステムには実装されていない。
        /// <summary>
        /// 502:指示されたコマンドはこのシステムには実装されていない。
        /// </summary>
        CommandNotImplemented = 502,
        /// 503:コマンドの発行順序が間違っている。
        /// <summary>
        /// 503:コマンドの発行順序が間違っている。
        /// </summary>
        BadSequenceOfCommands = 503,
        /// 504:コマンドの引数が未定義。
        /// <summary>
        /// 504:コマンドの引数が未定義。
        /// </summary>
        CommandParameterNotImplemented = 504,
        /// 530:認証が必要。
        /// <summary>
        /// 530:認証が必要。
        /// </summary>
        AuthenticationRequired = 530,
        /// 538:要求された認証処理には暗号化が必要。
        /// <summary>
        /// 538:要求された認証処理には暗号化が必要。
        /// </summary>
        EncryptionRequiredForRequestedAuthenticationMechanism = 538,
        /// 550:メールボックスが利用できないため、要求された処理は実行不能。 
        /// <summary>
        /// 550:メールボックスが利用できないため、要求された処理は実行不能。 
        /// </summary>
        RequestedActionNotTaken_MailboxUnavailable = 550,
        /// 551:受信者が存在しない。[forward-path]に送信せよ。
        /// <summary>
        /// 551:受信者が存在しない。[forward-path]に送信せよ。
        /// </summary>
        UserNotLocal_PleaseTry = 551,
        /// 552:ディスク不足のため、要求された処理は実行不能。
        /// <summary>
        /// 552:ディスク不足のため、要求された処理は実行不能。
        /// </summary>
        RequestedMailActionAborted_ExceededStorageAllocation = 552,
        /// 553:メールボックスが許可されないため、要求された処理は実行不能。
        /// <summary>
		/// 553:メールボックスが許可されないため、要求された処理は実行不能。
		/// </summary>
        RequestedActionNotTaken_MailboxNameNotAllowed = 553,
        /// 554:処理失敗。
        /// <summary>
        /// 554:処理失敗。
        /// </summary>
        TransactionFailed = 554
    }
}

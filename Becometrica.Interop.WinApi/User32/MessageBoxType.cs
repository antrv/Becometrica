namespace Becometrica.Interop.WinApi.User32;

public enum MessageBoxType: uint
{
    /// <summary>
    /// The message box contains three push buttons: Abort, Retry, and Ignore.
    /// </summary>
    AbortRetryIgnore = 0x00000002,

    /// <summary>
    /// The message box contains three push buttons: Cancel, Try Again, Continue. Use this message box type instead of MB_ABORTRETRYIGNORE.
    /// </summary>
    CancelTryContinue = 0x00000006,

    /// <summary>
    /// Adds a Help button to the message box. When the user clicks the Help button or presses F1, the system sends a WM_HELP message to the owner.
    /// </summary>
    Help = 0x00004000,

    /// <summary>
    /// The message box contains one push button: OK. This is the default.
    /// </summary>
    Ok = 0x00000000,

    /// <summary>
    /// The message box contains two push buttons: OK and Cancel.
    /// </summary>
    OkCancel = 0x00000001,

    /// <summary>
    /// The message box contains two push buttons: Retry and Cancel.
    /// </summary>
    RetryCancel = 0x00000005,

    /// <summary>
    /// The message box contains two push buttons: Yes and No.
    /// </summary>
    YesNo = 0x00000004,

    /// <summary>
    /// The message box contains three push buttons: Yes, No, and Cancel.
    /// </summary>
    YesNoCancel = 0x00000003,

    /// <summary>
    /// An exclamation-point icon appears in the message box.
    /// </summary>
    IconExclamation = 0x00000030,

    /// <summary>
    /// An exclamation-point icon appears in the message box.
    /// </summary>
    IconWarning = 0x00000030,

    /// <summary>
    /// An icon consisting of a lowercase letter i in a circle appears in the message box.
    /// </summary>
    IconInformation = 0x00000040,

    /// <summary>
    /// An icon consisting of a lowercase letter i in a circle appears in the message box.
    /// </summary>
    IconAsterisk = 0x00000040,

    /// <summary>
    /// A question-mark icon appears in the message box. The question-mark message icon is no longer recommended because it does not clearly represent a specific type of message and because the phrasing of a message as a question could apply to any message type. In addition, users can confuse the message symbol question mark with Help information. Therefore, do not use this question mark message symbol in your message boxes. The system continues to support its inclusion only for backward compatibility.
    /// </summary>
    IconQuestion = 0x00000020,

    /// <summary>
    /// A stop-sign icon appears in the message box.
    /// </summary>
    IconStop = 0x00000010,

    /// <summary>
    /// A stop-sign icon appears in the message box.
    /// </summary>
    IconError = 0x00000010,

    /// <summary>
    /// A stop-sign icon appears in the message box.
    /// </summary>
    IconHand = 0x00000010,

    /// <summary>
    /// The first button is the default button.
    /// MB_DEFBUTTON1 is the default unless MB_DEFBUTTON2, MB_DEFBUTTON3, or MB_DEFBUTTON4 is specified.
    /// </summary>
    DefButton1 = 0x00000000,

    /// <summary>
    /// The second button is the default button.
    /// </summary>
    DefButton2 = 0x00000100,

    /// <summary>
    /// The third button is the default button.
    /// </summary>
    DefButton3 = 0x00000200,

    /// <summary>
    /// The fourth button is the default button.
    /// </summary>
    DefButton4 = 0x00000300,

    /// <summary>
    /// The user must respond to the message box before continuing work in the window identified by the hWnd parameter. However, the user can move to the windows of other threads and work in those windows.
    /// Depending on the hierarchy of windows in the application, the user may be able to move to other windows within the thread. All child windows of the parent of the message box are automatically disabled, but pop-up windows are not.
    ///
    /// MB_APPLMODAL is the default if neither MB_SYSTEMMODAL nor MB_TASKMODAL is specified.
    /// </summary>
    ApplicationModal = 0x00000000,

    /// <summary>
    /// Same as MB_APPLMODAL except that the message box has the WS_EX_TOPMOST style. Use system-modal message boxes to notify the user of serious, potentially damaging errors that require immediate attention (for example, running out of memory). This flag has no effect on the user's ability to interact with windows other than those associated with hWnd.
    /// </summary>
    SystemModal = 0x00001000,

    /// <summary>
    /// Same as MB_APPLMODAL except that all the top-level windows belonging to the current thread are disabled if the hWnd parameter is NULL. Use this flag when the calling application or library does not have a window handle available but still needs to prevent input to other windows in the calling thread without suspending other threads.
    /// </summary>
    TaskModal = 0x00002000,

    /// <summary>
    /// Same as desktop of the interactive window station. For more information, see Window Stations.
    /// If the current input desktop is not the default desktop, MessageBox does not return until the user switches to the default desktop.
    /// </summary>
    DefaultDesktopOnly = 0x00020000,

    /// <summary>
    /// The text is right-justified.
    /// </summary>
    Right = 0x00080000,

    /// <summary>
    /// Displays message and caption text using right-to-left reading order on Hebrew and Arabic systems.
    /// </summary>
    RtlReading = 0x00100000,

    /// <summary>
    /// The message box becomes the foreground window. Internally, the system calls the SetForegroundWindow function for the message box.
    /// </summary>
    SetForeground = 0x00010000,

    /// <summary>
    /// The message box is created with the WS_EX_TOPMOST window style.
    /// </summary>
    Topmost = 0x00040000,

    /// <summary>
    /// The caller is a service notifying the user of an event. The function displays a message box on the current active desktop, even if there is no user logged on to the computer.
    /// Terminal Services: If the calling thread has an impersonation token, the function directs the message box to the session specified in the impersonation token.
    ///
    /// If this flag is set, the hWnd parameter must be NULL. This is so that the message box can appear on a desktop other than the desktop corresponding to the hWnd.
    ///
    /// For information on security considerations in regard to using this flag, see Interactive Services. In particular, be aware that this flag can produce interactive content on a locked desktop and should therefore be used for only a very limited set of scenarios, such as resource exhaustion.
    /// </summary>
    ServiceNotification = 0x00200000,
}
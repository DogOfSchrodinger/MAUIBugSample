using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;


namespace SuperNode
{

    public enum KeyCode
    {
        //
        // 摘要:
        //     No virtual key value.
        None = 0,
        //
        // 摘要:
        //     The left mouse button.
        LeftButton = 1,
        //
        // 摘要:
        //     The right mouse button.
        RightButton = 2,
        //
        // 摘要:
        //     The cancel key or button
        Cancel = 3,
        //
        // 摘要:
        //     The middle mouse button.
        MiddleButton = 4,
        //
        // 摘要:
        //     An additional "extended" device key or button (for example, an additional mouse
        //     button).
        XButton1 = 5,
        //
        // 摘要:
        //     An additional "extended" device key or button (for example, an additional mouse
        //     button).
        XButton2 = 6,
        //
        // 摘要:
        //     The virtual back key or button.
        Back = 8,
        //
        // 摘要:
        //     The Tab key.
        Tab = 9,
        //
        // 摘要:
        //     The Clear key or button.
        Clear = 12,
        //
        // 摘要:
        //     The Enter key.
        Enter = 13,
        //
        // 摘要:
        //     The Shift key. This is the general Shift case, applicable to key layouts with
        //     only one Shift key or that do not need to differentiate between left Shift and
        //     right Shift keystrokes.
        Shift = 0x10,
        //
        // 摘要:
        //     The Ctrl key. This is the general Ctrl case, applicable to key layouts with only
        //     one Ctrl key or that do not need to differentiate between left Ctrl and right
        //     Ctrl keystrokes.
        Control = 17,
        //
        // 摘要:
        //     The menu key or button.
        Menu = 18,
        //
        // 摘要:
        //     The Pause key or button.
        Pause = 19,
        //
        // 摘要:
        //     The Caps Lock key or button.
        CapitalLock = 20,
        //
        // 摘要:
        //     The Kana symbol key-shift button
        Kana = 21,
        //
        // 摘要:
        //     The Hangul symbol key-shift button.
        Hangul = 21,
        //
        // 摘要:
        //     The Junja symbol key-shift button.
        Junja = 23,
        //
        // 摘要:
        //     The Final symbol key-shift button.
        Final = 24,
        //
        // 摘要:
        //     The Hanja symbol key shift button.
        Hanja = 25,
        //
        // 摘要:
        //     The Kanji symbol key-shift button.
        Kanji = 25,
        //
        // 摘要:
        //     The Esc key.
        Escape = 27,
        //
        // 摘要:
        //     The convert button or key.
        Convert = 28,
        //
        // 摘要:
        //     The nonconvert button or key.
        NonConvert = 29,
        //
        // 摘要:
        //     The accept button or key.
        Accept = 30,
        //
        // 摘要:
        //     The mode change key.
        ModeChange = 0x1F,
        //
        // 摘要:
        //     The Spacebar key or button.
        Space = 0x20,
        //
        // 摘要:
        //     The Page Up key.
        PageUp = 33,
        //
        // 摘要:
        //     The Page Down key.
        PageDown = 34,
        //
        // 摘要:
        //     The End key.
        End = 35,
        //
        // 摘要:
        //     The Home key.
        Home = 36,
        //
        // 摘要:
        //     The Left Arrow key.
        Left = 37,
        //
        // 摘要:
        //     The Up Arrow key.
        Up = 38,
        //
        // 摘要:
        //     The Right Arrow key.
        Right = 39,
        //
        // 摘要:
        //     The Down Arrow key.
        Down = 40,
        //
        // 摘要:
        //     The Select key or button.
        Select = 41,
        //
        // 摘要:
        //     The Print key or button.
        Print = 42,
        //
        // 摘要:
        //     The execute key or button.
        Execute = 43,
        //
        // 摘要:
        //     The snapshot key or button.
        Snapshot = 44,
        //
        // 摘要:
        //     The Insert key.
        Insert = 45,
        //
        // 摘要:
        //     The Delete key.
        Delete = 46,
        //
        // 摘要:
        //     The Help key or button.
        Help = 47,
        //
        // 摘要:
        //     The number "0" key.
        Number0 = 48,
        //
        // 摘要:
        //     The number "1" key.
        Number1 = 49,
        //
        // 摘要:
        //     The number "2" key.
        Number2 = 50,
        //
        // 摘要:
        //     The number "3" key.
        Number3 = 51,
        //
        // 摘要:
        //     The number "4" key.
        Number4 = 52,
        //
        // 摘要:
        //     The number "5" key.
        Number5 = 53,
        //
        // 摘要:
        //     The number "6" key.
        Number6 = 54,
        //
        // 摘要:
        //     The number "7" key.
        Number7 = 55,
        //
        // 摘要:
        //     The number "8" key.
        Number8 = 56,
        //
        // 摘要:
        //     The number "9" key.
        Number9 = 57,
        //
        // 摘要:
        //     The letter "A" key.
        A = 65,
        //
        // 摘要:
        //     The letter "B" key.
        B = 66,
        //
        // 摘要:
        //     The letter "C" key.
        C = 67,
        //
        // 摘要:
        //     The letter "D" key.
        D = 68,
        //
        // 摘要:
        //     The letter "E" key.
        E = 69,
        //
        // 摘要:
        //     The letter "F" key.
        F = 70,
        //
        // 摘要:
        //     The letter "G" key.
        G = 71,
        //
        // 摘要:
        //     The letter "H" key.
        H = 72,
        //
        // 摘要:
        //     The letter "I" key.
        I = 73,
        //
        // 摘要:
        //     The letter "J" key.
        J = 74,
        //
        // 摘要:
        //     The letter "K" key.
        K = 75,
        //
        // 摘要:
        //     The letter "L" key.
        L = 76,
        //
        // 摘要:
        //     The letter "M" key.
        M = 77,
        //
        // 摘要:
        //     The letter "N" key.
        N = 78,
        //
        // 摘要:
        //     The letter "O" key.
        O = 79,
        //
        // 摘要:
        //     The letter "P" key.
        P = 80,
        //
        // 摘要:
        //     The letter "Q" key.
        Q = 81,
        //
        // 摘要:
        //     The letter "R" key.
        R = 82,
        //
        // 摘要:
        //     The letter "S" key.
        S = 83,
        //
        // 摘要:
        //     The letter "T" key.
        T = 84,
        //
        // 摘要:
        //     The letter "U" key.
        U = 85,
        //
        // 摘要:
        //     The letter "V" key.
        V = 86,
        //
        // 摘要:
        //     The letter "W" key.
        W = 87,
        //
        // 摘要:
        //     The letter "X" key.
        X = 88,
        //
        // 摘要:
        //     The letter "Y" key.
        Y = 89,
        //
        // 摘要:
        //     The letter "Z" key.
        Z = 90,
        //
        // 摘要:
        //     The left Windows key.
        LeftWindows = 91,
        //
        // 摘要:
        //     The right Windows key.
        RightWindows = 92,
        //
        // 摘要:
        //     The application key or button.
        Application = 93,
        //
        // 摘要:
        //     The sleep key or button.
        Sleep = 95,
        //
        // 摘要:
        //     The number "0" key as located on a numeric pad.
        NumberPad0 = 96,
        //
        // 摘要:
        //     The number "1" key as located on a numeric pad.
        NumberPad1 = 97,
        //
        // 摘要:
        //     The number "2" key as located on a numeric pad.
        NumberPad2 = 98,
        //
        // 摘要:
        //     The number "3" key as located on a numeric pad.
        NumberPad3 = 99,
        //
        // 摘要:
        //     The number "4" key as located on a numeric pad.
        NumberPad4 = 100,
        //
        // 摘要:
        //     The number "5" key as located on a numeric pad.
        NumberPad5 = 101,
        //
        // 摘要:
        //     The number "6" key as located on a numeric pad.
        NumberPad6 = 102,
        //
        // 摘要:
        //     The number "7" key as located on a numeric pad.
        NumberPad7 = 103,
        //
        // 摘要:
        //     The number "8" key as located on a numeric pad.
        NumberPad8 = 104,
        //
        // 摘要:
        //     The number "9" key as located on a numeric pad.
        NumberPad9 = 105,
        //
        // 摘要:
        //     The multiply (*) operation key as located on a numeric pad.
        Multiply = 106,
        //
        // 摘要:
        //     The add (+) operation key as located on a numeric pad.
        Add = 107,
        //
        // 摘要:
        //     The separator key as located on a numeric pad.
        Separator = 108,
        //
        // 摘要:
        //     The subtract (-) operation key as located on a numeric pad.
        Subtract = 109,
        //
        // 摘要:
        //     The decimal (.) key as located on a numeric pad.
        Decimal = 110,
        //
        // 摘要:
        //     The divide (/) operation key as located on a numeric pad.
        Divide = 111,
        //
        // 摘要:
        //     The F1 function key.
        F1 = 112,
        //
        // 摘要:
        //     The F2 function key.
        F2 = 113,
        //
        // 摘要:
        //     The F3 function key.
        F3 = 114,
        //
        // 摘要:
        //     The F4 function key.
        F4 = 115,
        //
        // 摘要:
        //     The F5 function key.
        F5 = 116,
        //
        // 摘要:
        //     The F6 function key.
        F6 = 117,
        //
        // 摘要:
        //     The F7 function key.
        F7 = 118,
        //
        // 摘要:
        //     The F8 function key.
        F8 = 119,
        //
        // 摘要:
        //     The F9 function key.
        F9 = 120,
        //
        // 摘要:
        //     The F10 function key.
        F10 = 121,
        //
        // 摘要:
        //     The F11 function key.
        F11 = 122,
        //
        // 摘要:
        //     The F12 function key.
        F12 = 123,
        //
        // 摘要:
        //     The F13 function key.
        F13 = 124,
        //
        // 摘要:
        //     The F14 function key.
        F14 = 125,
        //
        // 摘要:
        //     The F15 function key.
        F15 = 126,
        //
        // 摘要:
        //     The F16 function key.
        F16 = 0x7F,
        //
        // 摘要:
        //     The F17 function key.
        F17 = 0x80,
        //
        // 摘要:
        //     The F18 function key.
        F18 = 129,
        //
        // 摘要:
        //     The F19 function key.
        F19 = 130,
        //
        // 摘要:
        //     The F20 function key.
        F20 = 131,
        //
        // 摘要:
        //     The F21 function key.
        F21 = 132,
        //
        // 摘要:
        //     The F22 function key.
        F22 = 133,
        //
        // 摘要:
        //     The F23 function key.
        F23 = 134,
        //
        // 摘要:
        //     The F24 function key.
        F24 = 135,
        //
        // 摘要:
        //     The navigation up button.
        [SupportedOSPlatform("Windows10.0.10240.0")]
        NavigationView = 136,
        //
        // 摘要:
        //     The navigation menu button.
        [SupportedOSPlatform("Windows10.0.10240.0")]
        NavigationMenu = 137,
        //
        // 摘要:
        //     The navigation up button.
        [SupportedOSPlatform("Windows10.0.10240.0")]
        NavigationUp = 138,
        //
        // 摘要:
        //     The navigation down button.
        [SupportedOSPlatform("Windows10.0.10240.0")]
        NavigationDown = 139,
        //
        // 摘要:
        //     The navigation left button.
        [SupportedOSPlatform("Windows10.0.10240.0")]
        NavigationLeft = 140,
        //
        // 摘要:
        //     The navigation right button.
        [SupportedOSPlatform("Windows10.0.10240.0")]
        NavigationRight = 141,
        //
        // 摘要:
        //     The navigation accept button.
        [SupportedOSPlatform("Windows10.0.10240.0")]
        NavigationAccept = 142,
        //
        // 摘要:
        //     The navigation cancel button.
        [SupportedOSPlatform("Windows10.0.10240.0")]
        NavigationCancel = 143,
        //
        // 摘要:
        //     The Num Lock key.
        NumberKeyLock = 144,
        //
        // 摘要:
        //     The Scroll Lock (ScrLk) key.
        Scroll = 145,
        //
        // 摘要:
        //     The left Shift key.
        LeftShift = 160,
        //
        // 摘要:
        //     The right Shift key.
        RightShift = 161,
        //
        // 摘要:
        //     The left Ctrl key.
        LeftControl = 162,
        //
        // 摘要:
        //     The right Ctrl key.
        RightControl = 163,
        //
        // 摘要:
        //     The left menu key.
        LeftMenu = 164,
        //
        // 摘要:
        //     The right menu key.
        RightMenu = 165,
        //
        // 摘要:
        //     The go back key.
        [SupportedOSPlatform("Windows10.0.10240.0")]
        GoBack = 166,
        //
        // 摘要:
        //     The go forward key.
        [SupportedOSPlatform("Windows10.0.10240.0")]
        GoForward = 167,
        //
        // 摘要:
        //     The refresh key.
        [SupportedOSPlatform("Windows10.0.10240.0")]
        Refresh = 168,
        //
        // 摘要:
        //     The stop key.
        [SupportedOSPlatform("Windows10.0.10240.0")]
        Stop = 169,
        //
        // 摘要:
        //     The search key.
        [SupportedOSPlatform("Windows10.0.10240.0")]
        Search = 170,
        //
        // 摘要:
        //     The favorites key.
        [SupportedOSPlatform("Windows10.0.10240.0")]
        Favorites = 171,
        //
        // 摘要:
        //     The go home key.
        [SupportedOSPlatform("Windows10.0.10240.0")]
        GoHome = 172,
        //
        // 摘要:
        //     The gamepad A button.
        [SupportedOSPlatform("Windows10.0.10240.0")]
        GamepadA = 195,
        //
        // 摘要:
        //     The gamepad B button.
        [SupportedOSPlatform("Windows10.0.10240.0")]
        GamepadB = 196,
        //
        // 摘要:
        //     The gamepad X button.
        [SupportedOSPlatform("Windows10.0.10240.0")]
        GamepadX = 197,
        //
        // 摘要:
        //     The gamepad Y button.
        [SupportedOSPlatform("Windows10.0.10240.0")]
        GamepadY = 198,
        //
        // 摘要:
        //     The gamepad right shoulder.
        [SupportedOSPlatform("Windows10.0.10240.0")]
        GamepadRightShoulder = 199,
        //
        // 摘要:
        //     The gamepad left shoulder.
        [SupportedOSPlatform("Windows10.0.10240.0")]
        GamepadLeftShoulder = 200,
        //
        // 摘要:
        //     The gamepad left trigger.
        [SupportedOSPlatform("Windows10.0.10240.0")]
        GamepadLeftTrigger = 201,
        //
        // 摘要:
        //     The gamepad right trigger.
        [SupportedOSPlatform("Windows10.0.10240.0")]
        GamepadRightTrigger = 202,
        //
        // 摘要:
        //     The gamepad d-pad up.
        [SupportedOSPlatform("Windows10.0.10240.0")]
        GamepadDPadUp = 203,
        //
        // 摘要:
        //     The gamepad d-pad down.
        [SupportedOSPlatform("Windows10.0.10240.0")]
        GamepadDPadDown = 204,
        //
        // 摘要:
        //     The gamepad d-pad left.
        [SupportedOSPlatform("Windows10.0.10240.0")]
        GamepadDPadLeft = 205,
        //
        // 摘要:
        //     The gamepad d-pad right.
        [SupportedOSPlatform("Windows10.0.10240.0")]
        GamepadDPadRight = 206,
        //
        // 摘要:
        //     The gamepad menu button.
        [SupportedOSPlatform("Windows10.0.10240.0")]
        GamepadMenu = 207,
        //
        // 摘要:
        //     The gamepad view button.
        [SupportedOSPlatform("Windows10.0.10240.0")]
        GamepadView = 208,
        //
        // 摘要:
        //     The gamepad left thumbstick button.
        [SupportedOSPlatform("Windows10.0.10240.0")]
        GamepadLeftThumbstickButton = 209,
        //
        // 摘要:
        //     The gamepad right thumbstick button.
        [SupportedOSPlatform("Windows10.0.10240.0")]
        GamepadRightThumbstickButton = 210,
        //
        // 摘要:
        //     The gamepad left thumbstick up.
        [SupportedOSPlatform("Windows10.0.10240.0")]
        GamepadLeftThumbstickUp = 211,
        //
        // 摘要:
        //     The gamepad left thumbstick down.
        [SupportedOSPlatform("Windows10.0.10240.0")]
        GamepadLeftThumbstickDown = 212,
        //
        // 摘要:
        //     The gamepad left thumbstick right.
        [SupportedOSPlatform("Windows10.0.10240.0")]
        GamepadLeftThumbstickRight = 213,
        //
        // 摘要:
        //     The gamepad left thumbstick left.
        [SupportedOSPlatform("Windows10.0.10240.0")]
        GamepadLeftThumbstickLeft = 214,
        //
        // 摘要:
        //     The gamepad right thumbstick up.
        [SupportedOSPlatform("Windows10.0.10240.0")]
        GamepadRightThumbstickUp = 215,
        //
        // 摘要:
        //     The gamepad right thumbstick down.
        [SupportedOSPlatform("Windows10.0.10240.0")]
        GamepadRightThumbstickDown = 216,
        //
        // 摘要:
        //     The gamepad right thumbstick right.
        [SupportedOSPlatform("Windows10.0.10240.0")]
        GamepadRightThumbstickRight = 217,
        //
        // 摘要:
        //     The gamepad right thumbstick left.
        [SupportedOSPlatform("Windows10.0.10240.0")]
        GamepadRightThumbstickLeft = 218
    }
}

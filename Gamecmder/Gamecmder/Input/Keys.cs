using System;
using System.Collections.Generic;
using System.Text;

namespace Gamecmder.Input
{
    public enum Key
    {
        None,

        A,
        B,
        C,
        D,
        E,
        F,
        G,
        H,
        I,
        J,
        K,
        L,
        M,
        N,
        O,
        P,
        Q,
        R,
        S,
        T,
        U,
        V,
        W,
        X,
        Y,
        Z,
        Number0,
        Number1,
        Number2,
        Number3,
        Number4,
        Number5,
        Number6,
        Number7,
        Number8,
        Number9,

        NumPad0,
        NumPad1,
        NumPad2,
        NumPad3,
        NumPad4,
        NumPad5,
        NumPad6,
        NumPad7,
        NumPad8,
        NumPad9,

        NumPadDecimal,
        NumPadDivide,
        NumPadMultiply,
        NumPadAdd,
        NumPadSubtract,

        Tab,
        Tilde,
        Escape,

        F1,
        F2,
        F3,
        F4,
        F5,
        F6,
        F7,
        F8,
        F9,
        F10,
        F11,
        F12,
        Insert,
        Delete,
        Backspace,
        Enter,
        LeftWindows,
        RightWindows,
        Command,
        PrintScreen,
        PageUp,
        PageDown,
        Home,
        End,

        Up,
        Down,
        Left,
        Right,
        BackSlash,
        Spacebar,
        Comma,
        Minus,
        Period
    }

    [Flags]
    public enum ModifierKey
    {
        None = 0,

        LeftCtrl = 1,
        RightCtrl = 2,
        Alt = 4,
        AltGr = 8,
        LeftShift = 16,
        RightShift = 32
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace SnakeNet.Framework.Input
{
    public interface IInputManager
    {
        InputState State { get; }
        void Update(TimeSpan elapsedTime);
    }

    public class CmdInputManager : IInputManager
    {
        public InputState State { get; } = new InputState();

        public void Update(TimeSpan elapsedTime)
        {
            MapCmdInput();
        }

        private void MapCmdInput()
        {
            Key key = Key.None;
            ModifierKey modifierKey = ModifierKey.None;

            if (Console.KeyAvailable)
            {
                var consoleKey = Console.ReadKey();

                key = MapConsoleKey(consoleKey.Key);
                modifierKey = MapModifierKey(consoleKey.Modifiers);
            }

            State.KeyPressed = key;
            State.ModifierPressed = modifierKey;
        }

        private ModifierKey MapModifierKey(ConsoleModifiers modifiers)
        {
            switch (modifiers)
            {
                case ConsoleModifiers.Alt: return ModifierKey.Alt | ModifierKey.AltGr;
                case ConsoleModifiers.Control: return ModifierKey.LeftCtrl | ModifierKey.RightCtrl;
                case ConsoleModifiers.Shift: return ModifierKey.LeftShift | ModifierKey.RightShift;
                case 0: return ModifierKey.None;

                default: throw new NotSupportedException("Modifier key not supported in cmd applications");
            }
        }

        private Key MapConsoleKey(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.A: return Key.A;
                case ConsoleKey.Add: throw new NotImplementedException();
                case ConsoleKey.Applications: throw new NotImplementedException();
                case ConsoleKey.Attention: throw new NotImplementedException();
                case ConsoleKey.B: return Key.B;
                case ConsoleKey.Backspace: return Key.Backspace;
                case ConsoleKey.BrowserBack: throw new NotImplementedException();
                case ConsoleKey.BrowserFavorites: throw new NotImplementedException();
                case ConsoleKey.BrowserForward: throw new NotImplementedException();
                case ConsoleKey.BrowserHome: throw new NotImplementedException();
                case ConsoleKey.BrowserRefresh: throw new NotImplementedException();
                case ConsoleKey.BrowserSearch: throw new NotImplementedException();
                case ConsoleKey.BrowserStop: throw new NotImplementedException();
                case ConsoleKey.C: return Key.C;
                case ConsoleKey.Clear: throw new NotImplementedException();
                case ConsoleKey.CrSel: throw new NotImplementedException();
                case ConsoleKey.D: return Key.D;
                case ConsoleKey.D0: return Key.Number0;
                case ConsoleKey.D1: return Key.Number1;
                case ConsoleKey.D2: return Key.Number2;
                case ConsoleKey.D3: return Key.Number3;
                case ConsoleKey.D4: return Key.Number4;
                case ConsoleKey.D5: return Key.Number5;
                case ConsoleKey.D6: return Key.Number6;
                case ConsoleKey.D7: return Key.Number7;
                case ConsoleKey.D8: return Key.Number8;
                case ConsoleKey.D9: return Key.Number9;
                case ConsoleKey.Decimal: return Key.NumPadDecimal;
                case ConsoleKey.Delete: return Key.Delete;
                case ConsoleKey.Divide: return Key.NumPadDivide;
                case ConsoleKey.DownArrow: return Key.Down;
                case ConsoleKey.E: return Key.E;
                case ConsoleKey.End: return Key.End;
                case ConsoleKey.Enter: return Key.Enter;
                case ConsoleKey.EraseEndOfFile: throw new NotImplementedException();
                case ConsoleKey.Escape: return Key.Escape;
                case ConsoleKey.Execute: throw new NotImplementedException();
                case ConsoleKey.ExSel: throw new NotImplementedException();
                case ConsoleKey.F: return Key.F;
                case ConsoleKey.F1: return Key.F1;
                case ConsoleKey.F10: return Key.F10;
                case ConsoleKey.F11: return Key.F11;
                case ConsoleKey.F12: return Key.F12;
                case ConsoleKey.F13: throw new NotImplementedException();
                case ConsoleKey.F14: throw new NotImplementedException();
                case ConsoleKey.F15: throw new NotImplementedException();
                case ConsoleKey.F16: throw new NotImplementedException();
                case ConsoleKey.F17: throw new NotImplementedException();
                case ConsoleKey.F18: throw new NotImplementedException();
                case ConsoleKey.F19: throw new NotImplementedException();
                case ConsoleKey.F2: return Key.F2;
                case ConsoleKey.F20: throw new NotImplementedException();
                case ConsoleKey.F21: throw new NotImplementedException();
                case ConsoleKey.F22: throw new NotImplementedException();
                case ConsoleKey.F23: throw new NotImplementedException();
                case ConsoleKey.F24: throw new NotImplementedException();
                case ConsoleKey.F3: return Key.F3;
                case ConsoleKey.F4: return Key.F4;
                case ConsoleKey.F5: return Key.F5;
                case ConsoleKey.F6: return Key.F6;
                case ConsoleKey.F7: return Key.F7;
                case ConsoleKey.F8: return Key.F8;
                case ConsoleKey.F9: return Key.F9;
                case ConsoleKey.G: return Key.G;
                case ConsoleKey.H: return Key.H;
                case ConsoleKey.Help: throw new NotImplementedException();
                case ConsoleKey.Home: return Key.Home;
                case ConsoleKey.I: return Key.I;
                case ConsoleKey.Insert: return Key.Insert;
                case ConsoleKey.J: return Key.J;
                case ConsoleKey.K: return Key.K;
                case ConsoleKey.L: return Key.L;
                case ConsoleKey.LaunchApp1: throw new NotImplementedException();
                case ConsoleKey.LaunchApp2: throw new NotImplementedException();
                case ConsoleKey.LaunchMail: throw new NotImplementedException();
                case ConsoleKey.LaunchMediaSelect: throw new NotImplementedException();
                case ConsoleKey.LeftArrow: return Key.Left;
                case ConsoleKey.LeftWindows: return Key.LeftWindows;
                case ConsoleKey.M: return Key.M;
                case ConsoleKey.MediaNext: throw new NotImplementedException();
                case ConsoleKey.MediaPlay: throw new NotImplementedException();
                case ConsoleKey.MediaPrevious: throw new NotImplementedException();
                case ConsoleKey.MediaStop: throw new NotImplementedException();
                case ConsoleKey.Multiply: return Key.NumPadMultiply;
                case ConsoleKey.N: return Key.N;
                case ConsoleKey.NoName: throw new NotImplementedException();
                case ConsoleKey.NumPad0: return Key.NumPad0;
                case ConsoleKey.NumPad1: return Key.NumPad1;
                case ConsoleKey.NumPad2: return Key.NumPad2;
                case ConsoleKey.NumPad3: return Key.NumPad3;
                case ConsoleKey.NumPad4: return Key.NumPad4;
                case ConsoleKey.NumPad5: return Key.NumPad5;
                case ConsoleKey.NumPad6: return Key.NumPad6;
                case ConsoleKey.NumPad7: return Key.NumPad7;
                case ConsoleKey.NumPad8: return Key.NumPad8;
                case ConsoleKey.NumPad9: return Key.NumPad9;
                case ConsoleKey.O: return Key.O;
                case ConsoleKey.Oem1: throw new NotImplementedException();
                case ConsoleKey.Oem102: throw new NotImplementedException();
                case ConsoleKey.Oem2: throw new NotImplementedException();
                case ConsoleKey.Oem3: throw new NotImplementedException();
                case ConsoleKey.Oem4: throw new NotImplementedException();
                case ConsoleKey.Oem5: throw new NotImplementedException();
                case ConsoleKey.Oem6: throw new NotImplementedException();
                case ConsoleKey.Oem7: throw new NotImplementedException();
                case ConsoleKey.Oem8: throw new NotImplementedException();
                case ConsoleKey.OemClear: throw new NotImplementedException();
                case ConsoleKey.OemComma: return Key.Comma;
                case ConsoleKey.OemMinus: return Key.Minus;
                case ConsoleKey.OemPeriod: return Key.Period;
                case ConsoleKey.OemPlus: throw new NotImplementedException();
                case ConsoleKey.P: return Key.P;
                case ConsoleKey.Pa1: throw new NotImplementedException();
                case ConsoleKey.Packet: throw new NotImplementedException();
                case ConsoleKey.PageDown: return Key.PageDown;
                case ConsoleKey.PageUp: return Key.PageUp;
                case ConsoleKey.Pause: throw new NotImplementedException();
                case ConsoleKey.Play: throw new NotImplementedException();
                case ConsoleKey.Print: throw new NotImplementedException();
                case ConsoleKey.PrintScreen: return Key.PrintScreen;
                case ConsoleKey.Process: throw new NotImplementedException();
                case ConsoleKey.Q: return Key.Q;
                case ConsoleKey.R: return Key.R;
                case ConsoleKey.RightArrow: return Key.Right;
                case ConsoleKey.RightWindows: return Key.RightWindows;
                case ConsoleKey.S: return Key.S;
                case ConsoleKey.Select: throw new NotImplementedException();
                case ConsoleKey.Separator: throw new NotImplementedException();
                case ConsoleKey.Sleep: throw new NotImplementedException();
                case ConsoleKey.Spacebar: return Key.Spacebar;
                case ConsoleKey.Subtract: return Key.NumPadSubtract;
                case ConsoleKey.T: return Key.T;
                case ConsoleKey.Tab: return Key.Tab;
                case ConsoleKey.U: return Key.U;
                case ConsoleKey.UpArrow: return Key.Up;
                case ConsoleKey.V: return Key.V;
                case ConsoleKey.VolumeDown: throw new NotImplementedException();
                case ConsoleKey.VolumeMute: throw new NotImplementedException();
                case ConsoleKey.VolumeUp: throw new NotImplementedException();
                case ConsoleKey.W: return Key.W;
                case ConsoleKey.X: return Key.X;
                case ConsoleKey.Y: return Key.Y;
                case ConsoleKey.Z: return Key.Z;
                case ConsoleKey.Zoom: throw new NotImplementedException();

                default:
                    throw new NotSupportedException("Key not supported in cmd applications");
            }
        }
    }
}

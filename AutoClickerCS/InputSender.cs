using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace AutoClickerCS
{
    class InputSender
    {
        //Author: Bojidar Qnkov
        //Taken from from: https://www.codeproject.com/script/Articles/ViewDownloads.aspx?aid=5264831
        #region Imports/Structs/Enums
        [StructLayout(LayoutKind.Sequential)]
        public struct KeyboardInput
        {
            public ushort wVk;
            public ushort wScan;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MouseInput
        {
            public int dx;
            public int dy;
            public uint mouseData;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct HardwareInput
        {
            public uint uMsg;
            public ushort wParamL;
            public ushort wParamH;
        }

        [StructLayout(LayoutKind.Explicit)]
        public struct InputUnion
        {
            [FieldOffset(0)] public MouseInput mi;
            [FieldOffset(0)] public KeyboardInput ki;
            [FieldOffset(0)] public HardwareInput hi;
        }

        public struct Input
        {
            public int type;
            public InputUnion u;
        }

        [Flags]
        public enum InputType
        {
            Mouse = 0,
            Keyboard = 1,
            Hardware = 2
        }

        [Flags]
        public enum KeyEventF
        {
            KeyDown = 0x0000,
            ExtendedKey = 0x0001,
            KeyUp = 0x0002,
            Click,
            Unicode = 0x0004,
            Scancode = 0x0008
        }

        [Flags]
        public enum MouseEventF
        {
            //Absolute = 0x8000,
            SetPosition,
            Move = 0x0001,
            //MoveNoCoalesce = 0x2000,
            LeftDown = 0x0002,
            LeftUp = 0x0004,
            RightDown = 0x0008,
            RightUp = 0x0010,
            MiddleDown = 0x0020,
            MiddleUp = 0x0040,
            //VirtualDesk = 0x4000,
            //WheelScroll = 0x0800,
            //WheelTilt = 0x01000
            //XDown = 0x0080,
            //XUp = 0x0100
        }

        [Flags]
        public enum KeyType
        {
            KeyDown = 0x0000,
            //ExtendedKey = 0x0001, TODO
            KeyUp = 0x0002,
            Click
        }

        [Flags]
        public enum KeyboardKeys
        {
            ESC = 1,          
            Key1 = 2,
            Key2 = 3,
            Key3 = 4,
            Key4 = 5,
            Key5 = 6,
            Key6 = 7,
            Key7 = 8,
            Key8 = 9,
            Key9 = 10,
            Key0 = 11,
            MinusSign = 12,
            EqualSign = 13,
            BCKSP = 14,
            TAB = 15,
            q = 16,
            w = 17,
            e = 18,
            r = 19,
            t = 20,
            y = 21,
            u = 22,
            i = 23,
            o = 24,
            p = 25,
            OpenBracket = 26,
            CloseBracket = 27,
            Enter = 28,
            LCTRL = 29,
            a = 30,
            s = 31,
            d = 32,
            f = 33,
            g = 34,
            h = 35,
            j = 36,
            k = 37,
            l = 38,
            Semicolon = 39,
            Apostrophe = 40,
            BackwardApostrophe = 41,
            LSHIFT = 42,
            BackwardSlash = 43,
            z = 44,
            x = 45,
            c = 46,
            v = 47,
            b = 48,
            n = 49,
            m = 50,
            Comma = 51,
            Period = 52,
            ForwardSlash = 53,
            RSHIFT = 54,
            Asterisk = 55,
            LALT = 56,
            SPACE = 57,
            CAPS = 58,
            F1 = 59,
            F2 = 60,
            F3 = 61,
            F4 = 62,
            F5 = 63,
            F6 = 64,
            F7 = 65,
            F8 = 66,
            F9 = 67,
            F10 = 68,
            NUM = 69,
            SCR = 70,
            N7 = 71,
            N8 = 72,
            N9 = 73,
            NumMinus = 74,
            N4 = 75,
            N5 = 76,
            N6 = 77,
            NumPlus = 78,
            N1 = 79,
            N2 = 80,
            N3 = 81,
            N0  = 82,
            NDOT  = 83,
            F11 = 87,
            F12 = 88
        }

        [Flags]
        public enum SpecialKeyboardKeys
        {
            NEnter = 28,
            RCTRL = 29,
            NumMinus = 53,
            RALT = 56,
            HOME = 71,
            UP = 72,
            PGUP = 73,
            LEFT = 75,
            RIGHT = 77,
            END = 79,
            DOWN = 80,
            PGDN = 81,
            INS = 82,
            DEL = 83,
            LWIN = 91,
            RWIN = 92,
            APP = 93
        }

        [DllImport("user32.dll", SetLastError = true)]
        private static extern uint SendInput(uint nInputs, Input[] pInputs, int cbSize);

        [DllImport("user32.dll")]
        public static extern IntPtr GetMessageExtraInfo();

        [DllImport("user32.dll")]
        private static extern bool GetCursorPos(out POINT lpPoint);

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;
        }

        [DllImport("User32.dll")]
        private static extern bool SetCursorPos(int x, int y);
        #endregion

        #region Wrapper Methods
        public static POINT GetCursorPosition()
        {
            GetCursorPos(out POINT point);
            return point;
        }

        public static void SetCursorPosition(int x, int y)
        {
            SetCursorPos(x, y);
        }

        public static void SendKeyboardInput(KeyboardInput[] kbInputs)
        {
            Input[] inputs = new Input[kbInputs.Length];

            for (int i = 0; i < kbInputs.Length; i++)
            {
                inputs[i] = new Input
                {
                    type = (int)InputType.Keyboard,
                    u = new InputUnion
                    {
                        ki = kbInputs[i]
                    }
                };
            }

            SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(Input)));
        }

        public static void ClickKey(ushort scanCode)
        {
            var inputs = new KeyboardInput[]
            {
                new KeyboardInput
                {
                    wScan = scanCode,
                    dwFlags = (uint)(KeyEventF.KeyDown | KeyEventF.Scancode),
                    dwExtraInfo = GetMessageExtraInfo()
                },
                new KeyboardInput
                {
                    wScan = scanCode,
                    dwFlags = (uint)(KeyEventF.KeyUp | KeyEventF.Scancode),
                    dwExtraInfo = GetMessageExtraInfo()
                }
            };
            SendKeyboardInput(inputs);
        }

        public static void SendMouseInput(MouseInput[] mInputs)
        {
            Input[] inputs = new Input[mInputs.Length];

            for (int i = 0; i < mInputs.Length; i++)
            {
                inputs[i] = new Input
                {
                    type = (int)InputType.Mouse,
                    u = new InputUnion
                    {
                        mi = mInputs[i]
                    }
                };
            }

            SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(Input)));
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace AutoClickerCS
{
    class InputSender
    {
        //from: https://www.codeproject.com/script/Articles/ViewDownloads.aspx?aid=5264831
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
            //ExtendedKey = 0x0001, TODO
            KeyUp = 0x0002,
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
            WheelScroll = 0x0800,
            WheelTilt = 0x01000
            //XDown = 0x0080,
            //XUp = 0x0100
        }

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
            MinusSing = 12,
            EqualSign = 13,
            BackSpace = 14,
            Tab = 15,
            Q = 16,
            W = 17,
            E = 18,
            R = 19,
            T = 20,
            Y = 21,
            U = 22,
            I = 23,
            O = 24,
            P = 25,
            OpenBracket = 26,
            CloseBracket = 27,
            Enter = 28,
            CTRL = 29,
            A = 30,
            S = 31,
            D = 32,
            F = 33,
            G = 34,
            H = 35,
            J = 36,
            K = 37,
            L = 38,
            Semicolon = 39,
            Apostrophe = 40,
            BackwardApostrophe = 41,
            LShift = 42,
            BackwardSlash = 43,
            Z = 44,
            X = 45,
            C = 46,
            V = 47,
            B = 48,
            N = 49,
            M = 50,
            Comma = 51,
            Period = 52,
            ForwardSlash = 53,
            RShift = 54,
            PrtSc = 55,
            Alt = 56,
            Space = 57,
            Caps = 58,
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
            Num = 69,
            Scroll = 70,
            Num7 = 71,
            Num8 = 72,
            Num9 = 73,
            NumMinus = 74,
            Num4 = 75,
            Num5 = 76,
            Num6 = 77,
            NumPlus = 78,
            Num1 = 79,
            Num2 = 80,
            Num3 = 81,
            Ins  = 82,
            Del  = 83,
        }

        //TODO
        //public enum SpecialKeyboardKeys
        //{

        //}

        [DllImport("user32.dll", SetLastError = true)]
        private static extern uint SendInput(uint nInputs, Input[] pInputs, int cbSize);

        [DllImport("user32.dll")]
        private static extern IntPtr GetMessageExtraInfo();

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

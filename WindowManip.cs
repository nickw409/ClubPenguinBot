using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace ClubPenguinBot
{
    public class WindowManip
    {
        public const int TAB_WIDTH = 240;
        public const int TAB_HEIGHT = 12;
        public const int INPUT_MOUSE = 0;
        public const int MOUSEEVENTF_ABSOLUTE = 0x8000;
        public const int MOUSEEVENTF_MOVE = 0x0001;
        public const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        public const int MOUSEEVENTF_LEFTUP = 0x0004;
        public const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
        public const int MOUSEEVENTF_RIGHTUP = 0x0010;

        [DllImport("user32.dll", SetLastError = true)]
        private static extern uint SendInput(uint cInputs, Input[] inputs, int size);
        //[DllImport("user32.dll", SetLastError = true)]
        //private static extern bool GetCursorPos(out Point point);
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool SetCursorPos(int X, int Y);

        internal struct MouseInput
        {
            public int X;
            public int Y;
            public uint mouseData;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }
        internal struct Input
        {
            public int type;
            public MouseInput MouseInput;
        }

        public static void openTab(int tab)
        {
            int mouseX = 120 + (tab * TAB_WIDTH);
            mouseClick(mouseX, TAB_HEIGHT);
        }
        static void mouseClick(int mouseX, int mouseY)
        {
            Input[] inputs = new Input[2];

            SetCursorPos(mouseX, mouseY);
            System.Threading.Thread.Sleep(400);

            inputs[0] = new Input();
            inputs[0].type = INPUT_MOUSE;
            inputs[0].MouseInput.dwFlags = MOUSEEVENTF_LEFTDOWN;

            inputs[1] = new Input();
            inputs[1].type = INPUT_MOUSE;
            inputs[1].MouseInput.dwFlags = MOUSEEVENTF_LEFTUP;

            uint result = SendInput(2, inputs, Marshal.SizeOf(typeof(Input)));
            if (result == 0)
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
        }
        public static void moveLeft()
        {
            mouseClick(792, 978);
        }
        public static void moveRight()
        {
            mouseClick(954, 978);
        }
        public static void moveDown()
        {
            mouseClick(873, 1059);
        }
        public static void openActionMenu()
        {
            mouseClick(778, 1313);
        }
        public static void startMining()
        {
            mouseClick(772, 838);
        }
    }
}

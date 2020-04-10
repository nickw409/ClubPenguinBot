using System;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace ClubPenguinBot
{
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

    internal struct Point
    {
        public int x;
        public int y;
    }

    class Program
    {
        public const int INPUT_MOUSE = 0;
        public const int MOUSEEVENTF_ABSOLUTE = 0x8000;
        public const int MOUSEEVENTF_MOVE = 0x0001;
        public const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        public const int MOUSEEVENTF_LEFTUP = 0x0004;
        public const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
        public const int MOUSEEVENTF_RIGHTUP = 0x0010;

        [DllImport("user32.dll", SetLastError = true)]
        private static extern uint SendInput(uint cInputs, Input[] inputs, int size);
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool GetCursorPos(out Point point);
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool SetCursorPos(int X, int Y);
        static void Main(string[] args)
        {
            while (true)
            {
                moveLeft();
                System.Threading.Thread.Sleep(800);
                openActionMenu();
                System.Threading.Thread.Sleep(300);
                startMining();
                System.Threading.Thread.Sleep(13000);
                moveRight();
                System.Threading.Thread.Sleep(800);
                openActionMenu();
                System.Threading.Thread.Sleep(300);
                startMining();
                System.Threading.Thread.Sleep(13000);
            }

            //bool error = false;
            //Point p = new Point();
            
            //while (true)
            //{
            //    error = GetCursorPos(out p);
            //    Console.Write("{0}, {1}\n", p.x, p.y);
            //    System.Threading.Thread.Sleep(500);
            //}
        }

        static void moveLeft()
        {
            Input[] inputs = new Input[2];
            bool error = false;

            error = SetCursorPos(792, 978);

            inputs[0] = new Input();
            inputs[0].type = INPUT_MOUSE;
            inputs[0].MouseInput.X = 792;
            inputs[0].MouseInput.Y = 978;
            inputs[0].MouseInput.dwFlags = MOUSEEVENTF_LEFTDOWN;

            inputs[1] = new Input();
            inputs[1].type = INPUT_MOUSE;
            inputs[1].MouseInput.X = 792;
            inputs[1].MouseInput.Y = 978;
            inputs[1].MouseInput.dwFlags = MOUSEEVENTF_LEFTUP;
            
            uint result = SendInput(2, inputs, Marshal.SizeOf(typeof(Input)));
            if (result == 0)
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
        }

        static void moveRight()
        {
            Input[] inputs = new Input[2];
            bool error = false;

            error = SetCursorPos(954, 978);

            inputs[0] = new Input();
            inputs[0].type = INPUT_MOUSE;
            inputs[0].MouseInput.X = 954;
            inputs[0].MouseInput.Y = 978;
            inputs[0].MouseInput.dwFlags = MOUSEEVENTF_LEFTDOWN;

            inputs[1] = new Input();
            inputs[1].type = INPUT_MOUSE;
            inputs[1].MouseInput.X = 954;
            inputs[1].MouseInput.Y = 978;
            inputs[1].MouseInput.dwFlags = MOUSEEVENTF_LEFTUP;

            uint result = SendInput(2, inputs, Marshal.SizeOf(typeof(Input)));
            if (result == 0)
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
        }

        static void openActionMenu()
        {
            Input[] inputs = new Input[2];
            bool error = false;

            error = SetCursorPos(778, 1313);

            inputs[0] = new Input();
            inputs[0].type = INPUT_MOUSE;
            inputs[0].MouseInput.X = 778;
            inputs[0].MouseInput.Y = 1313;
            inputs[0].MouseInput.dwFlags = MOUSEEVENTF_LEFTDOWN;

            inputs[1] = new Input();
            inputs[1].type = INPUT_MOUSE;
            inputs[1].MouseInput.X = 778;
            inputs[1].MouseInput.Y = 1313;
            inputs[1].MouseInput.dwFlags = MOUSEEVENTF_LEFTUP;

            uint result = SendInput(2, inputs, Marshal.SizeOf(typeof(Input)));
            if (result == 0)
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
        }
        static void startMining()
        {
            Input[] inputs = new Input[2];
            bool error = false;

            error = SetCursorPos(772, 838);
            
            inputs[0] = new Input();
            inputs[0].type = INPUT_MOUSE;
            inputs[0].MouseInput.X = 772;
            inputs[0].MouseInput.Y = 838;
            inputs[0].MouseInput.dwFlags = MOUSEEVENTF_LEFTDOWN;

            inputs[1] = new Input();
            inputs[1].type = INPUT_MOUSE;
            inputs[1].MouseInput.X = 772;
            inputs[1].MouseInput.Y = 838;
            inputs[1].MouseInput.dwFlags = MOUSEEVENTF_LEFTUP;

            uint result = SendInput(2, inputs, Marshal.SizeOf(typeof(Input)));
            if (result == 0)
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
        }
    }
}

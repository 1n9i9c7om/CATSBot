using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CATSBot.Helper
{
    //Thanks to Antonio Bakula from StackOverflow: http://stackoverflow.com/a/10355905
    public class ClickOnPointTool
    {
        public enum MouseEventType : int
        {
            LeftDown = 0x02,
            LeftUp = 0x04,
            RightDown = 0x08,
            RightUp = 0x10
        }

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);


        [DllImport("user32.dll")]
        public static extern void mouse_event
            (MouseEventType dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);
        [DllImport("user32")]
        public static extern int SetCursorPos(int x, int y);


        [DllImport("user32.dll")]
        public static extern bool ClientToScreen(IntPtr hWnd, ref Point lpPoint);

        [DllImport("user32.dll")]
        internal static extern uint SendInput(uint nInputs, [MarshalAs(UnmanagedType.LPArray), In] INPUT[] pInputs, int cbSize);

#pragma warning disable 649
        internal struct INPUT
        {
            public UInt32 Type;
            public MOUSEKEYBDHARDWAREINPUT Data;
        }

        [StructLayout(LayoutKind.Explicit)]
        internal struct MOUSEKEYBDHARDWAREINPUT
        {
            [FieldOffset(0)]
            public MOUSEINPUT Mouse;
        }

        internal struct MOUSEINPUT
        {
            public Int32 X;
            public Int32 Y;
            public UInt32 MouseData;
            public UInt32 Flags;
            public UInt32 Time;
            public IntPtr ExtraInfo;
        }

#pragma warning restore 649

        public static void ResizeWindow(IntPtr wndHandle, int x, int y)
        {
            Point windowPos = new Point(0,0);
            ClientToScreen(wndHandle, ref windowPos);

            MoveWindow(wndHandle, windowPos.X, windowPos.Y, x, y, true);
        }
        public static void ClickOnPoint(IntPtr wndHandle, Point clientPoint)
        {
            /* Point oldPos = Cursor.Position;

            /// get screen coordinates
            ClientToScreen(wndHandle, ref clientPoint);

            /// set cursor on coords, and press mouse
            Cursor.Position = new Point(clientPoint.X, clientPoint.Y);

            INPUT inputMouseDown = new INPUT();
            inputMouseDown.Type = 0; /// input type mouse
            inputMouseDown.Data.Mouse.Flags = 0x0002; /// left button down

            INPUT inputMouseUp = new INPUT();
            inputMouseUp.Type = 0; /// input type mouse
            inputMouseUp.Data.Mouse.Flags = 0x0004; /// left button up

            INPUT[] inputs = new INPUT[] { inputMouseDown, inputMouseUp };
            SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(INPUT)));

            /// return mouse 
            Cursor.Position = oldPos; */

            ADBHelper.simulateClick(clientPoint.X, clientPoint.Y);
        }

        /* public static void ClickOnPoint(IntPtr wndHandle, Point clientPoint)
        {
            Point oldPos = Cursor.Position;
            ClientToScreen(wndHandle, ref clientPoint);
            SetCursorPos(clientPoint.X, clientPoint.Y);
            mouse_event(MouseEventType.LeftDown, Cursor.Position.X, Cursor.Position.Y, 0, 0);
            mouse_event(MouseEventType.LeftUp, Cursor.Position.X, Cursor.Position.Y, 0, 0);
            SetCursorPos(oldPos.X, oldPos.Y);
        } */

        public static Point GetPosition(IntPtr wndHandle, Point clientPoint)
        {
            ClientToScreen(wndHandle, ref clientPoint);
            return clientPoint;
        }
    }
}

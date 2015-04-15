using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
//http://aim400kg.ru/pr/top/ g1407326
namespace AutoClicker
{
    public partial class FormClicker : Form
    {
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;
        private static Thread AutoClick;
        private static Thread Autocolor;
        private static Thread MyClickT;
        public static int WM_HOTKEY = 0x312;
        private int _amount = 2;
        private int miliSecToClick = 120;
        private int miliSecToColor = 0;
        private bool _left = true;
        private const float ColorAccuracy = 10;
        private Point SetPosition;
        private Color newcolor = Color.Transparent;
        private Color oldcolor = Color.Transparent;
        private Color ignoreColor = Color.Transparent;
        public FormClicker()
        {
            InitializeComponent();
        }

        private Point CurrentPosition { get; set; }

        [DllImport("user32.dll")]
        public static extern void mouse_event(long dwFlags, long dx, long dy, long cButtons, long dwExtraInfo);

        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        public void MyClick()
        {
            Thread.Sleep(miliSecToClick);
            if (_left)
            {
                for (var i = 0; i < _amount; i++)
                {
                    CurrentPosition = Cursor.Position;
                    mouse_event(MOUSEEVENTF_LEFTDOWN, CurrentPosition.X, CurrentPosition.Y, 0, 0);
                    mouse_event(MOUSEEVENTF_LEFTUP, CurrentPosition.X, CurrentPosition.Y, 0, 0);                    
                }
            }
            else
            {
                for (var i = 0; i < _amount; i++)
                {
                    CurrentPosition = Cursor.Position;
                    mouse_event(MOUSEEVENTF_RIGHTDOWN, CurrentPosition.X, CurrentPosition.Y, 0, 0);
                    mouse_event(MOUSEEVENTF_RIGHTUP, CurrentPosition.X, CurrentPosition.Y, 0, 0);
              }
            }
        }

        private void SetCursorPosition(Point point)
        {
            Cursor.Position = point;
        }

        bool ColorsEquals(Color a, Color b)
        {
            float HueDiff = Math.Abs(a.GetHue() - b.GetHue());//[0;360]
            float SaturationDiff = Math.Abs(a.GetSaturation() - b.GetSaturation());//[0;1]
            float BrightnessDiff = Math.Abs(a.GetBrightness() - b.GetBrightness());
            //[0;10]   [350;360]
            return  ((HueDiff<ColorAccuracy)||(HueDiff>360-ColorAccuracy))
                && (BoxBright.Checked ? (BrightnessDiff < 1 / ColorAccuracy) : true);
            
        }
        
                
        public void Acolor()
        {
            MyClickT = new Thread(MyClick);

            MyClickT.IsBackground = true;
            while (true)
            {
                CurrentPosition = Cursor.Position;
                oldcolor = newcolor;
                newcolor = GetPixelColor(CurrentPosition.X, CurrentPosition.Y);
                ignoreColor = Color.FromName(ignoreColorBox.Text);
                float hueIg = ignoreColor.GetHue();
                MethodInvoker inv = delegate
                {
                    labelC.Text = GetColorName(newcolor) + " " + (oldcolor.GetHue() - newcolor.GetHue()) + " " + ignoreColor.GetHue(); 
                    labelC.Text =  " " + newcolor.GetHue(); 
                    
                    labelC.ForeColor = newcolor;
                };
                
                try
                {
                    Invoke(inv);
                }
                catch (Exception)
                {
                    throw;
                }
                if (ColorsEquals(oldcolor, newcolor) || ColorsEquals(newcolor, ignoreColor) ||
                    oldcolor.Equals(Color.Transparent) || newcolor.Equals(Color.Transparent)) continue;
                if (!MyClickT.IsAlive)
                {
                    MyClickT = new Thread(MyClick);
                    MyClickT.Start();
                   Thread.Sleep(miliSecToColor);
                }
            }
        }

        public static void ColorToHSV(Color color, out double hue, out double saturation, out double value)
        {
            int max = Math.Max(color.R, Math.Max(color.G, color.B));
            int min = Math.Min(color.R, Math.Min(color.G, color.B));

            hue = color.GetHue();
            saturation = (max == 0) ? 0 : 1d - (1d * min / max);
            value = max / 255d;
        }

        private string GetColorName(Color color)
        {
            var colorProperties = typeof (Color)
                .GetProperties(BindingFlags.Public | BindingFlags.Static)
                .Where(p => p.PropertyType == typeof (Color));
            foreach (var colorProperty in colorProperties)
            {
                var colorPropertyValue = (Color) colorProperty.GetValue(null, null);
                if ((Math.Abs(colorPropertyValue.R - color.R) < 20)
                    && (Math.Abs(colorPropertyValue.G - color.G) < 20)
                    && (Math.Abs(colorPropertyValue.B - color.B) < 20))
                {
                    return colorPropertyValue.Name;
                }
            }

            //If unknown color, fallback to the hex value
            //(or you could return null, "Unkown" or whatever you want)
            return ColorTranslator.ToHtml(color);
        }

        [DllImport("user32.dll")]
        private static extern IntPtr GetDC(IntPtr hwnd);

        [DllImport("user32.dll")]
        private static extern Int32 ReleaseDC(IntPtr hwnd, IntPtr hdc);

        [DllImport("gdi32.dll")]
        private static extern uint GetPixel(IntPtr hdc, int nXPos, int nYPos);

        public static Color GetPixelColor(int x, int y)
        {
            var hdc = GetDC(IntPtr.Zero);
            var pixel = GetPixel(hdc, x, y);
            ReleaseDC(IntPtr.Zero, hdc);
            var color = Color.FromArgb((int) (pixel & 0x000000FF),
                (int) (pixel & 0x0000FF00) >> 8,
                (int) (pixel & 0x00FF0000) >> 16);
            return color;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RegisterHotKey(Handle, (int) Keys.F1, 0, (uint) Keys.F1);
            Autocolor = new Thread(Acolor);
            Autocolor.IsBackground = true;

        }

        private void Form1_Close(object sender, EventArgs e)
        {
            MyClickT.Abort();
            Autocolor.Abort();
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_HOTKEY)
            {

                try
                {
                    _amount = int.Parse(numericUpDown1.Text);
                    _left = !rightBox.Checked;
                    ignoreColor = Color.FromName(ignoreColorBox.Text);
                   ignoreColorBox.ForeColor = ignoreColor;
                    miliSecToColor = (int)numSecToColor.Value;
                    miliSecToClick = (int) numSecToClick.Value;
                }
                catch
                {
                    _amount = 1;
                }
                var key = (Keys) (((int) m.LParam >> 16) & 0xFFFF);
                if (key == Keys.F1)
                {
                    if (!Autocolor.IsAlive)
                    {
                        Autocolor.Start();
                        lstate.Text = "Analyzing";
                        lstate.ForeColor = Color.Green;

                        Controls.Add(lstate);
                    }
                    else
                    {
                        newcolor = Color.Transparent;
                        oldcolor = Color.Transparent;
                        Autocolor.Abort();
                        Autocolor = new Thread(Acolor);
                        lstate.Text = "Not Clicking";
                        lstate.ForeColor = Color.Red;
                        Controls.Add(lstate);
                    }
                }
            }


        }

        private void labelignorecolor_Click(object sender, EventArgs e)
        {

        }

        private void labelC_Click(object sender, EventArgs e)
        {

        }
    }
}
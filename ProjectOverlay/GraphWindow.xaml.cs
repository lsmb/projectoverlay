using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProjectOverlay
{
    /// <summary>
    /// Interaction logic for GraphWindow.xaml
    /// </summary>
    public partial class GraphWindow : Window
    {
        private BackgroundWorker pingBw = new BackgroundWorker();
        private bool pingCheck = true;
        public GraphWindow()
        {
            ShowInTaskbar = false;
            InitializeComponent();
            pingBw.DoWork += pingBw_DoWork;
            pingBw.RunWorkerCompleted += pingBw_RunWorkerCompleted;
            pingBw.RunWorkerAsync();
        }

        private void pingBw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void pingBw_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            while (pingCheck)
            {
                string ping1;
                string ping2;
                System.Threading.Thread.Sleep(500);
                using (Ping p = new Ping())
                {
                    ping1 = p.Send("riot.de").RoundtripTime + "ms"; ;
                    ping2 = p.Send("google.fr").RoundtripTime + "ms"; ;
                }
                Dispatcher.BeginInvoke((Action)delegate()
                {
                    pingLabel.Text = "Ping: " + ping1;
                    ping2Label.Text = "Ping: " + ping2;
                });
            }
        }
        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            var hwnd = new WindowInteropHelper(this).Handle;
            WindowsServices.SetWindowExTransparent(hwnd);
        }
        public static class WindowsServices
        {
            const int WS_EX_TRANSPARENT = 0x00000020;
            const int GWL_EXSTYLE = (-20);

            [DllImport("user32.dll")]
            static extern int GetWindowLong(IntPtr hwnd, int index);

            [DllImport("user32.dll")]
            static extern int SetWindowLong(IntPtr hwnd, int index, int newStyle);

            public static void SetWindowExTransparent(IntPtr hwnd)
            {
                var extendedStyle = GetWindowLong(hwnd, GWL_EXSTYLE);
                SetWindowLong(hwnd, GWL_EXSTYLE, extendedStyle | WS_EX_TRANSPARENT);
            }
        }

    }
}

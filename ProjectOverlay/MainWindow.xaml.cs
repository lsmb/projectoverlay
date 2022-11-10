using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjectOverlay
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GraphWindow graphWindow = new GraphWindow();
        public MainWindow()
        {
            InitializeComponent();
            graphWindow.Show();
            graphWindow.WindowStartupLocation = WindowStartupLocation.Manual;
            graphWindow.Top = 0;
            graphWindow.Left = SystemParameters.PrimaryScreenWidth - graphWindow.Width;
        }
    }
}

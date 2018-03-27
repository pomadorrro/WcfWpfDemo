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
using System.Windows.Shapes;

namespace FatClient
{
    /// <summary>
    /// Логика взаимодействия для PopupWindow.xaml
    /// </summary>
    public partial class PopupWindow : Window
    {
        MainWindow ParentWindow { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mainWindow">parent window</param>
        public PopupWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            ParentWindow = mainWindow;
        }        

        /// <summary>
        /// Send message to the parent window to make button enabled.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnPopupWindowClosed(object sender, EventArgs e)
        {
            ParentWindow.SetButtonEnabled(ParentWindow.ConnectButton, true);
        }
    }
}

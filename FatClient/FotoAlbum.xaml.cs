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
using FatClient.ViewModel;

namespace FatClient
{
    /// <summary>
    /// Логика взаимодействия для FotoAlbum.xaml
    /// </summary>
    public partial class FotoAlbum : Window
    {
        public FotoAlbum()
        {
            InitializeComponent();
            DataContext = new FotoCardTagViewModel();
        }
    }
}

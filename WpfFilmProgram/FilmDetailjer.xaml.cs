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

namespace WpfFilmProgram
{
    /// <summary>
    /// Interaction logic for FilmDetailjer.xaml
    /// </summary>
    public partial class FilmDetailjer : Window
    {
        public FilmDetailjer()
        {
            InitializeComponent();  //intialisere
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();    //skjuler detailjer form 
            MainWindow screen = new MainWindow();
            screen.Show();      //viser Main window form
        }
    }
}

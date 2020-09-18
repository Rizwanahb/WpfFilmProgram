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
    /// Interaction logic for Redigerfilm.xaml
    /// </summary>
    public partial class Redigerfilm : Window   // instantier field til Film entites i WPFfilmprogram class
    {
        FilmEntities _db = new FilmEntities();
        int ID;
        public Redigerfilm(int Film_ID)
        {
            InitializeComponent();
            ID = Film_ID;       //tildeler værdi af funktion parameter til ID

        }

        private void Button_Gem_Click(object sender, RoutedEventArgs e)
        {
            Film_Nomineringer editfilm = (from f in _db.Film_Nomineringer //matcher ID til film_ID fra database og gemmer værdi til editfilm variabel
                                          where f.Film_ID == ID
                                      select f).Single();

            //tildeler textbox værdier til og sætter nye værdier til Film_Nomineringer fields ved at bruge get;set;
            editfilm.Titel = txttitelupdate.Text;
            editfilm.Instruktør = txtinstruktørupdate.Text;
            editfilm.Genre = cboxGenreupdate.Text;
            editfilm.Årstal = Convert.ToDateTime(datepickerupdate.Text);
            //opdatere database og film nomineringer list
            _db.SaveChanges();
            MainWindow.datagrid.ItemsSource = _db.Film_Nomineringer .ToList();
            this.Hide();    //skjuler Rediger form            
        }

        private void Button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();    //aflyser data og skjuler form
        }
    }
}

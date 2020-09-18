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
    /// Interaction logic for Opretfilm.xaml
    /// </summary>
    public partial class Opretfilm : Window
    {
        FilmEntities _db = new FilmEntities();         // instantier field til Film entites i WPFfilmprogram class
        public Opretfilm()
        {
            InitializeComponent();

        }

        private void Button_Gem_Click(object sender, RoutedEventArgs e)
        {
            Film_Nomineringer newFilm = new Film_Nomineringer()             //instantier variabel newfilm til Film_Nomineringer tabel i db
            {
                //tildeler textbox værdier til Film_Nomineringer fields ved at bruge get;set;
                Film_ID = Convert.ToInt32(txtfilmid.Text),
                Titel = txttitel1.Text,
                Instruktør = txtinstruktør.Text,
                Genre = cboxGenre.Text,
                Årstal = Convert.ToDateTime(datepicker.Text)

            };

            _db.Film_Nomineringer.Add(newFilm);     //tilføj new rekord til Film_Nomineringer
            //opdatere database og film nomineringer list
            _db.SaveChanges();
            MainWindow.datagrid.ItemsSource = _db.Film_Nomineringer .ToList();
            this.Hide();     //skjuler dialog
            

        }

        private void Button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();  //aflyser data og skjuler form
        }
    }
}

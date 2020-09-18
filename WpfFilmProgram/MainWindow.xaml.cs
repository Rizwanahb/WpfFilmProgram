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

namespace WpfFilmProgram
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //erklæring af variabler

        FilmEntities _db = new FilmEntities();
        public static DataGrid datagrid;
        public MainWindow()
        {
            InitializeComponent();
            Load();

        }
        private void Load()
        {
            MyDataGrid.ItemsSource = _db.Film_Nomineringer.ToList(); /*\\tildeler film_nomineringer list til MyDataGrid itemsource*/
            datagrid = MyDataGrid;   //tildeler MYDatagrid data til datagrid variabel
        }

        private void MyDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Opretfilm opret = new Opretfilm();     //hvis opret knap er trykket så kalder opretfilm method             
            opret.ShowDialog();                     //viser Opret window
        }

        private void RedigerBtn_Click(object sender, RoutedEventArgs e)
        {
            int Film_ID = (MyDataGrid.SelectedItem as Film_Nomineringer).Film_ID;   //tilder værdi af selected Film id til Film_ID variabel

            Redigerfilm rediger = new Redigerfilm(Film_ID);         // kalder Redigerfilm metode med parameter Film_ID
            rediger.ShowDialog(); //viser Rediger dialog
        }

        private void SletBtn_Click(object sender, RoutedEventArgs e)
        {
            //når bruger trykker på slet knappen så kommer der en message box med besked
            MessageBoxResult result= MessageBox.Show("Er du sikker på,at du vil slette denne film oplysninger?","Slet Film",MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)     //hvis Yes knap bliver trykket
            {

                int ID = (MyDataGrid.SelectedItem as Film_Nomineringer).Film_ID;    //tilder værdi af selected Film id til ID variabel

                var sletfilm = _db.Film_Nomineringer.Where(f => f.Film_ID == ID).Single(); //matcher ID til film_ID fra database og gemmer værdi til sletfilm variabel
                _db.Film_Nomineringer.Remove(sletfilm);                      //Remove() er brugt til at slette current film

                //opdatere database og film nominering list
                _db.SaveChanges();                                          
                MyDataGrid.ItemsSource = _db.Film_Nomineringer.ToList();
            }
           

        }

        private void DetailjeBtn_Click(object sender, RoutedEventArgs e)
        {
            FilmDetailjer detailjer = new FilmDetailjer();
            detailjer.ShowDialog();                 //viser dialog til detailjer
            this.Hide();                            //skjuler main window
        }
    }
}
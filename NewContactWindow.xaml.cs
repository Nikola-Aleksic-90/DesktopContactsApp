using DesktopContactsApp.Classes;
using SQLite;
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

namespace DesktopContactsApp
{
    /// <summary>
    /// Interaction logic for NewContactWindow.xaml
    /// </summary>
    public partial class NewContactWindow : Window
    {
        public NewContactWindow()
        {
            InitializeComponent();

            Owner = Application.Current.MainWindow;
            WindowStartupLocation= WindowStartupLocation.CenterOwner;
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {

            // ovako je preglednije
            Contact contact = new Contact()
            {
                Name = nameTextBox.Text,
                Email = emailTextBox.Text,
                Phone = phoneNumberTextBox.Text,
            };

            // prethodni kod se moze odraditi i kao:
            /*
                Contact contact = new Contact();
                contact.Name = nameTextBox.Text;
                contact.Email = emailTextBox.Text;
                contact.Phone = phoneNumberTextBox.Text;
            */

            

            // ovako je preglednije
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Contact>();
                connection.Insert(contact);
            }

            // prethodni kod se moze odraditi i kao:
            /*
                SQLiteConnection connection = new SQLiteConnection(databasePath);
                connection.CreateTable<Contact>();
                connection.Insert(contact);
                connection.Close;
            */

            /*
             * Uvek je potrebno zatvoriti konekciju sa SQL-om jer kada se 
             * pokrene sledeci put mozda nece raditi, tj. cdoci ce do crash-a
            */

            /* ako koristimo postojeci kod "using ( SQLite..." onda ce se automatski kreirati konekcija
             * i zatvoriti na kraju izvrsenja metode. Mozemo je izvrsiti i X puta, svaki put ce kreirati objekat connection, 
             * odradice se blok koda (u viticastim zagradama) i zatvoriti konekciju
             * To vidimo ako odemo u Definition za SQLiteConnection i vidimo da se primenjuje IDisposable Interface
             * Kada se izadje iz bloka koda pokrece se public void Dispose(); metoda, kao sto se vidi u Definition
             * Dakle, efektivno, automatski se kreira konekcija i prekida na elegantniji nacin.
            */ 


            this.Close();
        }

    }
}

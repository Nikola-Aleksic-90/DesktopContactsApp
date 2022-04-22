using DesktopContactsApp.Classes;
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

namespace DesktopContactsApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Contact> contacts;

        public MainWindow()
        {
            InitializeComponent();

            contacts = new List<Contact>();

            // kada otvorimo aplikaciju zelimo da nam prikaze
            ReadDatabase();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NewContactWindow newContactWindow = new NewContactWindow();
            newContactWindow.ShowDialog();

            ReadDatabase();
            // kada se prozor NewContactWindow zatvori zelimo da ponovo ucitamo, tj. osvezimo listu kontakta
        }

        void ReadDatabase()
        {
            
            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Contact>();
                contacts = connection.Table<Contact>().ToList().OrderBy(c => c.Name).ToList();
                // ToList() nam je potreban jer bez toga varijabla contacts prima query tip podatka, koji ne mozemo da pristupimo
                // OrderBy metoda po Name-u ce sloziti imena kontakta po abecedi
                
            }

            if (contacts != null)
            {
                contactsListView.ItemsSource = contacts;
            }
        }

        // Event Handeler kojim unosom u TextBox u Main Window filtriramo i prikazujemo samo kontakte koje zelimo
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox searchTextBox = sender as TextBox;

            var filteredList = contacts.Where(c => c.Name.ToLower().Contains(searchTextBox.Text.ToLower())).ToList();

            /*
             * Ovo radi isto kao i naredba iznad
             * 
            var filteredList = (from c in contacts
                                where c.Name.ToLower().Contains(searchTextBox.Text.ToLower())
                                orderby c.Name
                                select c).ToList();
            */

            contactsListView.ItemsSource = filteredList;
        }

        private void contactsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Contact selectedContact = (Contact)contactsListView.SelectedItem;

            if(selectedContact != null)
            {
                ContactDetailsWindow contactDetailsWindow = new ContactDetailsWindow(selectedContact);
                contactDetailsWindow.ShowDialog();

                ReadDatabase();
            }
        }
    }
}

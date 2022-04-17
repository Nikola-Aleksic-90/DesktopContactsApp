using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopContactsApp.Classes
{
    public class Contact
    {

        // ako ukucamo prop i dva puta pritisnemo tab sam ce kreirati property (geter i seter)
        
        // [PrimaryKey , AutoIncrement] SQlite atribut se odnose na prvi sledeci property, u ovom slucaju Id
        // nakon kucanja [PrimaryKey potrebno je odraditi CTRL + . i ubaciti " using SQlite "
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

    }
}

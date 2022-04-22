Moja druga C# WPF aplikacija. 

Ovo je samo kratki program koji od korisnika trazi unos podataka :
- Ime
- Email
- Telefon
i unosi ih u bazu podataka. 

Sastoji se od veoma osnovnog XAML frontend-a i osnova C#
U odnosu na prvu C# aplikaciju, ovde je i prikazan osnovni rad sa bazama podataka. S obzirom da je zamisljena kao desktop aplikacija za jednog korisnika primenjen je lokalni SQL database. Za bazu podataka koriscen je SQLite koji je ubacen kao NuGet paket. U sledecoj verziji dodace se i ListView  C# kako bi korisnik video koje kontakte je uneo (oni kontakti koji se nalaze u bazi).

22.4.2022
Dodat je i ListView da se vidi koji kontakti su do sada dodati.
Dodat je TextBox za pretragu postojecih kontakta (iznad ListView)
Primenjen je Data Binding, tj. veza izmedju objekata u C# i XAML. 
Koriscen je LINQ
Dodata je opcija da se neki kontakti izmene i izbrisu iz SQL
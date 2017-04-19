using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeDatabase
{
    class Program
    {
        static void Main(string[] args)
        {

            int start = 1;
            if (start == 1)
            {
                AutomaticRemoveFromDatabase Run = new AutomaticRemoveFromDatabase();
                Run.FindOutdateFolder();
            }
            else
            {
                ChangeDatabase Run = new ChangeDatabase();
                Run.AddArticle();
                Run.RemoveArticle();
            }


        }
    }
}

/*
 Ændre database.
Fjern automatisk gammelt indhold.
Slet manuelt artikler i database. (I stedet for at slette disse, kan de evt. blive rykket i en trashbin mappe)
Tilføj artikel (som txt fil)
Efter kontrol af fake, skal brugeren have mulighed for at tilføje en artikel til databasen.


Klasse:
ChangeDatabase
Skal måske arve fra en metode som finder alle artikler i database

Metoder:
En metode som står for at fjerne en artikel.
RemoveArticle(input){}

En metode som står for at tilføje en artikel.
AddArticle(input){} - dd_mm_yy







Hvornår skal brugeren kunne ændre i database?
start og efter kontrol af Fake News.
start: Brugeren får muligheden for at "ændre i database", hvorefter personen kan fjerne eller tilføje artikel. 
(Personligt vil jeg kun sige fjern her, da vi har brug for at vide artikels angivelse af Fake først.)

Slut: Brugeren kan vælge at tilføje den kontrollerede artikel.
     
     */

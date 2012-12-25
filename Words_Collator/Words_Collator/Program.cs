using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Words_Collator
{
    class Program
    {
        static void Main(string[] args)
        {
            int wynik;
            WordsCollator ziom = new WordsCollator();
            ziom.setWords("dobra", "dobre"); //potestuj na czym chcesz
            wynik = ziom.GetCollation();
            System.Console.WriteLine(wynik);
            System.Console.ReadKey();//czeka na dowolny klawisz, bez entera
            /*chciałbym, abyś to zmodyfikował, żeby wczytywał od użytkownika słowo, a potem n słów
             * (n ustala użytkownik, albo tak długo jak komenda "-quit") i porównywał do pierwszego.
             * Niech użytkownik ma możliwość zmienienia pierwszego słowa komendą "-zmien"
             * (pamietaj, ze komendy nie licza sie do podanych słów)
             * dzięki temu prostemu ćwiczeniu nauczysz się trochę c# :D */
        }
    }
}

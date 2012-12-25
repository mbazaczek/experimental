using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Words_Collator
{
    class WordsCollator
    {
        String word1 = String.Empty; //dlaczego String.Empty? dla bezpieczeństwa
        String word2 = String.Empty;
        String chars11 = String.Empty;//do tych dwóch stringów wrzucę litery,
        String chars21 = String.Empty;//które są różne, bądź zamienione miejscami
        public void setWord1(String word1)
        {
            this.word1 = word1;
        }// to dla zmiany tylko jednego
        public void setWord2(String word2)
        {
            this.word2 = word2;
        }// jw.
        public void setWords(String word1, String word2)
        {
            this.word1 = word1;
            this.word2 = word2;
        } // to dla możliwości dania 2 słów na raz
        public String getWord1()
        {
            return this.word1;
        } 
        public String getWord2()
        {
            return this.word2;
        }
        public int GetCollation()
        {
            int wordsDiff;
            int charsDiff = 0; //=0, bo inkrementujemy później, nie chcemy losowej wartości
            int wordsLength;
            this.word1.ToLower();//by różnice w wielkości nie przeszkadzały
            this.word2.ToLower();//jw.
            if (this.word1.Length >= this.word2.Length)
            {
                wordsDiff = this.word1.Length - this.word2.Length;
                for (int i = 0; i < wordsDiff; i++)
                {
                    this.word2 += "~";
                }
            }
            else if (this.word1.Length <= this.word2.Length)
            {
                wordsDiff = this.word2.Length - this.word1.Length;
                for (int i = 0; i < wordsDiff; i++)
                {
                    this.word1 += "~";
                }
            }//uzupełniam arbitralnymi znakami słowo, jeśli jest za krótkie
            wordsLength=this.word1.Length;//zapisuję długość słowa, nieważne które, obydwa obecnie mają tą samą
            for (int j = 0; j < wordsLength; j++)
            {
                if (this.word1[j] != this.word2[j])
                {
                    chars11 += this.word1[j];//wpisuję "błędne" znaki
                    chars21 += this.word2[j];//jw.
                }

            }
            
            char[] c1 = chars11.ToCharArray();
            Array.Sort(c1);
            String chars12 = String.Empty;
            foreach (char c in c1)
                chars12 += c;//skomplikowane sortowanie stringów. Internety :D
            char[] c2 = chars21.ToCharArray();
            Array.Sort(c2);
            String chars22 = String.Empty;
            foreach (char c in c2)
                chars22 += c;
            
            for (int i = 0; i < chars11.Length; i++)
            {
                if (chars12[i] != chars22[i])
                {
                    charsDiff++;//zwiększam współczynnik rożnicy
                }
            }
            return (((wordsLength - charsDiff)* 100) / wordsLength ); //prosty wzór, *100 wpierw by uniknąć zaokrągleń
        }
    }
}

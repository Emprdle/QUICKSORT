using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace _2Emrle
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch time = new Stopwatch();              
            Console.WriteLine("Zadejte hodnotu objemu: (v cm)");
            float V = float.Parse(Console.ReadLine());                        //Proměnná, do které zapisujeme objem.
            float minPovrch = int.MaxValue;                                   //Proměnná obsahující stávající nejvyšší hodotu.

            time.Start();                                                     //Start stopwatche.
            for (float A = 1; A < V / 2; A++)                                 //Dosazování A
            {
                for(float B = 1; B < V / A; B++)                              //Dosazování B
                {
                    float C = ((V / A) / B);                                  //výpočet strany C ze vzorečku objemu
                    float povrch = 2 * ((A * B) + (B * C) + (A * C));         //Výpočet povrchu kvádru.
                    
                    if(minPovrch > povrch)                                    //Do proměnné minPovrch se zapisuje největší povrch v dané chvíli, a když
                    {                                                         //je větší než proměnná povrch, tak proměnná povrch zapíše do minPovrch.
                        minPovrch = povrch;                                   //Opakuje se do té chvíle, dokud neprojdeme všechny čísla.
                    }
                }
            }
            time.Stop();                                                      //Stop Stopwatche.
            Console.WriteLine("Hodnota minimálního Povrchu: ");
            Console.WriteLine((minPovrch + " (cm^2)"));                       //Zobrazení vypočítaného povrchu
            Console.WriteLine("čas výpočtu: " );
            Console.WriteLine( time.Elapsed.TotalMilliseconds * 1000000 + " (ns)");   //Zobrazení délky výpočtu v nanosekundách.
            Console.ReadLine();

        }
    }
}

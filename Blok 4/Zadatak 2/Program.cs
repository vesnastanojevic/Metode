using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Zadatak_2
{
    public enum Boja { crvena=1, plava, zelena };
    public struct Tacka
    {
        public int x;
        public int y;
        public Boja boja;

        public Tacka(int x, int y, Boja boja)
        {
            this.x = x;
            this.y = y;
            this.boja = boja;
        }

        public override string ToString()
        {
            return "Tacka  ( " + x + " , " + y + " ), boja = " + boja;
        }
    }

    public struct Krug
    {
        public Tacka centar;
        public double poluprecnik;

        public Krug(Tacka centar, double poluprecnik)
        {
            this.centar = centar;
            this.poluprecnik = poluprecnik;
        }

        public override string ToString()
        {
            return "Krug : centar = " + centar + ",   poluprecnik = " + poluprecnik;
        }
        public double Povrsina()
        {
            double p;
            p = poluprecnik * poluprecnik * Math.PI;
            return p;
        }
    }
    

    class Program
    {
        public static void Meni()
        {
            Console.WriteLine("\n1. Transformacija broja po uslovu zadatka");
            Console.WriteLine("\n2. Poredjenje povrsine dva kruga");
            Console.WriteLine("\n3. Formiranje niza po uslovu zadatka");
            Console.WriteLine("\n4. Kraj programa");
        }
        static string Ucitaj()
        {
            return ReadLine();
        }
        public static void Ucitaj(out Tacka t)
        {
            Console.WriteLine("Ucitaj koordinatu x:");
            t.x = Convert.ToInt32(ReadLine());
            Console.WriteLine("Ucitaj koordinatu y:");
            t.y= Convert.ToInt32(ReadLine());
            Console.WriteLine("Ucitaj boju tacke: 1 (crvena), 2 (plava), 3 (zelena)");
            t.boja = (Boja)Enum.Parse(typeof(Boja), ReadLine());

        }
        public static void ObradaNiza()
        {
            ArrayList niz = new ArrayList();
            int broj, min, max, brmin = 0, brmax = 0;
            do
            {
                Console.WriteLine("Ucitaj novi broj:"); 
                broj = Convert.ToInt32(Ucitaj());
                if (broj != 0)
                    niz.Add(broj);
            } while (broj != 0);

            int[] pomoc = (int[])niz.ToArray(typeof(int));
            min = pomoc.Min();
            max = pomoc.Max();
            for(int i = 0; i < pomoc.Length; i++)
            {
                if (min == pomoc[i])
                    brmin++;
                else
                    if (max == pomoc[i])
                        brmax++;
            }
            WriteLine("Max = " + max + " Br.max = " + brmax + " Min = " + min + " Br.min = " + brmin);
        }
        public static void Test(ref bool kraj, int cif, int broj)
        {
            string niz = Convert.ToString(broj);
            int a = Convert.ToInt32(niz[0]-'0');
            int b = Convert.ToInt32(niz[niz.Length - 1]-'0');
            if (a == cif && b == cif)
                kraj = false;
        }
        public static void ObradaBrojeva()
        {
            int broj, cif;
            int min, max;
            int brmin = 1, brmax = 1;
            bool kraj = true;
            Console.WriteLine("Ucitaj kontrolnu cifru cif (1-9):");
            cif = Convert.ToInt32(Ucitaj());

           
            Console.WriteLine("Ucitaj novi broj:");
            broj = Convert.ToInt32(Ucitaj()); 
            min = broj;
            max = broj;
            Test(ref kraj, cif, broj);
            while (kraj)
            {
                Console.WriteLine("Ucitaj novi broj:");
                broj = Convert.ToInt32(Ucitaj());
                Test(ref kraj, cif, broj);
                if (broj <= min)
                    if(broj==min)
                        brmin++;
                    else
                    {
                        brmin = 1;
                        min = broj;
                    }

                if (broj >= max)
                    if (broj == max)
                        brmax++;
                    else
                    {
                        brmax = 1;
                        max = broj;
                    }
              
               
            }

            WriteLine("Min = " + min + " ,  Br.min = " + brmin + "  Max = " + max + " ,  Br.max = " + brmax);

        }
        public static void PorediKrugove()
        {
            Krug krug1, krug2;
            double r1;
            
            Console.Write("\nUcitaj poluprecnik prvog kruga = ");
            r1 = Convert.ToDouble(Ucitaj());
            Console.Write("\nUcitaj centar prvog kruga = ");
            Tacka tacka1 = new Tacka();
            Ucitaj(out tacka1);
            double r2;
            Console.Write("\nUcitaj poluprecnik drugog kruga = ");
            r2 = Convert.ToDouble(Ucitaj());
            Console.Write("\nUcitaj centar dugog kruga = ");
            Tacka tacka2 = new Tacka();  
            Ucitaj(out tacka2);
            krug1 = new Krug(tacka1, r1);
            krug2 = new Krug(tacka2, r2);

            if (krug1.Povrsina() > krug2.Povrsina())
            {
                WriteLine("Krug 1 > Krug 2:  " + krug1);
            }
            else
            {
            
                WriteLine("Krug 2 > Krug 1:  " + krug2);
            }

        }
        static void Main(string[] args)
        {

            int izbor;
            bool ispravno;
            bool kraj=true;
            do
            {
                Meni();
                do
                {
                    Console.Write("\nIzbor = ");
                    izbor = Convert.ToInt32(Ucitaj());
                    if (izbor < 1 || izbor > 5)
                    {
                        Console.Write("\nUnesite ponovo: ");
                        ispravno = true;

                    }
                    else
                        ispravno = false;
                } while (ispravno);



                switch (izbor)
                {
                    case 1:
                        ObradaBrojeva();
                        break;

                    case 2:
                        PorediKrugove();
                        break;
                    case 3:
                        ObradaNiza();
                        break;
                    case 4:
                        kraj = false; ;
                        break;

                }

            } while (kraj);
            Console.WriteLine("\nKraj programa!!!! ");
            ReadKey();
        }
    }
}

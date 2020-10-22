using System;
using System.Collections.Generic;

namespace palkkalaskuri
{
    class Program
    {
        public static string path = @"\Users\vilik\Desktop\palkkalaskuriOma\palkkalaskuri\palkkalaskuri\teksti.csv";
        public static List<Tyontekija> tyontekijaLista = new List<Tyontekija>();
        
        static void Main(string[] args)
        {
            Lukija lukija = new Lukija();
            Kirjottaja kirjoittaja = new Kirjottaja();

            lukija.LueTyontekijat(path, tyontekijaLista);
            string syote = "";

            while (syote != "exit")
            {
                Console.WriteLine("Anna syöte, 1 lisää työntekijä, 2 katso työntekijät, 3 poista työntekijä, 4 muokkaa työntekijän tietoja. \nSyötä 'exit', jos haluat poistua");
                syote = Console.ReadLine();
                if (syote == "1")
                    LisaaTyontekija(kirjoittaja);
                else if (syote == "2")
                    KatsoTyontekijat();
                else if (syote == "3")
                    PoistaTyontekija(kirjoittaja);
                else if (syote == "4")
                    MuokkaaTyontekijanTietoja(kirjoittaja);
            }
        }

        public static void LisaaTyontekija(Kirjottaja kirjoittaja)
        {
            // lisaa tyontekija
            Console.WriteLine("Syötä työntekijän koko nimi: ");
            string nimi = Console.ReadLine();
            Console.WriteLine("Syötä työntekijän palkka: ");
            double palkka = Konvertoi.saaArvo<double>(Console.ReadLine());
            Console.WriteLine("Syötä työntekijän ikä: ");
            int ika = Konvertoi.saaArvo<int>(Console.ReadLine());
            Console.WriteLine("Syötä muut pakolliset vakuutukset: ");
            double tyonantajanMuutPakollisetVakuutukset = Konvertoi.saaArvo<double>(Console.ReadLine());
            Console.WriteLine("Syötä muut kulut: ");
            double tyonantajanMuutKulut = Konvertoi.saaArvo<double>(Console.ReadLine());
            Console.WriteLine("Anna ennakonpidätysprosentti: ");
            double tyontekijanEnnakonpidatysprosentti = Konvertoi.saaArvo<double>(Console.ReadLine());

            Tyontekija tyontekija = new Tyontekija(nimi, palkka, ika, tyonantajanMuutPakollisetVakuutukset, tyonantajanMuutKulut, tyontekijanEnnakonpidatysprosentti);

            string luoTekstia = tyontekija.TuoTyontekijanTiedot();
            kirjoittaja.KirjoitaTiedosto(luoTekstia, path);

            tyontekijaLista.Add(tyontekija);

        }

        public static void KatsoTyontekijat()
        {
            foreach (Tyontekija tyontekija in tyontekijaLista)
                Console.WriteLine(tyontekija.TuoTyontekija());
        }

        public static void PoistaTyontekija(Kirjottaja kirjoittaja)
        {
          
            if (tyontekijaLista.Count != 0)
            {
                int indeksi = 0;

                foreach (Tyontekija tyontekija in tyontekijaLista)
                {
                    indeksi += 1;
                    Console.WriteLine(indeksi + " " + tyontekija.Nimi);
                }
                Console.WriteLine("Valitse työntekijä: ");
                int syote = Konvertoi.saaArvo<int>(Console.ReadLine());

                tyontekijaLista.RemoveAt(syote - 1);

                kirjoittaja.UudelleenKirjoitaTiedosto(path, tyontekijaLista);
            }
            else
                Console.WriteLine("Ei poistettavaa työntekijää");
        }

        public static void MuokkaaTyontekijanTietoja(Kirjottaja kirjoittaja)
        {
            
            if (tyontekijaLista.Count != 0)
            {
                int indeksi = 0;

                foreach (Tyontekija tyontekija in tyontekijaLista)
                {
                    indeksi += 1;
                    Console.WriteLine(indeksi + " " + tyontekija.Nimi);
                }
                Console.WriteLine("Valitse työntekijä: ");
                int syote = Konvertoi.saaArvo<int>(Console.ReadLine());


                Console.WriteLine("1 Vaihda nimi, 2 Vaihda palkka, 3 Vaihda ikä, 4 Työnantajan pakolliset vakuutukset, 5 Muut kulut, 6 Ennakkopidätysprosentti");
                int syote2 = Konvertoi.saaArvo<int>(Console.ReadLine());

                if (syote2 == 1)
                {
                    Console.WriteLine("Anna uusi nimi: ");
                    string uusiNimi = Console.ReadLine();
                    tyontekijaLista[syote - 1].VaihdaNimi(uusiNimi);
                }
                else if (syote2 == 2)
                {
                    Console.WriteLine("Anna uusi Palkka: ");
                    double uusiPalkka = Konvertoi.saaArvo<double>(Console.ReadLine());
                    tyontekijaLista[syote - 1].UusiPalkka(uusiPalkka);
                }
                else if (syote2 == 3)
                {
                    Console.WriteLine("Anna uusi ikä: ");
                    int uusiIka = Konvertoi.saaArvo<int>(Console.ReadLine());
                    tyontekijaLista[syote - 1].UusiIka(uusiIka);
                }
                else if (syote2 == 4)
                {
                    Console.WriteLine("Anna uusi työnantajan pakollinen vakuutus: ");
                    double uusiPakollinenVakuutus = Konvertoi.saaArvo<double>(Console.ReadLine());
                    tyontekijaLista[syote - 1].UusiTyonantajanMuutPakollisetVakuutukset(uusiPakollinenVakuutus);
                }
                else if (syote2 == 5)
                {
                    Console.WriteLine("Anna uudet muut kulut: ");
                    double uusiMuutKulut = Konvertoi.saaArvo<double>(Console.ReadLine());
                    tyontekijaLista[syote - 1].UusiTyonantajanMuutKulut(uusiMuutKulut);
                }
                else if (syote2 == 6)
                {
                    Console.WriteLine("Anna uusi ennakkopidätysprosentti: ");
                    double uusiEnnakonpidatysprosentti = Konvertoi.saaArvo<double>(Console.ReadLine());
                    tyontekijaLista[syote - 1].UusiTyontekijanEnnakonpidatysprosentti(uusiEnnakonpidatysprosentti);
                }

                kirjoittaja.UudelleenKirjoitaTiedosto(path, tyontekijaLista);
            }
            else
                Console.WriteLine("Ohjelmassa ei ole työntekijöitä");
        }
    }
}

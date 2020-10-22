using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace palkkalaskuri
{
    public class Lukija
    {

        public void LueTyontekijat(string path, List<Tyontekija> tyontekijaLista)
        {
            if (File.Exists(path))
            {
                string[] readText = File.ReadAllLines(path);

                foreach (string rivi in readText)
                {
                    string[] riviHajotettu = rivi.Split(';').ToArray();

                    string nimi = riviHajotettu[0];
                    int ika = Konvertoi.saaArvo<int>(riviHajotettu[1]);
                    double palkka = Konvertoi.saaArvo<double>(riviHajotettu[2]);
                    double tyonantajanMuutPakollisetVakuutukset = Konvertoi.saaArvo<double>(riviHajotettu[3]);
                    double tyonantajanMuutKulut = Konvertoi.saaArvo<double>(riviHajotettu[4]);
                    double tyontekijanEnnakonpidatysprosentti = Konvertoi.saaArvo<double>(riviHajotettu[5]);
                    Tyontekija tyontekija = new Tyontekija(nimi, palkka, ika, tyonantajanMuutPakollisetVakuutukset, tyonantajanMuutKulut, tyontekijanEnnakonpidatysprosentti);
                    tyontekijaLista.Add(tyontekija);
                }
            }
        }

        



    }
}

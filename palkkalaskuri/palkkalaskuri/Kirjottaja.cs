using System;
using System.Collections.Generic;
using System.IO;

namespace palkkalaskuri
{
    public class Kirjottaja
    {

        public void KirjoitaTiedosto(string teksti, string path)
        {
            if (!File.Exists(path))
            {
                // Create a file to write to.
                string createText = teksti + Environment.NewLine;
                File.WriteAllText(path, createText);
            }

            else if (File.Exists(path))
            {
                string appendText = teksti + Environment.NewLine;
                File.AppendAllText(path, appendText);
            }
        }

        public void UudelleenKirjoitaTiedosto(string path, List<Tyontekija> tyontekijaLista)
        {
            File.Create(path).Close();

            foreach (Tyontekija tyontekija in tyontekijaLista)
            {
                string appendText = tyontekija.TuoTyontekijanTiedot() + Environment.NewLine;
                File.AppendAllText(path, appendText);
            }
        }


        


}
}

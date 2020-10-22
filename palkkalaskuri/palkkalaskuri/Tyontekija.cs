namespace palkkalaskuri
{
    public class Tyontekija
    {

        public string Nimi { get; set; }
        private double palkka;
        private int ika;
        public int Ika
        {
            get => ika;
            set => ika = value;
        }

        private double tyonantajanTyoelakemaksu = 15.55d;
        private double tyonantajanMuutPakollisetVakuutukset;
        private double tyonantajanMuutKulut;
        private double tyonantajanSairasvakuutusmaksu { get => ika >= 16 && ika <= 67 ? 1.34d : 0; }

        public double TyonantajanSairasvakuutusmaksu
        {
            get
            {
                return tyonantajanSairasvakuutusmaksu;
            }
        }

        private double TyonantajanTyottomyysvakuutusmaksu = 0.45d;

        // (palkka - 2125501) * 0.017d + 2125501 * 0.0045d; Muista tämä erikoisuus työttömyysvakuutusmaksussa

        private double tyontekijanEnnakonpidatysprosentti;
        private double tyontekijanTyottomyysvakuutusmaksu = 1.25d;

        private double tyontekijanTyoelakemaksu { get => ika >= 17 && ika <= 52 ? 7.15d : ika >= 53 && ika <= 62 ? 8.65d : ika >= 63 && ika <= 67 ? 7.15d : 0; }

        public double TyontekijanTyoelakemaksu
        {
            get
            {
                return TyontekijanTyoelakemaksu;
            }
        }

        public Tyontekija(string nimi, double palkka, int ika, double tyonantajanMuutPakollisetVakuutukset, double tyonantajanMuutKulut, double tyontekijanEnnakonpidatysprosentti)
        {
            this.Nimi = nimi;
            this.palkka = palkka;
            this.ika = ika;
            this.tyonantajanMuutPakollisetVakuutukset = tyonantajanMuutPakollisetVakuutukset;
            this.tyonantajanMuutKulut = tyonantajanMuutKulut;
            this.tyontekijanEnnakonpidatysprosentti = tyontekijanEnnakonpidatysprosentti;

        }

        public Tyontekija()
        {

        }

        public void VaihdaNimi(string nimi)
        {
            this.Nimi = nimi;
        }

        public void UusiIka(int ika)
        {
            this.ika = ika;
        }

        public void UusiPalkka(double palkka)
        {
            this.palkka = palkka;
        }

        public void UusiTyonantajanMuutPakollisetVakuutukset(double tyonantajanMuutPakollisetVakuutukset)
        {
            this.tyonantajanMuutPakollisetVakuutukset = tyonantajanMuutPakollisetVakuutukset;
        }

        public void UusiTyonantajanMuutKulut(double tyonantajanMuutKulut)
        {
            this.tyonantajanMuutKulut = tyonantajanMuutKulut;
        }

        public void UusiTyontekijanEnnakonpidatysprosentti(double tyontekijanEnnakonpidatysprosentti)
        {
            this.tyontekijanEnnakonpidatysprosentti = tyontekijanEnnakonpidatysprosentti;
        }

        public string TuoTyontekijanTiedot()
        {
            return $"{Nimi};{ika};{palkka};{tyonantajanMuutPakollisetVakuutukset};{tyonantajanMuutKulut};{tyontekijanEnnakonpidatysprosentti}";
        }


        public string TuoTyontekija()
        {
            double yhtTyonantajanTyoelakemaksu = LaskeProsenttiKokoPalkasta(tyonantajanTyoelakemaksu, palkka);
            double yhtTyonantajanSairasvakuutusmaksu = LaskeProsenttiKokoPalkasta(tyonantajanSairasvakuutusmaksu, palkka);
            double yhtTyonantajanMuutPakollisetVakuutukset = LaskeProsenttiKokoPalkasta(tyonantajanMuutPakollisetVakuutukset, palkka);
            double yhtTyonantajanTyottomyysvakuutusmaksu = LaskeProsenttiKokoPalkasta(TyonantajanTyottomyysvakuutusmaksu, palkka);
            double yhtTyontekijanEnnakonpidatysprosentti = LaskeProsenttiKokoPalkasta(tyontekijanEnnakonpidatysprosentti, palkka);
            double yhtTyontekijanTyoelakemaksu = LaskeProsenttiKokoPalkasta(tyontekijanTyoelakemaksu, palkka);
            double yhtTyontekijanTyottomyysvakuutusmaksu = LaskeProsenttiKokoPalkasta(tyontekijanTyottomyysvakuutusmaksu, palkka);


            return
                $"\n\n\n________________________________________________________\n\n" +
                $"Nimi: {Nimi} \n" +
                $"Ikä: {ika} \n" +
                $"Bruttopalkka: {palkka} \n" +
                $"________________________________________________________\n" +
                $"\nTyönantajan maksu\n" +
                $"Työeläkemaksu: {tyonantajanTyoelakemaksu} \n" +
                $"Sairasvakuutusmaksu: {tyonantajanSairasvakuutusmaksu} \n" +
                $"Muut pakolliset vakuutukset: {tyonantajanMuutPakollisetVakuutukset} \n" +
                $"Työttömyysvakuutusmaksu: {TyonantajanTyottomyysvakuutusmaksu} \n" +
                $"Muut kulut: {tyonantajanMuutKulut} \n" +
                $" + Työeläkemaksu: {yhtTyonantajanTyoelakemaksu} \n" +
                $" + Sairasvakuutusmaksu: {yhtTyonantajanSairasvakuutusmaksu} \n" +
                $" + Muut pakolliset vakuutukset: {yhtTyonantajanMuutPakollisetVakuutukset} \n" +
                $" + Työttömyysvakuutusmaksu: {yhtTyonantajanTyottomyysvakuutusmaksu} \n" +
                $" + Muut kulut: {tyonantajanMuutKulut} \n" +
                $"Yhteensä: {yhtTyonantajanTyoelakemaksu + yhtTyonantajanSairasvakuutusmaksu + yhtTyonantajanMuutPakollisetVakuutukset + yhtTyonantajanTyottomyysvakuutusmaksu + tyonantajanMuutKulut} \n" +
                $"________________________________________________________\n" +
                $"\nPalkasta pidetään\n" +
                $"Ennakonpidätysprosentti: {tyontekijanEnnakonpidatysprosentti} \n" +
                $"Työeläkemaksu: {tyontekijanTyoelakemaksu} \n" +
                $"Työttömyysvakuutusmaksu: {tyontekijanTyottomyysvakuutusmaksu} \n" +
                $" - Ennakonpidätys: {yhtTyontekijanEnnakonpidatysprosentti} \n" +
                $" - Työeläkemaksu: {yhtTyontekijanTyoelakemaksu} \n" +
                $" - Työttömyysvakuutusmaksu: {yhtTyontekijanTyottomyysvakuutusmaksu} \n" +
                $"Nettopalkka : {palkka - (yhtTyontekijanEnnakonpidatysprosentti + yhtTyontekijanTyoelakemaksu + yhtTyontekijanTyottomyysvakuutusmaksu)} \n";
        }


        public double LaskeProsenttiKokoPalkasta(double prosentti, double palkka)
        {
            return (prosentti * 1 / 100) * palkka;
        }



    }

}

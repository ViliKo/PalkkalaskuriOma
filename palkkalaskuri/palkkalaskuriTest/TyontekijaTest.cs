using NUnit.Framework;
using palkkalaskuri;

namespace palkkalaskuriTest
{
    public class Tests
    {
        Tyontekija tyontekijaTesti = null;

        [SetUp]
        public void LuodaanTestiLuokkia()
        {
            tyontekijaTesti = new Tyontekija();
        }


        [Test]
        public void LuodaanInstanssi_tyontekijaLuokasta_onTyontekijaLuokanInstanssi()
        {
            
            Assert.IsInstanceOf<Tyontekija>(tyontekijaTesti);
        }

        [Test]
        public void TyonantajanSairasvakuutusmaksuAsetetaan__kunIkaOn__saaArvoksi()
        {
            
            tyontekijaTesti.Ika = 67;
            var tulos = tyontekijaTesti.TyonantajanSairasvakuutusmaksu;
            Assert.AreEqual(1.34d, tulos);

            tyontekijaTesti.Ika = 10;
            var tulos2 = tyontekijaTesti.TyonantajanSairasvakuutusmaksu;
            Assert.AreEqual(0, tulos2);
        }

       

        [Test]
        public void TyontekijanTyoelakemaksuAsetetaan__kunIkaOn__saaArvoksi()
        {
            tyontekijaTesti.Ika = 52;
            var tulos = tyontekijaTesti.TyontekijanTyoelakemaksu;
            Assert.AreEqual(7.15d, tulos);

            //tyontekijaTesti.UusiIka(62);
            //var tulos2 = tyontekijaTesti.TyontekijanTyoelakemaksu;
            //Assert.AreEqual(8.65d, tulos2);

            //tyontekijaTesti.UusiIka(67);
            //var tulos3 = tyontekijaTesti.TyontekijanTyoelakemaksu;
            //Assert.AreEqual(7.15d, tulos3);

            //tyontekijaTesti.UusiIka(10);
            //var tulos4 = tyontekijaTesti.TyontekijanTyoelakemaksu;
            //Assert.AreEqual(0, tulos4);
        }

 


        
 



    }
}
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Herencia
{
    public class CompteEstalvis: CompteBancari , IImposable
    {
        public decimal Interes { get; set; }
        public decimal TotalInteressos { get; private set; }
        public DateOnly DataPagament 
        { get
            {
                return new DateOnly(DateTime.Now.Year, 6, 1);
            } 
           }

        public CompteEstalvis(
           string titular,
           decimal saldoInicial = 0M,
           decimal interes = 0M) : base(titular, saldo: saldoInicial)
        {
            Interes = interes;
        }

        public override void PagaInteres()
        {
            decimal quantitatInteressos = Saldo * Interes;
            Diposit(quantitatInteressos);
            TotalInteressos += quantitatInteressos;
        }
       

        public override string ToString()
        {
            return $"(CE - {NCompte}) - {Titular} - Saldo: {Saldo}";
        }

        public  decimal PagaImpostos(decimal rendaAnual)
        {
            decimal impost;
            if (rendaAnual > 40000) { impost = TotalInteressos * 0.5M; }
            else { impost = TotalInteressos * 0.15M; }
            return impost;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Herencia
{
    public class CompteBancari : IComparable<CompteBancari> 
    {
        public class ComparadorPerTitularISaldo : IComparer<CompteBancari>
        {
            public int Compare(CompteBancari? primer, CompteBancari? segon)
            {
                int result = 0;
                if (primer is null || segon is null)
                    throw new ArgumentNullException("NO PODEM COMPARAR OBJECTES NULLS");
                result = primer.Titular.CompareTo(segon.Titular);
                if (result == 0) //MATEIXOS TITULARS
                result=primer.Saldo.CompareTo(segon.Saldo);
                return result;
            }
        }
        //public class ComparadorPerNumeroDeCompte : IComparer<CompteBancari>
        //{
        //    public int Compare(CompteBancari? x, CompteBancari? y)
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        private static int autonumeric = 0;
        public int NCompte { get; private set; }
        public string Titular { get; private set; }
        public decimal Saldo { get; protected set; } = 0M;
        public decimal TotalIngressos { get; private set; } = 0M;
        public decimal TotalReintegraments { get; private set; } = 0M;

        public CompteBancari(
            string titular,
            decimal saldo = 0M,
            decimal totalIngressos = 0M,
            decimal totalReintegraments = 0M)
        {
            NCompte = autonumeric;
            Titular = titular;
            Saldo = saldo;
            TotalIngressos = totalIngressos;
            TotalReintegraments = totalReintegraments;
            autonumeric++;
        }
        public virtual void PagaInteres()
        {

        }

        public virtual void Reintegrament(decimal quantitat)
        {
            Saldo= Saldo - quantitat;
            TotalReintegraments = TotalReintegraments + quantitat;
        }

        public  void Diposit(decimal quantitat)
        {
            Saldo += quantitat;
            TotalIngressos += quantitat;
        }

        public override String ToString()
        {
            return NCompte + " - " + Titular;
        }

        public int CompareTo(CompteBancari? other)
        {
            int resultat= 0;
            if (other is null) 
                throw new ArgumentNullException("NO PUC ORDENAR AMB ALGUN ELEMENT NULL");
            if (this.Saldo < other.Saldo) resultat = -1;
            else if (this.Saldo > other.Saldo) resultat= 1;
            else  //AQUI ELS SALDOS DELS 2 OBJECTES SON IGUALS
            {
                resultat= this.Titular.CompareTo(other.Titular);
            }
            return resultat;
        }



    }
}

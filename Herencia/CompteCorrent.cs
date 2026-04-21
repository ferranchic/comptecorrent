using System;
using System.Collections.Generic;
using System.Text;

namespace Herencia
{
    public class CompteCorrent : CompteBancari
    {
        public decimal ComissioPerXec { get; set; } = 0.25M;

        public CompteCorrent(
           string titular,
           decimal saldo = 0M,
           decimal comissioPerXec = 0.25M) : base(titular,saldo)
        {
            ComissioPerXec = comissioPerXec;
        }

        public override void Reintegrament(decimal quantitat)
        {
            base.Reintegrament(quantitat);
            Saldo = Saldo - ComissioPerXec;
        }

        public override string ToString()
        {
            return $"(CC - {NCompte}) - {Titular} - Saldo: {Saldo}";
        }
    }
}

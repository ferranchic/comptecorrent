namespace Herencia
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] noms = {"PERE","JOAN","ANNA","LIDIA" };
            Array.Sort(noms);
            MostrarArray(noms);



            int[] numeros = { 26, 11, 33, 44, 1, -8, 13 };
            Array.Sort(numeros);
            MostrarArray(numeros);

            List<int> llistaNums = new List<int>() { 26, 11, 33, 44, 1, -8, 13 };
            llistaNums.Sort();

            CompteBancari cb1 = new CompteCorrent("Pere", saldo: 10000);
            CompteBancari cb2 = new CompteCorrent("Pere", saldo: 5000,comissioPerXec:0.5M);
            CompteBancari cb3 = new CompteEstalvis("Noussaiba", saldoInicial: 10000, interes:0.02M);

          cb3.PagaInteres();

            if (cb3 is CompteBancari) { Console.WriteLine("ES CompteBancari"); }
            if (cb3 is CompteEstalvis) { Console.WriteLine("ES CompteEstalvis"); }
            if (cb3 is CompteCorrent) { Console.WriteLine("ES CompteCorrent"); }
            if (cb3 is IImposable) { Console.WriteLine("cb3 ES IImposable"); }
            if (cb2 is IImposable) { Console.WriteLine("cb2 ES IImposable"); }
            if (cb3 is IComparable<CompteEstalvis>) { Console.WriteLine("cb3 ES IComparable"); }
            if (cb1 is IComparable<CompteEstalvis>) { Console.WriteLine("cb1 ES IComparable"); }
            cb2.PagaInteres();

            IComparable<CompteBancari> interficieComparadoraDe_cb1 = (IComparable<CompteBancari>)cb1;
            Console.WriteLine(interficieComparadoraDe_cb1.CompareTo(cb2));
            Console.WriteLine(cb1.CompareTo(cb2));

            Console.WriteLine(((IImposable)cb3).PagaImpostos(50000));
            Console.WriteLine(((IImposable)cb3).DataPagament);

            if (cb3 is IImposable)
            { 
                IImposable interficieDe_cb3 = (IImposable)cb3;
                Console.WriteLine(interficieDe_cb3.PagaImpostos(20000));
            }

            if (cb3 is IImposable interficieDe_cb3_segona_versio)
            {
                Console.WriteLine(interficieDe_cb3_segona_versio.PagaImpostos(20000));
            }



            List<CompteBancari> comptes= new List<CompteBancari>();
          //  cb2.Reintegrament(100);
          //  cb1.Reintegrament(100);
          //  cb1.Reintegrament(200);
            comptes.Add(cb1);comptes.Add(cb2);comptes.Add(cb3);

            comptes.Sort();
            Console.WriteLine("COMPARADOR PER DEFECTE: SALDO , TITULAR");
            
          //  cb3.Reintegrament(2000);
            foreach(CompteBancari c in comptes)
            {
                Console.WriteLine(c);
            }

            Console.WriteLine("COMPARADOR DE LA SUBCLASSE: TITULAR,SALDO");
            comptes.Sort(new CompteBancari.ComparadorPerTitularISaldo());
            foreach (CompteBancari c in comptes)
            {
                Console.WriteLine(c);
            }



        }

        public static void MostrarArray<T>(T[]taula)
        {
            for (int i=0; i<taula.Length; i++)
                Console.WriteLine(taula[i]);
        }



    }
}

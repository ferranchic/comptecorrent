using System;
using System.Collections.Generic;
using System.Text;

namespace Herencia
{
    public interface IImposable
    {
        decimal PagaImpostos(decimal rendaAnual);
        public DateOnly DataPagament {  get; }
    }
}

using System;
using System.Collections.Generic;
using SoftBank_console.src.Services;

namespace SoftBank_console.src.Interfaces
{
    public interface ITransacoes<T>
    {
        void SaveTransaction();
        List<ExtratoContas> GetAllMovimentation(string contaID);
    }
}


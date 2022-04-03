using System;
using System.Collections.Generic;
using System.Text;

namespace Agenda.Model
{
    public class Endereco
    {
        int _id;
        string _identificador;
        string _endereco;
        public Endereco(int id, string identificador, string endereco)
        {
            this._id = id;
            this._identificador = identificador;
            this._endereco = endereco;
        }

    }
}

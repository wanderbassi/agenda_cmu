using System;
using System.Collections.Generic;
using System.Text;

namespace Agenda.Model
{
    public class Telefone
    {
        int _id;
        string _identificador;
        string _telefone;
        public Telefone(int id, string identificador, string telefone)
        {
            this._id = id;
            this._identificador = identificador;
            this._telefone = telefone;
        }
    }
}

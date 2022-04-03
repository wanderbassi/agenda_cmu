using System;
using System.Collections.Generic;
using System.Text;

namespace Agenda.Model
{
    public class Cliente
    {
        int _id;
        string _name;
        List<Contato> _contatos = new List<Contato>();
        public int Id
        {
            get { return _id; }
        }

        public Cliente(int id, string name)
        {
            this._id = id;
            this._name = name;
        }

        public void AddContato(List<Contato> contato)
        {
            this._contatos.AddRange(contato);
        }
    }
}

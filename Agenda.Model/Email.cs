using System;
using System.Collections.Generic;
using System.Text;

namespace Agenda.Model
{
    public class Email
    {
        int _id;
        string _identificador;
        string _email;
        public Email(int id, string identificador, string email)
        {
            this._id = id;
            this._identificador = identificador;
            this._email = email;
        }
    }
}

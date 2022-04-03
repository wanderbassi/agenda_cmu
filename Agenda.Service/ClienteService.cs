using Agenda.Model;
using Agenda.Repository;
using System;
using System.Collections.Generic;

namespace Agenda.Service
{
    public class ClienteService
    {
        private Banco _clienteRepository { get; set; }
        public ClienteService() {
            this._clienteRepository = new Banco();
        }

        //public void CreateClient(ClienteModel cliente )
        //{
        //   this._clienteRepository.CreateClient(cliente);

        //}
        // public List < ClienteModel > GetAllClients() {

        //   List <ClienteModel> result =  this._clienteRepository.GetAllClients();
        // return result;
        //}


    }
}

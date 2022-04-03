using System;
using System.Collections.Generic;

namespace Agenda.Model
{
    public class Contato
    {
        private int _id { get; set; }
        private string _nome { get; set; }
        private string _sobrenome { get; set; }
        private string _apelido { get; set; }
        private string _empresa { get; set; }
        private string _cargo { get; set; }
        private string _aniversario { get; set; }
        private string _observacao { get; set; }
        private int _usuario { get; set; }

        List<Email> _emails = new List<Email>();
        List<Endereco> _enderecos = new List<Endereco>();
        List<Telefone> _telefones = new List<Telefone>();

        public int Id
        {
            get { return this._id; }
            set
            {
                if (this._id == -1)
                {
                    this._id = value;
                }
            }
        }
        public string Nome
        {
            get { return this._nome; }
            set { this._nome = value; }
        }

        #region Emails
        public List<Email> GetEmails()
        {
            return this._emails;
        }
        public void SetEmails(List<Email> newEmails)
        {
            this._emails = newEmails;
        }
        public void AddEmail(string identificador, string email)
        {
            this._emails.Add(new Email(0, identificador, email));
        }
        public void RemoveEmail(string identificador, string email)
        {
            //this._emails.ForEach(); //pesquisar dentro dos emails e remover o email que seja compativel
            //this._emails.Remove();
        }
        #endregion

        #region Enderecos
        public List<Endereco> GetEnderecos()
        {
            return this._enderecos;
        }
        public void SetEnderecos(List<Endereco> newEnderecos)
        {
            this._enderecos = newEnderecos;
        }
        public void AddEnderecos(string identificador, string enderecos)
        {
            this._enderecos.Add(new Endereco(0, identificador, enderecos));
        }
        #endregion

        #region Telefone
        public List<Telefone> GetTelefone()
        {
            return this._telefones;
        }
        public void SetTelefones(List<Telefone> newItens)
        {
            this._telefones = newItens;
        }
        public void AddTelefone(string identificador, string email)
        {
            this._telefones.Add(new Telefone(0, identificador, email));
        }
        #endregion

        public string SobreNome
        {
            get { return this._sobrenome; }
            set { this._sobrenome = value; }
        }
        public string Apelido
        {
            get { return this._apelido; }
            set { this._apelido = value; }
        }
        public string Empresa
        {
            get { return this._empresa; }
            set { this._empresa = value; }
        }
        public string Cargo
        {
            get { return this._cargo; }
            set { this._cargo = value; }
        }
        public string Aniversario
        {
            get { return this._aniversario; }
            set { this._aniversario = value; }
        }
        public string Observacoes
        {
            get { return this._observacao; }
            set { this._observacao = value; }
        }
        public int Usuario
        {
            get { return this._usuario; }
            set { this._usuario = value; }
        }
        /// <summary>
        /// Contatos vindos do banco de dados
        /// Sobrecarda de Metodo
        /// </summary>
        /// <param name="id"></param>
        /// <param name="usuario"></param>
        /// <param name="nome"></param>
        /// <param name="sobrenome"></param>
        /// <param name="apelido"></param>
        /// <param name="empresa"></param>
        /// <param name="cargo"></param>
        /// <param name="aniversario"></param>
        /// <param name="observacao"></param>
        public Contato(int id, int usuario, string nome, string sobrenome, string apelido, string empresa, string cargo, string aniversario, string observacao)
        {
            this._id = id;
            this._usuario = usuario;
            this._nome = nome;
            this._sobrenome = sobrenome;
            this._apelido = apelido;
            this._cargo = cargo;
            this._empresa = empresa;
            this._observacao = observacao;
            this._aniversario = aniversario;
        }
        /// <summary>
        /// Contato criado localmente
        /// Sobrecarda de Metodo
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="nome"></param>
        /// <param name="sobrenome"></param>
        /// <param name="apelido"></param>
        /// <param name="empresa"></param>
        /// <param name="cargo"></param>
        /// <param name="aniversario"></param>
        /// <param name="observacao"></param>
        public Contato(int id, string nome, string sobrenome, string apelido, string empresa, string cargo, string aniversario, string observacao)
        {
            this._id = -1;
            //this._usuario = usuario;
            this._nome = nome;
            this._sobrenome = sobrenome;
            this._apelido = apelido;
            this._cargo = cargo;
            this._empresa = empresa;
            this._observacao = observacao;
            this._aniversario = aniversario;
        }

        public override string ToString()
        {
            var client = new
            {
                id = this._id,
                nome = this._nome,
                apelido = this._apelido,
                empresa = this._empresa,
                aniversario = this._aniversario,
                observacoes = this._observacao,
            };
            return $"{client}";
        }
    }

}

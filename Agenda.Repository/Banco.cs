using Agenda.Model;
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows;

namespace Agenda.Repository
{
    public class Banco
    {
        private string _string { get; set; }
        MySqlConnection bdConn; //MySQL
        private MySqlDataAdapter bdAdapter;
        private DataSet bdDataSet; //MySQL
        public Banco()
        {
            //Definição do dataset
            bdDataSet = new DataSet();
            //Define string de conexão



            string data_source = ("datasource=localhost;username=root;password=Teste;database=agenda");
            bdConn = new MySqlConnection(data_source);


        }
        public Cliente GetCliente(string user = "adamastor", string password = "12345")
        {
            //Abre conexão
            try
            {
                bdConn.Open();
                if (bdConn.State == ConnectionState.Open)
                {
                    //Se estiver aberta insere os dados na BD
                    MySqlCommand sql = new MySqlCommand(
                        "SELECT " +
                            "`usuario`.`id`, " + // reader.GetInt32(0)
                            "`usuario`.`nome` " + // reader.GetString(1)
                        "FROM `agenda`.`usuario`" +
                        "WHERE " +
                            "`usuario`.`usuario` = \\'" + user + "\\' AND " +
                            "`usuario`.`senha`= \\'" + password + "\\' " +
                        "LIMIT 1",
                        bdConn
                    );

                    MySqlDataReader reader = sql.ExecuteReader();

                    reader.Read();

                    Cliente cliente = new Cliente(
                        reader.GetInt32(0),
                        reader.GetString(1)
                    );
                    return cliente;
                }
                else
                {
                    throw new ArgumentException("Erro na Consulta");
                }
            }
            catch
            {
                Console.WriteLine("Impossível estabelecer conexão");
            }
            finally
            {
                bdConn.Close();
            }
            return null;
        }
        public List<Contato> GetAllContatos(Cliente cliente)
        {
            List<Contato> contatos = new List<Contato>();
            //Abre conexão
            try
            {
                bdConn.Open();
                if (bdConn.State == ConnectionState.Open)
                {
                    //Se estiver aberta insere os dados na BD
                    MySqlCommand sql = new MySqlCommand(
                        "SELECT " +
                            "`contato`.`id`, " +
                            "`contato`.`usuario`, " +
                            "`contato`.`nome`, " +
                            "`contato`.`sobrenome`, " +
                            "`contato`.`apelido`, " +
                            "`contato`.`empresa`, " +
                            "`contato`.`cargo`, " +
                            "DATE_FORMAT(`contato`.`aniversario`, '%d %m %Y') AS data, " +
                    "`contato`.`observacao`, " +
                        "FROM `agenda`.`contato` " +
                        "WHERE " +
                            "`contato`.`usuario` = \\'" + cliente.Id + "\\' ",
                        bdConn
                    );
                    MySqlDataReader reader = sql.ExecuteReader();



                    while (reader.Read())
                    {
                        Contato aux = new Contato(
                                reader.GetInt32(0),
                                reader.GetInt32(1),
                                reader.GetString(2),
                                reader.GetString(3),
                                reader.GetString(4),
                                reader.GetString(5),
                                reader.GetString(6),
                                reader.GetString(7),
                                reader.GetString(8)
                            );

                        aux.SetEmails(this.GetEmails(aux));
                        aux.SetEnderecos(this.GetEnderecos(aux));
                        aux.SetTelefones(this.GetTelefones(aux));
                        contatos.Add(aux);
                    }
                }
                else
                {
                    throw new ArgumentException("Erro na Consulta");
                }
            }
            catch
            {
                Console.WriteLine("Impossível estabelecer conexão");
            }
            finally
            {
                bdConn.Close();
            }
            return contatos;
        }
        private List<Email> GetEmails(Contato contato)
        {
            List<Email> emails = new List<Email>();

            //Abre conexão
            try
            {
                bdConn.Open();
                if (bdConn.State == ConnectionState.Open)
                {
                    //Se estiver aberta insere os dados na BD
                    MySqlCommand sql = new MySqlCommand(
                        "SELECT " +
                            "`emails`.`id`, " +
                            "`emails`.`identificador`, " +
                            "`emails`.`email` " +
                        "FROM `agenda`.`emails` " +
                        "WHERE " +
                            "`emails`.`contato` = \\'" + contato.Id + "\\' ",
                        bdConn
                    );
                    MySqlDataReader reader = sql.ExecuteReader();

                    while (reader.Read())
                    {
                        Email aux = new Email(
                                reader.GetInt32(0),
                                reader.GetString(1),
                                reader.GetString(2)
                            );
                        emails.Add(aux);
                    }
                }
                else
                {
                    throw new ArgumentException("Erro na Consulta");
                }
            }
            catch
            {
                Console.WriteLine("Impossível estabelecer conexão");
            }
            finally
            {
                bdConn.Close();
            }
            return emails;
        }
        private List<Endereco> GetEnderecos(Contato contato)
        {
            List<Endereco> enderecos = new List<Endereco>();

            //Abre conexão
            try
            {
                bdConn.Open();
                if (bdConn.State == ConnectionState.Open)
                {
                    //Se estiver aberta insere os dados na BD
                    MySqlCommand sql = new MySqlCommand(
                        "SELECT " +
                            "`enderecos`.`id`, " +
                            "`enderecos`.`identificador`, " +
                            "`enderecos`.`endereco` " +
                        "FROM `agenda`.`enderecos` " +
                        "WHERE " +
                            "`enderecos`.`contato` = \\'" + contato.Id + "\\' ",
                        bdConn
                    );
                    MySqlDataReader reader = sql.ExecuteReader();

                    while (reader.Read())
                    {
                        Endereco aux = new Endereco(
                                reader.GetInt32(0),
                                reader.GetString(1),
                                reader.GetString(2)
                            );
                        enderecos.Add(aux);
                    }
                }
                else
                {
                    throw new ArgumentException("Erro na Consulta");
                }
            }
            catch
            {
                Console.WriteLine("Impossível estabelecer conexão");
            }
            finally
            {
                bdConn.Close();
            }
            return enderecos;
        }
        private List<Telefone> GetTelefones(Contato contato)
        {
            List<Telefone> telefones = new List<Telefone>();

            //Abre conexão
            try
            {
                bdConn.Open();
                if (bdConn.State == ConnectionState.Open)
                {
                    //Se estiver aberta insere os dados na BD
                    MySqlCommand sql = new MySqlCommand(
                        "SELECT " +
                            "`telefones`.`id`, " +
                            "`telefones`.`identificador`, " +
                            "`telefones`.`telefone` " +
                        "FROM `agenda`.`telefones` " +
                        "WHERE " +
                            "`telefones`.`contato` = \\'" + contato.Id + "\\' ",
                        bdConn
                    );
                    MySqlDataReader reader = sql.ExecuteReader();

                    while (reader.Read())
                    {
                        Telefone aux = new Telefone(
                                reader.GetInt32(0),
                                reader.GetString(1),
                                reader.GetString(2)
                            );
                        telefones.Add(aux);
                    }
                }
                else
                {
                    throw new ArgumentException("Erro na Consulta");
                }
            }
            catch
            {
                Console.WriteLine("Impossível estabelecer conexão");
            }
            finally
            {
                bdConn.Close();
            }
            return telefones;
        }

        /// <summary>
        /// Atualiza ou Insere um novo contato
        /// </summary>
        /// <param name=""></param>
        public void UpdateContato(Contato contato)
        {
            //Abre conexão
            try
            {
                bdConn.Open();
                if (bdConn.State == ConnectionState.Open)
                {
                    if (contato.Id == -1)
                    {
                        //insere no banco e atualiza o ID
                        MySqlCommand sql = new MySqlCommand(
                            "INSERT INTO `agenda`.`contato` " +
                                "(`nome`,`sobrenome`,`apelido`,`empresa`,`cargo`,`aniversario`,`observacao`,`usuario`) " +
                            "VALUES (" +
                                "\\'" + contato.Nome + "\\', " +
                                "\\'" + contato.SobreNome + "\\', " +
                                "\\'" + contato.Apelido + "\\', " +
                                "\\'" + contato.Empresa + "\\', " +
                                "\\'" + contato.Cargo + "\\', " +
                                "\\'" + contato.Aniversario + "\\', " +
                                "\\'" + contato.Observacoes + "\\', " +
                                "\\'" + contato.Usuario + "\\')" +
                                "SELECT LAST_INSERT_ID(); ",
                            bdConn
                        );
                        MySqlDataReader reader = sql.ExecuteReader();
                        reader.Read();
                        contato.Id = reader.GetInt32(0);
                    }
                    else
                    {
                        //atualiza as informações
                        MySqlCommand sql = new MySqlCommand(
                            "UPDATE `agenda`.`contato`" +
                            "SET" +
                                "`nome` = \\'" + contato.Nome + "\\', " +
                                "`sobrenome` = \\'" + contato.SobreNome + "\\', " +
                                "`apelido` = \\'" + contato.Apelido + "\\', " +
                                "`empresa` = \\'" + contato.Empresa + "\\', " +
                                "`cargo` = \\'" + contato.Cargo + "\\', " +
                                "`aniversario` = \\'" + contato.Aniversario + "\\', " +
                                "`observacao` = \\'" + contato.Observacoes + "\\', " +
                            " WHERE `id` = \\'" + contato.Id + "\\';",
                            bdConn
                        );
                        sql.ExecuteNonQuery();
                    }
                }
                else
                {
                    throw new ArgumentException("Erro na Consulta");
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                bdConn.Close();
            }
        }

        public void DeleteContato(Contato contato)
        {
            //Abre conexão
            try
            {
                bdConn.Open();
                if (bdConn.State == ConnectionState.Open)
                {

                    //deleta no banco
                    MySqlCommand sql = new MySqlCommand(
                        "Delete FROM contato WHERE id = @id;", bdConn);


                    sql.Parameters.AddWithValue("@id", contato.Id);
                    sql.ExecuteNonQuery();


                    sql = new MySqlCommand(
                       "Delete FROM emails WHERE contato = @id;", bdConn);


                    sql.Parameters.AddWithValue("@id", contato.Id);
                    sql.ExecuteNonQuery();



                    sql = new MySqlCommand(
                        "Delete FROM telefones WHERE contato = @id;", bdConn);


                    sql.Parameters.AddWithValue("@id", contato.Id);
                    sql.ExecuteNonQuery();

                    sql = new MySqlCommand(
                        "Delete FROM enderecos WHERE contato = @id;", bdConn);


                    sql.Parameters.AddWithValue("@id", contato.Id);
                    sql.ExecuteNonQuery();



                }
                else
                {
                    throw new ArgumentException("Erro na Consulta");
                }
            }
            catch
            {
                Console.WriteLine("Impossível estabelecer conexão");
            }
            finally
            {
                bdConn.Close();
            }
        }
    }
}

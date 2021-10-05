using JSL.CadCaminhoneiro.Domain.Models;
using JSL.CadCaminhoneiro.Domain.Models.Interfaces;
using JSL.CadCaminhoneiro.Infra.Data.Connection;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace JSL.CadCaminhoneiro.Infra.Data.Repository
{
    public class MotoristaRepository : ConnectionDB, IMotoristaRepository
    {
        public MotoristaRepository(IConfiguration configuration) : base(configuration) { }

        public async Task<Motorista> Adicionar(Motorista motorista)
        {
            const string sqlAdicionarMotorista = @"INSERT INTO MOTORISTA (IDMOTORISTA, NOME) 
                                                    VALUES (@IDMOTORISTA, @NOME)";

            const string sqlAdicionarCaminhao = @"INSERT INTO CAMINHAO (IDCAMINHAO, MARCA, MODELO, PLACA, EIXO, IDMOTORISTA) 
                                                    VALUES (@IDCAMINHAO, @MARCA, @MODELO, @PLACA, @EIXO, @IDMOTORISTA)";

            const string sqlAdicionarEndereco = @"INSERT INTO ENDERECO (IDENDERECO, LOGRADOURO, NUMERO, BAIRRO, CIDADE, ESTADO, CEP, IDMOTORISTA)
                                                    VALUES (@IDENDERECO, @LOGRADOURO, @NUMERO, @BAIRRO, @CIDADE, @ESTADO, @CEP, @IDMOTORISTA)";

            using (var con = Connection)
            {
                try
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(sqlAdicionarMotorista, con))
                    {
                        sqlCommand.Parameters.Add("@IDMOTORISTA", SqlDbType.UniqueIdentifier).Value = motorista.Id;
                        sqlCommand.Parameters.Add("@NOME", SqlDbType.NVarChar, 80).Value = motorista.Nome;

                        sqlCommand.ExecuteNonQuery();
                    }

                    using (SqlCommand sqlCommand = new SqlCommand(sqlAdicionarCaminhao, con))
                    {
                        sqlCommand.Parameters.Add("@IDCAMINHAO", SqlDbType.UniqueIdentifier).Value = motorista.Caminhao.Id;
                        sqlCommand.Parameters.Add("@MARCA", SqlDbType.NVarChar, 30).Value = motorista.Caminhao.Marca;
                        sqlCommand.Parameters.Add("@MODELO", SqlDbType.NVarChar, 30).Value = motorista.Caminhao.Modelo;
                        sqlCommand.Parameters.Add("@PLACA", SqlDbType.NVarChar, 8).Value = motorista.Caminhao.Placa;
                        sqlCommand.Parameters.Add("@EIXO", SqlDbType.NVarChar, 8).Value = motorista.Caminhao.Placa;
                        sqlCommand.Parameters.Add("@IDMOTORISTA", SqlDbType.UniqueIdentifier).Value = motorista.Id;

                        sqlCommand.ExecuteNonQuery();
                    }

                    using (SqlCommand sqlCommand = new SqlCommand(sqlAdicionarEndereco, con))
                    {
                        sqlCommand.Parameters.Add("@IDENDERECO", SqlDbType.UniqueIdentifier).Value = motorista.Endereco.Id;
                        sqlCommand.Parameters.Add("@LOGRADOURO", SqlDbType.NVarChar, 80).Value = motorista.Endereco.Logradouro;
                        sqlCommand.Parameters.Add("@NUMERO", SqlDbType.NVarChar).Value = motorista.Endereco.Numero;
                        sqlCommand.Parameters.Add("@BAIRRO", SqlDbType.NVarChar, 30).Value = motorista.Endereco.Bairro;
                        sqlCommand.Parameters.Add("@CIDADE", SqlDbType.NVarChar, 30).Value = motorista.Endereco.Cidade;
                        sqlCommand.Parameters.Add("@ESTADO", SqlDbType.NVarChar, 30).Value = motorista.Endereco.Estado;
                        sqlCommand.Parameters.Add("@CEP", SqlDbType.NVarChar, 10).Value = motorista.Endereco.Cep;
                        sqlCommand.Parameters.Add("@IDMOTORISTA", SqlDbType.UniqueIdentifier).Value = motorista.Id;

                        sqlCommand.ExecuteNonQuery();
                    }
                }
                catch
                {
                    return null;
                }
                finally
                {
                    con.Close();
                }
            }

            return await Task.FromResult(motorista);
        }

        public async Task<Motorista> Atualizar(Motorista motorista)
        {
            const string sqlAtualizarMotorista = "UPDATE MOTORISTA SET NOME = @NOME WHERE IDMOTORISTA = @IDMOTORISTA";

            const string sqlAtualizarCaminhao = @"UPDATE CAMINHAO SET MARCA = @MARCA,
                                                                      MODELO = @MODELO,
                                                                      PLACA = @PLACA,
                                                                      EIXO = @EIXO
                                                  WHERE IDMOTORISTA = @IDMOTORISTA";

            const string sqlAtualizarEndereco = @"UPDATE ENDERECO SET IDENDERECO = @IDENDERECO, 
                                                                      LOGRADOURO = @LOGRADOURO, 
                                                                      NUMERO = @NUMERO, 
                                                                      BAIRRO = @BAIRRO, 
                                                                      CIDADE = @CIDADE,
                                                                      ESTADO = @ESTADO,
                                                                      CEP = @CEP 
                                                  WHERE IDMOTORISTA = @IDMOTORISTA";

            using (var con = Connection)
            {
                try
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(sqlAtualizarMotorista, con))
                    {
                        sqlCommand.Parameters.Add("@IDMOTORISTA", SqlDbType.UniqueIdentifier).Value = motorista.Id;
                        sqlCommand.Parameters.Add("@NOME", SqlDbType.NVarChar, 80).Value = motorista.Nome;

                        sqlCommand.ExecuteNonQuery();
                    }

                    using (SqlCommand sqlCommand = new SqlCommand(sqlAtualizarCaminhao, con))
                    {
                        sqlCommand.Parameters.Add("@MARCA", SqlDbType.NVarChar, 30).Value = motorista.Caminhao.Marca;
                        sqlCommand.Parameters.Add("@MODELO", SqlDbType.NVarChar, 30).Value = motorista.Caminhao.Modelo;
                        sqlCommand.Parameters.Add("@PLACA", SqlDbType.NVarChar, 8).Value = motorista.Caminhao.Placa;
                        sqlCommand.Parameters.Add("@EIXO", SqlDbType.NVarChar, 8).Value = motorista.Caminhao.Placa;
                        sqlCommand.Parameters.Add("@IDMOTORISTA", SqlDbType.UniqueIdentifier).Value = motorista.Id;

                        sqlCommand.ExecuteNonQuery();
                    }

                    using (SqlCommand sqlCommand = new SqlCommand(sqlAtualizarEndereco, con))
                    {
                        sqlCommand.Parameters.Add("@LOGRADOURO", SqlDbType.NVarChar, 80).Value = motorista.Endereco.Logradouro;
                        sqlCommand.Parameters.Add("@NUMERO", SqlDbType.NVarChar).Value = motorista.Endereco.Numero;
                        sqlCommand.Parameters.Add("@BAIRRO", SqlDbType.NVarChar, 30).Value = motorista.Endereco.Bairro;
                        sqlCommand.Parameters.Add("@CIDADE", SqlDbType.NVarChar, 30).Value = motorista.Endereco.Cidade;
                        sqlCommand.Parameters.Add("@ESTADO", SqlDbType.NVarChar, 30).Value = motorista.Endereco.Estado;
                        sqlCommand.Parameters.Add("@CEP", SqlDbType.NVarChar, 10).Value = motorista.Endereco.Cep;
                        sqlCommand.Parameters.Add("@IDMOTORISTA", SqlDbType.UniqueIdentifier).Value = motorista.Id;

                        sqlCommand.ExecuteNonQuery();
                    }
                }
                catch
                {
                    return null;
                }
                finally
                {
                    con.Close();
                }
            }

            return await Task.FromResult(motorista);
        }

        public async Task<Motorista> ObterMotoristaPorId(Guid idMotorista)
        {

            const string sqlObterMotorista = @"SELECT 
                                                     MOT.IDMOTORISTA,
                                                     MOT.NOME,
                                                     CAM.IDCAMINHAO,
                                                     CAM.MARCA,
                                                     CAM.MODELO,
                                                     CAM.PLACA, 
                                                     CAM.EIXO,
                                                     ENDE.IDENDERECO,
                                                     ENDE.LOGRADOURO,
                                                     ENDE.NUMERO, 
                                                     ENDE.BAIRRO,
                                                     ENDE.CIDADE,
                                                     ENDE.ESTADO,
                                                     ENDE.CEP
                                              FROM 
                                                     MOTORISTA AS MOT
                                                     INNER JOIN CAMINHAO AS CAM
                                                     ON MOT.IDMOTORISTA = CAM.IDMOTORISTA
                                                     INNER JOIN ENDERECO AS ENDE
                                                     ON MOT.IDMOTORISTA = ENDE.IDMOTORISTA
                                              WHERE
                                                     MOT.IDMOTORISTA = @IDMOTORISTA";

            Motorista motorista = null;

            using (var con = Connection)
            {
                try
                {
                    using (SqlCommand sqlCommand = new SqlCommand(sqlObterMotorista, con))
                    {
                        sqlCommand.Parameters.AddWithValue("@IDMOTORISTA", idMotorista);

                        if (con.State == ConnectionState.Closed)
                            con.Open();

                        using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                        {
                            while(dataReader.Read())
                            {
                                motorista = new Motorista();
                                motorista.Id = (Guid)dataReader[0];
                                motorista.Nome = dataReader[1].ToString();
                                motorista.Caminhao = new Caminhao();
                                motorista.Caminhao.Id = (Guid)dataReader[2];
                                motorista.Caminhao.Marca = dataReader[3].ToString();
                                motorista.Caminhao.Modelo = dataReader[4].ToString();
                                motorista.Caminhao.Placa = dataReader[5].ToString();
                                motorista.Caminhao.Eixo = dataReader[6].ToString();
                                motorista.Endereco = new Endereco();
                                motorista.Endereco.Id = (Guid)dataReader[7];
                                motorista.Endereco.Logradouro = dataReader[8].ToString();
                                motorista.Endereco.Numero = dataReader[9].ToString();
                                motorista.Endereco.Bairro = dataReader[10].ToString();
                                motorista.Endereco.Cidade = dataReader[11].ToString();
                                motorista.Endereco.Estado = dataReader[12].ToString();
                                motorista.Endereco.Cep = dataReader[13].ToString();
                            }

                            dataReader.Close();
                        }

                    }
                }
                catch
                {
                    return null;
                }
                finally
                {
                    con.Close();
                }
            }

            return await Task.FromResult(motorista);
        }

        public async Task<IEnumerable<Motorista>> ObterMotoristas()
        {
            const string sqlObterMotoristas = @"SELECT 
                                                      MOT.IDMOTORISTA,
                                                      MOT.NOME,
                                                      CAM.IDCAMINHAO,
                                                      CAM.MARCA,
                                                      CAM.MODELO,
                                                      CAM.PLACA, 
                                                      CAM.EIXO,
                                                      ENDE.IDENDERECO,
                                                      ENDE.LOGRADOURO,
                                                      ENDE.NUMERO, 
                                                      ENDE.BAIRRO,
                                                      ENDE.CIDADE,
                                                      ENDE.ESTADO,
                                                      ENDE.CEP
                                               FROM 
                                                      MOTORISTA AS MOT
                                                      INNER JOIN CAMINHAO AS CAM
                                                      ON MOT.IDMOTORISTA = CAM.IDMOTORISTA
                                                      INNER JOIN ENDERECO AS ENDE
                                                      ON MOT.IDMOTORISTA = ENDE.IDMOTORISTA
                                              ORDER BY MOT.NOME";

            List<Motorista> motoristas = new List<Motorista>();

            using (var con = Connection)
            {
                try
                {
                    using (SqlCommand sqlCommand = new SqlCommand(sqlObterMotoristas, con))
                    {
                        if (con.State == ConnectionState.Closed)
                            con.Open();

                        using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                Motorista motorista = new Motorista();

                                motorista.Id = (Guid)dataReader[0];
                                motorista.Nome = dataReader[1].ToString();
                                motorista.Caminhao = new Caminhao();
                                motorista.Caminhao.Id = (Guid)dataReader[2];
                                motorista.Caminhao.Marca = dataReader[3].ToString();
                                motorista.Caminhao.Modelo = dataReader[4].ToString();
                                motorista.Caminhao.Placa = dataReader[5].ToString();
                                motorista.Caminhao.Eixo = dataReader[6].ToString();
                                motorista.Endereco = new Endereco();
                                motorista.Endereco.Id = (Guid)dataReader[7];
                                motorista.Endereco.Logradouro = dataReader[8].ToString();
                                motorista.Endereco.Numero = dataReader[9].ToString();
                                motorista.Endereco.Bairro = dataReader[10].ToString();
                                motorista.Endereco.Cidade = dataReader[11].ToString();
                                motorista.Endereco.Estado = dataReader[12].ToString();
                                motorista.Endereco.Cep = dataReader[13].ToString();

                                motoristas.Add(motorista);
                            };

                            dataReader.Close();
                        }

                    }
                }
                catch(Exception ex)
                {
                    return null;
                }
                finally
                {
                    con.Close();
                }
            }

            return await Task.FromResult(motoristas);
        }

        public void Remover(Guid idMotorista)
        {
            const string sqlRemoverMotorista = @"DELETE FROM MOTORISTA WHERE IDMOTORISTA = @IDMOTORISTA";
            const string sqlRemoverCaminhao = @"DELETE FROM CAMINHAO WHERE IDMOTORISTA = @IDMOTORISTA";
            const string sqlRemoverEndereco = @"DELETE FROM ENDERECO WHERE IDMOTORISTA = @IDMOTORISTA";

            using (var con = Connection)
            {
                try
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(sqlRemoverEndereco, con))
                    {
                        sqlCommand.Parameters.AddWithValue("@IDMOTORISTA", idMotorista);

                        sqlCommand.ExecuteNonQuery();
                    }

                    using (SqlCommand sqlCommand = new SqlCommand(sqlRemoverCaminhao, con))
                    {
                        sqlCommand.Parameters.AddWithValue("@IDMOTORISTA", idMotorista);

                        sqlCommand.ExecuteNonQuery();
                    }

                    using (SqlCommand sqlCommand = new SqlCommand(sqlRemoverMotorista, con))
                    {
                        sqlCommand.Parameters.AddWithValue("@IDMOTORISTA", idMotorista);

                        sqlCommand.ExecuteNonQuery();
                    }
                }
                finally
                {
                    con.Close();
                }
            }
        }
    }
}

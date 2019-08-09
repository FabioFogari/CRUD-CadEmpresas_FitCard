using System;
using System.Collections.Generic;
using System.Collections; 
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace Sistema_Empresas
{
    class sisDBADM
    {
        private const string _strCon = @"Data Source=PCHOME\SQLEXPRESS;Initial Catalog=CrudEmpresa;Integrated Security=True";
        private string vsql = "";
        SqlConnection objCon = null;

        #region "Metodos de conexão com o Banco"
        private bool conectar()
        {
            objCon = new SqlConnection(_strCon);
            try
            {
                objCon.Open();
                return true;
            }
            catch
            {
                return false;
            }

        }
        private bool desconectar()
        {
                   
            if (objCon.State != ConnectionState.Closed)
            {
                objCon.Close();
                objCon.Dispose();
                return true;
            }else
            {
                return false;
            }
                objCon.Dispose();
                return false;
            }
        #endregion

        #region "Metodos de execução de SQL"
        public bool Insert(ArrayList p_arrInsert)
        {
            vsql = "INSERT INTO CrudEmpresa ([NOME], [RAZAO_SOCIAL], [CNPJ], [ENDERECO], [CIDADE], [UF], [TELEFONE], [EMAIL], [CATEGORIA], [STATUS], [AGENCIA], [CONTA])"+
                "VALUES (@NOME, @RAZAO_SOCIAL, @CNPJ, @ENDERECO, @CIDADE, @UF,@TELEFONE, @EMAIL, @CATEGORIA, @STATUS, @AGENCIA, @CONTA)";
            SqlCommand objcmd = null;

            if (this.conectar())
            {
                try
                {
                    objcmd = new SqlCommand(vsql, objCon);
                    objcmd.Parameters.Add(new SqlParameter("@NOME", p_arrInsert[0]));
                    objcmd.Parameters.Add(new SqlParameter("@RAZAO_SOCIAL", p_arrInsert[1]));
                    objcmd.Parameters.Add(new SqlParameter("@CNPJ", p_arrInsert[2]));
                    objcmd.Parameters.Add(new SqlParameter("@ENDERECO", p_arrInsert[3]));
                    objcmd.Parameters.Add(new SqlParameter("@CIDADE", p_arrInsert[4]));
                    objcmd.Parameters.Add(new SqlParameter("@UF", p_arrInsert[5]));
                    objcmd.Parameters.Add(new SqlParameter("@TELEFONE", p_arrInsert[6]));
                    objcmd.Parameters.Add(new SqlParameter("@EMAIL", p_arrInsert[7]));
                    objcmd.Parameters.Add(new SqlParameter("@CATEGORIA", p_arrInsert[8]));
                    objcmd.Parameters.Add(new SqlParameter("@STATUS", p_arrInsert[9]));
                    objcmd.Parameters.Add(new SqlParameter("@AGENCIA", p_arrInsert[10]));
                    objcmd.Parameters.Add(new SqlParameter("@CONTA", p_arrInsert[11]));
                    


                    objcmd.ExecuteNonQuery();

                    return true;

                }
                catch(SqlException sqlerr)
                {
                     throw sqlerr;
                }
                finally
                {
                    this.desconectar();
                }

            }
            else
            {
                return false;
            }

        }

        public bool Update(ArrayList p_arrUpdate)
        {
            vsql = "UPDATE CrudEmpresa SET NOME = @NOME, RAZAO_SOCIAL = @RAZAO_SOCIAL, CNPJ = @CNPJ, ENDERECO = @ENDERECO, CIDADE = @CIDADE, UF = @UF, TELEFONE = @TELEFONE, EMAIL = @EMAIL, CATEGORIA = @CATEGORIA, STATUS = @STATUS, AGENCIA = @AGENCIA, CONTA = @CONTA WHERE ID_EMPRESA = @ID_EMPRESA";

            SqlCommand objcmd = null;

            if (this.conectar())
            {
                try
                {
                    objcmd = new SqlCommand(vsql, objCon);
                    objcmd.Parameters.Add(new SqlParameter("@ID_EMPRESA", p_arrUpdate[0]));                    
                    objcmd.Parameters.Add(new SqlParameter("@NOME", p_arrUpdate[1]));
                    objcmd.Parameters.Add(new SqlParameter("@RAZAO_SOCIAL", p_arrUpdate[2]));
                    objcmd.Parameters.Add(new SqlParameter("@CNPJ", p_arrUpdate[3]));
                    objcmd.Parameters.Add(new SqlParameter("@ENDERECO", p_arrUpdate[4]));
                    objcmd.Parameters.Add(new SqlParameter("@CIDADE", p_arrUpdate[5]));
                    objcmd.Parameters.Add(new SqlParameter("@UF", p_arrUpdate[6]));
                    objcmd.Parameters.Add(new SqlParameter("@TELEFONE", p_arrUpdate[7]));
                    objcmd.Parameters.Add(new SqlParameter("@EMAIL", p_arrUpdate[8]));
                    objcmd.Parameters.Add(new SqlParameter("@CATEGORIA", p_arrUpdate[9]));
                    objcmd.Parameters.Add(new SqlParameter("@STATUS", p_arrUpdate[10]));
                    objcmd.Parameters.Add(new SqlParameter("@AGENCIA", p_arrUpdate[11]));
                    objcmd.Parameters.Add(new SqlParameter("@CONTA", p_arrUpdate[12]));
                   
                    

                    objcmd.ExecuteNonQuery();

                    return true;

                }
                catch (SqlException sqlerr)
                {
                    throw sqlerr;
                }
                finally
                {
                    this.desconectar();
                }

            }
            else
            {
                return false;
            }
        }

        public bool Delete(int id_Empresa)
        {
            vsql = "DELETE FROM CRUDEMPRESA WHERE ID_EMPRESA = @ID_EMPRESA";

            SqlCommand objcmd = null;

            if (this.conectar())
            {
                try
                {
                    objcmd = new SqlCommand(vsql, objCon);
                    objcmd.Parameters.AddWithValue("@ID_EMPRESA", id_Empresa);
                    objcmd.ExecuteNonQuery();

                   
                    
                    objcmd.ExecuteNonQuery();

                    return true;

                }
                catch (SqlException sqlerr)
                {
                    throw sqlerr;
                }
                finally
                {
                    this.desconectar();
                }

            }
            else
            {
                return false;
            }
        }
        #endregion

        #region " Metodos que ListaGrid e faz Pesquisa"
        public DataTable ListaGrid()
        {
            vsql = "SELECT [ID_EMPRESA] AS Código, [NOME], [RAZAO_SOCIAL], [CNPJ], [ENDERECO] FROM CRUDEMPRESA";

            SqlCommand objcmd = null;

            if (this.conectar())
            {
                try
                {
                    objcmd = new SqlCommand(vsql, objCon);
                    SqlDataAdapter adp = new SqlDataAdapter(objcmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);                    
                    return dt;
                }
                catch (SqlException sqlerr)
                {
                    throw sqlerr;
                }
                finally
                {
                    this.desconectar();
                }

            }
            else
            {
                return null;
            }


        }




        
        public DataTable Pesquisar(string sql,string param)
        {

            this.vsql = sql;

            SqlCommand objcmd = null;

            if (this.conectar())
            {
                try
                {
                    objcmd = new SqlCommand(vsql, objCon);
                    objcmd.Parameters.Add(new SqlParameter("@VALOR", param));
                    SqlDataAdapter adp = new SqlDataAdapter(objcmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    return dt;
                }
                catch (SqlException sqlerr)
                {
                    throw sqlerr;
                }
                finally
                {
                    this.desconectar();
                }

            }
            else
            {
                return null;
            }
        }
        #endregion



        public List<string> listaUF()
        {
            vsql = "SELECT UF FROM ESTADO";

            SqlCommand objcmd = null;

            List<string> uf = new List<string>();

        
            if (this.conectar())
            {
                try
                {
                    objcmd = new SqlCommand(vsql, objCon);
                    SqlDataReader dr = objcmd.ExecuteReader();

                    while(dr.Read())
                    {
                        uf.Add(dr["UF"].ToString());  
                    }

                    return uf;
                }
                catch (SqlException sqlerr)
                {
                    throw sqlerr; 
                }
                finally
                {
                    this.desconectar();
                }

            }
            else
            {
                return null;
            }
            
        }

        
    public List<string> listaCidade(string uf)
    {
        vsql = "SELECT NOME FROM CIDADE WHERE UF = @UF"; 

            SqlCommand objcmd = null;

            List<string> cidade = new List<string>();

        
            if (this.conectar())
            {
                try
                {
                    objcmd = new SqlCommand(vsql, objCon);
                    objcmd.Parameters.AddWithValue("@UF", uf);
                    SqlDataReader dr = objcmd.ExecuteReader(); 

                    while(dr.Read())
                    {
                        cidade.Add(dr["NOME"].ToString());  
                    }

                    return cidade;
                }
                catch (SqlException sqlerr)
                {
                    throw sqlerr; 
                }
                finally
                {
                    this.desconectar();
                }

            }
            else
            {
                return null;
            }
    }






        }
    }


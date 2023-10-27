using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
/* Bibliotecas para o Banco de Dados*/
using System.Data.SqlClient;
using System.Data;
using System.Xml.Linq;

namespace AppWebAspLoginUsuario
{
    public partial class Dashboard : System.Web.UI.Page
    {
        /* Criação da Conexão com palavras reservados SQL*/
        SqlConnection con = new SqlConnection();
        /* Criação dos comandos cmd SqlCommand com uso de palavras reservadas SQL */
        SqlCommand cmd = new SqlCommand();
        /* Criação do Adaptador */
        SqlDataAdapter sda = new SqlDataAdapter();
        /* Criação da Tabela recebida pelo objeto dt DataTable para suas manipulações */
        DataTable dt = new DataTable();
        /* Criação do objeto de de exibição ds DataSheet */
        DataSet ds = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            /* Caminho da Conexão da string retirado  na propriedade da conexão com o Servidor */
            con.ConnectionString = "Data Source=DELL-M4700\\SQLEXPRESS;Initial Catalog=login;Integrated Security=True";
            /* Abertura da Conexão */
            con.Open();

            
            ObterRequisicaoCookie();
            if (this.Page.Request.Cookies["login"] != null)
            {
                dataShow();
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }

        /* Obtém a Requisição do Cookie */
        public void ObterRequisicaoCookie()
        {

            if (this.Page.Request.Cookies["login"] != null)
            {
                // Obtém a requisição com dos dados do cookie
                HttpCookie cookie = this.Page.Request.Cookies["login"];

                // Recebendo o cookie como String
                lblUser.Text = cookie.Value.ToString();
            }
            else
            {
                // Caso não exista o cookie volta para o Login
                Response.Redirect("~/Login.aspx");
            }
            }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            // Obtém a requisição com dos dados do cookie
            HttpCookie cookie = this.Page.Request.Cookies["id_user"];

            // Recebendo o cookie como String
            int id_user = Convert.ToInt32(cookie.Value);
            con.Open();
            /* Intanciação do objeto dt DataTable*/
            dt = new DataTable();
            /* Comando SQL */
            cmd.CommandText = "UPDATE users  SET email='" + txbEmail.Text.ToString() + "', pass='" + txbPass.Text.ToString() + "' WHERE id_user='"+id_user+"'";
            /* Abre a Conexão */
            cmd.Connection = con;
            /* Executa a Query SQL */
            cmd.ExecuteNonQuery();
            /* Chama a função de Atualização */
            dataShow();

            Response.Write("<script> alert('Update to "+ txbEmail.Text.ToString() + " !');window.location='Logout.aspx';</script>");
            
        }

        /* Classe de exibição dos dados */
        public void dataShow()
        {
            /* Instanciação do objeto ds */
            ds = new DataSet();

            // Obtém a requisição com dos dados do cookie
            HttpCookie cookie = this.Page.Request.Cookies["id_user"];

            // Recebendo o cookie como String
            int id_user = Convert.ToInt32(cookie.Value);
                        
            /* Comando SQL */
            cmd.CommandText = "SELECT * FROM users WHERE id_user='"+id_user+"'";
            /* Conexão com Banco */
            cmd.Connection = con;
            /* Instanciãção do objeto de conexão */
            sda = new SqlDataAdapter(cmd);
            /* Adiciona ou atualiza linhas no DataSet para correspondência na fonte de dados. */
            sda.Fill(ds);
            /* Comando de execução */
            cmd.ExecuteNonQuery();
            /* GridView Students recebe o DataSheet*/
            grvUser.DataSource = ds;
            /* Associa a fonte de dados ao controle GridView.*/
            grvUser.DataBind();
            /* Fecha a Conexão */
            con.Close();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            // Obtém a requisição com dos dados do cookie
            HttpCookie cookie = this.Page.Request.Cookies["id_user"];

            // Recebendo o cookie como String
            int id_user = Convert.ToInt32(cookie.Value);
            con.Open();
            /* Intanciação do objeto dt DataTable*/
            dt = new DataTable();
            /* Comando SQL */
            cmd.CommandText = "DELETE users WHERE id_user='" + id_user + "'";
            /* Abre a Conexão */
            cmd.Connection = con;
            /* Executa a Query SQL */
            cmd.ExecuteNonQuery();
            /* Chama a função de Atualização */
            dataShow();

            Response.Write("<script> alert('DELETED !');window.location='Logout.aspx';</script>");
        }
    }
    }

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/* Bibliotecas para o Banco de Dados*/
using System.Data.SqlClient;
using System.Data;
using Microsoft.Win32;

namespace AppWebAspLoginUsuario
{    
    public partial class Login : System.Web.UI.Page
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
            /* Essa condição serve para que o conteúdo dentro desse if só seja executado na primeira vez */
            if (!Page.IsPostBack)
            {
                /* Chamda da Função de Exibição */
                //dataShow();
            }

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            checkUser();
        }

        public void checkUser()
        {
            /* Instanciação do objeto ds */
            ds = new DataSet();
            /* Comando SQL */
            cmd.CommandText = "SELECT * FROM users WHERE email='" + txbEmail.Text + "' AND pass='"+txbPass.Text+"'";
            /* Conexão com Banco */
            cmd.Connection = con;
            /* Instanciãção do objeto de conexão */
            sda = new SqlDataAdapter(cmd);
            /* Adiciona ou atualiza linhas no DataSet para correspondência na fonte de dados. */
            sda.Fill(ds);
            /* Comando de execução */
            cmd.ExecuteNonQuery();
            /* Carrega o resultado da leitura no Check */
            SqlDataReader check = cmd.ExecuteReader();
            /* GridView Students recebe o DataSheet*/

            if (check.HasRows)
            {
                // Fez a leitura de todas as linha encontradas no banco
                check.Read();
                //Cria o cookie do Login Com email do Banco de Dados
                string loginCookie = check["email"].ToString();
                HttpCookie login = new HttpCookie("login", loginCookie);
                Response.Cookies.Add(login);

                //Cria o cookie do id do usuário
                string IdUserCookie = check["id_user"].ToString();
                // Preaparaçao para o Navegador
                HttpCookie idUser = new HttpCookie("id_user", IdUserCookie);
                // Inserção do cookie no navegador
                Response.Cookies.Add(idUser);                

                //direcionar para a pagina principal
                Response.Redirect("Dashboard.aspx");
            }
            else
            {
                // Alert Javascript
                Response.Write("<script> alert('Email ou Senha Incorretos!');</script>");
                lblMensagem.Text = "E-mail ou Senha Inválidos";
            }
        }
    }
}
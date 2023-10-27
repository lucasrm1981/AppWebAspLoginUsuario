using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
/* Bibliotecas para o Banco de Dados*/
using System.Data.SqlClient;
using System.Data;

namespace AppWebAspLoginUsuario
{
    public partial class Register : System.Web.UI.Page
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
                dataShowUser();
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            /* Intanciação do objeto dt DataTable*/
            dt = new DataTable();
            /* Comando SQL que será executado */
            cmd.CommandText = "INSERT INTO users(email, pass)VALUES('" + txbEmail.Text.ToString() + "', '" + txbPass.Text.ToString() + "')";
            /* Abertura da Conexão pelo cmd */
            cmd.Connection = con;
            /* Execução do Comando*/
            cmd.ExecuteNonQuery();
            /* Chamada da função de exibição */
            dataShowUser();

            txbEmail.Text = txbPass.Text = String.Empty;
        }

        /* Exibe a Informação do Próprio Usuário*/
        public void dataShowUser()
        {
            /* Instanciação do objeto ds */
            ds = new DataSet();
            /* Comando SQL */
            cmd.CommandText = "SELECT * FROM users WHERE email='"+txbEmail.Text+"'";
            /* Conexão com Banco */
            cmd.Connection = con;
            /* Instanciãção do objeto de conexão */
            sda = new SqlDataAdapter(cmd);
            /* Adiciona ou atualiza linhas no DataSet para correspondência na fonte de dados. */
            sda.Fill(ds);
            /* Comando de execução */
            cmd.ExecuteNonQuery();
            /* GridView Students recebe o DataSheet*/
            grvUsers.DataSource = ds;
            /* Associa a fonte de dados ao controle GridView.*/
            grvUsers.DataBind();
            /* Fecha a Conexão */
            con.Close();
        }
    }
}
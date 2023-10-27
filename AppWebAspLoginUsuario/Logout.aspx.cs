using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppWebAspLoginUsuario
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Removendo o Cookie
            Response.Cookies["id_user"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["email"].Expires = DateTime.Now.AddDays(-1);
            
            Response.Redirect("~/Login.aspx");
        }
    }
}
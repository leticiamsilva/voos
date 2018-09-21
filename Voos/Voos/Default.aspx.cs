using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WSVoos;
using System.Web.Services;

namespace Voos
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public string LerVoos()
        {
            WebServiceVoos.WebServiceVoosSoapClient  wsv = new WebServiceVoos.WebServiceVoosSoapClient();
            return wsv.LerVoos();
        }
    }
}
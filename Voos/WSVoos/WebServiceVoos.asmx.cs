using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;
namespace WSVoos
{
    /// <summary>
    /// Descrição resumida de WebServiceVoos
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que esse serviço da web seja chamado a partir do script, usando ASP.NET AJAX, remova os comentários da linha a seguir. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceVoos : System.Web.Services.WebService
    {

        [WebMethod]
        public List<Trajeto> LerVoos()
        {
            List<Trajeto> trajetos = new List<Trajeto>();

            string caminho_arquivo = @"..\DesafioXML.xml";

            //Leitura do arquivo XML
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(caminho_arquivo);

            XmlNodeList xnList = xmlDoc.GetElementsByTagName("disponibilidade");

            for(int i = 0; i < xnList.Count; i++)
            {
                Trajeto t = new Trajeto();

                t.Data = xnList[i]["info"]["datapartida"].InnerText.Trim().Replace("-", "\\");

                string aux_trajeto = "";
                aux_trajeto += xnList[i]["info"]["origem"].InnerText.Trim();
                aux_trajeto += "~" + xnList[i]["info"]["origem"].InnerText.Trim();

                t.Nome = aux_trajeto;

                foreach (XmlElement child in xnList[i])
                {
                    if (child.Name.Equals("viagem"))
                        t.Voos.Add(PegarDadosVoo(xnList[i]["viagem"]));
                }

            }

            return trajetos;
        }

        public Voo PegarDadosVoo(XmlNode xmlNode)
        {
            Voo voo = new Voo();

            foreach (XmlElement child in xmlNode.ChildNodes)
            {
                if (child.Name.ToLower().Equals("tarifas"))
                {
                    foreach (XmlElement childs in xmlNode["tarifas"].ChildNodes)
                    {
                        double tarifaConvertida = 0;
                        try
                        {
                            tarifaConvertida = Convert.ToDouble(childs.InnerText.Trim().Replace(",", "."));
                        }
                        catch
                        {
                            tarifaConvertida = 0;
                        }

                        Tipo tipo = new Tipo();
                        tipo.Nome = childs.Attributes["nome"].Value;
                        tipo.Valor = tarifaConvertida;

                        voo.Tipos.Add(tipo);
                    }
                }

                if (child.Name.Equals("segmento"))
                {
                    foreach (XmlNode xmlSeg in child.ChildNodes)
                    {
                        if (xmlSeg.Name.ToLower().Equals("numerovoo"))
                            voo.Id = xmlSeg.InnerText.Trim();

                        if (xmlSeg.Name.ToLower().Equals("horasaida"))
                            voo.Hora = xmlSeg.InnerText.Trim();
                    }
                }
            }

            return voo;
        
        }
    }
}

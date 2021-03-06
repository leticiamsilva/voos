﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;
using System.Web.Script.Serialization;

namespace WSVoos
{
    /// <summary>
    /// Descrição resumida de WebServiceVoos
    /// </summary>
    [WebService(Namespace = "http://localhost:55069/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que esse serviço da web seja chamado a partir do script, usando ASP.NET AJAX, remova os comentários da linha a seguir. 
    [System.Web.Script.Services.ScriptService]
    public class WebServiceVoos : System.Web.Services.WebService
    {

        [WebMethod]
        public  string LerVoos()
        {
            List<Trajeto> trajetos = new List<Trajeto>();

            string path = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
            string caminho_arquivo = path + "DesafioXML.xml";

            //Leitura do arquivo XML
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(caminho_arquivo);

            XmlNodeList xnList = xmlDoc.GetElementsByTagName("trajeto");

            for(int i = 0; i < xnList.Count; i++)
            {
                Trajeto t = new Trajeto();

                t.Data = xnList[i]["info"]["datapartida"].InnerText.Trim().Replace("-", "/");

                string aux_trajeto = "";
                aux_trajeto += xnList[i]["info"]["origem"].InnerText.Trim();
                aux_trajeto += " ~ " + xnList[i]["info"]["destino"].InnerText.Trim();

                t.Nome = aux_trajeto;

                foreach (XmlElement child in xnList[i])
                {
                    if (child.Name.Equals("viagem"))
                        t.Voos.Add(PegarDadosVoo(xnList[i]["viagem"]));
                }

                trajetos.Add(t);

            }

            var json = new JavaScriptSerializer().Serialize(trajetos);

            return json;
        }

        public  Voo PegarDadosVoo(XmlNode xmlNode)
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
                        tipo.Valor = tarifaConvertida/100;

                       
                        voo.Tipos.Add(tipo);
                        voo.Tipos.Sort();
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

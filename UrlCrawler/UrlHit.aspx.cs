using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using System.Threading;
using System.Xml;

namespace SoftwareDeveloperSolution.UrlCrawler
{
    public partial class UrlHit : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblWebPage.Text = GetHtmlPage(txtWebSitePath.Text);
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //lblWebPage.Text = GetHtmlPage(txtWebSitePath.Text);
            ReadSiteMapFile(sender, e);
        }
        static string GetHtmlPage(string strURL)
        {
            String strResult;
            using (WebClient client = new WebClient())
            {
                strResult = client.DownloadString(strURL);
                //strResult = System.Text.Encoding.UTF8.GetString(data);

                //String strResult;
                //WebResponse objResponse;
                //WebRequest objRequest = HttpWebRequest.Create(strURL);
                //objResponse = objRequest.GetResponse();
                //using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
                //{
                //    strResult = sr.ReadToEnd();
                //    sr.Close();
                //}
            }
            return strResult;
        }

        private void ReadSiteMapFile(object sender, EventArgs e)
        {
            string PageUrl = "", siteMapData = "";
            using (WebClient wc = new WebClient())
            {
                wc.Encoding = System.Text.Encoding.UTF8;
                siteMapData = wc.DownloadString(txtSiteMapPath.Text);
            }
            XmlDocument urldoc = new XmlDocument();
            urldoc.LoadXml(siteMapData);
            XmlNodeList xnList = urldoc.GetElementsByTagName("url");
            /*Loops through the node list and prints the values of each node*/
            foreach (XmlNode node in xnList)
            {
                PageUrl = node["loc"].InnerText;
                lblWebPage.Text += PageUrl + "<br />";
                lblWebPage.Text = GetHtmlPage(PageUrl);
                txtWebSitePath.Text = PageUrl;
                Thread.Sleep(30 * 1000);
            }
            Thread.Sleep(60 * 1000);
            btnSubmit_Click(sender, e);
        }
    }
}
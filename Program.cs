using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel.Web;
using System.ServiceModel;
using ShapeRestServer;

namespace ShapeAndJson
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ShapeDialoge showDialog = new ShapeDialoge();
            WebServiceHost webHost = new WebServiceHost(typeof(RestServer), new Uri("http://localhost:35799/"));
            try
            {
                RestServer.OnAddCircle += showDialog.rest_OnAddCircle;
                //
                //
                //
                webHost.Open();
            }
            catch (CommunicationException cex)
            {
                Console.WriteLine("An exception occurred: {0}", cex.Message);
                webHost.Abort();
            }
            Application.Run(showDialog);
        }
    }
}

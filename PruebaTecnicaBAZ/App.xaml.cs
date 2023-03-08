using PruebaTecnicaBAZ.Rest;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PruebaTecnicaBAZ
{
    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static MainWindow VentanaPrincipal;
        public static RestServicio restServico;
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            VentanaPrincipal = new MainWindow();
            restServico = new RestServicio();

            VentanaPrincipal.Show();
        }

        public async static void ImprimirConsulta()
        {
            string cadenaObjetos = await restServico.GetResultAPI();

            VentanaPrincipal.DespligueInformacion.Text = cadenaObjetos;
        }
    }
}

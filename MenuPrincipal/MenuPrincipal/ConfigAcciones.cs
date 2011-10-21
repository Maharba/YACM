using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Xml;
using System.Configuration;

namespace MenuPrincipal
{
    class ConfigAcciones
    {
        private static Configuration _config;

        private static volatile ConfigAcciones _instancia;

        private ConfigAcciones()
        {
            _config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        }

        private static void CrearArchivoConfig()
        {
            XmlTextWriter.Create(Assembly.GetExecutingAssembly().Location + ".config");
            _config =
                ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            _config.Save();
        }

        public static ConfigAcciones CargarConfiguracion()
        {
            if (_instancia == null)
            {
                lock (typeof(ConfigAcciones))
                {
                    if (_instancia == null)
                    {
                        _instancia = new ConfigAcciones();
                    }
                }
            }
            return _instancia;
        }

        public void ActualizarLlave(string llave, string nuevoValor)
        {
            //_xmlDoc = new XmlDocument();
            //if (!File.Exists(Assembly.GetExecutingAssembly().Location + ".config")) CrearArchivoConfig();
            //_xmlDoc.Load(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\"+ Assembly.GetExecutingAssembly().Location +".config");

            //if (!ExisteLlave(llave))
            //{
            //    throw new ArgumentNullException(string.Format("El campo {0} no existe en el archivo de configuracion.", llave));
            //}
            //XmlNode appSettingsNode = _xmlDoc.SelectSingleNode("configuration/appSettings");

            //foreach (XmlNode childNode in appSettingsNode.Cast<XmlNode>().Where(childNode => childNode.Attributes["key"].Value == llave))
            //{
            //    childNode.Attributes["value"].Value = nuevoValor;
            //}
            //_xmlDoc.Save(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\App.config");
            //_xmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);


            if (!_config.HasFile)
                _config.AppSettings.Settings.Add(llave, nuevoValor);
            else
            {
                if (_config.AppSettings.Settings.AllKeys.Contains<string>(llave))
                    _config.AppSettings.Settings[llave].Value = nuevoValor;
                else
                    _config.AppSettings.Settings.Add(llave, nuevoValor);
            }
        }

        public void Guardar()
        {
            _config.Save(ConfigurationSaveMode.Modified);
        }

        private static bool ExisteLlave(string llave)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\" + Assembly.GetExecutingAssembly().Location + ".config");

            XmlNode appSettingsNode = xmlDoc.SelectSingleNode("configuration/appSettings");

            return appSettingsNode.Cast<XmlNode>().Any(childNode => childNode.Attributes["key"].Value == llave);
        }
    }
}

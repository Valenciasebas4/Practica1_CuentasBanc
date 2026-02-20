using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libCuentaBanc.dll
{
    public abstract class clsCuenta
    {
        #region Atributos
        // se usa protected para los atributos de la clase que va a ser padre y los hijos puedan heredar
        protected int intNroCta;
        protected string strFecCreac;
        protected int intTipoDoc;
        protected int intNroDcto;
        protected string strTitular;
        protected float fltSaldo;
        protected string rutaFile;
        protected string strError;

        #endregion

        #region Propiedades
        // se usa GET para salida y SET para entrada
        public int NroCta { get { return intNroCta; } } 
        public string FecCreac { get { return strFecCreac; } }
        public int TipoDoc { get { return intTipoDoc; } set { intTipoDoc = value; } }
        public int NroDcto { get { return intNroDcto; } set { intNroDcto = value; } }
        public string Titular { get { return strTitular; } set { strTitular = value; } }
        public float FltSaldo { get { return fltSaldo; } set { fltSaldo = value; } }
        public string Error { get { return strError; } set { strError = value; } }
        #endregion

        #region Métodos
        public bool Crear() 
        {
            return false;
        }

        public bool Buscar()
        {
            return true;
        }
        #endregion


    }

    public abstract class clsTipo : clsCuenta 
    {
        #region Métodos
        public abstract bool Deposito(int nroCta, float valor);
        public abstract bool Retiro(int nroCta, float valor);
        #endregion
    }

    public class clsGenerales 
    {
        #region Métodos
        public int UltimoId(string ruta)
        {
            int rpta = -1;
            string carpeta = Path.GetDirectoryName(ruta);

            if (!Directory.Exists(carpeta))
                Directory.CreateDirectory(carpeta);
            if (File.Exists(ruta))
            {
                // 1. Leer todas las lineas del archivo
                string[] lineas = File.ReadAllLines(ruta);
                //2. Verificar si hay lineas en el archivo
                if (lineas.Length > 0)
                {
                    //Opción 3: Obtener el último registro
                    string ultimoRegistro = lineas.LastOrDefault();
                    string[] datos = ultimoRegistro.Split(',');
                    rpta = Convert.ToInt32(datos[0]);
                }
                else
                    rpta = 0;
            }
            return rpta;
        }

        public List<string> leerArchivo(string ruta, int nroCta)
        {
            List<string> rpta = new List<string>();
            try
            {
                string carpeta = Path.GetDirectoryName(ruta);
                // Verificamos si la carpeta existe, o si no, se crea
                if (!Directory.Exists(carpeta))
                    Directory.CreateDirectory(carpeta);
                // Verificamos si el archivo existe, o si no, se crea
                if (!File.Exists(ruta))
                    return rpta;
                string[] lineas = File.ReadAllLines(ruta);
                if (lineas.Length > 0)
                {
                    foreach (string rgtro in lineas)
                    {
                        string[] datos = rgtro.Split(':');
                        if (int.Parse(datos[0]) == nroCta)
                        {
                            rpta.AddRange(datos);
                            break;
                        }
                    }
                }
                return rpta;
            }
            catch
            {
                return rpta;
            }
        }
        #endregion
    }
}

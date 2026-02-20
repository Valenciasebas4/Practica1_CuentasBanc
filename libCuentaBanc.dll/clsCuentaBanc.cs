using System;
using System.Collections.Generic;
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
}

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



    }
}

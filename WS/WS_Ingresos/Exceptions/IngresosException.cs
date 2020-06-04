using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WS_Ingresos.Exceptions
{
    [Serializable]
    public class IngresosException:BaseException
    {
        public IngresosException(string message, params object[] args) : base(message, args) { }
        public IngresosException(Exception innerException, string message, params object[] args) : base(message, innerException) { }
    }
}
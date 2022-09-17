using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prj_schoon_pais.cls
{
    static class clsConexao 
    {
        public static string linhaConexao = "SERVER=localhost;UID=root;PASSWORD=root;DATABASE=prjschoon";
        
        public static string getConexao()
        {
            return linhaConexao;
        }

    }
}
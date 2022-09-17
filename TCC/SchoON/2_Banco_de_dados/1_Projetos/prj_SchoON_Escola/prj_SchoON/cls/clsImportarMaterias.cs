using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Globalization;
using System.Threading;

namespace prj_SchoON.cls
{
    public class clsImportarMaterias:clsBanco
    {




        public bool enviar_materia(string codigo_materia, string qt_aula_total, string qt_trimestre, string qt_aula_semanal, string nome_materia)
        {
            /*vCodigo_Materia int(11),vQt_Total_Aula_Materia int(11),vQt_Semanal_Aula_Materia int(11),vNome_Materia varchar(100));/*/
            MySqlDataReader dados = null;
            string[,] valores = new string[5, 2];
            valores[0, 0] = "vCodigo_Materia";
            valores[0, 1] = codigo_materia;
            valores[1, 0] = "vQt_Total_Aula_Materia";
            valores[1, 1] = qt_aula_total;
            valores[2, 0] = "vTrimestre";
            valores[2, 1] = qt_trimestre;
            valores[3, 0] = "vQt_Semanal_Aula_Materia";
            valores[3, 1] = qt_aula_semanal;
            valores[4, 0] = "vNome_Materia";
            valores[4, 1] = nome_materia;
    


            List<string> email_recebidos = new List<string>();

            if (!ConsultaPorSP("inserir_materia", valores, ref dados))
            {
                FecharConexao();
                return false;
            }

            return true;

        }



    }
}
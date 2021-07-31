using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCCME.Models
{
    public class ConexaoBD
    {
        private static bdTCCEntities conexao;

        public static bdTCCEntities getBanco()
        {
            if (conexao == null)
            {
                conexao = new bdTCCEntities();

            }
            return conexao;
        }
    }
}
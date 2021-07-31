using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCCME.Models;

namespace TCCME.DAO
{
    public class CategoriaDAO
    {
        bdTCCEntities conexao;

        public CategoriaDAO()
        {
            conexao = new bdTCCEntities();
        }

        public List<Categoria> getTodasCategorias()
        {
            return conexao.Categoria.ToList();
        }
    }
}
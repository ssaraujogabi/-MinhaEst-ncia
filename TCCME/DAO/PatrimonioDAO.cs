using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TCCME.Models;

namespace TCCME.DAO
{
    public class PatrimonioDAO
    {
        bdTCCEntities conexao;

        public PatrimonioDAO()
        {
            conexao = ConexaoBD.getBanco();
        }
        public List<Patrimonio> getTodosPatrimonios()
        {
            return conexao.Patrimonio.ToList();
        }
        public void AddPatrimonio(Patrimonio novoPatrimonio)
        {
            conexao.Patrimonio.Add(novoPatrimonio);
            conexao.SaveChanges();
        }
        public void Alterar(Patrimonio atualPatrimonio)
        {
            conexao.Entry(atualPatrimonio).State = EntityState.Modified;
            conexao.SaveChanges();
        }
        public void Remover(Patrimonio patrimonio)
        {
            conexao.Patrimonio.Remove(patrimonio);
            conexao.SaveChanges();
        }
    }
}
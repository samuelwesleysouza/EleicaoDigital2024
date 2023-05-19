using EleicaoRepository;
using EleicaoRepository.ModelsTabelaSql;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EleicaoDigitalAplication.Services
{
    public class ControleCadastroService
    {
        private readonly EleicaoContext _context;

        public ControleCadastroService(EleicaoContext context)
        {
            _context = context;
        }

        public List<TabUsuario> ObterControleCadastroBairro(string bairro)
        {
            try
            {
                var bairroObjeto = _context.Usuarios.AsQueryable();

                if (!string.IsNullOrEmpty(bairro))
                {
                    bairroObjeto = bairroObjeto.Where(u => u.bairro == bairro);
                }

                var listaBairroObjeto= bairroObjeto.ToList();

                return listaBairroObjeto;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving user registrations: {ex.Message}");
                return null;
            }
        }


        public List<TabUsuario> ObterControleCadastroLideranca(string lider)
        {
            try
            {
                var liderobjeto = _context.Usuarios.AsQueryable();
                //AsQueryable() é usado para transformar a tabela de "Usuarios" em um objeto "queryable", que permite realizar consultas e operações de filtragem, ordenação e projeção nos dados.

                if (!string.IsNullOrEmpty(lider))
                //O método string.IsNullOrEmpty() é usado para verificar se uma string é nula ou vazia. 
                {
                    liderobjeto = liderobjeto.Where(TabUsuario => TabUsuario.lider == lider);
                }

                var listaObjetoLider = liderobjeto.ToList();

                return listaObjetoLider;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving user registrations: {ex.Message}");
                return null;
            }
        }
    }
}
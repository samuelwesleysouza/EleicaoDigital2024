using EleicaoDigital.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace EleicaoDigital.Repository.Repository.Pessoa
{
    public class PessoaRepository : IPessoaRepository
    {
        public Context _context;
        public PessoaRepository(Context context)
        {
            _context = context;
        }

        public bool AtualizaPessoa(tabPessoa pessoa)
        {
            try
            {
                _context.tabPessoa.Update(pessoa);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public tabPessoa CadastraPessoa(tabPessoa pessoa)
        {
            _context.tabPessoa.Add(pessoa);
            _context.SaveChanges();
            return pessoa;
        }

        public tabPessoa ObterPessoaPorId(int pessoaId)
        {
            return _context.tabPessoa.FirstOrDefault(p => p.Id == pessoaId);
        }

        public List<tabPessoa> ObterPessoasPorBairro(string bairro)
        {
            return _context.tabPessoa.AsTracking().Where(b => b.Bairro == bairro).ToList();
        }

        public List<tabPessoa> ObterPessoasPorLiderId(int liderId)
        {
            return _context.tabPessoa.AsTracking().Where(b => b.UsuarioResponsavelCodigo == liderId).ToList();
        }

        public List<tabPessoa> ObterPessoas()
        {
            return _context.tabPessoa.AsTracking().ToList();
        }

        public bool RemovePessoa(int pessoaId)
        {
            try
            {
                var pessoa = _context.tabPessoa.FirstOrDefault(p => p.Id == pessoaId);

                if (pessoa is null)
                    return false;

                _context.tabPessoa.Remove(pessoa);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

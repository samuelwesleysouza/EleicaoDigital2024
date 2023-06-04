
using EleicaoDigital.Application.Models.InputModel;
using EleicaoDigital.Application.Models.ViewModel;
using EleicaoDigital.Repository.Entities;
using EleicaoDigital.Repository.Repository.Pessoa;

namespace EleicaoDigital.Application.Services.Pessoa
{
    public class PessoaService : IPessoaService
    {
        private IPessoaRepository _pessoaRepository;

        public PessoaService(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public bool AtualizaPessoa(PessoaRequest pessoa, int usuarioId)
        {
            var pessoaModel = new tabPessoa
            {
                Id = pessoa.Id.Value,
                Email = pessoa.Email,
                Telefone = pessoa.Telefone,
                Bairro = pessoa.Bairro,
                Nome = pessoa.Nome,
                Instagram = pessoa.Instagram,
                DataCadastro = DateTime.Now,
                UsuarioResponsavelCodigo = usuarioId
            };


            return _pessoaRepository.AtualizaPessoa(pessoaModel);
        }

        public PessoaViewModel CadastraPessoa(PessoaRequest pessoa, int usuarioId)
        {
            var pessoaCadastrada = _pessoaRepository.CadastraPessoa(new tabPessoa
            {
                Bairro = pessoa.Bairro,
                DataCadastro = DateTime.Now,
                Instagram = pessoa.Instagram,
                Nome = pessoa.Nome,
                Email = pessoa.Email,
                Telefone = pessoa.Telefone,
                UsuarioResponsavelCodigo = usuarioId
            });


            return new PessoaViewModel
            {
                Id = pessoaCadastrada.Id,
                Bairro = pessoaCadastrada.Bairro,
                Instagram = pessoaCadastrada.Instagram,
                Email = pessoaCadastrada.Email,
                Nome = pessoaCadastrada.Nome,
                Telefone = pessoaCadastrada.Telefone
            };
        }

        public bool RemovePessoa(int pessoaId)
        {
            return _pessoaRepository.RemovePessoa(pessoaId);
        }

        public PessoaViewModel? ObterPessoaPorId(int pessoaId)
        {
            var pessoa = _pessoaRepository.ObterPessoaPorId(pessoaId);

            if (pessoa is null)
                return null;

            return new PessoaViewModel
            {
                Id = pessoa.Id,
                Bairro = pessoa.Bairro,
                Instagram = pessoa.Instagram,
                Email = pessoa.Email,
                Nome = pessoa.Nome,
                Telefone = pessoa.Telefone
            };
        }

        public List<PessoaViewModel> ObterPessoasPorBairro(string bairro)
        {
            return _pessoaRepository.ObterPessoasPorBairro(bairro).Select(p =>
                new PessoaViewModel
                {
                    Id = p.Id,
                    Bairro = p.Bairro,
                    Instagram = p.Instagram,
                    Email = p.Email,
                    Nome = p.Nome,
                    Telefone = p.Telefone

                }).ToList();
        }

        public List<PessoaViewModel> ObterPessoasPorLiderId(int liderId)
        {
            return _pessoaRepository.ObterPessoasPorLiderId(liderId).Select(p =>
                new PessoaViewModel
                {
                    Id = p.Id,
                    Bairro = p.Bairro,
                    Instagram = p.Instagram,
                    Email = p.Email,
                    Nome = p.Nome,
                    Telefone = p.Telefone

                }).ToList();
        }

        public List<PessoaViewModel> ObterPessoas()
        {
            return _pessoaRepository.ObterPessoas().Select(p =>
                new PessoaViewModel
                {
                    Id = p.Id,
                    Bairro = p.Bairro,
                    Instagram = p.Instagram,
                    Email = p.Email,
                    Nome = p.Nome,
                    Telefone = p.Telefone
                }).ToList();
        }
    }
}

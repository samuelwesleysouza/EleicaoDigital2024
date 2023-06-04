using EleicaoDigital.Application.Models.InputModel;
using EleicaoDigital.Application.Models.ViewModel;


namespace EleicaoDigital.Application.Services.Pessoa
{
    public interface IPessoaService
    {
        PessoaViewModel CadastraPessoa(PessoaRequest pessoa, int usuarioId);
        bool AtualizaPessoa(PessoaRequest pessoa, int usuarioId);
        bool RemovePessoa(int pessoaId);
        PessoaViewModel? ObterPessoaPorId(int pessoaId);
        List<PessoaViewModel> ObterPessoasPorBairro(string bairro);
        List<PessoaViewModel> ObterPessoasPorLiderId(int liderId);
        List<PessoaViewModel> ObterPessoas();
    }
}

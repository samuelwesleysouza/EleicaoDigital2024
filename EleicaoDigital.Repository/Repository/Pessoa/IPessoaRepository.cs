using EleicaoDigital.Repository.Entities;


namespace EleicaoDigital.Repository.Repository.Pessoa
{
    public interface IPessoaRepository
    {
        tabPessoa CadastraPessoa(tabPessoa pessoa);
        bool AtualizaPessoa (tabPessoa pessoa);
        bool RemovePessoa(int pessoaId);
        tabPessoa ObterPessoaPorId(int pessoaId);
        List<tabPessoa> ObterPessoasPorBairro(string bairro);
        List<tabPessoa> ObterPessoasPorLiderId(int liderId);
        List<tabPessoa> ObterPessoas();

    }
}

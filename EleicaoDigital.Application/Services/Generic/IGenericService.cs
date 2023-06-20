
namespace EleicaoDigital.Application.Services.Generic
{
    public interface IGenericService<T> where T : class
    {
        T Criar(T model);
        T Editar(T model);
        bool Deletar(T model);
    }
}

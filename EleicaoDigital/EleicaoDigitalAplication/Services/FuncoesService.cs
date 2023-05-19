using EleicaoDigitalAplication.Models.ModelRequest;
using EleicaoDigitalAplication.Models.ModelResponse;
using EleicaoRepository.ModelsTabelaSql;
using EleicaoRepository;
using System;




namespace EleicaoDigitalAplication.Services
{
    public class FuncoesService
    {
        private readonly EleicaoContext _context;

        public FuncoesService(EleicaoContext context)
        {
            _context = context;
        }

        public FuncoesResponse InserirPostTexto(FuncoesRequest request)
        {
            try
            {
                var conferirPost = _context.TabPostUsuario.FirstOrDefault(x => x.text.Equals(request.text));

                if (conferirPost != null)
                {
                    return new FuncoesResponse()
                    {
                        text = null,
                        mensagem = "Texto já cadastrado."
                    };
                }

                var post = new TabPostUsuario()
                {
                    nome = request.nome,
                    text = request.text,
                    datapost = DateTime.Now
                };

                _context.TabPostUsuario.Add(post);
                _context.SaveChanges();

                return new FuncoesResponse()
                {
                    text = post.text,
                    mensagem = "Texto cadastrado com sucesso."
                };
            }
            catch (Exception ex)
            {
                return new FuncoesResponse()
                {
                    text = null,
                    mensagem = "Erro ao cadastrar o texto."
                };
            }
        }
        public List<TabPostUsuario> ObterPostTxt()
        {
            try
            {
                var texto = _context.TabPostUsuario.OrderBy(x => x.text).ToList();
                return texto;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool AtualizarPostTxt(FuncoesRequest request)
        {
            try
            {
                if (!_context.TabPostUsuario.Any(x => x.text == request.text))
                    return false;

                var textDb = _context.TabPostUsuario.FirstOrDefault(x => x.text == request.text);
                if (textDb == null)
                    return false;

                textDb.text = request.text;
                textDb.nome = request.nome;

                _context.TabPostUsuario.Update(textDb);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool RemoverPostTxt(int id)
        {
            try
            {
                var textDb = _context.TabPostUsuario.FirstOrDefault(x => x.id == id);
                if (textDb == null)
                    return false;

                _context.TabPostUsuario.Remove(textDb);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                // Faça o tratamento adequado da exceção, como log ou tratamento específico
                // ...

                return false;
            }
        }
    }
}
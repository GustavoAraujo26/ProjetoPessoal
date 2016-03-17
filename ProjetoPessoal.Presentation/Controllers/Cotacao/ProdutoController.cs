using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using ProjetoPessoal.Application.Interfaces.Cotacao;
using ProjetoPessoal.Domain.Entities.Cotacao;

namespace ProjetoPessoal.Presentation.Controllers.Cotacao
{
    [EnableCors("http://cotacao.gustavodearaujo.com", "*", "*")]
    [RoutePrefix("v1/public")]
    public class ProdutoController : ApiController
    {
        private readonly IProdutoAppService _produtoApp;

        public ProdutoController(IProdutoAppService produtoApp)
        {
            this._produtoApp = produtoApp;
        }

        [HttpGet]
        [Route("produto")]
        public HttpResponseMessage GetProdutos()
        {
            try
            {
                var result = _produtoApp.GetAll();
                if (result == null)
                {
                    var mensagem = string.Format("Não foram localizados produtos no banco de dados!");
                    HttpError erro = new HttpError(mensagem);
                    return Request.CreateResponse(HttpStatusCode.NotFound, erro);
                }
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                var mensagem = string.Format("Houve um erro interno ao buscar os produtos!");
                HttpError erro = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, erro);
            }
        }

        [HttpGet]
        [Route("produto/{id}")]
        public HttpResponseMessage GetProdutoById([FromUri] int id)
        {
            try
            {
                var result = _produtoApp.GetById(id);
                if (result == null)
                {
                    var mensagem = "Não foi localizado o produto solicitado!";
                    HttpError erro = new HttpError(mensagem);
                    return Request.CreateResponse(HttpStatusCode.NotFound, erro);
                }
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                var mensagem = string.Format("Houve um erro interno ao buscar o produto desejado!");
                HttpError erro = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, erro);
            }
        }

        [HttpPost]
        [Route("produto")]
        public HttpResponseMessage PostNovoProduto([FromBody] Produto produto)
        {
            if (produto == null)
            {
                var mensagem = "Não é possível incluir um novo produto com informações nulas!";
                HttpError erro = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.BadRequest, erro);
            }
            try
            {
                _produtoApp.Add(produto);
                var result = produto;
                var response = Request.CreateResponse(HttpStatusCode.Created, result);

                var location = Url.Link("DefaultApi", new { controller = "produto", id = produto.Id });
                response.Headers.Location = new Uri(location);

                return response;
            }
            catch (Exception)
            {
                var mensagem = "Houve um erro interno ao incluir um novo produto no banco de dados!";
                HttpError erro = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, erro);
            }
        }

        [HttpPut]
        [Route("produto/{id}")]
        public HttpResponseMessage PutProduto([FromUri] int id, [FromBody] Produto produto)
        {
            if (produto == null)
            {
                var mensagem = string.Format("Não é possível alterar o produto com informações nulas!");
                HttpError erro = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.BadRequest, erro);
            }
            try
            {
                produto.Id = id;
                _produtoApp.Update(produto);
                var result = produto;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                var mensagem = string.Format("Houve um erro interno ao alterar o produto desejado!");
                HttpError erro = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, erro);
            }
        }

        [HttpDelete]
        [Route("produto/{id}")]
        public HttpResponseMessage DeleteProduto([FromUri] int id)
        {
            try
            {
                var produto = _produtoApp.GetById(id);
                if (produto == null)
                {
                    var mensagem = string.Format("Não foram localizados produtos no banco de dados!");
                    HttpError erro = new HttpError(mensagem);
                    return Request.CreateResponse(HttpStatusCode.NotFound, erro);
                }
                _produtoApp.Remove(produto);
                return Request.CreateResponse(HttpStatusCode.OK, "Produto excluido com sucesso!");
            }
            catch (Exception)
            {
                var mensagem = string.Format("Houve um erro interno ao excluir o produto desejado!");
                HttpError erro = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, erro);
            }
        }

        [HttpGet]
        [Route("produto/buscanome/{nome}")]
        public HttpResponseMessage BuscaPorNome([FromUri] string nome)
        {
            try
            {
                var result = _produtoApp.BuscaPorNome(nome);
                if (result == null)
                {
                    var mensagem = string.Format("Não foi localizado nenhum produto com este nome!");
                    HttpError erro = new HttpError(mensagem);
                    return Request.CreateResponse(HttpStatusCode.NotFound, erro);
                }
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                var mensagem = string.Format("Houve um erro ao buscar o produto desejado!");
                HttpError error = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, error);
            }
        }
    }
}

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
    public class FornecedorController : ApiController
    {
        private readonly IFornecedorAppService _fornecedorApp;

        public FornecedorController(IFornecedorAppService fornecedorApp)
        {
            this._fornecedorApp = fornecedorApp;
        }

        [HttpGet]
        [Route("fornecedor")]
        public HttpResponseMessage GetFornecedores()
        {
            try
            {
                var result = _fornecedorApp.GetAll();
                if (result == null)
                {
                    var mensagem = string.Format("Não foram localizados fornecedores no banco de dados!");
                    HttpError erro = new HttpError(mensagem);
                    return Request.CreateResponse(HttpStatusCode.NotFound, erro);
                }
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                var mensagem = string.Format("Houve um erro interno ao buscar os fornecedores!");
                HttpError erro = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, erro);
            }
        }

        [HttpGet]
        [Route("fornecedor/{id}")]
        public HttpResponseMessage GetFornecedorById([FromUri] int id)
        {
            try
            {
                var result = _fornecedorApp.GetById(id);
                if (result == null)
                {
                    var mensagem = "Não foi localizado o fornecedor solicitado!";
                    HttpError erro = new HttpError(mensagem);
                    return Request.CreateResponse(HttpStatusCode.NotFound, erro);
                }
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                var mensagem = string.Format("Houve um erro interno ao buscar o fornecedor desejado!");
                HttpError erro = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, erro);
            }
        }

        [HttpPost]
        [Route("fornecedor")]
        public HttpResponseMessage PostNovoFornecedor([FromBody] Fornecedor fornecedor)
        {
            if (fornecedor == null)
            {
                var mensagem = "Não é possível incluir um novo fornecedor com informações nulas!";
                HttpError erro = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.BadRequest, erro);
            }
            try
            {
                _fornecedorApp.Add(fornecedor);
                var result = fornecedor;
                var response = Request.CreateResponse(HttpStatusCode.Created, result);

                var location = Url.Link("DefaultApi", new { controller = "fornecedor", id = fornecedor.Id });
                response.Headers.Location = new Uri(location);

                return response;
            }
            catch (Exception)
            {
                var mensagem = "Houve um erro interno ao incluir um novo fornecedor no banco de dados!";
                HttpError erro = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, erro);
            }
        }

        [HttpPut]
        [Route("fornecedor/{id}")]
        public HttpResponseMessage PutFornecedor([FromUri] int id, [FromBody] Fornecedor fornecedor)
        {
            if (fornecedor == null)
            {
                var mensagem = string.Format("Não é possível alterar o fornecedor com informações nulas!");
                HttpError erro = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.BadRequest, erro);
            }
            try
            {
                fornecedor.Id = id;
                _fornecedorApp.Update(fornecedor);
                var result = fornecedor;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                var mensagem = string.Format("Houve um erro interno ao alterar o fornecedor desejado!");
                HttpError erro = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, erro);
            }
        }

        [HttpDelete]
        [Route("fornecedor/{id}")]
        public HttpResponseMessage DeleteFornecedor([FromUri] int id)
        {
            try
            {
                var fornecedor = _fornecedorApp.GetById(id);
                if (fornecedor == null)
                {
                    var mensagem = string.Format("Não foram localizados fornecedores no banco de dados!");
                    HttpError erro = new HttpError(mensagem);
                    return Request.CreateResponse(HttpStatusCode.NotFound, erro);
                }
                _fornecedorApp.Remove(fornecedor);
                return Request.CreateResponse(HttpStatusCode.OK, "fornecedor excluido com sucesso!");
            }
            catch (Exception)
            {
                var mensagem = string.Format("Houve um erro interno ao excluir o fornecedor desejado!");
                HttpError erro = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, erro);
            }
        }

        [HttpGet]
        [Route("fornecedor/lista/{id}")]
        public HttpResponseMessage ListaDeRepresentantes([FromUri] int id)
        {
            try
            {
                var result = _fornecedorApp.ListaRepresentantesPorFornecedor(id);
                if (result == null)
                {
                    var mensagem = string.Format("Não foram localizados os fornecedores no banco de dados!");
                    HttpError erro = new HttpError(mensagem);
                    return Request.CreateResponse(HttpStatusCode.NotFound, erro);
                }
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                var mensagem = string.Format("Houve um erro interno ao buscar os fornecedores desejados!");
                HttpError erro = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, erro);
            }
        }
    }
}

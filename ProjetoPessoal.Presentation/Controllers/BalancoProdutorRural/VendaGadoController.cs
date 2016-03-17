using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using ProjetoPessoal.Application.Interfaces.BalancoProdutorRural;
using ProjetoPessoal.Domain.Entities.BalancoProdutorRural;

namespace ProjetoPessoal.Presentation.Controllers.BalancoProdutorRural
{
    [EnableCors("http://balanco.gustavodearaujo.com", "*", "*")]
    [RoutePrefix("v1/public")]
    public class VendaGadoController : ApiController
    {
        private readonly IVendaGadoAppService _vendaGadoApp;

        public VendaGadoController(IVendaGadoAppService vendaGadoApp)
        {
            this._vendaGadoApp = vendaGadoApp;
        }

        [HttpGet]
        [Route("vendagado")]
        public HttpResponseMessage GetVendas()
        {
            try
            {
                var result = _vendaGadoApp.GetAll();
                if (result == null)
                {
                    var mensagem = string.Format("Não foram encontradas vendas no banco de dados!");
                    HttpError erro = new HttpError(mensagem);
                    return Request.CreateResponse(HttpStatusCode.NotFound, erro);
                }
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                    "Houve um problema ao buscar as vendas!");
            }
        }

        [HttpGet]
        [Route("vendagado/{id}")]
        public HttpResponseMessage GetVendaById([FromUri]int id)
        {
            try
            {
                var result = _vendaGadoApp.GetById(id);
                if (result == null)
                {
                    var mensagem = string.Format("Não foi encontrada a venda no banco de dados!");
                    HttpError erro = new HttpError(mensagem);
                    return Request.CreateResponse(HttpStatusCode.NotFound, mensagem);
                }
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                    "Houve um erro ao buscar a venda {0} no banco de dados!");
            }
        }

        [HttpPost]
        [Route("vendagado")]
        public HttpResponseMessage PostNovaVenda([FromBody] VendaGado vendaGado)
        {
            if (vendaGado == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest,
                    "Não é possível incluir uma venda em branco!");
            }
            try
            {
                _vendaGadoApp.Add(vendaGado);
                var result = vendaGado;
                var response = Request.CreateResponse(HttpStatusCode.Created, result);

                string location = Url.Link("DefaultApi", new { controller = "vendagado", id = vendaGado.Id });
                response.Headers.Location = new Uri(location);

                return response;
            }
            catch (Exception)
            {
                var mensagem = string.Format("Houve um erro interno ao incluir a venda desejada!");
                HttpError erro = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, erro);
            }
        }

        [HttpPut]
        [Route("vendagado/{id}")]
        public HttpResponseMessage PutVenda([FromUri] int id, [FromBody] VendaGado vendaGado)
        {
            if (vendaGado == null)
            {
                var mensagem = string.Format("Não é possível alterar a venda com informações nulas!");
                HttpError erro = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.BadRequest, erro);
            }
            try
            {
                vendaGado.Id = id;
                _vendaGadoApp.Update(vendaGado);
                var result = vendaGado;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                var mensagem = string.Format("Houve um erro interno ao alterar a venda desejada!");
                HttpError erro = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, erro);
            }
        }

        [HttpDelete]
        [Route("vendagado/{id}")]
        public HttpResponseMessage DeleteVenda([FromUri] int id)
        {
            try
            {
                var venda = _vendaGadoApp.GetById(id);
                _vendaGadoApp.Remove(venda);
                return Request.CreateResponse(HttpStatusCode.OK, "Venda excluida com sucesso!");
            }
            catch (Exception)
            {
                var mensagem = string.Format("Houve um erro ao excluir a venda desejado!");
                HttpError erro = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, erro);
            }
        }

        [HttpGet]
        [Route("vendagado/balanco/{produtorId}/{ano}")]
        public HttpResponseMessage BalancoDeVendas([FromUri] int produtorId, [FromUri] int ano)
        {
            try
            {
                var result = _vendaGadoApp.VendasPorProdutorEAno(produtorId, ano);
                if (result == null)
                {
                    var mensagem = string.Format("Não foram encontradas as vendas no banco de dados!");
                    HttpError erro = new HttpError(mensagem);
                    return Request.CreateResponse(HttpStatusCode.NotFound, mensagem);
                }
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                    "Houve um erro ao buscar as vendas no banco de dados!");
            }
        }
    }
}

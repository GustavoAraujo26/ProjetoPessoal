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
    public class CompraGadoController : ApiController
    {
        private readonly ICompraGadoAppService _compraGadoApp;

        public CompraGadoController(ICompraGadoAppService compraGadoApp)
        {
            this._compraGadoApp = compraGadoApp;
        }

        [HttpGet]
        [Route("compragado")]
        public HttpResponseMessage GetCompras()
        {
            try
            {
                var result = _compraGadoApp.GetAll();
                if (result == null)
                {
                    var mensagem = string.Format("Não foram encontradas compras no banco de dados!");
                    HttpError erro = new HttpError(mensagem);
                    return Request.CreateResponse(HttpStatusCode.NotFound, erro);
                }
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                    "Houve um problema ao buscar as compras!");
            }
        }

        [HttpGet]
        [Route("compragado/{id}")]
        public HttpResponseMessage GetCompraById([FromUri]int id)
        {
            try
            {
                var result = _compraGadoApp.GetById(id);
                if (result == null)
                {
                    var mensagem = string.Format("Não foi encontrada a compra no banco de dados!");
                    HttpError erro = new HttpError(mensagem);
                    return Request.CreateResponse(HttpStatusCode.NotFound, mensagem);
                }
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                    "Houve um erro ao buscar a compra {0} no banco de dados!");
            }
        }

        [HttpPost]
        [Route("compragado")]
        public HttpResponseMessage PostNovaCompra([FromBody] CompraGado compraGado)
        {
            if (compraGado == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest,
                    "Não é possível incluir uma compra em branco!");
            }
            try
            {
                _compraGadoApp.Add(compraGado);
                var result = compraGado;
                var response = Request.CreateResponse(HttpStatusCode.Created, result);

                string location = Url.Link("DefaultApi", new { controller = "compragado", id = compraGado.Id });
                response.Headers.Location = new Uri(location);

                return response;
            }
            catch (Exception)
            {
                var mensagem = string.Format("Houve um erro interno ao incluir a compra desejada!");
                HttpError erro = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, erro);
            }
        }

        [HttpPut]
        [Route("compragado/{id}")]
        public HttpResponseMessage PutCompra([FromUri] int id, [FromBody] CompraGado compraGado)
        {
            if (compraGado == null)
            {
                var mensagem = string.Format("Não é possível alterar a compra com informações nulas!");
                HttpError erro = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.BadRequest, erro);
            }
            try
            {
                compraGado.Id = id;
                _compraGadoApp.Update(compraGado);
                var result = compraGado;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                var mensagem = string.Format("Houve um erro interno ao alterar a compra desejada!");
                HttpError erro = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, erro);
            }
        }

        [HttpDelete]
        [Route("compragado/{id}")]
        public HttpResponseMessage DeleteCompra([FromUri] int id)
        {
            try
            {
                var compra = _compraGadoApp.GetById(id);
                _compraGadoApp.Remove(compra);
                return Request.CreateResponse(HttpStatusCode.OK, "Compra excluida com sucesso!");
            }
            catch (Exception)
            {
                var mensagem = string.Format("Houve um erro ao excluir a compra desejado!");
                HttpError erro = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, erro);
            }
        }

        [HttpGet]
        [Route("compragado/balanco/{produtorId}/{ano}")]
        public HttpResponseMessage BalancoDeCompras([FromUri] int produtorId, [FromUri] int ano)
        {
            try
            {
                var result = _compraGadoApp.ComprasPorProdutorEAno(produtorId, ano);
                if (result == null)
                {
                    var mensagem = string.Format("Não foram encontradas as compras no banco de dados!");
                    HttpError erro = new HttpError(mensagem);
                    return Request.CreateResponse(HttpStatusCode.NotFound, mensagem);
                }
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                    "Houve um erro ao buscar as compras no banco de dados!");
            }
        }
    }
}

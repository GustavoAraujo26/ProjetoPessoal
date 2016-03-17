using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Castle.Core.Internal;
using ProjetoPessoal.Application.Interfaces.Agenda;
using ProjetoPessoal.Domain.Entities.Agenda;

namespace ProjetoPessoal.Presentation.Controllers.Agenda
{
    [RoutePrefix("v1/public")]
    public class AtividadeController : ApiController
    {
        private readonly IAtividadeAppService _atividadeApp;

        public AtividadeController(IAtividadeAppService atividadeApp)
        {
            this._atividadeApp = atividadeApp;
        }

        [HttpGet]
        [Route("atividade")]
        public HttpResponseMessage GetAtividades()
        {
            try
            {
                var result = _atividadeApp.GetAll();
                if (result.IsNullOrEmpty())
                {
                    var mensagem = string.Format("Não foram encontradas atividades no banco de dados!");
                    HttpError erro = new HttpError(mensagem);
                    return Request.CreateResponse(HttpStatusCode.NotFound, erro);
                }
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                    "Houve um problema ao buscar as atividades!");
            }
        }

        [HttpGet]
        [Route("atividade/{id}")]
        public HttpResponseMessage GetAtividadeById([FromUri]int id)
        {
            try
            {
                var result = _atividadeApp.GetById(id);
                if (result == null)
                {
                    var mensagem = string.Format("Não foi encontrada a atividade no banco de dados!");
                    HttpError erro = new HttpError(mensagem);
                    return Request.CreateResponse(HttpStatusCode.NotFound, mensagem);
                }
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                    "Houve um erro ao buscar a atividade {0} no banco de dados!");
            }
        }

        [HttpPost]
        [Route("atividade")]
        public HttpResponseMessage PostNovaAtividade([FromBody] Atividade atividade)
        {
            if (atividade == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, 
                    "Não é possível incluir uma atividade em branco!");
            }
            try
            {
                _atividadeApp.Add(atividade);
                var result = atividade;
                var response = Request.CreateResponse(HttpStatusCode.Created, result);

                string location = Url.Link("DefaultApi", new { controller = "atividade", id = atividade.Id });
                response.Headers.Location = new Uri(location);

                return response;
            }
            catch (Exception)
            {
                var mensagem = string.Format("Houve um erro interno ao incluir a atividade desejado!");
                HttpError erro = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, erro);
            }
        }

        [HttpPut]
        [Route("atividade/{id}")]
        public HttpResponseMessage PutAtividade([FromUri] int id, [FromBody] Atividade atividade)
        {
            if (atividade == null)
            {
                var mensagem = string.Format("Não é possível alterar a atividade com informações nulas!");
                HttpError erro = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.BadRequest, erro);
            }
            try
            {
                atividade.Id = id;
                _atividadeApp.Update(atividade);
                var result = atividade;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                var mensagem = string.Format("Houve um erro interno ao alterar a atividade desejado!");
                HttpError erro = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, erro);
            }
        }

        [HttpPatch]
        [Route("atividade/{id}")]
        public HttpResponseMessage PatchAtividade([FromUri] int id, [FromBody] Atividade atividade)
        {
            if (atividade == null)
            {
                var mensagem = string.Format("Não é possível alterar a atividade com informações nulas!");
                HttpError erro = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.BadRequest, erro);
            }
            try
            {
                atividade.Id = id;
                _atividadeApp.Update(atividade);
                var result = atividade;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                var mensagem = string.Format("Houve um erro interno ao alterar a atividade desejado!");
                HttpError erro = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, erro);
            }
        }

        [HttpDelete]
        [Route("atividade/{id}")]
        public HttpResponseMessage DeleteAtividade([FromUri] int id)
        {
            try
            {
                var atividade = _atividadeApp.GetById(id);
                _atividadeApp.Remove(atividade);
                return Request.CreateResponse(HttpStatusCode.OK, "Atividade excluida com sucesso!");
            }
            catch (Exception)
            {
                var mensagem = string.Format("Houve um erro ao excluir a atividade desejado!");
                HttpError erro = new HttpError(mensagem);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, erro);
            }
        }

        [HttpGet]
        [Route("atividade/realizada/perfil/{id}")]
        public HttpResponseMessage AtividadesRealizadas([FromUri] int id)
        {
            try
            {
                var result = _atividadeApp.AtividadesRealizadas(id);
                if (result.IsNullOrEmpty())
                {
                    var mensagem = string.Format("Não foram encontradas as atividades no banco de dados!");
                    HttpError erro = new HttpError(mensagem);
                    return Request.CreateResponse(HttpStatusCode.NotFound, mensagem);
                }
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                    "Houve um erro ao buscar as atividades no banco de dados!");
            }
        }

        [HttpGet]
        [Route("atividade/naorealizada/perfil/{id}")]
        public HttpResponseMessage AtividadesNaoRealizadas([FromUri] int id)
        {
            try
            {
                var result = _atividadeApp.AtividadesNaoRealizadas(id);
                if (result.IsNullOrEmpty())
                {
                    var mensagem = string.Format("Não foram encontradas as atividades no banco de dados!");
                    HttpError erro = new HttpError(mensagem);
                    return Request.CreateResponse(HttpStatusCode.NotFound, mensagem);
                }
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                    "Houve um erro ao buscar as atividades no banco de dados!");
            }
        }
    }
}

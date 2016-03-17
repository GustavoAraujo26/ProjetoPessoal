using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using ProjetoPessoal.Application.Interfaces.ListaTelefonica;
using ProjetoPessoal.Domain.Entities.ListaTelefonica;

namespace ProjetoPessoal.Presentation.Controllers.ListaTelefonica
{
    [RoutePrefix("v1/public")]
    public class ContatoTelefonicoController : ApiController
    {
        private readonly IContatoTelefonicoAppService _contatoTelefonicoApp;

        public ContatoTelefonicoController(IContatoTelefonicoAppService contatoTelefonicoApp)
        {
            this._contatoTelefonicoApp = contatoTelefonicoApp;
        }

        [HttpGet]
        [Route("contatotelefonico")]
        public HttpResponseMessage GetContatos()
        {
            try
            {
                var result = _contatoTelefonicoApp.GetAll();
                if (result == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound,
                        "Não foram encontrados contatos no banco de dados!");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, result);
                }
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                    "Houve um problema ao buscar os contatos!");
            }
        }

        [HttpGet]
        [Route("contatotelefonico/{id}")]
        public HttpResponseMessage GetContatosById(int id)
        {
            try
            {
                var result = _contatoTelefonicoApp.GetById(id);
                if (result == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound,
                    "Não foi possível localizar o contato {0}!");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, result);
                }
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                    "Houve um erro ao buscar o contato {0}!");
            }
        }

        [HttpPost]
        [Route("contatotelefonico")]
        public HttpResponseMessage PostNovoContato([FromBody] ContatoTelefonico cTelefonico)
        {
            if (cTelefonico == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "O contato não pode ser nulo!");
            }
            try
            {
                _contatoTelefonicoApp.Add(cTelefonico);
                var result = cTelefonico;
                var response = Request.CreateResponse(HttpStatusCode.Created, result);

                var location = Url.Link("DefaultApi", new {controller = "contatotelefonico", id = cTelefonico.Id});
                response.Headers.Location = new Uri(location);

                return response;
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Erro ao incluir novo contato.");
            }
        }

        [HttpPut]
        [Route("contatotelefonico/{id}")]
        public HttpResponseMessage PutContato([FromUri] int id, [FromBody] ContatoTelefonico cTelefonico)
        {
            if (cTelefonico == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest,
                    "Não é possível alterar o contato com informações nulas!");
            }
            try
            {
                cTelefonico.Id = id;
                _contatoTelefonicoApp.Update(cTelefonico);
                var result = cTelefonico;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Erro ao alterar um novo contato!");
            }
        }

        [HttpPatch]
        [Route("contatotelefonico/{id}")]
        public HttpResponseMessage PatchContato([FromUri] int id, [FromBody] ContatoTelefonico cTelefonico)
        {
            if (cTelefonico == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest,
                    "Não é possível alterar o contato com informações nulas!");
            }
            try
            {
                cTelefonico.Id = id;
                _contatoTelefonicoApp.Update(cTelefonico);
                var result = cTelefonico;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Erro ao alterar um novo contato!");
            }
        }

        [HttpDelete]
        [Route("contatotelefonico/{id}")]
        public HttpResponseMessage DeleteContato([FromUri] int id)
        {
            try
            {
                var objeto = _contatoTelefonicoApp.GetById(id);
                _contatoTelefonicoApp.Remove(objeto);
                return Request.CreateResponse(HttpStatusCode.OK, "Contato excluído com sucesso!");
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                    "Erro ao excluir o contato solicitado!");
            }
        }

        [HttpGet]
        [Route("contatotelefonico/perfil/{perfilId}")]
        public HttpResponseMessage ListaDeContatos([FromUri] int perfilId)
        {
            try
            {
                var result = _contatoTelefonicoApp.ContatosPorPerfil(perfilId);
                if (result == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound,
                        "Não foi possível localizar os contatos do perfil {0}!");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, result);
                }
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                    "Houve um problema ao buscar os contatos!");
            }
        }
    }
}

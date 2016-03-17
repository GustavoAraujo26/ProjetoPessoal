using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using ProjetoPessoal.Application.Interfaces.Perfil;

namespace ProjetoPessoal.Presentation.Controllers.Perfil
{
    [RoutePrefix("v1/public")]
    public class PerfilController : ApiController
    {
        private readonly IPerfilAppService _perfilApp;

        public PerfilController(IPerfilAppService perfilApp)
        {
            this._perfilApp = perfilApp;
        }

        [HttpGet]
        [Route("perfil")]
        public HttpResponseMessage Get()
        {
            var result = _perfilApp.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [Route("perfil/{id}")]
        public HttpResponseMessage GetById([FromUri]int id)
        {
            try
            {
                var result = _perfilApp.GetById(id);
                if (result == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "O perfil solicitado não existe!");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, result);
                }
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Erro ao buscar perfil!");
            }
        }

        [HttpPost]
        [Route("perfil")]
        public HttpResponseMessage PostNovoPerfil([FromBody] Domain.Entities.Perfil.Perfil perfil)
        {
            if (perfil == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "O perfil não pode ser nulo!");
            }
            try
            {
                _perfilApp.Add(perfil);
                var result = perfil;
                var response = Request.CreateResponse(HttpStatusCode.Created, result);

                var location = Url.Link("DefaultApi", new {controller = "perfil", id = perfil.Id});
                response.Headers.Location = new Uri(location);

                return response;
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Erro ao incluir novo perfil.");
            }
        }

        [HttpPatch]
        [Route("perfil/{id}")]
        public HttpResponseMessage PatchPerfil([FromUri] int id, [FromBody] Domain.Entities.Perfil.Perfil perfil)
        {
            if (perfil == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "O perfil não pode ser nulo!");
            }
            try
            {
                perfil.Id = id;
                _perfilApp.Update(perfil);
                var result = perfil;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Erro ao incluir novo perfil.");
            }
        }

        [HttpPut]
        [Route("perfil/{id}")]
        public HttpResponseMessage PutPerfil([FromUri] int id, [FromBody] Domain.Entities.Perfil.Perfil perfil)
        {
            if (perfil == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "O perfil não pode ser nulo!");
            }
            try
            {
                perfil.Id = id;
                _perfilApp.Update(perfil);
                var result = perfil;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Erro ao incluir novo perfil.");
            }
        }

        [HttpDelete]
        [Route("perfil/{id}")]
        public HttpResponseMessage DeletePerfil([FromUri]int id)
        {
            try
            {
                var objeto = _perfilApp.GetById(id);
                _perfilApp.Remove(objeto);
                return Request.CreateResponse(HttpStatusCode.OK, "Perfil excluido com sucesso!");
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Erro ao apagar perfil!");
            }
        }

        [HttpGet]
        [Route("perfil/lista")]
        public HttpResponseMessage ListaPorPerfil()
        {
            try
            {
                var lista = _perfilApp.ListaPorPerfil();
                if (lista == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Não existem perfis cadastrados!");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, lista);
                }
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
        }
    }
}

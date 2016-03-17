using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using ProjetoPessoal.Application.Interfaces.Contato;
using ProjetoPessoal.Domain.Entities.Contato;

namespace ProjetoPessoal.Presentation.Controllers.Contato
{
    [EnableCors("http://gustavodearaujo.com", "*", "*")]
    [RoutePrefix("v1/public")]
    public class ContatoProfissionalController : ApiController
    {
        private readonly IContatoProfissionalAppService _contatoProApp;

        public ContatoProfissionalController(IContatoProfissionalAppService contatoProApp)
        {
            this._contatoProApp = contatoProApp;
        }
        
        [HttpGet]
        [Route("contatoprofissional")]
        public HttpResponseMessage GetContatos()
        {
            try
            {
                var result = _contatoProApp.GetAll();
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
        [Route("contatoprofissional/{id}")]
        public HttpResponseMessage GetContatosById(int id)
        {
            try
            {
                var result = _contatoProApp.GetById(id);
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
        [Route("contatoprofissional")]
        public HttpResponseMessage PostNovoContato([FromBody] ContatoProfissional cPro)
        {
            if (cPro == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "O contato não pode ser nulo!");
            }
            try
            {
                _contatoProApp.Add(cPro);
                var result = cPro;
                var response = Request.CreateResponse(HttpStatusCode.Created, result);

                var location = Url.Link("DefaultApi", new { controller = "contatoprofissional", id = cPro.Id });
                response.Headers.Location = new Uri(location);

                return response;
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Erro ao incluir um novo contato!");
            }
        }
        
        [HttpPut]
        [Route("contatoprofissional/{id}")]
        public HttpResponseMessage PutContato([FromUri] int id, [FromBody] ContatoProfissional cPro)
        {
            if (cPro == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest,
                    "Não é possível alterar o contato com informações nulas!");
            }
            try
            {
                cPro.Id = id;
                _contatoProApp.Update(cPro);
                var result = cPro;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Erro ao alterar um contato!");
            }
        }
        
        [HttpPatch]
        [Route("contatoprofissional/{id}")]
        public HttpResponseMessage PatchContato([FromUri] int id, [FromBody] ContatoProfissional cPro)
        {
            if (cPro == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest,
                    "Não é possível alterar o contato com informações nulas!");
            }
            try
            {
                cPro.Id = id;
                _contatoProApp.Update(cPro);
                var result = cPro;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Erro ao alterar um contato!");
            }
        }
        
        [HttpDelete]
        [Route("contatoprofissional/{id}")]
        public HttpResponseMessage DeleteContato([FromUri] int id)
        {
            try
            {
                var objeto = _contatoProApp.GetById(id);
                _contatoProApp.Remove(objeto);
                return Request.CreateResponse(HttpStatusCode.OK, "Contato excluído com sucesso!");
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                    "Erro ao excluir o contato solicitado!");
            }
        }

        [HttpGet]
        [Route("contatoprofissional/empresa/{nome}")]
        public HttpResponseMessage ListaPorEmpresa([FromUri] string nome)
        {
            try
            {
                var result = _contatoProApp.ListaPorEmpresa(nome);
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
    }
}

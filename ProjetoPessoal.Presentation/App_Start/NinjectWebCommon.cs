using System;
using System.Web;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;
using ProjetoPessoal.Application.Interfaces;
using ProjetoPessoal.Application.Interfaces.Agenda;
using ProjetoPessoal.Application.Interfaces.BalancoProdutorRural;
using ProjetoPessoal.Application.Interfaces.Contato;
using ProjetoPessoal.Application.Interfaces.Cotacao;
using ProjetoPessoal.Application.Interfaces.ListaTelefonica;
using ProjetoPessoal.Application.Interfaces.LivroCaixa;
using ProjetoPessoal.Application.Interfaces.Perfil;
using ProjetoPessoal.Application.Services;
using ProjetoPessoal.Application.Services.Agenda;
using ProjetoPessoal.Application.Services.BalancoProdutorRural;
using ProjetoPessoal.Application.Services.Contato;
using ProjetoPessoal.Application.Services.Cotacao;
using ProjetoPessoal.Application.Services.ListaTelefonica;
using ProjetoPessoal.Application.Services.LivroCaixa;
using ProjetoPessoal.Application.Services.Perfil;
using ProjetoPessoal.Domain.Interfaces.Repositories;
using ProjetoPessoal.Domain.Interfaces.Repositories.Agenda;
using ProjetoPessoal.Domain.Interfaces.Repositories.BalancoProdutorRural;
using ProjetoPessoal.Domain.Interfaces.Repositories.Contato;
using ProjetoPessoal.Domain.Interfaces.Repositories.Cotacao;
using ProjetoPessoal.Domain.Interfaces.Repositories.ListaTelefonica;
using ProjetoPessoal.Domain.Interfaces.Repositories.LivroCaixa;
using ProjetoPessoal.Domain.Interfaces.Repositories.Perfil;
using ProjetoPessoal.Domain.Interfaces.Services;
using ProjetoPessoal.Domain.Interfaces.Services.Agenda;
using ProjetoPessoal.Domain.Interfaces.Services.BalancoProdutorRural;
using ProjetoPessoal.Domain.Interfaces.Services.Contato;
using ProjetoPessoal.Domain.Interfaces.Services.Cotacao;
using ProjetoPessoal.Domain.Interfaces.Services.ListaTelefonica;
using ProjetoPessoal.Domain.Interfaces.Services.LivroCaixa;
using ProjetoPessoal.Domain.Interfaces.Services.Perfil;
using ProjetoPessoal.Infra.Repositories;
using ProjetoPessoal.Infra.Repositories.Agenda;
using ProjetoPessoal.Infra.Repositories.BalancoProdutorRural;
using ProjetoPessoal.Infra.Repositories.Contato;
using ProjetoPessoal.Infra.Repositories.Cotacao;
using ProjetoPessoal.Infra.Repositories.ListaTelefonica;
using ProjetoPessoal.Infra.Repositories.LivroCaixa;
using ProjetoPessoal.Infra.Repositories.Perfil;
using ProjetoPessoal.Presentation.App_Start;
using ProjetoPessoal.Services.Services;
using ProjetoPessoal.Services.Services.Agenda;
using ProjetoPessoal.Services.Services.BalancoProdutorRural;
using ProjetoPessoal.Services.Services.Contato;
using ProjetoPessoal.Services.Services.Cotacao;
using ProjetoPessoal.Services.Services.ListaTelefonica;
using ProjetoPessoal.Services.Services.LivroCaixa;
using ProjetoPessoal.Services.Services.Perfil;
using WebActivatorEx;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NinjectWebCommon), "Start")]
[assembly: ApplicationShutdownMethod(typeof(NinjectWebCommon), "Stop")]

namespace ProjetoPessoal.Presentation.App_Start
{
    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                
                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            //Registrando os meus serviços

            //Registrando IAppService -> AppService
            kernel.Bind(typeof(IAppServiceBase<>)).To(typeof(AppServiceBase<>));
            //Serviço Agenda
            kernel.Bind<IAtividadeAppService>().To<AtividadeAppService>();
            //Serviço BalancoProdutorRural
            kernel.Bind<ICompraGadoAppService>().To<CompraGadoAppService>();
            kernel.Bind<IDespesaGeralAppService>().To<DespesaGeralAppService>();
            kernel.Bind<IFazendaAppService>().To<FazendaAppService>();
            kernel.Bind<IPosseAppService>().To<PosseAppService>();
            kernel.Bind<IProdutorRuralAppService>().To<ProdutorRuralAppService>();
            kernel.Bind<IReceitaGeralAppService>().To<ReceitaGeralAppService>();
            kernel.Bind<IVendaGadoAppService>().To<VendaGadoAppService>();
            kernel.Bind<IVendaLeiteAppService>().To<VendaLeiteAppService>();
            //Serviço Contato
            kernel.Bind<IContatoProfissionalAppService>().To<ContatoProfissionalAppService>();
            //Serviço BalancoProdutorRural
            kernel.Bind<ICotacaoAppService>().To<CotacaoAppService>();
            kernel.Bind<IFornecedorAppService>().To<FornecedorAppService>();
            kernel.Bind<IProdutoAppService>().To<ProdutoAppService>();
            kernel.Bind<IRepresentanteAppService>().To<RepresentanteAppService>();
            //Serviço ListaTelefonica
            kernel.Bind<IContatoTelefonicoAppService>().To<ContatoTelefonicoAppService>();
            //Serviço LivroCaixa
            kernel.Bind<ICreditoCaixaAppService>().To<CreditoCaixaAppService>();
            kernel.Bind<IDebitoCaixaAppService>().To<DebitoCaixaAppService>();
            //Serviço Perfil
            kernel.Bind<IPerfilAppService>().To<PerfilAppService>();

            //Registrando IServiceBase -> ServiceBase
            kernel.Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));
            //Serviço Agenda
            kernel.Bind<IAtividadeService>().To<AtividadeService>();
            //Serviço BalancoProdutorRural
            kernel.Bind<ICompraGadoService>().To<CompraGadoService>();
            kernel.Bind<IDespesaGeralService>().To<DespesaGeralService>();
            kernel.Bind<IFazendaService>().To<FazendaService>();
            kernel.Bind<IPosseService>().To<PosseService>();
            kernel.Bind<IProdutorRuralService>().To<ProdutorRuralService>();
            kernel.Bind<IReceitaGeralService>().To<ReceitaGeralService>();
            kernel.Bind<IVendaGadoService>().To<VendaGadoService>();
            kernel.Bind<IVendaLeiteService>().To<VendaLeiteService>();
            //Serviço Contato
            kernel.Bind<IContatoProfissionalService>().To<ContatoProfissionalService>();
            //Serviço BalancoProdutorRural
            kernel.Bind<ICotacaoService>().To<CotacaoService>();
            kernel.Bind<IFornecedorService>().To<FornecedorService>();
            kernel.Bind<IProdutoService>().To<ProdutoService>();
            kernel.Bind<IRepresentanteService>().To<RepresentanteService>();
            //Serviço ListaTelefonica
            kernel.Bind<IContatoTelefonicoService>().To<ContatoTelefonicoService>();
            //Serviço LivroCaixa
            kernel.Bind<ICreditoCaixaService>().To<CreditoCaixaService>();
            kernel.Bind<IDebitoCaixaService>().To<DebitoCaixaService>();
            //Serviço Perfil
            kernel.Bind<IPerfilService>().To<PerfilService>();

            //Registrando IRepositoryBase -> RepositoryBase
            kernel.Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>));
            //Serviço Agenda
            kernel.Bind<IAtividadeRepository>().To<AtividadeRepository>();
            //Serviço BalancoProdutorRural
            kernel.Bind<ICompraGadoRepository>().To<CompraGadoRepository>();
            kernel.Bind<IDespesaGeralRepository>().To<DespesaGeralRepository>();
            kernel.Bind<IFazendaRepository>().To<FazendaRepository>();
            kernel.Bind<IPosseRepository>().To<PosseRepository>();
            kernel.Bind<IProdutorRuralRepository>().To<ProdutorRuralRepository>();
            kernel.Bind<IReceitaGeralRepository>().To<ReceitaGeralRepository>();
            kernel.Bind<IVendaGadoRepository>().To<VendaGadoRepository>();
            kernel.Bind<IVendaLeiteRepository>().To<VendaLeiteRepository>();
            //Serviço Contato
            kernel.Bind<IContatoProfissionalRepository>().To<ContatoProfissionalRepository>();
            //Serviço BalancoProdutorRural
            kernel.Bind<ICotacaoRepository>().To<CotacaoRepository>();
            kernel.Bind<IFornecedorRepository>().To<FornecedorRepository>();
            kernel.Bind<IProdutoRepository>().To<ProdutoRepository>();
            kernel.Bind<IRepresentanteRepository>().To<RepresentanteRepository>();
            //Serviço ListaTelefonica
            kernel.Bind<IContatoTelefonicoRepository>().To<ContatoTelefonicoRepository>();
            //Serviço LivroCaixa
            kernel.Bind<ICreditoCaixaRepository>().To<CreditoCaixaRepository>();
            kernel.Bind<IDebitoCaixaRepository>().To<DebitoCaixaRepository>();
            //Serviço Perfil
            kernel.Bind<IPerfilRepository>().To<PerfilRepository>();
        }        
    }
}

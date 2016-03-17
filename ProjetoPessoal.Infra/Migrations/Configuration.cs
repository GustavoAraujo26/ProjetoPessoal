using System.Collections;
using System.Collections.Generic;
using ProjetoPessoal.Domain.Entities.Agenda;
using ProjetoPessoal.Domain.Entities.BalancoProdutorRural;
using ProjetoPessoal.Domain.Entities.Contato;
using ProjetoPessoal.Domain.Entities.Cotacao;
using ProjetoPessoal.Domain.Entities.ListaTelefonica;
using ProjetoPessoal.Domain.Entities.LivroCaixa;
using ProjetoPessoal.Domain.Entities.Perfil;
using ProjetoPessoal.Infra.DataContext;

namespace ProjetoPessoal.Infra.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProjetoPessoal.Infra.DataContext.Contexto>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ProjetoPessoal.Infra.DataContext.Contexto context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            
            //Inicializando endereços aleatórios
            Endereco endereco1 = new Endereco { Logradouro = "Rua B", Numero = 283, Complemento = "", Bairro = "Residencial Santa Cruz", Cidade = "Dores do Indaiá", Estado = "MG", Cep = "35.610-000" };
            Endereco endereco2 = new Endereco { Logradouro = "Rua Carijós", Numero = 179, Complemento = "", Bairro = "São José", Cidade = "Dores do Indaiá", Estado = "MG", Cep = "35.610-000" };
            Endereco endereco3 = new Endereco { Logradouro = "Rua São Carlos", Numero = 90, Complemento = "", Bairro = "Centro", Cidade = "Patos de Minas", Estado = "MG", Cep = "39.987.987" };
            Endereco endereco4 = new Endereco { Logradouro = "Rua Demostes Silva", Numero = 1234, Complemento = "", Bairro = "Santa Efigenia", Cidade = "Belo Horizonte", Estado = "MG", Cep = "31.987.098" };
            Endereco endereco5 = new Endereco { Logradouro = "Avenida Francisco Campos", Numero = 849, Complemento = "", Bairro = "Centro", Cidade = "Dores do Indaiá", Estado = "MG", Cep = "35.610-000" };

            //Inicializando contatos aleatórios
            Contato contato1 = new Contato { Email = "gustavo.dearaujo26@gmail.com", Telefone1 = "(37)99033694", Telefone2 = "", Facebook = "https://www.facebook.com/gustavo.dearaujooliveira", LinkedIn = "https://br.linkedin.com/in/gustavodearaujo26" };
            Contato contato2 = new Contato { Email = "joicinha.92@hotmail.com", Telefone1 = "(37)98092421", Telefone2 = "", Facebook = "https://www.facebook.com/joicinha.92", LinkedIn = "https://br.linkedin.com/in/joicinha92" };
            Contato contato3 = new Contato { Email = "adelma.araujo08@gmail.com", Telefone1 = "(37)99345307", Telefone2 = "", Facebook = "https://www.facebook.com/adelma.araujo08", LinkedIn = "https://br.linkedin.com/in/adelma08" };
            Contato contato4 = new Contato { Email = "geraldo.evaldo01@gmail.com", Telefone1 = "(37)98765432", Telefone2 = "", Facebook = "https://www.facebook.com/geraldoevaldo", LinkedIn = "https://br.linkedin.com/in/geraldoevaldo" };
            Contato contato5 = new Contato { Email = "joao.dasilva@gmail.com", Telefone1 = "(37)00000000", Telefone2 = "", Facebook = "https://www.facebook.com/joao.silva", LinkedIn = "https://br.linkedin.com/in/joao.silva" };
            Contato contato6 = new Contato { Email = "newton.pavia@gmail.com", Telefone1 = "(37)98795678", Telefone2 = "", Facebook = "https://www.facebook.com/newton.pavia", LinkedIn = "https://br.linkedin.com/in/newton.pavia" };
            Contato contato7 = new Contato { Email = "gabriel.oliveira@gmail.com", Telefone1 = "(37)87655432", Telefone2 = "", Facebook = "https://www.facebook.com/gabriel.oliveira", LinkedIn = "https://br.linkedin.com/in/gabriel.oliveira" };
            Contato contato8 = new Contato { Email = "jose.silveira@gmail.com", Telefone1 = "(37)45678908", Telefone2 = "", Facebook = "https://www.facebook.com/jose.silveira", LinkedIn = "https://br.linkedin.com/in/jose.silveira" };
            Contato contato9 = new Contato { Email = "vanderlei.gomes@gmail.com", Telefone1 = "(37)21345678", Telefone2 = "", Facebook = "https://www.facebook.com/vanderlei.gomes", LinkedIn = "https://br.linkedin.com/in/vanderlei.gomes" };

            //Namespace Perfil
            context.Perfis.AddOrUpdate(x => x.Id,
                new Perfil { Id = 1, NomeCompleto = "Gustavo de Araujo Oliveira", DataNascimento = DateTime.Parse("26/01/1993"), GrauInstrucao = "Ensino Superior Completo", EstadoCivil = "Solteiro(a)", Sexo = "M", Endereco = endereco1, Contato = contato1 },
                new Perfil { Id = 2, NomeCompleto = "Joice de Oliveira Silva", DataNascimento = DateTime.Parse("22/10/1992"), GrauInstrucao = "Ensino Superior Incompleto", EstadoCivil = "Solteiro(a)", Sexo = "F", Endereco = endereco2, Contato = contato2 },
                new Perfil { Id = 3, NomeCompleto = "Adelma Alves de Araujo", DataNascimento = DateTime.Parse("08/01/1978"), GrauInstrucao = "Ensino Médio Completo", EstadoCivil = "Divorciado(a)", Sexo = "F", Endereco = endereco1, Contato = contato3 },
                new Perfil { Id = 4, NomeCompleto = "Geraldo Evaldo de Oliveira", DataNascimento = DateTime.Parse("01/04/1974"), GrauInstrucao = "Ensino Médio Incompleto", EstadoCivil = "Divorciado(a)", Sexo = "M", Endereco = endereco3, Contato = contato4 },
                new Perfil { Id = 5, NomeCompleto = "João da Silva", DataNascimento = DateTime.Parse("08/07/1967"), GrauInstrucao = "Ensino Superior Completo", EstadoCivil = "Casado(a)", Sexo = "M", Endereco = endereco4, Contato = contato5 },
                new Perfil { Id = 6, NomeCompleto = "Newton Pavia", DataNascimento = DateTime.Parse("27/12/1971"), GrauInstrucao = "Ensino Superior Completo", EstadoCivil = "Viúvo(a)", Sexo = "M", Endereco = endereco5, Contato = contato6 },
                new Perfil { Id = 7, NomeCompleto = "Gabriel de Oliveira Silva", DataNascimento = DateTime.Parse("20/03/2005"), GrauInstrucao = "Ensino Fundamental Incompleto", EstadoCivil = "Solteiro(a)", Sexo = "M", Endereco = endereco4, Contato = contato7 },
                new Perfil { Id = 8, NomeCompleto = "Vanderlei Gomes de Sales", DataNascimento = DateTime.Parse("05/06/1990"), GrauInstrucao = "Ensino Médio Completo", EstadoCivil = "Solteiro(a)", Sexo = "M", Endereco = endereco5, Contato = contato8 });
            
            //Namespace Cotacao
            context.Produtos.AddOrUpdate(x => x.Id,
                new Produto { Id = 1, Nome = "Ultrabook S46C", Marca = "Asus", Observacao = "" },
                new Produto { Id = 2, Nome = "Notebook Inspiron 15R", Marca = "Dell", Observacao = "" },
                new Produto { Id = 3, Nome = "Smartphone Z3+", Marca = "Sony", Observacao = "" },
                new Produto { Id = 4, Nome = "Smartphone Z3 Compact", Marca = "Asus",  Observacao = "" },
                new Produto { Id = 5, Nome = "Smartphone Gran Prime Duos", Marca = "Samsung", Observacao = "" });

            context.Fornecedores.AddOrUpdate(x => x.Id,
                new Fornecedor { Id = 1, RazaoSocial = "Empresa 01", Cnpj = "00.000.000/0000-00", InscricaoEstadual = "0000", Observacao = "", Endereco = endereco5, Contato = contato6 },
                new Fornecedor { Id = 2, RazaoSocial = "Empresa 02", Cnpj = "22.222.222/2222-22", InscricaoEstadual = "2222", Observacao = "", Endereco = endereco4, Contato = contato7 },
                new Fornecedor { Id = 3, RazaoSocial = "Empresa 03", Cnpj = "33.333.333/3333-33", InscricaoEstadual = "3333", Observacao = "", Endereco = endereco3, Contato = contato8 },
                new Fornecedor { Id = 4, RazaoSocial = "Empresa 04", Cnpj = "44.444.444/4444-44", InscricaoEstadual = "4444", Observacao = "", Endereco = endereco5, Contato = contato9 },
                new Fornecedor { Id = 5, RazaoSocial = "Empresa 05", Cnpj = "55.555.555/5555-55", InscricaoEstadual = "5555", Observacao = "", Endereco = endereco4, Contato = contato5 });
            
            context.Representantes.AddOrUpdate(x => x.Id,
                new Domain.Entities.Cotacao.Representante { Id = 1, Nome = "João Sales", Apelido = "João Bobão", Observacao = "", Contato = contato9, FornecedorId = 1 },
                new Domain.Entities.Cotacao.Representante { Id = 2, Nome = "Carlos Antonio", Apelido = "Carlinhos", Observacao = "", Contato = contato8, FornecedorId = 2 },
                new Domain.Entities.Cotacao.Representante { Id = 3, Nome = "Felipe Nogueira", Apelido = "Felipinho", Observacao = "", Contato = contato7, FornecedorId = 3 },
                new Domain.Entities.Cotacao.Representante { Id = 4, Nome = "Júlio Santos", Apelido = "Julinho", Observacao = "", Contato = contato6, FornecedorId = 4 },
                new Domain.Entities.Cotacao.Representante { Id = 5, Nome = "Daniel Gabeira", Apelido = "Dani", Observacao = "", Contato = contato5, FornecedorId = 5 });
            
            context.Cotacoes.AddOrUpdate(x => x.Id,
                new Cotacao { Id = 1, Data = DateTime.Now, ProdutoId = 1, RepresentanteId = 1, Qtd = 15, PrecoSugerido = decimal.Parse("2100,0"), Observacao = "" },
                new Cotacao { Id = 2, Data = DateTime.Today.AddDays(1), ProdutoId = 1, RepresentanteId = 2, Qtd = 10, PrecoSugerido = decimal.Parse("2350,0"), Observacao = "" },
                new Cotacao { Id = 3, Data = DateTime.Now, ProdutoId = 1, RepresentanteId = 3, Qtd = 5, PrecoSugerido = decimal.Parse("3000,0"), Observacao = "" },
                new Cotacao { Id = 4, Data = DateTime.Now, ProdutoId = 1, RepresentanteId = 4, Qtd = 16, PrecoSugerido = decimal.Parse("3200,0"), Observacao = "" },
                new Cotacao { Id = 5, Data = DateTime.Now, ProdutoId = 1, RepresentanteId = 5, Qtd = 19, PrecoSugerido = decimal.Parse("2200,0"), Observacao = "" },
                new Cotacao { Id = 6, Data = DateTime.Now, ProdutoId = 3, RepresentanteId = 1, Qtd = 19, PrecoSugerido = decimal.Parse("2000,0"), Observacao = ""  },
                new Cotacao { Id = 7, Data = DateTime.Now,  ProdutoId = 3, RepresentanteId = 2, Qtd = 19, PrecoSugerido = decimal.Parse("2200,0"), Observacao = "" },
                new Cotacao { Id = 8, Data = DateTime.Now, ProdutoId = 3, RepresentanteId = 3, Qtd = 19, PrecoSugerido = decimal.Parse("2200,0"), Observacao = "" },
                new Cotacao { Id = 9, Data = DateTime.Now, ProdutoId = 3, RepresentanteId = 4, Qtd = 19, PrecoSugerido = decimal.Parse("2200,0"), Observacao = "" },
                new Cotacao { Id = 10, Data = DateTime.Now, ProdutoId = 3, RepresentanteId = 5, Qtd = 19, PrecoSugerido = decimal.Parse("2200,0"), Observacao = "" });

            //Namespace ListaTelefonica
            context.ContatosTelefonicos.AddOrUpdate(x => x.Id, 
                new ContatoTelefonico { Id = 1, Nome = "Contato 1", Apelido = "Apelido 1", Cargo = "Cargo 1", Empresa = "Empresa 1", PerfilId = 1, Endereco = endereco5, Contato = contato8 },
                new ContatoTelefonico { Id = 2, Nome = "Contato 2", Apelido = "Apelido 2", Cargo = "Cargo 2", Empresa = "Empresa 2", PerfilId = 1, Endereco = endereco4, Contato = contato9 },
                new ContatoTelefonico { Id = 3, Nome = "Contato 3", Apelido = "Apelido 3", Cargo = "Cargo 3", Empresa = "Empresa 3", PerfilId = 1, Endereco = endereco3, Contato = contato7 },
                new ContatoTelefonico { Id = 4, Nome = "Contato 4", Apelido = "Apelido 4", Cargo = "Cargo 4", Empresa = "Empresa 4", PerfilId = 1, Endereco = endereco5, Contato = contato6 },
                new ContatoTelefonico { Id = 5, Nome = "Contato 5", Apelido = "Apelido 5", Cargo = "Cargo 5", Empresa = "Empresa 5", PerfilId = 1, Endereco = endereco4, Contato = contato5 },
                new ContatoTelefonico { Id = 6, Nome = "Contato 6", Apelido = "Apelido 6", Cargo = "Cargo 6", Empresa = "Empresa 6", PerfilId = 2, Endereco = endereco3, Contato = contato5 },
                new ContatoTelefonico { Id = 7, Nome = "Contato 7", Apelido = "Apelido 7", Cargo = "Cargo 7", Empresa = "Empresa 7", PerfilId = 2, Endereco = endereco5, Contato = contato6 },
                new ContatoTelefonico { Id = 8, Nome = "Contato 8", Apelido = "Apelido 8", Cargo = "Cargo 8", Empresa = "Empresa 8", PerfilId = 2, Endereco = endereco5, Contato = contato7 },
                new ContatoTelefonico { Id = 9, Nome = "Contato 9", Apelido = "Apelido 9", Cargo = "Cargo 9", Empresa = "Empresa 9", PerfilId = 2, Endereco = endereco5, Contato = contato8 },
                new ContatoTelefonico { Id = 10, Nome = "Contato 10", Apelido = "Apelido 10", Cargo = "Cargo 10", Empresa = "Empresa 10", PerfilId = 2, Endereco = endereco5, Contato = contato9 }); 

            //NamespaceAgenda
            context.Atividades.AddOrUpdate(x => x.Id, 
                new Atividade { Id = 1, DataInicio = DateTime.Now, DataFinal = DateTime.Now.AddDays(1), Realizado = false, Assunto = "Desenvolver os controllers", Descricao = "Desenvolver os controllers da aplicação", PerfilId = 1, ContatoTelefonicoId = 1 },
                new Atividade { Id = 2, DataInicio = DateTime.Now, DataFinal = DateTime.Now.AddDays(1), Realizado = false, Assunto = "Desenvolver o layout", Descricao = "Desenvolver o layout da aplicação", PerfilId = 1, ContatoTelefonicoId = 2 },
                new Atividade { Id = 3, DataInicio = DateTime.Now, DataFinal = DateTime.Now.AddDays(1), Realizado = false, Assunto = "Desenvolver o javascript", Descricao = "Desenvolver o javascript da aplicação", PerfilId = 1, ContatoTelefonicoId = 3 },
                new Atividade { Id = 4, DataInicio = DateTime.Now, DataFinal = DateTime.Now.AddDays(1), Realizado = false, Assunto = "Desenvolver os testes", Descricao = "Desenvolver os testes da aplicação", PerfilId = 1, ContatoTelefonicoId = null },
                new Atividade { Id = 5, DataInicio = DateTime.Now, DataFinal = DateTime.Now.AddDays(1), Realizado = false, Assunto = "Publicar", Descricao = "Publicar a aplicação", PerfilId = 1, ContatoTelefonicoId = null });

            //Namespace LivroCaixa
            context.CreditosCaixa.AddOrUpdate(x => x.Id,
                new CreditoCaixa { Id = 1, Data = DateTime.Now, NumeroDocumento = "1-A", Tipo = "Conta", Titulo = "Vivo 03/2016", Descricao = "", Valor = Decimal.Parse("64,90"), PerfilId = 1 },
                new CreditoCaixa { Id = 2, Data = DateTime.Now, NumeroDocumento = "2-A", Tipo = "Conta", Titulo = "Internet 03/2016", Descricao = "", Valor = Decimal.Parse("74,90"), PerfilId = 1 },
                new CreditoCaixa { Id = 3, Data = DateTime.Now, NumeroDocumento = "3-A", Tipo = "Conta", Titulo = "Spotify 03/2016", Descricao = "", Valor = Decimal.Parse("14,90"), PerfilId = 1 },
                new CreditoCaixa { Id = 4, Data = DateTime.Now, NumeroDocumento = "1-A", Tipo = "Conta", Titulo = "Vivo 03/2016", Descricao = "", Valor = Decimal.Parse("64,90"), PerfilId = 2 },
                new CreditoCaixa { Id = 5, Data = DateTime.Now, NumeroDocumento = "2-A", Tipo = "Conta", Titulo = "Internet 03/2016", Descricao = "", Valor = Decimal.Parse("74,90"), PerfilId = 2 },
                new CreditoCaixa { Id = 6, Data = DateTime.Now, NumeroDocumento = "3-A", Tipo = "Conta", Titulo = "Spotify 03/2016", Descricao = "", Valor = Decimal.Parse("14,90"), PerfilId = 2 });

            context.DebitosCaixa.AddOrUpdate(x => x.Id,
                new DebitoCaixa { Id = 1, Data = DateTime.Now, NumeroDocumento = null, Tipo = "Salario", Titulo = "Salário 03/2016", Descricao = "", Valor = Decimal.Parse("880,00"), PerfilId = 1 },
                new DebitoCaixa { Id = 2, Data = DateTime.Now, NumeroDocumento = null, Tipo = "Juros Poupança", Titulo = "Juros 03/2016", Descricao = "", Valor = Decimal.Parse("10,90"), PerfilId = 1 },
                new DebitoCaixa { Id = 3, Data = DateTime.Now, NumeroDocumento = null, Tipo = "Presente", Titulo = "Presente 03/2016", Descricao = "", Valor = Decimal.Parse("50,00"), PerfilId = 1 },
                new DebitoCaixa { Id = 4, Data = DateTime.Now, NumeroDocumento = null, Tipo = "Salario", Titulo = "Sálario 03/2016", Descricao = "", Valor = Decimal.Parse("440,00"), PerfilId = 2 },
                new DebitoCaixa { Id = 5, Data = DateTime.Now, NumeroDocumento = null, Tipo = "Juros Poupança", Titulo = "Juros 03/2016", Descricao = "", Valor = Decimal.Parse("10,90"), PerfilId = 2 },
                new DebitoCaixa { Id = 6, Data = DateTime.Now, NumeroDocumento = null, Tipo = "Presente", Titulo = "Presente 03/2016", Descricao = "", Valor = Decimal.Parse("100,00"), PerfilId = 2 });
            
            //Namespace Contato
            context.ContatosProfissionais.AddOrUpdate(x => x.Id,
                new ContatoProfissional { Id = 1, Data = DateTime.Now, Nome = "Pessoa 1", Empresa = "Empresa 1", Email = "empresa01@gmail.com", Telefone = "(00)00000000", Assunto = "Oferta de Emprego", Mensagem = "Venha trabalhar conosco!" },
                new ContatoProfissional { Id = 2, Data = DateTime.Now, Nome = "Pessoa 2", Empresa = "Empresa 2", Email = "empresa02@gmail.com", Telefone = "(00)00000000", Assunto = "Oferta de Emprego", Mensagem = "Venha trabalhar conosco!" },
                new ContatoProfissional { Id = 3, Data = DateTime.Now, Nome = "Pessoa 3", Empresa = "Empresa 3", Email = "empresa03@gmail.com", Telefone = "(00)00000000", Assunto = "Oferta de Emprego", Mensagem = "Venha trabalhar conosco!" },
                new ContatoProfissional { Id = 4, Data = DateTime.Now, Nome = "Pessoa 4", Empresa = "Empresa 4", Email = "empresa04@gmail.com", Telefone = "(00)00000000", Assunto = "Oferta de Emprego", Mensagem = "Venha trabalhar conosco!" },
                new ContatoProfissional { Id = 5, Data = DateTime.Now, Nome = "Pessoa 5", Empresa = "Empresa 5", Email = "empresa05@gmail.com", Telefone = "(00)00000000", Assunto = "Oferta de Emprego", Mensagem = "Venha trabalhar conosco!" });

            //Namespace BalancoProdutorRural
            context.ProdutoresRurais.AddOrUpdate(x => x.Id,
                new ProdutorRural { Id = 1, Nome = "Produtor 1", Cpf = "000.000.000-00", InscricaoEstadual = "0000", Email = "produtor1@gmail.com", Endereco = endereco5, Telefone1 = "(00)00000000", Telefone2 = "", Observacao = "" },
                new ProdutorRural { Id = 2, Nome = "Produtor 2", Cpf = "222.222.222-22", InscricaoEstadual = "2222", Email = "produtor2@gmail.com", Endereco = endereco4, Telefone1 = "(00)00000000", Telefone2 = "", Observacao = "" },
                new ProdutorRural { Id = 3, Nome = "Produtor 3", Cpf = "333.333.333-33", InscricaoEstadual = "3333", Email = "produtor3@gmail.com", Endereco = endereco3, Telefone1 = "(00)00000000", Telefone2 = "", Observacao = "" },
                new ProdutorRural { Id = 4, Nome = "Produtor 4", Cpf = "444.444.444-44", InscricaoEstadual = "4444", Email = "produtor4@gmail.com", Endereco = endereco5, Telefone1 = "(00)00000000", Telefone2 = "", Observacao = "" },
                new ProdutorRural { Id = 5, Nome = "Produtor 5", Cpf = "555.555.555-55", InscricaoEstadual = "5555", Email = "produtor5@gmail.com", Endereco = endereco4, Telefone1 = "(00)00000000", Telefone2 = "", Observacao = "" });

            context.Fazendas.AddOrUpdate(x => x.Id,
                new Fazenda { Id = 1, Nome = "Fazenda 1", Area = Decimal.Parse("100,00"), Endereco = endereco5, ProdutorRuralId = 1 },
                new Fazenda { Id = 2, Nome = "Fazenda 2", Area = Decimal.Parse("200,00"), Endereco = endereco4, ProdutorRuralId = 1 },
                new Fazenda { Id = 3, Nome = "Fazenda 3", Area = Decimal.Parse("300,00"), Endereco = endereco3, ProdutorRuralId = 2 },
                new Fazenda { Id = 4, Nome = "Fazenda 4", Area = Decimal.Parse("400,00"), Endereco = endereco5, ProdutorRuralId = 2 },
                new Fazenda { Id = 5, Nome = "Fazenda 5", Area = Decimal.Parse("500,00"), Endereco = endereco4, ProdutorRuralId = 3 },
                new Fazenda { Id = 6, Nome = "Fazenda 6", Area = Decimal.Parse("600,00"), Endereco = endereco3, ProdutorRuralId = 3 },
                new Fazenda { Id = 7, Nome = "Fazenda 7", Area = Decimal.Parse("700,00"), Endereco = endereco5, ProdutorRuralId = 4 },
                new Fazenda { Id = 8, Nome = "Fazenda 8", Area = Decimal.Parse("800,00"), Endereco = endereco4, ProdutorRuralId = 4 },
                new Fazenda { Id = 9, Nome = "Fazenda 9", Area = Decimal.Parse("900,00"), Endereco = endereco3, ProdutorRuralId = 5 },
                new Fazenda { Id = 10, Nome = "Fazenda 10", Area = Decimal.Parse("1000,00"), Endereco = endereco5, ProdutorRuralId = 5 });

            context.Posses.AddOrUpdate(x => x.Id,
                new Posse { Id = 1, DataAquisicao = DateTime.Now, Valor = Decimal.Parse("80000,00"), Descricao = "Automóvel 1", ProdutorRuralId = 1 },
                new Posse { Id = 2, DataAquisicao = DateTime.Now, Valor = Decimal.Parse("40000,00"), Descricao = "Automóvel 2", ProdutorRuralId = 1 },
                new Posse { Id = 3, DataAquisicao = DateTime.Now, Valor = Decimal.Parse("10000,00"), Descricao = "Motocicleta 1", ProdutorRuralId = 1 },
                new Posse { Id = 4, DataAquisicao = DateTime.Now, Valor = Decimal.Parse("250000,00"), Descricao = "Apartamento 1", ProdutorRuralId = 1 },
                new Posse { Id = 5, DataAquisicao = DateTime.Now, Valor = Decimal.Parse("180000,00"), Descricao = "Casa 1", ProdutorRuralId = 1 },
                new Posse { Id = 6, DataAquisicao = DateTime.Now, Valor = Decimal.Parse("70000,00"), Descricao = "Automóvel 1", ProdutorRuralId = 2 },
                new Posse { Id = 7, DataAquisicao = DateTime.Now, Valor = Decimal.Parse("30000,00"), Descricao = "Automóvel 2", ProdutorRuralId = 2 },
                new Posse { Id = 8, DataAquisicao = DateTime.Now, Valor = Decimal.Parse("3000,00"), Descricao = "Motocicleta 1", ProdutorRuralId = 2 },
                new Posse { Id = 9, DataAquisicao = DateTime.Now, Valor = Decimal.Parse("200000,00"), Descricao = "Apartamento 1", ProdutorRuralId = 2 },
                new Posse { Id = 10, DataAquisicao = DateTime.Now, Valor = Decimal.Parse("80000,00"), Descricao = "Casa 1", ProdutorRuralId = 2 });

            context.ComprasGados.AddOrUpdate(x => x.Id,
                new CompraGado { Id = 1, Data = DateTime.Now, ProdutorRuralId = 1, NumeroDocumento = "123", NomeVendedor = "Vendedor 1", QuantidadeCabecas = 12, Valor = Decimal.Parse("23000,00"), Descricao = "" },
                new CompraGado { Id = 2, Data = DateTime.Now, ProdutorRuralId = 1, NumeroDocumento = "456", NomeVendedor = "Vendedor 1", QuantidadeCabecas = 5, Valor = Decimal.Parse("2000,00"), Descricao = "" },
                new CompraGado { Id = 3, Data = DateTime.Now, ProdutorRuralId = 1, NumeroDocumento = "789", NomeVendedor = "Vendedor 2", QuantidadeCabecas = 13, Valor = Decimal.Parse("24000,00"), Descricao = "" },
                new CompraGado { Id = 4, Data = DateTime.Now, ProdutorRuralId = 1, NumeroDocumento = "101112", NomeVendedor = "Vendedor 2", QuantidadeCabecas = 20, Valor = Decimal.Parse("31000,00"), Descricao = "" },
                new CompraGado { Id = 5, Data = DateTime.Now, ProdutorRuralId = 1, NumeroDocumento = "131415", NomeVendedor = "Vendedor 3", QuantidadeCabecas = 23, Valor = Decimal.Parse("34000,00"), Descricao = "" },
                new CompraGado { Id = 6, Data = DateTime.Now, ProdutorRuralId = 2, NumeroDocumento = "1617", NomeVendedor = "Vendedor 3", QuantidadeCabecas = 30, Valor = Decimal.Parse("45000,00"), Descricao = "" },
                new CompraGado { Id = 7, Data = DateTime.Now, ProdutorRuralId = 2, NumeroDocumento = "1819", NomeVendedor = "Vendedor 4", QuantidadeCabecas = 50, Valor = Decimal.Parse("60000,00"), Descricao = "" },
                new CompraGado { Id = 8, Data = DateTime.Now, ProdutorRuralId = 2, NumeroDocumento = "2021", NomeVendedor = "Vendedor 4", QuantidadeCabecas = 3, Valor = Decimal.Parse("1000,00"), Descricao = "" },
                new CompraGado { Id = 9, Data = DateTime.Now, ProdutorRuralId = 2, NumeroDocumento = "2223", NomeVendedor = "Vendedor 5", QuantidadeCabecas = 24, Valor = Decimal.Parse("35000,00"), Descricao = "" },
                new CompraGado { Id = 10, Data = DateTime.Now, ProdutorRuralId = 2, NumeroDocumento = "2425", NomeVendedor = "Vendedor 5", QuantidadeCabecas = 10, Valor = Decimal.Parse("20000,00"), Descricao = "" });

            context.DespesasGerais.AddOrUpdate(x => x.Id,
                new DespesaGeral { Id = 1, Data = DateTime.Now, ProdutorRuralId = 1, NumeroDocumento = "1", NomeVendedor = "Vendedor 1", Valor = decimal.Parse("150,00"), Descricao = "" },
                new DespesaGeral { Id = 2, Data = DateTime.Now, ProdutorRuralId = 1, NumeroDocumento = "2", NomeVendedor = "Vendedor 1", Valor = decimal.Parse("353,00"), Descricao = "" },
                new DespesaGeral { Id = 3, Data = DateTime.Now, ProdutorRuralId = 1, NumeroDocumento = "3", NomeVendedor = "Vendedor 2", Valor = decimal.Parse("2345,00"), Descricao = "" },
                new DespesaGeral { Id = 4, Data = DateTime.Now, ProdutorRuralId = 1, NumeroDocumento = "4", NomeVendedor = "Vendedor 2", Valor = decimal.Parse("2355,00"), Descricao = "" },
                new DespesaGeral { Id = 5, Data = DateTime.Now, ProdutorRuralId = 1, NumeroDocumento = "5", NomeVendedor = "Vendedor 3", Valor = decimal.Parse("5000,00"), Descricao = "" },
                new DespesaGeral { Id = 6, Data = DateTime.Now, ProdutorRuralId = 2, NumeroDocumento = "6", NomeVendedor = "Vendedor 3", Valor = decimal.Parse("4354,00"), Descricao = "" },
                new DespesaGeral { Id = 7, Data = DateTime.Now, ProdutorRuralId = 2, NumeroDocumento = "7", NomeVendedor = "Vendedor 4", Valor = decimal.Parse("234,00"), Descricao = "" },
                new DespesaGeral { Id = 8, Data = DateTime.Now, ProdutorRuralId = 2, NumeroDocumento = "8", NomeVendedor = "Vendedor 4", Valor = decimal.Parse("34,00"), Descricao = "" },
                new DespesaGeral { Id = 9, Data = DateTime.Now, ProdutorRuralId = 2, NumeroDocumento = "9", NomeVendedor = "Vendedor 5", Valor = decimal.Parse("5657,00"), Descricao = "" },
                new DespesaGeral { Id = 10, Data = DateTime.Now, ProdutorRuralId = 2, NumeroDocumento = "10", NomeVendedor = "Vendedor 5", Valor = decimal.Parse("678,00"), Descricao = "" });

            context.ReceitasGerais.AddOrUpdate(x => x.Id,
                new ReceitaGeral { Id = 1, Data = DateTime.Now, ProdutorRuralId = 1, NumeroDocumento = "1", NomeComprador = "Vendedor 1", Valor = decimal.Parse("150,00"), Descricao = "" },
                new ReceitaGeral { Id = 2, Data = DateTime.Now, ProdutorRuralId = 1, NumeroDocumento = "2", NomeComprador = "Vendedor 1", Valor = decimal.Parse("353,00"), Descricao = "" },
                new ReceitaGeral { Id = 3, Data = DateTime.Now, ProdutorRuralId = 1, NumeroDocumento = "3", NomeComprador = "Vendedor 2", Valor = decimal.Parse("2345,00"), Descricao = "" },
                new ReceitaGeral { Id = 4, Data = DateTime.Now, ProdutorRuralId = 1, NumeroDocumento = "4", NomeComprador = "Vendedor 2", Valor = decimal.Parse("2355,00"), Descricao = "" },
                new ReceitaGeral { Id = 5, Data = DateTime.Now, ProdutorRuralId = 1, NumeroDocumento = "5", NomeComprador = "Vendedor 3", Valor = decimal.Parse("5000,00"), Descricao = "" },
                new ReceitaGeral { Id = 6, Data = DateTime.Now, ProdutorRuralId = 2, NumeroDocumento = "6", NomeComprador = "Vendedor 3", Valor = decimal.Parse("4354,00"), Descricao = "" },
                new ReceitaGeral { Id = 7, Data = DateTime.Now, ProdutorRuralId = 2, NumeroDocumento = "7", NomeComprador = "Vendedor 4", Valor = decimal.Parse("234,00"), Descricao = "" },
                new ReceitaGeral { Id = 8, Data = DateTime.Now, ProdutorRuralId = 2, NumeroDocumento = "8", NomeComprador = "Vendedor 4", Valor = decimal.Parse("34,00"), Descricao = "" },
                new ReceitaGeral { Id = 9, Data = DateTime.Now, ProdutorRuralId = 2, NumeroDocumento = "9", NomeComprador = "Vendedor 5", Valor = decimal.Parse("5657,00"), Descricao = "" },
                new ReceitaGeral { Id = 10, Data = DateTime.Now, ProdutorRuralId = 2, NumeroDocumento = "10", NomeComprador = "Vendedor 5", Valor = decimal.Parse("678,00"), Descricao = "" });

            context.VendasGerais.AddOrUpdate(x => x.Id,
                new VendaGado { Id = 1, Data = DateTime.Now, ProdutorRuralId = 1, NumeroDocumento = "123", NomeComprador = "Vendedor 1", QuantidadeCabecas = 12, Valor = Decimal.Parse("23000,00"), Descricao = "" },
                new VendaGado { Id = 2, Data = DateTime.Now, ProdutorRuralId = 1, NumeroDocumento = "456", NomeComprador = "Vendedor 1", QuantidadeCabecas = 5, Valor = Decimal.Parse("2000,00"), Descricao = "" },
                new VendaGado { Id = 3, Data = DateTime.Now, ProdutorRuralId = 1, NumeroDocumento = "789", NomeComprador = "Vendedor 2", QuantidadeCabecas = 13, Valor = Decimal.Parse("24000,00"), Descricao = "" },
                new VendaGado { Id = 4, Data = DateTime.Now, ProdutorRuralId = 1, NumeroDocumento = "101112", NomeComprador = "Vendedor 2", QuantidadeCabecas = 20, Valor = Decimal.Parse("31000,00"), Descricao = "" },
                new VendaGado { Id = 5, Data = DateTime.Now, ProdutorRuralId = 1, NumeroDocumento = "131415", NomeComprador = "Vendedor 3", QuantidadeCabecas = 23, Valor = Decimal.Parse("34000,00"), Descricao = "" },
                new VendaGado { Id = 6, Data = DateTime.Now, ProdutorRuralId = 2, NumeroDocumento = "1617", NomeComprador = "Vendedor 3", QuantidadeCabecas = 30, Valor = Decimal.Parse("45000,00"), Descricao = "" },
                new VendaGado { Id = 7, Data = DateTime.Now, ProdutorRuralId = 2, NumeroDocumento = "1819", NomeComprador = "Vendedor 4", QuantidadeCabecas = 50, Valor = Decimal.Parse("60000,00"), Descricao = "" },
                new VendaGado { Id = 8, Data = DateTime.Now, ProdutorRuralId = 2, NumeroDocumento = "2021", NomeComprador = "Vendedor 4", QuantidadeCabecas = 3, Valor = Decimal.Parse("1000,00"), Descricao = "" },
                new VendaGado { Id = 9, Data = DateTime.Now, ProdutorRuralId = 2, NumeroDocumento = "2223", NomeComprador = "Vendedor 5", QuantidadeCabecas = 24, Valor = Decimal.Parse("35000,00"), Descricao = "" },
                new VendaGado { Id = 10, Data = DateTime.Now, ProdutorRuralId = 2, NumeroDocumento = "2425", NomeComprador = "Vendedor 5", QuantidadeCabecas = 10, Valor = Decimal.Parse("20000,00"), Descricao = "" });

            context.VendasLeite.AddOrUpdate(x => x.Id,
                new VendaLeite { Id = 1, Data = DateTime.Now, ProdutorRuralId = 1, NumeroDocumento = "1", NomeComprador = "Vendedor 1", Valor = decimal.Parse("150,00"), Descricao = "" },
                new VendaLeite { Id = 2, Data = DateTime.Now, ProdutorRuralId = 1, NumeroDocumento = "2", NomeComprador = "Vendedor 1", Valor = decimal.Parse("353,00"), Descricao = "" },
                new VendaLeite { Id = 3, Data = DateTime.Now, ProdutorRuralId = 1, NumeroDocumento = "3", NomeComprador = "Vendedor 2", Valor = decimal.Parse("2345,00"), Descricao = "" },
                new VendaLeite { Id = 4, Data = DateTime.Now, ProdutorRuralId = 1, NumeroDocumento = "4", NomeComprador = "Vendedor 2", Valor = decimal.Parse("2355,00"), Descricao = "" },
                new VendaLeite { Id = 5, Data = DateTime.Now, ProdutorRuralId = 1, NumeroDocumento = "5", NomeComprador = "Vendedor 3", Valor = decimal.Parse("5000,00"), Descricao = "" },
                new VendaLeite { Id = 6, Data = DateTime.Now, ProdutorRuralId = 2, NumeroDocumento = "6", NomeComprador = "Vendedor 3", Valor = decimal.Parse("4354,00"), Descricao = "" },
                new VendaLeite { Id = 7, Data = DateTime.Now, ProdutorRuralId = 2, NumeroDocumento = "7", NomeComprador = "Vendedor 4", Valor = decimal.Parse("234,00"), Descricao = "" },
                new VendaLeite { Id = 8, Data = DateTime.Now, ProdutorRuralId = 2, NumeroDocumento = "8", NomeComprador = "Vendedor 4", Valor = decimal.Parse("34,00"), Descricao = "" },
                new VendaLeite { Id = 9, Data = DateTime.Now, ProdutorRuralId = 2, NumeroDocumento = "9", NomeComprador = "Vendedor 5", Valor = decimal.Parse("5657,00"), Descricao = "" },
                new VendaLeite { Id = 10, Data = DateTime.Now, ProdutorRuralId = 2, NumeroDocumento = "10", NomeComprador = "Vendedor 5", Valor = decimal.Parse("678,00"), Descricao = "" });
            
        }
    }
}

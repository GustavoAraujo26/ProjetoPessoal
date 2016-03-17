namespace ProjetoPessoal.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agenda_Atividade",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PerfilId = c.Int(nullable: false),
                        DataInicio = c.DateTime(nullable: false, storeType: "date"),
                        DataFinal = c.DateTime(nullable: false, storeType: "date"),
                        Assunto = c.String(nullable: false, maxLength: 500, unicode: false),
                        Descricao = c.String(maxLength: 8000, unicode: false),
                        ContatoTelefonicoId = c.Int(),
                        Realizado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ListaTelefonica_ContatoTelefonico", t => t.ContatoTelefonicoId)
                .ForeignKey("dbo.Perfil_Perfil", t => t.PerfilId, cascadeDelete: true)
                .Index(t => t.PerfilId)
                .Index(t => t.ContatoTelefonicoId);
            
            CreateTable(
                "dbo.ListaTelefonica_ContatoTelefonico",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PerfilId = c.Int(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 300, unicode: false),
                        Apelido = c.String(maxLength: 100, unicode: false),
                        Empresa = c.String(maxLength: 700, unicode: false),
                        Cargo = c.String(maxLength: 700, unicode: false),
                        Logradouro = c.String(nullable: false, maxLength: 500, unicode: false),
                        Numero = c.Int(nullable: false),
                        Complemento = c.String(maxLength: 500, unicode: false),
                        Bairro = c.String(nullable: false, maxLength: 300, unicode: false),
                        Cidade = c.String(nullable: false, maxLength: 300, unicode: false),
                        Estado = c.String(nullable: false, maxLength: 2, unicode: false),
                        Cep = c.String(nullable: false, maxLength: 10, unicode: false),
                        Email = c.String(nullable: false, maxLength: 200, unicode: false),
                        Telefone1 = c.String(nullable: false, maxLength: 14, unicode: false),
                        Telefone2 = c.String(name: "Telefone 2", maxLength: 14, unicode: false),
                        Facebook = c.String(maxLength: 500, unicode: false),
                        LinkedIn = c.String(maxLength: 500, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Perfil_Perfil", t => t.PerfilId, cascadeDelete: true)
                .Index(t => t.PerfilId);
            
            CreateTable(
                "dbo.Perfil_Perfil",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomeCompleto = c.String(nullable: false, maxLength: 300, unicode: false),
                        DataNascimento = c.DateTime(nullable: false, storeType: "date"),
                        GrauInstrucao = c.String(maxLength: 100, unicode: false),
                        EstadoCivil = c.String(maxLength: 50, unicode: false),
                        Sexo = c.String(nullable: false, maxLength: 1, unicode: false),
                        Logradouro = c.String(nullable: false, maxLength: 500, unicode: false),
                        Numero = c.Int(nullable: false),
                        Complemento = c.String(maxLength: 500, unicode: false),
                        Bairro = c.String(nullable: false, maxLength: 300, unicode: false),
                        Cidade = c.String(nullable: false, maxLength: 300, unicode: false),
                        Estado = c.String(nullable: false, maxLength: 2, unicode: false),
                        Cep = c.String(nullable: false, maxLength: 10, unicode: false),
                        Email = c.String(nullable: false, maxLength: 200, unicode: false),
                        Telefone1 = c.String(nullable: false, maxLength: 14, unicode: false),
                        Telefone2 = c.String(maxLength: 14, unicode: false),
                        Facebook = c.String(maxLength: 500, unicode: false),
                        LinkedIn = c.String(maxLength: 500, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ControleArquivo_CaixaArquivo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false, storeType: "date"),
                        Observacao = c.String(maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ControleArquivo_ItemArquivo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false, storeType: "date"),
                        NomeEntidade = c.String(nullable: false, maxLength: 300, unicode: false),
                        Cpf = c.String(maxLength: 14, unicode: false),
                        Cnpj = c.String(maxLength: 18, unicode: false),
                        Titulo = c.String(maxLength: 500, unicode: false),
                        Descricao = c.String(maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Restaurante_Cardapio",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false, storeType: "date"),
                        Periodo = c.String(maxLength: 200, unicode: false),
                        PrecoUnitario = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Observacao = c.String(maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Restaurante_Item",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 1000, unicode: false),
                        Descricao = c.String(maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Curriculum_Certificado",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PerfilId = c.Int(nullable: false),
                        NomeCurso = c.String(nullable: false, maxLength: 1000, unicode: false),
                        NomeInstituicao = c.String(nullable: false, maxLength: 1000, unicode: false),
                        Cidade = c.String(nullable: false, maxLength: 300, unicode: false),
                        Estado = c.String(nullable: false, maxLength: 2, unicode: false),
                        DataInicio = c.DateTime(nullable: false, storeType: "date"),
                        DataTermino = c.DateTime(nullable: false, storeType: "date"),
                        Cursando = c.Boolean(nullable: false),
                        Descricao = c.String(maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Perfil_Perfil", t => t.PerfilId, cascadeDelete: true)
                .Index(t => t.PerfilId);
            
            CreateTable(
                "dbo.Restaurante_Cliente",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 300, unicode: false),
                        Cpf = c.String(maxLength: 14, unicode: false),
                        Cnpj = c.String(maxLength: 18, unicode: false),
                        InscricaoEstadual = c.String(maxLength: 20, unicode: false),
                        Logradouro = c.String(nullable: false, maxLength: 500, unicode: false),
                        Numero = c.Int(nullable: false),
                        Complemento = c.String(maxLength: 500, unicode: false),
                        Bairro = c.String(nullable: false, maxLength: 300, unicode: false),
                        Cidade = c.String(nullable: false, maxLength: 300, unicode: false),
                        Estado = c.String(nullable: false, maxLength: 2, unicode: false),
                        Cep = c.String(nullable: false, maxLength: 10, unicode: false),
                        Telefone1 = c.String(nullable: false, maxLength: 14, unicode: false),
                        Telefone2 = c.String(maxLength: 14, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Curriculum_Competencia",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PerfilId = c.Int(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 1000, unicode: false),
                        NivelConhecimento = c.String(nullable: false, maxLength: 200, unicode: false),
                        Descricao = c.String(maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Perfil_Perfil", t => t.PerfilId, cascadeDelete: true)
                .Index(t => t.PerfilId);
            
            CreateTable(
                "dbo.BalancoProdutorRural_CompraGado",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false, storeType: "date"),
                        ProdutorRuralId = c.Int(nullable: false),
                        NumeroDocumento = c.String(maxLength: 20, unicode: false),
                        NomeVendedor = c.String(nullable: false, maxLength: 300, unicode: false),
                        QuantidadeCabecas = c.Int(nullable: false),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Descricao = c.String(maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BalancoProdutorRural_ProdutorRural", t => t.ProdutorRuralId, cascadeDelete: true)
                .Index(t => t.ProdutorRuralId);
            
            CreateTable(
                "dbo.BalancoProdutorRural_ProdutorRural",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 300, unicode: false),
                        Cpf = c.String(nullable: false, maxLength: 14, unicode: false),
                        InscricaoEstadual = c.String(nullable: false, maxLength: 20, unicode: false),
                        Logradouro = c.String(nullable: false, maxLength: 500, unicode: false),
                        Numero = c.Int(nullable: false),
                        Complemento = c.String(maxLength: 500, unicode: false),
                        Bairro = c.String(nullable: false, maxLength: 300, unicode: false),
                        Cidade = c.String(nullable: false, maxLength: 300, unicode: false),
                        Estado = c.String(nullable: false, maxLength: 2, unicode: false),
                        Cep = c.String(nullable: false, maxLength: 10, unicode: false),
                        Email = c.String(nullable: false, maxLength: 200, unicode: false),
                        Telefone1 = c.String(nullable: false, maxLength: 14, unicode: false),
                        Telefone2 = c.String(name: "Telefone 2", maxLength: 14, unicode: false),
                        Observacao = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BalancoProdutorRural_Fazenda",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 500, unicode: false),
                        Area = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProdutorRuralId = c.Int(nullable: false),
                        Logradouro = c.String(nullable: false, maxLength: 500, unicode: false),
                        Numero = c.Int(nullable: false),
                        Complemento = c.String(maxLength: 500, unicode: false),
                        Bairro = c.String(nullable: false, maxLength: 300, unicode: false),
                        Cidade = c.String(nullable: false, maxLength: 300, unicode: false),
                        Estado = c.String(nullable: false, maxLength: 2, unicode: false),
                        Cep = c.String(nullable: false, maxLength: 10, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BalancoProdutorRural_ProdutorRural", t => t.ProdutorRuralId, cascadeDelete: true)
                .Index(t => t.ProdutorRuralId);
            
            CreateTable(
                "dbo.AgendamentoMedico_Consulta",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false, storeType: "date"),
                        PacienteId = c.Int(nullable: false),
                        MedicoId = c.Int(nullable: false),
                        ConsultorioId = c.Int(),
                        HospitalId = c.Int(),
                        Motivo = c.String(maxLength: 1000, unicode: false),
                        Descricao = c.String(maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AgendamentoMedico_Consultorio", t => t.ConsultorioId)
                .ForeignKey("dbo.AgendamentoMedico_Hospital", t => t.HospitalId)
                .ForeignKey("dbo.AgendamentoMedico_Medico", t => t.MedicoId, cascadeDelete: true)
                .ForeignKey("dbo.AgendamentoMedico_Paciente", t => t.PacienteId, cascadeDelete: true)
                .Index(t => t.PacienteId)
                .Index(t => t.MedicoId)
                .Index(t => t.ConsultorioId)
                .Index(t => t.HospitalId);
            
            CreateTable(
                "dbo.AgendamentoMedico_Consultorio",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 700, unicode: false),
                        Logradouro = c.String(nullable: false, maxLength: 500, unicode: false),
                        Numero = c.Int(nullable: false),
                        Complemento = c.String(maxLength: 500, unicode: false),
                        Bairro = c.String(nullable: false, maxLength: 300, unicode: false),
                        Cidade = c.String(nullable: false, maxLength: 300, unicode: false),
                        Estado = c.String(nullable: false, maxLength: 2, unicode: false),
                        Cep = c.String(nullable: false, maxLength: 10, unicode: false),
                        Telefone1 = c.String(nullable: false, maxLength: 14, unicode: false),
                        Telefone2 = c.String(name: "Telefone 2", maxLength: 14, unicode: false),
                        Descricao = c.String(maxLength: 8000, unicode: false),
                        AtendeConvenio = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AgendamentoMedico_Medico",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 300, unicode: false),
                        Documento = c.String(nullable: false, maxLength: 30, unicode: false),
                        Logradouro = c.String(nullable: false, maxLength: 500, unicode: false),
                        Numero = c.Int(nullable: false),
                        Complemento = c.String(maxLength: 500, unicode: false),
                        Bairro = c.String(nullable: false, maxLength: 300, unicode: false),
                        Cidade = c.String(nullable: false, maxLength: 300, unicode: false),
                        Estado = c.String(nullable: false, maxLength: 2, unicode: false),
                        Cep = c.String(nullable: false, maxLength: 10, unicode: false),
                        Email = c.String(nullable: false, maxLength: 200, unicode: false),
                        Telefone1 = c.String(nullable: false, maxLength: 14, unicode: false),
                        Telefone2 = c.String(name: "Telefone 2", maxLength: 14, unicode: false),
                        Facebook = c.String(maxLength: 500, unicode: false),
                        LinkedIn = c.String(maxLength: 500, unicode: false),
                        AtendeConvenio = c.Boolean(nullable: false),
                        AtendeEmCasa = c.Boolean(nullable: false),
                        Especialidade_Id = c.Int(),
                        Hospital_Id = c.Int(),
                        Consultorio_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AgendamentoMedico_Especialidade", t => t.Especialidade_Id)
                .ForeignKey("dbo.AgendamentoMedico_Hospital", t => t.Hospital_Id)
                .ForeignKey("dbo.AgendamentoMedico_Consultorio", t => t.Consultorio_Id)
                .Index(t => t.Especialidade_Id)
                .Index(t => t.Hospital_Id)
                .Index(t => t.Consultorio_Id);
            
            CreateTable(
                "dbo.AgendamentoMedico_Especialidade",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 500, unicode: false),
                        Descricao = c.String(maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AgendamentoMedico_Hospital",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 700, unicode: false),
                        Logradouro = c.String(nullable: false, maxLength: 500, unicode: false),
                        Numero = c.Int(nullable: false),
                        Complemento = c.String(maxLength: 500, unicode: false),
                        Bairro = c.String(nullable: false, maxLength: 300, unicode: false),
                        Cidade = c.String(nullable: false, maxLength: 300, unicode: false),
                        Estado = c.String(nullable: false, maxLength: 2, unicode: false),
                        Cep = c.String(nullable: false, maxLength: 10, unicode: false),
                        Telefone1 = c.String(nullable: false, maxLength: 14, unicode: false),
                        Telefone2 = c.String(name: "Telefone 2", maxLength: 14, unicode: false),
                        Descricao = c.String(maxLength: 8000, unicode: false),
                        Privado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AgendamentoMedico_Paciente",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 300, unicode: false),
                        DataNascimento = c.DateTime(nullable: false, storeType: "date"),
                        Sexo = c.String(nullable: false, maxLength: 1, unicode: false),
                        Logradouro = c.String(nullable: false, maxLength: 500, unicode: false),
                        Numero = c.Int(nullable: false),
                        Complemento = c.String(maxLength: 500, unicode: false),
                        Bairro = c.String(nullable: false, maxLength: 300, unicode: false),
                        Cidade = c.String(nullable: false, maxLength: 300, unicode: false),
                        Estado = c.String(nullable: false, maxLength: 2, unicode: false),
                        Cep = c.String(nullable: false, maxLength: 10, unicode: false),
                        Telefone1 = c.String(nullable: false, maxLength: 14, unicode: false),
                        Telefone2 = c.String(name: "Telefone 2", maxLength: 14, unicode: false),
                        Observacao = c.String(maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Contato_ContatoProfissional",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 300, unicode: false),
                        Empresa = c.String(nullable: false, maxLength: 500, unicode: false),
                        Email = c.String(nullable: false, maxLength: 200, unicode: false),
                        Telefone = c.String(nullable: false, maxLength: 14, unicode: false),
                        Assunto = c.String(maxLength: 1000, unicode: false),
                        Mensagem = c.String(maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Cotacao_Cotacao",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false, storeType: "date"),
                        ProdutoId = c.Int(nullable: false),
                        RepresentanteId = c.Int(nullable: false),
                        PrecoSugerido = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Observacao = c.String(maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cotacao_Produto", t => t.ProdutoId, cascadeDelete: true)
                .ForeignKey("dbo.Cotacao_Representante", t => t.RepresentanteId, cascadeDelete: true)
                .Index(t => t.ProdutoId)
                .Index(t => t.RepresentanteId);
            
            CreateTable(
                "dbo.Cotacao_Produto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 500, unicode: false),
                        Marca = c.String(nullable: false, maxLength: 300, unicode: false),
                        Qtd = c.Int(nullable: false),
                        Observacao = c.String(maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Cotacao_Representante",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 300, unicode: false),
                        Apelido = c.String(maxLength: 100, unicode: false),
                        Email = c.String(nullable: false, maxLength: 200, unicode: false),
                        Telefone1 = c.String(nullable: false, maxLength: 14, unicode: false),
                        Telefone2 = c.String(name: "Telefone 2", maxLength: 14, unicode: false),
                        Facebook = c.String(maxLength: 500, unicode: false),
                        LinkedIn = c.String(maxLength: 500, unicode: false),
                        Observacao = c.String(maxLength: 8000, unicode: false),
                        Fornecedor_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cotacao_Fornecedor", t => t.Fornecedor_Id)
                .Index(t => t.Fornecedor_Id);
            
            CreateTable(
                "dbo.Cotacao_Fornecedor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RazaoSocial = c.String(nullable: false, maxLength: 500, unicode: false),
                        Cnpj = c.String(maxLength: 18, unicode: false),
                        InscricaoEstadual = c.String(nullable: false, maxLength: 20, unicode: false),
                        Logradouro = c.String(nullable: false, maxLength: 500, unicode: false),
                        Numero = c.Int(nullable: false),
                        Complemento = c.String(maxLength: 500, unicode: false),
                        Bairro = c.String(nullable: false, maxLength: 300, unicode: false),
                        Cidade = c.String(nullable: false, maxLength: 300, unicode: false),
                        Estado = c.String(nullable: false, maxLength: 2, unicode: false),
                        Cep = c.String(nullable: false, maxLength: 10, unicode: false),
                        Email = c.String(nullable: false, maxLength: 200, unicode: false),
                        Telefone1 = c.String(nullable: false, maxLength: 14, unicode: false),
                        Telefone2 = c.String(name: "Telefone 2", maxLength: 14, unicode: false),
                        Facebook = c.String(maxLength: 500, unicode: false),
                        LinkedIn = c.String(maxLength: 500, unicode: false),
                        Observacao = c.String(maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LivroCaixa_CreditoCaixa",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PerfilId = c.Int(nullable: false),
                        Data = c.DateTime(nullable: false, storeType: "date"),
                        NumeroDocumento = c.String(maxLength: 20, unicode: false),
                        Tipo = c.String(nullable: false, maxLength: 500, unicode: false),
                        Titulo = c.String(nullable: false, maxLength: 800, unicode: false),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Descricao = c.String(maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Perfil_Perfil", t => t.PerfilId, cascadeDelete: true)
                .Index(t => t.PerfilId);
            
            CreateTable(
                "dbo.LivroCaixa_DebitoCaixa",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PerfilId = c.Int(nullable: false),
                        Data = c.DateTime(nullable: false, storeType: "date"),
                        NumeroDocumento = c.String(maxLength: 20, unicode: false),
                        Tipo = c.String(nullable: false, maxLength: 500, unicode: false),
                        Titulo = c.String(nullable: false, maxLength: 800, unicode: false),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Descricao = c.String(maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Perfil_Perfil", t => t.PerfilId, cascadeDelete: true)
                .Index(t => t.PerfilId);
            
            CreateTable(
                "dbo.BalancoProdutorRural_DespesaGeral",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false, storeType: "date"),
                        ProdutorRuralId = c.Int(nullable: false),
                        NumeroDocumento = c.String(maxLength: 20, unicode: false),
                        NomeVendedor = c.String(nullable: false, maxLength: 300, unicode: false),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Descricao = c.String(maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BalancoProdutorRural_ProdutorRural", t => t.ProdutorRuralId, cascadeDelete: true)
                .Index(t => t.ProdutorRuralId);
            
            CreateTable(
                "dbo.QuadroFuncionarios_Entidade",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomeEntidade = c.String(nullable: false, maxLength: 300, unicode: false),
                        Cpf = c.String(maxLength: 14, unicode: false),
                        Cnpj = c.String(maxLength: 18, unicode: false),
                        Logradouro = c.String(nullable: false, maxLength: 500, unicode: false),
                        Numero = c.Int(nullable: false),
                        Complemento = c.String(maxLength: 500, unicode: false),
                        Bairro = c.String(nullable: false, maxLength: 300, unicode: false),
                        Cidade = c.String(nullable: false, maxLength: 300, unicode: false),
                        Estado = c.String(nullable: false, maxLength: 2, unicode: false),
                        Cep = c.String(nullable: false, maxLength: 10, unicode: false),
                        Email = c.String(nullable: false, maxLength: 200, unicode: false),
                        Telefone1 = c.String(nullable: false, maxLength: 14, unicode: false),
                        Telefone2 = c.String(maxLength: 14, unicode: false),
                        AreaAtuacao = c.String(maxLength: 14, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.QuadroFuncionarios_Funcionario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EntidadeId = c.Int(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 300, unicode: false),
                        Cpf = c.String(nullable: false, maxLength: 14, unicode: false),
                        Sexo = c.String(nullable: false, maxLength: 2, unicode: false),
                        Logradouro = c.String(nullable: false, maxLength: 500, unicode: false),
                        Numero = c.Int(nullable: false),
                        Complemento = c.String(maxLength: 500, unicode: false),
                        Bairro = c.String(nullable: false, maxLength: 300, unicode: false),
                        Cidade = c.String(nullable: false, maxLength: 300, unicode: false),
                        Estado = c.String(nullable: false, maxLength: 2, unicode: false),
                        Cep = c.String(nullable: false, maxLength: 10, unicode: false),
                        Email = c.String(nullable: false, maxLength: 200, unicode: false),
                        Telefone1 = c.String(nullable: false, maxLength: 14, unicode: false),
                        Telefone2 = c.String(maxLength: 14, unicode: false),
                        Facebook = c.String(maxLength: 500, unicode: false),
                        LinkedIn = c.String(maxLength: 500, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.QuadroFuncionarios_Entidade", t => t.EntidadeId, cascadeDelete: true)
                .Index(t => t.EntidadeId);
            
            CreateTable(
                "dbo.Curriculum_Experiencia",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PerfilId = c.Int(nullable: false),
                        NomeEmpresa = c.String(nullable: false, maxLength: 1000, unicode: false),
                        CidadeEmpresa = c.String(nullable: false, maxLength: 300, unicode: false),
                        EstadoEmpresa = c.String(nullable: false, maxLength: 2, unicode: false),
                        DataContratacao = c.DateTime(nullable: false, storeType: "date"),
                        DataDemissao = c.DateTime(nullable: false, storeType: "date"),
                        EmpregoAtual = c.Boolean(nullable: false),
                        Cargo = c.String(nullable: false, maxLength: 300, unicode: false),
                        Descricao = c.String(maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Perfil_Perfil", t => t.PerfilId, cascadeDelete: true)
                .Index(t => t.PerfilId);
            
            CreateTable(
                "dbo.QuadroFuncionarios_Falta",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false, storeType: "date"),
                        FuncionarioId = c.Int(),
                        EntidadeId = c.Int(nullable: false),
                        Motivo = c.String(nullable: false, maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.QuadroFuncionarios_Entidade", t => t.EntidadeId, cascadeDelete: true)
                .ForeignKey("dbo.QuadroFuncionarios_Funcionario", t => t.FuncionarioId)
                .Index(t => t.FuncionarioId)
                .Index(t => t.EntidadeId);
            
            CreateTable(
                "dbo.AgendamentoMedico_Fatura",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false, storeType: "date"),
                        PacienteId = c.Int(nullable: false),
                        MedicoId = c.Int(nullable: false),
                        Descricao = c.String(maxLength: 8000, unicode: false),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FormaPagamento = c.String(maxLength: 100, unicode: false),
                        Convenio = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AgendamentoMedico_Medico", t => t.MedicoId, cascadeDelete: true)
                .ForeignKey("dbo.AgendamentoMedico_Paciente", t => t.PacienteId, cascadeDelete: true)
                .Index(t => t.PacienteId)
                .Index(t => t.MedicoId);
            
            CreateTable(
                "dbo.QuadroFuncionarios_FolhaPonto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false, storeType: "date"),
                        FuncionarioId = c.Int(),
                        EntidadeId = c.Int(nullable: false),
                        HorarioEntrada = c.Time(nullable: false, precision: 7),
                        HorarioSaidaAlmoco = c.Time(nullable: false, precision: 7),
                        HorarioEntradaAlmoco = c.Time(nullable: false, precision: 7),
                        HorarioSaida = c.Time(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.QuadroFuncionarios_Entidade", t => t.EntidadeId, cascadeDelete: true)
                .ForeignKey("dbo.QuadroFuncionarios_Funcionario", t => t.FuncionarioId)
                .Index(t => t.FuncionarioId)
                .Index(t => t.EntidadeId);
            
            CreateTable(
                "dbo.Curriculum_Formacao",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PerfilId = c.Int(nullable: false),
                        NomeInstituicao = c.String(nullable: false, maxLength: 1000, unicode: false),
                        CidadeInstituicao = c.String(nullable: false, maxLength: 300, unicode: false),
                        EstadoInstituicao = c.String(nullable: false, maxLength: 2, unicode: false),
                        DataInicio = c.DateTime(nullable: false, storeType: "date"),
                        DataTermino = c.DateTime(nullable: false, storeType: "date"),
                        Cursando = c.Boolean(nullable: false),
                        Tipo = c.String(nullable: false, maxLength: 500, unicode: false),
                        AreaDeAtuacao = c.String(maxLength: 500, unicode: false),
                        Descricao = c.String(maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Perfil_Perfil", t => t.PerfilId, cascadeDelete: true)
                .Index(t => t.PerfilId);
            
            CreateTable(
                "dbo.AgendamentoMedico_Historico",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false, storeType: "date"),
                        PacienteId = c.Int(nullable: false),
                        MedicoId = c.Int(),
                        Descricao = c.String(maxLength: 8000, unicode: false),
                        Recomendacao = c.String(maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AgendamentoMedico_Medico", t => t.MedicoId)
                .ForeignKey("dbo.AgendamentoMedico_Paciente", t => t.PacienteId, cascadeDelete: true)
                .Index(t => t.PacienteId)
                .Index(t => t.MedicoId);
            
            CreateTable(
                "dbo.Curriculum_Idioma",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PerfilId = c.Int(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 1000, unicode: false),
                        NivelConhecimento = c.String(nullable: false, maxLength: 200, unicode: false),
                        Descricao = c.String(maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Perfil_Perfil", t => t.PerfilId, cascadeDelete: true)
                .Index(t => t.PerfilId);
            
            CreateTable(
                "dbo.Curriculum_InformacaoInicial",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PerfilId = c.Int(nullable: false),
                        Resumo = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Interesses = c.String(nullable: false, maxLength: 8000, unicode: false),
                        PossuiCNH = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Perfil_Perfil", t => t.PerfilId, cascadeDelete: true)
                .Index(t => t.PerfilId);
            
            CreateTable(
                "dbo.Restaurante_Mensagem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false, storeType: "date"),
                        Assunto = c.String(nullable: false, maxLength: 1000, unicode: false),
                        Descricao = c.String(maxLength: 8000, unicode: false),
                        ClienteId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restaurante_Cliente", t => t.ClienteId)
                .Index(t => t.ClienteId);
            
            CreateTable(
                "dbo.QuadroFuncionarios_Ocorrencia",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false, storeType: "date"),
                        FuncionarioId = c.Int(),
                        EntidadeId = c.Int(nullable: false),
                        Tipo = c.String(nullable: false, maxLength: 200, unicode: false),
                        Descricao = c.String(nullable: false, maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.QuadroFuncionarios_Entidade", t => t.EntidadeId, cascadeDelete: true)
                .ForeignKey("dbo.QuadroFuncionarios_Funcionario", t => t.FuncionarioId)
                .Index(t => t.FuncionarioId)
                .Index(t => t.EntidadeId);
            
            CreateTable(
                "dbo.BalancoProdutorRural_Posse",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DataAquisicao = c.DateTime(nullable: false, storeType: "date"),
                        ProdutorRuralId = c.Int(nullable: false),
                        Descricao = c.String(maxLength: 8000, unicode: false),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BalancoProdutorRural_ProdutorRural", t => t.ProdutorRuralId, cascadeDelete: true)
                .Index(t => t.ProdutorRuralId);
            
            CreateTable(
                "dbo.BalancoProdutorRural_ReceitaGeral",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false, storeType: "date"),
                        ProdutorRuralId = c.Int(nullable: false),
                        NumeroDocumento = c.String(maxLength: 20, unicode: false),
                        NomeComprador = c.String(nullable: false, maxLength: 300, unicode: false),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Descricao = c.String(maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BalancoProdutorRural_ProdutorRural", t => t.ProdutorRuralId, cascadeDelete: true)
                .Index(t => t.ProdutorRuralId);
            
            CreateTable(
                "dbo.QuadroFuncionarios_Registro",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FuncionarioId = c.Int(),
                        EntidadeId = c.Int(nullable: false),
                        DataContratacao = c.DateTime(nullable: false, storeType: "date"),
                        DataDemissao = c.DateTime(nullable: false, storeType: "date"),
                        Cargo = c.String(nullable: false, maxLength: 300, unicode: false),
                        Salario = c.Decimal(nullable: false, precision: 18, scale: 2),
                        HorarioEntrada = c.Time(nullable: false, precision: 7),
                        HorarioSaidaAlmoco = c.Time(nullable: false, precision: 7),
                        HorarioEntradaAlmoco = c.Time(nullable: false, precision: 7),
                        HorarioSaida = c.Time(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.QuadroFuncionarios_Entidade", t => t.EntidadeId, cascadeDelete: true)
                .ForeignKey("dbo.QuadroFuncionarios_Funcionario", t => t.FuncionarioId)
                .Index(t => t.FuncionarioId)
                .Index(t => t.EntidadeId);
            
            CreateTable(
                "dbo.Restaurante_Venda",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false, storeType: "date"),
                        CardapioId = c.Int(nullable: false),
                        ClienteId = c.Int(nullable: false),
                        Quantidade = c.Int(nullable: false),
                        ValorTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Observacao = c.String(maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restaurante_Cardapio", t => t.CardapioId, cascadeDelete: true)
                .ForeignKey("dbo.Restaurante_Cliente", t => t.ClienteId, cascadeDelete: true)
                .Index(t => t.CardapioId)
                .Index(t => t.ClienteId);
            
            CreateTable(
                "dbo.BalancoProdutorRural_VendaGado",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false, storeType: "date"),
                        ProdutorRuralId = c.Int(nullable: false),
                        NumeroDocumento = c.String(maxLength: 20, unicode: false),
                        NomeComprador = c.String(nullable: false, maxLength: 300, unicode: false),
                        QuantidadeCabecas = c.Int(nullable: false),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Descricao = c.String(maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BalancoProdutorRural_ProdutorRural", t => t.ProdutorRuralId, cascadeDelete: true)
                .Index(t => t.ProdutorRuralId);
            
            CreateTable(
                "dbo.BalancoProdutorRural_VendaLeite",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false, storeType: "date"),
                        ProdutorRuralId = c.Int(nullable: false),
                        NumeroDocumento = c.String(maxLength: 20, unicode: false),
                        NomeComprador = c.String(nullable: false, maxLength: 300, unicode: false),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Descricao = c.String(maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BalancoProdutorRural_ProdutorRural", t => t.ProdutorRuralId, cascadeDelete: true)
                .Index(t => t.ProdutorRuralId);
            
            CreateTable(
                "dbo.CaixaArquivo_ItemArquivo",
                c => new
                    {
                        CaixaArquivoId = c.Int(nullable: false),
                        ItemArquivoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CaixaArquivoId, t.ItemArquivoId })
                .ForeignKey("dbo.ControleArquivo_CaixaArquivo", t => t.CaixaArquivoId)
                .ForeignKey("dbo.ControleArquivo_ItemArquivo", t => t.ItemArquivoId)
                .Index(t => t.CaixaArquivoId)
                .Index(t => t.ItemArquivoId);
            
            CreateTable(
                "dbo.Cardapio_Item",
                c => new
                    {
                        CardapioId = c.Int(nullable: false),
                        ItemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CardapioId, t.ItemId })
                .ForeignKey("dbo.Restaurante_Cardapio", t => t.CardapioId)
                .ForeignKey("dbo.Restaurante_Item", t => t.ItemId)
                .Index(t => t.CardapioId)
                .Index(t => t.ItemId);
            
            CreateTable(
                "dbo.Medico_Consultorio",
                c => new
                    {
                        MedicoId = c.Int(nullable: false),
                        ConsultorioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MedicoId, t.ConsultorioId })
                .ForeignKey("dbo.AgendamentoMedico_Medico", t => t.MedicoId)
                .ForeignKey("dbo.AgendamentoMedico_Consultorio", t => t.ConsultorioId)
                .Index(t => t.MedicoId)
                .Index(t => t.ConsultorioId);
            
            CreateTable(
                "dbo.Medico_Especialidade",
                c => new
                    {
                        MedicoId = c.Int(nullable: false),
                        EspecialidadeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MedicoId, t.EspecialidadeId })
                .ForeignKey("dbo.AgendamentoMedico_Medico", t => t.MedicoId)
                .ForeignKey("dbo.AgendamentoMedico_Especialidade", t => t.EspecialidadeId)
                .Index(t => t.MedicoId)
                .Index(t => t.EspecialidadeId);
            
            CreateTable(
                "dbo.Medico_Hospital",
                c => new
                    {
                        MedicoId = c.Int(nullable: false),
                        HospitalId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MedicoId, t.HospitalId })
                .ForeignKey("dbo.AgendamentoMedico_Medico", t => t.MedicoId)
                .ForeignKey("dbo.AgendamentoMedico_Hospital", t => t.HospitalId)
                .Index(t => t.MedicoId)
                .Index(t => t.HospitalId);
            
            CreateTable(
                "dbo.Representante_Fornecedor",
                c => new
                    {
                        RepresentanteId = c.Int(nullable: false),
                        FornecedorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RepresentanteId, t.FornecedorId })
                .ForeignKey("dbo.Cotacao_Representante", t => t.RepresentanteId)
                .ForeignKey("dbo.Cotacao_Fornecedor", t => t.FornecedorId)
                .Index(t => t.RepresentanteId)
                .Index(t => t.FornecedorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BalancoProdutorRural_VendaLeite", "ProdutorRuralId", "dbo.BalancoProdutorRural_ProdutorRural");
            DropForeignKey("dbo.BalancoProdutorRural_VendaGado", "ProdutorRuralId", "dbo.BalancoProdutorRural_ProdutorRural");
            DropForeignKey("dbo.Restaurante_Venda", "ClienteId", "dbo.Restaurante_Cliente");
            DropForeignKey("dbo.Restaurante_Venda", "CardapioId", "dbo.Restaurante_Cardapio");
            DropForeignKey("dbo.QuadroFuncionarios_Registro", "FuncionarioId", "dbo.QuadroFuncionarios_Funcionario");
            DropForeignKey("dbo.QuadroFuncionarios_Registro", "EntidadeId", "dbo.QuadroFuncionarios_Entidade");
            DropForeignKey("dbo.BalancoProdutorRural_ReceitaGeral", "ProdutorRuralId", "dbo.BalancoProdutorRural_ProdutorRural");
            DropForeignKey("dbo.BalancoProdutorRural_Posse", "ProdutorRuralId", "dbo.BalancoProdutorRural_ProdutorRural");
            DropForeignKey("dbo.QuadroFuncionarios_Ocorrencia", "FuncionarioId", "dbo.QuadroFuncionarios_Funcionario");
            DropForeignKey("dbo.QuadroFuncionarios_Ocorrencia", "EntidadeId", "dbo.QuadroFuncionarios_Entidade");
            DropForeignKey("dbo.Restaurante_Mensagem", "ClienteId", "dbo.Restaurante_Cliente");
            DropForeignKey("dbo.Curriculum_InformacaoInicial", "PerfilId", "dbo.Perfil_Perfil");
            DropForeignKey("dbo.Curriculum_Idioma", "PerfilId", "dbo.Perfil_Perfil");
            DropForeignKey("dbo.AgendamentoMedico_Historico", "PacienteId", "dbo.AgendamentoMedico_Paciente");
            DropForeignKey("dbo.AgendamentoMedico_Historico", "MedicoId", "dbo.AgendamentoMedico_Medico");
            DropForeignKey("dbo.Curriculum_Formacao", "PerfilId", "dbo.Perfil_Perfil");
            DropForeignKey("dbo.QuadroFuncionarios_FolhaPonto", "FuncionarioId", "dbo.QuadroFuncionarios_Funcionario");
            DropForeignKey("dbo.QuadroFuncionarios_FolhaPonto", "EntidadeId", "dbo.QuadroFuncionarios_Entidade");
            DropForeignKey("dbo.AgendamentoMedico_Fatura", "PacienteId", "dbo.AgendamentoMedico_Paciente");
            DropForeignKey("dbo.AgendamentoMedico_Fatura", "MedicoId", "dbo.AgendamentoMedico_Medico");
            DropForeignKey("dbo.QuadroFuncionarios_Falta", "FuncionarioId", "dbo.QuadroFuncionarios_Funcionario");
            DropForeignKey("dbo.QuadroFuncionarios_Falta", "EntidadeId", "dbo.QuadroFuncionarios_Entidade");
            DropForeignKey("dbo.Curriculum_Experiencia", "PerfilId", "dbo.Perfil_Perfil");
            DropForeignKey("dbo.QuadroFuncionarios_Funcionario", "EntidadeId", "dbo.QuadroFuncionarios_Entidade");
            DropForeignKey("dbo.BalancoProdutorRural_DespesaGeral", "ProdutorRuralId", "dbo.BalancoProdutorRural_ProdutorRural");
            DropForeignKey("dbo.LivroCaixa_DebitoCaixa", "PerfilId", "dbo.Perfil_Perfil");
            DropForeignKey("dbo.LivroCaixa_CreditoCaixa", "PerfilId", "dbo.Perfil_Perfil");
            DropForeignKey("dbo.Cotacao_Cotacao", "RepresentanteId", "dbo.Cotacao_Representante");
            DropForeignKey("dbo.Representante_Fornecedor", "FornecedorId", "dbo.Cotacao_Fornecedor");
            DropForeignKey("dbo.Representante_Fornecedor", "RepresentanteId", "dbo.Cotacao_Representante");
            DropForeignKey("dbo.Cotacao_Representante", "Fornecedor_Id", "dbo.Cotacao_Fornecedor");
            DropForeignKey("dbo.Cotacao_Cotacao", "ProdutoId", "dbo.Cotacao_Produto");
            DropForeignKey("dbo.AgendamentoMedico_Consulta", "PacienteId", "dbo.AgendamentoMedico_Paciente");
            DropForeignKey("dbo.AgendamentoMedico_Consulta", "MedicoId", "dbo.AgendamentoMedico_Medico");
            DropForeignKey("dbo.AgendamentoMedico_Consulta", "HospitalId", "dbo.AgendamentoMedico_Hospital");
            DropForeignKey("dbo.AgendamentoMedico_Consulta", "ConsultorioId", "dbo.AgendamentoMedico_Consultorio");
            DropForeignKey("dbo.AgendamentoMedico_Medico", "Consultorio_Id", "dbo.AgendamentoMedico_Consultorio");
            DropForeignKey("dbo.Medico_Hospital", "HospitalId", "dbo.AgendamentoMedico_Hospital");
            DropForeignKey("dbo.Medico_Hospital", "MedicoId", "dbo.AgendamentoMedico_Medico");
            DropForeignKey("dbo.AgendamentoMedico_Medico", "Hospital_Id", "dbo.AgendamentoMedico_Hospital");
            DropForeignKey("dbo.Medico_Especialidade", "EspecialidadeId", "dbo.AgendamentoMedico_Especialidade");
            DropForeignKey("dbo.Medico_Especialidade", "MedicoId", "dbo.AgendamentoMedico_Medico");
            DropForeignKey("dbo.AgendamentoMedico_Medico", "Especialidade_Id", "dbo.AgendamentoMedico_Especialidade");
            DropForeignKey("dbo.Medico_Consultorio", "ConsultorioId", "dbo.AgendamentoMedico_Consultorio");
            DropForeignKey("dbo.Medico_Consultorio", "MedicoId", "dbo.AgendamentoMedico_Medico");
            DropForeignKey("dbo.BalancoProdutorRural_CompraGado", "ProdutorRuralId", "dbo.BalancoProdutorRural_ProdutorRural");
            DropForeignKey("dbo.BalancoProdutorRural_Fazenda", "ProdutorRuralId", "dbo.BalancoProdutorRural_ProdutorRural");
            DropForeignKey("dbo.Curriculum_Competencia", "PerfilId", "dbo.Perfil_Perfil");
            DropForeignKey("dbo.Curriculum_Certificado", "PerfilId", "dbo.Perfil_Perfil");
            DropForeignKey("dbo.Cardapio_Item", "ItemId", "dbo.Restaurante_Item");
            DropForeignKey("dbo.Cardapio_Item", "CardapioId", "dbo.Restaurante_Cardapio");
            DropForeignKey("dbo.CaixaArquivo_ItemArquivo", "ItemArquivoId", "dbo.ControleArquivo_ItemArquivo");
            DropForeignKey("dbo.CaixaArquivo_ItemArquivo", "CaixaArquivoId", "dbo.ControleArquivo_CaixaArquivo");
            DropForeignKey("dbo.Agenda_Atividade", "PerfilId", "dbo.Perfil_Perfil");
            DropForeignKey("dbo.Agenda_Atividade", "ContatoTelefonicoId", "dbo.ListaTelefonica_ContatoTelefonico");
            DropForeignKey("dbo.ListaTelefonica_ContatoTelefonico", "PerfilId", "dbo.Perfil_Perfil");
            DropIndex("dbo.Representante_Fornecedor", new[] { "FornecedorId" });
            DropIndex("dbo.Representante_Fornecedor", new[] { "RepresentanteId" });
            DropIndex("dbo.Medico_Hospital", new[] { "HospitalId" });
            DropIndex("dbo.Medico_Hospital", new[] { "MedicoId" });
            DropIndex("dbo.Medico_Especialidade", new[] { "EspecialidadeId" });
            DropIndex("dbo.Medico_Especialidade", new[] { "MedicoId" });
            DropIndex("dbo.Medico_Consultorio", new[] { "ConsultorioId" });
            DropIndex("dbo.Medico_Consultorio", new[] { "MedicoId" });
            DropIndex("dbo.Cardapio_Item", new[] { "ItemId" });
            DropIndex("dbo.Cardapio_Item", new[] { "CardapioId" });
            DropIndex("dbo.CaixaArquivo_ItemArquivo", new[] { "ItemArquivoId" });
            DropIndex("dbo.CaixaArquivo_ItemArquivo", new[] { "CaixaArquivoId" });
            DropIndex("dbo.BalancoProdutorRural_VendaLeite", new[] { "ProdutorRuralId" });
            DropIndex("dbo.BalancoProdutorRural_VendaGado", new[] { "ProdutorRuralId" });
            DropIndex("dbo.Restaurante_Venda", new[] { "ClienteId" });
            DropIndex("dbo.Restaurante_Venda", new[] { "CardapioId" });
            DropIndex("dbo.QuadroFuncionarios_Registro", new[] { "EntidadeId" });
            DropIndex("dbo.QuadroFuncionarios_Registro", new[] { "FuncionarioId" });
            DropIndex("dbo.BalancoProdutorRural_ReceitaGeral", new[] { "ProdutorRuralId" });
            DropIndex("dbo.BalancoProdutorRural_Posse", new[] { "ProdutorRuralId" });
            DropIndex("dbo.QuadroFuncionarios_Ocorrencia", new[] { "EntidadeId" });
            DropIndex("dbo.QuadroFuncionarios_Ocorrencia", new[] { "FuncionarioId" });
            DropIndex("dbo.Restaurante_Mensagem", new[] { "ClienteId" });
            DropIndex("dbo.Curriculum_InformacaoInicial", new[] { "PerfilId" });
            DropIndex("dbo.Curriculum_Idioma", new[] { "PerfilId" });
            DropIndex("dbo.AgendamentoMedico_Historico", new[] { "MedicoId" });
            DropIndex("dbo.AgendamentoMedico_Historico", new[] { "PacienteId" });
            DropIndex("dbo.Curriculum_Formacao", new[] { "PerfilId" });
            DropIndex("dbo.QuadroFuncionarios_FolhaPonto", new[] { "EntidadeId" });
            DropIndex("dbo.QuadroFuncionarios_FolhaPonto", new[] { "FuncionarioId" });
            DropIndex("dbo.AgendamentoMedico_Fatura", new[] { "MedicoId" });
            DropIndex("dbo.AgendamentoMedico_Fatura", new[] { "PacienteId" });
            DropIndex("dbo.QuadroFuncionarios_Falta", new[] { "EntidadeId" });
            DropIndex("dbo.QuadroFuncionarios_Falta", new[] { "FuncionarioId" });
            DropIndex("dbo.Curriculum_Experiencia", new[] { "PerfilId" });
            DropIndex("dbo.QuadroFuncionarios_Funcionario", new[] { "EntidadeId" });
            DropIndex("dbo.BalancoProdutorRural_DespesaGeral", new[] { "ProdutorRuralId" });
            DropIndex("dbo.LivroCaixa_DebitoCaixa", new[] { "PerfilId" });
            DropIndex("dbo.LivroCaixa_CreditoCaixa", new[] { "PerfilId" });
            DropIndex("dbo.Cotacao_Representante", new[] { "Fornecedor_Id" });
            DropIndex("dbo.Cotacao_Cotacao", new[] { "RepresentanteId" });
            DropIndex("dbo.Cotacao_Cotacao", new[] { "ProdutoId" });
            DropIndex("dbo.AgendamentoMedico_Medico", new[] { "Consultorio_Id" });
            DropIndex("dbo.AgendamentoMedico_Medico", new[] { "Hospital_Id" });
            DropIndex("dbo.AgendamentoMedico_Medico", new[] { "Especialidade_Id" });
            DropIndex("dbo.AgendamentoMedico_Consulta", new[] { "HospitalId" });
            DropIndex("dbo.AgendamentoMedico_Consulta", new[] { "ConsultorioId" });
            DropIndex("dbo.AgendamentoMedico_Consulta", new[] { "MedicoId" });
            DropIndex("dbo.AgendamentoMedico_Consulta", new[] { "PacienteId" });
            DropIndex("dbo.BalancoProdutorRural_Fazenda", new[] { "ProdutorRuralId" });
            DropIndex("dbo.BalancoProdutorRural_CompraGado", new[] { "ProdutorRuralId" });
            DropIndex("dbo.Curriculum_Competencia", new[] { "PerfilId" });
            DropIndex("dbo.Curriculum_Certificado", new[] { "PerfilId" });
            DropIndex("dbo.ListaTelefonica_ContatoTelefonico", new[] { "PerfilId" });
            DropIndex("dbo.Agenda_Atividade", new[] { "ContatoTelefonicoId" });
            DropIndex("dbo.Agenda_Atividade", new[] { "PerfilId" });
            DropTable("dbo.Representante_Fornecedor");
            DropTable("dbo.Medico_Hospital");
            DropTable("dbo.Medico_Especialidade");
            DropTable("dbo.Medico_Consultorio");
            DropTable("dbo.Cardapio_Item");
            DropTable("dbo.CaixaArquivo_ItemArquivo");
            DropTable("dbo.BalancoProdutorRural_VendaLeite");
            DropTable("dbo.BalancoProdutorRural_VendaGado");
            DropTable("dbo.Restaurante_Venda");
            DropTable("dbo.QuadroFuncionarios_Registro");
            DropTable("dbo.BalancoProdutorRural_ReceitaGeral");
            DropTable("dbo.BalancoProdutorRural_Posse");
            DropTable("dbo.QuadroFuncionarios_Ocorrencia");
            DropTable("dbo.Restaurante_Mensagem");
            DropTable("dbo.Curriculum_InformacaoInicial");
            DropTable("dbo.Curriculum_Idioma");
            DropTable("dbo.AgendamentoMedico_Historico");
            DropTable("dbo.Curriculum_Formacao");
            DropTable("dbo.QuadroFuncionarios_FolhaPonto");
            DropTable("dbo.AgendamentoMedico_Fatura");
            DropTable("dbo.QuadroFuncionarios_Falta");
            DropTable("dbo.Curriculum_Experiencia");
            DropTable("dbo.QuadroFuncionarios_Funcionario");
            DropTable("dbo.QuadroFuncionarios_Entidade");
            DropTable("dbo.BalancoProdutorRural_DespesaGeral");
            DropTable("dbo.LivroCaixa_DebitoCaixa");
            DropTable("dbo.LivroCaixa_CreditoCaixa");
            DropTable("dbo.Cotacao_Fornecedor");
            DropTable("dbo.Cotacao_Representante");
            DropTable("dbo.Cotacao_Produto");
            DropTable("dbo.Cotacao_Cotacao");
            DropTable("dbo.Contato_ContatoProfissional");
            DropTable("dbo.AgendamentoMedico_Paciente");
            DropTable("dbo.AgendamentoMedico_Hospital");
            DropTable("dbo.AgendamentoMedico_Especialidade");
            DropTable("dbo.AgendamentoMedico_Medico");
            DropTable("dbo.AgendamentoMedico_Consultorio");
            DropTable("dbo.AgendamentoMedico_Consulta");
            DropTable("dbo.BalancoProdutorRural_Fazenda");
            DropTable("dbo.BalancoProdutorRural_ProdutorRural");
            DropTable("dbo.BalancoProdutorRural_CompraGado");
            DropTable("dbo.Curriculum_Competencia");
            DropTable("dbo.Restaurante_Cliente");
            DropTable("dbo.Curriculum_Certificado");
            DropTable("dbo.Restaurante_Item");
            DropTable("dbo.Restaurante_Cardapio");
            DropTable("dbo.ControleArquivo_ItemArquivo");
            DropTable("dbo.ControleArquivo_CaixaArquivo");
            DropTable("dbo.Perfil_Perfil");
            DropTable("dbo.ListaTelefonica_ContatoTelefonico");
            DropTable("dbo.Agenda_Atividade");
        }
    }
}

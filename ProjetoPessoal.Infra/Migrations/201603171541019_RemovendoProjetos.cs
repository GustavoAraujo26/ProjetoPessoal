namespace ProjetoPessoal.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovendoProjetos : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CaixaArquivo_ItemArquivo", "CaixaArquivoId", "dbo.ControleArquivo_CaixaArquivo");
            DropForeignKey("dbo.CaixaArquivo_ItemArquivo", "ItemArquivoId", "dbo.ControleArquivo_ItemArquivo");
            DropForeignKey("dbo.Medico_Consultorio", "MedicoId", "dbo.AgendamentoMedico_Medico");
            DropForeignKey("dbo.Medico_Consultorio", "ConsultorioId", "dbo.AgendamentoMedico_Consultorio");
            DropForeignKey("dbo.AgendamentoMedico_Medico", "Especialidade_Id", "dbo.AgendamentoMedico_Especialidade");
            DropForeignKey("dbo.Medico_Especialidade", "MedicoId", "dbo.AgendamentoMedico_Medico");
            DropForeignKey("dbo.Medico_Especialidade", "EspecialidadeId", "dbo.AgendamentoMedico_Especialidade");
            DropForeignKey("dbo.AgendamentoMedico_Medico", "Hospital_Id", "dbo.AgendamentoMedico_Hospital");
            DropForeignKey("dbo.Medico_Hospital", "MedicoId", "dbo.AgendamentoMedico_Medico");
            DropForeignKey("dbo.Medico_Hospital", "HospitalId", "dbo.AgendamentoMedico_Hospital");
            DropForeignKey("dbo.AgendamentoMedico_Medico", "Consultorio_Id", "dbo.AgendamentoMedico_Consultorio");
            DropForeignKey("dbo.AgendamentoMedico_Consulta", "ConsultorioId", "dbo.AgendamentoMedico_Consultorio");
            DropForeignKey("dbo.AgendamentoMedico_Consulta", "HospitalId", "dbo.AgendamentoMedico_Hospital");
            DropForeignKey("dbo.AgendamentoMedico_Consulta", "MedicoId", "dbo.AgendamentoMedico_Medico");
            DropForeignKey("dbo.AgendamentoMedico_Consulta", "PacienteId", "dbo.AgendamentoMedico_Paciente");
            DropForeignKey("dbo.QuadroFuncionarios_Funcionario", "EntidadeId", "dbo.QuadroFuncionarios_Entidade");
            DropForeignKey("dbo.QuadroFuncionarios_Falta", "EntidadeId", "dbo.QuadroFuncionarios_Entidade");
            DropForeignKey("dbo.QuadroFuncionarios_Falta", "FuncionarioId", "dbo.QuadroFuncionarios_Funcionario");
            DropForeignKey("dbo.AgendamentoMedico_Fatura", "MedicoId", "dbo.AgendamentoMedico_Medico");
            DropForeignKey("dbo.AgendamentoMedico_Fatura", "PacienteId", "dbo.AgendamentoMedico_Paciente");
            DropForeignKey("dbo.QuadroFuncionarios_FolhaPonto", "EntidadeId", "dbo.QuadroFuncionarios_Entidade");
            DropForeignKey("dbo.QuadroFuncionarios_FolhaPonto", "FuncionarioId", "dbo.QuadroFuncionarios_Funcionario");
            DropForeignKey("dbo.AgendamentoMedico_Historico", "MedicoId", "dbo.AgendamentoMedico_Medico");
            DropForeignKey("dbo.AgendamentoMedico_Historico", "PacienteId", "dbo.AgendamentoMedico_Paciente");
            DropForeignKey("dbo.QuadroFuncionarios_Ocorrencia", "EntidadeId", "dbo.QuadroFuncionarios_Entidade");
            DropForeignKey("dbo.QuadroFuncionarios_Ocorrencia", "FuncionarioId", "dbo.QuadroFuncionarios_Funcionario");
            DropForeignKey("dbo.QuadroFuncionarios_Registro", "EntidadeId", "dbo.QuadroFuncionarios_Entidade");
            DropForeignKey("dbo.QuadroFuncionarios_Registro", "FuncionarioId", "dbo.QuadroFuncionarios_Funcionario");
            DropIndex("dbo.AgendamentoMedico_Consulta", new[] { "PacienteId" });
            DropIndex("dbo.AgendamentoMedico_Consulta", new[] { "MedicoId" });
            DropIndex("dbo.AgendamentoMedico_Consulta", new[] { "ConsultorioId" });
            DropIndex("dbo.AgendamentoMedico_Consulta", new[] { "HospitalId" });
            DropIndex("dbo.AgendamentoMedico_Medico", new[] { "Especialidade_Id" });
            DropIndex("dbo.AgendamentoMedico_Medico", new[] { "Hospital_Id" });
            DropIndex("dbo.AgendamentoMedico_Medico", new[] { "Consultorio_Id" });
            DropIndex("dbo.QuadroFuncionarios_Funcionario", new[] { "EntidadeId" });
            DropIndex("dbo.QuadroFuncionarios_Falta", new[] { "FuncionarioId" });
            DropIndex("dbo.QuadroFuncionarios_Falta", new[] { "EntidadeId" });
            DropIndex("dbo.AgendamentoMedico_Fatura", new[] { "PacienteId" });
            DropIndex("dbo.AgendamentoMedico_Fatura", new[] { "MedicoId" });
            DropIndex("dbo.QuadroFuncionarios_FolhaPonto", new[] { "FuncionarioId" });
            DropIndex("dbo.QuadroFuncionarios_FolhaPonto", new[] { "EntidadeId" });
            DropIndex("dbo.AgendamentoMedico_Historico", new[] { "PacienteId" });
            DropIndex("dbo.AgendamentoMedico_Historico", new[] { "MedicoId" });
            DropIndex("dbo.QuadroFuncionarios_Ocorrencia", new[] { "FuncionarioId" });
            DropIndex("dbo.QuadroFuncionarios_Ocorrencia", new[] { "EntidadeId" });
            DropIndex("dbo.QuadroFuncionarios_Registro", new[] { "FuncionarioId" });
            DropIndex("dbo.QuadroFuncionarios_Registro", new[] { "EntidadeId" });
            DropIndex("dbo.CaixaArquivo_ItemArquivo", new[] { "CaixaArquivoId" });
            DropIndex("dbo.CaixaArquivo_ItemArquivo", new[] { "ItemArquivoId" });
            DropIndex("dbo.Medico_Consultorio", new[] { "MedicoId" });
            DropIndex("dbo.Medico_Consultorio", new[] { "ConsultorioId" });
            DropIndex("dbo.Medico_Especialidade", new[] { "MedicoId" });
            DropIndex("dbo.Medico_Especialidade", new[] { "EspecialidadeId" });
            DropIndex("dbo.Medico_Hospital", new[] { "MedicoId" });
            DropIndex("dbo.Medico_Hospital", new[] { "HospitalId" });
            DropTable("dbo.ControleArquivo_CaixaArquivo");
            DropTable("dbo.ControleArquivo_ItemArquivo");
            DropTable("dbo.AgendamentoMedico_Consulta");
            DropTable("dbo.AgendamentoMedico_Consultorio");
            DropTable("dbo.AgendamentoMedico_Medico");
            DropTable("dbo.AgendamentoMedico_Especialidade");
            DropTable("dbo.AgendamentoMedico_Hospital");
            DropTable("dbo.AgendamentoMedico_Paciente");
            DropTable("dbo.QuadroFuncionarios_Entidade");
            DropTable("dbo.QuadroFuncionarios_Funcionario");
            DropTable("dbo.QuadroFuncionarios_Falta");
            DropTable("dbo.AgendamentoMedico_Fatura");
            DropTable("dbo.QuadroFuncionarios_FolhaPonto");
            DropTable("dbo.AgendamentoMedico_Historico");
            DropTable("dbo.QuadroFuncionarios_Ocorrencia");
            DropTable("dbo.QuadroFuncionarios_Registro");
            DropTable("dbo.CaixaArquivo_ItemArquivo");
            DropTable("dbo.Medico_Consultorio");
            DropTable("dbo.Medico_Especialidade");
            DropTable("dbo.Medico_Hospital");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Medico_Hospital",
                c => new
                    {
                        MedicoId = c.Int(nullable: false),
                        HospitalId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MedicoId, t.HospitalId });
            
            CreateTable(
                "dbo.Medico_Especialidade",
                c => new
                    {
                        MedicoId = c.Int(nullable: false),
                        EspecialidadeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MedicoId, t.EspecialidadeId });
            
            CreateTable(
                "dbo.Medico_Consultorio",
                c => new
                    {
                        MedicoId = c.Int(nullable: false),
                        ConsultorioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MedicoId, t.ConsultorioId });
            
            CreateTable(
                "dbo.CaixaArquivo_ItemArquivo",
                c => new
                    {
                        CaixaArquivoId = c.Int(nullable: false),
                        ItemArquivoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CaixaArquivoId, t.ItemArquivoId });
            
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
                .PrimaryKey(t => t.Id);
            
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
                .PrimaryKey(t => t.Id);
            
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
                .PrimaryKey(t => t.Id);
            
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
                .PrimaryKey(t => t.Id);
            
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
                .PrimaryKey(t => t.Id);
            
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
                .PrimaryKey(t => t.Id);
            
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
                "dbo.AgendamentoMedico_Especialidade",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 500, unicode: false),
                        Descricao = c.String(maxLength: 8000, unicode: false),
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
                .PrimaryKey(t => t.Id);
            
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
                "dbo.ControleArquivo_CaixaArquivo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false, storeType: "date"),
                        Observacao = c.String(maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Medico_Hospital", "HospitalId");
            CreateIndex("dbo.Medico_Hospital", "MedicoId");
            CreateIndex("dbo.Medico_Especialidade", "EspecialidadeId");
            CreateIndex("dbo.Medico_Especialidade", "MedicoId");
            CreateIndex("dbo.Medico_Consultorio", "ConsultorioId");
            CreateIndex("dbo.Medico_Consultorio", "MedicoId");
            CreateIndex("dbo.CaixaArquivo_ItemArquivo", "ItemArquivoId");
            CreateIndex("dbo.CaixaArquivo_ItemArquivo", "CaixaArquivoId");
            CreateIndex("dbo.QuadroFuncionarios_Registro", "EntidadeId");
            CreateIndex("dbo.QuadroFuncionarios_Registro", "FuncionarioId");
            CreateIndex("dbo.QuadroFuncionarios_Ocorrencia", "EntidadeId");
            CreateIndex("dbo.QuadroFuncionarios_Ocorrencia", "FuncionarioId");
            CreateIndex("dbo.AgendamentoMedico_Historico", "MedicoId");
            CreateIndex("dbo.AgendamentoMedico_Historico", "PacienteId");
            CreateIndex("dbo.QuadroFuncionarios_FolhaPonto", "EntidadeId");
            CreateIndex("dbo.QuadroFuncionarios_FolhaPonto", "FuncionarioId");
            CreateIndex("dbo.AgendamentoMedico_Fatura", "MedicoId");
            CreateIndex("dbo.AgendamentoMedico_Fatura", "PacienteId");
            CreateIndex("dbo.QuadroFuncionarios_Falta", "EntidadeId");
            CreateIndex("dbo.QuadroFuncionarios_Falta", "FuncionarioId");
            CreateIndex("dbo.QuadroFuncionarios_Funcionario", "EntidadeId");
            CreateIndex("dbo.AgendamentoMedico_Medico", "Consultorio_Id");
            CreateIndex("dbo.AgendamentoMedico_Medico", "Hospital_Id");
            CreateIndex("dbo.AgendamentoMedico_Medico", "Especialidade_Id");
            CreateIndex("dbo.AgendamentoMedico_Consulta", "HospitalId");
            CreateIndex("dbo.AgendamentoMedico_Consulta", "ConsultorioId");
            CreateIndex("dbo.AgendamentoMedico_Consulta", "MedicoId");
            CreateIndex("dbo.AgendamentoMedico_Consulta", "PacienteId");
            AddForeignKey("dbo.QuadroFuncionarios_Registro", "FuncionarioId", "dbo.QuadroFuncionarios_Funcionario", "Id");
            AddForeignKey("dbo.QuadroFuncionarios_Registro", "EntidadeId", "dbo.QuadroFuncionarios_Entidade", "Id", cascadeDelete: true);
            AddForeignKey("dbo.QuadroFuncionarios_Ocorrencia", "FuncionarioId", "dbo.QuadroFuncionarios_Funcionario", "Id");
            AddForeignKey("dbo.QuadroFuncionarios_Ocorrencia", "EntidadeId", "dbo.QuadroFuncionarios_Entidade", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AgendamentoMedico_Historico", "PacienteId", "dbo.AgendamentoMedico_Paciente", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AgendamentoMedico_Historico", "MedicoId", "dbo.AgendamentoMedico_Medico", "Id");
            AddForeignKey("dbo.QuadroFuncionarios_FolhaPonto", "FuncionarioId", "dbo.QuadroFuncionarios_Funcionario", "Id");
            AddForeignKey("dbo.QuadroFuncionarios_FolhaPonto", "EntidadeId", "dbo.QuadroFuncionarios_Entidade", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AgendamentoMedico_Fatura", "PacienteId", "dbo.AgendamentoMedico_Paciente", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AgendamentoMedico_Fatura", "MedicoId", "dbo.AgendamentoMedico_Medico", "Id", cascadeDelete: true);
            AddForeignKey("dbo.QuadroFuncionarios_Falta", "FuncionarioId", "dbo.QuadroFuncionarios_Funcionario", "Id");
            AddForeignKey("dbo.QuadroFuncionarios_Falta", "EntidadeId", "dbo.QuadroFuncionarios_Entidade", "Id", cascadeDelete: true);
            AddForeignKey("dbo.QuadroFuncionarios_Funcionario", "EntidadeId", "dbo.QuadroFuncionarios_Entidade", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AgendamentoMedico_Consulta", "PacienteId", "dbo.AgendamentoMedico_Paciente", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AgendamentoMedico_Consulta", "MedicoId", "dbo.AgendamentoMedico_Medico", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AgendamentoMedico_Consulta", "HospitalId", "dbo.AgendamentoMedico_Hospital", "Id");
            AddForeignKey("dbo.AgendamentoMedico_Consulta", "ConsultorioId", "dbo.AgendamentoMedico_Consultorio", "Id");
            AddForeignKey("dbo.AgendamentoMedico_Medico", "Consultorio_Id", "dbo.AgendamentoMedico_Consultorio", "Id");
            AddForeignKey("dbo.Medico_Hospital", "HospitalId", "dbo.AgendamentoMedico_Hospital", "Id");
            AddForeignKey("dbo.Medico_Hospital", "MedicoId", "dbo.AgendamentoMedico_Medico", "Id");
            AddForeignKey("dbo.AgendamentoMedico_Medico", "Hospital_Id", "dbo.AgendamentoMedico_Hospital", "Id");
            AddForeignKey("dbo.Medico_Especialidade", "EspecialidadeId", "dbo.AgendamentoMedico_Especialidade", "Id");
            AddForeignKey("dbo.Medico_Especialidade", "MedicoId", "dbo.AgendamentoMedico_Medico", "Id");
            AddForeignKey("dbo.AgendamentoMedico_Medico", "Especialidade_Id", "dbo.AgendamentoMedico_Especialidade", "Id");
            AddForeignKey("dbo.Medico_Consultorio", "ConsultorioId", "dbo.AgendamentoMedico_Consultorio", "Id");
            AddForeignKey("dbo.Medico_Consultorio", "MedicoId", "dbo.AgendamentoMedico_Medico", "Id");
            AddForeignKey("dbo.CaixaArquivo_ItemArquivo", "ItemArquivoId", "dbo.ControleArquivo_ItemArquivo", "Id");
            AddForeignKey("dbo.CaixaArquivo_ItemArquivo", "CaixaArquivoId", "dbo.ControleArquivo_CaixaArquivo", "Id");
        }
    }
}

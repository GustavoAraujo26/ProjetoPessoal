namespace ProjetoPessoal.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovendoRestaurante : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cardapio_Item", "CardapioId", "dbo.Restaurante_Cardapio");
            DropForeignKey("dbo.Cardapio_Item", "ItemId", "dbo.Restaurante_Item");
            DropForeignKey("dbo.Restaurante_Mensagem", "ClienteId", "dbo.Restaurante_Cliente");
            DropForeignKey("dbo.Restaurante_Venda", "CardapioId", "dbo.Restaurante_Cardapio");
            DropForeignKey("dbo.Restaurante_Venda", "ClienteId", "dbo.Restaurante_Cliente");
            DropIndex("dbo.Restaurante_Mensagem", new[] { "ClienteId" });
            DropIndex("dbo.Restaurante_Venda", new[] { "CardapioId" });
            DropIndex("dbo.Restaurante_Venda", new[] { "ClienteId" });
            DropIndex("dbo.Cardapio_Item", new[] { "CardapioId" });
            DropIndex("dbo.Cardapio_Item", new[] { "ItemId" });
            DropTable("dbo.Restaurante_Cardapio");
            DropTable("dbo.Restaurante_Item");
            DropTable("dbo.Restaurante_Cliente");
            DropTable("dbo.Restaurante_Mensagem");
            DropTable("dbo.Restaurante_Venda");
            DropTable("dbo.Cardapio_Item");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Cardapio_Item",
                c => new
                    {
                        CardapioId = c.Int(nullable: false),
                        ItemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CardapioId, t.ItemId });
            
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
                .PrimaryKey(t => t.Id);
            
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
                .PrimaryKey(t => t.Id);
            
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
                "dbo.Restaurante_Item",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 1000, unicode: false),
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
            
            CreateIndex("dbo.Cardapio_Item", "ItemId");
            CreateIndex("dbo.Cardapio_Item", "CardapioId");
            CreateIndex("dbo.Restaurante_Venda", "ClienteId");
            CreateIndex("dbo.Restaurante_Venda", "CardapioId");
            CreateIndex("dbo.Restaurante_Mensagem", "ClienteId");
            AddForeignKey("dbo.Restaurante_Venda", "ClienteId", "dbo.Restaurante_Cliente", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Restaurante_Venda", "CardapioId", "dbo.Restaurante_Cardapio", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Restaurante_Mensagem", "ClienteId", "dbo.Restaurante_Cliente", "Id");
            AddForeignKey("dbo.Cardapio_Item", "ItemId", "dbo.Restaurante_Item", "Id");
            AddForeignKey("dbo.Cardapio_Item", "CardapioId", "dbo.Restaurante_Cardapio", "Id");
        }
    }
}

namespace DPGERJ.Recepcao.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inital : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assistido",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100),
                        Documento = c.String(nullable: false, maxLength: 20),
                        OrgaoEmissor = c.String(maxLength: 20),
                        ImagemUrl = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Visita",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PessoaMotivo = c.String(nullable: false, maxLength: 50),
                        DataCadastro = c.DateTime(nullable: false),
                        AssistidoId = c.Int(nullable: false),
                        DestinoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Assistido", t => t.AssistidoId, cascadeDelete: true)
                .ForeignKey("dbo.Destino", t => t.DestinoId, cascadeDelete: true)
                .Index(t => t.AssistidoId)
                .Index(t => t.DestinoId);
            
            CreateTable(
                "dbo.Destino",
                c => new
                    {
                        DestinoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 30),
                        Andar = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.DestinoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Visita", "DestinoId", "dbo.Destino");
            DropForeignKey("dbo.Visita", "AssistidoId", "dbo.Assistido");
            DropIndex("dbo.Visita", new[] { "DestinoId" });
            DropIndex("dbo.Visita", new[] { "AssistidoId" });
            DropTable("dbo.Destino");
            DropTable("dbo.Visita");
            DropTable("dbo.Assistido");
        }
    }
}

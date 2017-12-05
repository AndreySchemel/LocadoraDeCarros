namespace LocadoraDeCarros.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AtualizarCampos : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clientes", "Telefone", c => c.Long());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Clientes", "Telefone", c => c.Long(nullable: false));
        }
    }
}

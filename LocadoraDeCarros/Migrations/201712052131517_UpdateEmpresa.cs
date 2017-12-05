namespace LocadoraDeCarros.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateEmpresa : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Empresas", "TipoEmpresa");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Empresas", "TipoEmpresa", c => c.Boolean(nullable: false));
        }
    }
}

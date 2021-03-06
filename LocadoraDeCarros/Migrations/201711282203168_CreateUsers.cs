namespace LocadoraDeCarros.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'4da75a60-bca4-46bc-83e8-694a3d3ede3b', N'andrey1@gmail.com', 0, N'ADP+GelY6woQWGVXFmnsb2CFb/1doVOVoWl8YUciyRemLtKZiOfIzL1yoVE/W+T2yw==', N'f932c673-86c3-462e-a62f-5473d3f5eb5b', NULL, 0, 0, NULL, 1, 0, N'andrey1@gmail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'7ee375d0-cd13-442f-8620-3fdafbc7659b', N'andrey@gmail.com', 0, N'AEUMZiF83dw9HnUqp+BjOlUboMCuzDmS7K7YeuZpnDeYUEQ79hpquwFRIJBCrgCpfg==', N'adb672d3-a41b-40bf-91da-bd60c0f6d0f8', NULL, 0, 0, NULL, 1, 0, N'andrey@gmail.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'b55ff480-bf9e-4464-a9d5-c93ac8e6ee2d', N'CanManage')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'7ee375d0-cd13-442f-8620-3fdafbc7659b', N'b55ff480-bf9e-4464-a9d5-c93ac8e6ee2d')

");
        }
        
        public override void Down()
        {
        }
    }
}

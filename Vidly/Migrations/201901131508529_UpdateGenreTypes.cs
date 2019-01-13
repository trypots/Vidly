namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateGenreTypes : DbMigration
    {
        public override void Up()
        {
			Sql("set identity_insert dbo.Genres on; insert into Genres (Id, Name) values (1, 'Science Fiction'); set identity_insert dbo.Genres off;");
			Sql("set identity_insert dbo.Genres on; insert into Genres (Id, Name) values (2, 'Drama'); set identity_insert dbo.Genres off; ");
			Sql("set identity_insert dbo.Genres on; insert into Genres (Id, Name) values (3, 'Comedy'); set identity_insert dbo.Genres off; ");
			Sql("set identity_insert dbo.Genres on; insert into Genres (Id, Name) values (4, 'Action'); set identity_insert dbo.Genres off; ");
			Sql("set identity_insert dbo.Genres on; insert into Genres (Id, Name) values (5, 'Animated'); set identity_insert dbo.Genres off; ");
		}

		public override void Down()
        {
			Sql("delete Genres where Id in (1,2,3,4,5)");
		}
	}
}

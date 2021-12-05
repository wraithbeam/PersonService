namespace PersonService.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using PersonService.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<PersonService.Data.ApplicationDbContextContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PersonService.Data.ApplicationDbContextContext context)
        {
            //  This method will be called after migrating to the latest version. 



            //  You can use the DbSet<T>.AddOrUpdate() helper extension method  

            //  to avoid creating duplicate seed data. E.g. 

            // 

            context.Titles.AddOrUpdate(x => x.Id,

                new Title() { Id = 1, Role = "��������" },

                new Title() { Id = 2, Role = "���������" },

                new Title() { Id = 3, Role = "��������" }

                );



            context.People.AddOrUpdate(x => x.Id,

                new Person()
                {
                    Id = 1,

                    BirstDate = new DateTime(1998, 3, 21),

                    Email = "ivanov@mail.ru",

                    FirstName = "����",

                    LastName = "������",

                    SecondName = "��������",
                    Phone = "+7 961 654 3245",
                    TitleId = 1
                },

                new Person()

                {

                    Id = 2,

                    BirstDate = new DateTime(1999, 11, 1),

                    Email = "ivanov@mail.ru",

                    FirstName = "����",

                    LastName = "������",

                    SecondName = "��������",

                    Phone = "+7 961 266 3244",

                    TitleId = 2
                },

                new Person()

                {

                    Id = 3,

                    BirstDate = new DateTime(1994, 10, 7),

                    Email = "ivanov@mail.ru",

                    FirstName = "�����",

                    LastName = "�������",

                    SecondName = "���������",

                    Phone = "+7 961 261 3444",

                    TitleId = 3
                },

                new Person()

                {

                    Id = 3,

                    BirstDate = new DateTime(1990, 12, 30),

                    Email = "ivanov@mail.ru",

                    FirstName = "������",

                    LastName = "����������",

                    SecondName = "��������",

                    Phone = "+7 961 261 4444",

                    TitleId = 3
                });

        }
    }
}

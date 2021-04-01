using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using SürücuKursu.Entities;

namespace SürücüKursu.DataAccessLayer
{
    public class Initializer : CreateDatabaseIfNotExists<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            SürücüKursuUser admin = new SürücüKursuUser()
            {
                Name = "Olcay",
                Surname = "Ertaşmış",
                Email = "ertasolcay@hotmail.com",
                ActivateGuid = Guid.NewGuid(),
                IsAdmin = true,
                Username = "olcayertas",
                Password = "123456",
                CreatedOn = DateTime.Now,
                //ModifiedOn = DateTime.Now.AddMinutes(5),
            };
            SürücüKursuUser standartUser = new SürücüKursuUser()
            {
                Name = "Onur",
                Surname = "Ertaşmış",
                Email = "ertasonurr@hotmail.com",
                ActivateGuid = Guid.NewGuid(),
                IsAdmin = false,
                Username = "onurertas",
                Password = "159753",
                CreatedOn = DateTime.Now.AddHours(1),
                //ModifiedOn = DateTime.Now.AddMinutes(65),
            };
            context.SürücuKursuUser.Add(admin);
            context.SürücuKursuUser.Add(standartUser);

            for (int i = 0; i < 8; i++)
            {
                SürücüKursuUser user = new SürücüKursuUser()
                {
                    Name = FakeData.NameData.GetFirstName(),
                    Surname = FakeData.NameData.GetSurname(),
                    Email = FakeData.NetworkData.GetEmail(),
                    ActivateGuid = Guid.NewGuid(),
                    IsAdmin = false,
                    Username = $"user{i}",
                    Password = "123",
                    CreatedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                    //ModifiedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                };
                context.SürücuKursuUser.Add(user);
            }
            context.SaveChanges();

            //user listesini kullanmak içn
            List<SürücüKursuUser> userList = context.SürücuKursuUser.ToList();

            //fake note
            for (int i = 0; i < FakeData.NumberData.GetNumber(5, 9); i++)
            {
                Note note = new Note()
                {
                    Title = FakeData.TextData.GetAlphabetical(FakeData.NumberData.GetNumber(5, 15)),
                    Text = FakeData.TextData.GetSentences(FakeData.NumberData.GetNumber(1, 3)),
                    //Owner = admin,
                    CreatedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                    //ModifiedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                };
                context.Notes.Add(note);

                //adding fake comment
                for (int k = 0; k < FakeData.NumberData.GetNumber(3, 5); k++)
                {
                    SürücüKursuUser comment_owner = userList[FakeData.NumberData.GetNumber(0, userList.Count - 1)];

                    Comment comment = new Comment()
                    {
                        Text = FakeData.TextData.GetSentence(),
                        Owner = userList[FakeData.NumberData.GetNumber(0, userList.Count - 1)],
                        CreatedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                        //ModifiedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                    };
                    note.Comments.Add(comment);
                }
            }
            context.SaveChanges();
        }
    }
}

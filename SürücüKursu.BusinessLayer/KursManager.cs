using SürücuKursu.Entities;
using SürücüKursu.Entitites.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using SürücüKursu.BusinessLayer;


namespace SürücüKursu.BusinessLayer
{
    public class KursManager
    {
        Repository<SürücüKursuUser> repo_user = new Repository<SürücüKursuUser>();
        public void RegisterUser(RegisterViewModel data)
        {
            SürücüKursuUser user = repo_user.Find(x => x.Username == data.Username || x.Email == data.Email);
            if (user != null)
            {
                throw new Exception("Kayıtlı kullanıcı adı ya da e-posta adresi");

            }
            else
            {
                repo_user.Insert(new SürücüKursuUser()
                {
                   
                    Username = data.Username,
                    Email = data.Email,
                    Password = data.Password,
                    ActivateGuid = Guid.NewGuid(),
                    CreatedOn = DateTime.Now,
                    IsAdmin = false,
                });
            }
        }

        public void LoginUser(LoginViewModel data)
        {
            SürücüKursuUser user = repo_user.Find(x => x.Username == data.Username || x.Password == data.Password);
            if (user != null)
            {

            }
            else
            {
                throw new Exception("Kullanıcı adı ya da şifre yanlış");
            }
        }
    }
}

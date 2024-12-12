using System.Linq;
using System.Web.Mvc;
using StoringPassword.Models;
using System.Security.Cryptography;
using System.Text;

namespace StoringPassword.Controllers
{
    public class AccountController : Controller
    {
        private UserContext db = new UserContext();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel logon)
        {
            if (ModelState.IsValid)
            {
                if(db.Users.ToList().Count == 0)
                {
                    ModelState.AddModelError("", "Wrong login!");
                    return View(logon);
                }
                var users = db.Users.Where(a => a.Login == logon.Login);
                if (users.ToList().Count == 0)
                {
                    ModelState.AddModelError("", "Wrong login!");
                    return View(logon);
                }
                var user = users.First();
                string salt = user.Salt;

                //переводим пароль в байт-массив  
                byte[] password = Encoding.Unicode.GetBytes(salt + logon.Password);

                //создаем объект для получения средств шифрования  
                MD5CryptoServiceProvider CSP = new MD5CryptoServiceProvider();

                //вычисляем хеш-представление в байтах  
                byte[] byteHash = CSP.ComputeHash(password);

                StringBuilder hash = new StringBuilder(byteHash.Length);
                for (int i = 0; i < byteHash.Length; i++)
                    hash.Append(string.Format("{0:X2}", byteHash[i]));

                if (user.Password != hash.ToString())
                {
                    ModelState.AddModelError("", "Wrong password!");
                    return View(logon);
                }
                Session["FirstName"] = user.FirstName;
                Session["LastName"] = user.LastName;
                return RedirectToAction("Index", "Home");
            }
            return View(logon);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel reg)
        {
            if (ModelState.IsValid)
            {
                User user = new User();
                user.FirstName = reg.FirstName;
                user.LastName = reg.LastName;
                user.Login = reg.Login;

                byte[] saltbuf = new byte[16];

                // Реализует криптографический генератор случайных чисел, используя реализацию, предоставляемую поставщиком служб шифрования (CSP). 
                RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
                rng.GetBytes(saltbuf);

                StringBuilder sb = new StringBuilder(16);
                for (int i = 0; i < 16; i++)
                    sb.Append(string.Format("{0:X2}", saltbuf[i]));
                string salt = sb.ToString();

                //переводим пароль в байт-массив  
                byte[] password = Encoding.Unicode.GetBytes(salt + reg.Password);

                //создаем объект для получения средств шифрования  
                MD5CryptoServiceProvider CSP = new MD5CryptoServiceProvider();

                //вычисляем хеш-представление в байтах  
                byte[] byteHash = CSP.ComputeHash(password);

                StringBuilder hash = new StringBuilder(byteHash.Length);
                for (int i = 0; i < byteHash.Length; i++)
                    hash.Append(string.Format("{0:X2}", byteHash[i]));

                user.Password = hash.ToString();
                user.Salt = salt;
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Login");
            }

            return View(reg);
        }
    }
}
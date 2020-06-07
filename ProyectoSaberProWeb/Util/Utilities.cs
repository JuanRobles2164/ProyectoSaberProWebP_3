using ProyectoSaberProWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace ProyectoSaberProWeb.Util
{
    public class Utilities
    {
        public static IEnumerable<ApplicationUser> getUsersByRoleId(string role, ApplicationDbContext db)
        {
            var usuarios = db.Users.Where(user => user.Roles.All(urm => urm.RoleId == role));
            return usuarios;
        }
        public static void SendEmail(string MailAdressTo, string body, bool isBodyHtml)
        {
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("geapsp2020@gmail.com");
            msg.To.Add(MailAdressTo);
            msg.Subject = "GEA";
            msg.IsBodyHtml = isBodyHtml;
            msg.Body = body;
            SmtpClient sc = new SmtpClient("smtp.gmail.com");
            sc.Port = 25;
            sc.Credentials = new NetworkCredential("geapsp2020@gmail.com", "zqoshuqcjbkkfsgk");
            sc.EnableSsl = true;
            sc.Send(msg);
        }
    }
}
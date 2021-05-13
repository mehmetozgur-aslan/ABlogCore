using ABlogCore.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ABlogCore.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HelperController : ControllerBase
    {
        [HttpPost]

        public IActionResult SendContactEmail(Contact contact)

        {
            try

            {
                MailMessage mailMessage = new MailMessage();

                SmtpClient smtpClient = new SmtpClient();

                mailMessage.From = new MailAddress("mehmetozguraslan09@gmail.com");

                mailMessage.To.Add("ozgurraslann.10@gmail.com"); // kime gidicek email burada belirtiyoruz

                mailMessage.Subject = contact.Subject;

                mailMessage.Body = contact.Message;

                mailMessage.IsBodyHtml = true;

                smtpClient.Host = "smtp.gmail.com";

                smtpClient.Port = 587;

                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

                smtpClient.UseDefaultCredentials = false;

                smtpClient.Credentials = new System.Net.NetworkCredential("mehmetozguraslan09@gmail.com", "Ozgur.190522");

                smtpClient.EnableSsl = true;

                smtpClient.Send(mailMessage);

                return Ok();

            }

            catch (Exception ex)

            {

                return BadRequest(ex.Message);

            }

        }
    }
}

using Notification.Server.Models;
using Notification.Server.Services.Interface;
using System.Net;
using System.Net.Mail;

namespace Notification.Server.Services
{
    public class EmailService : IEmailService
    {
        public async Task<Response<EmailModel>> SendEmailNotificationAsync(EmailModel emailModel)
        {
            try
            {
                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("surachathongmanee@gmail.com", "eonm xrvq jkxi jchs"),
                    EnableSsl = true,
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress("surachathongmanee@gmail.com"),
                    Subject = "Uploaded The File Success",
                    Body = $"<p1>Files '{string.Join(",", emailModel.FileName)}' have been uploaded successfully.</p1></br>{emailModel.ToEmailBody}",
                    IsBodyHtml = true
                };

                if (!string.IsNullOrEmpty(emailModel.ToEmail))
                {
                    var tmpToEmail = emailModel.ToEmail.Split(',');

                    if (tmpToEmail.Length == 0)
                        mailMessage.To.Add(emailModel.ToEmail ?? "");

                    foreach (var recipientEmail in tmpToEmail)
                    {
                        mailMessage.To.Add(recipientEmail.Trim());
                    }
                }
                await smtpClient.SendMailAsync(mailMessage);
                return new Response<EmailModel>()
                {
                    Data = null,
                    Message = "Upload file and send email success",
                    Success = true
                };
            }
            catch (Exception ex)
            {
                return new Response<EmailModel>()
                {
                    Data = null,
                    Message = ex.Message,
                    Success = false
                };
            }
        }
    }
}

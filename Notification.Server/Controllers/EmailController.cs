using Microsoft.AspNetCore.Mvc;
using Notification.Server.Attributes;
using Notification.Server.Models;
using Notification.Server.Services.Interface;

namespace Notification.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiKey]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;
        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }
        [HttpPost]
        public async Task<IActionResult> SendEmailAsync(EmailModel emailModel)
        {
            if (emailModel == null || emailModel.FileName.Count == 0)
                return BadRequest("Not founded the file.");

            var response = await _emailService.SendEmailNotificationAsync(emailModel);
            return response.Success ? Ok(response) : StatusCode(StatusCodes.Status500InternalServerError, response);
        }
    }
}

using GestioneSagre.Email.Controllers.Common;
using GestioneSagre.Email.Shared.Models;
using GestioneSagre.Messaging.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace GestioneSagre.Email.Controllers;

public class EmailController : BaseController
{
    private readonly ILogger<EmailController> logger;
    private readonly IMessageSender messageSender;

    public EmailController(ILogger<EmailController> logger, IMessageSender messageSender)
    {
        this.logger = logger;
        this.messageSender = messageSender;
    }

    [HttpPost("sendemail")]
    public async Task<IActionResult> SendEmailAsync(EmailRequest request)
    {
        try
        {
            await messageSender.PublishAsync(request);
            return Accepted();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
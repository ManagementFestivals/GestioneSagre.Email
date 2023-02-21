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
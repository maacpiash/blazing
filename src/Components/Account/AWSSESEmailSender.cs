using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;
using Blazing.Data;

namespace Blazing.Components.Account;

internal class AwsSesEmailSender(IAmazonSimpleEmailService sesEmailService, ILogger<AwsSesEmailSender> logger)
    : IEmailSender<ApplicationUser>
{
    private SendEmailRequest CreateEmailRequest(string emailAddress, string subject, string htmlBody, string textBody)
    {
        return new SendEmailRequest
        {
            Source = "blazing@maacpiash.com",
            Destination = new Destination { ToAddresses = [emailAddress] },
            Message = new Message
            {
                Body = new Body
                {
                    Html = new Content { Charset = "UTF-8",  Data = htmlBody },
                    Text = new Content { Charset = "UTF-8", Data = textBody }
                },
                Subject = new Content { Charset = "UTF-8", Data = subject }
            },
        };
    }
    
    public Task SendConfirmationLinkAsync(ApplicationUser user, string email, string confirmationLink)
    {
        var emailRequest = CreateEmailRequest(email, "Confirm your email address",
            $"Please confirm your account by <a href='{confirmationLink}'>clicking here</a>.",
            $"Please confirm your account by clicking here: {confirmationLink}");
        try
        {
            return sesEmailService.SendEmailAsync(emailRequest);
        }
        catch (Exception ex)
        {
            logger.LogError($"SendConfirmationLinkAsync failed for {email} with exception {ex.Message}");
            return Task.FromException(ex);
        }
    }
 
    public Task SendPasswordResetLinkAsync(ApplicationUser user, string email, string resetLink)
    {
        var emailRequest = CreateEmailRequest(email, "Reset your password",
            $"Please reset your password by <a href='{resetLink}'>clicking here</a>.",
            $"Please reset your password by clicking here: {resetLink}");
        try
        {
            return sesEmailService.SendEmailAsync(emailRequest);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"SendPasswordResetLinkAsync failed for {email} with exception {ex.Message}");
            return Task.FromException(ex);
        }
    }
 
    public Task SendPasswordResetCodeAsync(ApplicationUser user, string email, string resetCode)
    {
        var emailRequest = CreateEmailRequest(email, "Reset your password",
            $"Please reset your password using the following code: {resetCode}",
            $"Please reset your password using the following code: {resetCode}");

        try
        {
            return sesEmailService.SendEmailAsync(emailRequest);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"SendPasswordResetCodeAsync failed for {email} with exception {ex.Message}");
            return Task.FromException(ex);
        }
    }
}

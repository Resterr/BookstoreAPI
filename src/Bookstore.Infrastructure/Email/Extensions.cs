using Bookstore.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Mail;
using System.Net;
using RazorLight.Extensions;
using RazorLight;

namespace Bookstore.Infrastructure.Email;
internal static class Extensions
{
    public static IServiceCollection AddEmailing(this IServiceCollection services, IConfiguration configuration)
    {
        var emailConfig = configuration.GetSection("EmailConfiguration").Get<EmailOptions>();

        var engine = new RazorLightEngineBuilder()
                .UseFileSystemProject(Directory.GetCurrentDirectory())
                .UseMemoryCachingProvider()
                .Build();

        services.AddRazorLight(() => engine);

        services
        .AddFluentEmail(emailConfig.Username, emailConfig.From)
        .AddSmtpSender(new SmtpClient(emailConfig.SmtpServer)
        {
            UseDefaultCredentials = false,
            Port = emailConfig.Port,
            Credentials = new NetworkCredential(emailConfig.Username, emailConfig.Password),
            EnableSsl = true,
        });

        services.AddScoped<IEmailSender, EmailSender>();

        return services;
    }
}

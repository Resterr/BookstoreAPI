using Bookstore.Application.DTO;
using Bookstore.Application.Services;
using FluentEmail.Core;
using IronPdf;
using Microsoft.AspNetCore.Components.RenderTree;
using RazorLight;
using System.Diagnostics;

namespace Bookstore.Infrastructure.Email;
public class EmailSender : IEmailSender
{
    private readonly IFluentEmail _mailer;
    private readonly IRazorLightEngine _razorLightEngine;

    public EmailSender(IFluentEmail mailer, IRazorLightEngine razorLightEngine)
    {
        _mailer = mailer;
        _razorLightEngine = razorLightEngine;
    }

    public async Task SendInvoiceAsync(InvoiceDto invoiceData)
    { 
        var path = $"{Directory.GetCurrentDirectory()}\\wwwroot\\templates\\InvoiceTemplate.cshtml";
        var html = await _razorLightEngine.CompileRenderAsync(path, invoiceData);
        var renderer = new IronPdf.ChromePdfRenderer();
        using var PDF = await renderer.RenderHtmlAsPdfAsync(html);  
        using var PDFStream = PDF.Stream;

        var email = _mailer
            .To(invoiceData.Email)
            .Subject($"Invoice for order: {invoiceData.Id}")
            .Attach(new FluentEmail.Core.Models.Attachment
            {
                IsInline = true,
                Filename = $"{invoiceData.Id}.pdf",
                Data = PDFStream,
                ContentType = "application/pdf",
                ContentId = invoiceData.Id
            });

        await email.SendAsync();
    }
}

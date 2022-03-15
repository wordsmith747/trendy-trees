using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Net.Mail;
using TrendyTrees.Data;
using TrendyTrees.Models;

namespace TrendyTrees.Controllers
{
    public class AboutUsController : Controller
    {
        private readonly ConiferOptions _options;
        private readonly ITrendyTreesContext _trendyTreesContext;

        public AboutUsController(IOptions<ConiferOptions> options, ITrendyTreesContext trendyTreesContext)
        {
            _options = options.Value;
            _trendyTreesContext = trendyTreesContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(ContactViewModel modelWithNewValues)
        {
            if (!ModelState.IsValid)
            {
                return View(modelWithNewValues);
            }

            var customerInquiry = new CustomerInquiry();

            customerInquiry.Name = modelWithNewValues.Name;
            customerInquiry.EmailAddress = modelWithNewValues.EmailAddress;
            customerInquiry.PhoneNumber = modelWithNewValues.MobilePhone;
            customerInquiry.InquiryText = modelWithNewValues.Message;
            customerInquiry.InquiryDate = DateTime.Now;
            customerInquiry.IpAddress = HttpContext.Connection.RemoteIpAddress.ToString();

            _trendyTreesContext.CustomerInquiries.Add(customerInquiry);

            _trendyTreesContext.SaveChanges();

            var client = new SmtpClient();
            client.Host = "smtp.office365.com";
            client.Port = 587;
            client.EnableSsl = true;

            client.Credentials = new System.Net.NetworkCredential(_options.SendingEmailAddress, _options.PasswordForSendingEmail);

            var mm = new MailMessage();

            mm.From = new MailAddress(_options.EmailSentFrom);
            mm.To.Add(new MailAddress(_options.EmailSentTo));

            mm.Subject = "Enquiry from a client";
            mm.Body = $"<html><body>Client message submitted at {DateTime.Now}<br />Name : <strong>{modelWithNewValues.Name}</strong><br />Phone : <strong>{modelWithNewValues.MobilePhone}</strong><br />Email address : <strong>{modelWithNewValues.EmailAddress}</strong><br />Message<br /><strong>{modelWithNewValues.Message}</strong></body></html>";

            mm.IsBodyHtml = true;
            mm.Priority = MailPriority.Normal;

            client.Send(mm);

            return RedirectToAction("Form_Success", "AboutUs");
        }

        public IActionResult Form_Success()
        {
            return View();
        }
    }
}
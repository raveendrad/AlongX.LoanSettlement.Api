using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;
using System.IO;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Collections.Specialized;
using System.Web.Mvc;
using System.Web;

namespace BillZen.Warehouse.Api
{
    public class MessageSender
    {
        public  bool  SendMailThroughSendGrid(string from_name, string to, string subject, string htmlBody, string attcahmentFileContent = "", string attachmentFileName = "")
        {
            try
            {
                var apiKey = ConfigurationManager.AppSettings["sendgrid_api_key"];
                var client = new SendGridClient(apiKey);
                var fromEmail = new EmailAddress(ConfigurationManager.AppSettings["smtp_from"], from_name);
                var toEmail = new EmailAddress(to);
                var msg = MailHelper.CreateSingleEmail(fromEmail, toEmail, subject, null, htmlBody);
                if (attcahmentFileContent != "")
                {
                    msg.Attachments = new List<SendGrid.Helpers.Mail.Attachment>
                    {
                        new SendGrid.Helpers.Mail.Attachment
                        {
                            Content = Convert.ToBase64String(Encoding.UTF8.GetBytes(attcahmentFileContent)),
                            Filename = attachmentFileName,
                            Type = "application/html",
                            Disposition = "attachment"
                        }
                    };
                }
               
                var response =   client.SendEmailAsync(msg);

                return true;
            }
            catch
            {
                return false;
            }
        }
        public  bool  SendMail(string from_name, string to, string subject, string htmlBody, string attcahmentFileContent="",string attachmentFileName="")
        {
            try
            {
                  SendMailThroughSendGrid(from_name,to,subject,htmlBody, attcahmentFileContent, attachmentFileName);

                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool SendWhatsApp(string to, string messageBody, string attachement = "")
        {
            try
            {
                var accountSid = ConfigurationManager.AppSettings["accountSid"];
                var authToken = ConfigurationManager.AppSettings["authToken"];
                TwilioClient.Init(accountSid, authToken);

                var messageOptions = new CreateMessageOptions(new PhoneNumber("whatsapp:" + to + ""));
                messageOptions.From = new PhoneNumber("whatsapp:" + ConfigurationManager.AppSettings["fromNumber"] + "");
                //var messageOptions = new CreateMessageOptions(
                //                    new PhoneNumber("whatsapp:+918801766286"));
                //messageOptions.From = new PhoneNumber("whatsapp:+14155238886");
                messageOptions.Body = messageBody;
                if (attachement != "")
                {
                    List<Uri> medialUri = new List<Uri>();
                    medialUri.Add(new Uri(attachement));
                    messageOptions.MediaUrl = medialUri;
                }

                var message = MessageResource.Create(messageOptions);

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        //public bool SendOTP()
        //{
        //    int otpValue = new Random().Next(100000, 999999);
        //    var status = "";
        //    try
        //    {
        //        string recipient = ConfigurationManager.AppSettings["RecipientNumber"].ToString();
        //        string APIKey = ConfigurationManager.AppSettings["APIKey"].ToString();

        //        string message = "Your OTP Number is " + otpValue + " ( Sent By : Technotips-Ashish )";
        //        String encodedMessage = HttpUtility.UrlEncode(message);

        //        using (var webClient = new WebClient())
        //        {
        //            byte[] response = webClient.UploadValues("https://api.textlocal.in/send/", new NameValueCollection(){

        //                                 {"apikey" , APIKey},
        //                                 {"numbers" , recipient},
        //                                 {"message" , encodedMessage},
        //                                 {"sender" , "TXTLCL"}});

        //            string result = System.Text.Encoding.UTF8.GetString(response);

        //            var jsonObject = JObject.Parse(result);

        //            status = jsonObject["status"].ToString();

        //            Session["CurrentOTP"] = otpValue;
        //        }

        //        return Json(status, JsonRequestBehavior.AllowGet);


        //    }
        //    catch (Exception e)
        //    {

        //        throw (e);

        //    }

        //}
    }
}
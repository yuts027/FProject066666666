using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Web;

namespace FProjectCamping.Models.Infra
{
	public class EmailHelper
	{

        private string sendermail = "camping202306@gmail.com";
        private string senderPassword = "tzhm kxsl egwv jjnn"; 

        public void SenForgetPasswordEmail(string url, string name, string email)
        {
            var subject = "[重設密碼通知]";
            var body = $@"
<table width=""640"" border=""0"" align=""center"" cellpadding=""0"" cellspacing=""0""
        style=""border:#e1d5ce 1px solid; padding: 20px;"">
        <tr>
            <td style=""font-size:16px; color:#6f6f6f; line-height:1.7; font-weight:bold;"">
                <p style=""color:#462000; font-size:20px; font-weight:bold;margin: 0;"">
                    親愛的會員<span style=""color:#a53700;""> {name}</span>您好!
                </p>
                <p>我們收到你在<span style=""font-size: 18px;"">Camping放鬆村</span>重設密碼的要求</p>
                <br>
                請點下方按鈕連結
                <br />
                <br />
                <a href='{url}' target='_blank'
                    style=""padding: 10px 20px;background-color: #5694dd;border-bottom: 6px solid #215999; border-radius: 5px;font-size: 22px;margin: 40px 0 40px 0; font-weight: bold;color: #ffffff; text-decoration: none;"">我要重設密碼</a>
                <br />
                <br />
                若看不到按鈕請 [<a href='{url}' target='_blank' style=""font-size:18px;color:#215999;"">點此</a>]以進行重設密碼。
                <br />
                <br />
                如果您沒有提供申請，請忽略本信，謝謝。
                <br />
                <br />
        </tr>
    </table>";

            var from = sendermail;
            var to = email;
            var password = senderPassword;
            SendViaGoogle(from, password, to, subject, body);
        }

        public void SendConfirmRegisterEmail(string url, string name, string email)
        {
            var subject = "[新會員確認信]";
            var body = $@"<table width=""640"" border=""0"" align=""center"" cellpadding=""0"" cellspacing=""0""
        style=""border:#e1d5ce 1px solid; padding: 20px;"">
        <tr>
            <td style=""font-size:16px; color:#6f6f6f; line-height:1.7; font-weight:bold;"">
                <p style=""color:#462000; font-size:20px; font-weight:bold;margin: 0;"">
                    親愛的會員<span style=""color:#a53700;""> {name}</span>您好!
                </p>
                <p>我們收到你在<span style=""font-size: 18px;"">Camping放鬆村</span>註冊的要求</p>
                <br>
                請點下方按鈕連結
                <br />
                <br />
                <a href='{url}' target='_blank'
                    style=""padding: 10px 20px;background-color: #5694dd;border-bottom: 6px solid #215999; border-radius: 5px;font-size: 22px;margin: 40px 0 40px 0; font-weight: bold;color: #ffffff; text-decoration: none;"">完成註冊</a>
                <br />
                <br />
                若看不到按鈕請 [<a href='{url}' target='_blank' style=""font-size:18px;color:#215999;"">點此</a>]完成註冊
                <br />
                <br />
                如果您沒有提供申請，請忽略本信，謝謝
                <br />
                <br />
        </tr>
    </table>";
            var from = sendermail;
            var to = email;
            var password = senderPassword;
            SendViaGoogle(from, password, to, subject, body);
        }

        public virtual void SendViaGoogle(string from, string password,string to, string subject, string body)
        {
            try
            {
                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587, // google smpt port
                    Credentials = new NetworkCredential(from, password),
                    EnableSsl = true, // Depending on your SMTP server's requirement
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(from),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true, // Set this to true if the body content is HTML
                };

                mailMessage.To.Add(to);

                smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {
                throw new Exception($"錯誤email: {ex.Message}");
            }
        }
    }
}
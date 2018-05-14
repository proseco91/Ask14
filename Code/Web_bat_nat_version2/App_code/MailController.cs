using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Net.Security;
using System.Net;



public class MailController
{
    #region Feilds

    private string strErrorMessage = "";
    private string strHostServer = "";
    private bool bSendSuccess;
    BizHistorySent hizSent = new BizHistorySent();
    #endregion

    #region Contructor

    public MailController()
    {

    }

    public MailController(string strMailServerName)
    {
        strHostServer = strMailServerName;
    }

    #endregion

    #region Methods

    /// <summary>
    /// Send Mail
    /// </summary>
    /// <param name="strTo">Nguoi Nhan</param>
    /// <param name="strSubjects">Tieu de mail</param>
    /// <param name="strBody">Noi Dung Mail</param>
    /// <returns></returns>
    public bool SendMail(string strTo, string strSubjects, string strBody)
    {
        bSendSuccess = true;
        try
        {
            MailAddress from = new MailAddress("ducnghia@linktam.vn", "ask14.vn", System.Text.Encoding.UTF8);
            MailAddress to = new MailAddress(strTo);
            MailMessage objMailMessage = new MailMessage(from, to);


            objMailMessage.Subject = strSubjects;
            objMailMessage.BodyEncoding = System.Text.Encoding.UTF8;
            objMailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
            objMailMessage.IsBodyHtml = true;
            objMailMessage.Priority = MailPriority.High;
            objMailMessage.Body = strBody;

            NetworkCredential mailAuthentication = new NetworkCredential("ducnghia@linktam.vn", "ducnghia@linktam.vn");
            //SMTP mail
            SmtpClient objSmtpClient = new SmtpClient("smtp.gmail.com", 25);
            objSmtpClient.UseDefaultCredentials = true;
            objSmtpClient.Credentials = mailAuthentication;

            objSmtpClient.EnableSsl = true;
            objSmtpClient.Send(objMailMessage);
        }
        catch (Exception ex)
        {
            bSendSuccess = false;
            strErrorMessage = ex.Message;
        }
        return bSendSuccess;
    }


    /// <summary>
    /// Send Mail qua BCC
    /// </summary>
    /// <param name="strBB"></param>
    /// <param name="strSubjects"></param>
    /// <param name="strBody"></param>
    /// <returns></returns>
    public bool SendMails(string strBCC, string strSubjects, string strBody)
    {
        bSendSuccess = true;
        try
        {

            MailMessage objMailMessage = new MailMessage();
            MailAddress from = new MailAddress("noreply1@hentocdo.vn");

            objMailMessage.Bcc.Add(strBCC);

            objMailMessage.Subject = strSubjects;
            objMailMessage.IsBodyHtml = true;
            objMailMessage.Priority = MailPriority.High;
            objMailMessage.Body = strBody;

            //
            NetworkCredential mailAuthentication = new NetworkCredential("noreply1@hentocdo.vn", "hentocdo@123");
            //
            //SMTP mail
            SmtpClient objSmtpClient = new SmtpClient("smtp.gmail.com", 25);
            objSmtpClient.UseDefaultCredentials = true;
            objSmtpClient.Credentials = mailAuthentication;

            objSmtpClient.EnableSsl = true;
            objSmtpClient.Send(objMailMessage);
        }
        catch (Exception ex)
        {
            bSendSuccess = false;
            strErrorMessage = ex.Message;
        }
        return bSendSuccess;
    }

    /// <summary>
    /// Send Mail for attachment
    /// </summary>
    /// <param name="strTo">Nguoi Nhan</param>
    /// <param name="strCC">CC</param>
    /// <param name="strBB">BB</param>
    /// <param name="strSubjects">Tieu de</param>
    /// <param name="strBody">Noi dung</param>
    /// <param name="strAttachFile">File Attachment</param>
    /// <returns></returns>
    public bool SendMail(string strTo, string strCC, string strBB, string strSubjects, string strBody, string strAttachFile)
    {
        bSendSuccess = true;
        try
        {
            MailMessage objMailMessage = new MailMessage();
            objMailMessage.To.Add(strTo);
            objMailMessage.Subject = strSubjects;

            //TH su dung CC
            if (strCC != "")
            {
                objMailMessage.CC.Add(strCC);
            }
            //TH su dung BB
            if (strBB != "")
            {
                objMailMessage.Bcc.Add(strBB);
            }
            objMailMessage.Body = strBody;
            //Kiem tra trang thai file dinh kem
            if (strAttachFile != "")
            {
                Attachment objAttachment = new Attachment(strAttachFile);
                objMailMessage.Attachments.Add(objAttachment);
            }

            objMailMessage.IsBodyHtml = true;
            objMailMessage.Priority = MailPriority.High;
            SmtpClient objSmtpClient = new SmtpClient(strHostServer);
            objSmtpClient.Send(objMailMessage);
        }
        catch (Exception ex)
        {
            bSendSuccess = false;
            strErrorMessage = ex.Message;
        }
        return bSendSuccess;
    }


    /// <summary>
    /// Send Mail voi nhieu file Attach
    /// </summary> 
    /// <param name="strTo"></param>
    /// <param name="strCC"></param>
    /// <param name="strBB"></param>
    /// <param name="strSubjects"></param>
    /// <param name="strBody"></param>
    /// <param name="strAttachFileName"></param>
    /// <returns></returns>
    public bool SendMail(string strTo, string strCC, string strBB, string strSubjects, string strBody, string[] strAttachFileName)
    {
        bSendSuccess = true;
        try
        {
            MailMessage objMailMessage = new MailMessage();
            objMailMessage.To.Add(strTo);
            objMailMessage.Subject = strSubjects;
            //TH su dung CC
            if (strCC != "")
            {
                objMailMessage.CC.Add(strCC);
            }

            //TH su dung BB
            if (strBB != "")
            {
                objMailMessage.Bcc.Add(strBB);
            }
            objMailMessage.Body = strBody;
            if (strAttachFileName != null)
            {
                foreach (string strFileName in strAttachFileName)
                {
                    AttachFile(objMailMessage, strFileName);
                }
            }
            objMailMessage.IsBodyHtml = true;
            objMailMessage.Priority = MailPriority.High;
            SmtpClient objSmtpClients = new SmtpClient(strHostServer);
            objSmtpClients.EnableSsl = true;
            objSmtpClients.Send(objMailMessage);
        }
        catch (Exception ex)
        {
            bSendSuccess = false;
            strErrorMessage = ex.Message;
        }
        return bSendSuccess;
    }


    /// <summary>
    /// Duyet file Attachment
    /// </summary>
    /// <param name="objMail"></param>
    /// <param name="strAttachFile"></param>
    private void AttachFile(MailMessage objMail, string strAttachFile)
    {
        if (strAttachFile != "")
        {
            Attachment objAttachMent = new Attachment(strAttachFile);
            objMail.Attachments.Add(objAttachMent);
        }
    }

    /// <summary>
    /// Dang email nay la moi nhat gom co 6 paramter
    /// </summary>
    /// <param name="mailfrom"></param>
    /// <param name="mailto"></param>
    /// <param name="email_id"></param>
    /// <param name="subject"></param>
    /// <param name="body"></param>
    /// <param name="type">Xac thuc:1, Nhac lam bai 2, Dang ky su kien 3, nhac thanh toan su kien 4 </param>
    /// <returns></returns>

    public bool SendMailBCC(string mailfrom, string mailto, string[] strBCC, int email_id, string subject, string body, int type)
    {
        bSendSuccess = true;
        try
        {
            MailAddress from = new MailAddress(mailfrom, "Hẹn tốc độ", System.Text.Encoding.UTF8);
            MailAddress to = new MailAddress(mailto);
            MailMessage objMailMessage = new MailMessage(from, to);

            objMailMessage.To.Add(mailto);
            foreach (string str in strBCC)
            {
                objMailMessage.Bcc.Add(str);
            }

            objMailMessage.Subject = subject;
            objMailMessage.BodyEncoding = System.Text.Encoding.UTF8;
            objMailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
            objMailMessage.IsBodyHtml = true;
            objMailMessage.Priority = MailPriority.High;
            objMailMessage.Body = body;

            NetworkCredential mailAuthentication = new NetworkCredential(mailfrom, "hentocdo@123");
            //SMTP mail
            SmtpClient objSmtpClient = new SmtpClient("smtp.gmail.com", 25);
            objSmtpClient.UseDefaultCredentials = true;
            objSmtpClient.Credentials = mailAuthentication;

            objSmtpClient.EnableSsl = true;
            objSmtpClient.Send(objMailMessage);
            hizSent.Insert(mailfrom, mailto, email_id, DateTime.Now, body, type);
        }
        catch (Exception ex)
        {
            bSendSuccess = false;
            strErrorMessage = ex.Message;
        }
        return bSendSuccess;
    }


    public bool SendMailBCC2(string mailfrom, string mailto, string[] strBCC, string subject, string body)
    {
        bSendSuccess = true;
        try
        {
            MailAddress from = new MailAddress(mailfrom, "Hẹn tốc độ", System.Text.Encoding.UTF8);
            MailAddress to = new MailAddress(mailto);
            MailMessage objMailMessage = new MailMessage(from, to);

            objMailMessage.To.Add(mailto);
            foreach (string str in strBCC)
            {
                objMailMessage.Bcc.Add(str);
            }

            objMailMessage.Subject = subject;
            objMailMessage.BodyEncoding = System.Text.Encoding.UTF8;
            objMailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
            objMailMessage.IsBodyHtml = true;
            objMailMessage.Priority = MailPriority.High;
            objMailMessage.Body = body;

            NetworkCredential mailAuthentication = new NetworkCredential(mailfrom, "hentocdo@123");
            //SMTP mail
            SmtpClient objSmtpClient = new SmtpClient("smtp.gmail.com", 25);
            objSmtpClient.UseDefaultCredentials = true;
            objSmtpClient.Credentials = mailAuthentication;

            objSmtpClient.EnableSsl = true;
            objSmtpClient.Send(objMailMessage);
        }
        catch (Exception ex)
        {
            bSendSuccess = false;
            strErrorMessage = ex.Message;
        }
        return bSendSuccess;
    }

    #endregion
}


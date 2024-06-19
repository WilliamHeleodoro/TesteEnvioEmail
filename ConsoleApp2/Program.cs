using System;
using System.Net;
using System.Net.Mail;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("************ TESTE DE E-MAIL *************");

        Console.Write("\nDigite o servidor SMTP: ");
        string smtpServer = Console.ReadLine().Trim();

        Console.Write("Digite a porta do servidor SMTP: ");
        string port = Console.ReadLine().Trim();

        Console.Write("\nDigite o e-mail remetente: ");
        string senderEmail = Console.ReadLine().Trim();

        Console.Write("\nDigite a senha do remetente: ");
        string password = Console.ReadLine().Trim();

        Console.Write("\nDigite o e-mail destinatário: ");
        string recipientEmail = Console.ReadLine().Trim();

        Console.Write("\nDigite o assunto: ");
        string subject = Console.ReadLine();

        Console.Write("\nDigite o texto(body): ");
        string body = Console.ReadLine();

        try
        {
            // Configurar o cliente SMTP
            SmtpClient client = new SmtpClient(smtpServer, Convert.ToInt32(port))
            {
                Credentials = new NetworkCredential(senderEmail, password),
                EnableSsl = true, 
            };

            // Criar a mensagem de e-mail
            MailMessage mailMessage = new MailMessage
            {
                From = new MailAddress(senderEmail),
                Subject = subject,
                Body = body
            };
            mailMessage.To.Add(recipientEmail);

            // Enviar o e-mail
            client.Send(mailMessage);
            Console.WriteLine("E-mail enviado com sucesso!");
        }
        catch (SmtpException smtpEx)
        {
            Console.WriteLine($"Erro ao enviar e-mail: {smtpEx.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }

        // Manter a janela do console aberta
        Console.WriteLine("Pressione Enter para sair...");
        Console.ReadLine();
    }
}

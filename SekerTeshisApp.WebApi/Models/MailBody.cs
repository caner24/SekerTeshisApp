namespace SekerTeshisApp.WebApi.Models
{
    public static class MailBody
    {
        public static string DefaultMailBody(string username, string confirmationType, string dueDate, string url)
        {
            string html = @"
<!DOCTYPE html>
<html lang='en'>
<head>
  <meta charset='UTF-8'>
  <meta name='viewport' content='width=device-width, initial-scale=1.0'>
  <title>Şifre Sıfırlama</title>
  <style>
    body {{
      font-family: Arial, sans-serif;
      background-color: #f1f1f1;
      padding: 20px;
    }}
    
    .container {{
      max-width: 600px;
      margin: 0 auto;
      background-color: #fff;
      padding: 40px;
      border-radius: 4px;
      box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
    }}
    
    h1 {{
      text-align: center;
      margin-bottom: 30px;
    }}
    
    p {{
      margin-bottom: 20px;
    }}
    
    .btn {{
      display: inline-block;
      background-color: #4CAF50;
      color: #fff;
      padding: 10px 20px;
      text-decoration: none;
      border-radius: 4px;
    }}
  </style>
</head>
<body>
  <div class='container'>
    <h1>{0}</h1>
    <p>Merhaba, {1}</p>
    <p>Şifrenizi sıfırlamak için aşağıdaki bağlantıyı kullanabilirsiniz:</p>
    <p><a class='btn' href='{2}'>Şifre Sıfırlama</a></p>
    <p>Eğer şifre sıfırlama talebi yapmadıysanız, bu e-postayı görmezden gelebilirsiniz.</p>
    <p>İyi günler!</p>
  </div>
</body>
</html>
";

            string formattedHtml = string.Format(html, confirmationType, username, url);
            return formattedHtml;
        }

        public static string MailBodyConfirmation(string username, string confirmationType, string dueDate, string url)
        {
            string html = @"
<!DOCTYPE html>
<html lang='en'>
<head>
  <meta charset='UTF-8'>
  <meta name='viewport' content='width=device-width, initial-scale=1.0'>
  <title>Şifre Sıfırlama</title>
  <style>
    body {{
      font-family: Arial, sans-serif;
      background-color: #f1f1f1;
      padding: 20px;
    }}
    
    .container {{
      max-width: 600px;
      margin: 0 auto;
      background-color: #fff;
      padding: 40px;
      border-radius: 4px;
      box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
    }}
    
    h1 {{
      text-align: center;
      margin-bottom: 30px;
    }}
    
    p {{
      margin-bottom: 20px;
    }}
    
    .btn {{
      display: inline-block;
      background-color: #4CAF50;
      color: #fff;
      padding: 10px 20px;
      text-decoration: none;
      border-radius: 4px;
    }}
  </style>
</head>
<body>
  <div class='container'>
    <h1>{0}</h1>
    <p>Merhaba, {1}</p>
    <p>Eposta adresinizi onaylamak için aşağıdaki bağlantıyı kullanabilirsiniz:</p>
    <p><a class='btn' href='{2}'>Eposta Onaylama</a></p>
    <p>Lütfen eposta adresinizi onaylayın.</p>
    <p>İyi günler!</p>
  </div>
</body>
</html>
";

            string formattedHtml = string.Format(html, confirmationType, username, url);
            return formattedHtml;
        }

    }
}
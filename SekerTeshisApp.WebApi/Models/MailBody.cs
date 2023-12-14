using System.Net;

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
  <title>Mail Onaylama</title>
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
    <p>E-Mail adresinizi onaylamak için için aşağıdaki bağlantıyı kullanabilirsiniz:</p>
    <p><a class='btn' href='{2}'>Mail Onaylama</a></p>
    <p>Eğer sistem kayıt olma talebi yapmadıysanız, bu e-postayı görmezden gelebilirsiniz.</p>
    <p>İyi günler!</p>
  </div>
</body>
</html>
";

            string formattedHtml = string.Format(html, confirmationType, username, url);
            return formattedHtml;
        }


        public static string FoodListMailBody(string morning, string afternoon, string evening)
        {

            string formattedHtml = $@"
<!DOCTYPE html>
<html lang='tr'>
<head>
  <meta charset='UTF-8'>
  <meta name='viewport' content='width=device-width, initial-scale=1.0'>
  <title>Mail Onaylama</title>
   <style>
      body {{
        font-family: Arial, sans-serif;
        max-width: 600px;
        margin: 20px auto;
      }}

      h2 {{
        color: #333;
      }}

      ul {{
        list-style-type: none;
        padding: 0;
      }}

      li {{
        margin-bottom: 10px;
      }}
    </style>
  </head>
  <body>
    <h2>Sabah</h2>
    <ul>
      <li>{morning}</li>
    </ul>

    <h2>Öğle</h2>
    <ul>
      <li>{afternoon}</li>
    </ul>

    <h2>Akşam</h2>
    <ul>
      <li>{evening}</li>
    </ul>
  </body>
</html>
";

            return formattedHtml;
        }

        public static string ExercisesListBody(string afternoon, string evening)
        {

            string formattedHtml = $@"
<!DOCTYPE html>
<html lang='tr'>
<head>
  <meta charset='UTF-8'>
  <meta name='viewport' content='width=device-width, initial-scale=1.0'>
  <title>Mail Onaylama</title>
   <style>
      body {{
        font-family: Arial, sans-serif;
        max-width: 600px;
        margin: 20px auto;
      }}

      h2 {{
        color: #333;
      }}

      ul {{
        list-style-type: none;
        padding: 0;
      }}

      li {{
        margin-bottom: 10px;
      }}
    </style>
  </head>
  <body>
    <h2>Öğle</h2>
    <ul>
      <li>{afternoon}</li>
    </ul>

    <h2>Akşam</h2>
    <ul>
      <li>{evening}</li>
    </ul>

  </body>
</html>
";

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
    background-repeat: no-repeat;
        background-size: 100% 100%;
        background-image: url('https://media.istockphoto.com/id/1154923934/vector/red-blood-drop-vector-icon-isolated-on-white-background.jpg?s=612x612&w=0&k=20&c=2huXJsEtBnVZGvjmNCaZTHDoiWrt1pkOaFzYlKsWJFg=');
    }}
    
    h1 {{
      text-align: center;
      margin-bottom: 30px;
    }}
    
    p {{
color:'black';
      margin-bottom: 20px;
font-weight: bolder;
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
    <p>Şifrenizi sifirlamak  için kodunuz:</p>
    <p>{2}</p>
    <p>Bu kod ile şifrenizi sıfırlarken kullanabilirsiniz.</p>
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
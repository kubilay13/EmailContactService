<img width="1919" height="822" alt="Screenshot_3" src="https://github.com/user-attachments/assets/39c15af2-474a-48fe-a044-948bf3d7f4bf" />

> ⚠️ **Warning:** Please read the README.md file carefully before using this project. Important information about the license, installation, and SMTP settings is provided here. **Using the project without reading the README is not recommended.**


# EmailContactService

**EmailContactService** is a contact form application built with ASP.NET Core MVC. Users can fill out their name, email, subject, and message, and send it to a specified email address.  
---

## Features

- Simple and modern contact form (designed with Bootstrap 4)  
- Email sending via SMTP (Gmail / Outlook support)  
- Error messages and success messages  
- Responsive design   

---

## Requirements

- [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0) or later  
- Visual Studio 2022 or VS Code  
- Gmail or Outlook account (for SMTP usage)  
- Internet connection  




**Important Note for Gmail and Outlook Users!**
```bash 
To send emails, you must use an App Password via SMTP.

Why?

Gmail and Outlook no longer allow direct SMTP access using your account password.

If 2-Step Verification (2FA) is not enabled, you cannot create an App Password.

Therefore, both Gmail and Outlook users must enable 2FA and then create an App Password.

Steps:
```
**Gmail:**
```bash 
Log in to your Google account.

Go to Security → 2-Step Verification and enable it.

From App Passwords, generate a new password.

Use the generated password in the SMTP Credentials section in HomeController.cs
```

**Outlook:**
```bash 
Log in to your Microsoft account.

Go to Security → Advanced Security → App Passwords.

Generate a new App Password and use it in the SMTP Credentials section.
```
⚠️ Important: Do not hardcode the App Password in your code. It is recommended to use environment variables or appsettings.json.


---

## Installation

1. **Clone the project:**  
```bash 
Install-Package TronNet
```


2. **Restore NuGet packages:**
```bash 
dotnet restore
```


3. **Configure SMTP settings:** 
HomeController.cs içindeki kod şu şekilde çalışır:
```bash 
var mail = new MailMessage();
mail.To.Add("abcd@gmail.com"); // Recipient email
mail.From = new MailAddress(model.Email); // User's email
mail.Subject = model.Subject;
mail.Body = $"Gönderen: {model.Name} <{model.Email}>\nMesaj: {model.Message}";

using (var smtp = new SmtpClient("smtp.gmail.com", 587)) // Gmail SMTP server
{
    smtp.Credentials = new NetworkCredential("abcd@gmail.com", "AppPasswordKey"); 
    // Sender email and App Password
    // To create an App Password, 2-Step Verification (2FA) must be enabled. Valid for Gmail and Outlook..
    smtp.EnableSsl = true;
    smtp.Send(mail);
}
```


4.**Using Outlook instead of Gmail:**
```bash
using (var smtp = new SmtpClient("smtp.office365.com", 587)) // Use this for Outlook SMTP
```


**Explanations:**
```bash
mail.To.Add("abcd@gmail.com") → Recipient email address

mail.From = new MailAddress(model.Email) → Email of the user filling out the form

smtp.Credentials → Sender email and App Password

⚠️ Important: Never leave the password public in the code. Use environment variables or appsettings.json for GitHub.

smtp.EnableSsl = true → Ensures secure sending

Use smtp.office365.com instead of Gmail for Outlook
```
**LİCENCE**
```bash
BSD 3-Clause License

Copyright (c) 2025, Kubilay13
All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions are met:

1. Redistributions of source code must retain the above copyright notice,
   this list of conditions and the following disclaimer.

2. Redistributions in binary form must reproduce the above copyright notice,
   this list of conditions and the following disclaimer in the documentation
   and/or other materials provided with the distribution.

3. Neither the name of the copyright holder nor the names of its contributors
   may be used to endorse or promote products derived from this software
   without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO,
THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE
ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE
LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED
AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
```







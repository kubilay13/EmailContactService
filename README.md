<img width="1919" height="822" alt="Screenshot_3" src="https://github.com/user-attachments/assets/39c15af2-474a-48fe-a044-948bf3d7f4bf" />

# EmailContactService

**EmailContactService**, ASP.NET Core MVC ile hazırlanmış bir iletişim formu uygulamasıdır. Kullanıcılar form üzerinden ad, e-posta, konu ve mesaj bilgilerini girerek belirlenen e-posta adresine mesaj gönderebilir.  

---

## Özellikler

- Basit ve modern iletişim formu (Bootstrap 4 ile tasarlanmış)  
- SMTP üzerinden e-posta gönderimi (Gmail / Outlook desteği)  
- Hata mesajları ve başarılı gönderim mesajları  
- Responsive tasarım  

---

## Gereksinimler

- [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0) veya üzeri  
- Visual Studio 2022 veya VS Code  
- Gmail veya Outlook hesabı (SMTP kullanımı için)  
- İnternet bağlantısı  




**Gmail ve Outlook Kullanımı için Önemli Not!!**
```bash 
E-posta gönderimi için SMTP üzerinden uygulama şifresi (App Password) kullanmanız gerekir.

Neden gerekli?

Gmail ve Outlook artık doğrudan hesap şifresiyle SMTP erişimine izin vermez.

2 aşamalı doğrulama (2FA) açık değilse App Password oluşturamazsınız.

Bu nedenle hem Gmail hem de Outlook kullanıcıları 2FA’yı aktif hale getirmeli ve ardından App Password oluşturmalıdır.

Adımlar
```
**Gmail:**
```bash 
Google hesabınıza giriş yapın.

Güvenlik → 2 Adımlı Doğrulama kısmını etkinleştirin.

Uygulama şifreleri menüsünden yeni bir şifre oluşturun.

Oluşturduğunuz şifreyi HomeController.cs içindeki SMTP Credentials kısmında kullanın.
```
**Outlook:**
```bash 
Microsoft hesabınıza giriş yapın.

Güvenlik → İleri düzey güvenlik → App Passwords kısmını bulun.

Yeni bir uygulama şifresi oluşturun ve SMTP Credentials kısmında kullanın.

⚠️ Önemli: App Password’ü kodda direkt yazmak güvenli değildir. Environment variable veya appsettings.json kullanmanız önerilir.
```

---

## Kurulum

1. **Projeyi klonlayın:**  
```bash 
Install-Package TronNet
```


2. **NuGet paketlerini yükleyin:**
```bash 
dotnet restore
```


3. **SMTP ayarlarını yapılandırın:** 
HomeController.cs içindeki kod şu şekilde çalışır:
```bash 
var mail = new MailMessage();
mail.To.Add("abcd@gmail.com"); // Mesajın gideceği e-posta
mail.From = new MailAddress(model.Email); // Kullanıcının e-posta adresi
mail.Subject = model.Subject;
mail.Body = $"Gönderen: {model.Name} <{model.Email}>\nMesaj: {model.Message}";

using (var smtp = new SmtpClient("smtp.gmail.com", 587)) // Gmail SMTP sunucusu
{
    smtp.Credentials = new NetworkCredential("abcd@gmail.com", "AppPasswordKey"); 
    // Gönderici e-posta adresi, **uygulama şifresi (App Password)** kullanılıyor.
    // App Password oluşturmak için mail adresinizin 2 aşamalı doğrulamasını (2FA) açmanız gerekiyor. Gmail ve Outlook için geçerli.
    smtp.EnableSsl = true;
    smtp.Send(mail);
}
```


4.**Gmail yerine Outlook kullanmak için**
```bash
using (var smtp = new SmtpClient("smtp.office365.com", 587)) // // Gmail SMTP sunucusu ve portu eğer isterseniz OUTLOOK için "smtp.office365.com" ve port 587 kullanılabilir.
```


**Açıklamalar:**
```bash
mail.To.Add("abcd@gmail.com") → Mesajın gönderileceği e-posta adresi.

mail.From = new MailAddress(model.Email) → Formu dolduran kullanıcının e-posta adresi.

smtp.Credentials → Gönderici e-posta adresi ve uygulama şifresi (App Password).

⚠️ Önemli: Bu şifreyi kodda asla public olarak bırakma! GitHub’da paylaşmak için environment variable veya appsettings.json kullan.

smtp.EnableSsl = true → Güvenli gönderim sağlar.

Gmail yerine Outlook kullanmak için:
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







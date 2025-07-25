
# Vavasoft Clean Architecture Template

ASP.NET projelerinizde temiz bir mimari yapýsý uygulamak için hazýrladýðýmýz bu NuGet paketi, projelerinizi daha düzenli, sürdürülebilir ve test edilebilir hale getirmenizi saðlar.

## Özellikler

- **Katmanlý Mimari Desteði:** Domain, Application, Infrastructure ve Presentation katmanlarýný organize eder.
- **Baðýmlýlýk Yönetimi:** Dependency Injection (DI) desteðiyle güçlü ve esnek baðýmlýlýk yönetimi.
- **Test Edilebilirlik:** Her katman birbirinden baðýmsýz olarak test edilebilir þekilde tasarlanmýþtýr.
- **Geniþletilebilirlik:** Ýhtiyaçlarýnýza göre kolayca geniþletilebilir bir yapý.

## Kurulum

Bu paketi projelerinize NuGet üzerinden kolayca ekleyebilirsiniz.
Bu doküman, Vavasoft tarafýndan saðlanan Clean Architecture NuGet paketinin nasýl kullanýlacaðýný açýklamaktadýr. Bu þablon, ASP.NET projelerinde temiz bir mimari oluþturmayý kolaylaþtýrýr.

## Kurulum

### 1. NuGet Paketi Kurulumu

Aþaðýdaki komutla NuGet paketi yüklenir:

```bash
dotnet new install Vavasoft.Templates.CleanArchitecture
```

### 2. Proje Oluþturma

Projenin oluþturulacaðý klasöre gidin ve aþaðýdaki komutu çalýþtýrýn:

```bash
dotnet new vavasoft-clean -o "{projectname}" --appname "{appname}" --withsample "true"
```

- `-o "{projectname}"` ve `--appname "{appname}"` parametreleri zorunludur.
- `--withsample "true"` parametresi verilirse, çalýþýr durumda bir örnek proje oluþturulur.

#### Örnek Kullaným

- Proje Klasörü: `c:\test`
- `-o` Parametresi: `Trsale.Logo`
- `--appname` Parametresi: `SalesApplication`

```bash
dotnet new vavasoft-clean -o "Trsale.Logo" --appname "SalesApplication" --withsample "true"
```

## Örnek Proje ile Çalýþma

Eðer örnek proje oluþturulduysa, öncelikle `Api` projesindeki `appsettings.development.json` dosyasýndaki `ConnectionString` deðerlerini düzenleyin.

### Veritabaný Migration Ýþlemleri

#### Identity Veritabaný

Migration eklemek için:

```bash
dotnet ef migrations add initialmigration -c {appname}IdentityDbContext -p {projectname}.Identity.csproj -s {projectname}.Api.csproj
```

Örnek:

```bash
dotnet ef migrations add initialmigration -c SalesApplicationIdentityDbContext -p c:\test\Trsale.Logo\src\Trsale.Logo.Identity\Trsale.Logo.Identity.csproj -s c:\test\Trsale.Logo\src\Trsale.Logo.Api\Trsale.Logo.Api.csproj
```

Veritabanýný güncellemek için:

```bash
dotnet ef database update initialmigration -c {appname}IdentityDbContext -p {projectname}.Identity.csproj -s {projectname}.Api.csproj
```

Örnek:

```bash
dotnet ef database update initialmigration -c SalesApplicationIdentityDbContext -p c:\test\Trsale.Logo\src\Trsale.Logo.Identity\Trsale.Logo.Identity.csproj -s c:\test\Trsale.Logo\src\Trsale.Logo.Api\Trsale.Logo.Api.csproj
```

#### Proje Veritabaný

Migration eklemek için:

```bash
dotnet ef migrations add initialmigration -c {appname}DbContext -p {projectname}.Persistence.csproj -s {projectname}.Api.csproj
```

Örnek:

```bash
dotnet ef migrations add initialmigration -c SalesApplicationDbContext -p c:\test\Trsale.Logo\src\Trsale.Logo.Persistence\Trsale.Logo.Persistence.csproj -s c:\test\Trsale.Logo\src\Trsale.Logo.Api\Trsale.Logo.Api.csproj
```

Veritabanýný güncellemek için:

```bash
dotnet ef database update initialmigration -c {appname}DbContext -p {projectname}.Persistence.csproj -s {projectname}.Api.csproj
```

Örnek:

```bash
dotnet ef database update initialmigration -c SalesApplicationDbContext -p c:\test\Trsale.Logo\src\Trsale.Logo.Persistence\Trsale.Logo.Persistence.csproj -s c:\test\Trsale.Logo\src\Trsale.Logo.Api\Trsale.Logo.Api.csproj
```



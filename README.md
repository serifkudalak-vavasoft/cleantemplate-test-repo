
# Vavasoft Clean Architecture Template

ASP.NET projelerinizde temiz bir mimari yap�s� uygulamak i�in haz�rlad���m�z bu NuGet paketi, projelerinizi daha d�zenli, s�rd�r�lebilir ve test edilebilir hale getirmenizi sa�lar.

## �zellikler

- **Katmanl� Mimari Deste�i:** Domain, Application, Infrastructure ve Presentation katmanlar�n� organize eder.
- **Ba��ml�l�k Y�netimi:** Dependency Injection (DI) deste�iyle g��l� ve esnek ba��ml�l�k y�netimi.
- **Test Edilebilirlik:** Her katman birbirinden ba��ms�z olarak test edilebilir �ekilde tasarlanm��t�r.
- **Geni�letilebilirlik:** �htiya�lar�n�za g�re kolayca geni�letilebilir bir yap�.

## Kurulum

Bu paketi projelerinize NuGet �zerinden kolayca ekleyebilirsiniz.
Bu dok�man, Vavasoft taraf�ndan sa�lanan Clean Architecture NuGet paketinin nas�l kullan�laca��n� a��klamaktad�r. Bu �ablon, ASP.NET projelerinde temiz bir mimari olu�turmay� kolayla�t�r�r.

## Kurulum

### 1. NuGet Paketi Kurulumu

A�a��daki komutla NuGet paketi y�klenir:

```bash
dotnet new install Vavasoft.Templates.CleanArchitecture
```

### 2. Proje Olu�turma

Projenin olu�turulaca�� klas�re gidin ve a�a��daki komutu �al��t�r�n:

```bash
dotnet new vavasoft-clean -o "{projectname}" --appname "{appname}" --withsample "true"
```

- `-o "{projectname}"` ve `--appname "{appname}"` parametreleri zorunludur.
- `--withsample "true"` parametresi verilirse, �al���r durumda bir �rnek proje olu�turulur.

#### �rnek Kullan�m

- Proje Klas�r�: `c:\test`
- `-o` Parametresi: `Trsale.Logo`
- `--appname` Parametresi: `SalesApplication`

```bash
dotnet new vavasoft-clean -o "Trsale.Logo" --appname "SalesApplication" --withsample "true"
```

## �rnek Proje ile �al��ma

E�er �rnek proje olu�turulduysa, �ncelikle `Api` projesindeki `appsettings.development.json` dosyas�ndaki `ConnectionString` de�erlerini d�zenleyin.

### Veritaban� Migration ��lemleri

#### Identity Veritaban�

Migration eklemek i�in:

```bash
dotnet ef migrations add initialmigration -c {appname}IdentityDbContext -p {projectname}.Identity.csproj -s {projectname}.Api.csproj
```

�rnek:

```bash
dotnet ef migrations add initialmigration -c SalesApplicationIdentityDbContext -p c:\test\Trsale.Logo\src\Trsale.Logo.Identity\Trsale.Logo.Identity.csproj -s c:\test\Trsale.Logo\src\Trsale.Logo.Api\Trsale.Logo.Api.csproj
```

Veritaban�n� g�ncellemek i�in:

```bash
dotnet ef database update initialmigration -c {appname}IdentityDbContext -p {projectname}.Identity.csproj -s {projectname}.Api.csproj
```

�rnek:

```bash
dotnet ef database update initialmigration -c SalesApplicationIdentityDbContext -p c:\test\Trsale.Logo\src\Trsale.Logo.Identity\Trsale.Logo.Identity.csproj -s c:\test\Trsale.Logo\src\Trsale.Logo.Api\Trsale.Logo.Api.csproj
```

#### Proje Veritaban�

Migration eklemek i�in:

```bash
dotnet ef migrations add initialmigration -c {appname}DbContext -p {projectname}.Persistence.csproj -s {projectname}.Api.csproj
```

�rnek:

```bash
dotnet ef migrations add initialmigration -c SalesApplicationDbContext -p c:\test\Trsale.Logo\src\Trsale.Logo.Persistence\Trsale.Logo.Persistence.csproj -s c:\test\Trsale.Logo\src\Trsale.Logo.Api\Trsale.Logo.Api.csproj
```

Veritaban�n� g�ncellemek i�in:

```bash
dotnet ef database update initialmigration -c {appname}DbContext -p {projectname}.Persistence.csproj -s {projectname}.Api.csproj
```

�rnek:

```bash
dotnet ef database update initialmigration -c SalesApplicationDbContext -p c:\test\Trsale.Logo\src\Trsale.Logo.Persistence\Trsale.Logo.Persistence.csproj -s c:\test\Trsale.Logo\src\Trsale.Logo.Api\Trsale.Logo.Api.csproj
```



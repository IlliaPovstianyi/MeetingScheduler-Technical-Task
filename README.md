# MeetingScheduler-Technical-Task
Technický úkol pro společnost SCIO – webová aplikace pro sjednávání schůzek.

Aplikace umožňuje uživatelům generovat unikátní odkazy, přes které si mohou ostatní sjednat schůzku. Po přihlášení přes Google účet dostanete odkaz, který sdílíte, a kdokoliv si pak může vybrat volný termín ve vašem kalendáři.

...


# Nastavení OAuth
Získejte přihlašovací údaje z Google Cloud Console

Spusťte tyto příkazy s VAŠIMI přihlašovacími údaji:
dotnet user-secrets set "Authentication:Google:ClientId" "YOUR_ID"
dotnet user-secrets set "Authentication:Google:ClientSecret" "YOUR_SECRET"

# Nastavení SQL Server

Zkopírujte appsettings.Development.json.example do appsettings.Development.json
Nastavte heslo k SQL Serveru
Spusťte:
dotnet ef database update
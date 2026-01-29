# BankRUs

Färdigställ US-01: Öppna konto

Beskrivning
I denna övning övar du på att lägga till en entitet med tillhörande repository till projektet. Du övar även på att sätta upp och använda en lokal SMTP-server för att skicka mail. Målet är att färdigställa US-01: Öppna konto.

Lös uppgiften på egen hand eller tillsammans i grupp.

Instruktioner
Följande kvarstår att implementera för OpenAccount:
- Skapa bankkonto
- Skicka välkomstmail

Börja med att klona repot, checka ut US01-OpenAccount.
https://github.com/Lexicon-NET-2025-HT/BankRUs

Uppgift 1: Skapa bankkonto
Det behövs en entitet som representerar ett bankkonto, med tillhörande egenskaper såsom ägare, kontonummer och saldo.
Det behövs även ett repository för att skapa bankkonto i databasen.
Skapa och placera filerna på rätt ställe i projektet. Känner du dig osäker på var filerna bör ligga, använd AI för vägledning.

Uppgift 2: Skicka välkomstmail
Som sista steg i processen att skapa ett konto, vilket innefattar både skapande av en användare samt ett bankkonto åt denna, ska ett välkomstmail skickas ut till kund.
Vi vill undvika att skicka riktiga mail, och istället använda en lokal SMTP-server för utveckling.
Det finns många alternativ när det gäller att sätta upp en lokal SMTP-server. Ett populärt alternativ är Smtp4dev - förslagsvis använder du detta:
dotnet tool install -g Rnwood.Smtp4dev
https://github.com/rnwood/smtp4dev

När du väl implementerat detta, säkerställa att hela flödet fungerar - att ett användarkonto samt bankkonto skapas, samt att ett välkomstmail skickas ut.

Uppgift 3: Use Case "Skapa bankkonto" (BONUS)
För tillfället erbjuder systemet inte möjlighet att lägga till ytterligare bankkonto för en kund. Detta är dock något man behöver kunna göra, då en kund kan ha flera bankkonto.
Skapa ytterligare ett use case - OpenBankAccount, som triggas via nedan HTTP-anrop:

Endpoint
POST /api/bank-accounts

Payload
{
  "userId": "cb0fabcc-9c2c-451b-98b6-9f8743652e5c"
}

Uppgift 4: Förhindra dubbletter (BONUS)
För tillfället finns det inga begränsningar i databasen som förhindrar att samma kund registreras mer än en gång. Både personnummer och e-post behöver vara unikt i systemet. Uppdatera schemat för databasen så att dubbletter av personnummer och e-post inte tillåts för användare.
-----------------------
Install-Package Microsoft.AspNetCore.Authentication.JwtBearer
 

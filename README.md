# higlabo
HigLabo library provide features of Mail, Ftp, Rss, Twitter, ObjectMapper, ORM, ASP.NET Mvc...etc.

I added .NET Standard version at 2020/07/03.
It was https://github.com/higty/higlabo.netstandard repository.


## HigLabo.Mapper

A mapper library like AutoMapper,EmitMapper,FastMapper,ExpressMapper..etc.
You can map object out of box without configuration.
You can also customize completely as you can with AddPostAction method.
It's performance is great because this library generate il code on the fly.
You can know the detail of HigLabo.Mapper from here.

https://www.codeproject.com/Articles/1159789/HigLabo-Mapper-Zero-Configuraition-Full-customizat

Performance test at 2020/07/06.Mapster is fastest.
|              Method |       Mean |     Error |   StdDev | Ratio | RatioSD |    Gen 0 |  Gen 1 | Gen 2 |  Allocated |
|-------------------- |-----------:|----------:|---------:|------:|--------:|---------:|-------:|------:|-----------:|
| HandwriteMapperTest |   103.0 us |   8.25 us |  0.45 us |  1.00 |    0.00 |  76.7822 | 0.4883 |     - |  470.58 KB |
|   HigLaboMapperTest |   584.0 us | 297.98 us | 16.33 us |  5.67 |    0.13 |  97.6563 |      - |     - |  603.39 KB |
|         MapsterTest |   134.7 us |   4.23 us |  0.23 us |  1.31 |    0.00 |  74.2188 | 0.2441 |     - |  454.96 KB |
|      AutoMapperTest |   325.6 us |  35.37 us |  1.94 us |  3.16 |    0.00 |  68.8477 |      - |     - |  423.84 KB |
|   ExpressMapperTest |   342.4 us |  37.18 us |  2.04 us |  3.32 |    0.03 | 113.7695 | 0.4883 |     - |  697.14 KB |
|      TinyMapperTest |   428.9 us |  16.92 us |  0.93 us |  4.16 |    0.01 |  81.5430 | 0.4883 |     - |  501.83 KB |
|     AgileMapperTest |   445.4 us |  16.99 us |  0.93 us |  4.32 |    0.01 | 153.8086 | 0.4883 |     - |  944.05 KB |
|      FastMapperTest | 1,062.2 us | 274.28 us | 15.03 us | 10.31 |    0.15 | 205.0781 |      - |     - | 1259.64 KB |


## DbSharp
A code generator to call stored procedure on database(SQL server, MySQL)

https://www.codeproject.com/Articles/776811/DbSharp-DAL-Generator-Tool-on-NET-Core

## HigLabo.Mime
A library of Mime parser.World fastest parser of MIME.It is used for HigLabo.Mail.

## HigLabo.Mail
A mail library of SMTP,POP3,IMAP.

https://www.codeproject.com/Articles/399207/Understanding-the-Insides-of-the-SMTP-Mail-Protoco
https://www.codeproject.com/Articles/404066/Understanding-the-insides-of-the-POP-mail-protoco
https://www.codeproject.com/Articles/411018/Understanding-the-insides-of-the-IMAP-mail-protoco

## HigLabo.Data.XXX
A library for database access.

## HigLabo.Converter
Converter library for Base64,QueryString,QuotedPrintable,Rfc2047,ModifiedUtf7,ISO8601...etc.

## HigLabo.Bot.Facebook
A library to call Facebook Messenger API.

## HigLabo.Bot.LINE
A library to call LINE API.LINE is most used messaging app in Japan.

## HigLabo.Csv
CsvWriter libary.This library does not include CsvReader library.




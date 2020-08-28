# higlabo
HigLabo library provide features 
1. Object Mapper(fastest in the world)
2. DbSharp(DAL generator)
3. And other.(Mail, Ftp, Rss, Twitter...etc)

I added .NET Standard version at 2020/07/03.
It was moved from https://github.com/higty/higlabo.netstandard repository.


## HigLabo.Mapper
A mapper library like AutoMapper,EmitMapper,FastMapper,ExpressMapper..etc.
I posted article to CodeProject.
https://www.codeproject.com/Articles/5275388/HigLabo-Mapper-Creating-Fastest-Object-Mapper-in-t

You can map object out of box without configuration.
You can also customize completely as you can with AddPostAction,ReplaceMap method.

I completely rewrite HigLabo.Mapper. Now, HigLabo.Mapper is fastest mapper library in the world.
Performance test at 2020/08/01.
|                                   Method |         Mean |       Error |     StdDev |  Ratio | RatioSD |    Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------------------------- |-------------:|------------:|-----------:|-------:|--------:|---------:|-------:|------:|----------:|
|                  HandwriteMapper_Address |     7.552 us |   0.5069 us |  0.0278 us |   1.00 |    0.00 |   6.4163 |      - |     - |   40253 B |
|              HigLaboObjectMapper_Address |    37.117 us |   3.9361 us |  0.2158 us |   4.92 |    0.04 |   7.6294 |      - |     - |   48000 B |
|           HigLaboObjectMapConfig_Address |   148.455 us |  16.8335 us |  0.9227 us |  19.66 |    0.19 |  17.8223 |      - |     - |  112000 B |
|                          Mapster_Address |    41.172 us |   2.6546 us |  0.1455 us |   5.45 |    0.02 |   7.6294 |      - |     - |   48000 B |
|                       AutoMapper_Address |   113.133 us |  25.1448 us |  1.3783 us |  14.98 |    0.23 |        - |      - |     - |         - |
|                    ExpressMapper_Address |   123.352 us |  12.8851 us |  0.7063 us |  16.33 |    0.14 |  13.9160 |      - |     - |   88000 B |
|                      AgileMapper_Address |   321.437 us |  36.6738 us |  2.0102 us |  42.57 |    0.39 |  82.0313 |      - |     - |  516803 B |
|                       FastMapper_Address |   237.159 us |  16.1570 us |  0.8856 us |  31.40 |    0.16 |  59.8145 |      - |     - |  376000 B |
|                       TinyMapper_Address |    82.067 us |   7.3080 us |  0.4006 us |  10.87 |    0.09 |  15.2588 |      - |     - |   96000 B |
|           HigLaboObjectMapper_AddressDTO |    34.635 us |   3.0237 us |  0.1657 us |   4.59 |    0.04 |   6.3477 |      - |     - |   40000 B |
|        HigLaboObjectMapConfig_AddressDTO |   139.313 us |   7.5495 us |  0.4138 us |  18.45 |    0.12 |  16.3574 |      - |     - |  104000 B |
|                       Mapster_AddressDTO |    37.624 us |   5.9133 us |  0.3241 us |   4.98 |    0.06 |   6.3477 |      - |     - |   40000 B |
|                    AutoMapper_AddressDTO |   121.693 us |   8.5257 us |  0.4673 us |  16.11 |    0.11 |   6.3477 |      - |     - |   40000 B |
|                 ExpressMapper_AddressDTO |   127.495 us |  28.0275 us |  1.5363 us |  16.88 |    0.26 |  12.6953 |      - |     - |   80000 B |
|                   AgileMapper_AddressDTO |   159.150 us |  62.7304 us |  3.4385 us |  21.07 |    0.43 |  48.3398 |      - |     - |  304000 B |
|                    FastMapper_AddressDTO |   230.696 us |  53.7239 us |  2.9448 us |  30.55 |    0.35 |  59.8145 |      - |     - |  376000 B |
|                    TinyMapper_AddressDTO |    70.651 us |   4.1426 us |  0.2271 us |   9.36 |    0.05 |  13.9160 |      - |     - |   88000 B |
|             HigLaboObjectMapper_Customer |    88.213 us |  12.1313 us |  0.6650 us |  11.68 |    0.11 |  47.1191 |      - |     - |  296000 B |
|          HigLaboObjectMapConfig_Customer |   645.152 us |  57.3785 us |  3.1451 us |  85.43 |    0.55 | 100.5859 |      - |     - |  632000 B |
|                         Mapster_Customer |   861.706 us |  69.4256 us |  3.8055 us | 114.11 |    0.32 |  64.4531 |      - |     - |  408000 B |
|                      AutoMapper_Customer |   270.586 us |  50.3047 us |  2.7574 us |  35.83 |    0.49 |  35.6445 |      - |     - |  224000 B |
|                   ExpressMapper_Customer |   344.622 us | 229.5338 us | 12.5815 us |  45.63 |    1.63 | 106.9336 | 0.4883 |     - |  673852 B |
|                     AgileMapper_Customer | 2,000.527 us | 150.7667 us |  8.2640 us | 264.91 |    2.03 | 535.1563 | 3.9063 |     - | 3376268 B |
|                      FastMapper_Customer | 1,314.517 us | 977.0347 us | 53.5546 us | 174.05 |    6.48 | 232.4219 |      - |     - | 1465848 B |
|                      TinyMapper_Customer | 1,688.700 us |  90.1517 us |  4.9415 us | 223.62 |    1.39 | 158.2031 |      - |     - |  993850 B |
|     HandwriteMapper_Customer_CustomerDTO |    86.716 us |  10.3637 us |  0.5681 us |  11.48 |    0.04 |  62.7441 | 0.2441 |     - |  393851 B |
| HigLaboObjectMapper_Customer_CustomerDTO |   137.967 us |  36.1755 us |  1.9829 us |  18.27 |    0.29 |  76.4160 |      - |     - |  480000 B |
|             Mapster_Customer_CustomerDTO |   263.971 us |  40.1365 us |  2.2000 us |  34.95 |    0.17 |  76.1719 |      - |     - |  480000 B |
|          AutoMapper_Customer_CustomerDTO |   280.642 us |  15.2435 us |  0.8355 us |  37.16 |    0.06 |  68.8477 |      - |     - |  432000 B |

HigLabo.Mapper (version3.0.0 or later) is used expression tree.

For backward compatibility, old version HigLabo.Mapper is moved to HigLabo.Mapper.ObjectMapConfig.


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




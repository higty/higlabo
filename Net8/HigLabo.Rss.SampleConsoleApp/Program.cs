﻿using HigLabo.Rss;

var xml = await File.ReadAllTextAsync(Path.Combine(Environment.CurrentDirectory, "Xml", "Rss_2_0.xml"));

var parser = new Rss_2_0_Parser();
var feed = parser.Parse(xml);

foreach (RssItem_2_0 item in feed.Items)
{
    Console.WriteLine(item.ToString());
    Console.WriteLine(item.Author);
    Console.WriteLine("--------------");
}
Console.WriteLine("Parse success");
Console.ReadLine();


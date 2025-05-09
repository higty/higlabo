﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using HigLabo.Rss.Internal;

namespace HigLabo.Rss;

public class Rss_0_92_Parser : RssParser
{
    public override RssVersion Version
    {
        get { return RssVersion.Rss_0_92; }
    }
    public override RssChannel CreateRssChannel(XElement element)
    {
        return new RssChannel_0_92(element);
    }
    public override RssImage CreateRssImage(XElement element)
    {
        return new RssImage_0_92(element);
    }
    public override RssItem CreateRssItem(XElement element)
    {
        return new RssItem_0_92(element);
    }
    public override RssTextInput CreateRssTextInput(XElement element)
    {
        return new RssTextInput_0_92(element);
    }
}

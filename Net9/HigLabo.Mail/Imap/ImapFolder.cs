using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace HigLabo.Net.Imap;

public class ImapFolder
{
    public String Name { get; set; } = "";
    public Boolean HasChildren { get; set; }
    public Boolean NoSelect { get; set; }
    public Int32 MailCount { get; set; }
    public Int32 RecentMailCount { get; set; }
    public ReadOnlyCollection<String> Flags { get; private set; }

    public ImapFolder(SelectResult result)
    {
        this.Name = result.FolderName;
        this.MailCount = result.Exists;
        this.RecentMailCount = result.Recent;
        this.Flags = new ReadOnlyCollection<string>(new List<string>(result.Flags));
    }
    public ImapFolder(ListLineResult result)
    {
        this.Name = result.Name;
        this.NoSelect = result.NoSelect;
        this.HasChildren = result.HasChildren;
        this.MailCount = -1;
        this.RecentMailCount = -1;
        this.Flags = new ReadOnlyCollection<string>(new List<string>());
    }
    public ImapFolder(String folderName, Boolean noSelect, Boolean hasChildren)
    {
        this.Name = folderName;
        this.NoSelect = noSelect;
        this.HasChildren = hasChildren;
        this.MailCount = -1;
        this.RecentMailCount = -1;
        this.Flags = new ReadOnlyCollection<string>(new List<string>());
    }

    public override string ToString()
    {
        return this.Name;
    }
}

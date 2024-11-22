using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Web.RazorComponent.Panel;

public partial class SelectTimePanel
{
    public class MinuteSetting
    {
        public int Minute { get; set; }

        public bool IsDisplay { get; set; }

        public MinuteSetting(int minute, bool isDisplay)
        {
            Minute = minute;
            IsDisplay = isDisplay;
        }
    }


    [Parameter]
    public SelectEndTimeMode SelectEndTimeMode { get; set; } = SelectEndTimeMode.StartTime;
    [Parameter]
    public int StartHour { get; set; } = 9;
    [Parameter]
    public int EndHour { get; set; } = 18;
    [Parameter]
    public int MaxHour { get; set; } = 24;
    [Parameter]
    public bool DisplayAllTime { get; set; } = false;

    [Parameter]
    public TimeSpan? StartTime { get; set; }
    [Parameter]
    public EventCallback<SelectedTimeDuration> StartTimeSelected { get; set; }
    [Parameter]
    public EventCallback<SelectedTimeDuration> EndTimeSelected { get; set; }
    [Parameter]
    public EventCallback OnClosed { get; set; }

    public List<MinuteSetting> MinuteList { get; private set; } = new ();
    public List<MinuteSetting> DurationList { get; private set; } = new ();

    public SelectTimePanel()
    {
        MinuteList.Add(new MinuteSetting(0, true));
        MinuteList.Add(new MinuteSetting(10, false));
        MinuteList.Add(new MinuteSetting(15, true));
        MinuteList.Add(new MinuteSetting(20, false));
        MinuteList.Add(new MinuteSetting(30, true));
        MinuteList.Add(new MinuteSetting(40, false));
        MinuteList.Add(new MinuteSetting(45, true));
        MinuteList.Add(new MinuteSetting(50, false));
        DurationList.Add(new MinuteSetting(15, true));
        DurationList.Add(new MinuteSetting(30, true));
        DurationList.Add(new MinuteSetting(45, true));
        DurationList.Add(new MinuteSetting(60, true));
        DurationList.Add(new MinuteSetting(90, true));
        DurationList.Add(new MinuteSetting(120, true));
        DurationList.Add(new MinuteSetting(180, true));
        for (int i = 4; i < 14; i++)
        {
            DurationList.Add(new MinuteSetting(i * 60, false));
        }
    }

    private async ValueTask StartTimePanel_Click(TimeSpan value)
    {
        this.StartTime = value;

        var r = new SelectedTimeDuration();
        r.StartTime = value;
        await this.StartTimeSelected.InvokeAsync(r);
    }
    private async ValueTask EndTimePanel_Click(TimeSpan value)
    {
        var r = new SelectedTimeDuration();
        r.StartTime = this.StartTime;
        r.EndTime = value;
        await this.EndTimeSelected.InvokeAsync(r);
    }
    private async ValueTask DurationPanel_Click(int minute)
    {
        var r = new SelectedTimeDuration();
        r.StartTime = this.StartTime;
        if (r.StartTime.HasValue)
        {
            r.EndTime = r.StartTime.Value + TimeSpan.FromMinutes(minute);
        }
        await this.EndTimeSelected.InvokeAsync(r);
    }

    private async ValueTask CloseButton_Click()
    {
        await this.OnClosed.InvokeAsync();
    }
}

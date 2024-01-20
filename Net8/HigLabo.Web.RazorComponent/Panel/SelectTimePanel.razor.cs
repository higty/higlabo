using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Web.RazorComponent.Panel
{
    public partial class SelectTimePanel
    {
        public enum SelectMode
        {
            StartTime,
            EndTime,
            Duration,
        }
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
        public SelectMode Mode { get; set; } = SelectMode.StartTime;
        [Parameter]
        public int StartHour { get; set; } = 9;
        [Parameter]
        public int EndHour { get; set; } = 18;
        [Parameter]
        public int MaxHour { get; set; } = 30;
        [Parameter]
        public bool DisplayAllTime { get; set; } = false;
        [Parameter]
        public EventCallback<SelectedTimeDuration> TimeSelected { get; set; }

        public List<MinuteSetting> MinuteList { get; private set; } = new List<MinuteSetting>();
        public List<int> DurationList { get; private set; } = new List<int>();

        public SelectTimePanel()
        {
            MinuteList.Add(new MinuteSetting(0, isDisplay: true));
            MinuteList.Add(new MinuteSetting(10, isDisplay: false));
            MinuteList.Add(new MinuteSetting(15, isDisplay: true));
            MinuteList.Add(new MinuteSetting(20, isDisplay: false));
            MinuteList.Add(new MinuteSetting(30, isDisplay: true));
            MinuteList.Add(new MinuteSetting(40, isDisplay: false));
            MinuteList.Add(new MinuteSetting(45, isDisplay: true));
            MinuteList.Add(new MinuteSetting(50, isDisplay: false));
            DurationList.Add(15);
            DurationList.Add(30);
            DurationList.Add(45);
            DurationList.Add(60);
            DurationList.Add(90);
            for (int i = 2; i < 14; i++)
            {
                DurationList.Add(i * 60);
            }
        }

        private async ValueTask StartTimePanel_Click(TimeSpan timeSpan)
        {
            var r = new SelectedTimeDuration();
            r.StartTime = timeSpan;
            if (this.Mode == SelectMode.StartTime)
            {
                await this.TimeSelected.InvokeAsync(r);
            }
        }
        private async ValueTask EndTimePanel_Click(TimeSpan timeSpan)
        {
            var r = new SelectedTimeDuration();
            r.EndTime = timeSpan;
            await this.TimeSelected.InvokeAsync(r);
        }
    }
}

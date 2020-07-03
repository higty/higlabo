using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HigLabo.Core;
using System.ComponentModel;

namespace HigLabo.DbSharpApplication.Core
{
    public class ConnectionStringInfo: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private String _Name = "";
        private String _ConnectionString = "";
        private Int32 _TimeZone = DateTimeOffset.Now.Offset.Hours;

        public String Name
        {
            get { return this._Name; }
            set { this.SetPropertyValue(ref _Name, value, this.PropertyChanged); }
        }
        public String ConnectionString
        {
            get { return this._ConnectionString; }
            set { this.SetPropertyValue(ref _ConnectionString, value, this.PropertyChanged); }
        }
        public Int32 TimeZone
        {
            get { return this._TimeZone; }
            set { this.SetPropertyValue(ref _TimeZone, value, this.PropertyChanged); }
        }
    }
}

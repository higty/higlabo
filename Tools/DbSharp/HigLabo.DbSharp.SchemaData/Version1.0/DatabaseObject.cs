using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.DbSharp.MetaData
{
    public class DatabaseObject : INotifyPropertyChanged
    {
        public virtual event PropertyChangedEventHandler PropertyChanged;

        private DatabaseObjectType _ObjectType = DatabaseObjectType.Unknown;
        private String _Name = "";
        private String _Body = "";
        private DateTime _CreateTime = DateTime.MinValue;
        private DateTime _LastAlteredTime = DateTime.MinValue;

        public DatabaseObjectType ObjectType
        {
            get { return this._ObjectType; }
            set { this.SetPropertyValue(ref _ObjectType, value, PropertyChanged); }
        }
        public String Name
        {
            get { return this._Name; }
            set { this.SetPropertyValue(ref _Name, value, PropertyChanged); }
        }
        public String Body
        {
            get { return this._Body; }
            set { this.SetPropertyValue(ref _Body, value, PropertyChanged); }
        }
        public DateTime CreateTime
        {
            get { return this._CreateTime; }
            set { this.SetPropertyValue(ref _CreateTime, value, PropertyChanged); }
        }
        public DateTime LastAlteredTime
        {
            get { return this._LastAlteredTime; }
            set { this.SetPropertyValue(ref _LastAlteredTime, value, PropertyChanged); }
        }
        public DatabaseObject()
        {
        }
        public DatabaseObject(DatabaseObjectType objectType)
        {
            this.ObjectType = objectType;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}

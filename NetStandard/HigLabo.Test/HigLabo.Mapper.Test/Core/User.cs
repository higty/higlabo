using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Mapper.Test
{
    public interface IUser
    {
        String Value { get; set; }
        String Name { get; set; }
    }

    public class User : IUser
    {
        public class InnerClassUser : User
        {

        }

        public String Value { get; set; }
        public String Name { get; set; }

        public Int32 Int32 { get; set; }
        public Int32? Int32Nullable { get; set; }
        public Int32? Int32_Nullable { get; set; }
        public Int32? Int32NullableToInt32 { get; set; }
        public Int32 Int32ToInt32Nullable { get; set; }
        public DateTime DateTime { get; set; }
        public DateTime? DateTimeNullable { get; set; }
        public Decimal Decimal { get; set; }
        public Decimal? DecimalNullable { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public DayOfWeek? DayOfWeekNullable { get; set; }
        public DayOfWeek DayOfWeekToDayOfWeekNullable { get; set; }
        public DayOfWeek DayOfWeekToString { get; set; }
        public DayOfWeek? DayOfWeekNullableToString { get; set; }
        public Guid Guid { get; set; }
        public Guid? GuidNullable { get; set; }

        public MapPoint MapPoint { get; set; }
        public Vector2 VectorToNullable { get; set; }
        public Vector2 Vector2 { get; set; }
        public Vector2 Vector2ToString { get; set; }
        public User ParentUser { get; set; }
        public List<User> Users { get; set; }
        public List<Guid> GuidList { get; private set; } = new List<Guid>();
        public String[] Tags { get; set; }
        public Dictionary<String, String> Dictionary { get; set; }
        public IDictionary<String, ColorDefinition> ColorList { get; set; }
        public Byte[] Timestamp { get; set; }

        public String ReadOnlyProperty
        {
            get { return String.Format("{0}={1}", this.Name, this.Value); }
        }

        public User()
            : this("TestUser")
        {
        }
        public User(String name)
        {
            this.Name = name;
            this.Int32 = 3;
            this.Int32NullableToInt32 = 32;
            this.DateTime = new DateTime(2014, 12, 16);
            this.Decimal = 20.4m;
            this.DayOfWeek = DayOfWeek.Monday;

            this.Vector2 = new Vector2(2, 4);
            this.MapPoint = new MapPoint();

            this.Users = new List<User>();
        }
    }
    public class ColorDefinition
    {
        public virtual string Background { get; set; }
        public virtual string Foreground { get; set; }
        public ColorDefinition() { }
        public ColorDefinition(String background, String foreground)
        {
            this.Background = background;
            this.Foreground = foreground;
        }
    }
    public class UserFlatten
    {
        public String Value { get; set; }
        public String Name { get; set; }

        public Int32 Int32 { get; set; }
        public Int32? Int32Nullable { get; set; }
        public Int32 Int32NullableToInt32 { get; set; }
        public Int32? Int32ToInt32Nullable { get; set; }
        public DateTime DateTime { get; set; }
        public DateTime? DateTimeNullable { get; set; }
        public Decimal Decimal { get; set; }
        public Decimal? DecimalNullable { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public DayOfWeek? DayOfWeekNullable { get; set; }
        public DayOfWeek? DayOfWeekToDayOfWeekNullable { get; set; }
        public String DayOfWeekToString { get; set; }
        public String DayOfWeekNullableToString { get; set; }

        public Vector2? VectorToNullable { get; set; }
        public String Vector2ToString { get; set; }
        public Decimal Longitude { get; set; }
        public Decimal Latitude { get; set; }
        public Int32 X { get; set; }
        public Int32 Y { get; set; }

        public String Users { get; set; }
        public String Tags { get; set; }
    }
    public class VipUser : User
    {
        public Int32 Grade { get; set; }

        public VipUser()
        {
        }
        public VipUser(String name)
            : base(name)
        {

        }
    }
    public class UserNoDefaultConstructor : User
    {
        public UserNoDefaultConstructor(String name)
        {
            this.Name = name;
        }
    }
    public class UserListInfo 
    {
        public String GroupName { get; set; }
        public List<User> Users { get; set; }

        public UserListInfo()
        {
            this.Users = new List<User>();
        }
    }
    public class VipUserListInfo
    {
        public String GroupName { get; set; }
        public List<VipUser> Users { get; set; } = new List<VipUser>();
    }
    public interface IUsers
    {
        List<User> Users { get; }
    }
    public class UserListInfoWithInterface: IUsers
    {
        public List<User> Users { get; set; } = new List<User>();
    }
    public class UserListInfoWithInterface_SubClass : UserListInfoWithInterface
    {

    }
}

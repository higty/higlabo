using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HigLabo.Core;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Dynamic;
using System.Data.SqlClient;
using System.IO;
using System.Data;

namespace HigLabo.Mapper.Test
{
    [TestClass]
    public class ObjectMapperTest
    {
        [TestMethod]
        public void ObjectMapper_Map_Object_Object()
        {
            var mapper = new ObjectMapper();
            //mapper.Config.ClassPropertyMapMode = ClassPropertyMapMode.NewObject;

            var u1 = new User();

            var u2 = mapper.Map(u1, new User());

            Assert.AreEqual(u1.Name, u2.Name);
            Assert.AreEqual(u1.Int32, u2.Int32);
            Assert.AreEqual(u1.Decimal, u2.Decimal);
            Assert.AreEqual(u1.DateTime, u2.DateTime);
            Assert.AreEqual(u1.DayOfWeek, u2.DayOfWeek);

            Assert.AreEqual(u1.MapPoint.Latitude, u2.MapPoint.Latitude);
            Assert.AreEqual(u1.MapPoint.Longitude, u2.MapPoint.Longitude);

            Assert.AreEqual(u1.Vector2.X, u2.Vector2.X);
            Assert.AreEqual(u1.Vector2.Y, u2.Vector2.Y);
        }
        [TestMethod]
        public void ObjectMapper_Map_ValueType_Object()
        {
            var mapper = new ObjectMapper();

            var v1 = new Vector2(3, 6);
            var u1 = mapper.Map(v1, new UserFlatten());

            Assert.AreEqual(u1.X, v1.X);
        }
        [TestMethod]
        public void ObjectMapper_Map_GenericType_Object()
        {
            var mapper = new ObjectMapper();

            var u1 = new User();
            var u2 = Map_GenericType_Object<User>(u1);

            Assert.AreEqual(u1.Name, u2.Name);
            Assert.AreEqual(u1.Int32, u2.Int32);
            Assert.AreEqual(u1.Decimal, u2.Decimal);
            Assert.AreEqual(u1.DateTime, u2.DateTime);
            Assert.AreEqual(u1.DayOfWeek, u2.DayOfWeek);

            Assert.AreEqual(u1.MapPoint.Latitude, u2.MapPoint.Latitude);
            Assert.AreEqual(u1.MapPoint.Longitude, u2.MapPoint.Longitude);

            Assert.AreEqual(u1.Vector2.X, u2.Vector2.X);
            Assert.AreEqual(u1.Vector2.Y, u2.Vector2.Y);
        }
        private T Map_GenericType_Object<T>(T value)
            where T: class, new()
        {
            return value.Map(new T());
        }
        [TestMethod]
        public void ObjectMapper_Map_Object_ValueType()
        {
            var mapper = new ObjectMapper();

            var u1 = new UserFlatten();
            u1.X = 5;
            u1.Y = 7;
            var v1 = mapper.Map(u1, new Vector2(3, 6));

            Assert.AreEqual(u1.X, v1.X);
            Assert.AreEqual(u1.Y, v1.Y);
        }
        [TestMethod]
        public void ObjectMapper_MapOrNull()
        {
            var mapper = new ObjectMapper();

            var u1 = new User();
            User u2 = null;
            var u3 = mapper.MapOrNull(u1, () => new User() { Int32 = 3 });
            var u4 = mapper.MapOrNull(u2, () => new User() { Int32 = 3 });

            Assert.AreEqual(u3.Int32, 3);
            Assert.AreEqual(u4, null);
        }
        [TestMethod]
        public void ObjectMapper_Map_Object_Object_SetNullablePropertyToNull()
        {
            var mapper = new ObjectMapper();

            var u1 = new User();
            u1.DecimalNullable = null;
            u1.ParentUser = null;
            var u2 = new User();
            u2.DecimalNullable = 23.4m;
            u2.ParentUser = new User();
            mapper.Map(u1, u2);

            var u3 = new User();
            u3.ParentUser = null;
            mapper.Map(u1, u3);

            Assert.IsNull(u2.DecimalNullable);
            Assert.IsNull(u2.ParentUser);
            Assert.IsNull(u3.ParentUser);
        }
        [TestMethod]
        public void ObjectMapper_Map_Inherit_New_List_Property()
        {
            var mapper = new ObjectMapper();

            var s1 = new ScheduleRecord();
            s1.Title = "s1";
            s1.StartTime = new DateTimeOffset(2020, 1, 1, 9,0,0, TimeSpan.FromHours(9));
            s1.EndTime = new DateTimeOffset(2020, 1, 1, 10, 0, 0, TimeSpan.FromHours(9));
            var s2 = new ScheduleRecordChild();
            mapper.Map(s1, s2);

            Assert.AreEqual(s1.Title, s2.Title);
        }

        //[TestMethod]
        //public void ObjectMapper_Map_ClassPropertyMapMode_NullProperty_None()
        //{
        //    var mapper = new ObjectMapper();
        //    mapper.Config.ClassPropertyMapMode = ClassPropertyMapMode.None;
        //    mapper.MaxCallStackCount = 100;

        //    var u1 = new User();
        //    u1.ParentUser = null;
        //    var u2 = new User();
        //    u2.ParentUser = null;
        //    mapper.Map(u1, u2);

        //    Assert.IsNull(u2.ParentUser);
        //}
        //[TestMethod]
        //public void ObjectMapper_Map_ClassPropertyMapMode_NullProperty_NewObject()
        //{
        //    var mapper = new ObjectMapper();
        //    mapper.Config.ClassPropertyMapMode = ClassPropertyMapMode.NewObject;
        //    mapper.MaxCallStackCount = 100;

        //    var u1 = new User();
        //    u1.ParentUser = new User("ParentUser1");
        //    u1.Dictionary = new Dictionary<string, string>();
        //    var u2 = new User();
        //    u2.ParentUser = null;
        //    u2.Dictionary = null;
        //    mapper.Map(u1, u2);

        //    Assert.IsNotNull(u2.ParentUser);
        //    Assert.IsNotNull(u2.Dictionary);
        //    Assert.AreEqual("ParentUser1", u2.ParentUser.Name);

        //    u1.ParentUser.Name = "ParentUserChanged";
        //    //Difference object
        //    Assert.AreNotEqual("ParentUserChanged", u2.ParentUser.Name);
        //}
        [TestMethod]
        public void ObjectMapper_Map_ClassPropertyMapMode_NullProperty_DeepCopy()
        {
            var mapper = new ObjectMapper();
            mapper.CompilerConfig.ClassPropertyMapMode = ClassPropertyMapMode.DeepCopy;
            var u1 = new User();
            u1.ParentUser = new User("ParentUser");
            var u2 = new User();
            u2.ParentUser = null;
            mapper.Map(u1, u2);

            Assert.IsNotNull(u2.ParentUser);

            u1.ParentUser.Name = "ParentUserChanged";
            //Same object
            Assert.AreEqual("ParentUserChanged", u2.ParentUser.Name);
        }

        //[TestMethod]
        //public void ObjectMapper_Map_CollectionElementMapMode_CollectionElement_None()
        //{
        //    var mapper = new ObjectMapper();
        //    mapper.Config.CollectionElementMapMode = CollectionElementMapMode.None;

        //    var u1 = new User();
        //    for (int i = 0; i < 3; i++)
        //    {
        //        u1.Users.Add(new User("TestUser" + i.ToString()));
        //    }
        //    var u2 = mapper.Map(u1, new User());

        //    mapper.AddPostAction<User, User>((source, target) =>
        //    {
        //        if (source == null) { return; }
        //        target.Users.AddRange(source.Users);
        //    });
        //    var u3 = mapper.Map(u1, new User());

        //    Assert.AreEqual(0, u2.Users.Count);
        //    Assert.AreEqual(3, u3.Users.Count);
        //}
        [TestMethod]
        public void ObjectMapper_Map_CollectionElementMapMode_CollectionElement_NewObject()
        {
            var mapper = new ObjectMapper();
            mapper.CompilerConfig.CollectionElementMapMode = CollectionElementMapMode.NewObject;

            var u1 = new User();
            for (int i = 0; i < 3; i++)
            {
                u1.Users.Add(new User("TestUser" + i.ToString()));
            }
            var u2 = mapper.Map(u1, new User());
            u1.Users[0].Name = "Test20";

            Assert.AreEqual(3, u2.Users.Count);
            Assert.AreNotEqual("Test20", u2.Users[0].Name);
        }
        [TestMethod]
        public void ObjectMapper_Map_CollectionElementMapMode_CollectionElement_NewObject_NoDefaultConstructor()
        {
            var mapper = new ObjectMapper();
            mapper.CompilerConfig.CollectionElementMapMode = CollectionElementMapMode.NewObject;

            var u1 = new List<User>();
            for (int i = 0; i < 3; i++)
            {
                u1.Add(new User("TestUser" + i.ToString()));
            }
            var u2 = mapper.Map(u1, new List<UserNoDefaultConstructor>());

            Assert.AreEqual(0, u2.Count);
        }
        [TestMethod]
        public void ObjectMapper_Map_CollectionElementMapMode_CollectionElement_DeepCopy_SameClass()
        {
            var mapper = new ObjectMapper();
            mapper.CompilerConfig.CollectionElementMapMode = CollectionElementMapMode.DeepCopy;

            var u1 = new User();
            for (int i = 0; i < 3; i++)
            {
                u1.Users.Add(new User("TestUser" + i.ToString()));
            }
            var u2 = mapper.Map(u1, new User());
            u1.Users[0].Name = "Test20";

            Assert.AreEqual(3, u2.Users.Count);
            Assert.AreEqual("Test20", u2.Users[0].Name);
        }
        [TestMethod]
        public void ObjectMapper_Map_CollectionElementMapMode_CollectionElement_DeepCopy_OtherClass()
        {
            var mapper = new ObjectMapper();
            mapper.CompilerConfig.CollectionElementMapMode = CollectionElementMapMode.DeepCopy;

            var u1 = new VipUserListInfo();
            u1.GroupName = "Group1";
            var u2 = new UserListInfo();
            for (int i = 0; i < 3; i++)
            {
                u1.Users.Add(new VipUser("TestUser" + i.ToString()));
            }
            mapper.Map(u1, u2);
            u1.Users[0].Name = "Test20";

            Assert.AreEqual(3, u2.Users.Count);
            Assert.AreEqual("Group1", u2.GroupName);
            Assert.AreEqual("Test20", u2.Users[0].Name);
        }
        [TestMethod]
        public void ObjectMapper_Map_CollectionElementMapMode_DeepCopy_Implement_Interface()
        {
            var mapper = new ObjectMapper();
            mapper.CompilerConfig.CollectionElementMapMode = CollectionElementMapMode.DeepCopy;

            var u1 = new UserListInfoWithInterface();
            var u2 = new UserListInfoWithInterface_SubClass();
            for (int i = 0; i < 3; i++)
            {
                u1.Users.Add(new VipUser("TestUser" + i.ToString()));
            }
            mapper.Map(u1, u2);
            u1.Users[0].Name = "Test20";

            Assert.AreEqual(3, u2.Users.Count);
            Assert.AreEqual("Test20", u2.Users[0].Name);
        }
        [TestMethod]
        public void ObjectMapper_Map_CollectionElementMapMode_InfiniteLoop()
        {
            var mapper = new ObjectMapper();
            mapper.CompilerConfig.CollectionElementMapMode = CollectionElementMapMode.NewObject;

            var n1 = new TreeNode();
            n1.Nodes = new List<TreeNode>();
            n1.Nodes.Add(n1);
            var n2 = mapper.Map(n1, new TreeNode());
        }

        [TestMethod]
        public void ObjectMapper_Map_Dictionary_Object()
        {
            var mapper = new ObjectMapper();

            var d = new Dictionary<String, String>();
            d["Name"] = "N";
            d["Int32"] = "46";
            d["Decimal"] = "46.46";
            d["DateTime"] = "2014/12/17";
            d["DayOfWeek"] = "Friday";
            d["GuidNullable"] = "7195FBEF-B18C-BC29-E339-39DDC81FC90F";
            var u1 = new User();
            u1.Value = "Value1";
            var u2 = mapper.Map(d, u1);

            Assert.AreEqual("Value1", u2.Value);
            Assert.AreEqual("N", u2.Name);
            Assert.AreEqual(46, u2.Int32);
            Assert.AreEqual(46.46m, u2.Decimal);
            Assert.AreEqual(new DateTime(2014, 12,17), u2.DateTime);
            Assert.AreEqual(DayOfWeek.Friday, u2.DayOfWeek);
            Assert.AreEqual(new Guid("7195FBEF-B18C-BC29-E339-39DDC81FC90F"), u2.GuidNullable);
        }
        [TestMethod]
        public void ObjectMapper_Map_Object_Dictionary()
        {
            var mapper = new ObjectMapper();

            var u1 = new User();
            var d = mapper.Map(u1, new Dictionary<String, Object>());

            Assert.AreEqual(u1.Name, d["Name"]);
            Assert.AreEqual(u1.Int32, d["Int32"]);
            Assert.AreEqual(u1.Decimal, d["Decimal"]);
            Assert.AreEqual(u1.DateTime, d["DateTime"]);
            Assert.AreEqual(u1.DayOfWeek, d["DayOfWeek"]);
            Assert.AreEqual(u1.MapPoint, d["MapPoint"]);
        }
        [TestMethod]
        public void ObjectMapper_Map_Dictionary_Object_Convert_Failure()
        {
            var mapper = new ObjectMapper();

            var d = new Dictionary<String, String>();
            d["Decimal"] = "abc";
            var u2 = mapper.Map(d, new User());
            //Not changed...
            Assert.AreEqual(20.4m, u2.Decimal);
        }
        //[TestMethod]
        //public void ObjectMapper_Map_FromDecimalToInt32()
        //{
        //    var mapper = new ObjectMapper();
        //    mapper.PropertyMapRules.Clear();

        //    var rule = new PropertyNameMappingRule();
        //    rule.AddPropertyNameMap("Int32", "Decimal");
        //    mapper.PropertyMapRules.Add(rule);

        //    var u1 = new User();
        //    u1.Int32 = 23;
        //    var u2 = mapper.Map(u1, new User());

        //    Assert.AreEqual(23m, u2.Decimal);
        //}
        [TestMethod]
        public void ObjectMapper_Map_ByteArrayProperty()
        {
            var mapper = new ObjectMapper();
            mapper.CompilerConfig.ClassPropertyMapMode = ClassPropertyMapMode.NewObject;

            var u1 = new User();
            u1.Timestamp = new Byte[] { 1, 3, 6 };

            var u2 = mapper.Map(u1, new User());

            Assert.AreEqual(u1.Timestamp[2], u2.Timestamp[2]);
        }

        [TestMethod]
        public void ObjectMapper_Map_Dictionary_Encoding()
        {
            var mapper = new ObjectMapper();

            var d = new Dictionary<String, String>();
            d["Encoding"] = "UTF-8";
            var p1 = new TextParser();
            p1.Encoding = Encoding.ASCII;
            var p2 = mapper.Map(d, p1);

            Assert.AreEqual(Encoding.UTF8, p2.Encoding);
        }
        [TestMethod]
        public void ObjectMapper_Map_StringProperty_Encoding()
        {
            var mapper = new ObjectMapper();

            var p = new TextParser_StringProperty();
            p.Encoding = "UTF-8";
            var p1 = new TextParser();
            p1.Encoding = Encoding.ASCII;
            var p2 = mapper.Map(p, p1);

            Assert.AreEqual(Encoding.UTF8, p2.Encoding);
        }
        [TestMethod]
        public void ObjectMapper_Map_Dictionary_ClassPropertyMapMode_NewObject()
        {
            var mapper = new ObjectMapper();
            mapper.CompilerConfig.ClassPropertyMapMode = ClassPropertyMapMode.NewObject;

            var d = new Dictionary<String, String>();
            d["Int32Nullable"] = "abc";
            var u2 = new User();
            u2.Int32Nullable = null;
            mapper.Map(d, u2);

            Assert.AreEqual(null, u2.Int32Nullable);
        }
        [TestMethod]
        public void ObjectMapper_Map_DynamicObject_Object()
        {
            var mapper = new ObjectMapper();
            mapper.CompilerConfig.ClassPropertyMapMode = ClassPropertyMapMode.NewObject;

            dynamic u1 = new User();
            u1.Name = "TestUser";
            u1.Int32 = 23;
            u1.MapPoint.Latitude = 32.44m;
            u1.MapPoint.Longitude = 139.22m;

            var u2 = mapper.Map(u1, new User());

            Assert.AreEqual(u1.Name, u2.Name);
            Assert.AreEqual(u1.Int32, u2.Int32);

            Assert.AreEqual(u1.MapPoint.Latitude, u2.MapPoint.Latitude);
            Assert.AreEqual(u1.MapPoint.Longitude, u2.MapPoint.Longitude);
        }
        [TestMethod]
        public void ObjectMapper_Map_IDataReader_Object_With_DictionaryMappingRule()
        {
            var mapper = new ObjectMapper();

            var connectionString = File.ReadAllText("C:\\GitHub\\ConnectionString.txt");
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                var cm = new SqlCommand("select * from sys.databases where name = 'master'", cn);
                cn.Open();
                var dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    var s1 = mapper.Map(dr, new Sys_Database());
                    //May be because we connect to database.
                    Assert.AreEqual("master", s1.Name);
                    Assert.AreEqual(1, s1.Database_ID);
                }
            }
        }

        [TestMethod]
        public void ObjectMapper_Map_List_List()
        {
            var mapper = new ObjectMapper();

            var l1 = new List<User>();
            l1.Capacity = 100;
            l1.Add(new User());
            var l2 = mapper.Map(l1, new List<User>());

            Assert.AreEqual(0, l2.Count);
            Assert.AreEqual(100, l2.Capacity);
        }
        [TestMethod]
        public void ObjectMapper_Map_List_List_ValueType()
        {
            var mapper = new ObjectMapper();

            var l1 = new VectorInfo();
            l1.Vectors.Add(new Vector2() { X = 1, Y = 2 });
            var l2 = mapper.Map(l1, new VectorInfo());

            Assert.AreEqual(1, l2.Vectors[0].X);
        }
        //[TestMethod]
        //public void ObjectMapper_Map_List_NullableList()
        //{
        //    var mapper = new ObjectMapper();
        //    mapper.PropertyMapRules.Clear();

        //    var rule = new PropertyNameMappingRule();
        //    rule.AddPropertyNameMap("Vectors", "NullableVectors");
        //    mapper.PropertyMapRules.Add(rule);

        //    var l1 = new VectorList();
        //    l1.Vectors.Add(new Vector2() { X = 1, Y = 2 });
        //    var l2 = mapper.Map(l1, new VectorList());

        //    Assert.AreEqual(1, l2.NullableVectors[0].Value.X);
        //}
        [TestMethod]
        public void ObjectMapper_Map_List_ReadonlyList()
        {
            var mapper = new ObjectMapper();

            var l1 = new VectorInfo();
            l1.ReadonlyVectors.Add(new Vector2() { X = 1, Y = 2 });
            var l2 = mapper.Map(l1, new VectorInfo());

            Assert.AreEqual(1, l2.ReadonlyVectors[0].X);
        }
        [TestMethod]
        public void ObjectMapper_Map_NullListProperty_NewObject()
        {
            var mapper = new ObjectMapper();
            mapper.CompilerConfig.ClassPropertyMapMode = ClassPropertyMapMode.NewObject;
            var u1 = new User();
            var u2 = new User();
            u2.Users = null;
            mapper.Map(u1, u2);

            Assert.IsNotNull(u2.Users);
        }
        [TestMethod]
        public void ObjectMapper_Map_NullListProperty_DeepCopy_AddElement()
        {
            var mapper = new ObjectMapper();
            mapper.CompilerConfig.ClassPropertyMapMode = ClassPropertyMapMode.DeepCopy;
            var u1 = new User();
            var u2 = new User();
            u2.Users = null;
            mapper.Map(u1, u2);

            Assert.IsNotNull(u2.Users);

            u1.Users.Add(new User("ChildUser1"));
            Assert.AreEqual(1, u2.Users.Count);
            Assert.AreEqual("ChildUser1", u2.Users[0].Name);

            u1.Users[0].Name = "ChildUser2";
            Assert.AreEqual("ChildUser2", u2.Users[0].Name);
        }
        //[TestMethod]
        //public void ObjectMapper_Map_Flatten()
        //{
        //    var mapper = new ObjectMapper();
        //    mapper.AddPostAction<User, UserFlatten>((source, target) =>
        //    {
        //        source.Vector2.Map(target);
        //        source.MapPoint.Map(target);
        //    });
        //    var u1 = new User();
        //    var u2 = mapper.Map(u1, new UserFlatten());

        //    Assert.AreEqual(u1.MapPoint.Latitude, u2.Latitude);
        //    Assert.AreEqual(u1.MapPoint.Longitude, u2.Longitude);
        //    Assert.AreEqual(u1.Vector2.X, u2.X);
        //}
        [TestMethod]
        public void ObjectMapper_Map_SubClass_UserProperty()
        {
            var mapper = new ObjectMapper();
            mapper.CompilerConfig.ClassPropertyMapMode = ClassPropertyMapMode.None;

            var s1 = new Schedule();
            s1.CreateUser = new User("Test1");
            var s2 = mapper.Map(s1, new AllDaySchedule());

            Assert.IsNull(s2.CreateUser);
        }
        [TestMethod]
        public void ObjectMapper_Map_SubClass_ListProperty()
        {
            var mapper = new ObjectMapper();

            var s1 = new Schedule();
            s1.UserList.Add(new User("Test1"));
            var s2 = mapper.Map(s1, new AllDaySchedule());

            Assert.AreEqual(1, s2.UserList.Count);
        }

        //[TestMethod]
        //public void ObjectMapper_AddPostAction_IUser()
        //{
        //    var mapper = new ObjectMapper();
        //    mapper.AddPostAction<User, IUser>((source, target) =>
        //    {
        //        //Do nothing...
        //    });
        //    var u1 = new User();
        //    var u2 = mapper.Map(u1, new User());

        //    Assert.AreEqual(u1.Name, u2.Name);
        //}
        //[TestMethod]
        //public void ObjectMapper_AddPostAction_Enum()
        //{
        //    var mapper = new ObjectMapper();
        //    mapper.AddPostAction<String, DayOfWeek>((source, target) =>
        //    {
        //        return DayOfWeekConverter(source) ?? target;
        //    });

        //    mapper.PropertyMapRules.Clear();
        //    var rule = new PropertyNameMappingRule();
        //    rule.AddPropertyNameMap("Value", "DayOfWeek");
        //    mapper.PropertyMapRules.Add(rule);

        //    var u1 = new User();
        //    u1.Value = "Fri";
        //    var u2 = mapper.Map(u1, new User());

        //    Assert.AreEqual(DayOfWeek.Friday, u2.DayOfWeek);
        //}
        //[TestMethod]
        //public void ObjectMapper_AddPostAction_EnumNullable()
        //{
        //    var mapper = new ObjectMapper();
        //    mapper.AddPostAction<String, DayOfWeek?>((source, target) =>
        //    {
        //        return DayOfWeekConverter(source);
        //    });

        //    mapper.PropertyMapRules.Clear();
        //    var rule = new PropertyNameMappingRule();
        //    rule.AddPropertyNameMap("Value", "DayOfWeekNullable");
        //    mapper.PropertyMapRules.Add(rule);

        //    var u1 = new User();
        //    u1.Value = "Fri";
        //    var u2 = mapper.Map(u1, new User());

        //    Assert.AreEqual(DayOfWeek.Friday, u2.DayOfWeekNullable);
        //}
        //[TestMethod]
        //public void ObjectMapper_AddPostAction_Encoding()
        //{
        //    var mapper = new ObjectMapper();
        //    mapper.AddPostAction<String, Encoding>((source, target) =>
        //    {
        //        if (source == "U8") { return Encoding.UTF8; }
        //        return null;
        //    });

        //    mapper.PropertyMapRules.Clear();
        //    var rule = new PropertyNameMappingRule();
        //    rule.AddPropertyNameMap("Value", "Encoding");
        //    mapper.PropertyMapRules.Add(rule);

        //    var u1 = new User();
        //    u1.Value = "U8";
        //    var p2 = new TextParser();
        //    p2.Encoding = null;
        //    mapper.Map(u1, p2);

        //    Assert.AreEqual(Encoding.UTF8, p2.Encoding);
        //}
        //[TestMethod]
        //public void ObjectMapper_AddPostAction_Collection()
        //{
        //    var mapper = new ObjectMapper();
        //    mapper.AddPostAction<User>((source, target) =>
        //    {
        //        target.Tags = source.Tags.ToArray();
        //    });

        //    var u1 = new User();
        //    u1.Tags = new String[2];
        //    u1.Tags[0] = "News";
        //    u1.Tags[1] = "Sports";
        //    var u2 = mapper.Map(u1, new User());

        //    Assert.AreEqual(u1.Tags[0], u2.Tags[0]);
        //    Assert.AreEqual(u1.Tags[1], u2.Tags[1]);
        //}
        //[TestMethod]
        //public void ObjectMapper_AddPostAction_String_DayOfWeek()
        //{
        //    var mapper = new ObjectMapper();
        //    mapper.AddPostAction<String, DayOfWeek>((source, target) =>
        //    {
        //        return DayOfWeekConverter(source) ?? target;
        //    });

        //    mapper.PropertyMapRules.Clear();
        //    var rule = new PropertyNameMappingRule();
        //    rule.AddPropertyNameMap("Value", "DayOfWeek");
        //    mapper.PropertyMapRules.Add(rule);

        //    var u1 = new User();
        //    u1.Value = "Fri";
        //    var u2 = mapper.Map(u1, new User());

        //    Assert.AreEqual(DayOfWeek.Friday, u2.DayOfWeek);
        //}
        //[TestMethod]
        //public void ObjectMapper_RemovePropertyMap()
        //{
        //    var mapper = new ObjectMapper();
        //    mapper.RemovePropertyMap<User, VipUser>("Timestamp");

        //    var u1 = new User();
        //    u1.Timestamp = new Byte[] { 1, 3, 6 };

        //    var u2 = mapper.Map(u1, new VipUser());

        //    Assert.IsNull(u2.Timestamp);

        //    Assert.AreEqual(u1.MapPoint.Latitude, u2.MapPoint.Latitude);
        //    Assert.AreEqual(u1.MapPoint.Longitude, u2.MapPoint.Longitude);
        //}
        //[TestMethod]
        //public void ObjectMapper_RemoveAllPropertyMap()
        //{
        //    var mapper = new ObjectMapper();
        //    mapper.RemovePropertyMap<User, User>();

        //    var u1 = new User();
        //    u1.Value = "23.456";
        //    var u2 = mapper.Map(u1, new User());

        //    Assert.AreNotEqual(u1.Value, u2.Value);
        //}
        //[TestMethod]
        //public void ObjectMapper_ReplacePropertyMap()
        //{
        //    var mapper = new ObjectMapper();
        //    mapper.ReplacePropertyMap<User, User>((source, target) =>
        //    {
        //        target.Decimal = Decimal.Parse(source.Value);
        //    });

        //    var u1 = new User();
        //    u1.Value = "23.456";
        //    var u2 = mapper.Map(u1, new User());

        //    Assert.AreNotEqual(u1.Value, u2.Value);
        //    Assert.AreEqual(23.456m, u2.Decimal);
        //}

        //[TestMethod]
        //public void ObjectMapper_PropertyNameMappingRule_Failure()
        //{
        //    var mapper = new ObjectMapper();
        //    mapper.PropertyMapRules.Clear();

        //    var rule = new PropertyNameMappingRule();
        //    rule.AddPropertyNameMap("Value", "Decimal");
        //    mapper.PropertyMapRules.Add(rule);

        //    var u1 = new User();
        //    u1.Value = "abc";
        //    var u2 = mapper.Map(u1, new User());
        //    //Not changed...
        //    Assert.AreEqual(20.4m, u2.Decimal);
        //}
        //[TestMethod]
        //public void ObjectMapper_SuffixPropertyMappingRule()
        //{
        //    var mapper = new ObjectMapper();
        //    mapper.PropertyMapRules.Clear();
        //    var rule = new SuffixPropertyMappingRule("Nullable");
        //    mapper.PropertyMapRules.Add(rule);

        //    var u1 = new User();
        //    var u2 = mapper.Map(u1, new User());

        //    Assert.AreEqual(u1.Name, u2.Name);
        //    Assert.AreEqual(u1.Int32, u2.Int32Nullable);
        //    Assert.AreEqual(u1.Decimal, u2.DecimalNullable);
        //    Assert.AreEqual(u1.DateTime, u2.DateTimeNullable);
        //    Assert.AreEqual(u1.DayOfWeek, u2.DayOfWeekNullable);
        //}
        //[TestMethod]
        //public void ObjectMapper_IgnoreUnderscorePropertyMappingRule()
        //{
        //    var mapper = new ObjectMapper();

        //    var rule = new IgnoreUnderscorePropertyMappingRule();
        //    mapper.PropertyMapRules.Add(rule);

        //    var u1 = new User();
        //    u1.Int32Nullable = 3;
        //    var u2 = mapper.Map(u1, new User());

        //    Assert.AreEqual(u1.Int32Nullable, u2.Int32_Nullable);
        //}
        //[TestMethod]
        //public void ObjectMapper_CustomPropertyMappingRule()
        //{
        //    var mapper = new ObjectMapper();
        //    mapper.PropertyMapRules.Clear();
        //    var rule = new PropertyNameMappingRule();
        //    rule.AddPropertyNameMap("Value", "Int32");
        //    rule.AddPropertyNameMap("Value", "DateTime");
        //    rule.AddPropertyNameMap("Value", "Decimal");
        //    rule.AddPropertyNameMap("Value", "DayOfWeek");
        //    mapper.PropertyMapRules.Add(rule);

        //    var u1 = new User();
        //    {
        //        u1.Value = "23";
        //        var u2 = mapper.Map(u1, new User());
        //        Assert.AreEqual(23, u2.Int32);
        //    }
        //    {
        //        u1.Value = "2014/12/17 00:00:00";
        //        var u2 = mapper.Map(u1, new User());
        //        Assert.AreEqual(new DateTime(2014, 12, 17), u2.DateTime);
        //    }
        //    {
        //        u1.Value = "23.4";
        //        var u2 = mapper.Map(u1, new User());
        //        Assert.AreEqual(23.4m, u2.Decimal);
        //    }
        //    {
        //        u1.Value = "Friday";
        //        var u2 = mapper.Map(u1, new User());
        //        Assert.AreEqual(DayOfWeek.Friday, u2.DayOfWeek);
        //    }
        //}
        //[TestMethod]
        //public void ObjectMapper_CustomPropertyMappingRule_AddPostAction()
        //{
        //    var mapper = new ObjectMapper();
        //    mapper.AddPostAction<User>((source, target) =>
        //    {
        //        target.MapPoint = MapPointConverter(source.Value) ?? target.MapPoint;
        //    });
        //    mapper.PropertyMapRules.Clear();
        //    var rule = new PropertyNameMappingRule();
        //    rule.AddPropertyNameMap("Value", "MapPoint");
        //    mapper.PropertyMapRules.Add(rule);

        //    var u1 = new User();
        //    u1.Value = "23, 45";
        //    var u2 = mapper.Map(u1, new User());

        //    Assert.AreEqual(23m, u2.MapPoint.Latitude);
        //    Assert.AreEqual(45m, u2.MapPoint.Longitude);
        //}
        //[TestMethod]
        //public void ObjectMapper_CustomDictionaryMappingRule()
        //{
        //    var mapper = new ObjectMapper();

        //    var rule = new DictionaryKeyMappingRule(DictionaryMappingDirection.DictionaryToObject, typeof(User), TypeFilterCondition.Inherit);
        //    rule.AddMap("Int32Nullable", "int_nullable");
        //    mapper.DictionaryMappingRules.Add(rule);

        //    var d = new Dictionary<String, String>();
        //    d["int_nullable"] = "8";
        //    var u2 = mapper.Map(d, new User());

        //    Assert.AreEqual(8, u2.Int32Nullable);
        //}


        private MapPoint MapPointConverter(Object obj)
        {
            if (obj is String && (String)obj != null)
            {
                var ss = obj.ToString().Split(',');
                if (ss.Length == 2)
                {
                    var p = new MapPoint();
                    p.Latitude = Decimal.Parse(ss[0].Trim());
                    p.Longitude = Decimal.Parse(ss[1].Trim());
                    return p;
                }
            }
            return null;
        }
        private DayOfWeek? DayOfWeekConverter(Object obj)
        {
            DayOfWeek? dw = null;
            if (obj is String && (String)obj != null)
            {
                switch (obj.ToString())
                {
                    case "Mon": dw = DayOfWeek.Monday; break;
                    case "Tues": dw = DayOfWeek.Tuesday; break;
                    case "Wednes": dw = DayOfWeek.Wednesday; break;
                    case "Thurs": dw = DayOfWeek.Thursday; break;
                    case "Fri": dw = DayOfWeek.Friday; break;
                    case "Satur": dw = DayOfWeek.Saturday; break;
                    case "Sun": dw = DayOfWeek.Sunday; break;
                    default: return null;
                }
            }
            return dw;
        }
    }
}

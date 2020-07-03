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
    public class ObjectMapConfigTest
    {
        [TestMethod]
        public void ObjectMapConfig_Map_Object_Object()
        {
            var config = new ObjectMapConfig();
            config.NullPropertyMapMode = NullPropertyMapMode.NewObject;

            var u1 = new User();

            var u2 = config.Map(u1, new User());

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
        public void ObjectMapConfig_Map_ValueType_Object()
        {
            var config = new ObjectMapConfig();

            var v1 = new Vector2(3, 6);
            var u1 = config.Map(v1, new UserFlatten());

            Assert.AreEqual(u1.X, v1.X);
        }
        [TestMethod]
        public void ObjectMapConfig_Map_Object_ValueType()
        {
            var config = new ObjectMapConfig();

            var u1 = new UserFlatten();
            u1.X = 5;
            u1.Y = 7;
            var v1 = config.Map(u1, new Vector2(3, 6));

            Assert.AreEqual(u1.X, v1.X);
            Assert.AreEqual(u1.Y, v1.Y);
        }
        [TestMethod]
        public void ObjectMapConfig_MapOrNull()
        {
            var config = new ObjectMapConfig();

            var u1 = new User();
            User u2 = null;
            var u3 = config.MapOrNull(u1, () => new User() { Int32 = 3 });
            var u4 = config.MapOrNull(u2, () => new User() { Int32 = 3 });

            Assert.AreEqual(u3.Int32, 3);
            Assert.AreEqual(u4, null);
        }
        [TestMethod]
        public void ObjectMapConfig_Map_Object_Object_SetNullablePropertyToNull()
        {
            var config = new ObjectMapConfig();
            
            var u1 = new User();
            u1.DecimalNullable = null;
            var u2 = config.Map(u1, new User() { DecimalNullable = 23.4m });

            Assert.IsNull(u2.DecimalNullable);
        }

        [TestMethod]
        public void ObjectMapConfig_Map_NullProperty_NewObject()
        {
            var config = new ObjectMapConfig();
            config.NullPropertyMapMode = NullPropertyMapMode.NewObject;
            config.MaxCallStackCount = 100;

            var u1 = new User();
            u1.ParentUser = new User("ParentUser");
            u1.Dictionary = new Dictionary<string, string>();
            var u2 = new User();
            u2.ParentUser = null;
            u2.Dictionary = null;
            config.Map(u1, u2);

            Assert.IsNotNull(u2.ParentUser);
            Assert.IsNotNull(u2.Dictionary);

            u1.ParentUser.Name = "ParentUserChanged";
            //Difference object
            Assert.AreEqual("ParentUser", u2.ParentUser.Name);
        }
        [TestMethod]
        public void ObjectMapConfig_Map_NullProperty_DeepCopy()
        {
            var config = new ObjectMapConfig();
            config.NullPropertyMapMode = NullPropertyMapMode.DeepCopy;
            var u1 = new User();
            u1.ParentUser = new User("ParentUser");
            var u2 = new User();
            u2.ParentUser = null;
            config.Map(u1, u2);

            Assert.IsNotNull(u2.ParentUser);

            u1.ParentUser.Name = "ParentUserChanged";
            //Same object
            Assert.AreEqual("ParentUserChanged", u2.ParentUser.Name);
        }

        [TestMethod]
        public void ObjectMapConfig_Map_Dictionary_Object()
        {
            var config = new ObjectMapConfig();

            var d = new Dictionary<String, String>();
            d["Name"] = "N";
            d["Int32"] = "46";
            d["Decimal"] = "46.46";
            d["DateTime"] = "2014/12/17";
            d["DayOfWeek"] = "Friday";
            d["GuidNullable"] = "7195FBEF-B18C-BC29-E339-39DDC81FC90F";
            var u1 = new User();
            u1.Value = "Value1";
            var u2 = config.Map(d, u1);

            Assert.AreEqual("Value1", u2.Value);
            Assert.AreEqual("N", u2.Name);
            Assert.AreEqual(46, u2.Int32);
            Assert.AreEqual(46.46m, u2.Decimal);
            Assert.AreEqual(new DateTime(2014, 12,17), u2.DateTime);
            Assert.AreEqual(DayOfWeek.Friday, u2.DayOfWeek);
            Assert.AreEqual(new Guid("7195FBEF-B18C-BC29-E339-39DDC81FC90F"), u2.GuidNullable);
        }
        [TestMethod]
        public void ObjectMapConfig_Map_Object_Dictionary()
        {
            var config = new ObjectMapConfig();

            var u1 = new User();
            var d = config.Map(u1, new Dictionary<String, Object>());

            Assert.AreEqual(u1.Name, d["Name"]);
            Assert.AreEqual(u1.Int32, d["Int32"]);
            Assert.AreEqual(u1.Decimal, d["Decimal"]);
            Assert.AreEqual(u1.DateTime, d["DateTime"]);
            Assert.AreEqual(u1.DayOfWeek, d["DayOfWeek"]);
            Assert.AreEqual(u1.MapPoint, d["MapPoint"]);
        }
        [TestMethod]
        public void ObjectMapConfig_Map_Dictionary_Object_Convert_Failure()
        {
            var config = new ObjectMapConfig();

            var d = new Dictionary<String, String>();
            d["Decimal"] = "abc";
            var u2 = config.Map(d, new User());
            //Not changed...
            Assert.AreEqual(20.4m, u2.Decimal);
        }
        [TestMethod]
        public void ObjectMapConfig_Map_FromDecimalToInt32()
        {
            var config = new ObjectMapConfig();
            config.PropertyMapRules.Clear();

            var rule = new PropertyNameMappingRule();
            rule.AddPropertyNameMap("Int32", "Decimal");
            config.PropertyMapRules.Add(rule);

            var u1 = new User();
            u1.Int32 = 23;
            var u2 = config.Map(u1, new User());

            Assert.AreEqual(23m, u2.Decimal);
        }
        [TestMethod]
        public void ObjectMapConfig_Map_ByteArrayProperty()
        {
            var config = new ObjectMapConfig();
            config.NullPropertyMapMode = NullPropertyMapMode.NewObject;

            var u1 = new User();
            u1.Timestamp = new Byte[] { 1, 3, 6 };

            var u2 = config.Map(u1, new User());

            Assert.AreEqual(u1.Timestamp[2], u2.Timestamp[2]);
        }

        [TestMethod]
        public void ObjectMapConfig_Map_Dictionary_Encoding()
        {
            var config = new ObjectMapConfig();

            var d = new Dictionary<String, String>();
            d["Encoding"] = "UTF-8";
            var p1 = new TextParser();
            p1.Encoding = Encoding.ASCII;
            var p2 = config.Map(d, p1);

            Assert.AreEqual(Encoding.UTF8, p2.Encoding);
        }
        [TestMethod]
        public void ObjectMapConfig_Map_Dictionary_NullPropertyMapMode_NewObject()
        {
            var config = new ObjectMapConfig();
            config.NullPropertyMapMode = NullPropertyMapMode.NewObject;

            var d = new Dictionary<String, String>();
            d["Int32Nullable"] = "abc";
            var u2 = new User();
            u2.Int32Nullable = null;
            config.Map(d, u2);

            Assert.AreEqual(null, u2.Int32Nullable);
        }
        [TestMethod]
        public void ObjectMapConfig_Map_DynamicObject_Object()
        {
            var config = new ObjectMapConfig();
            config.NullPropertyMapMode = NullPropertyMapMode.NewObject;

            dynamic u1 = new User();
            u1.Name = "TestUser";
            u1.Int32 = 23;
            u1.MapPoint.Latitude = 32.44m;
            u1.MapPoint.Longitude = 139.22m;

            var u2 = config.Map(u1, new User());

            Assert.AreEqual(u1.Name, u2.Name);
            Assert.AreEqual(u1.Int32, u2.Int32);

            Assert.AreEqual(u1.MapPoint.Latitude, u2.MapPoint.Latitude);
            Assert.AreEqual(u1.MapPoint.Longitude, u2.MapPoint.Longitude);
        }
        [TestMethod]
        public void ObjectMapConfig_Map_IDataReader_Object_With_DictionaryMappingRule()
        {
            var config = new ObjectMapConfig();

            var connectionString = File.ReadAllText("C:\\GitHub\\ConnectionString.txt");
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                var cm = new SqlCommand("select * from sys.databases where name = 'master'", cn);
                cn.Open();
                var dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    var s1 = config.Map(dr, new Sys_Database());
                    //May be because we connect to database.
                    Assert.AreEqual("master", s1.Name);
                    Assert.AreEqual(1, s1.Database_ID);
                }
            }
        }

        [TestMethod]
        public void ObjectMapConfig_Map_List_List()
        {
            var config = new ObjectMapConfig();

            var l1 = new List<User>();
            l1.Capacity = 100;
            l1.Add(new User());
            var l2 = config.Map(l1, new List<User>());

            Assert.AreEqual(0, l2.Count);
            Assert.AreEqual(100, l2.Capacity);
        }
        [TestMethod]
        public void ObjectMapConfig_Map_List_List_ValueType()
        {
            var config = new ObjectMapConfig();

            var l1 = new VectorList();
            l1.Vectors.Add(new Vector2() { X = 1, Y = 2 });
            var l2 = config.Map(l1, new VectorList());

            Assert.AreEqual(1, l2.Vectors[0].X);
        }
        [TestMethod]
        public void ObjectMapConfig_Map_List_NullableList()
        {
            var config = new ObjectMapConfig();
            config.PropertyMapRules.Clear();

            var rule = new PropertyNameMappingRule();
            rule.AddPropertyNameMap("Vectors", "NullableVectors");
            config.PropertyMapRules.Add(rule);

            var l1 = new VectorList();
            l1.Vectors.Add(new Vector2() { X = 1, Y = 2 });
            var l2 = config.Map(l1, new VectorList());

            Assert.AreEqual(1, l2.NullableVectors[0].Value.X);
        }
        [TestMethod]
        public void ObjectMapConfig_Map_List_ReadonlyList()
        {
            var config = new ObjectMapConfig();

            var l1 = new VectorList();
            l1.ReadonlyVectors.Add(new Vector2() { X = 1, Y = 2 });
            var l2 = config.Map(l1, new VectorList());

            Assert.AreEqual(1, l2.ReadonlyVectors[0].X);
        }
        [TestMethod]
        public void ObjectMapConfig_Map_ListProperty()
        {
            var config = new ObjectMapConfig();
            config.CollectionElementMapMode = CollectionElementMapMode.None;

            var u1 = new User();
            for (int i = 0; i < 3; i++)
            {
                u1.Users.Add(new User("TestUser" + i.ToString()));
            }
            var u2 = config.Map(u1, new User());

            config.AddPostAction<User, User>((source, target) =>
            {
                if (source == null) { return; }
                target.Users.AddRange(source.Users);
            });
            var u3 = config.Map(u1, new User());

            Assert.AreEqual(0, u2.Users.Count);
            Assert.AreEqual(3, u3.Users.Count);
        }
        [TestMethod]
        public void ObjectMapConfig_Map_CollectionElement_NewObject()
        {
            var config = new ObjectMapConfig();
            config.CollectionElementMapMode = CollectionElementMapMode.NewObject;

            var u1 = new User();
            for (int i = 0; i < 3; i++)
            {
                u1.Users.Add(new User("TestUser" + i.ToString()));
            }
            var u2 = config.Map(u1, new User());
            u1.Users[0].Name = "Test20";

            Assert.AreEqual(3, u2.Users.Count);
            Assert.AreNotEqual("Test20", u2.Users[0].Name);
        }
        [TestMethod]
        public void ObjectMapConfig_Map_CollectionElement_NewObject_NoDefaultConstructor()
        {
            var config = new ObjectMapConfig();
            config.CollectionElementMapMode = CollectionElementMapMode.NewObject;

            var u1 = new List<User>();
            for (int i = 0; i < 3; i++)
            {
                u1.Add(new User("TestUser" + i.ToString()));
            }
            var u2 = config.Map(u1, new List<UserNoDefaultConstructor>());

            Assert.AreEqual(0, u2.Count);
        }
        [TestMethod]
        public void ObjectMapConfig_Map_CollectionElement_Reference()
        {
            var config = new ObjectMapConfig();
            config.CollectionElementMapMode = CollectionElementMapMode.DeepCopy;

            var u1 = new User();
            for (int i = 0; i < 3; i++)
            {
                u1.Users.Add(new User("TestUser" + i.ToString()));
            }
            var u2 = config.Map(u1, new User());
            u1.Users[0].Name = "Test20";

            Assert.AreEqual(3, u2.Users.Count);
            Assert.AreEqual("Test20", u2.Users[0].Name);
        }
        [TestMethod]
        public void ObjectMapConfig_MapCollection_CollectionElement_DeepCopy()
        {
            var config = new ObjectMapConfig();
            config.CollectionElementMapMode = CollectionElementMapMode.DeepCopy;

            var u1 = new VipUserListInfo();
            u1.GroupName = "Group1";
            var u2 = new UserListInfo();
            for (int i = 0; i < 3; i++)
            {
                u1.Users.Add(new VipUser("TestUser" + i.ToString()));
            }
            config.Map(u1, u2);
            u1.Users[0].Name = "Test20";

            Assert.AreEqual(3, u2.Users.Count);
            Assert.AreEqual("Group1", u2.GroupName);
            Assert.AreEqual("Test20", u2.Users[0].Name);
        }
        [TestMethod]
        public void ObjectMapConfig_Map_NullListProperty_NewObject()
        {
            var config = new ObjectMapConfig();
            config.NullPropertyMapMode = NullPropertyMapMode.NewObject;
            var u1 = new User();
            var u2 = new User();
            u2.Users = null;
            config.Map(u1, u2);

            Assert.IsNotNull(u2.Users);
        }
        [TestMethod]
        public void ObjectMapConfig_Map_NullListProperty_DeepCopy_AddElement()
        {
            var config = new ObjectMapConfig();
            config.NullPropertyMapMode = NullPropertyMapMode.DeepCopy;
            var u1 = new User();
            var u2 = new User();
            u2.Users = null;
            config.Map(u1, u2);

            Assert.IsNotNull(u2.Users);

            u1.Users.Add(new User("ChildUser1"));
            Assert.AreEqual(1, u2.Users.Count);
            Assert.AreEqual("ChildUser1", u2.Users[0].Name);

            u1.Users[0].Name = "ChildUser2";
            Assert.AreEqual("ChildUser2", u2.Users[0].Name);
        }
        [TestMethod]
        public void ObjectMapConfig_Map_Flatten()
        {
            var config = new ObjectMapConfig();
            config.AddPostAction<User, UserFlatten>((source, target) =>
            {
                source.Vector2.Map(target);
                source.MapPoint.Map(target);
            });
            var u1 = new User();
            var u2 = config.Map(u1, new UserFlatten());

            Assert.AreEqual(u1.MapPoint.Latitude, u2.Latitude);
            Assert.AreEqual(u1.MapPoint.Longitude, u2.Longitude);
            Assert.AreEqual(u1.Vector2.X, u2.X);
        }
        [TestMethod]
        public void ObjectMapConfig_Map_SubClass_ListProperty()
        {
            var config = new ObjectMapConfig();

            var s1 = new Schedule();
            s1.UserList.Add(new User("Test1"));
            var s2 = config.Map(s1, new AllDaySchedule());

            Assert.AreEqual(1, s2.UserList.Count);
        }

        [TestMethod]
        public void ObjectMapConfig_AddPostAction_IUser()
        {
            var config = new ObjectMapConfig();
            config.AddPostAction<User, IUser>((source, target) =>
            {
                //Do nothing...
            });
            var u1 = new User();
            var u2 = config.Map(u1, new User());

            Assert.AreEqual(u1.Name, u2.Name);
        }
        [TestMethod]
        public void ObjectMapConfig_AddPostAction_Enum()
        {
            var config = new ObjectMapConfig();
            config.AddPostAction<String, DayOfWeek>((source, target) =>
            {
                return DayOfWeekConverter(source) ?? target;
            });

            config.PropertyMapRules.Clear();
            var rule = new PropertyNameMappingRule();
            rule.AddPropertyNameMap("Value", "DayOfWeek");
            config.PropertyMapRules.Add(rule);

            var u1 = new User();
            u1.Value = "Fri";
            var u2 = config.Map(u1, new User());

            Assert.AreEqual(DayOfWeek.Friday, u2.DayOfWeek);
        }
        [TestMethod]
        public void ObjectMapConfig_AddPostAction_EnumNullable()
        {
            var config = new ObjectMapConfig();
            config.AddPostAction<String, DayOfWeek?>((source, target) =>
            {
                return DayOfWeekConverter(source);
            });

            config.PropertyMapRules.Clear();
            var rule = new PropertyNameMappingRule();
            rule.AddPropertyNameMap("Value", "DayOfWeekNullable");
            config.PropertyMapRules.Add(rule);

            var u1 = new User();
            u1.Value = "Fri";
            var u2 = config.Map(u1, new User());

            Assert.AreEqual(DayOfWeek.Friday, u2.DayOfWeekNullable);
        }
        [TestMethod]
        public void ObjectMapConfig_AddPostAction_Encoding()
        {
            var config = new ObjectMapConfig();
            config.AddPostAction<String, Encoding>((source, target) =>
            {
                if (source == "U8") { return Encoding.UTF8; }
                return null;
            });

            config.PropertyMapRules.Clear();
            var rule = new PropertyNameMappingRule();
            rule.AddPropertyNameMap("Value", "Encoding");
            config.PropertyMapRules.Add(rule);

            var u1 = new User();
            u1.Value = "U8";
            var p2 = new TextParser();
            p2.Encoding = null;
            config.Map(u1, p2);

            Assert.AreEqual(Encoding.UTF8, p2.Encoding);
        }
        [TestMethod]
        public void ObjectMapConfig_AddPostAction_Collection()
        {
            var config = new ObjectMapConfig();
            config.AddPostAction<User>((source, target) =>
            {
                target.Tags = source.Tags.ToArray();
            });

            var u1 = new User();
            u1.Tags = new String[2];
            u1.Tags[0] = "News";
            u1.Tags[1] = "Sports";
            var u2 = config.Map(u1, new User());

            Assert.AreEqual(u1.Tags[0], u2.Tags[0]);
            Assert.AreEqual(u1.Tags[1], u2.Tags[1]);
        }
        [TestMethod]
        public void ObjectMapConfig_AddPostAction_String_DayOfWeek()
        {
            var config = new ObjectMapConfig();
            config.AddPostAction<String, DayOfWeek>((source, target) =>
            {
                return DayOfWeekConverter(source) ?? target;
            });

            config.PropertyMapRules.Clear();
            var rule = new PropertyNameMappingRule();
            rule.AddPropertyNameMap("Value", "DayOfWeek");
            config.PropertyMapRules.Add(rule);

            var u1 = new User();
            u1.Value = "Fri";
            var u2 = config.Map(u1, new User());

            Assert.AreEqual(DayOfWeek.Friday, u2.DayOfWeek);
        }
        [TestMethod]
        public void ObjectMapConfig_RemovePropertyMap()
        {
            var config = new ObjectMapConfig();
            config.RemovePropertyMap<User, VipUser>("Timestamp");

            var u1 = new User();
            u1.Timestamp = new Byte[] { 1, 3, 6 };

            var u2 = config.Map(u1, new VipUser());

            Assert.IsNull(u2.Timestamp);

            Assert.AreEqual(u1.MapPoint.Latitude, u2.MapPoint.Latitude);
            Assert.AreEqual(u1.MapPoint.Longitude, u2.MapPoint.Longitude);
        }
        [TestMethod]
        public void ObjectMapConfig_RemoveAllPropertyMap()
        {
            var config = new ObjectMapConfig();
            config.RemovePropertyMap<User, User>();

            var u1 = new User();
            u1.Value = "23.456";
            var u2 = config.Map(u1, new User());

            Assert.AreNotEqual(u1.Value, u2.Value);
        }
        [TestMethod]
        public void ObjectMapConfig_ReplacePropertyMap()
        {
            var config = new ObjectMapConfig();
            config.ReplacePropertyMap<User, User>((source, target) =>
            {
                target.Decimal = Decimal.Parse(source.Value);
            });

            var u1 = new User();
            u1.Value = "23.456";
            var u2 = config.Map(u1, new User());

            Assert.AreNotEqual(u1.Value, u2.Value);
            Assert.AreEqual(23.456m, u2.Decimal);
        }

        [TestMethod]
        public void ObjectMapConfig_PropertyNameMappingRule_Failure()
        {
            var config = new ObjectMapConfig();
            config.PropertyMapRules.Clear();

            var rule = new PropertyNameMappingRule();
            rule.AddPropertyNameMap("Value", "Decimal");
            config.PropertyMapRules.Add(rule);

            var u1 = new User();
            u1.Value = "abc";
            var u2 = config.Map(u1, new User());
            //Not changed...
            Assert.AreEqual(20.4m, u2.Decimal);
        }
        [TestMethod]
        public void ObjectMapConfig_SuffixPropertyMappingRule()
        {
            var config = new ObjectMapConfig();
            config.PropertyMapRules.Clear();
            var rule = new SuffixPropertyMappingRule("Nullable");
            config.PropertyMapRules.Add(rule);

            var u1 = new User();
            var u2 = config.Map(u1, new User());

            Assert.AreEqual(u1.Name, u2.Name);
            Assert.AreEqual(u1.Int32, u2.Int32Nullable);
            Assert.AreEqual(u1.Decimal, u2.DecimalNullable);
            Assert.AreEqual(u1.DateTime, u2.DateTimeNullable);
            Assert.AreEqual(u1.DayOfWeek, u2.DayOfWeekNullable);
        }
        [TestMethod]
        public void ObjectMapConfig_IgnoreUnderscorePropertyMappingRule()
        {
            var config = new ObjectMapConfig();

            var rule = new IgnoreUnderscorePropertyMappingRule();
            config.PropertyMapRules.Add(rule);

            var u1 = new User();
            u1.Int32Nullable = 3;
            var u2 = config.Map(u1, new User());

            Assert.AreEqual(u1.Int32Nullable, u2.Int32_Nullable);
        }
        [TestMethod]
        public void ObjectMapConfig_CustomPropertyMappingRule()
        {
            var config = new ObjectMapConfig();
            config.PropertyMapRules.Clear();
            var rule = new PropertyNameMappingRule();
            rule.AddPropertyNameMap("Value", "Int32");
            rule.AddPropertyNameMap("Value", "DateTime");
            rule.AddPropertyNameMap("Value", "Decimal");
            rule.AddPropertyNameMap("Value", "DayOfWeek");
            config.PropertyMapRules.Add(rule);

            var u1 = new User();
            {
                u1.Value = "23";
                var u2 = config.Map(u1, new User());
                Assert.AreEqual(23, u2.Int32);
            }
            {
                u1.Value = "2014/12/17 00:00:00";
                var u2 = config.Map(u1, new User());
                Assert.AreEqual(new DateTime(2014, 12, 17), u2.DateTime);
            }
            {
                u1.Value = "23.4";
                var u2 = config.Map(u1, new User());
                Assert.AreEqual(23.4m, u2.Decimal);
            }
            {
                u1.Value = "Friday";
                var u2 = config.Map(u1, new User());
                Assert.AreEqual(DayOfWeek.Friday, u2.DayOfWeek);
            }
        }
        [TestMethod]
        public void ObjectMapConfig_CustomPropertyMappingRule_AddPostAction()
        {
            var config = new ObjectMapConfig();
            config.AddPostAction<User>((source, target) =>
            {
                target.MapPoint = MapPointConverter(source.Value) ?? target.MapPoint;
            });
            config.PropertyMapRules.Clear();
            var rule = new PropertyNameMappingRule();
            rule.AddPropertyNameMap("Value", "MapPoint");
            config.PropertyMapRules.Add(rule);

            var u1 = new User();
            u1.Value = "23, 45";
            var u2 = config.Map(u1, new User());

            Assert.AreEqual(23m, u2.MapPoint.Latitude);
            Assert.AreEqual(45m, u2.MapPoint.Longitude);
        }
        [TestMethod]
        public void ObjectMapConfig_CustomDictionaryMappingRule()
        {
            var config = new ObjectMapConfig();

            var rule = new DictionaryKeyMappingRule(DictionaryMappingDirection.DictionaryToObject, typeof(User), TypeFilterCondition.Inherit);
            rule.AddMap("Int32Nullable", "int_nullable");
            config.DictionaryMappingRules.Add(rule);

            var d = new Dictionary<String, String>();
            d["int_nullable"] = "8";
            var u2 = config.Map(d, new User());

            Assert.AreEqual(8, u2.Int32Nullable);
        }

        [TestMethod]
        public void ObjectMapConfig_InfiniteLoop()
        {
            var config = new ObjectMapConfig();
            config.CollectionElementMapMode = CollectionElementMapMode.NewObject;

            var n1 = new TreeNode();
            n1.Nodes = new List<TreeNode>();
            n1.Nodes.Add(n1);
            var n2 = config.Map(n1, new TreeNode());
        }

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

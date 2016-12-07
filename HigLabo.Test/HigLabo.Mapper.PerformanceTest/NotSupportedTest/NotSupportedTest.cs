using FastMapper;
using HigLabo.Core;
using Mapster;
using Nelibur.ObjectMapper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgileObjects;
using BenchmarkDotNet.Attributes;

namespace HigLabo.Mapper.TestNotSupported
{
    public class NotSupportedTest
    {
        public static void HigLaboMapperTest()
        {
            var config = ObjectMapConfig.Current;

            var b1 = new Building();
            var b2 = config.Map(b1, new Building());

            var tn = TreeNode.Create();
            var tn2 = config.Map(tn, new TreeNode());

            var p1 = Park.Create();
            var p2 = config.Map(p1);
        }
        public static void AutoMapperTest()
        {
            AutoMapper.Mapper.Initialize(config =>
            {
                config.CreateMap<Building, Building>();
                config.CreateMap<TreeNode, TreeNode>();
            });

            var b1 = new Building();
            var b2 = AutoMapper.Mapper.Map<Building>(b1);

            var p1 = Park.Create();
            var p2 = AutoMapper.Mapper.Map<Park>(p1);

            return;

            //StackOverflowException thrown
            var tn = TreeNode.Create();
            var tn2 = AutoMapper.Mapper.Map<TreeNode>(tn);
        }
        public static void TinyMapperTest()
        {
            TinyMapper.Bind<Park, Park>();

            var b1 = new Building();
            var b2 = TinyMapper.Map<Building>(b1);

            var p1 = Park.Create();
            var p2 = TinyMapper.Map<Park>(p1);//p2.Cars.Count = 0 is unexpected.Collection element does not copied to property with private setter.

            var d = new Dictionary<String, String>();
            d["Name"] = "B1";
            var b3 = TinyMapper.Map<Building>(d);//Does not map...

            return;

            //StackOverflowException thrown
            TinyMapper.Bind<TreeNode, TreeNode>();
            TinyMapper.Bind<TreeNode, TreeNodeTarget>();

            var tn = TreeNode.Create();
            var tn2 = TinyMapper.Map<TreeNode>(tn);
        }
        public static void MapsterTest()
        {
            var p1 = Park.Create();
            var p2 = Mapster.TypeAdapter.Adapt<Park>(p1);//p2.Cars.Count = 0 is unexpected.Collection element does not copied to property with private setter.

            var d = new Dictionary<String, String>();
            d["Name"] = "B1";
            var b3 = Mapster.TypeAdapter.Adapt<Building>(d);//Does not map...

            return;

            //StackOverflowException thrown
            var tn = TreeNode.Create();
            var tn2 = Mapster.TypeAdapter.Adapt<TreeNode>(tn);
        }
        public static void ExpressMapperTest()
        {
            var p1 = Park.Create();
            var p2 = ExpressMapper.Mapper.Map<Park, Park>(p1);//p2.Cars.Count = 0 is unexpected.Collection element does not copied to property with private setter.

            var c1 = Car.Create();
            var c2 = ExpressMapper.Mapper.Map<Car, Car>(c1);//Exception!

            var d = new Dictionary<String, String>();
            d["Name"] = "B1";
            var b3 = ExpressMapper.Mapper.Map<Dictionary<String, String>, Building>(d);//Does not map...

            return;

            var tn = TreeNode.Create();
            var tn2 = ExpressMapper.Mapper.Map<TreeNode, TreeNode>(tn);//tn2.Nodes.Count = 0.
        }
        public static void FastMapperTest()
        {
            var p1 = Park.Create();
            var p2 = TinyMapper.Map<Park>(p1);//p2.Cars.Count = 0 is unexpected.Collection element does not copied to property with private setter.

            var c1 = Car.Create();
            var c2 = FastMapper.TypeAdapter.Adapt<Car, Car>(c1);//Exception!

            var d = new Dictionary<String, String>();
            d["Name"] = "B1";
            var b3 = FastMapper.TypeAdapter.Adapt<Building>(d);//Does not map...

            return;

            //StackOverflowException thrown
            var tn = TreeNode.Create();
            var tn2 = FastMapper.TypeAdapter.Adapt<TreeNode>(tn);//tn2.Nodes.Count = 0.
        }
        public static void AgileMapperTest()
        {
            var p1 = Park.Create();
            var p2 = AgileObjects.AgileMapper.Mapper.Map<Park>(p1).ToANew<Park>();//p2.Cars.Count = 0 is unexpected.Collection element does not copied to property with private setter.

            var d = new Dictionary<String, String>();
            d["Name"] = "B1";
            var b3 = AgileObjects.AgileMapper.Mapper.Map<Dictionary<String, String>>(d).ToANew<Building>();//Does not map...

            return;
            //StackOverflowException thrown
            var tn = TreeNode.Create();
            var tn2 = AgileObjects.AgileMapper.Mapper.Map<TreeNode>(tn).ToANew<TreeNode>();//Does not map...
        }
    }

    public class TreeNode
    {
        public String Name { get; set; } = "Node1";
        public List<TreeNode> Nodes { get; set; }

        public TreeNode()
        {
            this.Nodes = new List<TreeNode>();
        }
        public static TreeNode Create()
        {
            var tn = new TreeNode();
            tn.Nodes.Add(new TreeNode());
            tn.Nodes[0].Nodes.Add(tn);
            return tn;
        }
    }
    public class TreeNodeTarget
    {
        public String Name { get; set; } = "Node2";
        public List<TreeNodeTarget> Nodes { get; private set; }

        public TreeNodeTarget()
        {
            this.Nodes = new List<TreeNodeTarget>();
        }
    }
    public class Building
    {
        public String Name { get; set; }

        public Park Park { get; set; }

        public Building()
        {
            this.Name = "Building123";
            this.Park = Park.Create();
        }
    }

    public class Park
    {
        public List<Car> Cars { get; private set; }

        public Park()
        {
            this.Cars = new List<Car>();
        }

        public static Park Create()
        {
            var p1 = new Park();
            var c1 = new Car();
            c1.Vector = new Vector2(2, 3);
            p1.Cars.Add(c1);
            return p1;
        }
    }
    public class ParkTarget
    {
        public Car[] Cars { get; set; }

        public ParkTarget()
        {
        }
    }
    public class Car
    {
        public String Name { get; set; } = "Toyota";
        public Vector2 Vector { get; set; }

        public static Car Create()
        {
            var c1 = new Car();
            c1.Vector = new Vector2(2, 3);
            return c1;
        }
    }
    public struct Vector2
    {
        public Int32 X { get; set; }
        public Int32 Y { get; set; }

        public Vector2(Int32 x, Int32 y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}

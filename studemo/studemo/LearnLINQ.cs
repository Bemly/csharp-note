using System;
using System.Linq;
using System.Xml.Linq;
using static System.Console;

namespace studemo;

class Other {
    public static int age = 18;
}
public class LearnLINQ {
    public static void learn() {
        // LINQ 语言集成查询 language integrated query
        int[] nums = { 1, 2, 13, 4, 15, 6, 30 };
        var lowNums = from num in nums
            where num < 10
            select num;
        foreach (var x in lowNums) WriteLine(x);
        
        // LINQ2XML LINQ2Objects BLINQ LINQ2SQL LINQ2Datasets LINQ2Entities
        // 匿名类型 anonymous type 只能局部变量 类成员不行 必须使用var没有类型 属性是只读的
        var student = new { name = "z3", age = 19, major = "cs" };
        WriteLine("{0} {1} {2}",student.name,student.age.ToString(),student.major);
        // 除了类似对象初始化语句 还支持 投影初始化语句
        var i = 1;
        var s = new { Other.age, i, Age = i };
        WriteLine("{0} {1}",s.Age.ToString(),(s.age == s.i).ToString());
        
        // 查询语法query syntax 声明式 declarative
        // 方法语法method syntax 命令式 imperative
        var numsQuery = from num in nums
            where num < 10
            select num;  //Query
        var numsMethod = nums.Where(N => N < 20); // Method
        var numsCount = (from num in nums
            where num < 10
            select num).Count(); // Q+M
        WriteLine(numsCount);
        
        // 匿名对象 可以创建数组
        var stuArr = new[] {
            new { name = "z3", age = 18 },
            new { name = "l4", age = 17 },
            new { name = "w5", age = 19 },
            new { name = "q6", age = 20 }
        };
        var idArr = new[] {
            new { name = "z3", id = 2 },
            new { name = "l4", id = 3 },
            new { name = "w5", id = 4 },
            new { name = "q5", id = 4 }
        };

        // LINQ返回两种类型 枚举集合 标量scalar
        // Query from/select...group必须 select必最后
        // from...let...where where条件 let赋值(计算体表达式)
        // from 变量类型(可省) 迭代变量 in 可枚举的集合
        // LINQ join => SQL JOIN子句 联结
        // orderby 排序
        var q1 = from v in stuArr select v;
        foreach (var v in q1) WriteLine($"q1 : {v}");
        var q2 = from v in stuArr select v.age;
        foreach (var v in q2) WriteLine($"q2 : {v.ToString()}");
        var q3 = from v in stuArr
            select new { v.name, age = v.age -1 };
        var q4 = from v in stuArr
            let x = v.age + -10
            select v with { age = x };
        foreach (var v in q3) WriteLine($"q3 : {v}");
        foreach (var v in q4) WriteLine($"q4 : {v}");
        var q5 = from v in stuArr
            orderby v.age select v;
        foreach (var v in q5) WriteLine($"q5 : {v}");
        var q6 = from _student in q5
            join _id in idArr on _student.name equals _id.name
            let ageSum = _id.id + _student.age
            where ageSum >= 0
            where _student.age > 0 && _id.id > 0
            where _student.age == 18
            select _id.id;
        foreach (var v in q6) WriteLine($"q6 : {v.ToString()}");
        
        // group...by 可选 设组 写了不用select
        // select...group 可选 选组
        var q7 = from v in stuArr group v by v.age;
        foreach (var v in q7) WriteLine($"q7 : {v}");
        foreach (var v in q7) WriteLine($"q7 : {v.Key.ToString()}");
        
        // into 查询延续
        var q8 = from _student in q5
            join _id in idArr on _student.name equals _id.name
                into _studentAND_id
            from _and in _studentAND_id // 交集效果
            // let ageSum = _id.id + _student.age
            // where ageSum >= 0
            // where _student.age > 0 && _id.id > 0
            // 延续之后前面的变量访问不了
            select _and;
        foreach (var v in q8) WriteLine($"q8 : {v}");
        
        // 被查询的可枚举集合 称为 序列
        // Sum 求和 Count 计数 Take 取前count个对象 Skip 跳过前count个对象
        // ... 自己查 Union 并集 Intersect 交集 ToLookup 作为Lookup<TKey, TValue>返回
        // Reverse 反转 ThenBy == OrderBy 排序 Concat 连接两个序列
        
        // System.Linq.Enumerable 的实现有大量的**扩展方法**
        // public static IEnumerable<T> Where<T>( this IEnumerable<T> source, ... );
        // this 扩展指示器 不是拓tuo展是扩kuo展 类似修饰器
        
        // 将委托作为参数 命令式参数里面这个其实就是lambda表达式 根本就是委托的匿名方法
        var numsMethod2 = nums.Where(N => N < 20);
        var nMed = nums.Where(delegate(int N) {
            return N < 20;
        }); // 是不是有一种js的匿名函数的美感了/JAVA的监听传过去的匿名内部类的美感了（（（
        var nMed2 = nums.Count(N => N < 20);
        // .NET预定义了两套泛型委托 Func和Action 各有19个成员
        
        // XML 可扩展标记语言 但是不如JSON（逃
        // LINQ2XML简化了XML的操作 有种我的世界纯用JSON写GUI的美感（（
        // LINQ2XML 用起来比 XPath XSLT等方法简单很多
        // 标记语言: markup language 文档中的一组标签
        // 标记标签不是文档的数据 而是数据的数据 有关数据的数据叫作 元数据
        // XML => HTML 超文本处理语言

        var linq2Xml = new XDocument(
            new XDeclaration("1.0", "GBK", "yes"),  // 声明语句不会在WriteLine里面输出
            new XComment("哈哈 我也可以在这里"),
            new XProcessingInstruction("xml-stylesheet", @"href=""stories.css"", type=""text/css"""),
            new XElement(
                new XElement("地图", // 用户自定义自动转型/转换
                    new XElement("坐标",new XElement("X","128"),new XElement("Y","-59")),
                    new XElement("坐标",new XElement("X","-128"),new XElement("Y","59"))
                    )
                ) // XDocument XML文档下面只有一个 XElement 根元素
            );
        linq2Xml.Save("learnLinq2xmlAPI.xml");
        var xml2Linq = XDocument.Load("learnLinq2xmlAPI.xml"); // 静态方法
        WriteLine(xml2Linq);

        // 如果报错就是字符串啥的玄学问题 直接改成英文（
        var rt = linq2Xml.Element("地图"); //获取第一个元素(不会递归到深层
        rt.Add(new XElement("坐标"));
        WriteLine("===============");
        WriteLine(rt);
        WriteLine("===============");
        WriteLine(linq2Xml);
        // 这只是一个引用 所以元素改变了 根也会改变
        var rt2 = linq2Xml.Element("X");
        if (rt2 == null) {
            WriteLine("没找到");
        } else {
            rt2.Add(new XComment("这是注释"));
        }
        rt.Add(new XElement("a", new XComment("这是注释")));
        WriteLine("===============");
        WriteLine(linq2Xml);
        WriteLine("===============");
        
        // LINQ查询XML
        var xyz = from v in rt.Elements() select v;
        foreach (var v in xyz) WriteLine(v);
        // 还有XAttribute属性这些 然后用Attribute("转换")查询 用匿名方法格式化一下就能用了
        // 还是json好啊（反复强调
    }
}
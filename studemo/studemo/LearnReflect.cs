#define A
using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using static System.Console;

namespace studemo;

class BaseClass {
    public int BaseField = 0;
}

class DerivedClass : BaseClass {
    public int DerivedField = 0;
}

public class LearnReflect {
    public static void learn() {
        // 反射: 查看其他程序集和自身的元数据
        // 元数据: 有关程序及其类型的数据
        
        // BCL 声明了一个叫作 Type 的抽象类
        Type t = typeof(DerivedClass);
        WriteLine(t.Name);
        T2.print("Hello");
        // T2.printOld("HH");
        //  LearnReflect.cs(24, 9): [CS0619] “T2.printOld(string)”已过时:“这个方法过时了”
        
        T2.doSomething("能看见我");
        T2.doSomething2("看不见我");        // 跳过了方法调用。编译器将不生成方法调用，因为该方法为条件方法，或者它是没有实现的分部方法。
        
        // 调用者信息特性 => 带有调用方信息的形参必须具有默认值
        static void msg([CallerFilePath] string path = "", [CallerLineNumber] int line = 0,
            [CallerMemberName] string name = "") {
            WriteLine(path);
            WriteLine(line);
            WriteLine(name);
        }
        msg();
        
        //DebuggerStepThrough 特性 跳过一些代码不进入调试环境
        
        T2.demo();
        
        // 自定义特性 特性派生自System.Attribute
        var a1 = new MyAttribute("Bemly_", "Version 1.1");
        var a2 = new MySubAttribute("Bemly_", "Version 1.2");
        var a3 = new MySubAttribute("Bemly_", "Version 1.3"){ ver = "Version 1.5", desc = "Bemly_" };
        
        /////////////////////////////////////////////////////////////////////////////////////////
        
        // 访问特性 我 被 我 派 生 类 应 用 特 性 了  我 还 应 用 我 自 己
        var isDefined = a1.GetType();
        WriteLine(isDefined.IsDefined(typeof(MyAttribute), false));
        WriteLine(isDefined.IsDefined(typeof(MySubAttribute), false));
        var T = a3.GetType().GetCustomAttributes();
        foreach (var v in T) WriteLine(v);
        foreach (var v in T) WriteLine(v.IsDefaultAttribute());
        WriteLine("===================");
        
        var T0 = a3.GetType().GetCustomAttributes( false );
        foreach (var v in T0) {
            var attr = v as MySubAttribute; // 这里是直接创建一个新的实例 而不是直接引用 所以激活了构造函数输出
            if (null != attr) {     // 反着写 高技术力（bushi
                WriteLine(attr.desc);
                WriteLine(attr.ver);
            }
        }
    }
}

/////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////////

// 特性 attribute 应用了特性的程序结构programConstruct叫作 目标Target
// [] 应用特性 应用后这个结构称为 被特性装饰 decorated/adorned
[Serializable] // 序列化
public class T1 {}
// 带参特性
[AttributeUsage(AttributeTargets.All)] //声明目标能用于什么类型程序结构，特性可一起写
public class T2 : Attribute {
    [Obsolete("这个方法不再受维护了")]
    public static void print(string s) => WriteLine(s);
    [Obsolete("这个方法过时了", true)]
    public static void printOld(string s) => WriteLine(s);
    
    [Conditional("A")] // 就相当于#if A define没有true就无法运行
    public static void doSomething(string s) => WriteLine(s);
    [Conditional("B")]
    public static void doSomething2(string s) => WriteLine(s);
    
    // [Obsolete("1"), Obsolete("2")] 特性不允许重复
    [method: Obsolete("1"), Conditional("B")]
    [assembly: AssemblyCopyright("bemly_")] // 'assembly' 不是此声明的有效特性位置。将忽略此块中的所有特性。
    // 支持逗号分隔和多层结构 Assembly需要在程序集/命名空间外面声明应用才行
    public static void demo() => WriteLine("看看我啊看看我");
}

/////////////////////////////////////////////////////////////////////////////////////////

// 自定义特性 名字后缀必须是Attribute 引用的时候不加Attribute
//[My()]和[My]等价
[My("Bemly_", "Version 1.3")]
[MySub("Bemly_", "Version 1.3", ver="Bemly_", desc="Version 1.3")]
public class MyAttribute : System.Attribute {
    // 特性类的公有成员只有 字段 属性 构造函数
    private string desc, ver;

    public MyAttribute(string desc, string ver) {
        this.desc = desc;
        this.ver = ver;
        WriteLine(desc + ver);
    }
}

// ReSharper disable once StringLiteralTypo
// 支持类似的参数初始化
// [AttributeUsage(AttributeTargets.All)] // 可以用这个限制特性使用
[My("Bemly_", "Version 1.3")]
[MySub("Bemly_", "Version 1.3", ver="Bemly_", desc="Version 1.3")]
public sealed class MySubAttribute : MyAttribute {
    public string desc, ver;

    public MySubAttribute(string desc, string ver) : base(desc, ver) {}
}
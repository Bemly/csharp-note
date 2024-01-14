using System;
using System.Diagnostics.CodeAnalysis;
using static System.Console;
namespace studemo; 

[SuppressMessage("ReSharper", "SpecifyACultureInStringConversionExplicitly")]
public class LearnExpression {
    public static void learn() {
        // 表达式 字面量 
        // 整数字面量
        var i1 = 246L;
        var i2 = 246UL;
        var i3 = 236U;
        // 实数字面量
        var i4 = 234F;
        var i5 = 394D;
        var i6 = .765;
        var i7 = .69M; // Decimal
        // 字符字面量
        var i8 = '\u005a'; //16
        var i9 = '\x0061'; //Unicode
        // 字符串字面量
        var i10 =  $"看得见我吗{ i8 } \n\t \"{ i9 }\" "; // 常规略 $可以塞变量 @表示逐字字面量
        var i11 =  @"看得见我吗{ i8 } \n\t ""{ i9 }"" ";
        var i12 = @$"看得见我吗{ i8 } \n\t ""{ i9 }"" "; //自动解析制表符
        var i13 = $@"看得见我吗{ i8 } \n\t ""{ i9 }"" "; //顺序不重要
        WriteLine($"{i1.ToString()} type: {i1.GetType()}\n" +
                  $"{i2.ToString()} type: {i2.GetType()}\n" +
                  $"{i3.ToString()} type: {i3.GetType()}\n" +
                  $"{i4.ToString()} type: {i4.GetType()}\n" +
                  $"{i5.ToString()} type: {i5.GetType()}\n" +
                  $"{i6.ToString()} type: {i6.GetType()}\n" +
                  $"{i7.ToString()} type: {i7.GetType()}\n" +
                  $"{i8.ToString()} type: {i8.GetType()}\n" +
                  $"{i9.ToString()} type: {i9.GetType()}\n" +
                  $"{i10}\n{i11}\n{i12}\n{i13}");
        
        // 运算符 短路 像这种静态语言不能用语句嵌套三元的意义不是很大 其他语言同理 略
        // unchecked checked typeof new 也算 运算符
        // 逻辑运算符 & 位与 | 位或 ^ 位异或 ~ 位非(取反 和JAVA的-一致)

        /////////////////////////////////////////////////////////////////////////////////////////
        
        // 用户自定义 类型转换 必须公共然后静态
        // 隐式转换 自动的 implicit    显式转换 使用显式转换运算符 explicit
        LimitedInt li = 500;
        int value = li;
        LimitedInt value2 = value;
        WriteLine($"li: { li.TheValue.ToString() }, value: { value.ToString() }, value2: { value2.TheValue.ToString() }");

        ExmitedInt li2 = (ExmitedInt)23;
        int value3 = (int)li2;
        WriteLine($"li2: { li2.TheValue.ToString() }, value3: { value3.ToString() }");
        // 类似还可以 一方自动 一方强制 实现上下转型
        
        /////////////////////////////////////////////////////////////////////////////////////////
        
        // 运算符重载 和类型转换类似 必须公共然后静态
        LimitedInt l1 = 29;
        LimitedInt l2 = 38;
        WriteLine((l1 + l2).TheValue);
        WriteLine((l1 - l2).TheValue);
        WriteLine((l2 - l1).TheValue);
        WriteLine((-l1).TheValue);
        // 运算符重载不能创建新运算符，不能改变语法，不能改变优先级
        // 重载运算符 支持 ++ -- 自增自减和一二元
        // ++ --前后如果是自定义的引用类型 前置没问题
        // 后置保存的副本是引用的副本！！
        
        // typeof 不能被重载 返回System.Type对象(静态类或实例)
        var t = typeof(LimitedInt);
        // ReSharper disable once PossibleMistakenCallToGetType.2
        WriteLine(t.GetType().ToString());     // GetType() 调用可能错误
        WriteLine(t);
        WriteLine($"{t.IsPublic.ToString()} {t.IsByRef.ToString()}");
        foreach (var f in t.GetFields()) WriteLine($" Field 字段 : { f.Name } ");
        foreach (var f in t.GetMethods()) WriteLine($" Method 方法 : { f.Name }");
        foreach (var f in t.GetProperties()) WriteLine($" Property 属性 : { f.Name }");
        foreach (var f in t.GetMembers()) WriteLine($" Member 数据+函数成员 : { f.Name }");
        foreach (var f in t.GetConstructors()) WriteLine($" Constructor 构造函数 : { f.Name }");
        
        // nameof 运算符 返回传入的字符串 没啥用 一般拿来方便之后改代码可以用这个
        
        /////////////////////////////////////////////////////////////////////////////////////////
        
        // 语句: 没啥大改变 for初始化和迭代语句 可以跟多表达式和多声明 没啥问题在表达式里面塞完整个判断都行（
        // 块可以嵌套 标签语句  标签一般拿来goto的      throw也算跳转语句 do=until
        // switch: goto不能和非常量switch一起用 case后面的<>: 也算标签哦 所以这个标签可以塞const这些常量(>C#7.0)
        
        // 标签语句和JavaScript的块关键字一致 Identifier: Statement 标签只允许在块内
        // 标签的作用域 外部不可见 块的作用范围和类相似 和函数成员 局部成员的关系相似
        
        // Goto会弱化结构化 不要使用
        var num = 1;
        {
            Good:
            WriteLine(num++);
            if (num < 100) goto Good;
        }
        WriteLine(num); // num能够访问并修改
        
        // 资源是指实现了System.IDisposable接口的类或者结构
        // 分配资源 => 使用资源 => 处置资源(使用时异常Dispose不被调用)
        // Using语句和Using指令不同 using ( ResourceType Identifier = Expression ) Statement
        // Using try在{}中 finally处置资源由Using帮你弄好了
        using (System.IO.TextWriter tw = System.IO.File.CreateText("UsingDEMO.md")) {
            // debug 默认输出在编译好的bin文件夹下面
            tw.WriteLine("：世界上最惨的猫是哪只猫？");
            tw.WriteLine("：薛定锷的猫");
            tw.WriteLine("：完全不好笑诶");
        }
        using (System.IO.TextReader tr = System.IO.File.OpenText("UsingDEMO.md")) {
            string outputStr;
            while (null != (outputStr = tr.ReadLine())) WriteLine(outputStr);
        }
        // using 支持多语句和嵌套 当然嵌套还是要考虑进程滴
        using (System.IO.TextWriter tw = System.IO.File.CreateText("UsingDEMO2.md")) {
            // debug 默认输出在编译好的bin文件夹下面
            tw.WriteLine("：世界上最惨的猫是哪只猫？");
            tw.WriteLine("：薛定锷的猫");
            tw.WriteLine("：完全不好笑诶");
            try {
                using (System.IO.TextReader tr = System.IO.File.OpenText("UsingDEMO2.md")) {
                    string outputStr;
                    while (null != (outputStr = tr.ReadLine())) WriteLine(outputStr);
                }
            }
            catch (Exception e) {
                WriteLine(e);
            }
        }
        // 资源声明可以在using之前，但是不推荐，因为会导致状态不一致
        
    }
    
    /////////////////////////////////////////////////////////////////////////////////////////
    
    class LimitedInt {
        private const int MaxValue = 100;
        private const int MinValue = 0;
        
        private int _theValue;
        public int TheValue {
            get => _theValue;
            private set => _theValue = value < MinValue ? 0 : value > MaxValue ? MaxValue : value;
        }

        // 用户自定义类型转换 this=>int
        public static implicit operator Int32(LimitedInt li) => li.TheValue;

        // 用户自定义类型转换 int=>this
        public static implicit operator LimitedInt(int x) => new() { TheValue = x };

        // 运算符重载 负数
        public static LimitedInt operator -(LimitedInt x) => new() { TheValue = -x.TheValue };

        // 运算符重载 加法
        public static LimitedInt operator +(LimitedInt x, LimitedInt y) => new() { TheValue = x.TheValue + y.TheValue };

        // 运算符重载 减法
        public static LimitedInt operator -(LimitedInt x, LimitedInt y) => new() { TheValue = x.TheValue - y.TheValue};
    }
    
    /////////////////////////////////////////////////////////////////////////////////////////
    
    class ExmitedInt {
        private const int MaxValue = 100;
        private const int MinValue = 0;
        
        private int _theValue;
        public int TheValue {
            get => _theValue;
            private set => _theValue = value < MinValue ? 0 : value > MaxValue ? MaxValue : value;
        }

        public static explicit operator Int32(ExmitedInt li) {
            return li.TheValue;
        }

        public static explicit operator ExmitedInt(int x) {
            ExmitedInt li = new ExmitedInt();
            li.TheValue = x;
            return li;
        }
    }
    
    /////////////////////////////////////////////////////////////////////////////////////////

}
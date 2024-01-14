namespace studemo; 

/// <summary>
///  这里是写代码信息的地方 详细标签查文档 
/// </summary>

public class LearnOtherTheme {
    public static void learn(string[] args) {
        // 和JAVA一致的StringBuilder 可变字符串
        // .Parse 解析为数据值
        
        // 声明可空变量
        int? n = 1;
        int? x = null;
        
        // 空接合运算符 只对null空的生效
        System.Console.WriteLine(n ?? -1);
        System.Console.WriteLine(x ?? -1);
        // 空条件运算符 只对不为null空的生效
        System.Console.WriteLine(n?.GetHashCode().ToString());
        System.Console.WriteLine(x?.GetHashCode().ToString());

        // 可空用户自定义类型 两者等价
        System.Nullable<MyStruct> mSNull = new MyStruct();
        MyStruct? msNull = new MyStruct();
        
        // C#程序入口点 Main 如果Main是private只有执行环境才能启动 其他程序集不能启动
        foreach (var v in args) System.Console.WriteLine(v);
        
        // 文档注释/// XML的使用
        // 目前新开发（？）的一个sandcastle文档编译器 用来生成.NET框架的文档
        
        // 嵌套类 可见性：属于成员访问级别 而不是类型访问级别
        
        // 终结器finalizer 就是 析构函数destructor 是老称呼 不能在代码显式调用析构函数
        // 只用于实例回收 和类名相同 但是要在前面加上~ 然后析构函数默认执行dispose模式
        
        // Tuple 元组 / ValueTuple
        // 前者成员是属性 后者是字段
        new System.Tuple<int, int, int>(1, 2, 3);
        System.Tuple.Create(1, 2, 3, 4);
    }
    struct MyStruct {}
    ~LearnOtherTheme() {}
}
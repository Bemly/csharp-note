using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace studemo; 

public class LearnNewContent {
    public static void learn() {
        // 1.$ 字符串插值
        // 2.自动属性初始化
        System.Console.WriteLine(new LearnNewContent().Length);
        // 3.只读自动属性 属性如果想要private setter 直接public getter 不写set访问器就行
        // 4.表达式主体/函数体成员 不能和访问器一起用 "=>"
        // 5.using static 把静态引入
        // 6.空条件运算符 之前的?.Invoke() 前面用来防止空委托出现
        int[] arr = null;
        int? a = arr?.Length;
        // arr = new int[]{ 1, 3, 5 };
        // int? b = arr?[10];       // X 只能判断是否为空 无法判断是否溢出下标/索引
        int? b = arr?[10];
        // 7.在catch/finally 上引入 await
        // 9.nameof
        //10.when异常过滤器
        //11.索引初始化
        var favCity = new Dictionary<int, string>();
        favCity.Add(0, "Baijing");
        favCity.Add(1, "Nanjing");
        favCity.Add(2, "Sichuan");
        var favNewCity = new Dictionary<int, string> {
            { 0, favCity[0] },
            { 1, favCity[1] },
            { 2, favCity[2] }
        };
        // 如果有索引器
        var favCity2 = new Dictionary<int, string>();
        favCity2[0] = favCity[0];
        favCity2[1] = favCity[1];
        favCity2[2] = favCity[2];
        var favNewCity2 = new Dictionary<int, string> {
            [0] = favCity[0],
            [1] = favCity[1],
            [2] = favCity[2],
            [2] = favCity2[2] // 重复会覆盖掉前面的
        };
        //12.集合初始化的扩展方法
        var c1 = new Customer("1");
        var c2 = new Customer("2");
        var cs = new Subscriptions { c1, c2 };
        // 这个c1 c2 加进去就是Add方法
        foreach (var c in cs) System.Console.WriteLine(c.Name);
        //13.改进的重载决策 优先选择Func<Task>()而不是Action
        static Task DoThing() => Task.FromResult(0);
        Task.Run(DoThing);
        //14.值元组 元组是个有序元素集合
        //15.is/as
        //16.switch 模式匹配 when过滤Contains也适用 可以赋值给第二个标识符
        //17.自定义析构函数 => 拆箱 用out参数实现Deconstruct功能方法即可
        // Todo: it still cant work.
        // (double b) = new MyDeconstruct(.30);
        // System.Console.WriteLine();
        // 也可以用扩展方法的析构函数
        //18.二进制字面量 数字分隔符
        //19.out变量
        //20.局部函数
        //21。ref变量和返回
        //22.表达式函数体扩展
        //23.throw表达式
        //24.扩展async返回类型
    }
    
    private static readonly double N = .354;
    public double Length { get; set; } = N + .356;
    
    // public class MyDeconstruct {
    //     public double A { get; set; } = .435;
    //     public MyDeconstruct(double B) => A = B;
    //     public void Deconstruct(out double B) => B = A;
    // }
}

public static class SubscriptionExtensions {
    public static void Add(this Subscriptions s, Customer c) => s.Subscribe(c);
}

public class Customer {
    public string Name { set; get; }
    public Customer(string name) => Name = name;
}

public class Subscriptions : IEnumerable<Customer> {
    private List<Customer> mSubscribers = new ();
    public IEnumerator<Customer> GetEnumerator() => mSubscribers.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => throw new System.NotImplementedException();
    public void Subscribe(Customer c) => mSubscribers.Add(c);
}



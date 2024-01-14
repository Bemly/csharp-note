using System.Configuration;
using static System.Console;

namespace studemo; 

public class LearnStruct {
    struct MyStruct {
        public int x = 5;  // 不允许初始化时赋值/定义
        public int y = 6;
        public int X => 2;

        // 可以隐式调用
        // public MyStruct() {
        //     x = y = 1;
        // }

        public MyStruct(int x = 1, int y = 5) {
            this.x = x;
            this.y = y;
        }
    }

    struct MyStructt {
        public int x;
        public int y;

        // 可以隐式调用
        public MyStructt() {
            x = y = 1;
        }

        public MyStructt(int x = 1, int y = 5) {
            this.x = x;
            this.y = y;
        }
    }
    
    struct MyStruct2 {
        private int x;
        private int y;
        public static string Property => "结构体内的静态计算属性";
        public static string field = "结构体内的静态字段";
        public string Property2 => "结构实例内的计算属性";
        // public string field2 = "结构实例内的字段";
        //   LearnStruct.cs(36, 12): [CS8983] 具有字段初始值设定项的“结构”必须包含显式声明的构造函数。
        // 如果没有初始化就不用写显式的默认 构造函数(非静态 ，因为静态可以初始化)

    }
    
    struct MyStruct3 {
        public int x = 8;
        public static string Property => "结构体内的静态计算属性";
        public static string field = "结构体内的静态字段";
        public string Property2 => "结构实例内的计算属性";
        public string field2 = "结构实例内的字段";

        public MyStruct3() {}
    }

    private static string Property => "类内的静态计算属性";
    // get 可以直接简写成这样 计算属性
    private string Property2 => "类实例内的计算属性";
    
    struct MyStruct4 {
        public static string Property => "结构体内的静态计算属性";
        public static string field = "结构体内的静态字段";
        public string Property2 => "结构实例内的计算属性";
        public string field2 = "结构实例内的字段";

        public MyStruct4() {
            field2 = "构造函数覆盖了";
        }

        public MyStruct4(params int[] i) {
            // do nothing
        }
    }
    
    /////////////////////////////////////////////////////////////////////////////////////////

    struct MasterStruct {
        public struct SubStruct {
            public string S => "我被包裹的严严实实的";
        }

        public SubStruct CreateSubStructOnSameInstance => new SubStruct();
    }
    
    /////////////////////////////////////////////////////////////////////////////////////////

    struct RefStruct {
        private int x;
        private static int X;

        public RefStruct(int x) {
            this.x = x;
        }

        static RefStruct() {
            X = 10;
        }

        public void print() => WriteLine(x);
        public static void Print() => WriteLine(X);

        public static ref int refFun() {
            return ref X;
        }
    }

    /////////////////////////////////////////////////////////////////////////////////////////
    
    public static void learn() {
        // 结构写法和类相似 结构是隐式密封的 所以不能派生其他结构 变量不能为null 两个结构变量不能引用同一个对象
        // 结构在栈中 而不是像类一样在堆中 内部结构和类类似 没有局部结构
        var myst = new MyStruct();
        WriteLine($" { myst.x.ToString() } { myst.y.ToString() } ");    // 不允许初始化**非静态**属性和字段 只能声明
        var myst2 = new MyStruct(y: 3);
        WriteLine($" { myst2.x.ToString() } { myst2.y.ToString() } ");
        WriteLine($" { (myst.x = myst2.y = 8).ToString() } ");
        var mystt = new MyStructt();
        WriteLine($" { mystt.x.ToString() } { mystt.y.ToString() } ");  // 正常输出 1 1
        // 结构可以有实例和静态构造函数 不允许析构函数 没有静态结构  静态构造函数没有修饰符
        // 即使不从 堆内存 分配空间 创建结构实例也需要使用new关键字运算符
        
        WriteLine(Property);
        WriteLine(new LearnStruct().Property2); // 如果静态方法在实例类 那么如果访问权限够 就算创建实例之后也有权限访问实例的private成员
        WriteLine(MyStruct2.Property);
        WriteLine(MyStruct2.field);             // 静态属性和字段可以正常初始化
        WriteLine(new MyStruct2().Property2);
        // WriteLine(new MyStruct2().Property); 不能在非 static 上下文中访问 static 属性 'Property'
        WriteLine(new MyStruct3().field2);
        WriteLine(new MyStruct3().x);           // 能访问到初始化成功了是因为 新版本C#编译器会自动把你初始化的语句放在构造函数里边
        WriteLine(new MyStruct().x);            // 这也是为什么如果你初始化了非静态的字段或者属性会让你显式的 说明 构造函数
        WriteLine(new MyStruct().X);            // 但是属性好像可以初始化 这跟书上的有出入 详细自己查新版本特性吧 反正一般用构造函数初始化最好
        
        WriteLine(new MyStruct4().field2);
        WriteLine(new MyStruct4(1).field2); // 看 如果构造函数没写 就会调用默认的 如果是老版本C#会报错
        
        /////////////////////////////////////////////////////////////////////////////////////////
        
        // 结构只能用 private public 结构不可派生 自身是派生的System.ValueType 这个又派生自 Object
        // 结构本身是值类型 如果想将一个结构实例作为引用类型对象 需要装箱的副本 详细装箱 拆箱
        // 结构可以作为返回值和参数

        var ms = new MasterStruct();
        var ss1 = ms.CreateSubStructOnSameInstance;
        var ss2 = ms.CreateSubStructOnSameInstance;
        // 同一个结构实例下面的两个嵌套结构实例(聚合关系,无继承)
        var ms2 = new MasterStruct.SubStruct();
        WriteLine(ms2.S);       // 支持嵌套 初始化实例语句
        
        /////////////////////////////////////////////////////////////////////////////////////////

        var a = new RefStruct(5);
        a.print();
        RefStruct.Print();
        ref var hh = ref RefStruct.refFun();
        hh = 100;
        RefStruct.Print();          // 结构引用自身的东西只能静态 无法动态ref 但是结构可以作为参数

        /////////////////////////////////////////////////////////////////////////////////////////

        var subclass = new RefClass.RefStruct.SubClass { name = "我是第一个匿名基类实例的第一个结构实例的一个派生类实例" }.I;    // 可以把类中的嵌套结构给这样声明初始化出来
        WriteLine(subclass.I.I.S);   // 其中name是继承RefClass的
        var refstruct1 = new RefClass.RefStruct{ name = "我是第二个匿名基类实例的一个结构实例" };
        var refstruct2 = new RefClass.RefStruct("我是第三个匿名基类实例的一个结构实例");

        var refclass = new RefClass{ name = "我是第一个正常声明初始化的基类实例" };
        // refclass = new RefStruct(""); 不能在创建好的实例里面初始化新实例 只能在内部创建好返回出来
        // var refstruct3 = new refclass.RefStruct();
        var refstruct3 = refclass.NewStruct("我是第一个正常声明初始化的基类实例引用其他地方的一个结构实例");
        var refstruct4 = refclass.NewStruct("我是第一个正常声明初始化的基类实例引用其他地方的二个结构实例");
        WriteLine((refstruct3 = refstruct1).name);      // 指向第二个匿名类的结构实例 相应正常初始化的第一个结构实例无引用 销毁

        WriteLine(subclass.RetMainClass.name);                      // 提升到父类 子类没有name 直接使用父类继承的name
        WriteLine(subclass.name);
        subclass.RetMainClass.NewStruct("我是第一个匿名基类实例的第一个结构实例的一个派生类实例 的基类 引用的其他地方一个结构实例");
        subclass.RetMainClass.NewStruct("我是第一个匿名基类实例的第一个结构实例的一个派生类实例 的基类 引用的其他地方二个结构实例");
        WriteLine(subclass.RetMainClass.GetType());
        WriteLine("=====子类this父类");
        foreach (var f in subclass.RetMainClass.GetType().GetMembers()) WriteLine(f.Name);   //打印的还是子类的
        RefClass subclassMain = subclass;                                                              //向上转型
        WriteLine("=====子类向上转型");
        foreach (var f in subclass.I.GetType().GetMembers()) WriteLine(f.Name);
        WriteLine("=====子类向上转型this父类");
        foreach (var f in subclass.RetMainClass.GetType().GetMembers()) WriteLine(f.Name);
        // 三坨都是一样的
        
        /////////////////////////////////////////////////////////////////////////////////////////

        var newrefclass = new RefClass();
        ref var F = ref newrefclass.retRefStruct("我是新建的一个结构实例");
        newrefclass.print();
        F = new RefClass.RefStruct("我是匿名的昂");
        newrefclass.print();            // 结构可以被引用然后改变

        var newoutclass = new RefClass();
        ref var O = ref newoutclass.outRefStruct(out RefClass.RefStruct newstruct);
        newoutclass.print();
        WriteLine(newstruct.name);
        WriteLine(O.name);
        WriteLine(newstruct.GetHashCode());
        WriteLine(O.GetHashCode());
        O = new RefClass.RefStruct("我是匿名的昂");
        newoutclass.print();            // 结构可以被引用然后改变

    }

    class RefClass {
        public string name;
        public struct RefStruct {
            private string S => "拨开乌云看本质";
            public string name;

            public RefStruct(string name) => this.name = name;

            public class SubClass : RefClass {
                public string S => "我是最里层";
                public SubClass I => this;
            }
        }

        private RefStruct _ref;
        
        public ref RefStruct retRefStruct(string x) {
            _ref = new (x);
            return ref _ref;
        }
        
        public ref RefStruct outRefStruct(out RefStruct x, string s = "默认新建了一个 现在的_ref x 和上面的声明赋值应该指向同一个结构吧") {
            x = _ref = new (s);
            return ref _ref;
        }

        public void print() => WriteLine(_ref.name);
        public RefClass RetMainClass => this;
        public RefStruct NewStruct(string x) => new RefStruct{name = x};
    }
}
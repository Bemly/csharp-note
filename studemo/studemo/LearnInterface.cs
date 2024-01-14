using static System.Console;

namespace studemo; 

public class LearnInterface {

    class Dadclass1 {}
    class Dadclass2 {}
    // 和JAVA一样 不能extend两个基类,派生类会坏掉的
    // 接口的语法和基类继承一样 都是: 比JAVA的implement更人性化
    // class Childclass : Dadclass1, Dadclass2 {}
    
    // C# 的接口命名规范是首字母大写I 第二个和类一样的双峰法
    interface IInfo {
        string getName();
        int getAge();
    }

    // 接口只能继承接口
    interface IDemo : IInfo {
        new string getName();   // 重写用new覆盖 但没啥用
        int getAge(int i);      // 重载可以
        string getAge();        // 改变类型可以用new覆盖修改 比如缩小范围 不过一般用泛型
        string GetProperty { set; get; } // 属性只能这样用 方法体有 但是访问器需要重写
        string this [int x, int y] { set; } // 索引器类似 这个只需要重写set访问器就行了
        event EventHandler Handler; // 事件 不跟方法体
    }

    // 继承基类,使用接口=>重写方法实现接口功能
    // 如果有基类 这个基类要写在第一个
    // class CA : IInfo, Dadclass1 {  X
    class CA : Dadclass1, IInfo { //  V
        private string name = "hh";
        private int age = 28;
        // lambda 表达式 如果括号没参数的时候省略就成为属性了
        public string getName() => name;
        public int getAge() => age;
    }
    
    /////////////////////////////////////////////////////////////////////////////////////////
    
    // 显式接口实现
    interface IInfosub : IInfo {
        new string getAge();
    }

    class MyClass : IInfo, IInfosub {
        private string name = "ha";
        public string getName() => name;
        
        // 显式不能用public修饰符
        // public string IInfosub.getAge() => age.ToString(); X
        string IInfosub.getAge() => "10";
        int IInfo.getAge() => 20;

        public void print() {
            // getAge();    // 如果直接用getAge不知道该用哪个 再加上显式直接不可视
            WriteLine(((IInfo)this).getAge());
            WriteLine(((IInfosub)this).getAge());
        }
    }
    
    
    /////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////
    public static void learn() {
        WriteLine(new CA().getAge());
        WriteLine(new CA().getName());
        // 接口不能有数据成员和静态成员
        // 比如属性,索引器,事件,方法这些函数成员是可以的 但是不能有方法主体/代码块
        
        // 接口是引用类型
        IInfo ifcd = new CA();  // 实例向上转型到接口(自动
        var ifc = (IInfo)new CA(); // var 需要指明,不然编译器直接初始化类的实例不转型了
        // 类型还是类！！！
        WriteLine(ifc.GetType()); // studemo.LearnInterface+CA 只是转型了而已
        WriteLine(ifc.getName()); // 调用接口的引用方法
        
        // AS 运算符 如果这个类不是接口的实现 可以用这个返回null 有的话直接指向接口引用
        var b = new CA() as IInfo;
        if (b != null) WriteLine(b.getAge());
        
        /////////////////////////////////////////////////////////////////////////////////////////

        var a = new MyClass();
        IInfo ai = a;
        IInfosub ais = a;
        WriteLine(ai.getAge());
        WriteLine(ais.getAge());
        WriteLine(((IInfo)a).getAge());
        WriteLine(((IInfosub)a).getAge());
        WriteLine("=================");
        
        // 类内访问 显式接口
        a.print();
    }
}
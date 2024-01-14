using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using static System.Console;

namespace studemo; 

public class MyClass {
// ReSharper disable InconsistentNaming
// 警告太多了看着头疼（
    
    /////////////////////////////////////////////////////////////////////////////////////////
    private static void learnPolymorphism() {
        
        //在以下代码中，我们使用polymorphism（多态）的特性来将Triangle类型的对象upcast为Shape类型
        //在这个例子中，shape引用虽然是指向了Triangle类型的对象，但在上转型之后，它仅能够访问Shape类中定义的成员，
        //而无法访问Triangle类中定义的成员。如果想要访问Triangle类中特有的字段或方法，需要进行强制类型转换.
        Func<int> f1 = () => {
            Triangle tri = new Triangle();
            Shape shape = tri; // Upcasting
            WriteLine(shape.GetType()); // 输出 Triangle
            return 0;
        };f1();
        
        //在这个例子中，我们使用了is运算符检测shape对象是否是Triangle类型的实例，如果是，
        //就将其向下转型成Triangle类型的对象tri2。最后，我们比较tri和tri2两个对象是否相等，
        //结果为True，表明这两个对象引用的是同一个Triangle类型的实例。
        Func<int> f2 = () => {
            Triangle tri = new Triangle();
            Shape shape = tri;
            
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            if (shape is Triangle) {  
                Triangle tri2 = (Triangle)shape; // Downcasting back to the original derived type 
                WriteLine(tri == tri2);  // 输出 True
            }
            return 0;
        };f2();
    }

    class Shape {}
    class Triangle : Shape {}
    
    /////////////////////////////////////////////////////////////////////////////////////////

    private static void learnVirtual() {
        var derived = new MyDerivedClass();
        WriteLine(derived.GetType());
        MyBaseClass mybc = derived;             // 向上转型
        mybc.print();                           // 转型之后就调用的子类重写的虚方法
        WriteLine(mybc.GetType());              // 发现转型之后虽然是基类型，但还是返回自身类型
        var originBase = new MyBaseClass();     //
        originBase.print();                     // 没有调用
        WriteLine(originBase.GetType());        //
        // 最高派生类会传递
        // 虚方法不是强制覆写的 先从栈引用到基类 再从基类的virtual修饰符往派生类抛
        // 如果派生类有覆写 就用子类的覆写方法 没有就有上级的函数成员 层层递推
        var secondDerived = new SecondDerived();
        MyBaseClass secbc = secondDerived;      // 直接跳传到基基类
        secbc.print();                          // 虚方法可以转型之后仍然 父类 > 子类
        secondDerived.print();
        secbc.printNotVirtual();                // 转型之后直接父类的 > 子类的
        secondDerived.printNotVirtual();        // 转型之前直接子类的 > 类类的
    }
    
    class MyBaseClass {
        public virtual void print() {
            WriteLine($"this is the { this }, not derivedClass.");
        }
        // 覆写和被覆写是相同的权限 不能覆写static
        // 方法 属性 索引器 事件 可以用虚方法
        public void printNotVirtual() {
            WriteLine($"1");
        }
    }

    class MyDerivedClass : MyBaseClass {
        public override void print() {
            WriteLine($"this is the { this }, not BaseClass.");
        }
    }

    class SecondDerived : MyDerivedClass {
        public override void print() {
            WriteLine($"this is the {this}.");
        }
        public new void printNotVirtual() {
            WriteLine($"2");
        }
    }
    
    /////////////////////////////////////////////////////////////////////////////////////////

    [SuppressMessage("ReSharper", "ObjectCreationAsStatement")]
    private static void learnConstructor() {
        WriteLine("////////////////////////////////////");
        new MasterClass();
        new SubClass();
        WriteLine("////////////////////////////////////");
        new MasterClass(1);
        new SubClass(2);
        WriteLine("////////////////////////////////////");
        new MasterClass(3D);
        new SubClass(4D);
        WriteLine("////////////////////////////////////");
        new SubClass(5F);       // 顺序是先执行 : 后面的，再执行 { 后面的
    }
    
    class MasterClass {
        public MasterClass() {
            WriteLine("父类的构造方法/函数被执行");
        }

        public MasterClass(int i) {
            WriteLine("int 父类的构造方法/函数被执行 {0}", i.ToString());
        }

        public MasterClass(double i) {
            WriteLine("double 父类的构造方法/函数被执行 {0}", i.ToString(CultureInfo.InvariantCulture));
        }
    }

    class SubClass : MasterClass {
        
        // 父类构造函数执行完了才是子类
        // 隐式调用父类构造方法
        public SubClass() {
            WriteLine("子类的构造方法/函数被执行");
        }

        // 隐式调用父类构造方法 => 默认是base() 所以父类构造方法执行的() 而不是(int i)
        public SubClass(int i) {
            WriteLine("子类的构造方法/函数被执行 {0}", i.ToString());
        }
        
        // 显式调用父类构造方法
        public SubClass(double i) : base(i) {
            WriteLine("子类的构造方法/函数被执行 {0}", i.ToString(CultureInfo.InvariantCulture));
        }

        // 显式调用自己的构造方法
        public SubClass(float i) : this() {
            WriteLine("F已收到 {0}", i.ToString(CultureInfo.InvariantCulture));
        }
    }
    
    /////////////////////////////////////////////////////////////////////////////////////////

    private static void learnAbstract() {
        //方法 属性 事件 索引器 可以被抽象 抽象和虚不能同时
        // 抽象类不能创建实例 和JAVA一样
        
        // 没用拓展方法的静态类
        WriteLine(ExtendData2.Average(new MyData(1, 2, 3, 4, 5, 6, 7, 8, 9, 10)));
        // 静态类的扩展方法
        WriteLine(ExtendData.Average(new MyData(1, 2, 3, 4, 5, 6, 7, 8, 9, 10)));
        // 直接可以简写成下面这种 假装这个方法已经到MyData的这个类实例里边了
        WriteLine(new MyData(1, 2, 3, 4, 5, 6, 7, 8, 9, 10).Average());
    }

    public abstract class AbClass {
        public abstract int attribute { set; get; }
    }

    public abstract class MyAbClass : AbClass {}
    public class MyAbAbClass : MyAbClass {
        public override int attribute { get; set; }
    }
    
    // ReSharper disable once UnusedType.Local
    sealed class MySeClass : MyAbAbClass {}

    // class Myclass : MySeClass {}
    // learnClass.cs(166, 21): [CS0509] “MyClass.Myclass”: 无法从密封类型“MyClass.MySeClass”派生
    
    // 静态类 也不支持被继承      C#6.0 :using static 可以直接访问静态类的成员 不必使用类名
    // 静态类的扩展方法 扩展方法只能在非泛型、非嵌套 static 类中声明
    // 这里嵌套了 静态内部类了 所以我把他移到主类上去
    // static class ExtendData {
    //     public static double Average(this MyData md) {
    //         return (md.sum() + .0) / md.length();
    //     }
    // }

    public class MyData {
        private int[] arr;
        
        public MyData(params int[] arr) {
            this.arr = arr;
        }

        public int sum() {
            var result = 0;
            foreach (var value in arr) result += value;
            return result;
        }

        public int length() {
            return arr.Length;
        }
    }

    /////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////
    
    public static void myClass() {
        learnPolymorphism();        // 在C#和Java中，上下转型并不会改变对象的原始类型, 也指向同一个引用，而不是创建副本
        learnVirtual();             // 学习虚方法和覆写
        CopySpace.learnVirtual();   // 学习new来覆写这个虚方法
        learnConstructor();         // 学习构造函数初始化语句
        
        //类访问修饰符 可访问accessible <=> 可见/可视visible
        // public 作用域为 所有程序集
        // internal 默认 当前程序集(程序集既不是程序也不是dll 一个程序集里面有很多类)
        
        // 程序集间的继承 从其他程序集的基类继承派生类
        // 其实 程序集就是每个命名空间
        learnAbstract();            // 学习 抽象类 密封类(JAVA的final类,不可被继承) 静态类(主文件写了)
    }
    
    /////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////
}

static class ExtendData {
    public static double Average(this MyClass.MyData md) {
        return (md.sum() + .0) / md.length();
    }
}

static class ExtendData2 {
    public static double Average(MyClass.MyData md) {
        return (md.sum() + .0) / md.length();
    }
}

class CopySpace {
    
    public static void learnVirtual() {
        var derived = new MyDerivedClass();
        WriteLine(derived.GetType());
        MyBaseClass mybc = derived;             // 向上转型
        mybc.print();                           // 转型之后就调用的子类重写的虚方法
        WriteLine(mybc.GetType());              // 发现转型之后虽然是基类型，但还是返回自身类型
        var originBase = new MyBaseClass();     //
        originBase.print();                     // 没有调用
        WriteLine(originBase.GetType());        //
        // 最高派生类会传递
        // 虚方法不是强制覆写的 先从栈引用到基类 再从基类的virtual修饰符往派生类抛
        // 如果派生类有覆写 就用子类的覆写方法 没有就有上级的函数成员 层层递推
        var secondDerived = new SecondDerived();
        MyBaseClass secbc = secondDerived;      // 直接跳传到基基类
        secbc.print();                          // 虚方法可以转型之后仍然 父类 > 子类
        secondDerived.print();
        secbc.printNotVirtual();                // 转型之后直接父类的 > 子类的
        secondDerived.printNotVirtual();        // 转型之前直接子类的 > 类类的
        
        // 其他的属性啊 字段啊 索引器啊 这些数据成员 都一样的用法
        // 在创建实例之前 虚方法的执行顺序 > 构造函数 所以不要在构造函数中调用虚方法
        // 如果调用的话 会在派生类实例初始化之前就被传递到派生类 会造成构造出来的字段传递不到
    }
    class MyBaseClass {
        virtual public void print() {
            WriteLine($"this is the { this }, not derivedClass.");
        }
        // 覆写和被覆写是相同的权限 不能覆写static
        // 方法 属性 索引器 事件 可以用虚方法
        public void printNotVirtual() {
            WriteLine($"1");
        }
    }

    class MyDerivedClass : MyBaseClass {
        public override void print() {
            WriteLine($"this is the { this }, not BaseClass.");
        }
    }

    class SecondDerived : MyDerivedClass {
        // public override void print() {
        //     WriteLine($"this is the {this}.");
        // }
        // 原先是向下抛给这个派生类 现在用new mask屏蔽掉 意思是 抛下来的到上级就结束 然后使用上级的重写方法
        // this不变 还是SecondDerived 但是用的方法是第二级的 因为最小派生类已经屏蔽了
        // this is the studemo.CopySpace+SecondDerived, not BaseClass.
        public new void print() {
            WriteLine($"this is the {this}.");
        }
        public new void printNotVirtual() {
            WriteLine($"2");
        }
    }
    
    /////////////////////////////////////////////////////////////////////////////////////////
    
    // ReSharper disable once UnusedType.Local
    class MyClass1 {
        class MyClass2 {
            public class MyClass3 {
                public class MyClass4 {
                    public class MyClass5 {
                        public class MyClass6 {
                            public class MyClass7 {
                                public class MyClass8 {
                                    public class MyClass9 {
                                        public class MyClass10 {
                                            public class MyClass11 {
                                                public class MyClass12 {
                                                    public class MyClass13 {
                                                        public class MyClass14 {
                                                            public class MyClass15 {
                                                                public class MyClass16 {
                                                                    public class MyClass17 {
                                                                        public class MyClass18 {
                                                                            public class MyClass19 {
                                                                                public class MyClass20 {
                                                                                    public class MyClass21 {
                                                                                        public class MyClass22 {
                                                                                            public class MyClass23 {
                                                                                                public class MyClass24 {
                                                                                                    public class MyClass25 {
                                                                                                        public class MyClass26 {
                                                                                                            public class MyClass27 {
                                                                                                                public class MyClass28 {
                                                                                                                    public int 仅供娱乐 = 1;
                                                                                                                }
                                                                                                            }
                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        // ReSharper disable once UnusedMember.Local
        void 减少警告用() {
            var a = new MyClass2.MyClass3.MyClass4.MyClass5.MyClass6.MyClass7.MyClass8.MyClass9.MyClass10
                .MyClass11.MyClass12.MyClass13.MyClass14.MyClass15.MyClass16.MyClass17.MyClass18.MyClass19.MyClass20
                .MyClass21.MyClass22.MyClass23.MyClass24.MyClass25.MyClass26.MyClass27.MyClass28();
            a.仅供娱乐 += a.仅供娱乐;
        }
    }
}
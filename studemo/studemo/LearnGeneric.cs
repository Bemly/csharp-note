using System;
using static System.Console;

namespace studemo; 

public class LearnGeneric {
    class MyClass< T1, T2, T3 > where T3 : LearnGeneric {
        private T1 a, b, c;
        private T2 d, e, f;

        public MyClass(T1 t1, T2 t2) {
            a = b = c = t1;
            d = e = f = t2;
        }
        
        public MyClass(T1 t1, T2 t2, T3 G) {
            a = b = c = t1;
            d = e = f = t2;
            this.G = G;
        }

        public T1 getA => a;
        public T2 getD => d;
        
        // 约束 where 在类外 也可以是接口这些 反正能约束类型就行 允许该基类及其派生类
        T3 G;
        public int G2 = 1;
    }
    
    /////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////
    
    public static void learn() {
        // 泛型: 让多种类型共用一套方法 泛型类型的模板是 用户自定义类型 也就是上节的 运算符重载装拆箱那
        WriteLine(new MyClass<object, object, LearnGeneric>(1, "hh").getA.GetType());
        WriteLine(new MyClass<object, object, LearnGeneric>(1, "hh").getD.GetType());
        // 约束constraint: 类似JAVA的通配符 限定符
        // new MyClass { G2 = 1 };      泛型类不支持如此初始化
        // 泛型是必须全写的 就算构造只有三个参数 但是如果泛型有三个参数 那泛型必须写三个
        new MyClass<object, object, LearnGeneric>(1, 1, new LearnGeneric());
        // new MyClass<object, object, MyClass>(1, 1, new MyClass());       // X
        //  LearnGeneric.cs(37, 37): [CS0311] 类型“studemo.MyClass”不能用作泛型类型或方法
        // “LearnGeneric.MyClass<T1, T2, T3>”中的类型参数“T3”。
        // 没有从“studemo.MyClass”到“studemo.LearnGeneric”的隐式引用转换。
        
        // 拓展方法和泛型类
        var intHolder = new Holder<int>(3, 5, 7);
        var stringHolder = new Holder<string>("a1", "a2", "a3");
        intHolder.print();
        stringHolder.print();
        
        // 泛型委托 这里略 LINQ的大量特性使用的泛型委托
        // 泛型接口
        WriteLine(new Simple().returnIt("hello"));
        WriteLine(new Simple2<object>().returnIt(new LearnGeneric()));
        WriteLine(new Simple2<string>().newReturnIt<int>(20));
        WriteLine(new Simple2<string>().newReturnIt(30));
        WriteLine(new Simple2<string>().newReturnIt(new []{1})); // 但是T没有约束 实参可以写任意类型 但需要注意安全问题
        // WriteLine(new Simple2<string>().returnIt(40));   // 因为S被指定为string 所以无法传递
        
        // 可变性variance: 协变con variance和逆变contra variance,不变in variance
        // JAVA的数据成员/成员变量 会被 继承 父类/基类的 在C#被称为 赋值兼容性
        var a1 = new Animal();
        var a2 = new Dog();
        WriteLine(a1.age == a2.age);
        // 泛型委托不适用赋值兼容性 因为委托对象是同级的 不能进行上下转型/转换
        // 协变
        Factory<Dog> dogMaker = () => new Dog();
        // Factory<Animal> animalMaker = dogMaker;
        // 不能将初始值设定项类型 'studemo.Factory<studemo.Dog>' 转换为目标类型 'studemo.Factory<studemo.Animal>'
        // Cannot convert source type 'studemo.Factory<studemo.Dog>' to target type 'studemo.Factory<studemo.Animal>'
        // 意思是Factory这个泛型不同 创建的对象也不同 两者是平级的而不是派生关系
        
        // 为了解决这种不能转换的关系 仅将派生类用作输出值与构造委托有效性之间的常数关系叫作协变
        FactoryOut<Dog> dogMakers = () => new Dog();
        FactoryOut<Animal> animalMakers = dogMakers;
        // Animal的委托创建后直接赋值给Dog子类的 可以看作向上转型 但是向下转换就不行了
        // FactoryOut<Dog> dogMaker2 = animalMakers;
        // 不能将初始值设定项类型 'studemo.FactoryOut<studemo.Animal>' 转换为目标类型 'studemo.FactoryOut<studemo.Dog>'
        // Cannot convert source type 'studemo.FactoryOut<studemo.Animal>' to target type 'studemo.FactoryOut<studemo.Dog>'
        
        // 逆变 也就是从派生类逆向到基类 逆变声明委托时只能void 也就是没有返回值
        FactoryIn<Animal> animalMaker = () => new Animal();
        FactoryIn<Dog> dogeMaker = animalMaker;
        Factory<Animal> animalMaker2 = () => new Animal();
        // Factory<Dog> dogeMakers = animalMaker; //X
        
        // TODO: 需要查一下 这里的说法可能错误 还有加点栗子
        // 类似的，虽然接口支持赋值兼容性(?) 但是也支持协变逆变
        
        // 逆变协变也可以写在一起 下面这个就是
    }
    delegate V FactoryV<out R, in T, V>();
}

/////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////////

static class ExtendHolder {
    public static void print<T>(this Holder<T> h) {
        T[] vals = h.GetValues();
        WriteLine($"{vals[0]},{vals[1]},{vals[2]}");
    }
}

class Holder<T> {
    T[] Vals = new T[3];

    public Holder(T v0, T v1, T v2) {
        Vals[0] = v0;
        Vals[1] = v1;
        Vals[2] = v2;
    }

    public T[] GetValues() => Vals;
}

/////////////////////////////////////////////////////////////////////////////////////////

interface IMyIfc<T> {
    T returnIt(T invalue);
}

class Simple : IMyIfc<string> {
    public string returnIt(string invalue) => invalue;
}

class Simple2<S> : IMyIfc<S> {
    public S returnIt(S invalue) => invalue;
    public T newReturnIt<T>(T i) => i;
    // 也可以在函数前面单独新创建一个泛型方法
    // 但是这样子没有where来约束
}

/////////////////////////////////////////////////////////////////////////////////////////
// class Simple3<S> : IMyIfc<int>, IMyIfc<S> {
//     public int retrunIt(int invalue) => invalue;
//     public S retrunIt(S invalue) => invalue;
// }
// 泛型接口的实现必须唯一 比如如果是IMyIfc的话 只能写一个泛型接口
/////////////////////////////////////////////////////////////////////////////////////////

class Animal { public int age = 5; }
class Dog : Animal {}
delegate T Factory<T>();
delegate T FactoryOut<out T>();
delegate void FactoryIn<in T>();

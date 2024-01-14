using System;
using static System.Console;
// ReSharper disable InconsistentNaming
#pragma warning disable CS0067

namespace studemo;

// 委托类型声明
delegate void Handler();

// 发布者
internal class Incrementer {
    // 事件声明
    public event Handler MyEvent1, MyEvent2, OtherEvent; // 事件后面跟声明的委托
    public static event EventHandler MyStaticEvent;
    // BCL 声明了一个 EventHandler 的委托 专门处理系统事件

    public void doCount() {
        for (int i = 1; i < 100; i++) {
            if ( i % 12 != 0) continue;
            if (MyEvent1 != null) MyEvent1(); // 触发事件的代码
        }
    }
}

// 订阅者
internal class Dozens {
    public int DozensCount { get; private set; }

    public Dozens(Incrementer incrementer) {
        DozensCount = 0;
        // 事件注册 订阅事件
        incrementer.MyEvent1 += IncrementDozensCount;
        // 此时传过去的IncrementDozensCount就在作用域内 所以不用担心private 直接封装就行
    }

    // 事件处理程序声明
    private void IncrementDozensCount() {
        DozensCount++;
    }
}

/////////////////////////////////////////////////////////////////////////////////////////

public delegate void EventHandler(object sender, EventArgs e);
// 第一个参数用来保存触发事件的被触发对象的一个引用 由于是object大类 所以都是能够匹配到的,然后向上自动转型
// 第二个参数保存状态信息,不能传递任何数据,是用于事件处理程序的-一般忽略
//          如果希望传递数据可以派生一个自EventArgs基类的派生类
// 改写上面的程序
internal class Incrementer2 {
    public event EventHandler MyEvent;
    public void doCount() {
        for (int i = 1; i < 100; i++) if (MyEvent != null && i % 12 == 0) MyEvent(this, null);
    }
}

// 订阅者
internal class Dozens2 {
    public int DozensCount { get; private set; }

    public Dozens2(Incrementer2 incrementer) {
        DozensCount = 0;
        incrementer.MyEvent += IncrementDozensCount;
    }
    private void IncrementDozensCount(object sender, EventArgs e) => DozensCount++;
}

/////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////////

// 原初之类
public class LearnEvent {
    public static void learn() {
        // 事件: 发布者/订阅者模式 Publisher/Subscriber pattern
        
        // 委托类型声明 事件处理程序声明 事件声明 事件注册 触发事件的代码
        // 事件可静可动 事件不是类 而是类/结构的成员
        // 事件成员被自动隐式初始化为null
        var incrementer = new Incrementer();
        var dozensCounter = new Dozens(incrementer);
        // 如果是值类型 比如结构这些 就是参数克隆 需要指向要用到ref
        // 如果是引用类型 那么实参和形参都指向同一个对象Object！！！
        // Java 也是一样的 详细看 Program.cs+Csharp().demo(): 99
        incrementer.doCount();
        WriteLine(dozensCounter.DozensCount);
        incrementer.doCount();
        WriteLine(dozensCounter.DozensCount);

        /////////////////////////////////////////////////////////////////////////////////////////
        
        // GUI编程是事件驱动的 程序事件的异步操作是使用C#的绝佳场景
        // .NET 提供了 标准模式  改写上面的程序
        var incrementer2 = new Incrementer2();
        var dozensCounter2 = new Dozens2(incrementer2);
        incrementer2.doCount();
        WriteLine(dozensCounter2.DozensCount);
        incrementer2.doCount();
        WriteLine(dozensCounter2.DozensCount);
        
        /////////////////////////////////////////////////////////////////////////////////////////

        var p = new Publisher();
        var s = new Subscriber();
        p.SimpleEvent += s.MethodA;
        p.SimpleEvent += s.MethodB;
        p.RaiseTheEvent();
        p.SimpleEvent -= s.MethodA;
        p.RaiseTheEvent();
        
        WriteLine("==============");
        
        // 事件访问器 类似属性的用法
        var p2 = new PublisherEvent();
        p2.SimpleEvent += s.MethodA;
        p2.SimpleEvent += s.MethodB;
    }
}

/////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////////

class Publisher {
    public event EventHandler SimpleEvent;
    public void RaiseTheEvent() => SimpleEvent?.Invoke(this, null);
}

class Subscriber {
    public void MethodA(object o, EventArgs e) => WriteLine("AAA");
    public void MethodB(object o, EventArgs e) => WriteLine("BBB");
}

// 事件访问器 类似属性的用法 value是隐式传参
class PublisherEvent {
    public event EventHandler SimpleEvent {
        add => value?.Invoke(this, null);       // += 后面的值作为value
        remove => value?.Invoke(this, null);    // -= 后面的值作为value
        // 需要自己实现 这里不讨论
    }
}
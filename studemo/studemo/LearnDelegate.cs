using static System.Console;

namespace studemo; 




public class LearnDelegate {
    
    delegate void MyDel(int x);

    MyDel delVar, dVar;

    class MyClass {
        private int x = 3;
        private static int _x = 6;

        public void setx(int x) {
            this.x = x;
        }

        public static int X => _x;
        public int Y => x;

        public static void setX(int X) {
            _x = X;
        }

        public void print(int i) {
            WriteLine($"我收到了{ i.ToString() }");
        }
    }

    public void Learn() {
        var X = new MyClass();
        delVar = new MyDel( X.setx );       // 成员
        // dVar = new MyDel(X.X);       不支持属性
        dVar = new MyDel( MyClass.setX );   // 静态
        // 其中这个new可以省略
        delVar = MyClass.setX;
        WriteLine($"prototype 成员: { X.Y.ToString() }");
        dVar = X.setx;
        WriteLine($"prototype 静态 : { MyClass.X }");
        
        WriteLine("====================");

        dVar( 10 );
        WriteLine($"dVar 成员 : { X.Y.ToString() }");
        delVar( 20 );
        WriteLine($"delVar 静态 : { MyClass.X.ToString() }");

        delVar( 30 );
        WriteLine($"delVar 静态 : { MyClass.X.ToString() }");
        
        WriteLine("====================");

        delVar = X.setx;
        dVar = MyClass.setX;
        
        dVar( 40 );
        WriteLine($"dVar 静态 : { MyClass.X.ToString() }");
        delVar( 50 );
        WriteLine($"delVar 成员 : { X.Y.ToString() }");
        
        // 组合委托
        var delC = delVar + dVar;
        delC( 60 );
        WriteLine($"delVar 成员 + dVar 静态 : { X.Y.ToString() }, { MyClass.X.ToString() }");
        // 组合之后 如果原delVar dVar这些引用改了 但组合的委托是不改的
        delVar = X.print;
        delVar( 70 );
        delC( 70 );
        WriteLine($"delVar 成员 + dVar 静态 : { X.Y.ToString() }, { MyClass.X.ToString() }");
        delC += delVar;
        delC( 80 );
        WriteLine($"delVar 成员 + dVar 静态 : { X.Y.ToString() }, { MyClass.X.ToString() }");
        // 空委托返回为Null 逆组合 移除方法
        delC -= delVar;
        delC( 90 );
        WriteLine($"delVar 成员 + dVar 静态 : { X.Y.ToString() }, { MyClass.X.ToString() }");
        
        // 用Invoke来防止委托可能是null
        if (delC != null) delC(100);
        WriteLine($"delVar 成员 + dVar 静态 : { X.Y.ToString() }, { MyClass.X.ToString() }");
        delC?.Invoke( 110 );
        WriteLine($"delVar 成员 + dVar 静态 : { X.Y.ToString() }, { MyClass.X.ToString() }");
        delC += delVar;
        delC += delVar;
        delC -= delVar;
        delC -= delVar;
        delC -= delVar; // 改变无效
        // 如果引用改了 可能无法删除委托组中的该委托 委托组差不多可以看作是个数组
        var count = 1;
        foreach (var v in delC.GetInvocationList()) {
            // if ((count++) == 1) delC -= v;
            // v 是 委托元素，而不是我们new的自定委托类，不能使用委托的运算符重载
            WriteLine(v.GetInvocationList());
            foreach (var f in v.GetInvocationList()) {
                WriteLine(f.GetInvocationList());
            }
        }
        
        // 也可以调用有返回值的委托 在方法return 然后**委托**委命这个方法 把返回值传出来
    }
    
    /////////////////////////////////////////////////////////////////////////////////////////

    class Myclass {
        delegate void Mydel(ref int X);
        delegate void Mydel2();
        public void Add2(ref int x) => x += 2;
        public void Add3(ref int x) => x += 3;

        public void Add4() => WriteLine("好耶");

        public static void learn() {
            var mc = new Myclass();
            var mDel = mc.Add2; // 这里是通过参数一致来判断委托类型的 所以不用初始化委托了
            mDel += mc.Add3;
            mDel += mc.Add2;

            int x = 5;
            mDel(ref x);
            // 委托这个索引器和运算符重载是按照类似栈加入的方式 逐级允许的
            WriteLine(x);
            
            /////////////////////////////////////////////////////////////////////////////////////////
            
            // 看完上面那两个及其注释之后 然后是重点 匿名方法和Lambda 表达式
            // 匿名方法和Lambda 表达式
            // 匿名方法和Lambda 表达式
            // anonymous method 和 Lambda 表达式
            
            // 关键字支持 delegate,这个函数/方法匿名 所以没有名字
            mDel = delegate(ref int x) {
                x += 20;
            };
            
            // 使用全称反而错误
            // mDel = new Mydel( delegate(ref int x) {
            //     x += 20;
            // } );
            
            // 如果 参数没有out 然后不使用参数就可以把参数省略
            var mdel = mc.Add4;     // 封装 可以用这个把匿名函数/方法啥的封装到委托组里边
            mdel += delegate { WriteLine("好耶！"); }; // 直接省略掉参数
            mdel += () => WriteLine("好耶！！");       // 箭头匿名函数没有参数需要加括号，有参数且一个不用加
            
            // 匿名函数对params参数无效 会自动省略
            // 匿名函数的作用域在方法体内
            
            // C# 3.0就加入了Lambda 这个表达式彻底摒弃了名字
            mdel += () => WriteLine("好耶！！！");
            mdel();
        }
    }
    
    /////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////
    
    public static void learn() {
        // 委托: 是一个类型安全的、面向对象的 C++ 函数指针
        // 委托类型不是委托对象 是一个包含有序方法序列的对象 这些方法具有有相同的签名(形参)和返回类型
        
        // 记录一下 笔记全没了 凑合着直接看代码吧
        
        // delegate void MyDel(int x);
        // X 委托不支持局部声明 但是支持成员内部声明

        new LearnDelegate().Learn();

        Myclass.learn();
        
        
        
        
    }
}
using System;    //使用SYSTEM命名空间类型
using System.Text;
using static System.Console;
using static System.Math;
// ReSharper disable InconsistentNaming
// 警告太多了看着头疼（

namespace studemo { //声明新命名空间
    internal class Program {  //声明一个类
	    
        public static void Main(string[] args) {   //声明Main的方法作为类的成员方法
            WriteLine("Hello Rider!\nHello CSharp!");  //Main方法体语句块内的语句，调用外部类Console的方法WriteLine
            
            //////////////////////////////////////////////
            // ReSharper disable once InvalidXmlDocComment
            ///
            ///         ReSharper 真是太好用辣 泰库辣
            ///  文档作者：本木栗 Bemly_
            ///  创建时间：2023/04/30
            ///  更新时间：2023/05/08
            /// 
            //////////////////////////////////////////////
            ///
            ///	 更新说明:
            ///		2023/05/02 完成 1  2  3  大章的学习
            ///		2023/05/03 完成 4  5  6  大章的学习
            ///		2023/05/04 完成 7  8     大章的学习
            ///		2023/05/05 完成 9  10 11 大章的学习
            ///		2023/05/06 完成 12 13 14 大章的学习
            ///		2023/05/07 完成 15 16 17 大章的学习
            ///		2023/05/08 完成 18 19 20 大章的学习
            ///
            //////////////////////////////////////////////
            /// 
            ///  C# 图解教程学习大纲:
            ///     1.类型 存储 变量
            ///     2.类 方法
            ///     3.面向对象OOP 继承
            ///     4.表达式 运算符 语句
            ///     5.结构
            ///     6.枚举
            ///     7.数组
            ///     8.委托
            ///     9.事件
            ///     10.聚合 多态 接口
            ///     11.转换
            ///     12.泛型
            ///     13.枚举器 迭代器
            ///     14.LINQ
            ///     15.异步 协程
            ///     16.命名空间 包
            ///     17.异常
            ///     18.预处理指令
            ///     19.反射 特性
            ///     20.C# .NET 6-7新版本特性
            ///     21.综合应用
            ///
            //////////////////////////////////////////////
            ///
            ///		Todo :
            ///			完成书籍内容之后 需要系统复习一下 然后做项目
            ///		Todo :
            ///			熟悉 枚举器 迭代器 的原理
            ///		Todo :
            ///			创建 WPF 来使用 异步操作
            ///		Todo :
            ///			做程序签名 使用的类库等等 还有逆向dll然后魔改dll等等
            ///
            //////////////////////////////////////////////

            var csharp = new Csharp();  //目录 上下文操作 导航到 方法		p.s.还是Clion跳转好用
            csharp.demo();				// 临时方法
            csharp.C1();				// 1. 类型 存储 变量
            csharp.C2();				// 2. 类 方法
            csharp.C2p();				// 2. 附加 方法参数
            csharp.C3();				// 3. 面向对象OOP 继承
            LearnExpression.learn();	// 4. 表达式 运算符 语句
            LearnStruct.learn();		// 5. 结构
            LearnEnum.learn();			// 6. 枚举
            LearnArray.learn();			// 7. 数组
            LearnDelegate.learn();		// 8. 委托
            LearnEvent.learn();			// 9. 事件
            LearnInterface.learn();		// 10.聚合 多态 接口
            LearnConversion.learn();	// 11.转换
            LearnGeneric.learn();		// 12.泛型
            LearnEnumer.learn();		// 13.枚举器 迭代器
            LearnLINQ.learn();			// 14.LINQ
            LearnAsync.learn();			// 15.异步 协程
            LearnNamespace.learn();		// 16.命名空间 包
            LearnException.learn();		// 17.异常
            LearnDefine.learn();		// 18.预处理指令
            LearnReflect.learn();		// 19.反射 特性
            LearnNewContent.learn();	// 20.C# .NET 6-7新版本特性
            LearnOtherTheme.learn(args);	// 21.综合应用
        }
    }

    class Csharp {
	    public int demoInt = 1;
	    public Csharp(){}
	    public Csharp(Csharp C) {
		    C.demoInt = 10;
	    }
	    public void Demo(Csharp C) {
		    C.demoInt = 20;
	    }
	    
	    struct MyStruct {
		    public int demoInt;

		    public MyStruct() => demoInt = 1;

		    public MyStruct(MyStruct S) {
			    S.demoInt = 10;
			    WriteLine(S.demoInt);
		    }
		    public void Demo(MyStruct S) {
			    S.demoInt = 20;
			    WriteLine(S.demoInt);
		    }
	    }
	    public void demo() { // 我也不知道我什么时候放了个这玩意 不过能跑就不要动（（（
		    var c1 = new Csharp();
		    var c2 = new Csharp(c1);
		    WriteLine(c1.demoInt);
		    c2.Demo(c1);
		    WriteLine(c1.demoInt);

		    var s1 = new MyStruct();
		    var s2 = new MyStruct(s1);
		    WriteLine(s1.demoInt);
		    s2.Demo(s1);
		    WriteLine(s1.demoInt);
		    
		    // 如果是值类型 比如结构这些 就是参数克隆 需要指向要用到ref
		    // 如果是引用类型 那么实参和形参都指向同一个对象Object！！！
		    // Java 也是一样的
	    }
	    
	    public void C1() {
		    WriteLine("======  基本语句块练习  ======");
            {
                int i = 1;
                System.Console.WriteLine("这是一个语句块 局部变量只能在该块存在 i={0}", i);
                WriteLine("限定符冗余，因为所在命名空间类型就是System的");
            }
            // WriteLine($"从C#6.0开始直接在format里面输入变量就行了,比如i={i}");
            //  Program.cs(46, 65): [CS0103] 当前上下文中不存在名称“i”
            
            WriteLine($"从C#6.0开始直接在format里面输入变量就行了,比如i={8},i={0}", 8);
            //使用了内插字符串。您是想使用格式字符串占位符吗?
            //编译器不知道该是{8}是占位符还是把int 8当作变量传给$format:"string"
            //因为是$修饰的，所以编译器默认后者，但是不同的环境对默认会有不同的解释，导致运行结果不可预期
            
            WriteLine("==============================");
            double d = 3.4;
            WriteLine("{0, 12}", "简易公告版");
            WriteLine($"(ノ｀Д)ノ丨{d, 10}丨");
            //对齐说明符
            WriteLine($"(ノ｀Д)ノ丨{d, -10}丨");
            //格式说明符 精度说明符 Float .10f <= JAVA
            WriteLine($"(ノ｀Д)ノ丨{d, -10:F8}丨");
            WriteLine("==============================");
            
            WriteLine($"CLR Version CLR是.NET框架的核心组件，是系统的顶层: {Environment.Version}");
            
            //C#程序或dll源代码是一组类声明 就是类的广义集合
            //类型是一种模板，需要被实例化
            ulong MAX = ulong.MaxValue;
            //C: unsigned long long [int] => C#:ulong (JAVA:没有无符号的长长整型，甚至是整型而言)
            WriteLine($"{MAX++}++ => {MAX}");
            //MAX+=2效果差不多与++MAX一致，返回值是修改后的

            // int i1 = uint.MaxValue;
            //uint不能转换为int
            uint i2 = uint.MaxValue;
            int i1 = (int)i2; //强制转换=不检查 可能导致溢出
            WriteLine($"i1:{i1}, i2:{i2}"); //输出可以看出采用的补码
            var i3 = 1.48900D;
            var i4 = 1.48900F;
            var i5 = 1.48900;
            var i6 = 0x578D;
            var i7 = 578D;
            var i8 = 0b00001010_00000000_00000001_01001101; //特性和JAVA一致
            WriteLine(i3.GetType());
            WriteLine(i4.GetType());    //能够识别Float然后var自动被编译成float
            WriteLine(i5.GetType());    //默认双精度
            WriteLine(i6.GetType());	//0x开头代表Hex 这个时候不认后面的D 用的int32(4Byte signed Int)
            WriteLine(i6);              //输出默认十进制
            WriteLine(i7.GetType());	//十进制输入加D编译器可以识别为Double
            WriteLine(i8);				//0b二进制 _忽略 方便查看
            
            // 套用JAVA的初学教程
            WriteLine("======套用JAVA的初学教程======");
            byte xx1 = Byte.MaxValue;			//0b1111_1111
            byte xx2 = Byte.MinValue;			//0b0000_0000
            WriteLine(xx1);
            WriteLine(xx2);
            // ！！！和JAVA不同，C#的Byte没有符号位哦
			xx1++;
	        WriteLine(xx1);				//0b0000_0000
	        // x1 = -1;  // 1111_1111
	        // JAVA的-1会自动转换   C#：Program.cs(96, 15): [CS0031] 常量值“-1”无法转换为“byte”
	        // x1 = (byte)-1;
	        //   Program.cs(98, 15): [CS0221] 常量值“-1”无法转换为“byte”(使用 "unchecked" 语法重写)
	        xx1 = 0b111_1111;
	        WriteLine(xx1);				//127
	        
	        // JAVA 1.8 也就是8之前就有了
	        //  Program.cs(123, 4): [CS8370] 功能“未签名的右移位”在 C# 7.3 中不可用。请使用 11.0 或更高的语言版本。

	        // Int32 x, y;		  //默认xy初始化才会判断int大小 一般是int32
	        // Int16 short Int64 long 和C不同 无long long
	        WriteLine("======  移位运算符学习  ======");

	        int x, y;
	        x = 0b0000_0011_0000_0000;
	        //Convert.ToString将x的十进制输出转化为String 2进制 然后32位补齐，不足的添0
			x = x >> 1;							// 0000_0000_0000_0000 0000_0001_1000_0000 x
			WriteLine(Convert.ToString(x, 2).PadLeft(32, '0'));
			x <<= 23;							// 1100_0000_0000_0000 0000_0000_0000_0000 x
			WriteLine(Convert.ToString(x, 2).PadLeft(32, '0'));
			y = x >> 1;							// 1110_0000_0000_0000 0000_0000_0000_0000 y
			WriteLine(Convert.ToString(y, 2).PadLeft(32, '0'));
			y >>= 10;							// 1111_1111_1111_1000 0000_0000_0000_0000 y
			WriteLine(Convert.ToString(y, 2).PadLeft(32, '0'));
			x >>>= 1;							// 0110_0000_0000_0000 0000_0000_0000_0000 x
			WriteLine(Convert.ToString(x, 2).PadLeft(32, '0'));
			x >>>= 10;							// 0000_0000_0001_1000 0000_0000_0000_0000 x
			WriteLine(Convert.ToString(x, 2).PadLeft(32, '0'));
			x >>= 1;							// 0000_0000_0000_1100 0000_0000_0000_0000 x
			WriteLine(Convert.ToString(x, 2).PadLeft(32, '0'));
			y >>>= 1;							// 0111_1111_1111_1100 0000_0000_0000_0000 y
			WriteLine(Convert.ToString(y, 2).PadLeft(32, '0'));
			/*
			 * >>> 符号位始终取0，如果开始是负也就是符号位是1的话，1会右移动到右边位
			 * >>  符号位是1 往右边吐1 符号位是0 往右边吐0
			 */
			
			WriteLine("======  比较两个String  ======");
			String x2 = "x";
			String y2 = "x";
			WriteLine(x2 == y2); //T
			y2 = new string(new char[]{ 'x' });
			WriteLine(x2 == y2); //F x  T V
			
			/*
			 * JAVA 这个是False 这是默认值会调用toString的方法
			 * getClass().getName() + '@' + Integer.toHexString(hashCode())
			 *
			 * 由于字符串在程序中经常用到，Java为了加快程序的执行速度
			 * 把隐式创建的字符串对象放在栈中一个特殊区域—字符串池（String Pool）中，
			 * 相同内容的字符串对象只保留一份，用引号新产生字符串对象时先从字符串池中寻找是否已经存在，
			 * 若已经存在就取出来直接使用。而用new创建的字符串对象即使内容都是”Hello Java!”
			 * 他们也是不同的对象实例，在内存中占不同的空间。
			 * 
			 * C#中 数据结构-字符串常量池
			 * CLR为了减少字符串对象的重复创建，其维护了一个特殊的内存，这段内存被成为字符串常量池。
			 * 字符串常量池不在堆中也不在栈中,是独立的内存空间管理，在内存的常量区。
			 * 如果存在相同内容的字符串对象的引用，则将这个引用返回。
			 *
			 * 注意：不是所有的字符串都放在暂存池中，运行时期动态创建的字符串不会被加入到驻留池中。
			 * 关于字符串常量池的更深理解：
			 *		1. 驻留池由CLR来维护，其中的所有字符串对象的值都不相同。
			 *		2. 只有编译阶段的文本字符常量会被自动添加到驻留池。
			 *		3.运行时期动态创建的字符串不会被加入到驻留池中。
			 *		4.string.Intern()可以把动态创建的字符串加入到驻留池中。
			 * 
			 */
			
			WriteLine("======  按位运算符学习  ======");
			 int x4 = 0b00001010_00000000_00010001_01001101; //167776589
			 int y4 = +0b0001010_00000000_00010001_00000000; //167776512
			 WriteLine(x4 & y4); //0000_0001;
			 int i9 = 167776589; // 00001010 00000000 00010001 01001101
			 int n = 167776512; // 00001010 00000000 00010001 00000000
			 WriteLine(i9 & n); // 167776512
 							   // 11111111 11111111 11101111 10110010 X
 							   // 00001010 00000000 00010001 00000000 V
			 
			 int x5 = 0b00001010_00000000_00000001_01001101;
			 int y5 = +0b0001010_00000000_00010001_00000000;
			 WriteLine(x5 & y5);
 					 //+0001010_00000000_00000001_00000000
			 
			 int x3 = 0b00001010_00000000_00000001_01001101;
			 int y3 = -1979707136;
			        //-0b0001010_00000000_00010001_00000000
			 WriteLine(x3 & y3);
 					 //+0001010_00000000_00000001_00000000
		 
			 // int x6 = 0b00001010_00000000_00000001_01001101;
			 // int y6 = 0b10001010_00000000_00010001_00000000;
			 // WriteLine(x6 & y6);
 			// 		 //+0000000_00000000_00000001_00000000
            // 在C#中 只能用下面的表达式 因为C#默认数字都代表符号位
            // 如果有0b32位首先会判断为拿出32位全部来做数字，此时的基本类型为uint 所以不能赋值给int
            // 如果不写0b32位就会判断拿出最高位作为符号位 此时编译器判断为int 赋值给声明为int值类型的字段变量
			 
			 int x7 = 0b00001010_00000000_00000001_01001101;
			 int y7 = -0b1110101_11111111_11101110_11111111;
			 WriteLine(x7 & y7);
 					 //+0000000_00000000_00000001_00000000
                     
                     //-取反 source:https://www.cnblogs.com/ntyvictory/p/10650834.html

	        int y8 = -0b01;
	        WriteLine(y8);
	        WriteLine("==============================");
	
			WriteLine("😢");
			
			// C#的数组声明定义初始化语法和 JAVA 的语法糖一致
			var i2489 = "auiadg";
			i2489 = i2489.ToLower();
	        i2489 = "HELLO".ToLower();
	        WriteLine(i2489.ToLower());

	        String s = "Test string";
	        int n1 = s.IndexOf('t');
	        int n2 = s.IndexOf("st", StringComparison.Ordinal);
	        int n3 = s.IndexOf("st", 4, StringComparison.Ordinal);
	        WriteLine(n1);
	        WriteLine(n2);
	        WriteLine(n3);
	        // C# 的方法一般不算驼峰法 而是双峰
	        
	        WriteLine("======  引用字符串学习  ======");
	        String s1 = " 我还是我自己 ";
            String s2 = s1;
            // s2[2] = '不';
            // Program.cs(79, 13): [CS0200] 无法为属性或索引器“string.this[int]”赋值 - 它是只读的
            s2 = s1.Trim();
            WriteLine($"s1:{s1}, s2:{s2}");
            //因为s2.trim()不会改变原有数组，但是返回了一个新String类/对象 s2从指向s1变到了指向s1.trim()
            String.Concat(s1, s2); //类似的String封装类一样，和C不同，这些都不改变原值

            char[] c1 = new char[]{ '我', '还', '是', '我', '自', '己'  }; //new char[]可以忽略如果是静态初始化 和JAVA一致
            char[] c2 = { '我', '还', '是', '我', '自', '己'  };
            c1 = new char[]{ '我', '还', '是', ' ', '自', '己'  };
            WriteLine($"c1[]:{c1}, c2[]:{c2}"); //$不支持char[]传参直接输出String了
            WriteLine("c1[]:{0}, c2[]:{1}", c1, c2);
            WriteLine(c1);  //目前只支持构造函数传过去char[]单独解析
            WriteLine(c2);
            c1 = c2;
            WriteLine(c1);
            c1[1] = '不';
            WriteLine(c2); //c1直接和c2一样 指向堆内存中同一个char数组,当c1改动之后c2也相应变化
            
            // c1[6] = '.';
            // 未经处理的异常:  System.IndexOutOfRangeException: 索引超出了数组界限。
            // 在 studemo.Program.Main(String[] args) 位置 E:\Csharp\studemo\studemo\Program.cs:行号 97
            // 和 C 语言不一样 这个\0是特殊处理之后的 检查器会在\0这里算索引下标越位
            
            //String 因为安全性 初始化并不char[] 也不是java中又object封装的
            //他是预定义类型中的String 引用类型 且初始化之后指向的String是只读的
            //如果需要修改要用到可变字符串（JAVA） StringBuilder/StringBuffer
            var sb1 = new StringBuilder("我还是我自己");
            var sb2 = sb1;
            //如果用var只能够声明一个变量！ 且必须初始化 且必须要表达式 说人话就是要让编译器看到这个到底是什么类型的，不能模凌两可
            // var sb1 = 1, sb2 = 2;     X
            // var sb1;                  X
            // var whoami = { "我是谁" }; X
            sb1[1] = '不';
            WriteLine(sb2);  //同理,s2只是一个引用 引用的Object基类的孙子类StringBuilder
	    }
	    public void C2() {
		    int Cc2(int x) {
			    WriteLine(x);
			    return x;
		    }
		    Cc2(1);
		    
		    double legendrePolynomial(double n, double x) {
			    if (n == 0) return 1;
			    else if (n == 1) return x;
			    else return ((n*2-1)*x - legendrePolynomial(n-1, x) - (n-1)*legendrePolynomial(n-2, x))/n;
		    }
		    double newtonRaphsonMethod(double x, double a, double b, double c, double d) {
			    double f(double x) { return Pow(x,3)*a-Pow(x,2)*b+x*c-d; }
			    double df(double x) { return Pow(x,2)*a*3-x*b*2+c; }
			    while (Abs(f(x)/df(x)) >= 1e-6) x -= f(x)/df(x);
			    return x;
		    }
		    WriteLine($"{legendrePolynomial(10, 0.5)}, {newtonRaphsonMethod(1, 1, 2, 3, 4)}");
		    
		    // 引用参数
		    var num = 1;
		    void refNum(ref int i) {
			    i = 2;
		    }
		    refNum(ref num);
		    WriteLine(num);
		    // 引用参数类似define 形参不分配内存 直接指向实参 因此实参会跟着形参的改变而改变 注意参数都要加ref

		    int[] arrInt = { 1, 2, 3 };
		    void refArr(ref int[] arr) {
			    int[] arr2 = { 1, 3, 4 };
			    arr = arr2;
			    arr2[2] = 5;
		    }
		    // refArr(ref new int[]{1, 2});
		    //  Program.cs(316, 18): [CS1510] ref 或 out 值必须是可以赋值的变量
		    refArr(ref arrInt);
		    WriteLine(arrInt[2]);  //output: 5
		    
		    // 输出参数
		    void arrOut(out int i) {
			    // int v = i + 2;
			    //   Program.cs(323, 16): [CS0269] 使用了未赋值的 out 参数“i”
			    //   Program.cs(322, 12): [CS0177] 控制离开当前方法之前必须对 out 参数“i”赋值
			    // out要出去必须必须先赋值 形参必须被初始化 实参然后会引用形参的值

			    i = 1;
		    }
		    arrOut(out num);
		    WriteLine(num);

		    void arrOut2(out int i) {
			    i = 3;
		    }
		    arrOut2(out int n);
		    WriteLine(n); //C#7.0开始不需要声明了
		    
		    // 参数数组
		    //  必须是参数最后一个 且只能有一个 数组长度可变
		    // void paramFun(params int[] i, int a) { X
		    //  
		    void paramFun(ref string s, params int[] i) {
			    WriteLine(num);
			    int n = 1;				//String是实参的话会现在实参所在作用域把变量拼接好了再发给形参
			    WriteLine(s += s);
			    i[n] = 1;
			    foreach (var num in i) {
				    // static int n = 1;  // C# 不支持静态局部变量
				    WriteLine($"{n++}=>{num}");
			    }
		    }
		    var sn = $" {n} ";
		    paramFun(ref sn, 1, 2, 3, 4, 5);
		    WriteLine(sn);
		    paramFun(ref sn, new int[]{ 1, 2, 3, 4, 5 });
		    
		    // ref 局部变量和 ref 返回  REF=>别名
		    var x = 1;
		    ref var y = ref x;
		    WriteLine($"x:{x} y:{y}");
		    y = 2;
		    WriteLine($"x:{x} y:{y}");

	    }
	    public void C2p() {
		    var i = new C2c(1);
		    ref int output = ref i.refToValue();
		    WriteLine(output);
		    i.show();
		    output = 5;
		    i.show();
		    
		    // 键值对应用：通过ref取最大键的值
		    var i1 = 10;
		    var i2 = 10;
		    WriteLine($"i1=>{i1}, i2=>{i2}");
		    ref int MAX = ref C2c.max(ref i1, ref i2);	//静态调用 就是不创建实例这种动态的
		    WriteLine($"MAX=>{MAX}");
		    MAX++;
		    WriteLine($"i1=>{i1}, i2=>{i2}, MAX=>{MAX}");
		    // 在C#中，不允许使用 ref 关键字返回一个实例方法中的局部变量。尝试这样做会导致编译时错误。
		    // refFun(out int A);
		    // ref int refFun(out int o) {
			    // return ref int 2;		X
			    // return ref var o = 2;	X
			    // return ref o = 1;		X
			    //  Program.cs(367, 19): [CS8156] 不能在此上下文中使用表达式，因为表达式无法通过引用传递或返回
			    
			    // o = 1;					X
			    // return ref o;			X
			    //  Program.cs(370, 19): [CS9075] 无法按引用“o”返回参数，因为它的作用域为当前方法

			    // o = 1;					X
			    // return ref A;			X
			    //  Program.cs(376, 19): [CS8168] 局部变量“A”不是 ref 局部变量，无法通过引用返回
			    //  Program.cs(364, 7): [CS0165] 使用了未赋值的局部变量“A”
		    // }
		    // ref 局部变量只能赋值初始化一次，就像final一样
		    // 如果返回之前是ref修饰过的引用 返回的时候没有ref则还是副本
		    
		    // 方法重装就是同名方法有多种参数分别调用不同的同名方法
		    // 同理。有构造函数/方法重载 这些同名不同参的方法每个叫做签名
		    
		    // 命名参数 在实参处 就是实参传过去之前用 <形参名称: 实参变量/表达式> 来指定传入哪个形参
		    // 可选参数 在形参处 如果没有传过来就用默认的参数 <类型 形参字段 = 默认值>
		    //		ref params out 不能用可选参数 且引用类型的可选参数只能为null
		    // 顺序： 必填参数 可选参数 可变参数数组
		    int test(out int a, string b = "值呢", params int[] i) {
			    if (b == "值呢") WriteLine("自寻死路");
			    return a = i.Length > 0 ? i[0] : 2;
		    }
		    // WriteLine($"第壹次：{test(b: "给你值",a: out int A,i: null)}");
		    //未经处理的异常:  System.NullReferenceException: 未将对象引用设置到对象的实例。 i != null
		    WriteLine($"第壹次：{test(b: "给你值",a: out int A,i: 1)} => A: {A}");
		    WriteLine($"第贰次：{test(i: new int[6], a: out int B, b: "给你值")} => B: {B}");
		    // WriteLine($"第叁次：{test(i: new int[]{3，4，3}, a: out int C)} => B: {C}");
		    // 大括号冲突 无法解析
		    WriteLine($"第叁次：{test(out int C)} => B: {C}");
		    WriteLine($"A=>{A}, B=>{B}, C=>{C}");
	    }
	    class C2c {
		    private int i;
		    
		    private C2c(){}
		    
		    public C2c(int i) {
			    this.i = i;
		    }
		    
		    public ref int refToValue() {
			    return ref i;
		    }
		    
		    public void show() {
			    WriteLine($"i: {i}");
		    }
		    
		    // MAX 应用
		    private static int min = Int32.MinValue;
		    public static ref int max(ref int i1, ref int i2) {
			    if (i1 == i2) return ref min;
			    if (i1 > i2) return ref i1;
			    return ref i2;
		    }
	    }
	    public void C3() {
		    const int MRJBCL = 3;// 局部常量 常量const不是修饰符 是声明一部分 不占内存 编译时会被编译器替换
		    static void MRJTJBHS() {}// 静态局部函数
		    
		    // 属性 不能显式调用get setter类似访问器 只能隐式
		    C3c.MyValue = 5;
		    WriteLine(C3c.MyValue);

		    C3c.OneValue = 110;
		    WriteLine(C3c.OneValue);
		    C3c.OneValue = 53;
		    WriteLine(C3c.OneValue);
		    C3c.OneValue = 28;
		    WriteLine(C3c.OneValue);
		    C3c.OneValue = -4;
		    WriteLine(C3c.OneValue);
		    
		    // 属性比公共字段更好，比公共函数更简洁 只读只写 支持静态蓝图成员和实例成员
		    // 自动实现属性不需要后备字段了
		    // 自动实现属性和公有字段差不多 相当于public 变量
		    // 但是属性是属于实现功能 所以修改功能只需要编译实现就行了，不需要再重复编译它的其他程序集
		    C3c.value = 3;
		    WriteLine(C3c.value);

		    C3c.str = " 我是故意留下空格的 ";	//只写
		    WriteLine(C3c.trim);			//只读
		    //不传参是个好文明
		    
		    // 静态构造函数/方法
		    WriteLine(C3c.next);
		    WriteLine(C3c.next);
		    WriteLine(C3c.next);
		    WriteLine(C3c.next);
		    WriteLine(C3c.next);
		    WriteLine(C3c.next);
		    WriteLine(C3c.next);
		    WriteLine(new C3c().Next);
		    WriteLine(new C3c().Next);
		    WriteLine(new C3c().Next);
		    WriteLine(new C3c().Next);
		    WriteLine(new C3c().Next);
		    WriteLine(new C3c().Next);
		    
		    // 对象初始化 初始化时必须是能够访问的字段和属性
		    var initC = new C3c { X = 4, Y = 5, Z = 6 };
		    WriteLine($"X: { initC.X }, Y: { initC.Y }, Z: { initC.Z }");
		    
		    // 构造函数 Constructor		析构函数 Destructor
		    // 售前 Before				售后 After
		    // 一般析构是用来实例销毁 清理释放非托管资源的行为
		    // 非托管指 Win32 API的文件句柄 非托管内存块
		    // .NET 类是无法Get it 不需要为类编写 析构函数
		    
		    // READONLY 修饰符 类似JAVA的final 抑或是C的常变量const
		    // 会分配内存 可以在任意位置初始化 但是不能更改 可实例可静态
		    // 只能用于数据成员的字段和属性
		    var initA = new C3c(b: 1, a: 2);							// 1
		    var initB = new C3c(b: new int[] { 1, 2, 5, 4, -3 }, a: 2);	// -3
		    var initD = new C3c(b: new int[5], a: 2);					// 0
		    var initE = new C3c(3, 4, 5, 64, 5, 2, -38, 7);	// 7
		    var initF = new C3c(3);									// 3
		    WriteLine($"initA => { initA.AfterInitNum }\n" +
		              $"initB => { initB.AfterInitNum }\n" +
		              $"initD => { initD.AfterInitNum }\n" +
		              $"initE => { initE.AfterInitNum }\n" +
		              $"initF => { initF.AfterInitNum }" );

		    // 索引器
		    var indexer = new C3c();
		    WriteLine(indexer.getIndex);
		    indexer[1] = "蓝莓小果冻";
		    indexer[-2] = "蓝莓小疙瘩";
		    indexer[3] = "本木栗";
		    indexer[-4] = "Bemly_";
		    WriteLine(indexer.getIndex);
		    indexer.getIndex = "C位？";
		    WriteLine(indexer[Int32.MaxValue]);
		    WriteLine($"{indexer.getIndex}\n" +
		              $"indexer[-8]:{indexer[-8]}		indexer[-7]:{indexer[-7]}\n" +
		              $"indexer[-6]:{indexer[-6]}		indexer[-5]:{indexer[-5]}\n" +
		              $"indexer[-4]:{indexer[-4]}		indexer[-3]:{indexer[-3]}\n" +
		              $"indexer[-2]:{indexer[-2]}		indexer[-1]:{indexer[-1]}\n" +
		              $"indexer[0]:{ indexer[0]}		indexer[1]:{ indexer[1]}\n" +
		              $"indexer[2]:{ indexer[2]}		indexer[3]:{ indexer[3]}\n" +
		              $"indexer[4]:{ indexer[4]}		indexer[5]:{ indexer[5]}\n" +
		              $"indexer[6]:{ indexer[6]}		indexer[8]:{ indexer[8]}\n" +
		              $"indexer[8]:{ indexer[8]}		indexer[9]:{ indexer[9]}");
		    indexer[0] = null;
		    WriteLine(indexer[0]);
		    
		    // 重载索引器 赋值具有传递性
		    indexer.D1 = indexer.D2 = 2;
		    WriteLine($"{indexer.D1}, {indexer.D2}");
		    indexer[-0.0000D, 0F] = 10.355D;
		    WriteLine($"{indexer.D1}, {indexer.D2}");
		    indexer[-20D, 0F] = 10.355D;
		    WriteLine($"{indexer.D1}, {indexer.D2}");
		    indexer[20D, 0F] = -10.355D;
		    WriteLine($"{indexer.D1}, {indexer.D2}");
		    indexer[0D, -20F] = -10.355D;
		    WriteLine($"{indexer.D1}, {indexer.D2}");
		    indexer[20D, 0F] = 10.355D;
		    WriteLine($"{indexer.D1}, {indexer.D2}");
		    WriteLine(indexer[1D + 1e-5, 0F]);
		    WriteLine(indexer[1D + 1e-6, 0F]);
		    WriteLine(indexer[1D + 1e-6, -1e-2F]);
		    WriteLine(indexer[1D + 1e-6, 0.3F]);
		    
		    // C3e C3c()类外部 也就是C3的成员方法内
		    // C3cc() 指C3c类中的内部类	cf 访问C3cc()的函数	sf 静态访问C3cc()的函数 
		    // 通过实例动态调用 成员方法 从内部访问内部类 C3ccf
		    indexer.C3ccf();
		    // 如果 内部类是private 这里是访问不了的 外部访问成员内部类
		    // 局部函数 不能加修饰符 和JAVA一致
		    // Program.cs(563, 7): [CS0106] 修饰符“public”对该项无效
		    void C3ef() {
			    // var c3cc = new indexer.C3cc();
			    // 已经创建了实例的是不能再在外部创建了

			    // var c3cc = new C3c().C3cc();
			    // JAVA的逻辑不适用 先实例C3c 再实例C3cc

			    var c3cc = new C3c.C3cc();
			    c3cc[1] = 30; c3cc[2] = 40; c3cc.getKeyValue(1); c3cc.getKeyValue(2);
		    }
		    C3ef();
		    
		    // 通过实例静态调用 静态方法 从内部访问内部类 C3ccf
		    C3c.C3ccsf();
		    
		    // 可以是局部静态函数
		    static void C3ecsf() {
			    // indexer.C3ccf();
			    // static 局部函数不能包含对 'indexer' 的引用
			    // 意思是 只能在静态里面创建然后用 不能调用外部的实例
			    var indexer = new C3c();
			    indexer.C3ccf();
			    
			    C3c.C3ccsf();
			    
			    var c3cc = new C3c.C3cc();
			    c3cc[1] = 70; c3cc[2] = 80; c3cc.getKeyValue(1); c3cc.getKeyValue(2);
		    }
		    C3ecsf();
		    
		    // 访问 静态构造函数 实例好的 静态数据成员(C3cc类型的字段)
		    C3c.c3cc[1] = 90; C3c.c3cc[2] = 100; C3c.c3cc.getKeyValue(1); C3c.c3cc.getKeyValue(2);
		    // 成员方法 访问 静态 C3cc的实例 内类访问
		    indexer.c3ccf();
		    // 静态方法 访问 静态 C3cc的实例 内类访问
		    // indexer.c3ccsf();    不能在非 static 上下文中访问 static 方法 'c3ccsf'
		    C3c.c3ccsf();
		    
		    // 内类 成员方法 访问 静态内部类
		    indexer.C3cscf();
		    // 内类 静态方法 访问 静态内部类
		    C3c.C3cscsf();
		    // 类外 成员方法 访问 静态内部类
		    C3c.C3csc.d1 = 170; C3c.C3csc.d2 = 180; C3c.C3csc.getD(1); C3c.C3csc.getD(2);
		    
		    // 分部类和分部类型
		    WriteLine(new C3cp().getI());
		    // 还有分部接口和分部结构
		    // 分部方法 必须在分部类下面 相当于声明和定义分开 先定义再实现
		    // 返回类型只能是void 参数不能有out 只能是私有 不用写修饰符
		    WriteLine(new C3cp().setI(5).getI());
		    WriteLine(new C3cp().I.I.I.I.I.I.I.I.setI(new Random().Next()).getI());
		    
		    // 已存在的称为基类 新类为派生类 => 继承 所有类都派生至Object类
		    // 继承可以覆盖 父类 的 成员 和java一样只能继承一个父类 基类和派生类是相对术语
		    
		    new C3cpsub().getI();
		    new C3cp("我会输出吗？");				// 会
		    new C3cpsub("我会输出吗？").print(8);  // 会
		    WriteLine(new C3cpsub().baseAccess(-30).baseAccess(-59).I.getI());
		    // 两次baseAccess count计数 每个实例指向一个 所以作用域在整个类范围内
		    // 第壹次返回了一个新的派生类实例 第二次沿用this自生派生类
		    // 然后调用派生类的基类中的I属性，属性返回了该派生类的基类
		    // 然后提升到基类操作(向上提升之后无法再向下降级) getI只有返回值(说明是基类/父类)没有直接打印(说明是派生类/子类)
		    
		    // 和JAVA一样 派生类支持自动向上转型 强制向下转型
		    // is 是返回Boolean布尔值  as 是返回类或者null(不属于该类时)
		    bool isSub(C3cp c) {
			    // JAVA:   c instanceof C3cpsub
			    if (c == null) throw new Exception("类型不能为空");
			    WriteLine($"{c} 属于C3cp {c is C3cp}");
			    if (c is C3cpsub) return true;
			    return false;
		    }

		    C3cp asSub(C3cp c, params int[] i) {
			    C3cp s = c as C3cpsub;
			    if (s == null) return new C3cpsub().baseAccess(i.Length>0?i[0]:0).I.I;
			    return s;
		    }
		    var c3cp = new C3cp();
		    WriteLine($"{c3cp} 是不是子类: {isSub(c3cp)}, {asSub(c3cp)}");
		    c3cp = new C3cpsub();				// 向上转型
		    WriteLine($"{c3cp} 是不是子类: {isSub(c3cp)}, {asSub(c3cp)}");
		    var c3cpsub = new C3cpsub();
		    WriteLine($"{c3cpsub} 是不是子类: {isSub(c3cpsub)}, {asSub(c3cpsub)}");
		    try {
			    c3cpsub = (C3cpsub)new C3cp();		// 向下转型
			    WriteLine($"{c3cpsub} 是不是子类: {isSub(c3cpsub)}, {asSub(c3cpsub)}");
		    }
		    catch (Exception e) { WriteLine(e); }
		    finally { WriteLine($"目前的c3cpsub是: { c3cpsub }"); }
		    
		    // 返回是基类 但是类型还是派生类 然后方法用不了子类的了
		    WriteLine(asSub(asSub(new C3cpsub2(), 5)).I.I is C3cpsub);
		    
		    // 不堪重负了 这个文件，去其他文件写了，眼花缭乱的
		    MyClass.myClass();
	    }
	    class C3c {
		    private   const int SYSJCYCL = 1;	// 私有数据成员常量
		    public    const int GGSJCYCL = 2;	// 公共数据成员常量
					  const int MRSJCYCL = 3;	// 默认数据成员常量(私有)
			internal  const int WBSJCYCL = 4;	// 外部数据成员常量
			protected const int JCSJCYCL = 5;	// 继承数据成员常量
			protected internal const int CL = 6;// 外部继承数据成员常量
			// 常量const不是修饰符 是声明一部分 不占内存 编译时会被编译器替换
			
			private   static int SYJTSJCYBL = 1;	// 私有静态数据成员变量
		    public    static int GGJTSJCYBL = 2;	// 公共静态数据成员变量
					  static int MRJTSJCYBL = 3;	// 默认静态数据成员变量(私有)
			internal  static int WBJTSJCYBL = 4;	// 外部静态数据成员变量
			protected static int JCJTSJCYBL = 5;	// 继承静态数据成员变量
			protected internal static int JTBL = 6; // 外部继承静态数据成员变量
			
			private   static void SYJTHSCYFF() {}	// 私有静态函数成员方法
		    public    static void GGJTHSCYFF() {}	// 公共静态函数成员方法
					  static void MRJTHSCYFF() {}	// 默认静态函数成员方法(公共)
			internal  static void WBJTHSCYFF() {}	// 外部静态函数成员方法
			protected static void JCJTHSCYFF() {}	// 继承静态函数成员方法
			protected internal static void JTFF() {}// 外部继承静态函数成员方法
			
			private   void SYHSCYFF() {}	// 私有函数成员方法
		    public    void GGHSCYFF() {}	// 公共函数成员方法
		              void MRHSCYFF() {}	// 默认函数成员方法(公共)
			internal  void WBHSCYFF() {}	// 外部函数成员方法
			protected void JCHSCYFF() {}	// 继承函数成员方法
			protected internal static void H() {}// 外部继承函数成员方法
			
			// 属性  字段使用 Camel myValue 属性使用 Pascal MyValue
			private static int myValue;
			public static int MyValue {
				set { myValue = value; }
				get { return myValue; }
			}
			
			// C# 7.0 新增 lambda 表达函数体 只能承载一个表达式
			private static int oneValue;
			public static int OneValue {
				set => oneValue = value > 100 ? 100 : value > 30 ? 30 : value > 0 ? value : oneValue;
				get => oneValue;
			}
			
			// 隐式传参 方法！ 类似js
			private static string Str;
			public static string trim {
				get => Str.Trim();
			}
			public static string str {
				set => Str = value;
			}
			
			//自动实现属性
			public static int value { set; get; }
			
			// 静态构造函数 不允许加修饰符 一个类只能带一个 且必须无参 初始化是在任何实例和静态成员之前
			private static readonly Random R;
			public static readonly C3cc c3cc;
			static C3c() {
				// 例如 程序每次运行的时候随机生成一个随机数
				// 然后每个实例都采用这个随机数
				R = new Random();
				// 必须是静态成员才能访问哦
				c3cc = new C3cc();
			}
			public static int next {
				get => R.Next();
			}
			public int Next {
				get => R.Next();
			}
			
			// 对象初始化 初始化时必须是能够访问的字段和属性
			public int X = 1;
			public int Y = 2;
			public int Z { set; get; }
			
			// readonly
			private readonly double PI = 3.1415926;
			private readonly int AFTERINITNUM;
			public int AfterInitNum { get => AFTERINITNUM; }
			public C3c(int a, params int[] b) {
				if (b.Length > 0) AFTERINITNUM = b[b.Length - 1];
				else AFTERINITNUM = a;
			}
			// 如果没写构造函数 默认构造函数是无参的 编译器会帮你加上
			// 如果写了还需要自己把无参的构造函数功能给加上
			public C3c() {}
			
			// 索引器	和属性类似，使用索引运算符而不是点运算符，让人感觉 啊这个实例好像一个数组诶
			// 是get/set访问器 是实例成员 不能声明为static 没有名称 关键字是this 参数必须声明一个
			// 索引器和属性：都不用分配内存 属性针对单个数据成员 索引器针对多个数据成员
			private string 我;
			private string 是;
			private string 索;
			private string 引;
			private string defaultString;
			public string this [int index] {
				set { switch (index) {
					case 1: case -1: 我 = value; break;
					case 2: case -2: 是 = value; break;
					case 3: case -3: 索 = value; break;
					case 4: case -4: 引 = value; break;
					default: defaultString = value; WriteLine("找茬是吧"); break;
				}}
				get { switch (index) {
					case 1: case -1: return 我;
					case 2: case -2: return 是;
					case 3: case -3: return 索;
					case 4: case -4: return 引;
					default: return defaultString;
				}}
			}
			public string getIndex {
				get => $"我: { 我 }, 是: { 是 }, 索: { 索 }, 引: { 引 }";
				set => defaultString = value;
			}
			
			// 索引器重载
			private double d1;
			private double d2;
			public double this [double Id, float If] {
				get => Id is > 1D - 1e-5 and < 1e-5 + 1 ? d1 + d2 : If + Id < 5 && If < Log(Id) ? If > 0 ? d1 : d2 : d1 - d2;
					// 浮点数比较要看误差 Id == 1  构造一个三角形的索引
				set => Id = value > 0 ? (d1 = value > Id ? value - Id : -d2) : (d2 = value > If ? value - If : -d1);
			}
			public double D1 { set => d1 = value; get => d1; }
			public double D2 { set => d2 = value; get => d2; }

			// C# 只有成员内部类 静态成员内部类；没有匿名内部类(可以用匿名函数代替) 没有局部内部类
			// 内部类的访问修饰符可以是public、internal。因为内部类默认修饰符是private，所以默认是错误的(指类外访问)
			// 因为protected是自身和子类可以访问，所以protected也是错误的。(指类外访问)
			// 成员内部类
			public class C3cc {
				private int d1;
				private int d2;
				public int this[int i] {
					set => i = i == 1 ? d1 = value : i == 2 ? d2 = value : throw new Exception("没有此索引");
					private get => i == 1 ? d1 : i == 2 ? d2 : throw new Exception("没有此索引");  // 之后再了解switch新语法 箭头switch JAVA也有 很方便
				}
				// getter/setter访问器继承索引器/属性的权限修饰符，也可以自己单独指定修饰符来覆盖掉
				public int getKeyValue(int i) {
					WriteLine(i = this[i]);		// 把 键 变成 值
					return i;					// 把get访问器的权限通过该成员方法扩散出去
				}
			}
			// 成员方法 类内 访问 成员内部类
			public void C3ccf() {
				var c3cc = new C3cc();			//创建实例
				c3cc[1] = 10;					//索引器赋值
				c3cc[2] = 20;
				try { c3cc[0] = 30; } catch (Exception e) { WriteLine(e); } // 此处捕获到该异常 但是不抛出
				c3cc.getKeyValue(1);
				c3cc.getKeyValue(2);
				try { c3cc.getKeyValue(0); } catch (Exception e) { WriteLine(e); }
			}
			
			// 静态方法 内类 访问 成员内部类
			public static void C3ccsf() {
				var c3cc = new C3cc();	// 静态方法创建内部类的实例
				c3cc[1] = 50;
				c3cc[2] = 60;
				c3cc.getKeyValue(1);
				c3cc.getKeyValue(2);
			}

			// 成员方法 访问 静态 C3cc的实例 内类访问
			public void c3ccf() {
				c3cc[1] = 110; c3cc[2] = 120; c3cc.getKeyValue(1); c3cc.getKeyValue(2);
			}
			public static void c3ccsf() {
				c3cc[1] = 110; c3cc[2] = 120; c3cc.getKeyValue(1); c3cc.getKeyValue(2);
			}
			
			// 静态内部类，就是静态类，静态类不能new，而且静态类里的非静态成员变量也没什么用，所以只能是静态类+静态变量。
			public static class C3csc {
				// public int this[int i] { }		索引器不支持static 所以静态类不能用
				public static int d1 { set; get; }
				public static int d2 { set; get; }
				// 属性支持 static
				public static void getD(params int[] i) {
					int w(int w) { WriteLine(w); return w; }
					if (i.Length > 0) {
						i[0] = i[0] switch {
							1 => w(d1), 2 => w(d2), _ => throw new Exception("非法参数")
						};
					} else WriteLine($"d1: {d1}, d2: {d2}");
					// 新语法: 箭头switch 
					/*  <需要赋值的字段> = <Switch判断的字段> switch {
					 *    <和字段==的常量！！！> => 返回语句, (逗号结尾，就像对象一样)
					 *    _ => default语句 (最后一句不用加逗号,就像对象 JSON一样)
					 *  };
					 */
				}
			}

			// 内类 成员方法 访问 静态内部类
			public void C3cscf() {
				C3csc.d1 = 130; C3csc.d2 = 140; C3csc.getD();
			}

			// 内类 静态方法 访问 静态内部类
			public static void C3cscsf() {
				C3csc.d1 = 150; C3csc.d2 = 160; C3csc.getD(1); C3csc.getD(2);
			}
	    }
	    partial class C3cp {
		    protected int i = 5;
		    private int num1;
		    protected int num2 = -10;
		    partial void print(int i);
	    }
	    partial class C3cp {

		    public C3cp I { get => this; }
		    // static 不能使用 this
		    
		    public int getI() {
			    return i;
		    }
		    
		    partial void print(int i) {
			    WriteLine($"设置成功 i => {i}.");
		    }

		    public C3cp setI(int i) {
			    this.i = i;
			    print(i);
			    return this;
		    }

		    public C3cp() {}

		    public C3cp(string s) {
			    WriteLine(s);
		    }
	    }

	    class C3cpsub : C3cp {
		    // 覆盖可以改变类型 如果参数不一致就成方法重载了 然后如果没有new的话会出被隐藏的警告
		    // new就是显式告诉编译器 你要覆盖掉这个方法 字段同理
		    public void getI() {
			    WriteLine(i);
		    }
		    protected new int num1; // 此处显示new冗余 是 因为父类是private 反正子类也访问不到 不在该作用域
		    public new int num2 = -20;	// protected被子类访问到了 然后子类覆盖掉这个父类数据成员public出去

		    public void print(int i) {
			    new C3cp().setI(i); // 只是在子类新开辟一个父类的实例 数据还是存放在新实例的 不会改变子类实例的数据成员
		    }

		    private static int count = 1;
		    public C3cpsub baseAccess(int num2) {
			    WriteLine($"父类: { base.num2 }, 子类: { this.num2 }, 传入参数: { num2 }");
			    return count++ > 1 ? new C3cpsub() : this;
		    }
		    
		    public C3cpsub() {}
		    // 调用父类的构造函数
		    public C3cpsub(string s) : base(s) {
			    WriteLine("那我呢？我在父类的前面输出还是后面？"); // 后面
		    }
	    }
	    class C3cpsub2 : C3cp {}
    }
}
using System;
using static System.Console;

namespace studemo;

public class LearnArray {
    public static void learn() {
        //数组: 元素 维度(秩) 维度长度 数组长度
        // 一维数组: 单行元素/元素向量 多维=> subarray
        // 多维: 矩形数组rectangular[,,] 和 交错数组jagged[][][]
        // 数组实例由System.Array继承 数组从BCL基类派生
        // Rank 维度      Length 长度

        // JAVA: 左侧可用var代替
        // int[] arr = new int[4];
        // int[][] arr2 = new int[4][];
        // int[][][] arr3 = new int[2][][];
        // int[] arr4 = new int[]{1,2,3};
        // int[][] arr5 = new int[][]{{1},{2},{3}};
        // int[] arr6 = { 1,2,3 };
        // int[][] arr7 = {{1},{2},{3}};
        // var arr = new int[4];
        // var arr2 = new int[4][];
        // var arr3 = new int[2][][];
        // var arr4 = new int[]{1,2,3};
        // var arr5 = new int[][]{{1},{2},{3}};
        // 下面这俩不能用var 因为替换之后缺少int 编译器无法识别
        // int[] arr6 = { 1,2,3 };
        // int[][] arr7 = {{1},{2},{3}};
        // 下面这个只能用前者 后者是C的
        // char[] arrc = new char[3];   V
        // char[] arrb = { " " };       X
        // 可以先声明后初始化/赋值/定义
        // int[][] x; x = {{}};

        // C: C特有的Char数组里面塞字符串String 且只能在声明的时候定义/初始化/赋值 无var
        // 可以声明和初始化允许值不一致 以声明为准 多的溢出 现代编译器有安全扩容 空的默认为0
        // char S[] = { " " }; char S[] = { '','','' };
        // int x[] = {1,2,3};·
        // int xy[3] = {};

        // C# 作为面向对象语言 特征和JAVA类似 是在数组类型写维度/秩说明符 与C/C++不同
        // 可以先声明在初始化
        int[] arr;
        arr = new int[4];
        // 动态创建矩形数组 ,,, 声明不用初始化/实例化(数组其实也是派生而来的)长度
        int[,,] arr2 = new int[3, 7, 2]; // 可以像三元坐标那样去用
        WriteLine(arr2.Length); // 长度就是3*7*2=42
        arr2[2, 4, 1] = 4; // 注意的是 创建长度的时候是从1开始，但是序号/坐标是从0开始
        WriteLine(arr2[2, 3, 1]); // 默认为0
        var count = 1;
        foreach (var VARIABLE in arr2) WriteLine($"arr2=> {count++} : {VARIABLE}");
        count = 1;
        // 静态创建数组 显式初始化=>指明维度和向量
        var intArr = new int[,,] { };
        foreach (var VARIABLE in intArr) WriteLine($"intArr=> {count++} : {VARIABLE}");
        count = 1;
        int[,,] intArr2 = new int[,,] { { { 1 } } }; // 如果int[,,]有类型说明 后面可以省略 和JAVA一致
        foreach (var VARIABLE in intArr2) WriteLine($"intArr2=> {count++} : {VARIABLE}");
        // 矩形数组的好处就是不用考虑null问题

        // 隐式初始化
        var intArr3 = new[,,] { { { 1 } } };
        int[,,] intArr4 = { { { 1 } } };
        WriteLine(intArr3 == intArr4);
        WriteLine(intArr3.GetHashCode());
        WriteLine(intArr4.GetHashCode());
        foreach (var VARIABLE in intArr3) WriteLine($"intArr3=> {count++} : {VARIABLE}");
        foreach (var VARIABLE in intArr4) WriteLine($"intArr4=> {count++} : {VARIABLE}");
        WriteLine((intArr3 = intArr4) == intArr4);
        WriteLine(intArr3.GetHashCode());
        WriteLine(intArr4.GetHashCode());

        var cArr = new[,,] {
            { { 'A', 'B' }, { 'C', 'D' }, { 'E', 'F' } },
            { { 'A', 'B' }, { 'C', 'D' }, { 'E', 'F' } },
            { { 'A', 'B' }, { 'C', 'D' }, { 'E', 'F' } },
            { { 'A', 'B' }, { 'C', 'D' }, { 'E', 'F' } }
        };
        for (int i = 0; i < 4; i++)
        for (int j = 0; j < 3; j++)
        for (int k = 0; k < 2; k++)
            WriteLine($"[{i},{j},{k}] : {cArr[i, j, k].ToString()}");

        // 交错数组和其他语言大差不差 不能初始化顶层数组以外的数组 是不规则 包含矩形
        // var jagArr  = new int[][][5];       X
        // var jagArr2 = new int[][5][];       X
        var jagArr = new int[5][][]; //        V
        // var jagArr4 = new int[5][5][5];     X
        jagArr[0] = new int[4][]; // [0][4][] 动态的每个维度 同一个维度长度可以改变 
        jagArr[0][3] = new int[3];
        jagArr[0][3][0] = 2;
        jagArr[0][2] = new[] { 1 }; // 隐式初始化
        jagArr[1] = new int[5][];
        jagArr[2] = new[] { new[] { 2 }, new[] { 3 } }; // 隐式初始化
        WriteLine(jagArr.Length); // 5
        WriteLine(jagArr[0].Length); // 4
        WriteLine(jagArr[0][3].Length); // 3
        WriteLine(jagArr[0][2].Length); // 1
        WriteLine(jagArr[1].Length); // 5
        WriteLine(jagArr[2].Length); // 2

        // foreach (var i in jagArr) foreach (var j in i) foreach (var v in j) WriteLine(v);
        // for (int i = 0; i < jagArr.Length; i++)
        //     for (int j = 0; j < jagArr[i].Length; j++)
        //         for (int k = 0; k < jagArr[i][j].Length; k++)
        //             WriteLine($"[{i},{j},{k}] : {jagArr[i][j][k].ToString()}");
        // 未将对象引用设置到对象的实例。
        //
        // --- EXCEPTION #1/1 [NullReferenceException]
        // Message = 未将对象引用设置到对象的实例。
        // ExceptionPath = Root
        // ClassName = System.NullReferenceException
        // HResult = 80004003
        // Source = studemo
        // StackTraceString = “在 studemo.LearnArray.learn() 位置 E:\Csharp\studemo\studemo\LearnArray.cs:行号 103”
        //
        //
        // Error: JetBrains Launcher could not run. 未将对象引用设置到对象的实例。

        // 这个数组没有初始化完全完成 有些地方还是null 所以返回不到
        for (int i = 0; i < jagArr.Length; i++)
            if (jagArr[i] != null)
                for (int j = 0; j < jagArr[i].Length; j++)
                    if (jagArr[i][j] != null)
                        for (int k = 0; k < jagArr[i][j].Length; k++)
                            WriteLine($"[{i},{j},{k}] : {jagArr[i][j][k].ToString()}");

        foreach (var i in jagArr)
            if (i != null)
                foreach (var j in i)
                    if (j != null)
                        foreach (var v in j)
                            WriteLine(v);

        // 交错夹矩形
        var jagRetangle = new char[4][,,];
        jagRetangle[0] = cArr;

        for (int i = 0; i < jagRetangle.Length; i++)
            if (jagRetangle[i] != null)
                for (int j = 0; j < jagRetangle[i].GetLength(0); j++)
                for (int k = 0; k < jagRetangle[i].GetLength(1); k++)
                for (int l = 0; l < jagRetangle[i].GetLength(2); l++)
                    WriteLine($"[{i}][{j},{k},{l}] : {jagRetangle[i][j, k, l].ToString()}");

        // 矩形数组的好处就是不用考虑null问题
        // 矩形数组只占一个对象 交错数组你初始化几个就是几个对象 CIL中对交错数组有单独的优化 所以有些时候交错效率更高
        // 矩形的复杂度低 直接被看作一个单元 而不是数组的数组

        subLearn();
    }

    /////////////////////////////////////////////////////////////////////////////////////////

    class A {}

    class B : A { public string name { set; get; } }
    
    class C {}

    class D {
        private int[] x = new int[10];
        public int this [int i] {
            get => x[i];
            set => x[i] = value;
        }

        private int[,] y = new int[10,10];
        public int this[int x, int y] {
            get => this.y[x, y];
            set => this.y[x, y] = value;
        }
    }

    public static void subLearn() {
        
        // 数组协变 只支持引用类型 比如enum,struct没有协变
        var Arr1 = new A[3];
        var Arr2 = new A[3];
        // 普通: A对象 => A 数组
        Arr1[0] = new A(); Arr1[1] = new A(); Arr1[2] = new A();
        // 协变: B对象 => A 数组 (自动向上转型 多态调用)
        Arr2[0] = new A(); Arr2[1] = new B(); Arr2[2] = new B();
        WriteLine(Arr2[2].GetType() + "@" + Arr2[2].GetHashCode());
        Arr1[1] = Arr2[2];
        WriteLine(Arr1[1].GetType() + "@" + Arr1[1].GetHashCode());
        // Arr1[1] = new C();       不是派生和基不能转型
        var Brr1 = new B[3];
        // Brr1[0] = (B)new A(); Brr1[1] = (B)new A(); Brr1[2] = (B)new A();
        //无法将类型为“A”的对象强制转换为类型“B”。
        // WriteLine(Brr1[1].GetType() + "@" + Brr1[1].GetHashCode());
        B a, b, c; a = b = c = new B();     // 穿透的引用是一样的
        WriteLine(a.GetType() + "@" + a.GetHashCode());
        WriteLine(b.GetType() + "@" + b.GetHashCode());
        WriteLine(c.GetType() + "@" + c.GetHashCode());
        A d = a, e = b, f = c;
        WriteLine(d.GetType() + "@" + d.GetHashCode());
        WriteLine(e.GetType() + "@" + e.GetHashCode());
        WriteLine(f.GetType() + "@" + f.GetHashCode());
        Brr1[0] = (B)d; Brr1[1] = (B)e; Brr1[2] = (B)f; // 转两次转回去就不会报错
        Brr1[0].name = "Brr1这个没头脑，三个数组全部指向我一个 哈哈";
        WriteLine(Brr1[0].name+Brr1[1].name+Brr1[2].name);

        // 索引器和数组不一样哦 一个是数组里面放实例 一个是实例里面自定义索引
        // 猜猜这是交错数组里面放了矩形数组 矩形数组里面又放了交错数组吗
        var arr = new D[2][,];
        arr[1] = new D[1, 2];
        arr[1][0, 1] = new D();
        arr[1][0, 1][2] = 4;
        WriteLine(arr[1][0, 1][2]);
        arr[1][0, 1][2, 3] = 6;
        WriteLine(arr[1][0, 1][2, 3]);
        
        // 哈哈 我创了个一维数组 里面有8个元素
        // 傻der 这是八维数组 一个对象
        var arro = new int[1,2,3,5,4,6,7,8];
        WriteLine($"一共有 { arro.Length.ToString() } 个元素。");

        /////////////////////////////////////////////////////////////////////////////////////////

        // 数组继承有用成员
        // 实例 属性: Rank 维度, Length 长度
        // 实例 方法: GetLength 每维长度, Clone 浅复制(JSON有个深拷贝), GetUpperBound 指定维度上限
        // 静态 方法: Clear 设为0/null, BinarySearch 二进制搜一维数组的值, IndexOf 一维数组中第一个值, Reverse 反转一维数组某范围元素
        
        // Clone 浅复制: 不会复制元素引用对象
        // JSON 深拷贝: 转换过来再转换回去 会创建新的对象
        
        // 数组与ref返回和ref局部变量
        var scores = new []{ 5, 80 };
        WriteLine($"Before: { scores[0].ToString() }, { scores[1].ToString() }");
        ref int h = ref PointerToHighestPositive(scores);
        h = 0;
        WriteLine($"After: { scores[0].ToString() }, { scores[1].ToString() }");
    }

    public static ref int PointerToHighestPositive(int[] num) {
        int h = 0;
        int I = 0;

        for (int i = 0; i < num.Length; i++) {
            if (num[i] > h) {
                I = i;
                h = num[I];
            }
        }

        return ref num[I];
    }
}
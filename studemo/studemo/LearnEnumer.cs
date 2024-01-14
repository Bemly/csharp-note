using System;
using System.Collections;
using System.Collections.Generic;
using static System.Console;

namespace studemo; 

public class LearnEnumer {
    public static void learn() {
        // 实现IEnumerator接口的枚举器包括三个成员:
        // MoveNext 把枚举器位置前进到下一个位置 就像核糖体一样 返回bool 位置有效true 溢出false 初始位置在第一项之前-1 要最先执行
        // Current 返回当前项属性,类型为object 只读
        // Reset 把位置重置到初始位置
        // 数据成员: position 记录位置 私有 封装
        int[] arr1 = { 10, 20, 30, 40, 50 };
        var ie = arr1.GetEnumerator();      // 里面指定返回数组实现的接口
        while (ie.MoveNext()) WriteLine($"Item value = { ie.Current }");
        
        // IEnumerable接口只有一个成员
        var spectrum = new Spectrum();
        foreach (var color in spectrum) WriteLine(color);
        
        // 可枚举类和枚举器被广泛使用 C#2.0出了一个更加方便的 迭代器iterator
        new LearnEnumer().learnIterator();
    }
    
    // 枚举器
    class ColorEnumerator : IEnumerator {
        private string[] _colors;
        private int position = -1;
        public ColorEnumerator(string[] theColors) {
            _colors = new string[theColors.Length];      // 浅拷贝  
            for (int i = 0; i < theColors.Length; i++) _colors[i] = theColors[i];
        }

        // 属性 Current默认关键字 覆盖掉 然后方法赋值兼容性
        public object Current {
            get {
                if (position == -1) {
                    throw new InvalidOperationException();
                }

                if (position >= _colors.Length ) {
                    throw new InvalidOperationException();
                }

                return _colors[position];
            }
        }

        public bool MoveNext() {
            if (position < _colors.Length - 1) {
                position++;
                return true;
            } else {
                return false;
            }
        }

        public void Reset() {
            position = -1;
        }
        
        public IEnumerator GetEnumerator() {
            throw new NotImplementedException();
        }
    }

    // 可枚举 的 类
    class Spectrum : IEnumerable {
        private string[] Colors = { "red", "blue", "black" };

        public IEnumerator GetEnumerator() {
            return new ColorEnumerator(Colors);
        }
    }

    // 枚举器接口 这个Z属于实现IZ接口的实例/类 所以可以返回 向上转型
    interface IZ {}
    class Z : IZ {
        public IZ z() {
            return this;
        }
    }
    
    /////////////////////////////////////////////////////////////////////////////////////////

    public void learnIterator() {
        // 迭代器返回一个泛型枚举器
        // yield 迭代器块 return 指定序列下一项 break 指定序列没有其他项
        var le = new LearnEnumer();
        foreach (var shade in le) WriteLine(shade);
        
        // 使用迭代器创建可枚举类型
        var mc = new MyClass();
        foreach (var v in mc) WriteLine(v);
        foreach (var v in mc.enumerator()) WriteLine(v);
        
        // 一个类/结构只能有一个枚举器 可以有多个可枚举类型(对象)/迭代器(简写可枚举类型)
        var myc = new MyyClass();
        foreach (var VARIABLE in myc.normalOutput()) Write($"{VARIABLE} ");
        WriteLine();
        foreach (var VARIABLE in myc.reserveOutput()) Write($"{VARIABLE} ");
        WriteLine();
        
        // 可以将迭代器作为属性 但是只能有一个迭代器 所以可以加上判断 每个实例创建时使用对应的迭代器
    }

    public IEnumerator<int> OneTwoThree() {
        yield return 10;
        yield return 20;
        yield return 30;
    }
    public IEnumerator<int> OneTwoThree2() {
        int[] theNums = { 10, 20, 30 };
        for (int i = 0; i < theNums.Length; i++) yield return theNums[i];
    }
    
    public IEnumerator GetEnumerator() => new LearnEnumer().OneTwoThree();

    class MyClass : IEnumerable {
        string[] theNums = { "10", "20", "30" };
        public IEnumerable<string> enumerator() {
            for (int i = 0; i < theNums.Length; i++) yield return theNums[i];
        }

        // 这个关键字是不能改的 其中new MyClass可以省略 因为已经是实例了 直接在实例调用这个方法就行
        public IEnumerator GetEnumerator() => new MyClass().enumerator().GetEnumerator();
    }
    
    /////////////////////////////////////////////////////////////////////////////////////////

    class MyyClass {
        private int[] arr = { 100, 200, 300 };

        public IEnumerable<int> normalOutput() {
            for (int i = 0; i < arr.Length; i++) yield return arr[i];
        }

        public IEnumerable<int> reserveOutput() {
            for (int i = arr.Length - 1; i >= 0; i--) yield return arr[i];
        }
    }
}
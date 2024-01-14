using System;
using static System.Console;

namespace studemo; 

public class LearnEnum {

    enum MyEnum {
        A, B, C, D, E, F
    }
    
    enum MyEnum2 : ushort {
        A, B, C, D, E, F
    }
    
    enum MyEnum3 : ushort {
        Green = 1,
        Red = 1,
        Origin = UInt16.MaxValue,
        // hh = (Int16)(UInt16.MaxValue + 1),
        //  LearnEnum.cs(20, 14): [CS0221] 常量值“65536”无法转换为“short”(使用 "unchecked" 语法重写)
        //  LearnEnum.cs(20, 14): [CS0266] 无法将类型“short”隐式转换为“ushort”。存在一个显式转换(是否缺少强制转换?)
        Black = 1 - 1
    }
    
    enum MyEnum4  {
        a,b,c,
        A = (int)UInt32.MinValue,
        B = Int32.MinValue, 
        C,
        D
        
    }
    
    /////////////////////////////////////////////////////////////////////////////////////////

    public static void learn() {
        // 枚举差不多就是js的对象 但是只能存命名的整数值常量一种类型 栈的排列是 第一个元素在最底下 最后一个在栈顶
        var a = MyEnum.A;
        WriteLine($"{a} : {(int)a}");
        WriteLine($"{MyEnum.B} : {(int)MyEnum.B}\n" +
                  $"{MyEnum.C} : {(int)MyEnum.C}\n" +
                  $"{MyEnum.D} : {(int)MyEnum.D}\n" +
                  $"{MyEnum.E} : {(int)MyEnum.E}\n" +
                  $"{MyEnum.F} : {(int)MyEnum.F}\n");
        
        WriteLine($"{MyEnum2.A} : {(int)MyEnum2.A}\n" +
                  $"{MyEnum2.B} : {(int)MyEnum2.B}\n" +
                  $"{MyEnum2.C} : {(int)MyEnum2.C}\n" +
                  $"{MyEnum2.D} : {(int)MyEnum2.D}\n" +
                  $"{MyEnum2.E} : {(int)MyEnum2.E}\n" +
                  $"{MyEnum2.F} : {(int)MyEnum2.F}\n");
        
        WriteLine($"{MyEnum3.Green} : {(int)MyEnum3.Green}\n" +
                  $"{MyEnum3.Black} : {(int)MyEnum3.Black}\n" +
                  $"{MyEnum3.Origin} : {(int)MyEnum3.Origin}\n" +
                  $"{MyEnum3.Red} : {(int)MyEnum3.Red}\n");
        // 和对象的键值对类似 值可以一样 项/键/名称不能一样
        // 可以是运算表达式 但是必须满足要求
        
        WriteLine($"{MyEnum4.a} : {(int)MyEnum4.a}\n" +
                  $"{MyEnum4.b} : {(int)MyEnum4.b}\n" +
                  $"{MyEnum4.c} : {(int)MyEnum4.c}\n" +
                  $"{MyEnum4.A} : {(int)MyEnum4.A}\n" +
                  $"{MyEnum4.B} : {(int)MyEnum4.B}\n" +
                  $"{MyEnum4.C} : {(int)MyEnum4.C}\n" +
                  $"{MyEnum4.D} : {(int)MyEnum4.D}\n");
        // 如果没有指明 默认编号从第一个显式初始化开始 然后依次累加 如果后面有重复的就+1直到没有重复的 如果中途显式初始化指定了新的 则用新的+1判断
        // 默认为0开始 用的Int32 也就是int
        
        // 位标志 一般用single word不同位表示一组开关标志的紧凑方法 我称之为标志字 flag word
        // 1 word = 2 Byte = 16 Bit = 1 short/Int16
        // 1 dword = 32 Bit = 1 int/Int32
        // 1 qword = 2 dword = 4 word = 64 Bit = 1 long/Int64
        // 按位或 & AND
        // 按位与 | OR
        // 处理位模式 一般采用16Hex进制表示法 采用Flags 特性装饰decorate

        // var 枚举类型 ops 标志字 位标志 或 在一起
        var ops = CardDeckSetting.SingleDeck
                  | CardDeckSetting.FancyNumbers
                  | CardDeckSetting.Animation;
        // 这仨或在ops里
        var useFancyNumbers = ops.HasFlag(CardDeckSetting.FancyNumbers);
        WriteLine($"{ ops } : { useFancyNumbers }");
        var useLargePictures = ops.HasFlag(CardDeckSetting.LargePictures);
        WriteLine($"{ ops } : { useLargePictures }");
        // Large 不在ops里

        // HasFlag 跟 标志位
        var testFlags = CardDeckSetting.Animation | CardDeckSetting.FancyNumbers;
        var useAnimationAndFancyNumbers = ops.HasFlag( testFlags );
        //标志位跟标志位比较 这俩都包含在ops里
        WriteLine($"{ testFlags } : { useAnimationAndFancyNumbers }");
        
        testFlags = CardDeckSetting.Animation | CardDeckSetting.LargePictures;
        useAnimationAndFancyNumbers = ops.HasFlag( testFlags );
        WriteLine($"{ testFlags } : { useAnimationAndFancyNumbers }");
        
        testFlags = CardDeckSetting.Animation & CardDeckSetting.LargePictures; // 与就为0
        useAnimationAndFancyNumbers = ops.HasFlag( testFlags );
        WriteLine($"{ testFlags } : { useAnimationAndFancyNumbers }");
        
        testFlags = CardDeckSetting.Animation & CardDeckSetting.Nothing;       // 只有Animation
        useAnimationAndFancyNumbers = ops.HasFlag( testFlags );
        WriteLine($"{ testFlags } : { useAnimationAndFancyNumbers }");
        
        // & 两个都1才1与     | 两个都0才0/一个1就1或    ~取反     ^两位相同0,相对1 异或
        testFlags = ~ CardDeckSetting.Anything;
        useAnimationAndFancyNumbers = ops.HasFlag( testFlags );                // 取反是所有32位取反 这个没有对应的 所以直接给值了
        WriteLine($"{ testFlags } : { useAnimationAndFancyNumbers }");

        WriteLine(Convert.ToString((int)ops,2));
        WriteLine(Convert.ToString((int)(CardDeckSetting.FancyNumbers),2).PadLeft(4,'0'));
        WriteLine(Convert.ToString((int)(ops&CardDeckSetting.FancyNumbers),2).PadLeft(4,'0'));
        WriteLine($"{ (ops & CardDeckSetting.FancyNumbers) == CardDeckSetting.FancyNumbers }");
        // 三个或 0b1101 & 0b0100 => 0b0100 == 0b0100
        
        // Flags 特性 按位 才能这么玩
    }
    
    /////////////////////////////////////////////////////////////////////////////////////////
    
    [Flags]
    enum CardDeckSetting : uint {
        SingleDeck    = 0b0001, //0x01 位0
        LargePictures = 0b0010, //0x02 位1
        FancyNumbers  = 0b0100, //0x04 位2
        Animation     = 0b1000,  //0x08 位3
        Nothing       = 0b1111,
        Anything      = 0b1110
    }
}
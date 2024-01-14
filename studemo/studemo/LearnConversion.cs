using System;
using static System.Console;

namespace studemo; 

public class LearnConversion {
    // version 版本 transform 转换 但不是我们今天要学的 conversion
    public static void learn() {
        // 动态类型语言：没我事了，那我走（？        []{}!={}[]害怕 你永远不知道程序员在想什么
        // 加入TypeScript 荣光的革命之路吧（（（（（ 
        // 转换: 就是转换类型 为泛型打基础 从源Source到目标Dist类型
        
        // 溢出检测上下文 unchecked 就不检测抛出错误
        var u = 1000000000000;
        try { var uc = checked( (ushort)u ); } catch (Exception e) { WriteLine(e); }
        var ucc = unchecked( (ushort)u );
        
        // 引用类型转换 也就是上下转型 自己看JAVA 一致的
        
        // 除了 标准转换 还有 预定义 的类型转换 叫做 装箱
        // 装箱Boxing: 值类型 => Object 类型/System.ValueType 类型
        // 拆箱: Object 类型/System.ValueType 类型 => 值类型
        // JAVA 有定义好的 String Integer Float Double 这些封装好的箱子Boxing
        // JavaScript是 packing 和 unpacking
        // 如果是自定义Object子类/派生类的拆箱操作 可以覆盖父类/基类的.toString()方法
        object io = 1;      // Boxing allocation: conversion from 'int' to 'object' requires boxing of the value type
        WriteLine(io.GetType());

        int ii = 1;         // 声明定义/初始化 1 基本值类型
        object iio = null;  // 在内存堆空间开辟一个Object的类实例(创建对象)
        iio = ii;           // 把值丢给这个类实例/对象就算装箱了
        WriteLine(iio.GetType());
        WriteLine(iio);     // 自动拆箱 拆箱过程就算逆装箱 略
        
        // 用户自定义转换 => 用到运算符重载
        var herec = new LearnConversion() { age = 20 }; // 静态方法没this 所以这个也相同只能打全称 不然找不到
        int heres = herec;
        WriteLine(heres);
        herec = heres;
        WriteLine(herec.age);
        // 用户自定义转换 可以递归 转换到需要用的类 或者其他更多链式转换各种类型
    }
    // 还是老规矩 重载需要public和static 而且需要在this所在类内 不支持子类
    public int age = 18;
    public static implicit operator LearnConversion(int c) => new(){ age = c };
    public static implicit operator int(LearnConversion c) => c.age;
}

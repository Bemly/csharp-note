#define A // 可以注释
#define B // 可以&注释
// 不能用多行注释
// #define C /* adad & afafa */
// #define D /* adawdawd */
// 取消定义编译符号
#undef A
// 编译符号的范围限制为单个**源**文件
#define B // 可以重复定义
// 和C++/C不同，不表示字符串 定义一个类似true 没有就是false
#pragma warning disable

using static System.Console;
// 静态引用类库
using System;
using System.Threading;

// 动态引用

namespace studemo {
    public class LearnNamespace {
        public static void learn() {
            // 完全限定类名 = 命名空间名 + 类名
            // TODO: 做程序签名 使用的类库等等 还有逆向dll然后魔改dll等等
        }
    }

    // 嵌套命名空间
    namespace MyNamespace1 {}
}
// 分离声明 两者是等价的
namespace MyNamespace2 {}

namespace studemo {
    public class LearnException {
        public static void learn() {
            var x = 1;
            try {
                var y = 0;
                x /= y;
            }
            // 异常过滤器
            catch (Exception e) when( e.Message.Contains("Zero") ) {
                WriteLine("1:" + e);
            } // 这玩意会受文化字段影响 需要对应方法修改 具体看文档
            catch (Exception e) when( e.Message.Contains("零") ) {
                WriteLine("2:" + e);
            }
            WriteLine("a");
        }
    }

    public class LearnDefine {
        public static void learn() {
            // 看文件最上面
            // #define A 不能在文件中第一个令牌后定义/取消定义预处理程序符号
            #if A
            WriteLine("a false");
            #elif B
            WriteLine("b true");
            #else
            WriteLine("else");
            #endif
            
            #if false
            WriteLine("true");
            #elif !A && B || 我说这里可以当作注释用你信吗
            WriteLine("!A&&B==true");
            #warning 类似Todo
            // #error ?
            //  LearnNamespace.cs(68, 20): [CS1029] #错误:“?”
            #endif

            #region first
            #region second
            WriteLine("嵌套");
            #endregion
            #region third
            Thread.Sleep(0);
            #endregion
            #endregion
        }
    }
}
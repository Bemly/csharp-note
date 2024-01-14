using System;
using System.Net;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace studemo;

class MyDownloadString {
    private Stopwatch sw = new Stopwatch();

    public void doRun() {
        sw.Start(); // 开始计时
        var t1 = countChar(1, "https://www.baidu.com");
        var t2 = countChar(2, "https://www.bing.com");
        WriteLine(sw.Elapsed.TotalMilliseconds + " ms");
    }

    private int countChar(int i, string URL) {
        var wc = new WebClient();
        WriteLine($"Starting Call {i}: {sw.Elapsed.TotalMilliseconds, 7:N0} ms");
        var result = wc.DownloadString(new Uri(URL));
        WriteLine($"    Call success {i}: {sw.Elapsed.TotalMilliseconds, 5:N0} ms");
        return result.Length;
    }

    public void doRunForAsync() {
        sw.Start();
        var t1 = countCharForAsync(1, "https://www.baidu.com");
        var t2 = countCharForAsync(2, "https://www.bing.com");
        WriteLine(sw.Elapsed.TotalMilliseconds + " ms");
        WriteLine(t1.Result + t2.Result);
        WriteLine(sw.Elapsed.TotalMilliseconds + " ms");
    }
    
    private async Task<int> countCharForAsync(int i, string URL) {
        var wc = new WebClient();
        WriteLine($"Starting Call {i}: {sw.Elapsed.TotalMilliseconds, 7:N0} ms");
        var result = await wc.DownloadStringTaskAsync(new Uri(URL));
        WriteLine($"    Call success {i}: {sw.Elapsed.TotalMilliseconds, 5:N0} ms");
        return result.Length;
    }

    public static async Task doWorkAsync() {
        // Action
        await Task.Run(() => WriteLine(5));
        // TResult Func()
        WriteLine(await Task.Run(() => 6));
        // Task Func()
        await Task.Run(() => Task.Run(() => WriteLine(7)));
        // Task<TResult> Func()
        var value = await Task.Run(() => Task.Run(() => 8));
        WriteLine(value);
    }
}

public class LearnAsync {
    public static void learn() {
        // 启动程序 系统会在内存中新建一个进程
        // 在进程内部 系统创建了一个称为 线程 的内核Kernel对象 线程全称执行线程
        // 默认情况一个进程只包含一个线程 线程可以派生和被派生 一个进程可能包含多个不同状态的线程
        // 一个进程的多个线程会共享进程的资源
        // async/await 大部分有.NET框架的特性 没有嵌入C#
        // 异步不同于同步的阻塞
        new MyDownloadString().doRun();
        WriteLine("==============");
        // void Task Task<T> ValueTask<T> 占位符 2和3个可以继续执行 方法/匿名方法/lambda表达式可以作为异步对象
        new MyDownloadString().doRunForAsync();
        WriteLine("==============");

        // 一个异步方法可以包含多个await表达式 然后被调用方法调用
        // ValueTask是值类型 可以放在栈上 可以void(fire and forget调用并忘记) 
        var t = MyDownloadString.doWorkAsync();
        t.Wait();
        
        // 协同来取消异步操作
        CancellationTokenSource cts = new (), cts2 = new (), cts3 = new ();
        var mc = new MyClass();
        var T = mc.runAsync(cts.Token);
        Thread.Sleep(3000);
        cts.Cancel();
        T.Wait();
        WriteLine("Cancel success");
        
        var T2 = mc.runAsync(cts2.Token);
        T2.Wait( cts2.Token );
        
        // 同步等待异步任务: Task.WaitAll等待全部 Task.WaitAny等待任何一个 重载方法
        // 异步等待异步任务: await Task.WhenAll WhenAny 支持传参List<Task<T>>
        
        // Task.Delay 不会阻塞线程 可以暂停在线程中的处理
        // Task.Yield => awaitable
        
        // TODO: WPF 异步窗口
    }

    class MyClass {
        public async Task runAsync( CancellationToken ct ) {
            if ( ct.IsCancellationRequested ) return;   // 监控IsCancellationRequested
            await Task.Run(() => {
                const int max = 5;
                for (int i = 0; i < max; i++) {
                    if ( ct.IsCancellationRequested ) return;   // 监控IsCancellationRequested
                    Thread.Sleep(1000);
                    WriteLine($"    { i+1 } of { max } iterations completed");
                }
            }, ct);
        }
    }
}
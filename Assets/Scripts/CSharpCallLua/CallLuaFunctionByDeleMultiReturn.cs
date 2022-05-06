using UnityEngine;
using XLua;

namespace CSharpCallLua
{
    /**
     * Summary: XLua热更 之 C# --> Lua Function
     *      方式一（扩展）：使用delegate的方式映射Lua中含有多个返回值的函数
     *      1、定义out关键字的委托
     *      2、定义ref关键字的委托（引用类型）
     * Create By: Lee
     * Create Time: 2022年05月06日 Friday 15:30
     *========================================
     * Description:
     */

    //自定义委托(使用out关键字来接收)
    [CSharpCallLua]
    public delegate void AddMultiReturn(int num1, int num2, out int res1, out int res2, out int res3);

    //自定义委托(引用类型参数)
    [CSharpCallLua]
    public delegate void AddMultiReturnRef(ref int num1, ref int num2, out int result);

    public class CallLuaFunctionByDeleMultiReturn : MonoBehaviour
    {
        private LuaEnv env;

        private AddMultiReturn addMultiReturn;
        private AddMultiReturnRef addMultiReturnRef;

        private void Start()
        {
            env = new LuaEnv();
            env.DoString("require 'CallByCSharp'");

            //映射函数
            addMultiReturn = env.Global.Get<AddMultiReturn>("ProcMyFunc5");
            addMultiReturnRef = env.Global.Get<AddMultiReturnRef>("ProcMyFunc5");

            int res1, res2, res3;
            //使用out关键字来接收返回值并输出
            addMultiReturn.Invoke(3, 6, out res1, out res2, out res3);
            Debug.Log($"{res1}+{res2}={res3}");

            res1 = 10;
            res2 = 20;
            addMultiReturnRef.Invoke(ref res1, ref res2, out res3);
            Debug.Log($"{res1}+{res2}={res3}");
        }

        private void OnDestroy()
        {
            addMultiReturn = null;
            addMultiReturnRef = null;
            env.Dispose();
        }
    }
}
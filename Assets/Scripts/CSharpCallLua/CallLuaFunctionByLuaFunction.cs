using UnityEngine;
using XLua;

namespace CSharpCallLua
{
    /**
     * Summary: XLua热更 之 C# --> Lua Function
     *      方式二：采用luaFunction方式来映射Lua中的函数
     *      性能不高，不推荐
     * Create By: Lee
     * Create Time: 2022年05月06日 Friday 15:19
     *========================================
     * Description:
     */
    public class CallLuaFunctionByLuaFunction : MonoBehaviour
    {
        private LuaEnv env;

        private void Start()
        {
            env = new LuaEnv();
            env.DoString("require 'CallByCSharp'");

            LuaFunction luaFunction1 = env.Global.Get<LuaFunction>("ProcMyFunc1");
            LuaFunction luaFunction2 = env.Global.Get<LuaFunction>("ProcMyFunc2");
            LuaFunction luaFunction3 = env.Global.Get<LuaFunction>("ProcMyFunc3");
            LuaFunction luaFunction4 = env.Global.Get<LuaFunction>("ProcMyFunc4");

            luaFunction1.Call();
            luaFunction2.Call(1, 2);
            object[] result = luaFunction3.Call(1, 2);
            Debug.Log("result=" + result[0]);
            luaFunction4.Call(1, 2, 3);

            //多返回值
            LuaFunction luaFunction5 = env.Global.Get<LuaFunction>("ProcMyFunc5");
            result = luaFunction5.Call(99, 1);
            Debug.Log($"{result[0]}+{result[1]}={result[2]}");
        }

        private void OnDestroy()
        {
            env.Dispose();
        }
    }
}
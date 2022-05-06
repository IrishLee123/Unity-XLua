using UnityEngine;
using XLua;

namespace CSharpCallLua
{
    /// <summary>
    /// C#->Lua 之获取lua中的table
    /// 方式4：使用LuaTable来映射得到Lua中的table内容。
    /// 优点：功能强大，方便 
    /// 缺点：效率低
    /// </summary>
    public class CallLuaByLuaTable : MonoBehaviour
    {
        private LuaEnv _env;

        private void Start()
        {
            _env = new LuaEnv();
            _env.DoString("require 'CallByCSharp'");
            LuaTable luaTable = _env.Global.Get<LuaTable>("gameUser");

            // 输出变量
            Debug.Log("name=" + luaTable.Get<string>("name"));
            Debug.Log("age=" + luaTable.Get<int>("age"));
            Debug.Log("ID=" + luaTable.Get<string>("ID"));

            //函数
            LuaFunction speakFun = luaTable.Get<LuaFunction>("Speak");
            speakFun.Call();

            LuaFunction walkingFun = luaTable.Get<LuaFunction>("Walking");
            walkingFun.Call();

            //带参方法
            LuaFunction killFun = luaTable.Get<LuaFunction>("Kill");
            killFun.Call(luaTable, "李四");

            //返回值方法
            LuaFunction addFun = luaTable.Get<LuaFunction>("Add");
            object[] result = addFun.Call(luaTable, 5, 10);
            Debug.Log("result=" + result[0]);
        }

        private void OnDestroy()
        {
            _env.Dispose();
        }
    }
}
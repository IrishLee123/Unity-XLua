using UnityEngine;
using XLua;

public class XLuaHelloWorld : MonoBehaviour
{
    // XLua的环境核心类
    LuaEnv _env;

    private void Start()
    {
        _env = new LuaEnv();
        _env.DoString("print('Hello XLua!')");
        //利用XLua调用Unity接口
        _env.DoString("CS.UnityEngine.Debug.Log('Lua Call Unity Log!')");
    }

    private void OnDestroy()
    {
        _env.Dispose();
    }
}
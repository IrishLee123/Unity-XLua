using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

/// <summary>
/// C#->Lua
///  
/// 通过Global.Get方法来获取Lua脚本中的全局变量
/// </summary>
public class CallLuaByGlobalVar : MonoBehaviour
{
    private LuaEnv _env;

    private void Start()
    {
        _env = new LuaEnv();
        _env.DoString("require 'CallByCSharp'");

        string str1 = _env.Global.Get<string>("str");
        Debug.Log("str: " + str1);

        int number = _env.Global.Get<int>("number");
        Debug.Log("number: " + number);

        // int num = _env.Global.Get<int>("num");
        // Debug.Log("num: " + num);

        float floNumber = _env.Global.Get<float>("floNumber");
        Debug.Log("floNumber: " + floNumber);

        bool isFirstTime = _env.Global.Get<bool>("IsFirstTime");
        Debug.Log("IsFirstTime: " + isFirstTime);
    }

    private void OnDestroy()
    {
        _env.Dispose();
    }
}
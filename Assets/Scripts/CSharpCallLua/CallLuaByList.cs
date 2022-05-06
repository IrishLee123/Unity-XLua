using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

/// <summary>
/// C#->lua
/// 如果lua中的表比较简单，可以只用Dictionary<>，或List<>直接进行映射
/// </summary>
public class CallLuaByList : MonoBehaviour
{
    private LuaEnv _env;

    private void Start()
    {
        _env = new LuaEnv();
        _env.DoString("require 'CallByCSharp'");

        List<string> list = _env.Global.Get<List<string>>("cardList");
        foreach (string s in list)
        {
            Debug.Log(s);
        }
    }

    private void OnDestroy()
    {
        _env.Dispose();
    }
}
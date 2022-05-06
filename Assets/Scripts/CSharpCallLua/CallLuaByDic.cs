using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

/// <summary>
/// C#->lua
/// 如果lua中的表比较简单，可以只用Dictionary<>，或List<>直接进行映射
/// </summary>
public class CallLuaByDic : MonoBehaviour
{
    private LuaEnv _env;

    private void Start()
    {
        _env = new LuaEnv();
        _env.DoString("require 'CallByCSharp'");

        Dictionary<string, object> dictionary = _env.Global.Get<Dictionary<string, object>>("weaponTable"); //映射一个简单表

        foreach (string key in dictionary.Keys)
        {
            Debug.Log(key + ": " + dictionary[key]);
        }
    }

    private void OnDestroy()
    {
        _env.Dispose();
    }
}
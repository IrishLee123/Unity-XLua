using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

/// <summary>
/// c#->lua
/// 通过interface映射Lua中复杂的table
/// </summary>
public class CallLuaTableByInterfaceComp : MonoBehaviour
{
    private LuaEnv _env;

    private void Start()
    {
        _env = new LuaEnv();
        _env.DoString("require 'CallByCSharp'");

        //得到lua中的表信息
        IUserInfo table = _env.Global.Get<IUserInfo>("gameUser");
        //输出
        Debug.Log("name" + table.name);
        Debug.Log("age" + table.age);
        Debug.Log("id" + table.ID);
        table.Speak();
        table.Walking();
        table.Kill("李四");
    }

    private void OnDestroy()
    {
        _env.Dispose();
    }

    [CSharpCallLua]
    public interface IUserInfo
    {
        string name { get; set; }
        int age { get; set; }
        string ID { get; set; }

        void Speak();
        void Walking();
        void Kill(string name);
    }
}
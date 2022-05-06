using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

/// <summary>
/// C#->Lua 之获取lua中的table
/// 方式1：使用class(struct)来映射得到Lua中的table内容。
/// 注意此时class中的变量数据空间和table中的变量数据空间是不相同的，即修改class中的变量并不会影响table中的变量
/// </summary>
public class CallLuaTableByClass : MonoBehaviour
{
    private LuaEnv _env;

    private void Start()
    {
        _env = new LuaEnv();
        _env.DoString("require 'CallByCSharp'");

        //得到lua中的表信息
        WeaponTable weaponTable = _env.Global.Get<WeaponTable>("weaponTable");
        //输出
        Debug.Log(weaponTable.weapon1);
        Debug.Log(weaponTable.weapon2);
        Debug.Log(weaponTable.weapon3);
        Debug.Log(weaponTable.weapon4);
    }

    private void OnDestroy()
    {
        _env.Dispose();
    }

    public class WeaponTable
    {
        public string weapon1;
        public string weapon2;
        public string weapon3;
        public string weapon4;
    }
}
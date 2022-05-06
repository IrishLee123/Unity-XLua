using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

/// <summary>
/// C#->Lua 之获取lua中的table
/// 方式2：使用interface来映射得到Lua中的table内容。
/// 通过这种方式获得的映射是一种引用拷贝，需要XLua插件生成桥接类
/// </summary>
public class CallLuaTableByInterface : MonoBehaviour
{
    private LuaEnv _env;

    private void Start()
    {
        _env = new LuaEnv();
        _env.DoString("require 'CallByCSharp'");

        //得到lua中的表信息
        IWeaponTable weaponTable = _env.Global.Get<IWeaponTable>("weaponTable");
        //输出
        Debug.Log("[使用接口]weapon1" + weaponTable.weapon1);
        Debug.Log("[使用接口]weapon2" + weaponTable.weapon2);
        Debug.Log("[使用接口]weapon3" + weaponTable.weapon3);
        Debug.Log("[使用接口]weapon4" + weaponTable.weapon4);
        //引用类型测试
        weaponTable.weapon1 = "uzi";
        _env.DoString("print('修改后weaponTabel.weapon1='..weaponTable.weapon1)");
    }

    private void OnDestroy()
    {
        _env.Dispose();
    }

    //需要添加标签
    [CSharpCallLua]
    public interface IWeaponTable
    {
        string weapon1 { get; set; }
        string weapon2 { get; set; }
        string weapon3 { get; set; }
        string weapon4 { get; set; }
    }
}
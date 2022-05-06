using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

/// <summary>
/// 通过Require的方式来加载Lua文件，查找每个文件知道找到目标文件
/// 有点：使用方便
/// 缺点：只能使用Resources与内置的路径，不能自定义路径
///
/// 理想模式：
/// 整个程序只是用一个DoStirng("require'main'")，在main.lua中加载其他脚本
/// </summary>
public class RunLuaByRequire : MonoBehaviour
{
    private LuaEnv _env;

    private void Start()
    {
        _env = new LuaEnv();

        _env.DoString("require 'ExampleLua'");
    }

    private void OnDestroy()
    {
        _env.Dispose();
    }
}
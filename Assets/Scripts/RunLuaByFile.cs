using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class RunLuaByFile : MonoBehaviour
{
    private LuaEnv _env;

    private void Start()
    {
        _env = new LuaEnv();

        TextAsset txtAssest = Resources.Load<TextAsset>("ExampleLua.lua");
        _env.DoString(txtAssest.text);
    }

    private void OnDestroy()
    {
        _env.Dispose();
    }
}
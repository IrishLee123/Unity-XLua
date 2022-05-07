using System;
using UnityEngine;
using XLua;

namespace DefaultNamespace
{
    /**
     * Summary: Lua环境启动器
     * Create By: Lee
     * Create Time: 2022年05月07日 Saturday 10:32
     *========================================
     * Description:
     */
    public class LuaLuncher : MonoBehaviour
    {
        private LuaEnv env;

        private void Start()
        {
            Debug.Log("Lua环境启动");
            env = new LuaEnv();
            env.DoString("require 'LuaCallCSharp'");
        }

        private void OnDestroy()
        {
            env.Dispose();
        }
    }
}
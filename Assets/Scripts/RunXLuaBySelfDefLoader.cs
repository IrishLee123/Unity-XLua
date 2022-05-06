using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using XLua;

/// <summary>
/// 自定义Loader方式加载Lua文件，商业化开发的通用模式
/// </summary>
public class RunXLuaBySelfDefLoader : MonoBehaviour
{
    private LuaEnv _env;

    private void Start()
    {
        _env = new LuaEnv();

        _env.AddLoader(MyLoader);

        _env.DoString("require 'CustomDirLuaFile'");
    }

    /// <summary>
    /// 定义回调方法
    /// 功能：
    ///     方法主要功能是自定义lua文件路径
    /// </summary>
    /// <param name="filepath"></param>
    /// <returns></returns>
    private byte[] MyLoader(ref string filepath)
    {
        // 定义Lua文件路径
        string luaPath = Application.dataPath + "/Scripts/Lua/" + filepath + ".lua";
        // 读取路径中指定lua文件内容
        string strLuaContent = File.ReadAllText(luaPath);
        //数据类型转换
        byte[] result = System.Text.Encoding.UTF8.GetBytes(strLuaContent);
        return result;
    }

    private void OnDestroy()
    {
        _env.Dispose();
    }
}
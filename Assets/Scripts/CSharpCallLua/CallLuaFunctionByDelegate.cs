using System;
using System.Collections.Generic;
using UnityEngine;
using XLua;

namespace CSharpCallLua
{
    /**
     * Summary: XLua热更 之 C# --> Lua Function
     *      方式一：采用delegate方式，官方推荐
     * Create By: Lee
     * Create Time: 2022年05月06日 Friday 14:32
     *========================================
     * Description:
     *      
     */
    public class CallLuaFunctionByDelegate : MonoBehaviour
    {
        private LuaEnv env;

        //定义委托
        public delegate void Add(int num1, int num2);

        //以下两种委托定义需要配置文件支持
        //ExampleGenConfig中添加typeof(Action<int,int,int>)
        //然后XLua->GenerateCode
        private Action<int, int, int> addThree;

        //带返回值的委托，第一个int表示返回值类型
        private Func<int, int, int> addWithReturn;

        private void Start()
        {
            env = new LuaEnv();
            env.DoString("require 'CallByCSharp'");

            //通过Action（delegate）来映射lua中的简单函数
            Action action = env.Global.Get<Action>("ProcMyFunc1");

            //通过自定义Delegate来映射含参数的Lua函数
            Add addFun = env.Global.Get<Add>("ProcMyFunc2");

            //定义三个输入参数的委托
            addThree = env.Global.Get<Action<int, int, int>>("ProcMyFunc4");

            //定义两个输入参数并带有返回值的委托
            addWithReturn = env.Global.Get<Func<int, int, int>>("ProcMyFunc3");

            //调用委托
            action.Invoke();
            addFun.Invoke(10, 15);
            addThree.Invoke(1, 2, 3);
            var result = addWithReturn(100, 150);
            Debug.Log("result=" + result);
        }

        private void OnDestroy()
        {
            addThree = null;
            addWithReturn = null;
            
            env?.Dispose();
        }
    }
}
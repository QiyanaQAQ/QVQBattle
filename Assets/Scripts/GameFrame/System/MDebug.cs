using System.Collections;
using System.Collections.Generic;
using GameFrame.Runtime;
using UnityEngine;

namespace GameFrame.Runtime
{
    public class MDebug : BaseSystem
    {
        public static void Log(string _content)
        {
            Debug.Log(_content);
        }

        public static void Error(string _content)
        {
            Debug.LogError(_content);
        }

        public static void Warning(string _content)
        {
            Debug.LogWarning(_content);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFrame.Runtime
{
    public class GameMain : MonoBehaviour
    {
        private static readonly List<BaseSystem> systems = new List<BaseSystem>();
        
        public static MResource MResource { get; private set; }
        public static MDebug MDebug { get; private set; }
        public static MScene MScene { get; private set; }


        void SetSystem()
        {
            MResource = GetSystem<MResource>();
            MDebug = GetSystem<MDebug>();
            MScene = GetSystem<MScene>();
        }
        
        
        
        #region Private
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
        
        private static T GetSystem<T>() where T : BaseSystem
        {
            return (T)GetSystem(typeof(T));
        }
        
        private static BaseSystem GetSystem(Type type)
        {
            for (int i = 0; i < systems.Count; i++)
            {
                if (systems[i].GetType() == type)
                {
                    return systems[i];
                }
            }
            return null;
        }
        #endregion

        
        
        #region RegisterSystem
        internal static void RegisterSystem(BaseSystem _system)
        {
            if (_system == null)
            {
                return;
            }

            Type type = _system.GetType();
            for (int i = 0; i < systems.Count; i++)
            {
                if (systems[i].GetType() == type)
                {
                    return;
                }
            }
            systems.Add(_system);
        }
        #endregion

        
        
        #region GameLoop
        private void Start()
        {
            SetSystem();
            for (int i = 0; i < systems.Count; i++)
            {
                systems[i].OnInit();
            }
        }

        private void Update()
        {
            for (int i = 0; i < systems.Count; i++)
            {
                systems[i].OnUpdate(Time.deltaTime, Time.unscaledDeltaTime);
            }
        }

        private void OnDestroy()
        {
            for (int i = 0; i < systems.Count; i++)
            {
                systems[i].OnDestroy();
            }
        }
        #endregion
    }
}
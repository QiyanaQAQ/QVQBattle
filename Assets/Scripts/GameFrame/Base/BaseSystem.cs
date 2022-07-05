using System;
using UnityEngine;
namespace GameFrame.Runtime
{
    public abstract class BaseSystem : MonoBehaviour
    {
        protected void Awake()
        {
            GameMain.RegisterSystem(this);
        }
        
        public virtual void OnInit() { }

        public virtual void OnUpdate(float deltaTime, float unscaledDeltaTime) { }
        public virtual void OnDestroy() { }
    }
}
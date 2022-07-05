using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions;

namespace GameFrame.Singleton
{
    public abstract class MonoSingleton<T> : MonoBehaviour
        where T:MonoSingleton<T>
    {
        private static T instance = null;

        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    var gameMainObj =  GameObject.Find("GameMain");
                    Assert.IsNotNull(gameMainObj);
                    var instanceObj = SpawnObj(typeof(T).Name, gameMainObj.transform);
                    instance = instanceObj.GetOrAddComponent<T>();
                    DontDestroyOnLoad(instanceObj);
                }
                return instance;
            }
        }

        private static GameObject SpawnObj(string name, Transform parent)
        {
            var obj = new GameObject(name);
            obj.transform.SetParent(parent);
            return obj;
        }
    }
}

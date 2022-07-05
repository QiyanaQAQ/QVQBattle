using UnityEditor;
using UnityEngine;

namespace GameFrame.Runtime
{
    public class MResource : BaseSystem
    {
        public static T LoadAsset<T>(string _assetPath) where T : Object => (T) LoadAsset(_assetPath, typeof (T));

        public static Object LoadAsset(string _assetPath, System.Type _type)
        {
    #if UNITY_EDITOR
            var asset = AssetDatabase.LoadAssetAtPath(_assetPath, _type);
            return asset;
    #else
            
    #endif
            return null;
        }
    }
}
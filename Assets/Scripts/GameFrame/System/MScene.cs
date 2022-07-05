using UnityEngine.SceneManagement;

namespace GameFrame.Runtime
{
    public class MScene : BaseSystem
    {
        public override void OnInit()
        {
            base.OnInit();
        }

        public static void LoadScene(string _sceneName)
        {
            SceneManager.LoadScene(_sceneName);
        }
    }
}

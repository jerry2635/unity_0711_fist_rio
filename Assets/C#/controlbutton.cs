using UnityEngine;
using UnityEngine.SceneManagement;

namespace jerry
{
    public class controlbutton : MonoBehaviour
    {
        public void NextGame(string SceneName)
        {
            SceneManager.LoadScene(SceneName);
        }
    }

}



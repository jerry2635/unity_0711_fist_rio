using UnityEngine;
using UnityEngine.Video;
using System.Collections;

namespace jerry
{
    public class Video : MonoBehaviour
    {
        public VideoPlayer VideoObj;
        bool VideoState;

        void Start()
        {
            StartCoroutine(Wait());
        }

        IEnumerator Wait()
        {
            yield return new WaitForSeconds(1f);
            VideoState = true;
        }

        void Update()
        {
            if (!VideoObj.isPlaying && VideoState)
            {
                Application.LoadLevel("Game");
            }
        }
    }

}

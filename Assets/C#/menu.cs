using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

namespace jerry
{
    public class menu : MonoBehaviour
    {
        [Header("BGM")]
        public GameObject BGM;
        bool ControlAudio;
        [Header("聲音按鈕")]
        public Image ButtonSound;
        [Header("解析度Dropdown")]
        public Dropdown SizeDropdown;
        [Header("語言Dropdown")]
        public Dropdown LanDropdown;
        string SaveLanID = "SaveLanID";
        public string[] filePaths;
        public InputField[] Keyboards;
        public float Speed;
        public float MinX, MaxX, MinY, MaxY;

        private void Awake()
        {
            filePaths = Directory.GetFiles(Application.streamingAssetsPath, "*.png");
#if UNITY_STANDALONE_WIN
            SizeDropdown.interactable = true;
#endif
#if UNITY_ANDROID || UNITY_IOS
SizeDropdown.interactable = false;
#endif
            Debug.Log(Staticvar.KeyboardState[0]);
            if (Staticvar.KeyboardState[0] == null || Staticvar.KeyboardState[1] == null || Staticvar.KeyboardState[2] == null || Staticvar.KeyboardState[3] == null)
            {
                Keyboards[0].text = "w";
                Keyboards[1].text = "s";
                Keyboards[2].text = "a";
                Keyboards[3].text = "d";
                for (int i = 0; i < Keyboards.Length; i++)
                    Staticvar.KeyboardState[i] = Keyboards[i].text;
            }
        }


        // Start is called before the first frame update
        void Start()
        {
            if (GameObject.FindGameObjectsWithTag("BGM").Length <= 0)
            {
                Instantiate(BGM);
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey(Staticvar.KeyboardState[0]))
            {
                transform.Translate(0, 0, Speed * Time.deltaTime);
            }
            else if (Input.GetKey(Staticvar.KeyboardState[1]))
            {
                transform.Translate(0, 0, -Speed * Time.deltaTime);
            }
            else if (Input.GetKey(Staticvar.KeyboardState[2]))
            {
                transform.Translate(-Speed * Time.deltaTime, 0, 0);
            }
            else if (Input.GetKey(Staticvar.KeyboardState[3]))
            {
                transform.Translate(Speed * Time.deltaTime, 0, 0);
            }
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, MinX, MaxX), Mathf.Clamp(transform.position.y, MinY, MaxY), transform.position.z);
        }
        #region
        public void NextScene()
        {
            SceneManager.LoadScene("Level");
        }
        #endregion
        public void Quit()
        {
            Application.Quit();
        }

        public void Control_Audio()
        {
            ControlAudio = !ControlAudio;
            if (ControlAudio)
            {
                StreamingAssetsLoadTexture(1);
            }
            else
            {
                StreamingAssetsLoadTexture(0);
            }
            AudioListener.pause = ControlAudio;
        }

        void StreamingAssetsLoadTexture(int ID)
        {
            byte[] pngbytes = File.ReadAllBytes(filePaths[ID]);
            Texture2D tex = new Texture2D(0, 0);
            tex.LoadImage(pngbytes);
            Sprite Formtex = Sprite.Create(tex, new Rect(0f, 0f, tex.width, tex.height), new Vector2(0.5f, 0.5f));
            ButtonSound.sprite = Formtex;
        }

        public void ChangeScreenSize()
        {

        }

        public void ChangeLan()
        {
            PlayerPrefs.SetInt(SaveLanID, LanDropdown.value);
        }

        public void SetKeyboard(int ID)
        {
            Staticvar.KeyboardState[ID] = Keyboards[ID].text;
        }


    }
}



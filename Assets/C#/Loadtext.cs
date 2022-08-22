using UnityEngine;
using UnityEngine.UI;

namespace jerry
{
    public class Loadtext : MonoBehaviour
    {
        [Header("輸入每個文字自己的ID")]
        public int ID;

        string SaveLanID = "SaveLanID";

        void Update()
        {
            switch (PlayerPrefs.GetInt(SaveLanID))
            {
                case 0:
                    gameObject.GetComponent<Text>().text = FindObjectOfType<Readtext>().CHDatas[ID];
                    break;

                case 1:
                    gameObject.GetComponent<Text>().text = FindObjectOfType<Readtext>().ENDatas[ID];
                    break;
            }
        }
    }
}


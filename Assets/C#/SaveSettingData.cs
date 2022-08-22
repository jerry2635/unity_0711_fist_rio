using UnityEngine;
using System.IO;
using UnityEngine.UI;

namespace jerry
{
    public class saveset : MonoBehaviour
    {
        string Path;
        [Header("語言下拉選單")]
        public Dropdown LanDropdown;
        [Header("解析度下拉選單")]
        public Dropdown ScreenSizeDropdown;
        FileStream file;

        public enum Platform
        {
            PC,
            Mobile
        }
        [Header("選擇要切換的平台")]
        public Platform platform;
        [Header("顯示文字檔兩個Dropdown資料")]
        public string[] Datas;
        WWW Reader;
        string ReaderPC;

        private void Awake()
        {
            Path = Application.persistentDataPath + "Save.txt";

            if (File.Exists(Path))
            {
                Debug.Log("抓取手機內文字檔案");

            }
            else
            {
                Debug.Log("在手機建立一個文字檔案");
                file = new FileStream(Path, FileMode.Create);
                file.Close();
            }
        }

        public void SaveData(string Data)//儲存文檔
        {
            WriteString(ScreenSizeDropdown.value + "@" + LanDropdown.value);
        }
        void WriteString(string Data)
        {
            file = new FileStream(Path, FileMode.Open);
            StreamWriter sw = new StreamWriter(file);
            sw.WriteLine(Data);
            sw.Close();
        }
        void ReadString()//重新啟動
        {
            switch (platform)
            {
                case Platform.Mobile:
                    Reader = new WWW(Path);
                    Datas = Reader.text.Split('@');
                    ScreenSizeDropdown.value = int.Parse(Datas[0]);
                    LanDropdown.value = int.Parse(Datas[1]);
                    break;

                case Platform.PC:
                    ReaderPC = File.ReadAllText(Path);
                    Datas = ReaderPC.Split('@');
                    ScreenSizeDropdown.value = int.Parse(Datas[0]);
                    LanDropdown.value = int.Parse(Datas[1]);
                    break;
            }
        }
    }
}


using UnityEngine;
using System.IO;
using UnityEngine.UI;

namespace jerry
{
    public class saveset : MonoBehaviour
    {
        string Path;
        [Header("�y���U�Կ��")]
        public Dropdown LanDropdown;
        [Header("�ѪR�פU�Կ��")]
        public Dropdown ScreenSizeDropdown;
        FileStream file;

        public enum Platform
        {
            PC,
            Mobile
        }
        [Header("��ܭn���������x")]
        public Platform platform;
        [Header("��ܤ�r�ɨ��Dropdown���")]
        public string[] Datas;
        WWW Reader;
        string ReaderPC;

        private void Awake()
        {
            Path = Application.persistentDataPath + "Save.txt";

            if (File.Exists(Path))
            {
                Debug.Log("����������r�ɮ�");

            }
            else
            {
                Debug.Log("�b����إߤ@�Ӥ�r�ɮ�");
                file = new FileStream(Path, FileMode.Create);
                file.Close();
            }
        }

        public void SaveData(string Data)//�x�s����
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
        void ReadString()//���s�Ұ�
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


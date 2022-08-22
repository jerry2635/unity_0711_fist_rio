using UnityEngine;
using System.IO;

namespace jerry
{
    public class Readtext : MonoBehaviour
    {
        //�������
        string CHPath;
        //�^�����
        string ENPath;

        [Header("��ܤ����r�ɸ��")]
        public string CHData;
        [Header("��ܭ^���r�ɸ��")]
        public string ENData;

        [Header("��ܤ����r�ɸ��")]
        public string[] CHDatas;
        [Header("��ܭ^���r�ɸ��")]
        public string[] ENDatas;

        public enum Platform
        {
            PC,
            Mobile
        }

        [Header("��ܭn���������x")]
        public Platform Platforms;

        WWW CHreader;
        WWW ENreader;

        private void Awake()
        {
            CHPath = Application.streamingAssetsPath + "/CH.txt";
            ENPath = Application.streamingAssetsPath + "/EN.txt";
            switch (Platforms)
            {
                case Platform.Mobile:
                    CHreader = new WWW(CHPath);
                    CHreader = new WWW(ENPath);
                    CHDatas = CHreader.text.Split('\n');
                    ENDatas = ENreader.text.Split('\n');
                    break;
                case Platform.PC:
                    CHData = File.ReadAllText(CHPath);
                    ENData = File.ReadAllText(ENPath);
                    CHDatas = CHData.Split('\n');
                    ENDatas = ENData.Split('\n');
                    break;
            }
        }
    }
}



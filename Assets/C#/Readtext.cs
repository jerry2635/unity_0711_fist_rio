using UnityEngine;
using System.IO;

namespace jerry
{
    public class Readtext : MonoBehaviour
    {
        //中文文檔
        string CHPath;
        //英文文檔
        string ENPath;

        [Header("顯示中文文字檔資料")]
        public string CHData;
        [Header("顯示英文文字檔資料")]
        public string ENData;

        [Header("顯示中文文字檔資料")]
        public string[] CHDatas;
        [Header("顯示英文文字檔資料")]
        public string[] ENDatas;

        public enum Platform
        {
            PC,
            Mobile
        }

        [Header("選擇要切換的平台")]
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



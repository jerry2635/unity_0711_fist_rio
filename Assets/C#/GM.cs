using UnityEngine;

namespace jerry
{
    public class GM : MonoBehaviour
    {
        [Header("�T�w�ɶ����ͪ���")]
        public float SetTime;
        [Header("�ĤH")]
        public GameObject[]Enemys;

        [Header("X��ɳ̤j��")]
        public float MaxX;
        [Header("X��ɳ̤p��")]
        public float MinX;

        private void Start()
        {
            InvokeRepeating("CreatEnemys", SetTime, SetTime);
        }

        public void CteatEnemys()
        {
            Instantiate(Enemys[Random.Range(0, Enemys.Length)], new Vector3(Random.Range(MinX,MaxX),transform.position.y,transform.position.z),transform.rotation);
        }

        private void Update()
        {
           
        }
    }
}


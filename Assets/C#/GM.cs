using UnityEngine;

namespace jerry
{
    public class GM : MonoBehaviour
    {
        [Header("固定時間產生物件")]
        public float SetTime;
        [Header("敵人")]
        public GameObject[]Enemys;

        [Header("X邊界最大值")]
        public float MaxX;
        [Header("X邊界最小值")]
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


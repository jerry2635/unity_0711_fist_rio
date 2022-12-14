using UnityEngine;

namespace jerry
{
    public class Bullet : MonoBehaviour
    {
        [Header("移動速度")]
        public float Speed;
        [Header("消失時間")]
        public float DeleteTime;
        [Header("粒子系統_Player")]
        public GameObject PlayerEcp;
        [Header("粒子系統_Enemy")]
        public GameObject EnemyExp;


        void Start()
        {
            Destroy(gameObject, DeleteTime);
        }

        void Update()
        {
            transform.Translate(Vector3.up * Speed * Time.deltaTime);
        }
    }
}



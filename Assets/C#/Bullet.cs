using UnityEngine;

namespace jerry
{
    public class Bullet : MonoBehaviour
    {
        [Header("簿笆硉")]
        public float Speed;
        [Header("ア丁")]
        public float DeleteTime;
        [Header("采╰参_Player")]
        public GameObject PlayerEcp;
        [Header("采╰参_Enemy")]
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



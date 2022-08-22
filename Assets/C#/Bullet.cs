using UnityEngine;

namespace jerry
{
    public class Bullet : MonoBehaviour
    {
        [Header("���ʳt��")]
        public float Speed;
        [Header("�����ɶ�")]
        public float DeleteTime;
        [Header("�ɤl�t��_Player")]
        public GameObject PlayerEcp;
        [Header("�ɤl�t��_Enemy")]
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



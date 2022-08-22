using UnityEngine;

namespace jerry
{
    public class Enemy : MonoBehaviour
    {
        public float Speed;
        public float DeleteTime;

        public GameObject Bullet;
        [Header("�l�u���ͮɶ�")]
        public float SetTime;
        [Header("�ѦҦ�m")]
        public Transform TargetPoint;

        private void Start()
        {
            Destroy(gameObject, DeleteTime);
        }

        private void Update()
        {
            transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        }
    }
}


using UnityEngine;

namespace jerry
{
    public class Player : MonoBehaviour
    {
        public float Speed;
        public float MinX, MaxX, MinY, MaxY;
        bool isTouch;

        public GameObject bullet;
        [Header("設定多少時間產生一個子彈")]
        public float SetTime;
        float ScriptTime;
        [Header("參考位置")]
        public Transform TargetPoint;

        private PlayerControl playerControls;

        internal PlayerControl PlayerControls { get => playerControls; set => playerControls = value; }

        void Start()
        {
            PlayerControls = new PlayerControl();
            PlayerControls.Enable();
        }

        void Update()
        {
            if (isTouch)
            {
                transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, -0.3f);
            }
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, MinX, MaxX), Mathf.Clamp(transform.position.y, MinY, MaxY), transform.position.z);
            ScriptTime += Time.deltaTime;
            if (ScriptTime >= SetTime)
            {
                Instantiate(bullet, TargetPoint.transform.position, TargetPoint.transform.rotation);
                ScriptTime = 0;
            }
        }
        private void OnMouseDown()
        {
            isTouch = true;
        }
        private void OnMouseUp()
        {
            isTouch = false;
        }
    }
}


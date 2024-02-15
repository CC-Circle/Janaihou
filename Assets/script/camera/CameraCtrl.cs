using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] GameObject stage;
    private Camera cam;
    [SerializeField] private float camera_rotate_magnification = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        // マウスの移動量を取得
        float mx = Input.GetAxis("Mouse X") * camera_rotate_magnification;
        float my = Input.GetAxis("Mouse Y");


        //float sensitiveRotate = 10.0f;

        if (Input.GetMouseButton(0))
        {
            // 回転軸はワールド座標のY軸
            transform.RotateAround(stage.transform.position, Vector3.up, mx);
        }
    }
}

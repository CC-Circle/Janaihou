using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    [SerializeField] private float true_conveyor_speed = 250;
    [SerializeField] private float false_conveyor_speed = -150;
    [SerializeField] private GameObject conveyor;
    private Vector3 conveyor_direction = Vector3.zero;

    void Start()
    {
        // コンベアの方向ベクトルを取得
        conveyor_direction = conveyor.transform.forward;
    }

    void OnTriggerStay(Collider col)
    {
        if (col.tag == "Player")
        {
            Rigidbody rb = col.transform.GetComponent<Rigidbody>();

            // 逆再生中の場合、速度を反転
            float speed;
            if (TIME_MANAGER.is_revtime)
            {
                speed = false_conveyor_speed;
            }
            else
            {
                speed = true_conveyor_speed;
            }

            // コンベアの方向に速度をかける
            rb.AddForce(conveyor_direction * speed);
        }
    }
}

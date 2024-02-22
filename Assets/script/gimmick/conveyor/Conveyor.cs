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
        conveyor_direction = conveyor.transform.position;
    }

    void OnTriggerStay(Collider col)
    {
        if (col.tag == "Player")
        {
            if (TIME_MANAGER.is_revtime == false)
            {
                Rigidbody rb = col.transform.GetComponent<Rigidbody>();
                rb.AddForce(0, 0, true_conveyor_speed);
            }
            else
            {
                Rigidbody rb = col.transform.GetComponent<Rigidbody>();
                rb.AddForce(0, 0, false_conveyor_speed);
            }
        }
    }
}

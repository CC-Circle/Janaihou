using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : MonoBehaviour
{
    [SerializeField] private float gear_rotate_speed_z = -0.1f;
    private bool time = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, gear_rotate_speed_z));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            time = !time;
            gear_rotate_speed_z = -gear_rotate_speed_z;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : MonoBehaviour
{
    [SerializeField] private float gear_rotate_speed_z = -0.1f;
    private bool time = true;
    private bool prevrev = false;
    // Start is called before the first frame update
    void Start()
    {
        prevrev = TIME_MANAGER.is_revtime;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, gear_rotate_speed_z));

        if (prevrev!=TIME_MANAGER.is_revtime)
        {
            time = !time;
            gear_rotate_speed_z = -gear_rotate_speed_z;
        }
        prevrev = TIME_MANAGER.is_revtime;
    }
}

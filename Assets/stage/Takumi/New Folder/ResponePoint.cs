using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponePoint : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        FallSenser.respone_vector = this.transform.position;
    }
}

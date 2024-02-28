using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player_Triger : MonoBehaviour
{
    [SerializeField][Range(0f, 30.0f)] float time_up_to_fall = 1.0f;
    private Down_Scaffolding down_Scaffolding;
    private GameObject player_parent;
    void Start()
    {
        down_Scaffolding = FindObjectOfType<Down_Scaffolding>();
        player_parent = this.gameObject.transform.Cast<Transform>()
            .FirstOrDefault(child => child.name == "player_parent")?.gameObject;
    }

    void Update()
    {

    }

    private void StartCoroutine()
    {
        Debug.Log("StartCoroutine");
        StartCoroutine(down_Scaffolding.Down_board(gameObject.transform.parent.gameObject, time_up_to_fall));

    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.SetParent(player_parent.transform);
            StartCoroutine();
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.SetParent(null);
        }
    }

}

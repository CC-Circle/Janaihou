using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{

    [SerializeField] private GameObject board;
    [SerializeField] private GameObject upper_limit;
    [SerializeField] private GameObject lower_limit;
    [SerializeField] private float balloon_upward_speed = 1.0f;
    [SerializeField] private float balloon_downward_speed = -1.0f;
    private Vector3 max_position = Vector3.zero;
    private Vector3 min_position = Vector3.zero;

    void Start()
    {
        max_position = upper_limit.transform.position;
        min_position = lower_limit.transform.position;
    }

    void Update()
    {
        Vector3 current_board_position = board.transform.position;
        Vector3 new_board_position = current_board_position;
        if (TIME_MANAGER.is_revtime == true)
        {
            if (current_board_position.y > min_position.y)
            {
                //Debug.Log("Balloon is going up");
                new_board_position.y += balloon_downward_speed * Time.deltaTime;
            }
        }
        else if (TIME_MANAGER.is_revtime == false)
        {
            if (current_board_position.y < max_position.y)
            {
                //Debug.Log("Balloon is going down");
                new_board_position.y += balloon_upward_speed * Time.deltaTime;
            }
        }
        board.transform.position = new_board_position;
    }

}

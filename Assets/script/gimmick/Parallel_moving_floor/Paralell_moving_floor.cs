using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralell_moving_floor : MonoBehaviour
{
    [SerializeField] private GameObject board;
    [SerializeField] private GameObject start;
    [SerializeField] private GameObject goal;
    [SerializeField] private float speed_head_to_start = 1.0f;
    [SerializeField] private float speed_head_to_goal = 1.0f;
    private Vector3 start_position = Vector3.zero;
    private Vector3 goal_position = Vector3.zero;
    void Start()
    {
        start_position = start.transform.position;
        goal_position = goal.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 current_board_position = board.transform.position;
        Vector3 new_board_position = current_board_position;

        if (TIME_MANAGER.is_revtime == true)
        {
            if (current_board_position != start_position)
            {
                //Debug.Log("Paralell_moving_floor is going start position");
                new_board_position = Vector3.MoveTowards(current_board_position, start_position, speed_head_to_goal * Time.deltaTime);
            }
        }
        else if (TIME_MANAGER.is_revtime == false)
        {
            if (current_board_position != goal_position)
            {
                //Debug.Log("Paralell_moving_floor is going goal position");
                new_board_position = Vector3.MoveTowards(current_board_position, goal_position, speed_head_to_start * Time.deltaTime);

            }
        }
        board.transform.position = new_board_position;
    }
}

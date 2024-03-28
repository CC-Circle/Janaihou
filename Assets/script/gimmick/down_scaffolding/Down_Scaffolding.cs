using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Down_Scaffolding : MonoBehaviour
{
    [SerializeField] private float board_upward_speed = 0.5f;
    [SerializeField] private float board_downward_speed = -0.5f;
    void Start()
    {

    }


    void Update()
    {

    }

    public IEnumerator Down_board(GameObject Scaffolding, float time_up_to_fall)
    {
        GameObject upper = Scaffolding.transform.Cast<Transform>()
            .FirstOrDefault(child => child.name == "upper_limit")?.gameObject;
        if (upper == null)
        {
            Debug.Log(Scaffolding.name + "の子要素に、GameObject: upper がありません。");
            yield break;
        }

        GameObject lower = Scaffolding.transform.Cast<Transform>()
        .FirstOrDefault(child => child.name == "lower_limit")?.gameObject;
        if (upper == null)
        {
            Debug.Log(Scaffolding.name + "の子要素に、GameObject: lower がありません。");
            yield break;
        }

        GameObject board = Scaffolding.transform.Cast<Transform>()
            .FirstOrDefault(child => child.name == "board")?.gameObject;
        if (upper == null)
        {
            Debug.Log(Scaffolding.name + "の子要素に、GameObject: board がありません。");
            yield break;
        }

        Vector3 upper_position = upper.transform.position;
        Vector3 lower_position = lower.transform.position;

        if (board.transform.position.y != upper_position.y)
        {
            yield break;
        }

        yield return new WaitForSeconds(time_up_to_fall);

        while (true)
        {
            Vector3 current_board_position = board.transform.position;
            Vector3 new_board_position = current_board_position;

            if (TIME_MANAGER.is_revtime == false)
            {
                if (current_board_position.y > lower_position.y)
                {
                    new_board_position.y += board_downward_speed * Time.deltaTime;
                }
            }
            else if (TIME_MANAGER.is_revtime == true)
            {
                if (current_board_position.y < upper_position.y)
                {
                    new_board_position.y += board_upward_speed * Time.deltaTime;
                }
                else
                {
                    board.transform.position = upper_position;
                    yield break;
                }
            }
            board.transform.position = new_board_position;

            yield return null;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using JetBrains.Annotations;
using UnityEngine;

public class disappearing_platform : MonoBehaviour
{
    private List<GameObject> boardList = new List<GameObject>();
    [SerializeField] private float PauseTime = 1.5f;


    void Start()
    {
        Regex targetChildNameRegex = new Regex("board_[1-9][0-9]*");

        Transform[] children = GetComponentsInChildren<Transform>(true);

        boardList = children
            .Where(child => targetChildNameRegex.IsMatch(child.name))
            .Select(child => child.gameObject)
            .ToList();

        PrintBoardList(boardList);

        foreach (GameObject board in boardList)
        {
            DissaperBoard(board);
        }

        StartCoroutine(MainLoop());
    }


    void Update()
    {

    }

    private IEnumerator MainLoop()
    {
        int boardIndex = 0;
        while (true)
        {
            StartCoroutine(AppearBoard(boardList[boardIndex]));
            yield return new WaitForSeconds(PauseTime);

            if (TIME_MANAGER.is_revtime == false)
            {
                boardIndex = (boardIndex + 1) % boardList.Count;
            }
            else
            {
                boardIndex = (boardIndex - 1 + boardList.Count) % boardList.Count;

            }
        }
    }

    void PrintBoardList(List<GameObject> boardList)
    {
        foreach (GameObject board in boardList)
        {
            Debug.Log(board.name);
        }
    }

    void DissaperBoard(GameObject board)
    {
        Renderer boardRenderer = board.GetComponent<Renderer>();
        if (boardRenderer != null)
        {
            boardRenderer.enabled = false;
        }
        else
        {
            Debug.Log("boardRenderer is null");
        }

        Collider boardCollider = board.GetComponent<Collider>();
        if (boardCollider != null)
        {
            boardCollider.enabled = false;
        }
        else
        {
            Debug.Log("boardCollider is null");
        }
    }

    private IEnumerator AppearBoard(GameObject board)
    {
        Renderer boardRenderer = board.GetComponent<Renderer>();
        if (boardRenderer != null)
        {
            boardRenderer.enabled = true;
        }
        else
        {
            Debug.Log("boardRenderer is null");
        }

        Collider boardCollider = board.GetComponent<Collider>();
        if (boardCollider != null)
        {
            boardCollider.enabled = true;
        }
        else
        {
            Debug.Log("boardCollider is null");
        }

        yield return new WaitForSeconds(PauseTime * 2.0f);
        DissaperBoard(board);

        yield return null;
    }
}
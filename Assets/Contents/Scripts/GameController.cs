using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject undoButton;
    public GameObject resetButton;
    private Stack<Vector3> moveHistory = new Stack<Vector3>();

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetLevel();
        }

        if (undoButton != null && Input.GetKeyDown(KeyCode.U)) // Tasto per annullare l'ultima mossa
        {
            UndoLastMove();
        }
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void UndoLastMove()
    {
        if (moveHistory.Count > 0)
        {
            Vector3 lastPosition = moveHistory.Pop();
        }
    }

    public void RegisterMove(Vector3 position)
    {
        moveHistory.Push(position);
    }
}
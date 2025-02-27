using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int currentLevel = 1;
    public int totalLevels = 3;
    public GameObject[] levels;

    void Start()
    {
        LoadLevel(currentLevel);
    }

    void LoadLevel(int level)
    {
        foreach (GameObject lvl in levels)
        {
            lvl.SetActive(false);
        }

        levels[level - 1].SetActive(true);
    }

    public void CompleteLevel()
    {
        if (currentLevel < totalLevels)
        {
            currentLevel++;
            LoadLevel(currentLevel);
        }
        else
        {
            Debug.Log("Game Completed!");
        }
    }
}
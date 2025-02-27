using UnityEngine;

public class BreadManager : MonoBehaviour
{
    public GameObject topBreadPrefab;
    public GameObject bottomBreadPrefab;
    public Vector3 bottomPosition;
    public Vector3 topPosition;

    void Start()
    {
        Instantiate(bottomBreadPrefab, bottomPosition, Quaternion.identity);
        Instantiate(topBreadPrefab, topPosition, Quaternion.identity);
    }
}
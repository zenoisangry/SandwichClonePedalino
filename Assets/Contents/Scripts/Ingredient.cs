using UnityEngine;
using UnityEngine.Android;

public class Ingredient : MonoBehaviour
{
    public bool isFlipped = false;

    public void OnSelected()
    {
        GetComponent<SpriteRenderer>().color = Color.yellow;
    }

    public void OnDeselected()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
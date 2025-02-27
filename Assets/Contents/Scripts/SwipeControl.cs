using UnityEngine;
using UnityEngine.Android;

public class SwipeControl : MonoBehaviour
{
    private Vector2 touchStartPos;
    private Vector2 touchEndPos;
    private Ingredient selectedIngredient;
    private bool isSelectingIngredient = false;

    void Update()
    {
        if (Input.touchCount > 0 || Input.GetMouseButtonDown(0))
        {
            Vector2 inputPos = Input.touchCount > 0 ? (Vector2)Input.GetTouch(0).position : (Vector2)Input.mousePosition;
            HandleInput(inputPos);
        }

        if (Input.GetMouseButtonUp(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended))
        {
            Vector2 swipeDirection;

            if (Input.touchCount > 0)
            {
                touchEndPos = Input.GetTouch(0).position;
                swipeDirection = touchEndPos - touchStartPos;
            }
            else
            {
                touchEndPos = Input.mousePosition;
                swipeDirection = touchEndPos - touchStartPos;
            }

            HandleSwipe(swipeDirection);
        }
    }

    void HandleInput(Vector2 inputPos)
    {
        if (!isSelectingIngredient)
        {
            Ray ray = Camera.main.ScreenPointToRay(inputPos);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Ingredient hitIngredient = hit.transform.GetComponent<Ingredient>();
                if (hitIngredient != null)
                {
                    selectedIngredient = hitIngredient;
                    isSelectingIngredient = true;
                    selectedIngredient.OnSelected();
                }
            }
            touchStartPos = inputPos;
        }
    }

    void HandleSwipe(Vector2 swipeDirection)
    {
        if (selectedIngredient == null) return;

        if (Mathf.Abs(swipeDirection.x) > Mathf.Abs(swipeDirection.y))
        {
            FlipIngredientHorizontally(swipeDirection.x);
        }
        else
        {
            FlipIngredientVertically(swipeDirection.y);
        }
    }

    void FlipIngredientHorizontally(float direction)
    {
        if (selectedIngredient != null)
        {
            float flipDirection = direction > 0 ? 1 : -1;
            selectedIngredient.transform.position += new Vector3(flipDirection, 0, 0);
            selectedIngredient.isFlipped = true;
            selectedIngredient.transform.Rotate(0, 0, direction > 0 ? 180 : -180);
        }
    }

    void FlipIngredientVertically(float direction)
    {
        if (selectedIngredient != null)
        {
            float flipDirection = direction > 0 ? 1 : -1;
            selectedIngredient.transform.position += new Vector3(0, flipDirection, 0);
            selectedIngredient.isFlipped = true;
            selectedIngredient.transform.Rotate(direction > 0 ? 180 : -180, 0, 0);
        }
    }

    public void DeselectIngredient()
    {
        if (selectedIngredient != null)
        {
            selectedIngredient.OnDeselected();
            selectedIngredient = null;
            isSelectingIngredient = false;
        }
    }
}
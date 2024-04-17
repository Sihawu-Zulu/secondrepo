using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;

    public float speed = 5.0f;

    [SerializeField] private float maxX = 1f;
    [SerializeField] private float minX = -1f;
    [SerializeField] private float minY = -1f;
    [SerializeField] private float maxY = 1f;

    private void OnMouseDown()
    {
        isDragging = true;
        offset = gameObject.transform.position - GetMouseWorldPosition();
    }

    private void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 newPosition = GetMouseWorldPosition() + offset;

            newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
            newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);

            transform.position = newPosition;
        }
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mousePosition.z = 0f;
        return mousePosition;
    }
}

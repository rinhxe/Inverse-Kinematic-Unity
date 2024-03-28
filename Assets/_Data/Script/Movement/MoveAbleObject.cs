using UnityEngine;

public class MoveAbleObject: MonoBehaviour {
    Vector3 mouse_Position;

    private Vector3 GetMousePosition() {
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    private void OnMouseDown() {
        mouse_Position = Input.mousePosition - GetMousePosition();

    }

    private void OnMouseDrag() {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition
                - mouse_Position);
    }
}

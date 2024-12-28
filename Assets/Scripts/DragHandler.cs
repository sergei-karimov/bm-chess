using UnityEngine;

public class DragHandler : MonoBehaviour {
    private static Transform _transform;
    private static SpriteRenderer _spriteRenderer;

    private Vector3 _startPosition;

    void Start() {
    }

    void Update() {
    }

    public void OnMouseDown() {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.color = new Color(1f, 1f, 1f, 0.5f);
        Debug.Log($"Start position: {gameObject.transform.position}");
        
    }

    public void OnMouseDrag() {
        if (Camera.main != null) {
            gameObject.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -0.01f);
        }
    }

    public void OnMouseUp() {
        Debug.Log($"Start position: {gameObject.transform.position}");
        _spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
    }
}
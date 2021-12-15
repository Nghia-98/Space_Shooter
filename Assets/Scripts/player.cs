using UnityEngine;
using UnityEngine.InputSystem;

public class player : MonoBehaviour {
    [SerializeField] private float moveSpeed = 5f;
    private Vector2 rawInput;

    // Config view port
    Vector2 minBounds;
    Vector2 maxBounds;

    [SerializeField] float paddingLeft;
    [SerializeField] float paddingRight;
    [SerializeField] float paddingTop;
    [SerializeField] float paddingBottom;

    Shooter shooter;

    void Awake() {
        shooter = GetComponent<Shooter>();
    }


    void Start() {
        InitBounds();
    }

    // Update is called once per frame
    private void Update() {
        Move();
    }

    private void InitBounds() {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }

    private void Move() {
        Vector2 delta = rawInput * moveSpeed * Time.deltaTime;
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBounds.x + paddingLeft, maxBounds.x - paddingRight);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBounds.y + paddingBottom, maxBounds.y - paddingTop);
        transform.position = newPos;
    }

    private void OnMove(InputValue value) {
        rawInput = value.Get<Vector2>();
    }

    void OnFire(InputValue value) {
        if (shooter != null) {
            shooter.isFiring = value.isPressed;
        }
    }
}
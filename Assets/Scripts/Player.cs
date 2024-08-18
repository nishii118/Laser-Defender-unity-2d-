using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Vector2 rawInput;
    [SerializeField] float moveSpeed;
    Vector2 minBounds;
    Vector2 maxBounds;
    [SerializeField] float paddingHorizontal;
    [SerializeField] float paddingTop;
    [SerializeField] float paddingBottom;

    Shooter shooter;

    private void Awake()
    {
        shooter = GetComponent<Shooter>();
    }
    void Start()
    {
        moveSpeed = 5f;
        InitBounds();
        paddingHorizontal = 0.5f;
        paddingTop = 2f;
        paddingBottom = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }
    void Move()
    {
        //rigibody.velocity
        Vector3 delta = rawInput * moveSpeed * Time.deltaTime;
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBounds.x + paddingHorizontal, maxBounds.x - paddingHorizontal);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBounds.y + paddingBottom, maxBounds.y - paddingTop);
        transform.position = newPos;
    }

    void OnMove(InputValue inputValue)
    {
        rawInput = inputValue.Get<Vector2>();
    }

    void OnFire(InputValue inputValue)
    {
        if (shooter != null)
        {
            Debug.Log("Onfire work");
            shooter.isFiring = inputValue.isPressed;
        }
    }
}

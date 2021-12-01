using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    Vector2  rawInput;
    // Update is called once per frame
    void Update()
    {
      Move();
    }

    void Move() {
      Vector3 delta = rawInput * moveSpeed *Time.deltaTime;
      transform.position += delta;
    }
    void OnMove(InputValue value) {
      rawInput = value.Get<Vector2>();
      Debug.Log(rawInput);
    }
}

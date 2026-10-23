using UnityEngine;
using UnityEngine.InputSystem;

public class ControlNave : MonoBehaviour
{
    public float velocidadHorizontal = 8f;
    public float velocidadVertical = 4f;

    private Rigidbody2D rb;
    private float inputX;
    private float inputY;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        var keyboard = Keyboard.current;
        if (keyboard == null) return;

        // Movimiento Horizontal (Flechas o A/D)
        inputX = 0f;
        if (keyboard.dKey.isPressed || keyboard.rightArrowKey.isPressed) inputX += 1f;
        if (keyboard.aKey.isPressed || keyboard.leftArrowKey.isPressed) inputX -= 1f;

        // Movimiento Vertical (Flechas o W/S)
        inputY = 0f;
        if (keyboard.wKey.isPressed || keyboard.upArrowKey.isPressed) inputY += 1f;
        if (keyboard.sKey.isPressed || keyboard.downArrowKey.isPressed) inputY -= 1f;
    }

    void FixedUpdate()
    {

        rb.linearVelocity = new Vector2(inputX * velocidadHorizontal, inputY * velocidadVertical);
    }
}
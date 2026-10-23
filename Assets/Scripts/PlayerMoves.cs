using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
    public float walkSpeed = 4f;
    public float jumpForce = 6f;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private bool enSuelo = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // 1. Movimiento horizontal (A y D)
        float directionX = 0f;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) directionX = -1f;
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) directionX = 1f;

        rb.linearVelocity = new Vector2(directionX * walkSpeed, rb.linearVelocity.y);

        // Voltear sprite según la dirección
        if (spriteRenderer != null && directionX != 0)
        {
            spriteRenderer.flipX = (directionX < 0);
        }

        // 2. Salto seco (Estrictamente solo si está en el suelo)
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) && enSuelo)
        {
            enSuelo = false; // Bloquea inmediatamente cualquier otro salto
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    // Usamos Stay en lugar de Enter para asegurarnos de que esté pisando algo de verdad
    private void OnCollisionStay2D(Collision2D collision)
    {
        // Verificamos que el personaje esté quieto en Y o cayendo, y que el contacto sea por debajo de él
        foreach (ContactPoint2D contact in collision.contacts)
        {
            // Si el punto normal apunta hacia arriba, significa que estamos pisando algo
            if (contact.normal.y > 0.5f)
            {
                enSuelo = true;
                break;
            }
        }
    }

    // Si se separa de la superficie, pierde el suelo
    private void OnCollisionExit2D(Collision2D collision)
    {
        enSuelo = false;
    }
}
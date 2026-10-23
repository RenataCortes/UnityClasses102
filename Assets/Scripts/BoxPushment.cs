using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BoxPushment : MonoBehaviour
{
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Si la caja se está moviendo horizontalmente por inercia pero queremos que frene al instante
        // cuando el jugador deja de aplicarle una fuerza externa activa, podemos controlarlo así:

        // Verificamos si algún otro objeto (como el jugador) le está aplicando velocidad o si queremos forzar el freno.
        // Una forma muy limpia de hacer que frene de golpe al no haber contacto activo es usar la velocidad lineal:

        // Si quieres que se detenga por completo al instante cuando su velocidad sea baja:
        if (Mathf.Abs(rb.linearVelocity.x) > 0.01f)
        {
            // Opcional: Si quieres comprobar si está chocando con el jugador, 
            // pero si solo quieres que frene al dejar de recibir movimiento:
            // (Aquí podemos aplicar un freno drástico reduciendo la velocidad a 0 rápidamente)
        }
    }

    // Una forma infalible de saber si dejó de ser empujada o de chocar:
    // Si quieres que la caja se frene al instante exacto en que el jugador se separa de ella:
    private void OnCollisionExit2D(Collision2D collision)
    {
        // Si el objeto que se fue era el jugador, detenemos la caja por completo al instante
        if (collision.gameObject.CompareTag("Player"))
        {
            rb.linearVelocity = new Vector2(0f, rb.linearVelocity.y);
            rb.angularVelocity = 0f; // Por si acaso tiene rotación
        }
    }
}
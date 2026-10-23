using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed = 2f;
    public float distanciaMovimiento = 3f;
    public bool seMueveEnVertical = false;


    public float tiempoOffset = 0f; // Puedes cambiar este número en cada plataforma (ej: 0, 1.5, 3)

    private Vector2 posicionInicial;

    void Start()
    {
        posicionInicial = transform.position;
    }

    void Update()
    {
        // Añadimos el offset al tiempo para que cada plataforma empiece en un punto distinto del ciclo
        float desplazamiento = Mathf.Sin((Time.time + tiempoOffset) * speed) * distanciaMovimiento;

        if (seMueveEnVertical)
        {
            transform.position = new Vector2(posicionInicial.x, posicionInicial.y + desplazamiento);
        }
        else
        {
            transform.position = new Vector2(posicionInicial.x + desplazamiento, posicionInicial.y);
        }
    }

    // El sistema para que el jugador viaje con la plataforma se queda igualito
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
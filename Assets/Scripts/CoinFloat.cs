using UnityEngine;

public class CoinFloat : MonoBehaviour
{
    public float velocidadFlotacion = 5f; // Qué tan rápido se mueve
    public float alturaFlotacion = 0.1f;   // Qué tan alto sube y baja

    private Vector3 posicionInicial;

    void Start()
    {
        posicionInicial = transform.position;
    }

    void Update()
    {
        // Usa una onda senoidal para moverla suavemente de arriba a abajo
        float nuevaY = posicionInicial.y + Mathf.Sin(Time.time * velocidadFlotacion) * alturaFlotacion;
        transform.position = new Vector3(transform.position.x, nuevaY, transform.position.z);
    }
}
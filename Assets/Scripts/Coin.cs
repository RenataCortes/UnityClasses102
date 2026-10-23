using UnityEngine;

public class Coin : MonoBehaviour
{
    [Header("Referencia al texto de You Win (Opcional)")]
    public GameObject textoYouWin; // Arrastra aquí tu objeto de texto de la UI si lo tienes

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verificamos si el que tocó la moneda es el jugador
        if (collision.CompareTag("Player"))
        {
            // Si asignaste un objeto de texto en el Inspector, lo activamos
            if (textoYouWin != null)
            {
                textoYouWin.SetActive(true);
            }
            else
            {
                // Si no tienes UI creada aún, al menos mostramos un mensaje en la consola de Unity
                Debug.Log("¡YOU WIN!");
            }

            // Destruimos la moneda para que desaparezca al recogerla
            Destroy(gameObject);
        }
    }
}
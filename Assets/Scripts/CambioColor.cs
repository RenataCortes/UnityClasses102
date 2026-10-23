using UnityEngine;

public class CambioColor : MonoBehaviour
{
    private SpriteRenderer colaSpriteRenderer;

    void Start()
    {
        colaSpriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow)) colaSpriteRenderer.color = Color.red;
        if (Input.GetKey(KeyCode.RightArrow)) colaSpriteRenderer.color = Color.blue;
        if (Input.GetKey(KeyCode.UpArrow)) colaSpriteRenderer.color = Color.yellow;
        if (Input.GetKey(KeyCode.DownArrow)) colaSpriteRenderer.color = new Color(1f, 0.5f, 0f); // Naranja
    }
}
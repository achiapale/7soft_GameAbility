
using UnityEngine;

// Classe per il controllo dei nemici (fantasmi)

public class DanniControl : MonoBehaviour
{
    // Inserimento del danno che infligge il fantasma
    [SerializeField] private float danno;

    // controllo collisione
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<Salute>().Danno(danno);
        }
    }
}

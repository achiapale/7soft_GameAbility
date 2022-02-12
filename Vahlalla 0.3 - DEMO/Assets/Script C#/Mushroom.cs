using UnityEngine;

// controllo del fungo

public class Mushroom : MonoBehaviour
{
    // Dichiaro animator e rigidBody
    private Animator anim;
    private Rigidbody2D body;

    private void Start()
    {        
        anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
    }


    // controllo della collisione:
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            // animazione per la morte del fungo
            anim.SetTrigger("morto");

        }
    }
}


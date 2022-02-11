using UnityEngine;

//controllo del fungo

public class Mushroom : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D body;

    private void Start()
    {        
        anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
    }

    //controllo della collisione
    //animazione per la morte del fungo

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            anim.SetTrigger("morto");

        }
    }
}


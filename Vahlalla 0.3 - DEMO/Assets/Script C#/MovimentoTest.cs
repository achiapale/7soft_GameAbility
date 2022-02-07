using UnityEngine;

// Classe Movimento per "sprite1" (giocatore)

public class MovimentoTest : MonoBehaviour
{

    // creo campo con velocità del player
    [SerializeField] private float speed;

    // dichiaro variabili
    private Rigidbody2D body;
    private float horizontalInput;
    private Animator anim;
    private bool grounded;

    // inizializzo animazioni e posizione
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        transform.localScale = Vector3.one;
    }

    // controllo Update effettuato ad ogni frame
    private void Update()
    {
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);

        // condizione per il salto:
        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            Jump();
        }

        horizontalInput = Input.GetAxis("Horizontal");
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", grounded);

        // Specchia il player in base al movimento
        if (horizontalInput > 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }


    }

    
    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed);
        anim.SetTrigger("jump");
        grounded = false;
    }

    // controllo se tocca il terreno
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "terreno")
        {
            grounded = true;
        }
    }
}

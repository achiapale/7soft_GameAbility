using UnityEngine;

// Controllo IA degli sprite nemici

public class IA_Enemy : MonoBehaviour
{
    [SerializeField] private float recupero;
    [SerializeField] private int damage;
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayer;

    private float tempoRecupero = Mathf.Infinity;

    private Health saluteGiocatore;

    // Delay per evitare il loop del contatto:

    private void Update()
    {
        tempoRecupero += Time.deltaTime;

        if (PlayerInSight())
        {
            if (tempoRecupero >= recupero)
            {
                tempoRecupero = 0;

            }
        }
        
    }

    // Controllo la salute del player:

    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0,Vector2.left,0,playerLayer);

        if(hit.collider != null)
        {
            saluteGiocatore = hit.transform.GetComponent<Health>();

        }
        return hit.collider != null;

      
    }

    // Area di contatto: (se toccata, infligge il danno)

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));


    }

    // Funzione per danneggiare il giocatore:

    private void DamagePlayer()
    {
        if (PlayerInSight())
        {
            saluteGiocatore.Danno(damage);
        }
    }
}

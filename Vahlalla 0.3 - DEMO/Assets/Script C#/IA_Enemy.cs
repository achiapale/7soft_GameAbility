using UnityEngine;

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

    //delay per evitare il contatto con un nemico più volte in un
    //periodo di tempo ristretto

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

    //controllo sulla salute del giocatore

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

    //area di contatto dove il fantasma fa danno

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));


    }

    //funzione per il danno subito

    private void DamagePlayer()
    {
        if (PlayerInSight())
        {
            saluteGiocatore.Danno(damage);
        }
    }
}

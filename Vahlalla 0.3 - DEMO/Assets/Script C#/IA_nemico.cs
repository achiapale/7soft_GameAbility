
using UnityEngine;

public class IA_nemico : MonoBehaviour
{
    [SerializeField] private float recupero;
    [SerializeField] private int damage;
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayer;

    private float tempoRecupero = Mathf.Infinity;

    private Salute saluteGiocatore;

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

    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0,Vector2.left,0,playerLayer);

        if(hit.collider != null)
        {
            saluteGiocatore = hit.transform.GetComponent<Salute>();

        }
        return hit.collider != null;

      
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));


    }

    private void DamagePlayer()
    {
        if (PlayerInSight())
        {
            saluteGiocatore.Danno(damage);
        }
    }
}

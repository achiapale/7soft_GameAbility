using UnityEngine;

// Controllo del nemico (fantasma)

public class GhostControl : MonoBehaviour
{
    [Header ("Punti Movimento")]
    [SerializeField] private Transform LeftEdge;
    [SerializeField] private Transform RightEdge;
    

    [Header("Enemy")]
    [SerializeField] private Transform enemy;

    [Header("Parametri movimento")]
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingLeft;

    private void Awake()
    {
        initScale = enemy.localScale;
    }

    // Sposto il fantasma tra due punti:

    private void Update()
    {
        if (movingLeft)
        {
            if(enemy.position.x >= LeftEdge.position.x)
            {
                MoveInDirection(-1);
            }
            else
            {
                DirectionChange();
            }
            
        }
        else
        {
            if(enemy.position.x <= RightEdge.position.x)
            {
                MoveInDirection(1);

            }
            else
            {
                DirectionChange();
            }
            
        }
        
    }

    private void DirectionChange()
    {
        movingLeft = !movingLeft;
    }


    private void MoveInDirection(int _direction)
    {
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed,
            enemy.position.y, enemy.position.z);
    }


}

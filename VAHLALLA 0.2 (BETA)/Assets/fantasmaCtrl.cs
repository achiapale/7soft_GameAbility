
using UnityEngine;

public class fantasmaCtrl : MonoBehaviour
{
    [Header ("Punti Movimento")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;
    

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

    private void Update()
    {
        if (movingLeft)
        {
            if(enemy.position.x >= leftEdge.position.x)
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
            if(enemy.position.x <= rightEdge.position.x)
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

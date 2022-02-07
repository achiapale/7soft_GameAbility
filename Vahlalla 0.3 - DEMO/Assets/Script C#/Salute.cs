using UnityEngine;

// Gestione della barra di salute (3 cuori)

public class Salute : MonoBehaviour
{
    // Campo per l'inserimento della salute iniziale (3)
    [SerializeField] private float saluteIniziale;

    private bool morto;
    public float saluteAttuale { get; private set; }
    private Animator anim;

    private void Awake()
    {
        saluteAttuale = saluteIniziale;
        anim = GetComponent<Animator>();

    }

    public void Danno(float _damage)
    {
        saluteAttuale = Mathf.Clamp(saluteAttuale - _damage, 0, saluteIniziale);

        if (saluteAttuale > 0)
        {
            anim.SetTrigger("hurt");
        }
        else
        {
            if (!morto)
            {
                anim.SetTrigger("die");
                GetComponent<MovimentoTest>().enabled=false;
                morto = true;
            }
            
        }
    }  
    
  
        
    
}

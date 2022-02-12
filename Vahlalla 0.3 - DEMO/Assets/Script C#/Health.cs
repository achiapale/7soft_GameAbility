using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;

// Gestione della barra di salute (3 cuori)

public class Health : MonoBehaviour
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

    // Verifico se il player ha terminato le vite:

    public void Danno(float _damage)
    {
        saluteAttuale = Mathf.Clamp(saluteAttuale - _damage, 0, saluteIniziale);

        if (!morto)
        {
            if (saluteAttuale <= 0)
            {
                anim.SetTrigger("die");
                GetComponent<MovementTest>().enabled = false;
                morto = true;


            } else {
              anim.SetTrigger("hurt");
            }
        }

    }

    // Verifico se il player è morto:

    private void Update()
    {
        if (morto)

        {
            StartCoroutine(Timedelay());

            SceneManager.LoadScene(2);
            morto = false;

        }
    }

    
    IEnumerator Timedelay()
    {
        yield return new WaitForSeconds(2);
        anim.SetTrigger("stand");
        GetComponent<MovementTest>().transform.position = new Vector3(-3, -3.64f, 0);
        GetComponent<MovementTest>().enabled = true;
        RipristinaSalute();

    }

    // Azzero i valori (riporto salute a 3):

    public void RipristinaSalute()
    {
        saluteAttuale = saluteIniziale;
    }
}

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

    //verifica se il personaggio ha terminato le vite o se bisogna toglierne una

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

    //verifica se il personaggio è morto

    private void Update()
    {
        if (morto)

        {
            StartCoroutine(Timedelay());

            SceneManager.LoadScene(2);
            morto = false;

        }
    }

    //delay (?)

    IEnumerator Timedelay()
    {
        yield return new WaitForSeconds(2);
        anim.SetTrigger("stand");
        GetComponent<MovementTest>().transform.position = new Vector3(-3, -3.64f, 0);
        GetComponent<MovementTest>().enabled = true;
        RipristinaSalute();

    }

    //quando riparte il giocosi azzerano i valori

    public void RipristinaSalute()
    {
        saluteAttuale = saluteIniziale;
    }
}

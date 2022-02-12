using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Script per la schermata di vittoria:

public class Victory : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Se il player tocca la chest finale, carico scena 5:
        
        if (collision.tag == "chest")
        {
            SceneManager.LoadScene(5);

        }
    }

}

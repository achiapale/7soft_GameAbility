
using UnityEngine;
using UnityEngine.UI;

public class BarraSalute : MonoBehaviour
{
    [SerializeField] private Salute saluteGiocatore;
    [SerializeField] private Image barraTotale;
    [SerializeField] private Image barraAttuale;

    // Riempio barra salute
    private void Start()
    {
        barraTotale.fillAmount = saluteGiocatore.saluteAttuale/10;
    }

    // Aggiorno ad ogni fotogramma
    private void Update()
    {
        barraAttuale.fillAmount = saluteGiocatore.saluteAttuale/10;
    }
}

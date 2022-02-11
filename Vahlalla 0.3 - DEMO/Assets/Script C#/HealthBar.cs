using UnityEngine;
using UnityEngine.UI;

//barra della salute

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health saluteGiocatore;
    [SerializeField] private Image TotalHealthBar;
    [SerializeField] private Image NowHealthBar;

    // Riempio barra salute
    private void Start()
    {
        TotalHealthBar.fillAmount = saluteGiocatore.saluteAttuale/10;
    }

    // Aggiorno ad ogni fotogramma
    private void Update()
    {
        NowHealthBar.fillAmount = saluteGiocatore.saluteAttuale/10;
    }
}

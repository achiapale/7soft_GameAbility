using UnityEngine;

// controllo del volume

public class VolumeValueChange : MonoBehaviour
{
    private AudioSource audioSrc;
    private float musicVolume = 1f;

    // inizializzazione
    void Start()
    {
        // controllo del componente AudioSource
        audioSrc = GetComponent<AudioSource>();
    }

    void Update()
    {

        // l'opzione del volume deve essere uguale al vlaore della barra
        audioSrc.volume = musicVolume;
    }

    // prende il valore dello slider e lo imposta come musicValue
    public void SetVolume(float vol)
    {
        musicVolume = vol;
    }
}


using UnityEngine;

// Classe cameraControl per il movimento della videocamera

public class cameraControl : MonoBehaviour
{

    [SerializeField] private Transform player;
    [SerializeField] private float dist;
    // Velocit� videocamera:
    [SerializeField] private float velCamera;
    private float lookAhead;

    
    private void Update()
    {
        transform.position = new Vector3(player.position.x + lookAhead, transform.position.y, transform.position.z);
        lookAhead = Mathf.Lerp(lookAhead, (dist * player.localScale.x), Time.deltaTime * velCamera);
    }


}
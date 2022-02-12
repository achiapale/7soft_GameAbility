using UnityEngine;

// Classe cameraControl per il movimento della videocamera

public class CameraControl : MonoBehaviour
{

    [SerializeField] private Transform player;
    [SerializeField] private float dist;
    // Velocità videocamera:
    [SerializeField] private float velCamera;
    private float lookAhead;


// Segue il personaggio:

    private void Update()
    {
        transform.position = new Vector3(player.position.x + lookAhead, transform.position.y, transform.position.z);
        lookAhead = Mathf.Lerp(lookAhead, (dist * player.localScale.x), Time.deltaTime * velCamera);
    }

}

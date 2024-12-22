
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    private Transform player;
    private bool reachedBoss;
    [SerializeField] private GameObject bossBorder;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
        offset = transform.position - player.position; // Υπολογισμός απόστασης 
        reachedBoss = false;
    }

    void LateUpdate()
    {
        // Η θέση της κάμερας ακολουθεί τον παίκτη
        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Κρατάμε την κάμερα στο ίδιο ύψος
        transform.position = new Vector3(transform.position.x, transform.position.y, offset.z);
    }

    private void Update()
    {
        //Get camera position and make it equal to the player's
        Vector3 cameraPosition = transform.position;
        cameraPosition.x = player.position.x;
        if (cameraPosition.x >= 150)
            reachedBoss = true; //Flag for when the player has reached the boss area

        if (reachedBoss)
            bossBorder.SetActive(true); //Create border and trap the player in the boss area

        if (!(cameraPosition.x <= -8) && !reachedBoss)
            transform.position = cameraPosition; //If the camera isn't going beyond any borders then follow the player
    }
}




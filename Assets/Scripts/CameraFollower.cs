using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    private Transform player;
    private bool reachedBoss;
    [SerializeField] private GameObject bossBorder;

    private void Awake() {
        player = GameObject.FindWithTag("Player").transform;
        reachedBoss = false;
   }

   private void Update() {
        
        //Get camera position and make it equal to the player's
        Vector3 cameraPosition = transform.position;
        cameraPosition.x = player.position.x;
        if(cameraPosition.x >= 150)
            reachedBoss = true; //Flag for when the player has reached the boss area
        if(reachedBoss)
            bossBorder.SetActive(true); //Create border and trap the player in the boss area
        if(!(cameraPosition.x <= -8) && !reachedBoss)
            transform.position = cameraPosition; //If the camera isn't going beyond any borders then follow the player
   }
}

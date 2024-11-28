using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    private Transform player;

    private void Awake() {
        player = GameObject.FindWithTag("Player").transform;
   }

   private void Update() {
        Vector3 cameraPosition = transform.position;
        cameraPosition.x = player.position.x;
        if(!(cameraPosition.x <= -14))
            transform.position = cameraPosition; 
   }
}

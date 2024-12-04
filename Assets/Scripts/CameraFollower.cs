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
        Vector3 cameraPosition = transform.position;
        cameraPosition.x = player.position.x;
        if(cameraPosition.x >= 148)
            reachedBoss = true;
        if(reachedBoss)
            bossBorder.SetActive(true);
        if(!(cameraPosition.x <= -8) && !reachedBoss)
            transform.position = cameraPosition; 
   }
}

using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    [SerializeField] private GameObject playerObject;
    [SerializeField] private GameObject playerHealthBar;
    [SerializeField] private GameObject enemyHealthBar;
    [SerializeField] private Vector3 offset = new Vector3(-0.1f, 0.5f, 0); // Η απόσταση της health bar από τον παίκτη 
    [SerializeField] private Image pForegroundImage;
    [SerializeField] private Image eForegroundImage;

    public void setEnemyHealthBarActive(bool active) {
        enemyHealthBar.SetActive(active);
    }

    private void Update()
    {            
        if(playerObject.CompareTag("Player")) {
            // Κρατάει τη θέση του health bar σταθερή σε σχέση με τον παίκτη, χωρίς περιστροφή
            playerHealthBar.transform.position = playerObject.transform.position + offset; // Ακολουθεί τη θέση του παίκτη με την απόσταση
        }
    }

    public void UpdateHealthBar(float currentHealth, float maxHealth, string character)
    {
        if(character == "player") {
            if (pForegroundImage != null)
            {
                pForegroundImage.fillAmount = currentHealth / maxHealth; // Υπολογισμός ποσοστού
            }
        }
        else if(character == "enemy") {
            if (eForegroundImage != null)
            {
                eForegroundImage.fillAmount = currentHealth / maxHealth; // Υπολογισμός ποσοστού
            }
        }
        
    }
}
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene3_Changer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            if(enemies.Length == 0)
            {
                SceneManager.LoadScene("Game3");
            }
            else
            {
                Debug.Log("Defeat all enemies first");
            }
        }
    }
}
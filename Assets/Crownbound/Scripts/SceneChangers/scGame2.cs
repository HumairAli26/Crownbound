using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Changer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject[] enemies = GameObject.FindGameObjectWithTag("Enemy");
            if(enemies.Length == 0)
            {
                SceneManager.LoadScene("Game2");
            }
            else
            {
                Debug.Log("Defeat all enemies first");
            }
        }
    }
}
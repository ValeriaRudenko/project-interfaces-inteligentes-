
using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class HitPoints : MonoBehaviour
{
    public int hp = 100;
    
    
    public TextMeshProUGUI scoreText;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Skeleton"))
        { 
            scoreText.text = "HP: " + Mathf.Ceil(hp).ToString();          
        }
        if (hp <= 0){
            SceneManager.LoadScene("Lost");
            Cursor.lockState = CursorLockMode.None; 
        Cursor.visible = true; 
        }
    }
}

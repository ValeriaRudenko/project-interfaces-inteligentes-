
using System.Collections;
using UnityEngine;
using TMPro;

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
    }
}

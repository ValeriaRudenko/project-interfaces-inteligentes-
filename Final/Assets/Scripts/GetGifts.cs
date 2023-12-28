
using System.Collections;
using UnityEngine;
using TMPro;

public class GetGifts : MonoBehaviour
{
    private int score = 0;
    public TextMeshProUGUI scoreText;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gift"))
        {
            Destroy(other.gameObject);
            score +=1;
            scoreText.text = Mathf.Ceil(score).ToString();
        }
    }
}

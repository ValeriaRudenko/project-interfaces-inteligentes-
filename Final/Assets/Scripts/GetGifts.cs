
using System.Collections;
using UnityEngine;
using TMPro;

public class GetGifts : MonoBehaviour
{
    private int score = 0;
    
    public GameObject gift1;
    public GameObject gift2;
    public TextMeshProUGUI scoreText;
    void SpawnGift(){

        Vector3 position = new Vector3(Random.Range(-8.0F, 8.0F), 1, Random.Range(-8.0F, 8.0F));
        int gift =Random.Range(-1, 1);
        if(gift>=0){
            Instantiate (gift1, position, Quaternion.identity);
        }else{

            Instantiate (gift2, position, Quaternion.identity);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gift"))
        {
            Destroy(other.gameObject);
            score +=1;
            scoreText.text = Mathf.Ceil(score).ToString();
            SpawnGift();
        }
    }
}

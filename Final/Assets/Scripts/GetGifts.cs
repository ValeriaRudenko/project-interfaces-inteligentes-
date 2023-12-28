
using System.Collections;
using UnityEngine;
using TMPro;

public class GetGifts : MonoBehaviour
{
    private int score = 0;
    
    public GameObject gift1;
    public GameObject gift2;
    public TextMeshProUGUI scoreText;

    public int count = 50;
    void Start(){
         for(int i=0; i <count; i++){
            SpawnGift();
         }
    }
    void SpawnGift(){
        
        float randomXOffset = (Random.Range(0, 2) == 0) ? 0.0F : 63.0F;
        Vector3 position = new Vector3(Random.Range(-9.0F, 25.0F) + randomXOffset, 2.5F, Random.Range(-68.0F, 5.0F));

        int gift =Random.Range(-1, 1);
        if(gift>=0){
            Instantiate (gift1, position, Quaternion.identity);
        }else{
            Instantiate (gift2, position, Quaternion.identity);
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Gift"))
        {
            Destroy(other.gameObject);
            score +=1;
            scoreText.text = Mathf.Ceil(score).ToString();
            SpawnGift();
            
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    GameManager GM;
    PlayerController pc;
    public float HP=100.0f;
    public GameObject Bullet;
    float   count;
    int weightAngle;
    float OneattackRate;
    float intervalAngle;
    
    [SerializeField] int Score = 100000000;
    // Start is called before the first frame update
    void Start()
    { 
        pc= GameObject.Find("Player").GetComponent<PlayerController>();
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        count=30;
        weightAngle=0;
        OneattackRate=1.0f;
        intervalAngle = 360/count;
        One();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(HP<=0){
            Destroy(gameObject);
            GM.Score+=Score;
        }
    }
    void OnTriggerEnter2D(Collider2D other){
        
        if(other.gameObject.tag=="Bullet"){
            HP-=pc.Power;
        }
        
    }
    
    void One(){
        
            for(int i=0; i<count;i++)
            {
                GameObject clone =Instantiate(Bullet,transform.position,Quaternion.identity);
                float angle = weightAngle+intervalAngle*i;

                float x = Mathf.Cos(angle*Mathf.PI / 180.0f);
                float y = Mathf.Sin(angle*Mathf.PI / 180.0f);

                clone.GetComponent<BossBullet>().MoveTo(new Vector2(x,y));


            }
            weightAngle+=1;

            Invoke("One",OneattackRate);
        
    }
    void Destroy()
    {
        GM.End();
    }

}

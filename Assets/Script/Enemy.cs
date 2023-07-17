using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameManager GM;
    PlayerController pc;
    [SerializeField] float HP=0f;
    [SerializeField] int Score=0;
    // Start is called before the first frame update
    void Start()
    {
        pc= GameObject.Find("Player").GetComponent<PlayerController>();
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(HP<=0){
            Destroy(gameObject);
            GM.Score+=Score;
        }
        else if(transform.position.y<-5.0f){
            Destroy(gameObject);
        }
    }
   
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag=="Player"){
            Destroy(gameObject);
        }
        if(other.gameObject.tag=="Bullet"){
            HP-=pc.Power;
        }
        
    }
}

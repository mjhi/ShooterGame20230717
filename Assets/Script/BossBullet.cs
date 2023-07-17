using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{


    GameManager GM;
    [SerializeField] float speed = 0f;
    Vector3 dir =Vector3.up;
    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        

        transform.position += dir*speed*Time.deltaTime;

        if(transform.position.y >5.0f || transform.position.y <-5.0f){
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other){
        
        if(other.gameObject.tag=="Player"){
            
            GM.hit();
            Destroy(gameObject);
        }
        
    }
    public void MoveTo(Vector3 Direc){
        dir = Direc;
    }

}

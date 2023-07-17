using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 0f;
    Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dir = Vector3.up;

        transform.position += dir*speed*Time.deltaTime;

        if(transform.position.y >5.0f){
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other){
        
        if(other.gameObject.tag=="Enemy"){
            Destroy(gameObject);
        }
        
    }
    public void MoveTo(Vector3 Direc){
        dir = Direc;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
     
    float moveX,moveY;
    public float Power=5f;
    [SerializeField] float moveSpeed = 2f;
    
    GameManager GM;
    public GameObject BulletStart;
    public GameObject Bullet;
    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxis("Horizontal")*moveSpeed*Time.deltaTime;
        moveY = Input.GetAxis("Vertical")*moveSpeed*Time.deltaTime;

        transform.position = new Vector2(transform.position.x+moveX,transform.position.y+moveY);

        if (Input.GetKeyDown(KeyCode.Space))
        {

            Shoot();

        }

    }

    void LateUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x,-2.6f,2.6f),
        Mathf.Clamp(transform.position.y, -4.6f,4.6f));
    }

    void Shoot(){
        Instantiate(Bullet,BulletStart.transform.position,Quaternion.identity);
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag=="Enemy"){
            GM.hit();
        }
        else if(other.gameObject.tag=="Gob"){
            Power*=2;
            Destroy(other.gameObject);
        }
        
    }
}

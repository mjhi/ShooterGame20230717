using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
   
    public int HP=3;
    public GameObject[] HPCount;
    public GameObject GameOver;
    public int Score=0;
    [SerializeField] float delay;
    public int UnitInt=50;
    public GameObject EndScreen;
    public TMP_Text ScoreT;
    public TMP_Text EndScore;
    public GameObject[] Enemy;
    public GameObject Boss;
    public GameObject StartBtn;
    public GameObject[] Gob;
    // Start is called before the first frame update
    void Start()
    {
        delay=2.0f;
        
    }
    public void GameStart()
    {
        for(int i=0; i<Gob.Length; i++){
            Gob[i].SetActive(true);
        }
        StartBtn.SetActive(false);
        Spawn();
    }
    // Update is called once per frame
    void Update()
    {
        ScoreT.text = "Score : "+Score.ToString();
        if(UnitInt==40){
            delay=1.5f;
        }
        else if(UnitInt==20){
            delay=0.5f;
        }
        else if(UnitInt==0){
            BossStart();
            UnitInt-=1;
        }

        if(HP==0){
            GameOver.SetActive(true);
        }
    }

    public void Spawn()
    {
        if(UnitInt>0){
            float x =Random.Range(-2.3f, 2.3f);
            int index = Random.Range(0,2);
            Instantiate(Enemy[index],new Vector3(x,5.5f,0),Quaternion.identity);
        
            UnitInt-=1;
            Invoke("Spawn",delay);
        }
        
    }

    void BossStart()
    {
        Instantiate(Boss,new Vector3(0.0f,2.0f,0),Quaternion.identity);
    }
    public void End()
    {
        EndScore.text = "Score : "+Score.ToString();
        EndScreen.SetActive(true);
    }
    public void hit()
    {
        HP-=1;
        HPCount[HP].SetActive(false);
    }
}

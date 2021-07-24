using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            Destroy(gameObject);
        } 
        if (collision.gameObject.tag == "Player")
        {
            player.GetComponent<playermove>().Life--;
            agent.speed=0;
        }
        
       
    }
    GameObject player;
    Animator anim;
    UnityEngine.AI.NavMeshAgent agent;
    public float speed=1.7f ;
    Vector3 _rotation;
    private void Start() {
     player = GameObject.FindGameObjectWithTag("Player");  
     agent=GetComponent<UnityEngine.AI.NavMeshAgent>();
     _rotation=new Vector3(player.transform.position.x,transform.position.y,player.transform.position.z);
     agent.destination=player.transform.position;
    }
    private void Update() {
        agent.destination=player.transform.position;
        
    }
	
}
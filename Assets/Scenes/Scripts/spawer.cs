using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawer : MonoBehaviour
{
  public GameObject[] Enemigos;
  int  max_point;
  [SerializeField]
  float TimeToSpaw=7f;
  float currentToSpaw=0f;
  [SerializeField]
  Vector3 Origin;
  private void Start() {
      currentToSpaw=TimeToSpaw;
       max_point=Enemigos.Length;
  }
  private void Update() {
    currentToSpaw-=Time.deltaTime;
    
    if(currentToSpaw<0){
      Vector3 pos=transform.position;
      pos+=Vector3.forward*Origin.z*(Random.value-0.5f);
      pos+=Vector3.right*Origin.x*(Random.value-0.5f);
      Instantiate(Enemigos[Random.Range(0, max_point)],pos,Quaternion.identity);
      currentToSpaw=TimeToSpaw;
    }

  }

}

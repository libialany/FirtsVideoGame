using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(PlayerInput))]
public class playermove : MonoBehaviour
{
    
    [Header("Life")]
    [SerializeField]
    public int Life;
    [Header("Counter")]
    public float CanPower;
    [SerializeField]
    float currentCanPower;
    bool already=true;
    ///////
    public Image img;
    [SerializeField]
    float timetotation;
    public GameObject punch;
    [SerializeField]
    float valorAlfa;
    [Range(1f,5f)]
    //4f
    public float speedcam;
    [Range(5f,16f)]
    public float speed;
    private PlayerInput playerInput;
    private CharacterController characterController;
    private Transform child;
    private void Awake() {
        Life=11;
        punch.SetActive(false);
        currentCanPower=CanPower;
        valorAlfa=1f;
        playerInput=GetComponent<PlayerInput>();
        characterController=GetComponent<CharacterController>();
        child=transform.GetChild(0).transform;
    }
    
    private void FixedUpdate() {
        Vector2 moveInput=playerInput.actions["Move"].ReadValue<Vector2>();
        float x=moveInput.x;
        float z=moveInput.y;
        //print(moveInput);
        if(Life<0){
            SceneManager.LoadScene(0);
        }
        Vector3 moveDirection=transform.right*x+transform.forward*z;
        characterController.Move(moveDirection*speed*Time.deltaTime);
        attack();
        if(moveInput!=Vector2.zero){
            Quaternion rotation =Quaternion.Euler(new Vector3(child.localEulerAngles.x,Camera.main.transform.localEulerAngles.y,child.localEulerAngles.z));
            child.rotation=Quaternion.Lerp(child.rotation,rotation,Time.deltaTime*speedcam);
        }
        if(!already){
            currentCanPower-=Time.deltaTime;
                 if(currentCanPower<0){
                        already=true;
                        currentCanPower=CanPower;
                        valorAlfa=1f;
                    }
        }

        img.color=new Color(1,1,1,valorAlfa);
    }
    void attack(){
        if( playerInput.actions["Jump"].triggered && already){
            StartCoroutine(rotar());
            valorAlfa=0.3f;
            already=false;
        }
    }
    private IEnumerator rotar()
    {
            punch.SetActive(true);
            yield return new WaitForSeconds(timetotation);
            punch.SetActive(false);
    }
}

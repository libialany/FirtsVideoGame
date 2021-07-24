using UnityEngine;
using UnityEngine.UI;
public class AddPlayerControlVelocity : MonoBehaviour
{
    [SerializeField]
    float AngularVelocity=400f;
    private void FixedUpdate() {
        transform.Rotate(0,AngularVelocity*Time.deltaTime,0);
    }
    
}

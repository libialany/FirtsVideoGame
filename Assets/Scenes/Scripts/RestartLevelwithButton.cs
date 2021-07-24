using UnityEngine;
using UnityEngine.SceneManagement;
public class RestartLevelwithButton : MonoBehaviour
{
    //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    public void Jugar(){
        SceneManager.LoadScene(1);
    }
    public void Salir(){
        Application.Quit();
    }
}

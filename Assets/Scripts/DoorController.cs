using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    private void OnTriggerEnter(Collider collidingObject)
    {
        if(collidingObject.gameObject.name == "Player")
        {
            //Loads the next scene from the Build Profiles-> Scene List
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseShow : MonoBehaviour
{
private bool menuInput;
private bool menuActive;
[SerializeField] private GameObject Menu;
 void Update()
    {
        menuInput = Input.GetKeyDown(KeyCode.Escape);
        if (menuInput)
        {
        if (!menuActive)
        {
            Menu.SetActive(true);
            
        }
        else{
            Menu.SetActive(false);
        }
        menuActive= !menuActive;
        }
    }
    void Start()
    {
      
    }
}

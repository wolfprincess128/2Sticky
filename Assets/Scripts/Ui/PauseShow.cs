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
                Time.timeScale = 0f;
        }
        else{
            Menu.SetActive(false);
                Time.timeScale = 1f;
        }
        menuActive= !menuActive;
        }
    }
    void Start()
    {
      
    }
}

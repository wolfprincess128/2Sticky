using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform playerPos;
    [SerializeField] private Vector3 Offset;
    public int FovState;
    private CanvasGroup vignetteBorder;
    void Start()
    {
        vignetteBorder = GameObject.Find("vingette_overlay").GetComponent<CanvasGroup>();
        vignetteBorder.alpha = 0;
    }
    void LateUpdate()
    {
        this.transform.position = playerPos.transform.position + Offset;
    }

    public void SwitchFOV()
    {
        switch(FovState)
            {
                case 0:
                    Camera.main.fieldOfView = 75f;
                    vignetteBorder.alpha = 0.3f;
                    break;
                case 1:
                    Camera.main.fieldOfView = 70f;
                    vignetteBorder.alpha = 0.5f;
                    break;
                case 2:
                    Camera.main.fieldOfView = 65f;
                    vignetteBorder.alpha = 0.6f;
                    break;
                case 3:
                    Camera.main.fieldOfView = 60f;
                    vignetteBorder.alpha = 0.9f;
                    break;
                default:
                   // this will have you white out. either remove a certain amount of points or just like kill you. lol idk
                   Debug.Log("You whited out !!");
                    break;
            }
        FovState++;
    } 

    private void EaseFOV()
    {
        //plan to replace the current jump in fov to be a linear zoom
    }
}

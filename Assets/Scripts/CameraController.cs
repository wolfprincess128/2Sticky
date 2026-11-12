using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform playerPos;

    [SerializeField] private Vector3 Offset;

    private int state;

    private FOVstate[] FOVlevel = new FOVstate[6];

    private CanvasGroup vignetteBorder;
    void Start()
    {
        vignetteBorder = GameObject.Find("vingette_overlay").GetComponent<CanvasGroup>();
        FOVlevel[0] = new FOVstate(80f,0f);
        FOVlevel[1] = new FOVstate(75f, 0.2f);
        FOVlevel[2] = new FOVstate(70f, 0.6f);
        FOVlevel[3] = new FOVstate(65f, 0.7f);
        FOVlevel[4] = new FOVstate(60f, 0.8f);
        FOVlevel[5] = new FOVstate(55f, 1f);
        SwitchFOV();
    }

    void LateUpdate()
    {
        this.transform.position = playerPos.transform.position + Offset;

    }

    public void SwitchFOV()
    {
        if (state <= FOVlevel.Length - 1)
        { 
            Camera.main.fieldOfView = FOVlevel[state].targetFOV;
            vignetteBorder.alpha = FOVlevel[state].targetBorder;
            state++;
        }
        else
        { 
            resetFOV();
            //whiteout sequence. lose points.
        }
    }

    public void resetFOV()
    {
        state = 0;
        SwitchFOV();
    }
}

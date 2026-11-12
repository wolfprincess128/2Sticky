using UnityEngine;

public class FOVstate
{
    public float targetFOV;
    public float targetBorder;

    public FOVstate()
    {
        targetFOV = 90f;
        targetBorder = 0.0f;
    }

    public FOVstate(float _fov, float _border)
    {
        targetFOV = _fov;
        targetBorder = _border;
    }
}

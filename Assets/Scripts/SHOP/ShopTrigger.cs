using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShopTrigger : MonoBehaviour
{
    private Camera camShop;
    private Camera camMain;
    public bool inShop = false;

    private void Start()
    {
        camShop = GameObject.Find("ShopCam").GetComponent<Camera>();
        camMain = GameObject.Find("Camera").GetComponent<Camera>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inShop = true;
            camMain.enabled = false;
            camShop.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inShop = false;
            camMain.enabled = true;
            camShop.enabled = false;
        }
    }
}

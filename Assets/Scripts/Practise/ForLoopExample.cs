using UnityEngine;

public class ForLoopExample : MonoBehaviour
{
    public int[] itemsToDrop;
   
    void Start()
    {
    itemsToDrop = new int[] {1,23,45,16,21};

    for (int i = 0; i < itemsToDrop.Length; i++)
    {
        Debug.Log("Hi mate your Lucky Number isss.,.,., " + itemsToDrop[i]);
    }
    }

}

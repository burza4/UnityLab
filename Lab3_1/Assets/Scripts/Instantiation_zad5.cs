using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Instantiation_zad5 : MonoBehaviour
{
    public GameObject block;
    public int width = 13;
    public int length = 4;
    public int space = 2;
    public int y = 1;
    
    void Start()
    {
        for (int z = 0; z < length; ++z)
        {
            z += space;
            for (int x = 0; x < width; ++x)
            {
                Instantiate(block, new Vector3(x, y, z), Quaternion.identity);
                x += space;
            }
        }
    }
}

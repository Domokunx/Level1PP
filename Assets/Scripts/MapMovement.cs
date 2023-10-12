using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MapMovement : MonoBehaviour
{
    private int drunkLevel = 1;
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SwayScreen();
    }

    private void SwayScreen()
    {
        transform.RotateAround(target.transform.position, Vector3.forward, 70 * Time.deltaTime);
    }
}

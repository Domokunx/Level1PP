using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MapMovement : MonoBehaviour
{
    PlayerManager pm;
    int counter;
    bool rotateLeft;
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        pm = target.GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckRotation();
        SwayScreen();
    }

 
    private void SwayScreen()
    {
        if (rotateLeft)
        {
            transform.RotateAround(target.transform.position, Vector3.forward, 20 * Time.deltaTime * pm.drunkLevel);
        }
        else
        {
            transform.RotateAround(target.transform.position, Vector3.forward, 20 * -Time.deltaTime * pm.drunkLevel);
        }
    }

    private void CheckRotation()
    {
        if (counter++ == 20)
        {
            rotateLeft = !rotateLeft;
            counter = 0;
        }
    }
}

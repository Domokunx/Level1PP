using UnityEngine;

public class MapMovement : MonoBehaviour { 
    PlayerManager pm;
    bool rotateLeft;
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CheckRotation", 0, 3f);
        pm = target.GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
          

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

   void CheckRotation()
    {
        rotateLeft = !rotateLeft;
        return;
    }
}

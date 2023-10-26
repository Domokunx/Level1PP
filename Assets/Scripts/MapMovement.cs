using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class MapMovement : MonoBehaviour { 
    PlayerManager pm;
    bool rotateLeft;
    public GameObject target;

    public Volume volume;
    LensDistortion ld;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CheckRotation", 0, 3f);
        pm = target.GetComponent<PlayerManager>();
        ld = volume.GetComponent<LensDistortion>();
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

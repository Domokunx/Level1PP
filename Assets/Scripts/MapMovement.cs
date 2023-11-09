using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class MapMovement : MonoBehaviour { 
    PlayerManager pm;
    bool rotateLeft;
    public GameObject player;
    public GameObject map;

    private float currIntensity;
    public Volume volume;
    VolumeProfile profile;
    LensDistortion LD;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CheckRotation", 0, 3f);
        pm = FindAnyObjectByType<PlayerManager>();
        profile = volume.sharedProfile;
        if (!profile.TryGet<LensDistortion>(out var ld)) {
            ld = profile.Add<LensDistortion>(false);
        }

        ld.intensity.overrideState = true;
        ld.intensity.value = 0;
        LD = ld;
    }

    // Update is called once per frame
    void Update()
    {
        if (pm.drunkLevel == 0)
        {
            LD.intensity.value = 0;         
        }
        SwayScreen();
    }

 
    private void SwayScreen()
    {
        if (rotateLeft)
        {
            currIntensity = LD.intensity.GetValue<float>() + 0.01f * pm.drunkLevel;
            LD.intensity.value = Mathf.Clamp(currIntensity, 0, 0.3f);
            map.transform.RotateAround(player.transform.position, Vector3.forward, 20 * Time.deltaTime * Mathf.Log10(1 + pm.drunkLevel));
        }
        else
        {
            currIntensity = LD.intensity.GetValue<float>() - 0.01f * pm.drunkLevel;
            LD.intensity.value = Mathf.Clamp(currIntensity, -0.3f, 0);
            map.transform.RotateAround(player.transform.position, Vector3.forward, 20 * -Time.deltaTime * Mathf.Log10(1 + pm.drunkLevel));
        }
    }

   void CheckRotation()
    {
        rotateLeft = !rotateLeft;
        return;
    }
}

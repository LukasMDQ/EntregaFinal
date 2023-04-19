using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PosProcess : MonoBehaviour
{
    public PostProcessVolume vol;
    private ColorGrading _color;
    private Bloom _bloom;
   
    
    void Start()
    {
        vol.profile.TryGetSettings(out _color);
        vol.profile.TryGetSettings(out _bloom);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _color.contrast.value = 100f;
            _color.saturation.value = 100f;
            _color.temperature.value = 20f;
            _bloom.intensity.value = 20;
            




        }
        
    }
}

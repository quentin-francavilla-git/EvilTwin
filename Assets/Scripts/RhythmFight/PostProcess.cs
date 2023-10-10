using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcess : MonoBehaviour
{
    private PostProcessVolume postprocess;
    private Bloom bloom;

    private float valuetest;
    private bool blooming;

    void Start()
    {
        postprocess = GetComponent<PostProcessVolume>();
        postprocess.profile.TryGetSettings(out bloom);
        bloom.intensity.value = 0.0f;
        blooming = false;
    }

    void Update()
    {
        if (blooming)
        {
            valuetest += 400 * Time.deltaTime;
            if (valuetest > 45)
                blooming = false;
        }
        else
        {
            if (valuetest > 0)
                valuetest -= 400 * Time.deltaTime;
        }

        bloom.intensity.value = valuetest;
    }

    public void BloomUp()
    {
        blooming = true;
    }
}

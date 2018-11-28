using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowSprite : MonoBehaviour {

    Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        

        if (rend == null)
            Debug.Log("Renderer is empty");
        //GetComponent<Renderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
        GetComponent<Renderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.TwoSided;
        GetComponent<Renderer>().receiveShadows = true;

        
        
    }

    

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTextureSetup : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera cameraB;
    public Material cameraMatB;
    void  Start()
    {
        if(cameraB.targetTexture!= null){
            cameraB.targetTexture.Release();

        }
        cameraB.targetTexture = new RenderTexture(Screen.width ,Screen.height , 24);
        cameraMatB.mainTexture = cameraB.targetTexture;
    }

    // Update is called once per frame
    
    
}

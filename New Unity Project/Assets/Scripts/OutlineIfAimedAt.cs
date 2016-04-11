using UnityEngine;
using System.Collections;

public class OutlineIfAimedAt : MonoBehaviour {

    public Material outlineMat;
    Material defaultMat;
    bool usingOutline = false;
    Renderer renderer;

	// Use this for initialization
	void Start () {
        renderer = GetComponent<Renderer>();
        defaultMat = renderer.material;

	}

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hitInfo;
        Physics.Raycast(ray,out hitInfo);

        bool hitDetected = false;
        foreach(Collider c in gameObject.GetComponents<Collider>())
        {
            if (hitInfo.collider == c) //player is looking at the object directly
            {
                if (!usingOutline)
                {
                    renderer.material = outlineMat;
                    usingOutline = true;
                }
                hitDetected = true;
                break;
            }
        }
        if (!hitDetected && usingOutline)
        {
            renderer.material = defaultMat;
            usingOutline = false;
        }
	}
}

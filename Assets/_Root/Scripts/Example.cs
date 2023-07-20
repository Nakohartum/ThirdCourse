using UnityEngine;

public class Example : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject go = GameObject.CreatePrimitive(PrimitiveType.Plane);
        Renderer rend = go.GetComponent<Renderer>();
        rend.material.mainTexture = Resources.Load<Texture>("glass");
    }
}

using UnityEngine;

public class MoverCamara : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0.01f, 0.0f));
    }
}

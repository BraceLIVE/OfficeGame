using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonitorScreen : MonoBehaviour
{
    private GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;

        Texture2D newTexture = Resources.Load<Texture2D>("unlocked");

        if (newTexture == null)
        {
            Debug.LogError("Die PNG-Datei konnte nicht geladen werden. Stelle sicher, dass sie im Assets/Resources-Ordner liegt und die Dateiendung korrekt ist.");
            return;
        }

        Material newMaterial = new Material(Shader.Find("Standard"));
        newMaterial.mainTexture = newTexture;

        Renderer renderer = obj.GetComponent<Renderer>();

        renderer.material = newMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

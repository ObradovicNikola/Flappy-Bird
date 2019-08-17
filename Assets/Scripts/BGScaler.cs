using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScaler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var height = Camera.main.orthographicSize * 2f;
        var width = height / Screen.height * Screen.width;

        if (gameObject.name == "Background")
        {
            transform.localScale = new Vector3(width, height, 0);
        }
        else transform.localScale = new Vector3(width + 3f, 4, 0);
    }
}

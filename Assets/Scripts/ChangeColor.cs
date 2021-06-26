using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChangeColor : MonoBehaviour
{

    public Color[] colors;

    Color oneColor;
    Color twoColor;
    int rndColor;
    public Camera cam;
    public Material floorMaterial;

    // Start is called before the first frame update
    void Start()
    {

        rndColor = Random.Range(0, colors.Length);
        floorMaterial.color = colors[rndColor];
        twoColor = colors[rndColorFunc ()];
        cam = GetComponent<Camera>();

    }

    int rndColorFunc()
    {
        int rndTwoColor = Random.Range(0, colors.Length);

        while (rndColor == rndTwoColor)
        {
            rndTwoColor = Random.Range(0, colors.Length);
        }
        return rndTwoColor;

    }

    // Update is called once per frame
    void Update()
    {
        Color result = floorMaterial.color - twoColor;

        if (Mathf.Abs(result.r) + Mathf.Abs(result.g) + Mathf.Abs(result.b) < 0.2f)
        {
            twoColor = colors[rndColorFunc()];
        }
        floorMaterial.color = Color.Lerp(floorMaterial.color, twoColor, 0.003f);
        
    }
}

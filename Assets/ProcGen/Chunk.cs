using System.Collections;
using System.Collections.Generic;
using System;
using UnityEditor;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    public int size = 256;
    public NoiseMap noiseMap;
    public Gradient gradient;

    public Renderer rend;

    [Header("Screen Shot")]
    public string screenShotName = "ScreenShot";

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    public void GenerateMap()
    {
        rend.sharedMaterial.mainTexture = GenerateTexture();
    }

    public void savePNG() {
        Texture2D texture = GenerateTexture();
        byte[] _bytes = texture.EncodeToPNG();
        string date = DateTime.Now.ToString().Replace('/', '_').Replace(':', '_').Trim();
        string path = Application.dataPath + "/Record/ScreenShots/" + screenShotName + date + ".png";
        System.IO.File.WriteAllBytes(path, _bytes);
        Debug.Log(_bytes.Length/1024  + "Kb was saved as: " + path);
    }

    Texture2D GenerateTexture()
    {
        Texture2D texture = new Texture2D(size, size);

        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                float sample = noiseMap.Noise(x, y, size);
                Color color = gradient.Evaluate(sample);
                //Color color = new Color(sample, sample, sample);
                texture.SetPixel(x, y, color);
            }
        }

        texture.Apply();
        return texture;
    }
}
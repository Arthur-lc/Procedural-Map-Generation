using System.Collections;
using System.Collections.Generic;
using System;
using UnityEditor;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    public int resolution = 256;
    public bool autoGenerate = true;
    public NoiseMap noiseMap;
    public Gradient gradient;
    public float seaLevel;
    public Vector2 offset;


    public Renderer rend;

    [Header("Screen Shot")]
    public string screenShotName = "ScreenShot";

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material = new Material(rend.material);
    }

    public void RenderMap()
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

    private void Update() {
        if (autoGenerate) {
            offset.x = this.transform.position.x / this.transform.localScale.x * resolution;
            offset.y = this.transform.position.y / this.transform.localScale.y * resolution;
            RenderMap();
        }
    }

    Texture2D GenerateTexture()
    {
        Texture2D texture = new Texture2D(resolution, resolution);
        texture.filterMode = FilterMode.Point;

        for (int i = 0; i < resolution; i++)
        {
            for (int j = 0; j < resolution; j++)
            {
                float x = offset.x + (float)i / resolution;
                float y = offset.x + (float)j / resolution;
                float sample = noiseMap.Noise(x, y);
                Color color = gradient.Evaluate(sample);
                //Color color = new Color(sample, sample, sample);
                texture.SetPixel(i, j, color);
            }
        }

        texture.Apply();
        return texture;
    }
}
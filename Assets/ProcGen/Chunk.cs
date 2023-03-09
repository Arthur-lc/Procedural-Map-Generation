using System.Collections;
using System.Collections.Generic;
using System;
using UnityEditor;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    public int size = 256;
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
            offset.x = this.transform.position.x / this.transform.localScale.x * size;
            offset.y = this.transform.position.y / this.transform.localScale.y * size;
            RenderMap();
        }
    }

    Texture2D GenerateTexture()
    {
        Texture2D texture = new Texture2D(size, size);
        texture.filterMode = FilterMode.Point;

        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                float sample = noiseMap.Noise(offset.x + x, offset.y + y);
                Color color = gradient.Evaluate(sample);
                //Color color = new Color(sample, sample, sample);
                texture.SetPixel(x, y, color);
            }
        }

        texture.Apply();
        return texture;
    }
}
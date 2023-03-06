using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NoiseMap
{
    public float scale = 1.0F;
    public int octaves = 1;
    public float persistence;
    public float lacunarity;

    public float Noise(int x, int y, int size) {
        float sample = 0;

        float amplitude = 1;
        float frequency = 1;
        float noiseHeight = 0;

        for (int i = 0; i < octaves; i++) {
            float xCoord = (float)x / scale;
            float yCoord = (float)y / scale;

            sample = Mathf.PerlinNoise(xCoord, yCoord);
            noiseHeight += sample * amplitude;

            amplitude *= persistence;
            frequency *= lacunarity;
        }

        return sample;
    }
}

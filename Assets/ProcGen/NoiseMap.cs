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

    public float Noise(float x, float y) {
        if (scale == 0) {
            scale = 0.0001f;
        }

        float sample = 0;

        float amplitude = 1;
        float frequency = 1;
        float noiseHeight = 0;

        for (int i = 0; i < octaves; i++) {
            float yCoord = scale * frequency * (float)y;
            float xCoord = scale * frequency * (float)x;

            sample = Mathf.PerlinNoise(xCoord, yCoord) * 2 - 1;
            noiseHeight += sample * amplitude;

            amplitude /= persistence;
            frequency *= lacunarity;
        }

        return noiseHeight / 2 + 0.5f;
    }
}

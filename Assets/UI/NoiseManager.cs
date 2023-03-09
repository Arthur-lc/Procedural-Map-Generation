using UnityEngine;
using UnityEngine.UI;

public class NoiseManager : MonoBehaviour {
    public Chunk chunk;
    [SerializeField] public Slider seaLevelSlider;
    public Slider scaleSlider;
    public Slider resolutionSlider;
    public Slider octavesSlider;
    public Slider persistenceSlider;
    public Slider lacunaritySlider;
    private NoiseMap noiseMap;

    private void Start() {
        noiseMap = chunk.noiseMap;

        scaleSlider.value = noiseMap.scale;
        resolutionSlider.value = chunk.size;
        octavesSlider.value = noiseMap.octaves;
        persistenceSlider.value = noiseMap.persistence;
        lacunaritySlider.value = noiseMap.lacunarity;
    }

    public void setSeaLevel() {

    }

    public void setScale() {
        noiseMap.scale = scaleSlider.value;
        chunk.RenderMap();
    }

    public void serResolution() {
        chunk.size = (int)resolutionSlider.value;
        chunk.RenderMap();
    }

    public void setOctaves() {
        noiseMap.octaves = (int)octavesSlider.value;
        chunk.RenderMap();
    }

    public void setPersistence() {
        noiseMap.persistence = persistenceSlider.value;
        chunk.RenderMap();
    }

    public void setLacunarity() {
        noiseMap.lacunarity = lacunaritySlider.value;
        chunk.RenderMap();
    }


}
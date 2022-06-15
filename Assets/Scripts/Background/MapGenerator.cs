using UnityEngine;
using System.Collections;

public class MapGenerator : MonoBehaviour
{

    public FilterMode filterMode = FilterMode.Point;
    public int width;
    public int height;

    public float noiseScale;

    public int seed;
    public bool randomSeed;
    public bool snapRegions;
    public TerrainType[] regions;

    private float[,] noiseMap;
    private Color[] colourMap;



    public void Start()
    {
        CreateSprite();
    }

    public void CreateSprite()
    {
        if (randomSeed)
        {
            seed = Random.Range(0, 1000);
        }
        GenerateMap();
        DrawText();
    }
    public void GenerateMap()
    {
        noiseMap = Noise.GenerateNoiseMap(width, height, seed, noiseScale, 1, 0.5f, 0.5f, Vector2.zero);

        colourMap = new Color[width * height];
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                float currentHeight = noiseMap[x, y];
                int firstRegion = -1;
                int secondRegion = -1;
                for (int i = 0; i < regions.Length; i++)
                {
                    if (snapRegions)
                    {
                        if (currentHeight <= regions[i].height)
                        {
                            colourMap[y * width + x] = regions[i].colour;
                            break;
                        }
                    }
                    else
                    {
                        if (currentHeight >= regions[i].height)
                        {
                            firstRegion = i;
                        }
                        if (currentHeight <= regions[i].height)
                        {
                            secondRegion = i;
                        }
                        if (firstRegion != -1 && secondRegion != -1)
                        {
                            Color color = Color.Lerp(regions[firstRegion].colour, regions[secondRegion].colour, currentHeight);
                            colourMap[y * width + x] = color;
                            break;
                        }

                    }
                }

            }

        }
    }

    public void DrawText()
    {
        Texture2D texture = TextureGenerator.TextureFromColourMap(colourMap, width, height, filterMode);
        this.GetComponent<SpriteRenderer>().sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f), 10f);
    }

    // uncomment this to create a map on every value changed in the inspector

    void OnValidate()
    {
        CreateSprite();
    }


}

[System.Serializable]
public struct TerrainType
{
    public string name;
    public float height;
    public Color colour;
}
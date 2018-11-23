using UnityEngine;

/// <summary>
/// Generates the level with random level parts
/// </summary>
public class LevelGeneration : MonoBehaviour
{
    [Tooltip("The width of one level part")]
    public float TileSize = 2f;

    private float startZ = -4;  //have four parts before the player initial position


    //TODO: In dieser Methode soll ein zufälliges Level aus allen möglichen LevelParts erstellt werden
    //      Dabei soll der erste Chunk bei startZ starten und eine Breite von 'TileSize' bsitzen
    //      Die LevelParts befinden sich im Ordner 'Prefabs'
    public void GenerateLevel(int numberOfChunks = 50)
    {
    }
}

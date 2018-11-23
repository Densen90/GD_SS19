using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// GameManager who handles the point system
/// Setup as first Script to call in Execution Order
/// </summary>
public class GameManager : MonoBehaviour
{
    //TODO: folgende Funktionalitäten können im GameManager implementiert werden
    //      1. GameManager ruft das externe Script LevelGeneration auf, um am Anfang das Level zu erstellen
    //      2. Implementierung als Singleton, um überall darauf zugreifen zu können
    //      3. Punkte speichern, in der UI ausgeben und Funktionalität, die Punkte zu erhöhen
    private void Awake()
    {
    }
}

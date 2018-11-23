using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// The players movement with collision handling
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    public float JumpDistance = 2f;
    public float lerpTime = 1f;
    public Animator animator;

    private Vector3 endPos = Vector3.zero;
    private bool moveInProgress = false;
    private float delta = 0f;

    private void Awake()
    {
        endPos = this.transform.position;
    }

    //Hier läuft die Hauptschleife ab, in der der Spieler bewegt wird und Abfragen gemacht werden
    //TODO: Die Spielfigur bewegt sich automatisch nach einem gültigen input. Es soll keine Bewegung möglich sein, während sich die Spielfigur noch bewegt. Nachdem die Bewegung abgeschlossen ist, soll dies wieder möglich sein.
    private void Update()
    {
        Vector2 dir = Vector2.zero;

        if (CheckForKeyboardInput(out dir)) Move(dir);

        if (!moveInProgress) return;

        delta += Time.deltaTime;

        this.transform.position = Vector3.Lerp(this.transform.position, endPos, delta / lerpTime);
    }

    //TODO: Hier sollen alle Pfeiltasten (oder wasd) abgefragt werden
    //      Der Rückgabeparameter soll sagen, ob eine taste gedrückt wurde, der out-Parameter soll angeben, welche Richtungstaste gedrückt wurde
    private bool CheckForKeyboardInput(out Vector2 direction)
    {
        direction = Vector2.zero;

        return direction != Vector2.zero;
    }

    //TODO: Hier soll die EndPosition der Spielfigur bestimmt werden, wenn die Spielfigur bewegt wird; folgende Funktionen können implementiert werden
    //      1. Setze eine EndPosition, abhängig von der Vairable 'JumpDistance'
    //      2. Rotiere die Spielfigur in die Richtung, in die sie sich bewegt
    //      3. Setze keine neue Endposition, wenn die Figur sich gerade bewegt
    //      4. Spiel die Animation für einen Sprung ab
    //      5. Bewege die Spielfigur nicht, wenn sich ein hindernis im Weg befindet (siehe 'ObstacleInWay')
    public void Move(Vector2 dir)
    {
    }

    //TODO: Prüfe ob sich in der Bewegungsrichtung des Spielers ein Hindernis befindet
    //      Dabei soll ein Raycast prüfen, ob ein objekt näher ist als die Figur springen kann, und true zurückgeben, wenn das der Fall ist
    private bool ObstacleInWay(Vector2 dir)
    {
        return false;
    }

    //TODO: Prüfe ab, ob die Spielfigur in einen bestimten Trigger springt
    //      1. Sollte der Trigger den Tag 'Death' besitzen, soll das Level neu geladen werden
    //      2. Sollte der Trigger den Tag 'Points' besitzen, soll der Spieler einen Punkt dazu bekommen
    //      3. Der Spieler soll je neu betretenen Chunk einen punkt bekommen, betritt er einen Chunk ein zweites Mal, soll er keine neuen Punkte bekommen
    private void OnTriggerEnter(Collider other)
    {
    }
}

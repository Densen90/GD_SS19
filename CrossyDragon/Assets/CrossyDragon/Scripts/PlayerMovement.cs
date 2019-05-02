using UnityEngine;

/// <summary>
/// The players movement with collision handling
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    public float JumpDistance = 2f;
    public float lerpTime = 1f;
    public Animator animator;

    private Vector3 endPos = Vector3.zero, startPos = Vector3.zero;
    private bool moveInProgress = false;
    private float delta = 0f;

    private void Awake()
    {
        endPos = this.transform.position;
        startPos = this.transform.position;
    }

    //Hier läuft die Hauptschleife ab, in der der Spieler bewegt wird und Abfragen gemacht werden
    //TODO: Die Spielfigur bewegt sich automatisch nach einem gültigen input. Es soll keine Bewegung möglich sein, während sich die Spielfigur noch bewegt. Nachdem die Bewegung abgeschlossen ist, soll dies wieder möglich sein.
    private void Update()
    {
        Vector3 dir = Vector3.zero;

        if (CheckForKeyboardInput(out dir)) Move(dir);

        if (!moveInProgress) return;

        delta += Time.deltaTime;

        this.transform.position = Vector3.Lerp(startPos, endPos, delta / lerpTime);

        //stop when move time is over
        if(delta >= lerpTime)
        {
            delta = 0f;
            this.transform.position = endPos;
            startPos = endPos;
            moveInProgress = false;
        }
    }

    //Hier werden alle Pfeiltasten (oder wasd) abgefragt
    //      Der Rückgabeparameter soll sagen, ob eine taste gedrückt wurde, der out-Parameter soll angeben, welche Richtungstaste gedrückt wurde
    private bool CheckForKeyboardInput(out Vector3 direction)
    {
        direction = Vector3.zero;

        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) direction = new Vector3(0, 0, 1);
        else if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) direction = new Vector3(-1, 0, 0);
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) direction = new Vector3(0, 0, -1);
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) direction = new Vector3(1, 0, 0);      

        return direction != Vector3.zero;
    }

    //TODO: Hier soll die EndPosition der Spielfigur bestimmt werden, wenn die Spielfigur bewegt wird; folgende Funktionen können implementiert werden
    //      1. Setze eine EndPosition, abhängig von der Vairable 'JumpDistance'
    //      2. Rotiere die Spielfigur in die Richtung, in die sie sich bewegt
    //      3. Setze keine neue Endposition, wenn die Figur sich gerade bewegt
    //      4. Spiel die Animation für einen Sprung ab
    //      5. Bewege die Spielfigur nicht, wenn sich ein hindernis im Weg befindet (siehe 'ObstacleInWay')
    public void Move(Vector3 dir)
    {
        if (moveInProgress || ObstacleInWay(dir)) return;


        endPos = this.transform.position + (dir * JumpDistance);    //set end position depending on input

        float rot = 0f;
        if (dir.x == 1) rot = 90f;
        else if (dir.x == -1) rot = 270f;
        else if (dir.z == -1) rot = 180f;
        this.transform.rotation = Quaternion.Euler(0f, rot, 0f); //rotate in move direction

        moveInProgress = true;
    }

    //TODO: Prüfe ob sich in der Bewegungsrichtung des Spielers ein Hindernis befindet
    //      Dabei soll ein Raycast prüfen, ob ein objekt näher ist als die Figur springen kann, und true zurückgeben, wenn das der Fall ist
    private bool ObstacleInWay(Vector3 dir)
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

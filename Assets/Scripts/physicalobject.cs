using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class physicalobject : MonoBehaviour
{
    Rigidbody2D myrigidbody;
    FSM<int> machine;
    Cubestate _state1;
    Cubestatetwo _state2;
    [Range(0f, 3f)]
    public float magnitude;
    // Start is called before the first frame update
    void Start()
    {
        myrigidbody = this.GetComponent<Rigidbody2D>();
        machine = new FSM<int>();
        _state1 = new Cubestate(machine, this.gameObject);
        _state2 = new Cubestatetwo(machine, this.gameObject);
        machine.AddState(_state1);
        machine.AddState(_state2);
        machine.Initialize(0);
        machine.SwitchState(_state1.GetType());
    }

    // Update is called once per frame
    void Update()
    {
        machine.Update();
        //if a finger touches me i i fly away in the direction of touch
        //if a player tabs near me i move away from the finger
    }

    public void ApplyForce(Vector3 direction)
    {
      //  direction = myrigidbody.transform.position - direction;
        myrigidbody.AddForceAtPosition(direction.normalized, transform.position);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Vector2 direction = col.GetContact(0).point - (Vector2)transform.position;
        direction.Normalize();
        // Apply force based on the collision direction
        if(myrigidbody)
        {
            myrigidbody.AddForce(-direction * magnitude, ForceMode2D.Impulse);
        }
    }

    private void OnBecameInvisible()
    {
        machine.SwitchState(_state2.GetType());
    }

    private void OnBecameVisible()
    {
        Debug.Log("enter field");
    }
}
public class Cubestate : State<int>
{
    GameObject obj;
    public FSM<int> owner;
    public Cubestate(FSM<int> _owner, GameObject _obj)
    {
        obj = _obj;
        owner = _owner;
    }
    public override void OnEnter()
    {
       // Debug.Log("start");
    }
    public override void OnUpdate()
    {
        
        //Debug.Log("update");
    }
    public override void OnExit()
    {
       
    }
}

public class Cubestatetwo : State<int>
{
    public FSM<int> owner;
    GameObject obj;
    Color mycolor;
    public Cubestatetwo(FSM<int> _owner,GameObject _obj)
    {
        owner = _owner;
        obj = _obj;
        mycolor = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));

    }
    public override void OnEnter()
    {
        Debug.Log("respawn");
        obj.transform.position = new Vector3 (Random.Range(0,3), Random.Range(0, 3), Random.Range(0, 3));
        obj.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        obj.GetComponent<SpriteRenderer>().color = mycolor;
     //   Debug.Log("set new color to "+ mycolor.ToString() +" and reset velocity");
    }
    public override void OnUpdate()
    {
        Debug.Log("check condition");
    }
    public override void OnExit()
    {
        Debug.Log("condition met");
        
    }

}

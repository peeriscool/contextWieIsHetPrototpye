using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class OneScriptGame : MonoBehaviour
{
    public GameObject Player;
    keybinding Mybinding;
    PlayField field;
    public Texture2D FloorTex;
    public ParticleSystem cursorParticles; // Reference to the particle system for the cursor
    int v = 0;
    // Start is called before the first frame update
    void Start()
    {
        Mybinding = new keybinding();
        field = new PlayField(10, FloorTex); //makes a 9x9 grid
    }

    // Update is called once per frame
    void Update()
    {
        Mybinding.ControUpdate(Player.transform);
        particleUPdate();
       if(Input.GetKeyDown(KeyCode.E))
        {
            PlayerInvestigatetile();
        }
    }

    private void particleUPdate()
    {
        //  Vector3 mousePosition = Input.mousePosition;
        //  mousePosition.z = -Camera.main.transform.position.z;
        cursorParticles.transform.position = Player.transform.position;//Camera.main.ScreenToWorldPoint(mousePosition);
    }

    public void PlayerInvestigatetile()
    {
        //get grid
        //get player
       Debug.Log(field.Objgrid.Length);
       Debug.Log(field.Objgrid[v]);
       v++;

        //    for (int y = 0; y < field.Objgrid.Length; y++)
        //    {
        //    if(field.Objgrid[y] != null)
        //    {
        //        if (Player.transform.position == field.Objgrid[y].transform.position)
        //        {
        //            field.Objgrid[y].GetComponent<SpriteRenderer>().color = Color.green;

        //            Debug.Log("player on tile" + field.Objgrid[y].name);
        //        }
        //        if (Player.transform.position == field.Objgrid[y].transform.position)
        //        {
        //            field.Objgrid[y].GetComponent<SpriteRenderer>().color = Color.red;
        //            Debug.Log("player on tile" + field.Objgrid[y].name);
        //        }
        //    }
        //}
    }
}
public class keybinding
{
    public void ControUpdate(Transform _transform)
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
          _transform.position += new Vector3(0, 1, 0);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            _transform.position += new Vector3(-1, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            _transform.position += new Vector3(0, -1, 0);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
          _transform.position += new Vector3(1, 0, 0);
        }
    }
}
public class PlayField
{
    public int[] grid;
    public GameObject[] Objgrid;
    public Texture2D tex;
    private Sprite mySprite;
    private SpriteRenderer sr;
    public int[] objectives;

    public PlayField(int size, Texture2D _tex)
    {
        tex = _tex;
        grid = new int[size];
        Objgrid = new GameObject[(grid.Length-1) * (grid.Length-1)];
        GenerateField();
        generateObjectives(5);
    }
    void GenerateField()
    {
       

        for (int i = 0; i < grid.Length; i++)
        {

            for (int y = 0; y < grid.Length; y++)
            {
               GameObject tile = new GameObject();
               //sprite
               sr = tile.AddComponent<SpriteRenderer>() as SpriteRenderer;
               mySprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
               sr.sprite = mySprite;
               //location
               tile.transform.position = new Vector3(i , y , 0);
               tile.name = "Tile " +"X "+ i.ToString() + "Y " + y.ToString();
               //add to list
               Objgrid[i] = tile;
               //  Objgrid[y] = GameObject.Instantiate(tile);
               Debug.Log(Objgrid[i].name);
            }
        }
        Debug.Log("there are:  "+ Objgrid.Length + "Items in grid");
       
    }
    void generateObjectives(int amount)
    {
        objectives = new int[amount];
        for (int i = 0; i < amount; i++) 
        {
            int o = Random.Range(0, Objgrid.Length);
            objectives[i]=o;
        }
    }
}
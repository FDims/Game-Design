using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorScript : MonoBehaviour
{
    private Vector2 x_range;
    private Vector2 y_range;
    [SerializeField] private float RoomNumber;
    [SerializeField] public GameObject shadow;
    GameObject Player;
    bool visited = false;
    void Start()
    {
        var renderer = GetComponent<SpriteRenderer>();
        var drawsize = renderer.drawMode;
        if (renderer.drawMode == SpriteDrawMode.Tiled)
        {
            x_range = new Vector2(transform.position.x - (0.5f * transform.localScale.x* renderer.size.x), transform.position.x + (0.5f * transform.localScale.x*renderer.size.x));
            y_range = new Vector2(transform.position.y - (0.5f * transform.localScale.y* renderer.size.y), transform.position.y + (0.5f * transform.localScale.y * renderer.size.y));
        }
        else
        {
            x_range = new Vector2(transform.position.x - (0.5f * transform.localScale.x), transform.position.x + (0.5f * transform.localScale.x));
            y_range = new Vector2(transform.position.y - (0.5f * transform.localScale.y), transform.position.y + (0.5f * transform.localScale.y));
        }
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.transform.position.x >= x_range[0] && Player.transform.position.x <= x_range[1] && !visited)
        {
            if (Player.transform.position.y >= y_range[0] && Player.transform.position.y <= y_range[1])
            {
                if(shadow)
                {
                    shadow.GetComponent<Animator>().SetTrigger("Visited");
                    visited = true;
                }
                
            }
        }
        detectEnemies();
        
    }

    public void detectEnemies()
    {
        var Characters = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var enemy in Characters)
        {
            if (enemy.transform.position.x >= x_range[0] && enemy.transform.position.x <= x_range[1])
            {
                if (enemy.transform.position.y >= y_range[0] && enemy.transform.position.y <= y_range[1])
                {
                    enemy.GetComponent<EnemyAI>().location = RoomNumber;
                }
            }
        }
        if (Player.transform.position.x >= x_range[0] && Player.transform.position.x <= x_range[1])
        {
            if (Player.transform.position.y >= y_range[0] && Player.transform.position.y <= y_range[1])
            {
                Player.GetComponent<Player>().location = RoomNumber;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Snake : MonoBehaviour
{
    private enum BodyDirection { 
        up = 0,
        down = 1
    }

    private enum HeadDirection
    {
        up,
        down,
        left,
        right
    }

    private enum TailDirection
    {
        up = 0,
        down = 1,
        left = 2,
        right = 3
    }

    private enum TurnDirection
    {
        upLeft = 0,
        upRight = 1,
        downLeft = 2,
        downright = 3
    }

    [SerializeField]
    private Sprite[] BodySprites = new Sprite[2];

    [SerializeField]
    private Sprite[] HeadSprites = new Sprite[4];

    [SerializeField]
    private Sprite[] TailSprites = new Sprite[4];

    [SerializeField]
    private Sprite[] TurnSprites = new Sprite[4];

    private List<GameObject> SnakeBodyParts = new List<GameObject>();

    private float MoveTimer;

    [SerializeField]
    private float MoveTimerMax;

    private void Awake()
    {
        GameObject SnakePartHead = new GameObject();
        SnakePartHead.AddComponent<SpriteRenderer>();
        SnakePartHead.GetComponent<SpriteRenderer>().sprite = HeadSprites[(int)HeadDirection.left];
        SnakePartHead.transform.position = Vector3.zero;

        SnakeBodyParts.Add(SnakePartHead);

        GameObject SnakePartTail = new GameObject();
        SnakePartTail.AddComponent<SpriteRenderer>();
        SnakePartTail.GetComponent<SpriteRenderer>().sprite = TailSprites[(int)TailDirection.left];
        SnakePartTail.transform.position = new Vector3(1, 0, 0);

        SnakeBodyParts.Add(SnakePartTail);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(MoveTimer >= MoveTimerMax)
        {
            for (int i = SnakeBodyParts.Count - 1; i >= 0; i--)
            {
                if(i == 0)
                {
                    SnakeBodyParts[i].transform.position = new Vector3(SnakeBodyParts[i].transform.position.x - 1, SnakeBodyParts[i].transform.position.y, 0);
                }
                else
                {
                    SnakeBodyParts[i].transform.position = SnakeBodyParts[i - 1].transform.position;
                }
            }

            MoveTimer = 0;
        }

        MoveTimer += Time.deltaTime;
    }
}

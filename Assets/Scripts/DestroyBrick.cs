using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBrick : MonoBehaviour
{
    public int numberOfHits = 0;
    public int maxHits;

    public SpriteRenderer brickSprite;
    public GameMaster gameMaster;

    public List<GameObject> bricks;

    private Vector3 telePos;

    // Start is called before the first frame update
    void Start()
    {
        brickSprite = GetComponent<SpriteRenderer>();
        gameMaster.GetComponent<GameMaster>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        float xPos = Random.Range(-16, 16);
        float yPos = Random.Range(1, 7);
        telePos = new Vector3(xPos, yPos, 0);

        numberOfHits++;
        if (this.gameObject.tag == "TeleBrick" && numberOfHits == 1)
        {
            brickSprite.color = Color.blue;
            this.gameObject.transform.position = telePos;
        }
        else if(this.gameObject.tag == "TeleBrick" && numberOfHits == 2)
        {
            brickSprite.color = Color.red;
            this.gameObject.transform.position = telePos;
        }
        else
        {
            brickSprite.color = Color.red;
        }

        if (numberOfHits >= maxHits)
        {
            if(this.gameObject.tag == "SplitBrick")
            {
                Instantiate(bricks[0], transform.position, bricks[0].transform.rotation);
            }
            gameMaster.playerPoints = gameMaster.playerPoints + 10;
            Destroy(this.gameObject);
        }
    }

}

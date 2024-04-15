using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScrollingScript : MonoBehaviour
{
    // Start is called before the first frame update

    public Vector2 speed = new Vector2(10, 10);
    public Vector2 direction = new Vector2(-1, 0);
    public bool isLinkedToCamera = false;
    public bool isLooping = false;

    private List<SpriteRenderer> backgroundPart;





    void Start()
    {
        if (isLooping)
        {
            // Get all the children of the layer with a renderer
            backgroundPart = new List<SpriteRenderer>();

            for (int i = 0; i < transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);
                SpriteRenderer r = child.GetComponent<SpriteRenderer>();

                // Add only the visible children
                if (r != null)
                {
                    backgroundPart.Add(r);
                }
            }

            // Note: Get the children from left to right.
            // We would need to add a few conditions to handle all the possible scrolling directions.
            backgroundPart = backgroundPart.OrderBy( t => t.transform.position.x).ToList();
        }

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(speed.x * direction.x, speed.y * direction.y, 0);

        movement *= Time.deltaTime;
        transform.Translate(movement);

        // Move the camera
        if (isLinkedToCamera)
        {
            Camera.main.transform.Translate(movement);
        }
        if (isLooping)
        {
            SpriteRenderer firstChild = backgroundPart.FirstOrDefault();
            if (firstChild.transform.position.x < Camera.main.transform.position.x)
            {
                
                SpriteRenderer lastChild = backgroundPart.LastOrDefault();

                Vector3 lastPosition = lastChild.transform.position;
                Vector3 lastSize = (lastChild.bounds.max - lastChild.bounds.min);

                    // Set the position of the recyled one to be  the last child.
                    // Note: Only work for horizontal scrolling currently.
                firstChild.transform.position = new Vector3(lastPosition.x + lastSize.x, firstChild.transform.position.y, firstChild.transform.position.z);

                    // Set the recycled child to the last position
                    // of the backgroundPart list.
                backgroundPart.Remove(firstChild);
                backgroundPart.Add(firstChild);
            }
        }

    }
}

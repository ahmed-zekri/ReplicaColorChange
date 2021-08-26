using UnityEngine;

public class FollowObject : MonoBehaviour
{

    public Transform player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
            if (player.position.y > transform.position.y)
            {
                transform.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);

            }
    }
}

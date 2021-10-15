using UnityEngine;

public class ChangeLayer : MonoBehaviour
{
    public Transform player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        GetComponent<SpriteRenderer>().sortingOrder = transform.position.z < player.position.z ? 4445 : 4443;
    }
}

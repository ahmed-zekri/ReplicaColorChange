using System.Collections;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField]
    private float speed;
    public string currentColor;


    public SpriteRenderer sr;


    public Color colorCyan;
    public Color colorYellow;
    public Color colorMagenta;
    public Color colorPink;
    private Renderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SetRandomColor();
        renderer = GetComponent<Renderer>();
        StartCoroutine(checkVisibility());
    }

    private IEnumerator checkVisibility()
    {
        yield return new WaitForSeconds(1);
        while (true)
        {
            if (!renderer.isVisible)

                GameManager.gameOverFunction?.Invoke();

            yield return null;

        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
            rb.velocity = Vector2.up * speed;



    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ColorChanger")
        {
            SetRandomColor();
            Destroy(collision.gameObject);
            return;
        }
        if (currentColor != collision.tag)


            GameManager.gameOverFunction?.Invoke();



    }
    void SetRandomColor()
    {
        int index = Random.Range(0, 4);

        switch (index)
        {
            case 0:
                currentColor = "Cyan";
                sr.color = colorCyan;
                break;
            case 1:
                currentColor = "Yellow";
                sr.color = colorYellow;
                break;
            case 2:
                currentColor = "Magenta";
                sr.color = colorMagenta;
                break;
            case 3:
                currentColor = "Pink";
                sr.color = colorPink;
                break;
        }
    }
}

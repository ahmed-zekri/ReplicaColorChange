using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject circlePrefab;
    [SerializeField]
    GameObject colorChangerPrefab;

    int counter;
    Vector3 lastPos;
    public delegate void GameOverDelegate(); // declare a delegate
    // Start is called before the first frame update
    public static GameOverDelegate gameOverFunction = GameOver;

    private static void GameOver()
    {
        Scene scene = SceneManager.GetActiveScene();

        SceneManager.LoadScene(scene.name);
    }

    void Start()
    {
        player = Instantiate(player);
        StartCoroutine(RespawnCircles());
        FindObjectOfType<FollowObject>().player = player.transform;
    }

    private IEnumerator RespawnCircles()
    {
        GameObject circle = Instantiate(circlePrefab, Camera.main.transform.position + Vector3.up * 3 + Vector3.forward * 10, Quaternion.identity);
        GameObject colorChanger = Instantiate(colorChangerPrefab, circle.transform.position + Vector3.up * 3, Quaternion.identity);
        lastPos = colorChanger.transform.position;
        while (true)
        {

            yield return new WaitUntil(() => player.transform.position.y > 4 * counter);
            counter++;
            int randomNumber = Random.Range(2, 6);
            circle = Instantiate(circlePrefab, lastPos + (Vector3.up * randomNumber), Quaternion.identity);
            colorChanger = Instantiate(colorChangerPrefab, circle.transform.position + Vector3.up * 3, Quaternion.identity);
            lastPos = colorChanger.transform.position;

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

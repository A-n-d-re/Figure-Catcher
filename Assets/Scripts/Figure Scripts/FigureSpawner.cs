using UnityEngine;

public class FigureSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] figures;

    [SerializeField] private float spawnHeight;

    [SerializeField] private float spawnInterval = 0.5f;

    [SerializeField] private float fallingSpeed;

    [SerializeField] private int timeToDestroyFigure = 10;

    private Camera mainCamera;

    private void Start()
    {
        fallingSpeed = PlayerPrefs.GetInt("FigureFallingSpeed");

        mainCamera = Camera.main;

        spawnHeight = mainCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y + 1f;

        InvokeRepeating("SpawnFigure", 0f, spawnInterval);
    }

    private void SpawnFigure()
    {
        float spawnRangeX = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
        int figureIndex = Random.Range(0, figures.Length);

        GameObject selectedFigure = figures[figureIndex];

        float spawnPosX = Random.Range(-spawnRangeX, spawnRangeX);
        Vector3 spawnPosition = new Vector3(spawnPosX, spawnHeight, 0f);

        GameObject figure = Instantiate(selectedFigure, spawnPosition, Quaternion.identity);
        figure.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -fallingSpeed);

        Destroy(figure, timeToDestroyFigure);
    }
}

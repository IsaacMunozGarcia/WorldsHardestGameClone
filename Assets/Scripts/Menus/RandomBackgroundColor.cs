using UnityEngine;

public class RandomBackgroundColor : MonoBehaviour
{
    private Camera cam;
    public float interval = 0.5f; // Time between color changes (in seconds)
    private float timer = 0f;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= interval)
        {
            timer = 0f;
            cam.backgroundColor = GetRandomColor();
        }
    }

    Color GetRandomColor()
    {
        return new Color(Random.value, Random.value, Random.value);
    }
}


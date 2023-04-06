using UnityEngine;

public class GridDrawer : MonoBehaviour
{
    public int width = 10;
    public int height = 10;
    public float cellSize = 1f;
    public Color gridColor = Color.white;

    private const float LineWidth = 0.15f;
    private LineRenderer _lineRenderer;

    private void Start()
    {
        DrawGrid();
    }

    private LineRenderer InitializeLineRenderer(GameObject container)
    {
        _lineRenderer = container.AddComponent<LineRenderer>();
        _lineRenderer.useWorldSpace = true;
        _lineRenderer.startWidth = LineWidth;
        _lineRenderer.endWidth = LineWidth;
        _lineRenderer.material = new Material(Shader.Find("Unlit/Color"));
        _lineRenderer.material.color = gridColor;

        return _lineRenderer;
    }

    private void DrawLine(Vector2 start, Vector2 end)
    {
        GameObject container = new GameObject();
        container.transform.parent = transform;

        var lineRenderer = InitializeLineRenderer(container);
        lineRenderer.name = start + " _ " + end;
        lineRenderer.SetPosition(0, start);
        lineRenderer.SetPosition(1, end);
    }

    private void DrawGrid()
    {
        float offsetX = (width * cellSize) / 2;
        float offsetY = (height * cellSize) / 2;

        for (int i = 0; i <= width; i++)
        {
            Vector3 startPos = new Vector3(i * cellSize - offsetX, -offsetY, 0);
            Vector3 endPos = new Vector3(i * cellSize - offsetX, height * cellSize - offsetY, 0);
            DrawLine(startPos, endPos);
        }

        for (int j = 0; j <= height; j++)
        {
            Vector3 startPos = new Vector3(0 - offsetX, j * cellSize - offsetY, 0);
            Vector3 endPos = new Vector3(width * cellSize - offsetX, j * cellSize - offsetY, 0);
            DrawLine(startPos, endPos);
        }
    }
}
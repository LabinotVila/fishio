using UnityEngine;
using UnityEngine.Serialization;

public class GridDrawer2D : MonoBehaviour
{
    public int horizontalCells = 10;
    public int verticalCells = 10;
    public float cellSize = 1f;
    [Range(0.15f, 0.4f)] public float lineWidth = 0.15f;
    public Color gridColor = Color.white;

    private LineRenderer _lineRenderer;

    private void Start()
    {
        DrawGrid();
    }

    private LineRenderer InitializeLineRenderer(GameObject container)
    {
        _lineRenderer = container.AddComponent<LineRenderer>();
        _lineRenderer.useWorldSpace = true;
        _lineRenderer.startWidth = lineWidth;
        _lineRenderer.endWidth = lineWidth;
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
        float offsetX = (horizontalCells * cellSize) / 2;
        float offsetY = (verticalCells * cellSize) / 2;

        for (int i = 0; i <= horizontalCells; i++)
        {
            Vector3 startPos = new Vector3(i * cellSize - offsetX, -offsetY, 0);
            Vector3 endPos = new Vector3(i * cellSize - offsetX, verticalCells * cellSize - offsetY, 0);
            DrawLine(startPos, endPos);
        }

        for (int j = 0; j <= verticalCells; j++)
        {
            Vector3 startPos = new Vector3(0 - offsetX, j * cellSize - offsetY, 0);
            Vector3 endPos = new Vector3(horizontalCells * cellSize - offsetX, j * cellSize - offsetY, 0);
            DrawLine(startPos, endPos);
        }
    }
}
using UnityEngine;
using UnityEngine.UI;

public class GenerateCrops : MonoBehaviour
{
    // Hardcodeado, este el tamaño ideal en 4x4 y se tiene que escalar para los diferentes tamaños
    private const int CELL_SPACING = 16;
    private const int CELL_IDEL_SIZE = (200 * 4);
    private const int CELL_IDEL_SPACING = (CELL_SPACING * 4);

    [SerializeField] private GameObject cropPrefab;

    private int cropsRows;
    private int cropsCellSize;
    private int cropsSpacing;
    private int cropsMaxSize;

    private GridLayoutGroup cropsLayoutGroup;

    private void Awake()
    {
        // Pedir cropsRow a la base de datos, de momento incializamos en 5
        cropsRows = 5;

        // Indicamos el mayor tamaño que va a tener el parterre
        cropsMaxSize = CELL_IDEL_SIZE + CELL_IDEL_SPACING;
        cropsSpacing = CELL_SPACING;
        
        cropsLayoutGroup = GetComponent<GridLayoutGroup>();
        cropsLayoutGroup.constraintCount = cropsRows;
    }

    private void Start()
    {
        GenerateCropsLands();
    }

    public int GetCropsRows() => cropsRows;

    public void SetCropsRows(int number)
    {
        cropsRows = number;
        cropsLayoutGroup.constraintCount = cropsRows;

        GenerateCropsLands();
    }

    private void GenerateCropsLands()
    {
        // Configuramos el tamaño de cada celda
        CalculateCellSize();

        int cellsGenerated = 0;

        for (int i = 0; i < cropsRows; i++)
        {
            for (int j = 0; j < cropsRows; j++)
            {
                GameObject temp = Instantiate(cropPrefab, transform);
                temp.transform.SetParent(transform, false);
                temp.transform.name = "Crops_" + cellsGenerated.ToString("00000000");
                temp.name = "Crops_" + cellsGenerated.ToString("00000000");
                cellsGenerated++;
            }
        }
    }

    private void CalculateCellSize()
    {
        int cellSpace = cropsMaxSize - (cropsSpacing * cropsRows);
        cropsCellSize = cellSpace / cropsRows;

        cropsLayoutGroup.cellSize = new Vector2(cropsCellSize, cropsCellSize);
    }
}

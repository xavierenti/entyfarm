public class CellsSave
{
    private int x;
    private int y;
    private float time;
    private int id_plant;

    public CellsSave(int x, int y, float time, int id_plant)
    {
        this.x = x;
        this.y = y;
        this.time = time;
        this.id_plant = id_plant;
    }

    public int GetX() => this.x;
    public int GetY() => this.y;
    public float GetTime() => this.time;
    public int GetPlantID() => this.id_plant;
}

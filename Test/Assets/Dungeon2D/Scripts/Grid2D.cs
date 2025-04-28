public enum Tile { Empty, Floor, Wall }

/// <summary> Very light 2‑D tile map with indexer access. </summary>
public sealed class Grid2D
{
    public readonly int W, H;
    private readonly Tile[,] g;

    public Grid2D(int w, int h)
    {
        W = w; H = h; g = new Tile[w, h];
    }

    public Tile this[int x, int y]
    {
        get => g[x, y];
        set => g[x, y] = value;
    }

    public bool Inside(int x, int y) => (uint)x < W && (uint)y < H;
}
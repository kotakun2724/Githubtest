using UnityEngine;

/// <summary> Axis‑aligned rectangular room. Immutable value‑type. </summary>
public readonly struct Room
{
    public readonly int x, y, w, h;

    public int X2 => x + w;
    public int Y2 => y + h;
    public Vector2 Center => new Vector2(x + w * .5f, y + h * .5f);

    public Room(int x, int y, int w, int h)
    {
        this.x = x; this.y = y; this.w = w; this.h = h;
    }

    /// <summary> True if overlapped → pushes <paramref name="other"/> by 1 tile away. </summary>
    public bool Push(ref Room other)
    {
        if (X2 <= other.x || other.X2 <= x || Y2 <= other.y || other.Y2 <= y)
            return false;    // no overlap

        Vector2 dir = (Vector2)(other.Center - Center);
        if (dir == Vector2.zero) dir = Vector2.right;
        dir.Normalize();
        int dx = Mathf.RoundToInt(dir.x);
        int dy = Mathf.RoundToInt(dir.y);
        other = new Room(other.x + dx, other.y + dy, other.w, other.h);
        return true;
    }

    /// <summary> Random tile strictly inside the room (margin 1). </summary>
    public Vector2Int RandomPointInside()
    {
        return new Vector2Int(Random.Range(x + 1, X2 - 1), Random.Range(y + 1, Y2 - 1));
    }
}
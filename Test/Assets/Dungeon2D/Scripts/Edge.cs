using System;

/// <summary> Undirected weighted edge between two room indices. </summary>
public readonly struct Edge : IEquatable<Edge>, IComparable<Edge>
{
    public readonly int a, b;   // room indices
    public readonly float w;    // cost (Euclidean distance)

    public Edge(int a, int b, float w) { this.a = a; this.b = b; this.w = w; }

    public bool Equals(Edge other) => (a == other.a && b == other.b) || (a == other.b && b == other.a);
    public override bool Equals(object obj) => obj is Edge e && Equals(e);
    public override int GetHashCode() => a ^ (b << 16);
    public int CompareTo(Edge other) => w.CompareTo(other.w);

    public int Other(int idx) => idx == a ? b : a;
}
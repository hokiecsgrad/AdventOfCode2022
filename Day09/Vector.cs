using System;
using System.Collections.Generic;

namespace AdventOfCode.Day09;

public class Vector : IEquatable<Vector>
{
    public int X { get; set; } = 0;
    public int Y { get; set; } = 0;

    public Vector() {}

    public Vector(int x, int y)
    {
        X = x;
        Y = y;
    }

    public double Magnitude()
    {
        return Convert.ToInt32(Math.Sqrt(X * X + Y * Y));
    }

    public Vector ToUnit()
    {
        Vector unit;
        unit = new Vector(
                    (int)Math.Round((double)X / (double)Magnitude(), MidpointRounding.AwayFromZero), 
                    (int)Math.Round((double)Y / (double)Magnitude(), MidpointRounding.AwayFromZero)
                    );
        return unit;
    }

    public bool Equals(Vector other)
    {
        if(other == null) return false;

        if (X == other.X && Y == other.Y)
            return true;

        return false;
    }

	public override bool Equals(object obj)
    {
		if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
		return Equals(obj as Vector);
	}

    public int GetHashCode(Vector vec)
    {
        var hashCode = 13;
        hashCode = (hashCode * 397) ^ vec.X;
        hashCode = (hashCode * 397) ^ vec.Y;
        return hashCode;
    }
}
public class CycleMagic
{
    public static MagicType CurrentMagicType = MagicType.Yellow;
    
    public static void Cycle()
    {
        switch (CurrentMagicType)
        {
            case MagicType.Yellow:
                CurrentMagicType = MagicType.Red;
                break;
            case MagicType.Red:
                CurrentMagicType = MagicType.Blue;
                break;
            case MagicType.Blue:
                CurrentMagicType = MagicType.Green;
                break;
            case MagicType.Green:
                CurrentMagicType = MagicType.Yellow;
                break;
        }
    }
}

public enum MagicType
{
    Yellow,
    Red,
    Blue,
    Green
}
namespace CityManagementSystem.Utilities;

public static class IdGenerator
{
    private static int _id = 100;

    public static int Generate()
    {
        _id++;
        return _id;
    }
}

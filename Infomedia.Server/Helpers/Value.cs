namespace Infomedia.Server.Helpers;

public static class Value
{
    public static bool Check(string value)
    {
        return value != null && value != "null" && value != "undefined" && value != "";
    }
}

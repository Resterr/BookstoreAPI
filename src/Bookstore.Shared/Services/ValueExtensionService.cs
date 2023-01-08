namespace Bookstore.Shared.Services;
public static class ValueExtensionService
{
	public static string GetValueOrNull(this object obj)
	{
		return obj == null ? "null" : obj.ToString();

	}
	public static string GetNameOfObject(this object obj)
	{
		return obj.GetType().Name;
	}

}

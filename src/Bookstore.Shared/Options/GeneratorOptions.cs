namespace Bookstore.Shared.Options;
public sealed class GeneratorOptions
{
	public int Id { get; set; }
	public DateTime Epoch { get; set; }
	public byte TimestampBits { get; set; }
	public byte GeneratorIdBits { get; set; }
	public byte SequenceBits { get; set; }
}

using Bookstore.Shared.Abstractions.Services;
using Bookstore.Shared.Options;
using IdGen;
using Microsoft.Extensions.Options;

namespace Bookstore.Shared.Services;

internal sealed class IdGeneratorService : IIdGeneratorService
{
	private readonly IdGenerator _generator;

	public IdGeneratorService(IOptions<GeneratorOptions> options)
	{
		var generatorStructure = new IdStructure(options.Value.TimestampBits, options.Value.GeneratorIdBits, options.Value.SequenceBits);
		var generatorOptions = new IdGeneratorOptions(generatorStructure, new DefaultTimeSource(options.Value.Epoch));

		_generator = new IdGenerator(options.Value.Id, generatorOptions);
	}

	public long Generate()
	{
		var result = _generator.CreateId();

		return result;
	}
}

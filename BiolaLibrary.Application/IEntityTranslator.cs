using BiolaLibrary.Model;

namespace BiolaLibrary.Application
{
	public interface IEntityTranslator<M, D> where M:ModelBase
	{
		M CreateModel(D dto);
		M UpdateModel(M model, D dto);
		D CreateDto(M model);
		D UpdateDto(D dto, M model);
	}
}
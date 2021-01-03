
namespace RobotizeFacebook.Pages.LoggedIn
{
    public interface IPatioFurnitureFilterOptions :
        IFilterOptions,
        IPrice,
        IItemCondition<ItemCondition>,
        IDecorStyle<StyleDecorStyle>,
        IFinish<Finish>,
        IMaterial<Material>
    {
    }
}

using BuberBreakfast.Models;
using BuberBreakfast.ServiceErrors;
using ErrorOr;
namespace BuberBreakfast.Services.Breakfasts;

public class BreakfastService : IBreakfastService
{

    private readonly Dictionary<Guid, Breakfast> _breakfast = new();
    public void CreateBreakfast(Breakfast breakfast)
    {
        _breakfast.Add(breakfast.Id, breakfast);
    }

    public void Delete(Guid id)
    {
        _breakfast.Remove(id);
    }

    public ErrorOr<Breakfast> GetBreakfast(Guid id)
    {
        if (_breakfast.TryGetValue(id, out var breakfast))
        {
            return _breakfast[id];
        }

        return Errors.Breakfast.NotFound;

    }

    public void Update(Breakfast breakfast)
    {
        _breakfast[breakfast.Id] = breakfast;
    }
}
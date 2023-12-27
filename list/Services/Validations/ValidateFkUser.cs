using list.Infrastructure.Data;

namespace list.Services.Validations;

public class ValidateFkUser
{
    private readonly DataContext _dataContext;

    public ValidateFkUser(DataContext dataContext)
    {
        this._dataContext = dataContext;
    }

    public bool ExistsUserFk(int userId)
    {
        return _dataContext.Users.Any(d => d.Id == userId);
    }
}
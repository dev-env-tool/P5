using Microsoft.EntityFrameworkCore;
using P5WebApp.Models.Entities;
using static P5WebApp.Models.Entities.Add;

namespace P5WebApp.Models.Repositories
{
    public class AddRepository
    {
        //// Create a readonly collection for readonly purpose
        //private readonly List<Add>? _addList = new List<Add>();

        //public IReadOnlyList<Add> AddList => _addList.AsReadOnly();


        //public void LoadAddListFromDb(DbContext context)
        //{
        //    _addList.Clear();
        //    _addList.AddRange(context.Add.ToList());
        //}

    }
}

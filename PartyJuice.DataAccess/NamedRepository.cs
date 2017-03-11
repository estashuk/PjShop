using PartyJuice.DbEntity;

namespace PartyJuice.DataAccess
{
    public class NamedRepository<T> : BaseRepository<T> where T : NameEntity
    {
         
    }
}
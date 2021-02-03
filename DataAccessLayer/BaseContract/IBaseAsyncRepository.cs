using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DataAccessLayer.BaseContract
{
    public interface IBaseAsyncRepository<RemoveInput,GetAllResult,UpdateInput,InsertInput,Key>
    {
        public void Remove(RemoveInput entity, bool isSave=false);
        public void Remove(Key key, bool isSave = false);
        public  Task<IEnumerable<GetAllResult>> GetAllAsync();
        public UpdateInput Update(UpdateInput entity, bool isSave = false);
        public Task<int> InsertAsync(InsertInput entity, CancellationToken token, bool isSave = false);
        public Task<int> SaveChangesAsync(CancellationToken token);
        public int SaveChanges();

    }

}

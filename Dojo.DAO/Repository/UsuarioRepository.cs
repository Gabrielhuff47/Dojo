
using System.Runtime.InteropServices;
using Dojo.DAO.BaseRepository;
using Dojo.DAO.Context;
using Microsoft.EntityFrameworkCore;

namespace Dojo.DAO.Repository;

public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
{
    public UsuarioRepository(DbdojoContext context) : base(context)
    {
    }


    public async Task AddAsync(Usuario entity)
    {
        await base.AddAsync(entity);
    }

    public async Task DeleteAsync(int id)
    {
        await base.DeleteAsync(id);
    }

    public async Task UdateAsync(Usuario entity)
    {
        await base.UdateAsync(entity);
    }

    public async Task<IEnumerable<Usuario>> GetAllAsync()
    {
        return await base.GetAllAsync();
    }

    public async Task<Usuario> GetByIdAsync(int id)
    {
        return await base.GetByIdAsync(id);
    }

    
}

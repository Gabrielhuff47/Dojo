using Dojo.DAO.Context;
using Dojo.DAO.Repository;

namespace Dojo.BLL;

public class UsuarioService : IUsuarioService
{

    private readonly IUsuarioRepository _repository;

    public UsuarioService(IUsuarioRepository usuarioRepository)
    {
        _repository = usuarioRepository;
    }
    public async Task AddAsync(Usuario usuario)
    {
      if(usuario == null)
        throw new ArgumentException("Objeto enviado é nulo");

      if(string.IsNullOrEmpty (usuario.Nome))
        throw new ArgumentException("O campo nome não pode estar em branco");

      if(string.IsNullOrEmpty(usuario.Cpf))
      throw new ArgumentException("o Campo cpf nao pode estar em branco");

      await _repository.AddAsync(usuario);
    }

    public async Task DeleteAsync(int id)
    {
        if (id == 0){
            throw new ArgumentException("o Id do usuário não pode ser zero!");
        }

        await _repository.DeleteAsync(id);
    }

    public async Task<IEnumerable<Usuario>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Usuario> GetByIdAsync(int id)
    {
       if (id == 0){
            throw new ArgumentException("o Id do usuário não pode ser zero!");
        }
        
        return await _repository.GetByIdAsync(id);
    }

    public async Task UpdateAsync(Usuario usuario)
    {
           {
      if(usuario == null)
        throw new ArgumentException("Objeto enviado é nulo");

      if(string.IsNullOrEmpty (usuario.Nome))
        throw new ArgumentException("O campo nome não pode estar em branco");

      if(string.IsNullOrEmpty(usuario.Cpf))
      throw new ArgumentException("o Campo cpf nao pode estar em branco");

       await _repository.UpdateAsync(usuario);
    }
    }

}

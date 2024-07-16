
using Dojo.DAO.Context;
using Dojo.DAO.Repository;
using Microsoft.EntityFrameworkCore;

namespace Dojo.Test;

public class UsuarioRepositoryTest
{
    private readonly UsuarioRepository _usuarioRepository;

    private readonly DbdojoContext _context;

    public UsuarioRepositoryTest()
    {
        Environment.SetEnvironmentVariable("IS_TEST", "True");

        var options = new DbContextOptionsBuilder<DbdojoContext>()
        .UseInMemoryDatabase(databaseName: "TestDatabase")
        .Options;

        _context = new MockDbContext(options);
        _usuarioRepository = new UsuarioRepository(_context);

    }

    [Fact]
    public async Task GetByIdAsync_ReturnsUser()
    {
        var usuario = new Usuario
        {
            Id = 1,
            Nome = "Usuario teste",
            Cpf = " 19192301"
        };

        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();

        var usuarioDoBancoDados = await _usuarioRepository.GetByIdAsync(usuario.Id);


        Assert.NotNull(usuarioDoBancoDados);
        Assert.Equal(usuario.Id, usuarioDoBancoDados.Id);
    }
}

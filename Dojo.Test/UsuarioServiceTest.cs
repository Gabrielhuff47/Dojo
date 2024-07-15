
using Dojo.BLL;
using Dojo.DAO.Context;
using Dojo.DAO.Repository;
using Moq;



namespace Dojo.Test;

public class UsuarioServiceTest
{
    private readonly UsuarioService _usuarioService;

    private readonly Mock<IUsuarioRepository> _usuarioRepositoryMock;

    public UsuarioServiceTest()
    {
        _usuarioRepositoryMock = new Mock<IUsuarioRepository>();
        _usuarioService = new UsuarioService(_usuarioRepositoryMock.Object);
    }

    [Fact]
    public async Task DeveRetornaUmUsuarioPelId(){
        _usuarioRepositoryMock.Setup(repo => repo.GetByIdAsync(It.IsAny<int>()))
        .ReturnsAsync(new Usuario { Id = 1, Nome = "Enzon Test", Cpf = "19100000"});
    


    var usuario = await _usuarioService.GetByIdAsync(1);

    Assert.Equal(1, usuario.Id);
    Assert.NotNull(usuario);
    
    }

    // [Fact]            // melhorar essse teste
    // public async Task DeveFalharAoInserirUmUsuarioComIdZero(){
    //      _usuarioRepositoryMock.Setup(repo => repo.GetByIdAsync(It.IsAny<int>()))
    //     .ReturnAsync(new Usuario { Id = 0, Nome = "Enzon Test", Cpf = "19100000"});
    // // 
    //     var usuario = await _usuarioService.GetByIdAsync(0);

    //     Assert.Null(usuario);

    
    // }


}

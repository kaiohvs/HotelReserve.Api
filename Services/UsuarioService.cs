using HotelReserve.Api.Data;
using HotelReserve.Api.Models;

namespace HotelReserve.Api.Services
{
    public class UsuarioService
    {
        private readonly HotelContext _context;

        public UsuarioService(HotelContext context)
        {
            _context = context;
        }

        public Usuario RegistrarUsuario(string nome, string email, string senha)
        {
            if (_context.Usuarios.Any(u => u.Email == email))
            {
                return null; // Usuário já existe
            }

            var novoUsuario = new Usuario
            {
                Nome = nome,
                Email = email,
                Senha = senha
            };

            _context.Usuarios.Add(novoUsuario);
            _context.SaveChanges();
            return novoUsuario;
        }

        public Usuario VerificarLogin(string email, string senha)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }
    }

}

using ProiectDAW.Models;
using ProiectDAW.Models.Enum;
using ProiectDAW.Models.DTOs.UserDTOs;
using ProiectDAW.Helpers.Utils;
using ProiectDAW.Repositories.UsersRepository;
using BCryptNet = BCrypt.Net.BCrypt;
using AutoMapper;
using ProiectDAW.Repositories.UnitOfWork;

namespace ProiectDAW.Services.UsersService
{
    public class UsersService : IUsersService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtUtils _jwtUtils;
        private readonly IMapper _mapper;

        public UsersService(IUnitOfWork unitOfWork, IJwtUtils jwtUtils, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _jwtUtils = jwtUtils;
            _mapper = mapper;
        }

        public UserResponseDTO Authenticate(string username, string password)
        {
            var user = _unitOfWork._usersRepository.GetByUsername(username);

            if (user == null) return null;
            if (!BCryptNet.Verify(password, user.PasswordHash)) return null;

            var jwtToken = _jwtUtils.GenerateJwtToken(user);

            return new UserResponseDTO(user, jwtToken);
        }

        public Guid GetCurrentUserId(string jwtToken)
        {
            var currentUserId = _jwtUtils.ValidateJwtToken(jwtToken);

            return currentUserId;
        }

        public async Task Register(User user)
        {
            await _unitOfWork._usersRepository.CreateAsync(user);
            await _unitOfWork.SaveAsync();
        }

        public async Task<List<UserGetDTO>> GetAllUsers()
        {
            var users = await _unitOfWork._usersRepository.GetAllAsync();
            List<UserGetDTO> result = _mapper.Map<List<UserGetDTO>>(users);
            return result;
        }

        public async Task<UserGetDTO> GetUserById(Guid id)
        {
            var user = await _unitOfWork._usersRepository.GetByIdAsync(id);
            UserGetDTO result = _mapper.Map<UserGetDTO>(user);
            return result;
        }

        public async Task<List<UserGetInfoDTO>> GetInfoAllUsers()
        {
            var users = await _unitOfWork._usersRepository.GetAllIncludeOrders();
            List<UserGetInfoDTO> result = _mapper.Map<List<UserGetInfoDTO>>(users); 
            return result;
        }

        public async Task<UserGetInfoDTO> GetInfoUserById(Guid id)
        {
            var user = await _unitOfWork._usersRepository.GetByIdIncludeOrders(id);
            UserGetInfoDTO result = _mapper.Map<UserGetInfoDTO>(user);
            return result;
        }

        public async Task<Guid> MakeCustomer(string username, string jwtToken)
        {
            var currentUserId = _jwtUtils.ValidateJwtToken(jwtToken);

            if (currentUserId == Guid.Empty) return Guid.Empty;

            var userToEdit = _unitOfWork._usersRepository.GetByUsername(username);

            if (userToEdit == null) return Guid.Empty;

            if (userToEdit.Id == currentUserId) return Guid.Empty;

            if (userToEdit.Role == Role.Customer) return Guid.Empty;

            userToEdit.Role = Role.Customer;
            userToEdit.DateModified = DateTime.UtcNow;

            await _unitOfWork.SaveAsync();

            return userToEdit.Id;
        }

        public async Task<Guid> MakeAdmin(string username, string jwtToken)
        {
            var currentUserId = _jwtUtils.ValidateJwtToken(jwtToken);

            if (currentUserId == Guid.Empty) return Guid.Empty;

            var userToEdit = _unitOfWork._usersRepository.GetByUsername(username);

            if (userToEdit == null) return Guid.Empty;

            if (userToEdit.Id == currentUserId) return Guid.Empty;

            if (userToEdit.Role == Role.Admin) return Guid.Empty;

            userToEdit.Role = Role.Admin;
            userToEdit.DateModified = DateTime.UtcNow;

            await _unitOfWork.SaveAsync();

            return userToEdit.Id;
        }

        public async Task<List<User>> DeleteUser(string username, string jwtToken)
        {
            var currentUserId = _jwtUtils.ValidateJwtToken(jwtToken);

            if (currentUserId == Guid.Empty) return null;

            var userToDelete = _unitOfWork._usersRepository.GetByUsername(username);

            if (userToDelete == null) return null;

            if (userToDelete.Id == currentUserId) return null;

            _unitOfWork._usersRepository.Delete(userToDelete);

            await _unitOfWork.SaveAsync();

            return await _unitOfWork._usersRepository.GetAllAsync();
        }
    }
}

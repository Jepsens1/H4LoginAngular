using H4LoginAPI.Database;
using H4LoginAPI.Model;

namespace H4LoginAPI.Managers
{
    public class LoginManager
    {
        DataAccess _dbaccess;
        private ICrypto _crypto;

        public LoginManager(ICrypto crypto)
        {
            _crypto = crypto;
        }
        public string Register(string username, string password)
        {
            try
            {
                _dbaccess = new DataAccess();
                byte[] salt = _crypto.GenerateSalt();
                _dbaccess.RegisterUser(new User(username, Convert.ToBase64String(_crypto.CreateHash(password, salt)), Convert.ToBase64String(salt)));
                return "User created";
            }
            catch (Exception)
            {
                throw;
            };
        }

        public string Login(string username, string password)
        {
            try
            {
                _dbaccess = new DataAccess();
                User user = _dbaccess.Login(username);
                if (user == null)
                {
                    return "Could not find user";

                }
                if (_crypto.Verify(user.Password, password, Convert.FromBase64String(user.Salt)))
                {
                    //Updating the user password and salt when we can verify login
                    byte[] salt = _crypto.GenerateSalt();
                    _dbaccess.UpdatePassWord(username, Convert.ToBase64String(_crypto.CreateHash(password, salt)), Convert.ToBase64String(salt));
                    return "Login Sucess";
                }
                return "Login Failed";
            }
            catch (Exception)
            {
                throw;
            }
            
        }
    }
}

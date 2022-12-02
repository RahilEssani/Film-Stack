using FilmStack.Models.Interfaces;

namespace FilmStack.Models.Repository
{
    public class AdminData : IAdmin
    {
        private FilmStackDBContext FST;
        public AdminData()
        {
            FST = new FilmStackDBContext();

        }
        public bool ApproveSignup(string email)
        {
            try
            {
                var signup = (from s in FST.AdminSignups
                            where s.Email == email
                            select s).First();
                    var newLogin = new Login { Email = signup.Email, Country = signup.Country, Name = signup.Name, Password = signup.Password };
                    FST.AdminLogins.Add(newLogin);
                    FST.AdminSignups.Remove(signup);
                    FST.SaveChanges();
                    return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Signup> GetPendingRequests()
        {
            try
            {
                var users = FST.AdminSignups.ToList();
                return users;
            }
            catch
            {
                return new List<Signup>();
            }
        }


        public Login GetUser(string login)
        {
            try
            {
                var user = (from s in FST.AdminLogins
                            where s.Email == login
                            select s).First();
                return user;
            }
            catch
            {
                return null;
            }
        }

        public bool StoreSignup(Signup signup)
        {
            try
            {
                Login login = new Login { Email = signup.Email , Password=signup.Password};
                if(!ValidateUserEmail(login))
                {
                    var user = (from s in FST.AdminSignups
                                where s.Email == login.Email
                                select s).Count();
                    if(user <= 0)
                    {
                        FST.AdminSignups.Add(signup);
                        FST.SaveChanges();
                        return true;
                    }      
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool ValidateUser(Login login)
        {
            try
            {
                var user = (from s in FST.AdminLogins
                            where (s.Email == login.Email && s.Password == login.Password)
                            select s).First();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool ValidateUserEmail(Login login)
        {
            try
            {
                var user = (from s in FST.AdminLogins
                            where s.Email == login.Email
                            select s).First();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

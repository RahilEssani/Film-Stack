namespace FilmStack.Models.Interfaces
{
    public interface IAdmin
    {

        public bool StoreSignup(Signup signup);
        public bool ApproveSignup(string signup);

        public bool ValidateUser(Login login);
        public Login GetUser(string login);
        public List<Signup> GetPendingRequests();
    }
}

using CommentManagement.Entity.Users;

namespace CommentManagement.Entity.Test.Users
{
    internal class UserBuilder
    {
        private string _email;

        public UserBuilder WithEmail(string email)
        {
            _email = email;
            return this;
        }

        public User Build() 
        {
            return new User(_email);
        }
    }
}

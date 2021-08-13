using System;

namespace ForeignWay.DeliveryManager.Types.Users
{
    public class User
    {
        public Guid Id { get; }

        public string UserName { get; }

        public string Password { get; }

        public UserType UserType { get; }


        public User(Guid id, string userName, string password, UserType userType)
        {
            Id = id;
            UserName = userName;
            Password = password;
            UserType = userType;
        }


        public static User GetEmpty()
        {
            return new User(Guid.Empty, "none", "none", UserType.None);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id.GetHashCode(),
                UserName.GetHashCode(),
                Password.GetHashCode(),
                UserType.GetHashCode());
        }

        public override bool Equals(object? obj)
        {
            if (obj != null && obj.GetType() == typeof(User))
            {
                var user = (User)obj;

                return user.Id.Equals(Id) &&
                       user.UserName.Equals(UserName) &&
                       user.Password.Equals(Password) &&
                       user.UserType.Equals(UserType);
            }

            return false;
        }

        public override string ToString()
        {
            return $"UserName={UserName}, UserType={UserType}";
        }
    }
}
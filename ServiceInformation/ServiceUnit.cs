namespace ServiceInformation
{
    public class ServiceUnit : Unit
    {
        public ServiceUnit(string name) : base(name)
        {
            Name += ".service";
        }

        public string GetGroup()
        {
            const string propertyName = "Group";

            var group = GetPropertyValue(propertyName);

            if (group == string.Empty)
            {
                group = "None";
            }

            return group;
        }

        public string GetUser()
        {
            const string propertyName = "User";

            var user = GetPropertyValue(propertyName);

            if (user == string.Empty)
            {
                user = "None";
            }

            return user;
        }
    }
}
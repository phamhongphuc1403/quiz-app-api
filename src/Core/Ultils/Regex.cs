namespace quiz_app_api.src.Core.Ultils
{
    public class Regex
    {
        public const string PASSWORD = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";
        public const string EMAIL = @"^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$";
    }
}

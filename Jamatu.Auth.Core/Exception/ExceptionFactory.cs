using System.Linq;
using System.Reflection;

namespace Jamatu.Auth.Core.Exception
{
    public static class ExceptionFactory
    {
        private static T GenerateException<T>(string method, string instance, string detail = null) where T : System.Exception
        {
            var methodInfo = typeof(ExceptionFactory).GetMethods(BindingFlags.Static | BindingFlags.Public)
                .First(x => x.Name == method);

            var attribute = methodInfo.GetCustomAttributes<ErrorCodeAttribute>().First();
            var constructorInfo = typeof(T).GetConstructor(new[] { typeof(string), typeof(string), typeof(short), typeof(string)});
            var parameters = new object[] { instance, attribute.Title, attribute.Code, detail };

            return (T)constructorInfo!.Invoke(parameters);
        }
        [ErrorCode(100, "The username is already taken. Pick another one")]
        public static ApplicationException UsernameExists(string module)
        {
            return GenerateException<ApplicationException>(MethodBase.GetCurrentMethod()!.Name, module, null);
        }
        [ErrorCode(101, "The user does not exist")]
        public static ApplicationException UserDoesNotExists(string module)
        {
            return GenerateException<ApplicationException>(MethodBase.GetCurrentMethod()!.Name, module, null);
        }
        [ErrorCode(102, "Token could not be validated. Please get a new token")]
        public static ApplicationException TokenValidationFailed(string module)
        {
            return GenerateException<ApplicationException>(MethodBase.GetCurrentMethod()!.Name, module, null);
        }
        [ErrorCode(103, "Password is not correct")]
        public static ApplicationException WrongPassword(string module)
        {
            return GenerateException<ApplicationException>(MethodBase.GetCurrentMethod()!.Name, module, null);
        }
        [ErrorCode(104, "User not logged in")]
        public static ApplicationException NotLoggedIn(string module)
        {
            return GenerateException<ApplicationException>(MethodBase.GetCurrentMethod()!.Name, module, null);
        }
    }
}

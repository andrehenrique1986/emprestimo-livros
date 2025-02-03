using System.Security.Claims;

namespace EmprestimoLivros.Infra.Ioc
{
    public static class ClaimsPrincipalExtentions
    {
        public static int GetId(this ClaimsPrincipal user)
        {
            return int.Parse(user.FindFirst("id").Value);
        }

        public static string GetEmail(this ClaimsPrincipal user)
        {
            return user.FindFirst("email").Value;
        }
    }
}

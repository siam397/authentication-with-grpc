using Grpc.Core;

namespace AuthenticationGrpc.Services
{
    public class LoginService:Login.LoginBase
    {
        private AuthHandler _authHandler;
        public LoginService()
        {
            _authHandler = new AuthHandler();
        }
        public override Task<LoginReply> loginUser(LoginRequest request, ServerCallContext context)
        {
            if (_authHandler.findUser(request.Username) == null)
            {
                return Task.FromResult(new LoginReply
                {
                    Message = "Wrong username."
                });
            }

            if (_authHandler.verifyUser(request.Username, request.Password))
            {
                return Task.FromResult(new LoginReply
                {
                    Message = "Wrong password."
                });
            }

            return Task.FromResult(new LoginReply
            {
                Message = $"Logged in as {request.Username}"
            });

        }
    }
}

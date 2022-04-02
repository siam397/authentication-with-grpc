using Grpc.Core;

namespace AuthenticationGrpc.Services
{
    public class SignupService:Signup.SignupBase
    {
        private AuthHandler _authHandler;

        public SignupService()
        {
            _authHandler = new AuthHandler();
        }

        public override Task<SignupReply> signupUser(SignupRequest request, ServerCallContext context)
        {
            if (_authHandler.findUser(request.Username) == null)
            {
                return Task.FromResult(new SignupReply
                {
                    Message = $"{request.Username} already exists."
                });
            }

            _authHandler.createUser(request.Username, request.Password);

            return Task.FromResult(new SignupReply
            {
                Message = $"{request.Username} created."
            });
        }
    }
}

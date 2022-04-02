using AuthenticationGrpc;
using AuthenticationGrpc.Db;
using AuthenticationGrpc.Model;
using Grpc.Core;

namespace AuthenticationGrpc.Services
{
    public class AuthService : Auth.AuthBase
    {
        private AuthHandler authHandler;
        public AuthService()
        {
            this.authHandler = new AuthHandler();
        }

        public override async Task<SignupReply> SignUp(SignupRequest request, ServerCallContext context)
        {
            
            if (authHandler.findUser(request.Username) != null)
            {
                return await Task.FromResult(new SignupReply
                {
                    Message = $"{request.Username} already exists."
                });
            }

            authHandler.createUser(request.Username,request.Password);

            return await Task.FromResult(new SignupReply
            {
                Message = $"Signup Successful for user {request.Username}"
            });
        }


        public override Task<LoginReply> Login(LoginRequest request, ServerCallContext context)
        {

            if (authHandler.verifyUser(request.Username, request.Password))
            {
                return Task.FromResult(new LoginReply
                {
                    Message = $"Login Successful for user {request.Username}"
                });
            }

            return Task.FromResult(new LoginReply
            {
                Message = $"Wrong password"
            });



        }

    }
}
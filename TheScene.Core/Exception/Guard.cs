namespace TheScene.Core.Exception
{
    public class Guard : IGuard
    {
        public void AgainstNull<T>(T value, string? errorMessage = null)
        {
            if (value == null)
            {
                var exception = errorMessage == null ?
                    new SceneException() :
                    new SceneException(errorMessage);

                throw exception;
            }
        }
    }
}

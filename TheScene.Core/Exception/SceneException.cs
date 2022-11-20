namespace TheScene.Core.Exception
{
    public class SceneException : ApplicationException
    {
        public SceneException()
        {

        }

        public SceneException(string errorMessage)
            : base(errorMessage)
        {

        }
    }
}

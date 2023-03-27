namespace OneCook.BL.Services.Interfaces
{
    public interface ILikeServiceBL
    {
        void LikePost(int recipeId, int userId);
        void RemoveLike(int recipeId, int userId);
    }
}

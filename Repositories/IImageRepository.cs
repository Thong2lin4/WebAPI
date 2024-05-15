using LAB_LTW_API.Models;

namespace LAB_LTW_API.Repositories
{
    public interface IImageRepository
    {
        Image Upload (Image image);
        List<Image> GetAllInfoImages();
        (byte[], string, string) DownloadFile(int Id);
    }
}

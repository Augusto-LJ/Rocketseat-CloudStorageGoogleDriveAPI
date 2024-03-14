using Microsoft.AspNetCore.Http;

namespace CloudStorageGoogleDriveAPI.Application.UseCases.Users.UploadProfilePhoto;

public interface IUploadProfilePhotoUseCase
{
    public void Execute(IFormFile file);
}

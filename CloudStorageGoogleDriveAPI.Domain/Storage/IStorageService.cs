using CloudStorageGoogleDriveAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace CloudStorageGoogleDriveAPI.Domain.Storage;

public interface IStorageService
{
    string Upload(IFormFile file, User user);
}

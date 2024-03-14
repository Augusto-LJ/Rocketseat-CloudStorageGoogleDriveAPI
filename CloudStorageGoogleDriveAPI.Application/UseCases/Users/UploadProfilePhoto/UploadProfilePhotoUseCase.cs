using CloudStorageGoogleDriveAPI.Domain.Entities;
using CloudStorageGoogleDriveAPI.Domain.Storage;
using FileTypeChecker.Extensions;
using FileTypeChecker.Types;
using Microsoft.AspNetCore.Http;

namespace CloudStorageGoogleDriveAPI.Application.UseCases.Users.UploadProfilePhoto;

public class UploadProfilePhotoUseCase : IUploadProfilePhotoUseCase
{
    private readonly IStorageService _storageService;
    public UploadProfilePhotoUseCase(IStorageService storageService)
    {
        _storageService = storageService;
    }

    public void Execute(IFormFile file)
    {
        var fileStream = file.OpenReadStream();

        var isImage = fileStream.Is<JointPhotographicExpertsGroup>();

        if (!isImage)
            throw new Exception("The file is not an image.");

        var user = GetFromDatabase();

        _storageService.Upload(file, user);
    }

    private User GetFromDatabase()
    {
        return new User
        {
            Id = 1,
            Name = "Augusto",
            Email = "augustolimajardim@gmail.com",
            RefreshToken = "1//04OtJHQzfX5B-CgYIARAAGAQSNwF-L9Ir8SWFYZTCO1XSAGcT8mFN6yXpwOjVlqKOPClP47AvgGwfTY6bUFfgKrNe5uJPYKtDJxA",
            AccessToken = "ya29.a0Ad52N3_0fmGLnAvo-xnFwC3jvlOSlpkzAHO7WUQkV3N-RKGfLgCgihTXqzvW_D_iDI3sEoJsvsfD7Ial7dzL5YbtBXxL3uyGABp2peuHx69BJD-qLhmfx1HuZ4q_W3Hphb4Uzf0I2PAUMHq1Wrmhi3Jl0nRwhVz_lOYaaCgYKARASARASFQHGX2MiPc8db5c545BPrTaAZh_SmQ0171"
        };
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mcparts.Infrastructure.FileDocumentManager
{
    public interface IFileDocumentService
    {
        Task<string> UploadAsync(
            string? originalFileName,
            string? docExtension,
            byte[]? fileData,
            long? size,
            string? description = "",
            string? createdById = "",
            CancellationToken cancellationToken = default);

        Task<byte[]> GetFileAsync(string fileName, CancellationToken cancellationToken = default);
    }
}

using car_system.Models.DTO;
using car_system.Models.Entities;

namespace car_system.Controllers.Services
{
	public interface IAttachmentService
	{
        Task<AttachmentDTO> GetAttachmentByUserId(string userId);
        Task<AttachmentDTO> CreateAttachment(AttachmentDTO attachmentDto);
        Task<AttachmentDTO> UpdateAttachment(AttachmentDTO attachmentDto);
        Task<bool> DeleteAttachment(int attachmentId);
    }
}

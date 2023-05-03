using car_system.Controllers.Data;
using car_system.Models.DTO;
using car_system.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace car_system.Controllers.Services
{
    public class AttachmentService : IAttachmentService
    {
        private readonly ApplicationDbContext _dbContext;

        public async Task<AttachmentDTO> CreateAttachment(AttachmentDTO attachmentDto)
        {
            // Validate the attachment DTO
            var validationContext = new ValidationContext(attachmentDto, serviceProvider: null, items: null);
            var validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(attachmentDto, validationContext, validationResults, validateAllProperties: true);

            if (!isValid)
            {
                string errorMessages = string.Join("; ", validationResults.Select(r => r.ErrorMessage));
                throw new ArgumentException($"Invalid attachment data: {errorMessages}");
            }

            // Validate the image size
            if (attachmentDto.CitizenshipImage.Length > 1.5 * 1024 * 1024) // 1.5MB in bytes
            {
                throw new ArgumentException("Attachment image size exceeds the limit of 1.5MB.");
            }

            // Create a new Attachment entity from the DTO
            Attachment attachment = new Attachment
            {
                Citizenship = attachmentDto.CitizenshipImage, // Update this line if CitizenshipImage is not the same as Citizenship
                UserID = attachmentDto.UserID
            };

            // Add the Attachment entity to the database
            _dbContext.Attachments.Add(attachment);
            await _dbContext.SaveChangesAsync();

            // Create a new AttachmentDTO from the created Attachment entity
            AttachmentDTO createdAttachmentDto = new AttachmentDTO
            {
                CitizenshipImage = attachment.Citizenship,
                UserID = attachment.UserID
            };

            return createdAttachmentDto;
        }

        public Task<bool> DeleteAttachment(int attachmentId)
        {
            throw new NotImplementedException();
        }

        public async Task<AttachmentDTO> GetAttachmentByUserId(string userId)
        {
            Attachment attachment = await _dbContext.Attachments.FirstOrDefaultAsync(a => a.UserID == userId);
            if (attachment == null)
            {
                return null;
            }

            // Create a new AttachmentDTO from the retrieved Attachment entity
            AttachmentDTO attachmentDto = new AttachmentDTO
            {
                CitizenshipImage = attachment.Citizenship,
                UserID = attachment.UserID
            };

            return attachmentDto;
        }

        public async Task<AttachmentDTO> UpdateAttachment(AttachmentDTO attachmentDto)
        {
            // Validate the attachment DTO
            //if (!ValidateAttachmentDTO(attachmentDto))
            //{
            //    throw new ArgumentException("Invalid attachment data");
            //}

            //// Find the Attachment entity in the database
            //Attachment attachment = await _dbContext.Attachments.FirstOrDefaultAsync(a => a.UserID == attachmentDto.UserID);
            //if (attachment == null)
            //{
            //    return null;
            //}

            //// Update the Attachment entity with the values from the DTO
            //attachment.DrivingLicense = attachmentDto.DrivingLicense;
            //attachment.Citizenship = attachmentDto.Citizenship;

            //// Save the changes to the database
            //_dbContext.Attachments.Update(attachment);
            await _dbContext.SaveChangesAsync();

            // Return the updated AttachmentDTO
            return attachmentDto;
        }
    }
}

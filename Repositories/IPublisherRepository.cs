using LAB_LTW_API.Models.Domain;
using LAB_LTW_API.Models.DTO;
using static LAB_LTW_API.Models.DTO.PublishersDTO;

namespace LAB_LTW_API.Repositories
{
    public interface IPublisherRepository
    {
        List<PublisherDTO> GetAllPublishers();
        PublisherNoIdDTO GetPublisherById(int id);
        AddPublishers AddPublisher(AddPublishers addPublisherRequestDTO);
        PublisherNoIdDTO UpdatePublisherById(int id, PublisherNoIdDTO publisherNoIdDTO);
        Publishers? DeletePublisherById(int id);
    }
}

using PetFamily.Domain.Common;
using PetFamily.Domain.ValueObjects;

namespace PetFamily.Domain.Entities;
public class SocialMedia: Entity
{
    private SocialMedia()
    {
    }
    public SocialMedia(string link, Social social)
    {
        Link = link;
        Social = social;
    }

    public Guid Id { get; set; }
    public string Link { get; set; }
    public Social Social { get; set; }
}